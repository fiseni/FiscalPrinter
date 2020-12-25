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

        public byte Byte => (int)FiscalCommandsEnum.DailyFiscalReport;

        public string RequestData
        {
            get
            {
                switch (request.DailyReportType)
                {
                    case DailyFiscalEnum.Control:
                        return "2";
                    case DailyFiscalEnum.ExtendedKFI:
                        return "3";
                    case DailyFiscalEnum.DayClosure:
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

    public static partial class FiscalCommandFactoryExtensions
    {
        public static DailyFiscalReportCommand DailyFiscalReport(this IFiscalCommandFactory value, DailyFiscalReportRequest request)
            => new DailyFiscalReportCommand(request);
    }
}
