using Accent.Ecr;
using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class FiscalPrinter
    {
        private readonly Ecr ecr;
        private readonly ICommandProcessor processor;

        public IFiscalCommandFactory Commands { get; } = new FiscalCommandFactory();

        public FiscalPrinter(string serialPort, int baudRate)
        {
            ecr = new Ecr(serialPort, baudRate);
            processor = new CommandProcessor(ecr);
        }

        public TResponse Send<TResponse>(IFiscalCommand<TResponse> command) where TResponse : FiscalResponse
        {
            return processor.SendCommand(command);
        }

        public FiscalResponse PrintBill(CreateFiscalBillRequest request)
        {
            return processor.PrintBill(request);
        }

        public FiscalResponse PrintCancelledBill(CreateFiscalCancelledBillRequest request)
        {
            return processor.PrintCancelledBill(request);
        }
    }
}
