namespace OSDevGrp.OSIntranet.CommonLibrary.Resources
{
    /// <summary>
    /// Exception messages.
    /// </summary>
    public enum ExceptionMessage
    {
        NoConfigurationProviderFoundWithKey,
        ConfigurationSectionCouldNotBeReaded,
        CouldNotReadContainerConfiguration,
        TypeNotConfigured,
        InvalidType,
        WrongConfiguredType,
        ConfiguredTypeDoesNotImplementInterface,
        NoCommandHandlerRegisteredForType,
        NoCommandHandlerRegisteredForTypeAndReturnType,
        NoQueryHandlerRegisteredForTypeAndReturnType,
        TransactionError,
        ExceptionNotHandledByCommandHandler,
        NoInterfacesOnType,
    }
}
