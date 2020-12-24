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

        public bool Success { get; }
        public string PaidCode { get; }
        public decimal Amount { get; }
        public decimal ReturnAmount { get; }
    }
}
