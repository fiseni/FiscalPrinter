using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class CreateFiscalCancelledBillRequest
    {
        public OpenFiscalCancelledBillRequest OpenBill { get; set; } = new OpenFiscalCancelledBillRequest();
        public List<RegisterItemOnOpenBillRequest> Items { get; set; } = new List<RegisterItemOnOpenBillRequest>();
        public List<CalculateTotalOnOpenBillRequest> RegisterPayments { get; set; } = new List<CalculateTotalOnOpenBillRequest>();
    }
}
