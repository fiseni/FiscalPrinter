namespace PozitronDev.FiscalPrinter
{
    internal interface ICommandProcessor
    {
        TResponse SendCommand<TResponse>(IFiscalCommand<TResponse> command) where TResponse : FiscalResponse;
    }
}