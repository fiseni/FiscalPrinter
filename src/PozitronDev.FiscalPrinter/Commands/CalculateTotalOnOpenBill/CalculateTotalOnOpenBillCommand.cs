using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class CalculateTotalOnOpenBillCommand : IFiscalCommand<CalculateTotalOnOpenBillResponse>
    {
        private readonly CalculateTotalOnOpenBillRequest request;

        public CalculateTotalOnOpenBillCommand(CalculateTotalOnOpenBillRequest request)
        {
            this.request = request;
        }

        public byte Byte => 53;

        public string RequestData
        {
            get
            {
                var paymentTypeString = "";
                switch (request.PaymentType)
                {
                    case PaymentTypeEnum.Cash:
                        paymentTypeString = "P";
                        break;
                    case PaymentTypeEnum.Credit:
                        paymentTypeString = "N";
                        break;
                    case PaymentTypeEnum.Pin:
                        paymentTypeString = "D";
                        break;
                }
                return "\t" + paymentTypeString + request.Amount.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        public CalculateTotalOnOpenBillResponse MapResponse(FiscalResponse fiscalResponse)
        {
            return new CalculateTotalOnOpenBillResponse(fiscalResponse);
        }
    }
}
