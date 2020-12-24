using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class OpenCancelledFiscalBillRequest : FiscalRequest
    {
        //FROM 1 - 8
        public int WaiterCode { get; set; }
        //DIGITS 4 - 6
        public int WaiterPin { get; set; }
        //NUMBER 1-5 digits
        public int OperatorPlace { get; set; }
    }
}
