using Accent.Ecr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    internal class CommandProcessor : ICommandProcessor
    {
        private readonly ErrorDictionary errorDictionary;
        private readonly Ecr ecr;

        internal CommandProcessor(Ecr ecr)
        {
            errorDictionary = new ErrorDictionary();
            this.ecr = ecr;
        }

        public TResponse SendCommand<TResponse>(IFiscalCommand<TResponse> command) where TResponse : FiscalResponse
        {
            try
            {
                ecr.OpenPort();
                var ecrResult = ecr.WriteCommand(command.Byte, command.RequestData ?? "");
                ecr.ClosePort();

                var fiscalResponse = ConvertAccentResultInFiscalResponse(ecrResult);

                return command.MapResponse(fiscalResponse);
            }
            catch (Exception)
            {
                // TODO: Should we catch here or not? [fatii, 12/24/2020]
                throw;
            }
        }

        public FiscalResponse PrintBill(CreateFiscalBillRequest request)
        {
            try
            {
                ecr.OpenPort();
                SendCommandOpenedPort(new OpenFiscalBillCommand(request.OpenBill));

                foreach (var item in request.Items)
                {
                    SendCommandOpenedPort(new RegisterItemOnOpenBillCommand(item));
                }
                foreach (var payment in request.RegisterPayments)
                {
                    SendCommandOpenedPort(new CalculateTotalOnOpenBillCommand(payment));
                }

                var response = SendCommandOpenedPort(new CloseFiscalBillCommand());
                ecr.ClosePort();

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public FiscalResponse PrintCancelledBill(CreateCancelledFiscalBillRequest request)
        {
            try
            {
                ecr.OpenPort();
                SendCommandOpenedPort(new OpenCancelledFiscalBillCommand(request.OpenBill));

                foreach (var item in request.Items)
                {
                    SendCommandOpenedPort(new RegisterItemOnOpenBillCommand(item));
                }
                foreach (var payment in request.RegisterPayments)
                {
                    SendCommandOpenedPort(new CalculateTotalOnOpenBillCommand(payment));
                }

                var response = SendCommandOpenedPort(new CloseCancelledFiscalBillCommand());
                ecr.ClosePort();

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private FiscalResponse SendCommandOpenedPort<TResponse>(IFiscalCommand<TResponse> command) where TResponse : FiscalResponse
        {
            try
            {
                var ecrResult = ecr.WriteCommand(command.Byte, command.RequestData ?? "");

                var fiscalResponse = ConvertAccentResultInFiscalResponse(ecrResult);

                return command.MapResponse(fiscalResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private FiscalResponse ConvertAccentResultInFiscalResponse(EcrResult ecrResult)
        {
            var response = new FiscalResponse();
            var msg = new StringBuilder();
            var bits = new BitArray(ecrResult.Status);

            for (var i = 0; i < 48; i++)
            {
                if (!bits[i]) continue;
                if (i == 44 || i == 41) continue;
                if (!string.IsNullOrEmpty(errorDictionary._dictionary[i]))
                    msg.AppendLine(errorDictionary._dictionary[i]);
            }

            response.StatusMsg = msg.ToString();
            response.Data = Encoding.ASCII.GetString(ecrResult.Data);

            //RAZGELDAJ ZA OD 35 NATMU OTKAKO KE IMASH FISKALIZIRAN PRINTER
            response.PrinterStatus = StatusEnum.OK;
            if (bits[13] || bits[2] || bits[17] || bits[18] || bits[19] || bits[20] || bits[34] || bits[35]) response.PrinterStatus = StatusEnum.WARNING;
            else if (bits[5] || bits[37]) response.PrinterStatus = StatusEnum.ERROR;

            return response;
        }
    }
}
