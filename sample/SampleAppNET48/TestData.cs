using PozitronDev.FiscalPrinter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppNET48
{
    public static class TestData
    {
        public static CreateFiscalBillRequest GetTestFiscalBill()
        {
            return new CreateFiscalBillRequest
            {
                OpenBill = new OpenFiscalBillRequest
                {
                    WaiterCode = 1,
                    WaiterPin = 1111,
                    OperatorPlace = 1
                },
                Items = new List<RegisterItemOnOpenBillRequest>() { new RegisterItemOnOpenBillRequest
                {
                    IsNationalProduct = false,
                    ItemTax = TaxEnum.A,
                    ItemName = "ЧАША",
                    ItemPrice = 2,
                    ItemQuantity = 1,
                    ItemDiscountPercentage = -50.00m
                }},
                RegisterPayments = new List<CalculateTotalOnOpenBillRequest>() { new CalculateTotalOnOpenBillRequest
                {
                    Amount = 10000,
                    PaymentType = PaymentTypeEnum.Cash
                }}
            };
        }

        public static CreateFiscalCancelledBillRequest GetTestFiscalCancelledBill()
        {
            return new CreateFiscalCancelledBillRequest
            {
                OpenBill = new OpenFiscalCancelledBillRequest
                {
                    WaiterCode = 1,
                    WaiterPin = 1111,
                    OperatorPlace = 1
                },
                Items = new List<RegisterItemOnOpenBillRequest>() { new RegisterItemOnOpenBillRequest
                {
                    IsNationalProduct = false,
                    ItemTax = TaxEnum.A,
                    ItemName = "ЧАША",
                    ItemPrice = 2,
                    ItemQuantity = 1,
                    ItemDiscountPercentage = -50.00m
                }},
                RegisterPayments = new List<CalculateTotalOnOpenBillRequest>() { new CalculateTotalOnOpenBillRequest
                {
                    Amount = 10000,
                    PaymentType = PaymentTypeEnum.Cash
                }}
            };
        }
    }
}
