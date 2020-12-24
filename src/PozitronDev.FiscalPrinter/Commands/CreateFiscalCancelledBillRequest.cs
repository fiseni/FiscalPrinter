using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class CreateFiscalCancelledBillRequest
    {
        public OpenFiscalCancelledBillRequest OpenBill { get; set; }
        public List<RegisterItemOnOpenBillRequest> Items { get; set; }
        public List<CalculateTotalOnOpenBillRequest> RegisterPayments { get; set; }
    }
}
