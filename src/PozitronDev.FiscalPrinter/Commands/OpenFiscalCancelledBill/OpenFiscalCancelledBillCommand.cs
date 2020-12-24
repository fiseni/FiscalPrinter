using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class OpenFiscalCancelledBillCommand : IFiscalCommand<OpenFiscalCancelledBillResponse>
    {
        private readonly OpenFiscalCancelledBillRequest request;

        public OpenFiscalCancelledBillCommand(OpenFiscalCancelledBillRequest request)
        {
            this.request = request;
        }

        public byte Byte => 85;

        public string RequestData
        {
            get
            {
                return request.WaiterCode + "," + request.WaiterPin + "," + request.OperatorPlace + ",R";
            }
        }

        public OpenFiscalCancelledBillResponse MapResponse(FiscalResponse fiscalResponse)
        {
            return new OpenFiscalCancelledBillResponse(fiscalResponse);
        }
    }
}
