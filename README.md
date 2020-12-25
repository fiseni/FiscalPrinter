<img align="left" src="pozitronlogo.png" width="120" height="120">

&nbsp; [![NuGet](https://img.shields.io/nuget/v/PozitronDev.FiscalPrinter.svg)](https://www.nuget.org/packages/PozitronDev.FiscalPrinter)[![NuGet](https://img.shields.io/nuget/dt/PozitronDev.FiscalPrinter.svg)](https://www.nuget.org/packages/PozitronDev.FiscalPrinter)

&nbsp; [![Build Status](https://dev.azure.com/pozitrondev/PozitronDev.FiscalPrinter/_apis/build/status/FiscalPrinter_BuildPackage?branchName=master)](https://dev.azure.com/pozitrondev/PozitronDev.FiscalPrinter/_build/latest?definitionId=14&branchName=master)

&nbsp; [![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/pozitrondev/PozitronDev.FiscalPrinter/14)](https://dev.azure.com/pozitrondev/PozitronDev.FiscalPrinter/_build/latest?definitionId=14&branchName=master&view=codecoverage-tab)

&nbsp;

# PozitronDev FiscalPrinter

Nuget package providing high-level abstractions and simplifying the task of printing to fiscal devices. The package is based and build upon the `ecr.dll` driver published by `Accent` [here](https://www.accent.mk/?page_id=1282#sy250).

## Usage

Refer to the sample applications provided within this repository under `sample` folder.

Create an instance of `FiscalPrinter` and simply utilize the provided methods
- Send - It translates the given command and writes it to the fiscal printer
- PrintBill - This is just a convenience method, since the functionality is used frequently. It just groups necessary commands for this action `OpenFiscalBillCommand`, `RegisterItemOnOpenBillCommand`, `CalculateTotalOnOpenBillCommand` and `CloseFiscalBillCommand`. You can do this manually by utilizing `Send` as well.
- PrintCancelledBill - Similar to the previous one. It prints the cancelled bill.

Example usage

```c#
class Program
{
    static void Main(string[] args)
    {
        var printer = new FiscalPrinter("COM5", 9600);

        try
        {
            var command = printer.Commands.DailyFiscalReport(new DailyFiscalReportRequest
            {
                DailyReportType = DailyFiscalEnum.DayClosure
            });
            var result = printer.Send(command);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
```

Depending on the usage, and the architecture you have created internally, you may not use the command factory at all and instantiate the command directly

```c#
var result = printer.Send(new DailyFiscalReportCommand(new DailyFiscalReportRequest
{
    DailyReportType = DailyFiscalEnum.DayClosure
}));
```

## Extending with your own commands

The package is quite flexible and supports extensions. If any fiscal command is not yet supported by the package, you can add it on your own.

Example extensions

```c#
public class MyRequest : FiscalRequest
{
}

public class MyResponse : FiscalResponse
{
    public MyResponse(FiscalResponse response) : base(response)
    {
    }
}

public class MyCommand : IFiscalCommand<MyResponse>
{
    private readonly MyRequest request;

    public MyCommand(MyRequest request)
    {
        this.request = request;
    }

    public byte Byte => 0; // Write the byte representation of the command.

    public string RequestData => "something"; // Translate the request information into required request string for the device.

    public MyResponse MapResponse(FiscalResponse fiscalResponse)
    {
        return new MyResponse(fiscalResponse);
    }
}

public static class MyCommandFactoryExtensions
{
    public static MyCommand MyCommand(this IFiscalCommandFactory value, MyRequest request)
        => new MyCommand(request);
}
```

## Give a Star! :star:
If you like or are using this project please give it a star. Thanks!
