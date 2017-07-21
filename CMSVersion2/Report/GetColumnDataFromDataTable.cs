using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CMSVersion2.Report.Operation.Manifest.Reports
{
    public class GetColumnDataFromDataTable
    {
        public String get_Column_DataView(DataTable _table, String _column)
        {
            String Column_Name = "";
            try
            {
                DataView view = new DataView(_table);
                DataTable table = view.ToTable(true, _column);

                table = view.ToTable(true, _column);
                foreach (DataRow x in table.Rows)
                {
                    if (x[_column].ToString() != null)
                    {
                        Column_Name += x[_column].ToString() + ",";
                    }
                }
                Column_Name = Column_Name.TrimEnd(',');
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message, "Column Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Column_Name = "N/A";
                Console.WriteLine(ex);
            }

            Column_Name = (Column_Name != null || Column_Name != "") ? Column_Name : "N/A";

            return Column_Name;

        }
    }
}