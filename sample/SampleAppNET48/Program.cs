using PozitronDev.FiscalPrinter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppNET48
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new FiscalPrinter("COM5", 9600);

            PrintBill(printer);
            //PrintCancelledBill(printer);
            //PrintReport(printer);
        }

        static void PrintBill(FiscalPrinter printer)
        {
            var request = TestData.GetTestFiscalBill();

            try
            {
                var result = printer.PrintBill(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void PrintCancelledBill(FiscalPrinter printer)
        {
            var request = TestData.GetTestCancelledFiscalBill();

            try
            {
                var result = printer.PrintCancelledBill(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void PrintReport(FiscalPrinter printer)
        {
            try
            {
                // Results are strongly typed, no need for casting.


                // Usage 1
                var command = printer.Commands.DailyFiscalReport(new DailyFiscalReportRequest
                {
                    DailyReportType = DailyFiscalEnum.ZatvaranjeDen
                });
                var result = printer.Send(command);

                // Usage 2.
                // Depending on the needs, you can create the command manually, and not use the provided factory extensions.
                //var result = printer.Send(new DailyFiscalReportCommand(new DailyFiscalReportRequest
                //{
                //    DailyReportType = DailyFiscalEnum.ZatvaranjeDen
                //}));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
