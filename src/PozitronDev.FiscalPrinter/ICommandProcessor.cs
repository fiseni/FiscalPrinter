namespace PozitronDev.FiscalPrinter
{
    internal interface ICommandProcessor
    {
        CloseFiscalBillResponse PrintBill(CreateFiscalBillRequest request);
        CloseFiscalCancelledBillResponse PrintCancelledBill(CreateFiscalCancelledBillRequest request);
        TResponse SendCommand<TResponse>(IFiscalCommand<TResponse> command, bool initiateConnection = true) where TResponse : FiscalResponse;
    }
}