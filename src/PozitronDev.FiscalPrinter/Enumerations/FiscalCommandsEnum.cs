using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.FiscalPrinter
{
    // This is an internal enum, used just as a reference.
    // These are almost all possible commands and their byte representation for the driver.
    // They are not all implemented in this package yet.
    internal enum FiscalCommandsEnum
    {
        //MANDATORY ORDER: FIRST OPEN, REGISTER ITEMS,CALCULATE TOTAL, CLOSE 
        OpenFiscalBill = 48,
        OpenFiscalCancelledBill = 85,
        RegisterItemOnOpenBill = 49,
        CalculateTotalOnOpenBill = 53,
        CloseFiscalBill = 56,
        CloseFiscalCancelledBill = 86,

        //SLUZBENO VADENJE ILI STAVANJE PARI VO KASA
        MoneyInOutDrawerRequest = 70,

        // IZVESHTAI SHTO SE PECATAT
        DailyFiscalReport = 69,
        FiscalReportFromToFiscalClosing = 94,
        TaxAddedBetweenPeriod = 50,
        SubTotal = 51,
        PrintFiscalEntryByNumberFromFiscalMemory = 73,
        PrintAcumulatedSumsFromFiscalMemory = 95,
        PrintSumsFromMemory = 79,
        DiagnosticReportPrint = 71,

        //OPERACII SO DISPLEJOT NA FISKALNATA
        ShowDateAndTimeOnFiscalDisplay = 63,
        WriteLowerTextOnFiscalDisplay = 35,
        WriteUpperTextOnFiscalDisplay = 47,
        WriteTextOnFiscalDisplay = 100,
        ClearDataFromFiscalDisplay = 33,

        //SETTINGS NA SMETKATA
        //OPCIITE avtomatsko secenje, zadavanje na prazni linii kaj total ili danocen broj ne se implementirani
        AddHeaderTextOnReceipt = 43,

        //MEHANICKI OPERACII NA PRINTEROT
        RollThePrinterPaper = 44,
        CutPaper = 45,
        DrawerKick = 106,

        //CITANJE I SETIRANJE NA DATUM NA FISKALNATA
        GetDateTimeFromFiscalPrinter = 62,
        SetFiscalDateAndTime = 61,

        //OPRACII SO KELNERI
        GetWaiterNameFromCode = 112,
        PutWaiterName = 102,
        ChangeWaiterPin = 101,

        //MOEMNTALNO OTVORENA FISKALNA TRANSAKCIJA KOJA NE E ZAVRSHENA
        StatusOnFiscalTransaction = 76,

        //DOPOLNITELNI POMOSHNI PODATOCI
        GetTaxNumbers = 99,
        GetStatuses = 74,
        GetDiagnosticReportData = 90,
        GetLastPrintedFiscalDocumentNumber = 113,
        GetAdditionalDailyInformations = 110,
        GetCurrentAcumulatedTax = 103,
        GetProgramedTaxes = 97,
        GetFreeSpaceInFiscalMemory = 68,
        GetDailySums = 67,
        GetDailyTaxSums = 65,
        GetInfoForLastFiscalStore = 64,

    }
}
