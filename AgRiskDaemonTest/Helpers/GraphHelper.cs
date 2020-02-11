using Microsoft.Graph;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AgRiskDaemonTest.Helpers
{
    public static class GraphHelper
    {
        /// <summary>
        /// Get Files From Root folder
        /// </summary>
        /// <returns>
        /// DriveItemChildrenCollectionPage Result
        /// </returns>
        public static async Task<IDriveItemChildrenCollectionPage> GetFilesAsync()
        {
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();

            var files = await graphClient.Me.Drive.Root.Children
                .Request()
                .GetAsync();

            return files;
        }

        public static async Task<Workbook> GetWorkbook(string idItem)
        {
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();
            
            var workBook = await graphClient.Drive.Items[idItem].Workbook
                .Request()
                .GetAsync();

            return workBook;
        }

        public static async Task<WorkbookSessionInfo> CreateSession(string idItem,bool persistChanges)
        {
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();

            var sessionInfo = await graphClient.Drive.Items[idItem].Workbook
                .CreateSession(persistChanges)
                .Request()
                .PostAsync();

            return sessionInfo;
        }

        public static async Task CloseSession(string idItem, WorkbookSessionInfo workbookSessionInfo)
        {
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();

            var optionSession = new HeaderOption("workbook-session-id", workbookSessionInfo.Id);
            var options = new List<Option> { optionSession };
            await graphClient.Drive.Items[idItem].Workbook
                .CloseSession()
                .Request(options)
                .PostAsync();
        }

        public static async Task RefreshSession(string idItem, WorkbookSessionInfo workbookSessionInfo)
        {
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();

            var optionSession = new HeaderOption("workbook-session-id", workbookSessionInfo.Id);
            var options = new List<Option> { optionSession };
            await graphClient.Drive.Items[idItem].Workbook
                .RefreshSession()
                .Request(options)
                .PostAsync();
        }

        public static async Task<IEnumerable<WorkbookWorksheet>> GetSheets(string idItem)
        {
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();

            var sheets = await graphClient.Drive.Items[idItem].Workbook.Worksheets
                .Request()
                .GetAsync();

            return sheets.CurrentPage.AsEnumerable();
        }

        public static async Task<WorkbookRange> GetRange(string idItem, string nameSheet, string range, WorkbookSessionInfo workbookSessionInfo)
        {
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();
            var name = nameof(WorkbookRange.Values);
            var optionSession = new HeaderOption("workbook-session-id", workbookSessionInfo.Id);
            var options = new List<Option> { optionSession };
            var workbookRange = await graphClient.Drive.Items[idItem].Workbook
                .Worksheets[nameSheet]
                .Range(range)
                .Request(options)
                .Select(name)
                .GetAsync();

            return workbookRange;
        }

        public static async Task<WorkbookRange> PatchRange(string idItem, string nameSheet, string range, WorkbookRange workbookRangeUpdate, WorkbookSessionInfo workbookSessionInfo)
        {            
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();
            //var name = nameof(WorkbookRange.Values);
            var optionSession = new HeaderOption("workbook-session-id", workbookSessionInfo.Id);
            var options = new List<Option> { optionSession };
            var workbookRange = await graphClient.Drive.Items[idItem].Workbook.Worksheets[nameSheet]
                .Range(range)
                .Request(options)
                .PatchAsync(workbookRangeUpdate);

            return workbookRange;
        }

        public static async Task<WorkbookRange> PutRange(string idItem, string nameSheet, string range, WorkbookRange workbookRangeUpdate, WorkbookSessionInfo workbookSessionInfo)
        {
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();

            var optionSession = new HeaderOption("workbook-session-id", workbookSessionInfo.Id);
            var options = new List<Option> { optionSession };
            var workbookRange = await graphClient.Drive.Items[idItem].Workbook.Worksheets[nameSheet]
                .Range(range)
                .Request(options)
                .Select("Values")
                .PutAsync(workbookRangeUpdate);

            return workbookRange;
        }

        public static async Task<IWorkbookTablesCollectionPage> GetTablesAsync(string idItem)
        {
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();

            var workbookTable = await graphClient.Drive.Items[idItem].Workbook.Tables
                .Request()
                .GetAsync();

            return workbookTable;
        }

        public static async Task<WorkbookRange> GetCell(string idItem, string nameSheet, int row, int column, WorkbookSessionInfo workbookSessionInfo)
        {
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();
            
            var optionSession = new HeaderOption("workbook-session-id", workbookSessionInfo.Id);
            var options = new List<Option> { optionSession };
            var workbookRange = await graphClient.Drive.Items[idItem].Workbook.Worksheets[nameSheet]
                .Cell(row,column)
                .Request(options)
                .Select("Values")
                .GetAsync();

            return workbookRange;
        }

        public static async Task<WorkbookRange> PatchCell(string idItem, string nameSheet, int row, int column, WorkbookRange workbookRangeUpdate, WorkbookSessionInfo workbookSessionInfo)
        {
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();

            var optionSession = new HeaderOption("workbook-session-id", workbookSessionInfo.Id);
            var options = new List<Option> { optionSession };
            var workbookRange = await graphClient.Drive.Items[idItem].Workbook.Worksheets[nameSheet]
                .Cell(row, column)
                .Request(options)
                //.Select("Values")
                .PatchAsync(workbookRangeUpdate);

            return workbookRange;
        }

        public static async Task<WorkbookRange> PutCell(string idItem, string nameSheet, int row, int column, WorkbookRange workbookRangeUpdate, WorkbookSessionInfo workbookSessionInfo)
        {
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();

            var optionSession = new HeaderOption("workbook-session-id", workbookSessionInfo.Id);
            var options = new List<Option> { optionSession };
            var workbookRange = await graphClient.Drive.Items[idItem].Workbook.Worksheets[nameSheet]
                .Cell(row, column)
                .Request(options)
                //.Select(nameof(workbookRangeUpdate.Values))
                .PutAsync(workbookRangeUpdate);

            return workbookRange;
        }

        public static async Task<IWorkbookTableColumnsCollectionPage> GetColumn(string idItem, string nameSheet)
        {
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();

            var columns = await graphClient.Drive.Items[idItem].Workbook.Tables[nameSheet].Columns
                .Request()
                //.Skip(5)
                .Top(2)
                .GetAsync();
            return columns;
        }

        public static async Task<string> GetChart(string idItem, string nameSheet)
        {
            //IWorkbookChartRequestBuilder
            //IWorkbookChartImageRequest
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();

            //var chartImage = await graphClient.Drive.Items[idItem]
            //    .Workbook
            //    .Worksheets[nameSheet]
            //    .Charts["Chart 1"]
            //    .Image()
            //    //.Image(640, 480, "fit")
            //    .Request()
            //    .GetAsync();

            //ni llega este punto
            //_ = chartImage.Length;

            var chartResourceUrl = graphClient.Drive.Items[idItem]
             .Workbook
             .Worksheets[nameSheet]
             .Charts["Chart 1"]
             .Request().RequestUrl;


            var urlToGetImageFromChart = $"{chartResourceUrl}/image(width=400, height=480)";
            var message = new HttpRequestMessage(HttpMethod.Get, urlToGetImageFromChart);
            await graphClient.AuthenticationProvider.AuthenticateRequestAsync(message);
            var response = await graphClient.HttpProvider.SendAsync(message);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                JObject imageObject = JObject.Parse(content);
                JToken chartData = imageObject.GetValue("value");
                //...
            }


            return chartResourceUrl;
        }

        //public static async Task<WorkbookRangeInsertRequest> InsertRange(string idItem, string nameSheet, string range)
        //{
        //    var graphClient = AuthenticationHelper.GetAuthenticatedClient();
        //    var shift = "Down";

        //    var workbookRangeInsert = await graphClient.Drive.Items[idItem].Workbook.Worksheets[nameSheet]
        //        .Range(range)
        //        .Request()
        //        .PatchAsync();

        //    return workbookRangeInsert;
        //}


    }
}