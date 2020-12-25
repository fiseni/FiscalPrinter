using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    public class DailyFiscalReportRequest
    {
        public DailyFiscalEnum DailyReportType { get; set; } = DailyFiscalEnum.Control;
    }
}
