using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class FiscalResponse
    {
        public StatusEnum PrinterStatus { get; }
        public string StatusMsg { get; }
        public string RawData { get; }

        public FiscalResponse(StatusEnum printerStatus, string statusMsg, string rawData)
        {
            PrinterStatus = printerStatus;
            StatusMsg = statusMsg;
            RawData = rawData;
        }

        public FiscalResponse(FiscalResponse response) 
            : this(response.PrinterStatus, response.StatusMsg, response.RawData)
        {
        }
    }
}
