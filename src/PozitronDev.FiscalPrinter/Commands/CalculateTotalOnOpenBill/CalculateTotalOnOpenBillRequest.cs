using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class CalculateTotalOnOpenBillRequest : FiscalRequest
    {
        public PaymentTypeEnum PaymentType { get; set; } = PaymentTypeEnum.Cash;
        public decimal Amount { get; set; }
    }
}
