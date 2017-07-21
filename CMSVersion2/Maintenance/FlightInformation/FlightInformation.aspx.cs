using System;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BLL = BusinessLogic;
using Tools = utilities;
using DAL = DataAccess;
using System.IO;
using System.Data.OleDb;
using System.Collections;
using Microsoft.VisualBasic.FileIO;

namespace CMSVersion2.Maintenance.FlightInformation
{
    public partial class FlightInformation : System.Web.UI.Page
    {
        Tools.DataAccessProperties getConstr = new Tools.DataAccessProperties();
        protected void Page_Load(object sender, EventArgs e)
        {
            //FileUploadFlightInfo.Attributes["onchange"] = "UploadFile(this)";



            RadGrid2.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;

            if (!string.IsNullOrEmpty(Session["UsernameSession"] as string))
            {
                string usersession = Session["UsernameSession"].ToString();
            }

        }

        #region Properties
        private string fileExtension;
        private string fileName;
        private string path;
        #endregion

        #region Read Excel file
        private DataTable ReadExcelFile(string sheetName, string path)
        {

            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable dt = new DataTable();
                string Import_FileName = path;
                string fileExtension = Path.GetExtension(Import_FileName);
                if (fileExtension == ".xls")
                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                if (fileExtension == ".xlsx")
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = "Select * from [" + sheetName + "$] WHERE not ltrim(rtrim(FlightNo)) = ''";

                    comm.Connection = conn;

                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(dt);
                        return dt;
                    }

                }
            }
        }
        #endregion


        protected void RadGrid2_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {

                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["FlightInfoId"], e.Item.ItemIndex);

                //HyperLink ViewReps = (HyperLink)e.Item.FindControl("ViewRepsLink");
                //ViewReps.Attributes["href"] = "javascript:void(0);";
                //ViewReps.Attributes["onclick"] = String.Format("return ViewRep('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CompanyId"], e.Item.ItemIndex);


                //HyperLink ViewApprovingLink = (HyperLink)e.Item.FindControl("ViewApprovingLink");
                //ViewApprovingLink.Attributes["href"] = "javascript:void(0);";
                //ViewApprovingLink.Attributes["onclick"] = String.Format("return ViewApprovingAuthority('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["CompanyId"], e.Item.ItemIndex);

            }
        }

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "Rebind")
            {

                RadGrid2.MasterTableView.SortExpressions.Clear();
                RadGrid2.MasterTableView.GroupByExpressions.Clear();
                RadGrid2.Rebind();
            }
            else if (e.Argument == "RebindAndNavigate")
            {
                RadGrid2.MasterTableView.SortExpressions.Clear();
                RadGrid2.MasterTableView.GroupByExpressions.Clear();
                RadGrid2.MasterTableView.CurrentPageIndex = RadGrid2.MasterTableView.PageCount - 1;
                RadGrid2.Rebind();
            }
        }

        public DataTable GetFlightDetails()
        {
            //DataTable data = new DataTable();
            DataSet data = BLL.Flight.GetFlightInformation(getConstr.ConStrCMS);
            DataTable convertdata = new DataTable();
            convertdata = data.Tables[0];
            return convertdata;
        }



        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid2.DataSource = GetFlightDetails();
        }




        protected void RadGrid2_ItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        protected void RadGrid2_ItemCommand(object sender, GridCommandEventArgs e)
        {
        }

        protected void RadGrid2_ItemDataBound1(object sender, GridItemEventArgs e)
        {

        }

        protected void RadGrid2_ItemUpdated(object sender, GridUpdatedEventArgs e)
        {

        }

        protected void RadGrid2_ItemCreated1(object sender, GridItemEventArgs e)
        {

        }




        protected void RadGrid2_ItemCommand1(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string userid = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["FlightInfoId"].ToString();
                DAL.Flight.DeleteFlightInfo(new Guid(userid), getConstr.ConStrCMS);

            }
        }



        protected void FileUploadFlightInfo_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            UploadedFile file = e.File;
            fileExtension = file.GetExtension();
            fileName = file.GetName();
            path = Server.MapPath("~/Upload/");
            file.SaveAs(path + fileName);
        }



        #region Upload File
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            DataTable data;
            DataTable dataSheets = new DataTable();
            DataTable filterTable;
            DataTable ftable = new DataTable();
            int count;
            object missing = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Excel.Application excelObj = null;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;


            if (fileName != null && path != null)
            {
                if (fileExtension.Equals(".xlsx") || fileExtension.Equals(".xls"))
                {
                    try
                    {
                        excelObj = new Microsoft.Office.Interop.Excel.Application();
                        workbook = excelObj.Workbooks.Open(path + fileName, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                        ArrayList sheetname = new ArrayList();

                        foreach (Microsoft.Office.Interop.Excel.Worksheet sheet in workbook.Sheets)
                        {
                            //sheetname.Add(sheet.Name);
                            data = ReadExcelFile(sheet.Name, path + fileName);
                            dataSheets.Merge(data);
                        }

                        //data = ReadExcelFile("Sheet1", path + fileName);
                        filterTable = FilterFlightInfoData(dataSheets);
                        ftable = filterTable;
                        //count = ftable.Rows.Count;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                else if (fileExtension.Equals(".csv"))
                {
                    try
                    {
                        string SaveLocation = path + fileName;
                        DataTable csvData = GetDataTableFromCSVFile(SaveLocation);
                        filterTable = FilterFlightInfoData(csvData);
                        ftable = filterTable;
                        //count = filterTable.Rows.Count;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

            }

            try
            {
                count = ftable.Rows.Count;
                if (count > 0)
                {
                    BLL.Flight.BulkInsertFlightInfo(ftable, getConstr.ConStrCMS);

                    if (workbook != null)
                    {
                        workbook.Close(false);
                        excelObj.Quit();

                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelObj);
                    }

                    if (Directory.Exists(path))
                    {
                        // Directory.Delete(SaveLocation);
                        File.Delete(path + "\\" + fileName);
                    }

                    string script = "<script>alert('File successfully imported!.')</" + "script>";
                    ClientScript.RegisterStartupScript(GetType(), "Alert", script);

                    RadGrid2.DataSource = GetFlightDetails();
                    RadGrid2.Rebind();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            //if (FileUploadFlightInfo.HasFile)
            //{
            //    string extension = System.IO.Path.GetExtension(FileUploadFlightInfo.FileName); // extension file

            //    if (extension.Equals(".csv"))
            //    {
            //        try
            //        {

            //            string folderPath = Server.MapPath("~/Upload");

            //            Check whether Directory(Folder) exists.
            //            if (!Directory.Exists(folderPath))
            //            {
            //                If Directory (Folder)does not exists.Create it.
            //                Directory.CreateDirectory(folderPath);
            //            }

            //            string SaveLocation = folderPath + "\\" + FileUploadFlightInfo.FileName;
            //            string SaveLocation = folderPath + Path.GetFileName(FileUploadFlightInfo.FileName);
            //            FileUploadFlightInfo.SaveAs(SaveLocation);

            //            Save the File to the Directory (Folder).
            //            FileUploadFlightInfo.SaveAs(SaveLocation);

            //            DataTable csvData = GetDataTableFromCSVFile(SaveLocation);
            //            DataTable filterTable = FilterFlightInfoData(csvData);
            //            int count = filterTable.Rows.Count;
            //            if (count > 0)
            //            {
            //                BLL.Flight.BulkInsertFlightInfo(filterTable, getConstr.ConStrCMS);

            //                string script = "<script>CloseOnReload()</" + "script>";
            //                ClientScript.RegisterStartupScript(this.GetType(), "CloseOnReload", script);

            //                if (Directory.Exists(folderPath))
            //                {
            //                    Directory.Delete(SaveLocation);
            //                    File.Delete(SaveLocation);
            //                }

            //                string script = "<script>alert('File successfully imported!.')</" + "script>";
            //                ClientScript.RegisterStartupScript(GetType(), "Alert", script);

            //                RadGrid2.DataSource = GetFlightDetails();
            //                RadGrid2.Rebind();

            //            }



            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex);
            //        }
            //    }
            //    else
            //    {

            //    }
            //}
        }

        #endregion

        static System.Globalization.DateTimeFormatInfo dti = new System.Globalization.DateTimeFormatInfo();
        static string dateFormat = "yyyyMMddHHmmss";

        #region GetDataFromCsvFile

        public DataTable GetDataTableFromCSVFile(string csvFilePath)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csvFilePath))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;

                    //read column names  
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datacolumn = new DataColumn(column);
                        datacolumn.AllowDBNull = true;
                        csvData.Columns.Add(datacolumn);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        string flightNo = fieldData[0];
                        string airlineName = fieldData[3];
                        string originCityName = fieldData[4];
                        string destinationCityName = fieldData[5];
                        DateTime ETD = Convert.ToDateTime(fieldData[1]);
                        DateTime ETA = Convert.ToDateTime(fieldData[2]);

                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return csvData;
        }
        #endregion

        //convert DateTime into Formated String
        public static string convertDateTimeToFormatedString(DateTime dateTime)
        {
            return dateTime.ToString(dateFormat, dti);
        }

        //convert Formatted String into DateTime
        public static DateTime convertStringToDateTime(string dateTimeInString)
        {
            dti.LongTimePattern = dateFormat;
            return DateTime.ParseExact(dateTimeInString, "T", dti);
        }

        #region DataTable FilterFlightInfoData

        public DataTable FilterFlightInfoData(DataTable datatable)
        {
            DataTable filterDatafromCsv = new DataTable();
            filterDatafromCsv.Columns.AddRange(new DataColumn[12]
                        {
                        new DataColumn("FlightInfoId", typeof(Guid)),
                        new DataColumn("FlightNo", typeof(string)),
                        new DataColumn("ETD",typeof(DateTime)),
                        new DataColumn("ETA",typeof(DateTime)),
                        new DataColumn("GateWayId", typeof(Guid)),
                        new DataColumn("OriginCityId", typeof(Guid)),
                        new DataColumn("DestinationCityId", typeof(Guid)),
                        new DataColumn("CreatedBy", typeof(Guid)),
                        new DataColumn("CreatedDate", typeof(DateTime)),
                        new DataColumn("ModifiedBy", typeof(Guid)),
                        new DataColumn("ModifiedDate", typeof(DateTime)),
                        new DataColumn("RecordStatus", typeof(int)),
                        });

            Guid FlightInfoId;
            Guid airlineId = new Guid();
            Guid OriginCityId = new Guid();
            Guid DestinationCityId = new Guid();
            Guid CreatedModifiedBy = new Guid("11111111-1111-1111-1111-111111111111");

            foreach (DataRow row in datatable.Rows)
            {
                string flightNo = row[0].ToString(); //0
                string airlineName = row[3].ToString();
                string originCityName = row[4].ToString();
                string destinationCityName = row[5].ToString();
                DateTime ETD = Convert.ToDateTime(row[1].ToString()); //1
                DateTime ETA = Convert.ToDateTime(row[2].ToString()); //2
                FlightInfoId = Guid.NewGuid();

                #region Check If FlightNumber and Id exists
                int checkIfFlightNumberExists = BLL.Flight.checkIfFlightNumberExists(flightNo, getConstr.ConStrCMS);

                //IF NOT EXISTS
                if (checkIfFlightNumberExists == 0)
                {
                    int checkIfIdExists = BLL.Flight.checkIfIdExists(airlineName, originCityName, destinationCityName, getConstr.ConStrCMS);
                    // CHECK IF airlineName, originCityName, destinationCityName HAS ID
                    if (checkIfIdExists == 3)
                    {
                        var result = BLL.Flight.GetIds(airlineName, originCityName, destinationCityName, getConstr.ConStrCMS);
                        airlineId = result.Item1;
                        OriginCityId = result.Item2;
                        DestinationCityId = result.Item3;
                        filterDatafromCsv.Rows.Add(FlightInfoId, flightNo, ETD, ETA, airlineId, OriginCityId, DestinationCityId,
                                                    CreatedModifiedBy, DateTime.Now, CreatedModifiedBy, DateTime.Now, 1);
                    }

                }
                else
                {

                }
                #endregion
            }

            return filterDatafromCsv;
        }

        #endregion
    }
}