using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class CreateFiscalBillRequest
    {
        public OpenFiscalBillRequest OpenBill { get; set; } = new OpenFiscalBillRequest();
        public List<RegisterItemOnOpenBillRequest> Items { get; set; } = new List<RegisterItemOnOpenBillRequest>();
        public List<CalculateTotalOnOpenBillRequest> RegisterPayments { get; set; } = new List<CalculateTotalOnOpenBillRequest>();
    }
}
