# How to import data from excel to MAUI DataGrid
To import data from an Excel file into a [.NET MAUI DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid), you can use the [XlsIO](https://help.syncfusion.com/file-formats/xlsio/overview) library to read data from Excel files and then bind the data to the SfDataGrid in your MAUI application.

 Install the [Syncfusion.Maui.DataGridExport](https://www.nuget.org/packages/Syncfusion.Maui.DataGridExport) nuGet package to use the SfDataGrid and for reading Excel files.

##### C#

Place the Excel document in the Raw folder within the Resources directory. We can access the document using `FileSystem.OpenAppPackageFileAsync()`.
```C#
private async Task LoadDataGridAsync()
{
    //Creates a new instance for ExcelEngine
    ExcelEngine excelEngine = new ExcelEngine();

    //Initialize IApplication
    Syncfusion.XlsIO.IApplication application = excelEngine.Excel;

    //Load the file into stream
    Stream inputStream = await FileSystem.OpenAppPackageFileAsync("DataGrid.xlsx");

    //Loads or open an existing workbook through Open method of IWorkbooks
    IWorkbook workbook = application.Workbooks.Open(inputStream);

    IWorksheet worksheet = workbook.Worksheets[0];

    DataTable customersTable = worksheet.ExportDataTable(1, 1, 20, 15, ExcelExportDataTableOptions.ColumnNames);

    this.dataGrid.ItemsSource = customersTable;

    workbook.Close();

    excelEngine.Dispose();
}
```
Read the content from the Excel sheet and export it to a DataTable. Then, assign the DataTable as the ItemSource for the DataGrid.


[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-import-data-from-excel-to-MAUI-DataGrid)

Take a moment to pursue this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples.
Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid(SfDataGrid).

#### Conclusion
I hope you enjoyed learning about how to import data from excel to MAUI DataGrid.

You can refer to our [.NET MAUI DataGrid's feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to know about its other groundbreaking feature representations. You can also explore our .NET MAUI DataGrid Documentation to understand how to present and manipulate data.
For current customers, you can check out our .NET MAUI components from the [License and Downloads](https://www.syncfusion.com/account/downloads) page. If you are new to Syncfusion, you can try our 30-day free trial to check out our .NET MAUI DataGrid and other .NET MAUI components.
If you have any queries or require clarifications, please let us know in comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/account/login?ReturnUrl=%2Faccount%2Fconnect%2Fauthorize%2Fcallback%3Fclient_id%3Dc54e52f3eb3cde0c3f20474f1bc179ed%26redirect_uri%3Dhttps%253A%252F%252Fsupport.syncfusion.com%252Fagent%252Flogincallback%26response_type%3Dcode%26scope%3Dopenid%2520profile%2520agent.api%2520integration.api%2520offline_access%2520kb.api%26state%3D8db41f98953a4d9ba40407b150ad4cf2%26code_challenge%3DvwHoT64z2h21eP_A9g7JWtr3vp3iPrvSjfh5hN5C7IE%26code_challenge_method%3DS256%26response_mode%3Dquery) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid). We are always happy to assist you!