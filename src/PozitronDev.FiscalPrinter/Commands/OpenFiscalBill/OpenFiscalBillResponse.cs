using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class OpenFiscalBillResponse : FiscalResponse
    {
        public OpenFiscalBillResponse(FiscalResponse response) : base(response)
        {
            var data = response.RawData.Split(',');

            int.TryParse(data[0], out var billNo);
            FiscalBillNo = billNo;

            if (data.Length > 1)
            {
                int.TryParse(data[1], out var cancelledBillNo);
                FiscalCancelledBillNo = cancelledBillNo;
            }
        }

        public int FiscalBillNo { get; set; }
        public int FiscalCancelledBillNo { get; set; }
    }
}
