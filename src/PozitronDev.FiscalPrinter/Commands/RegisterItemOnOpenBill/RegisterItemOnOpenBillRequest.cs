using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class RegisterItemOnOpenBillRequest : FiscalRequest
    {
        public bool IsNationalProduct { get; set; }
        public TaxEnum ItemTax { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal ItemQuantity { get; set; }
        public decimal ItemDiscountPercentage { get; set; }
    }
}
