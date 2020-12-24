namespace PozitronDev.FiscalPrinter
{
    internal interface ICommandProcessor
    {
        FiscalResponse PrintBill(CreateFiscalBillRequest request);
        FiscalResponse PrintCancelledBill(CreateFiscalCancelledBillRequest request);
        TResponse SendCommand<TResponse>(IFiscalCommand<TResponse> command, bool initiateConnection = true) where TResponse : FiscalResponse;
    }
}