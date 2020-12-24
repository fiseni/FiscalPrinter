using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class CalculateTotalOnOpenBillResponse : FiscalResponse
    {
        // TODO: Should analyze the response and fill properties. [fatii, 12/24/2020]
        public CalculateTotalOnOpenBillResponse(FiscalResponse response) : base(response)
        {
            Success = true;
        }

        public bool Success { get; set; }
        public string PaidCode { get; set; }
        public decimal Amount { get; set; }
        public decimal ReturnAmount { get; set; }
    }
}
