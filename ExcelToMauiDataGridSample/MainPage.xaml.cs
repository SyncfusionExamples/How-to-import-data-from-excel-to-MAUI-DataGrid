using Syncfusion.XlsIO;
using System.Data;
using System.Reflection;

namespace ExcelToMauiDataGridSample
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await LoadDataGridAsync();
        }

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
    }

}
