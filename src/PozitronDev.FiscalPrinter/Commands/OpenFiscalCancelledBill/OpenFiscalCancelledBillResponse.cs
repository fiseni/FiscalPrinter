using PozitronDev.Convert;
using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class OpenFiscalCancelledBillResponse : FiscalResponse
    {
        public OpenFiscalCancelledBillResponse(FiscalResponse response) : base(response)
        {
            var data = response.RawData.Split(',');

            FiscalBillNo = data[0].To().IntOrDefault;

            if (data.Length > 1)
            {
                FiscalCancelledBillNo = data[1].To().IntOrDefault;
            }
        }

        public int FiscalBillNo { get; set; }
        public int FiscalCancelledBillNo { get; set; }
    }
}
