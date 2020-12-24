using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class DailyFiscalReportCommand : IFiscalCommand<DailyFiscalReportResponse>
    {
        private readonly DailyFiscalReportRequest request;

        public DailyFiscalReportCommand(DailyFiscalReportRequest request)
        {
            this.request = request;
        }

        public byte Byte => 69;

        public string RequestData
        {
            get
            {
                switch (request.DailyReportType)
                {
                    case DailyFiscalEnum.Kontrolen:
                        return "2";
                    case DailyFiscalEnum.ProshirenKFI:
                        return "3";
                    case DailyFiscalEnum.ZatvaranjeDen:
                        return "0";
                    default:
                        return "2";
                }
            }
        }

        public DailyFiscalReportResponse MapResponse(FiscalResponse fiscalResponse)
        {
            return new DailyFiscalReportResponse(fiscalResponse);
        }
    }
}
