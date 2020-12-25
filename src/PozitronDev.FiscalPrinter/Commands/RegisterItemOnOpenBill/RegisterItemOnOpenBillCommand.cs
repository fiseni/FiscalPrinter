using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class RegisterItemOnOpenBillCommand : IFiscalCommand<FiscalResponse>
    {
        private readonly RegisterItemOnOpenBillRequest request;

        public RegisterItemOnOpenBillCommand(RegisterItemOnOpenBillRequest request)
        {
            this.request = request;
        }

        public byte Byte => 49;

        public string RequestData
        {
            get
            {
                var temp = request.IsNationalProduct ? "@" : "";
                var discount = request.ItemDiscountPercentage != 0 ? "," + request.ItemDiscountPercentage.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) : "";
                return request.ItemName + "\t" + temp + request.ItemTax + request.ItemPrice.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "*" + request.ItemQuantity.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture) + discount;

            }
        }

        public FiscalResponse MapResponse(FiscalResponse fiscalResponse)
        {
            return fiscalResponse;
        }
    }

    public static partial class FiscalCommandFactoryExtensions
    {
        public static RegisterItemOnOpenBillCommand RegisterItemOnOpenBill(this IFiscalCommandFactory value, RegisterItemOnOpenBillRequest request)
            => new RegisterItemOnOpenBillCommand(request);
    }
}
