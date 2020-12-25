using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class OpenFiscalBillCommand : IFiscalCommand<OpenFiscalBillResponse>
    {
        private readonly OpenFiscalBillRequest request;

        public OpenFiscalBillCommand(OpenFiscalBillRequest request)
        {
            this.request = request;
        }

        public byte Byte => 48;

        public string RequestData
        {
            get
            {
                return request.WaiterCode + "," + request.WaiterPin + "," + request.OperatorPlace;
            }
        }

        public OpenFiscalBillResponse MapResponse(FiscalResponse fiscalResponse)
        {
            return new OpenFiscalBillResponse(fiscalResponse);
        }
    }

    public static partial class FiscalCommandFactoryExtensions
    {
        public static OpenFiscalBillCommand OpenFiscalBill(this IFiscalCommandFactory value, OpenFiscalBillRequest request)
            => new OpenFiscalBillCommand(request);
    }
}
