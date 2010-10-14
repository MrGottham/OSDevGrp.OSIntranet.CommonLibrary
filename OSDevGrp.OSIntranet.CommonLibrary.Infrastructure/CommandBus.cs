using System;
using System.Collections.Generic;
using System.Linq;
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
            if (command.GetType() != typeof(TCommand) && command.GetType().GetInterface("ICommand") != null)
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

            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
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
            if (command.GetType() != typeof(TCommand) && command.GetType().GetInterface("ICommand") != null)
            {
                var dynamicInvoke = typeof (ICommandBus).GetMethods()
                    .First(m => m.Name == "Publish" && m.GetGenericArguments().Count() == 2)
                    .MakeGenericMethod(new[] {command.GetType(), typeof (TReturnValue)});
                return (TReturnValue) dynamicInvoke.Invoke(this, new object[] {command});
            }

            var mainSubscriber = _container.Resolve<ICommandHandler<TCommand, TReturnValue>>();
            var extraSubscriber = _container.Resolve<ICommandHandler<TCommand>>();
            if (mainSubscriber == null)
            {
                throw new CommandBusException(
                    Resource.GetExceptionMessage(ExceptionMessage.NoCommandHandlerRegisteredForTypeAndReturnType,
                                                 typeof (TCommand), typeof (TReturnValue)));
            }

            throw new System.NotImplementedException();
        }

        #endregion
    }
}
