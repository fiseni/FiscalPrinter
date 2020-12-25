using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class OpenFiscalCancelledBillRequest : FiscalRequest
    {
        //FROM 1 - 8
        public int WaiterCode { get; set; } = 1;

        //DIGITS 4 - 6
        public int WaiterPin { get; set; } = 1;

        //NUMBER 1-5 digits
        public int OperatorPlace { get; set; } = 1;
    }
}
