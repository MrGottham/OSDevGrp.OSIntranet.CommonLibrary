using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces.Exceptions;
using OSDevGrp.OSIntranet.CommonLibrary.IoC.Interfaces;
using OSDevGrp.OSIntranet.CommonLibrary.Resources;

namespace OSDevGrp.OSIntranet.CommonLibrary.Infrastructure
{
    /// <summary>
    /// Implementering af en CommandBus.
    /// </summary>
    public class CommandBus : ICommandBus
    {
        #region Private variables

        private readonly IContainer _container;

        #endregion

        #region Constructor

        /// <summary>
        /// Danner en CommandBus.
        /// </summary>
        /// <param name="container">Container til Inversion of Control.</param>
        public CommandBus(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        #endregion

        #region ICommandBus Members

        /// <summary>
        /// Publicering af kommando uden returværdi.
        /// </summary>
        /// <typeparam name="TCommand">Typen af kommandoen, som skal publiceres.</typeparam>
        /// <param name="command">Kommando, der skal publiceres.</param>
        public void Publish<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            // If the command we are receiving is actual a command inherited from the command 
            // defined by TCommand then we invoke the commandbus dynamically with the corrent
            // type.
            if (command.GetType() != typeof (TCommand) && command.GetType().GetInterface("ICommand") != null)
            {
                var dynamicInvoke = typeof (ICommandBus).GetMethods()
                    .First(m => m.Name == "Publish" && m.GetGenericArguments().Count() == 1)
                    .MakeGenericMethod(command.GetType());
                dynamicInvoke.Invoke(this, new object[] {command});
                return;
            }

            var subscribers = _container.ResolveAll<ICommandHandler<TCommand>>();
            if (subscribers == null || subscribers.Length == 0)
            {
                throw new CommandBusException(
                    Resource.GetExceptionMessage(ExceptionMessage.NoCommandHandlerRegisteredForType, typeof (TCommand)));
            }

            try
            {
                var transactionOptions = new TransactionOptions
                                             {
                                                 IsolationLevel = IsolationLevel.Serializable,
                                                 Timeout = new TimeSpan(0, 0, 30, 0)
                                             };
                using (var scope = new TransactionScope(TransactionScopeOption.Suppress, transactionOptions))
                {
                    ExecuteCommandHandlers(subscribers, command);
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                throw new CommandBusException(
                    Resource.GetExceptionMessage(ExceptionMessage.TransactionError, FormatMessage(ex)), ex);
            }
        }

        /// <summary>
        /// Publicering af kommandoer uden returværdier.
        /// </summary>
        /// <typeparam name="TCommand">Typen af de kommanoder, som skal publiceres.</typeparam>
        /// <param name="commands">Kommandoer, der skal publiceres.</param>
        public void Publish<TCommand>(IList<TCommand> commands) where TCommand : class, ICommand
        {
            if (commands == null)
            {
                throw new ArgumentNullException("commands");
            }

            try
            {
                var transactionOptions = new TransactionOptions
                                             {
                                                 IsolationLevel = IsolationLevel.Serializable,
                                                 Timeout = new TimeSpan(0, 0, 30, 0)
                                             };
                using (var scope = new TransactionScope(TransactionScopeOption.Suppress, transactionOptions))
                {
                    foreach (var command in commands)
                    {
                        Publish(command);
                    }
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                throw new CommandBusException(
                    Resource.GetExceptionMessage(ExceptionMessage.TransactionError, FormatMessage(ex)), ex);
            }
        }

        /// <summary>
        /// Publicering af kommando med returværdi.
        /// </summary>
        /// <typeparam name="TCommand">Typen af kommandoen, som skal publiceres.</typeparam>
        /// <typeparam name="TReturnValue">Typen af værdien, som kommandoen skal returnerer.</typeparam>
        /// <param name="command">Kommando, der skal publiceres.</param>
        /// <returns>Værdi, som kommandoen returnerer efter eksekvering.</returns>
        public TReturnValue Publish<TCommand, TReturnValue>(TCommand command) where TCommand : class, ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            // If the command we are receiving is actual a command inherited from the command 
            // defined by TCommand then we invoke the commandbus dynamically with the corrent
            // type.
            if (command.GetType() != typeof (TCommand) && command.GetType().GetInterface("ICommand") != null)
            {
                var dynamicInvoke = typeof (ICommandBus).GetMethods()
                    .First(m => m.Name == "Publish" && m.GetGenericArguments().Count() == 2)
                    .MakeGenericMethod(new[] {command.GetType(), typeof (TReturnValue)});
                return (TReturnValue) dynamicInvoke.Invoke(this, new object[] {command});
            }

            var mainSubscriber = _container.Resolve<ICommandHandler<TCommand, TReturnValue>>();
            var extraSubscribers = _container.ResolveAll<ICommandHandler<TCommand>>();
            if (mainSubscriber == null)
            {
                throw new CommandBusException(
                    Resource.GetExceptionMessage(ExceptionMessage.NoCommandHandlerRegisteredForTypeAndReturnType,
                                                 typeof (TCommand), typeof (TReturnValue)));
            }

            TReturnValue returnValue;
            try
            {
                using (
                    var scope = new TransactionScope(mainSubscriber.TransactionScopeOption,
                                                     mainSubscriber.TransactionOptions))
                {
                    returnValue = ExecuteAsUnitOfWork(mainSubscriber, command);
                    ExecuteCommandHandlers(extraSubscribers, command);
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                throw new CommandBusException(
                    Resource.GetExceptionMessage(ExceptionMessage.TransactionError, FormatMessage(ex)), ex);
            }
            return returnValue;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returnerer formateret fejlbesked for en exception.
        /// </summary>
        /// <param name="ex">Exception.</param>
        /// <returns>Formateret fejlbesked.</returns>
        private static string FormatMessage(Exception ex)
        {
            return ex.InnerException != null
                       ? string.Format("{0} -> {1}", ex.Message, FormatMessage(ex.InnerException))
                       : ex.Message;
        }

        /// <summary>
        /// Eksekvering af alle commandhandlers til kommandoen.
        /// </summary>
        /// <typeparam name="TCommand">Typen af kommandoen, som skal eksekveres.</typeparam>
        /// <param name="commandHandlers">Commandhandlers, der skal eksekveres.</param>
        /// <param name="command">Kommando, der skal eksekveres.</param>
        private static void ExecuteCommandHandlers<TCommand>(IEnumerable<ICommandHandler<TCommand>> commandHandlers, TCommand command) where TCommand : class, ICommand
        {
            if (commandHandlers == null)
            {
                return;
            }
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            foreach (var commandHandler in commandHandlers)
            {
                ExecuteAsUnitOfWork(commandHandler, command);
            }
        }

        /// <summary>
        /// Eksekvering af en commandhandler til kommandoen.
        /// </summary>
        /// <typeparam name="TCommand">Typen af kommandoen, som skal eksekveres.</typeparam>
        /// <param name="commandHandler">Commandhandleren, der ska eksekveres.</param>
        /// <param name="command">Kommando, der skal eksekveres.</param>
        private static void ExecuteAsUnitOfWork<TCommand>(ICommandHandler<TCommand> commandHandler, TCommand command) where TCommand : class, ICommand
        {
            if (commandHandler == null)
            {
                throw new ArgumentNullException("commandHandler");
            }
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            using (
                var scope = new TransactionScope(commandHandler.TransactionScopeOption,
                                                 commandHandler.TransactionOptions))
            {
                try
                {
                    commandHandler.Execute(command);
                }
                catch (Exception ex)
                {
                    if (IsExceptionMarkedForRethrow(commandHandler, ex))
                    {
                        throw;
                    }
                    commandHandler.HandleException(command, ex);
                }
                scope.Complete();
            }
        }

        /// <summary>
        /// Eksekvering af en commandhandler til kommandoen.
        /// </summary>
        /// <typeparam name="TCommand">Typen af kommandoen, som skal eksekveres.</typeparam>
        /// <typeparam name="TReturnValue">Typen af værdien, som kommandoen skal returnerer.</typeparam>
        /// <param name="commandHandler">Commandhandleren, der ska eksekveres.</param>
        /// <param name="command">Kommando, der skal eksekveres.</param>
        /// <returns>Værdi, som kommandoen returnerer efter eksekvering.</returns>
        private static TReturnValue ExecuteAsUnitOfWork<TCommand, TReturnValue>(ICommandHandler<TCommand, TReturnValue> commandHandler, TCommand command) where TCommand : class, ICommand
        {
            if (commandHandler == null)
            {
                throw new ArgumentNullException("commandHandler");
            }
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            using (
                var scope = new TransactionScope(commandHandler.TransactionScopeOption,
                                                 commandHandler.TransactionOptions))
            {
                try
                {
                    var returnValue = commandHandler.Execute(command);
                    scope.Complete();
                    return returnValue;
                }
                catch (Exception ex)
                {
                    if (IsExceptionMarkedForRethrow(commandHandler, ex))
                    {
                        throw;
                    }
                    commandHandler.HandleException(command, ex);
                }
            }
            throw new CommandBusException(
                Resource.GetExceptionMessage(ExceptionMessage.ExceptionNotHandledByCommandHandler, typeof (TCommand),
                                             typeof (TReturnValue)));
        }

        /// <summary>
        /// Undersøger, om den kastede exception er markeret til "Rethrow" i commandhandleren.
        /// </summary>
        /// <param name="commandHandler">Commandhandler, som har kastet exceptionen.</param>
        /// <param name="exception">Exception, der blev kastet.</param>
        /// <returns>True, hvis exception er markeret til "Rethrow", ellers false.</returns>
        private static bool IsExceptionMarkedForRethrow(ICommandHandler commandHandler, Exception exception)
        {
            if (commandHandler == null)
            {
                throw new ArgumentNullException("commandHandler");
            }
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }
            var targetType = DetermineTypeForAttributesReflection(commandHandler);
            var attributes =
                targetType.GetMethod("HandleException").GetCustomAttributes(typeof (RethrowExceptionAttribute), true) as
                RethrowExceptionAttribute[];
            if (attributes == null)
            {
                return false;
            }
            return attributes.Any(attribute => attribute.ExceptionTypes.Contains(exception.GetType()));
        }

        /// <summary>
        /// Determine which target type to use when trying to find attributes.
        /// </summary>
        private static Type DetermineTypeForAttributesReflection(ICommandHandler commandHandler)
        {
            object proxiedClass = null;
            // We know that DynamicProxy has an internal field called __target where it stores 
            // information about the class being proxied so we used this information to determine
            // if the commandhandler is really a proxy so we need to reflect attributes on the 
            // target of the proxy instead of the proxy itself.
            var targetField = commandHandler.GetType().GetField("__target");
            if (targetField != null)
            {
                proxiedClass = targetField.GetValue(commandHandler);
            }
            return proxiedClass != null ? proxiedClass.GetType() : commandHandler.GetType();
        }

        #endregion
    }
}
