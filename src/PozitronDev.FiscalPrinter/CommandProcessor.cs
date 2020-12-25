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

        public TResponse SendCommand<TResponse>(IFiscalCommand<TResponse> command, bool initiateConnection = true)
            where TResponse : FiscalResponse
        {
            try
            {
                if (initiateConnection)
                {
                    ecr.OpenPort();
                }

                var ecrResult = ecr.WriteCommand(command.Byte, command.RequestData ?? "");

                if (initiateConnection)
                {
                    ecr.ClosePort();
                }

                var fiscalResponse = ConvertAccentResultInFiscalResponse(ecrResult);

                return command.MapResponse(fiscalResponse);
            }
            catch (Exception)
            {
                // TODO: Should we catch here or not? [fatii, 12/24/2020]
                throw;
            }
        }

        public CloseFiscalBillResponse PrintBill(CreateFiscalBillRequest request)
        {
            try
            {
                ecr.OpenPort();
                SendCommand(new OpenFiscalBillCommand(request.OpenBill), initiateConnection: false);

                foreach (var item in request.Items)
                {
                    SendCommand(new RegisterItemOnOpenBillCommand(item), initiateConnection: false);
                }
                foreach (var payment in request.RegisterPayments)
                {
                    SendCommand(new CalculateTotalOnOpenBillCommand(payment), initiateConnection: false);
                }

                var response = SendCommand(new CloseFiscalBillCommand(), initiateConnection: false);
                ecr.ClosePort();

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CloseFiscalCancelledBillResponse PrintCancelledBill(CreateFiscalCancelledBillRequest request)
        {
            try
            {
                ecr.OpenPort();
                SendCommand(new OpenFiscalCancelledBillCommand(request.OpenBill), initiateConnection: false);

                foreach (var item in request.Items)
                {
                    SendCommand(new RegisterItemOnOpenBillCommand(item), initiateConnection: false);
                }
                foreach (var payment in request.RegisterPayments)
                {
                    SendCommand(new CalculateTotalOnOpenBillCommand(payment), initiateConnection: false);
                }

                var response = SendCommand(new CloseFiscalCancelledBillCommand(), initiateConnection: false);
                ecr.ClosePort();

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private FiscalResponse ConvertAccentResultInFiscalResponse(EcrResult ecrResult)
        {
            if (ecrResult == null)
            {
                return new FiscalResponse(StatusEnum.OK, string.Empty, string.Empty);
            }

            var msg = new StringBuilder();
            var bits = new BitArray(ecrResult.Status);

            for (var i = 0; i < 48; i++)
            {
                if (!bits[i]) continue;
                if (i == 44 || i == 41) continue;
                if (!string.IsNullOrEmpty(errorDictionary._dictionary[i]))
                    msg.AppendLine(errorDictionary._dictionary[i]);
            }

            var statusMsg = msg.ToString();
            var rawData = Encoding.ASCII.GetString(ecrResult.Data);

            //RAZGELDAJ ZA OD 35 NATMU OTKAKO KE IMASH FISKALIZIRAN PRINTER
            var printerStatus = StatusEnum.OK;
            if (bits[13] || bits[2] || bits[17] || bits[18] || bits[19] || bits[20] || bits[34] || bits[35]) printerStatus = StatusEnum.WARNING;
            else if (bits[5] || bits[37]) printerStatus = StatusEnum.ERROR;

            return new FiscalResponse(printerStatus, statusMsg, rawData);
        }
    }
}
