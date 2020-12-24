using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class OpenCancelledFiscalBillCommand : IFiscalCommand<OpenCancelledFiscalBillResponse>
    {
        private readonly OpenCancelledFiscalBillRequest request;

        public OpenCancelledFiscalBillCommand(OpenCancelledFiscalBillRequest request)
        {
            this.request = request;
        }

        public byte Byte => 48;

        public string RequestData
        {
            get
            {
                return request.WaiterCode + "," + request.WaiterPin + "," + request.OperatorPlace + ",R";
            }
        }

        public OpenCancelledFiscalBillResponse MapResponse(FiscalResponse fiscalResponse)
        {
            return new OpenCancelledFiscalBillResponse(fiscalResponse);
        }
    }
}
