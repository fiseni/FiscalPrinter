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

    public static partial class FiscalCommandFactoryExtensions
    {
        public static DailyFiscalReportCommand DailyFiscalReport(this IFiscalCommandFactory value, DailyFiscalReportRequest request)
            => new DailyFiscalReportCommand(request);
    }
}
