using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class FiscalResponse
    {
        public StatusEnum PrinterStatus { get; set; }
        public string StatusMsg { get; set; }
        public string Data { get; set; }

        public FiscalResponse()
        {
        }

        public FiscalResponse(FiscalResponse response)
        {
            PrinterStatus = response.PrinterStatus;
            StatusMsg = response.StatusMsg;
        }
    }
}
