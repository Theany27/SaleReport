using DevExpress.CodeParser;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleReport
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            startdate.Value = DateTime.Today.AddMonths(-1);
            enddate.Value = DateTime.Today;

            UpdateDataBasedOnDatePickers();
        }
        

        private void startdate_ValueChanged(object sender, EventArgs e)
        {
            UpdateDataBasedOnDatePickers();
        }

        private void enddate_ValueChanged(object sender, EventArgs e)
        {
            UpdateDataBasedOnDatePickers();
        }

        private void UpdateDataBasedOnDatePickers()
        {
            DateTime startDate = startdate.Value.Date;
            DateTime endDate = enddate.Value.Date.AddTicks(1); 

            if (startDate <= endDate)
            {
                SaleDto(startDate, endDate);
            }
            else
            {
                MessageBox.Show("Start date must be before or equal to end date.", "Date Range Error");
            }
        }
        public void SaleDto(DateTime startDate, DateTime endDate)
        {
            string cnnStr = ConfigurationManager.ConnectionStrings["SaleReportdb"].ConnectionString;


            var conn = new SqlConnection(cnnStr);
                try
                {
                    conn.Open();


                    string sql = @"
                                SELECT 
                                    PRODUCTCODE,
                                    PRODUCTNAME,
                                    QUANTITY,
                                    UNITPRICE,
                                    QUANTITY * UNITPRICE AS TOTAL,
                                    SALEDATE
                                FROM PRODUCTSALES
                                WHERE SALEDATE BETWEEN @STARTDATE AND @ENDDATE
                                ORDER BY SALEDATE";

                    var cmd = new SqlCommand(sql, conn);
                    
                        cmd.Parameters.AddWithValue("@STARTDATE", startDate);
                        cmd.Parameters.AddWithValue("@ENDDATE", endDate);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        tblgetdata.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                XtraReport1 report = new XtraReport1();
                var dataset = await FillDataset(startdate.Value, enddate.Value);
                report.RequestParameters = false;
                report.DataSource = await FillDataset(startdate.Value, enddate.Value);
                if (dataset.Tables["PRODUCTSALES"].Rows.Count == 0)
                {
                    MessageBox.Show("No results found for the selected date range.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                };
                report.DataMember = "PRODUCTSALES";
                ReportPrintTool tool = new ReportPrintTool(report);
                tool.ShowPreview();

                
                Directory.CreateDirectory(@"D:\sampleData");
                report.ExportToPdf(@"D:\sampleData\sales_report.pdf");

                MessageBox.Show(@"File successfully created at D:\sampleData\sales_report.pdf", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogError($"[{DateTime.Now}] UI error: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<DataSet> FillDataset(DateTime startDate, DateTime endDate)
        {

            string cnnStr = ConfigurationManager.ConnectionStrings["SaleReportdb"].ConnectionString;


            DataSet dataSet = new DataSet();
            dataSet.DataSetName = "SalesDataset";

            DataTable dataTable = new DataTable("PRODUCTSALES");
            dataSet.Tables.Add(dataTable);

            dataTable.Columns.Add("PRODUCTCODE", typeof(string));
            dataTable.Columns.Add("PRODUCTNAME", typeof(string));
            dataTable.Columns.Add("QUANTITY", typeof(int));
            dataTable.Columns.Add("UNITPRICE", typeof(decimal));
            dataTable.Columns.Add("TOTAL", typeof(decimal));
            dataTable.Columns.Add("SALEDATE", typeof(DateTime));

            using (SqlConnection conn = new SqlConnection(cnnStr))
            {
                await conn.OpenAsync();

                string sql = @"
                                SELECT 
                                    PRODUCTCODE,
                                    PRODUCTNAME,
                                    QUANTITY,
                                    UNITPRICE,
                                    QUANTITY * UNITPRICE AS TOTAL, 
                                    SALEDATE
                                FROM PRODUCTSALES
                                WHERE SALEDATE BETWEEN @STARTDATE AND @ENDDATE
                                ORDER BY SALEDATE";

                var cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@STARTDATE", startDate);
                    cmd.Parameters.AddWithValue("@ENDDATE", endDate);
                    cmd.Parameters.AddWithValue("@PRODUCTNAME", $"%{txtfilter}%");

                var reader = await cmd.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            dataTable.Rows.Add(
                                reader["PRODUCTCODE"],
                                reader["PRODUCTNAME"],
                                reader["QUANTITY"],
                                reader["UNITPRICE"],
                                reader["TOTAL"],
                                reader["SALEDATE"]
                            );
                        }
            }
            return dataSet;
        }
        private void LogError(string message)
        {
            string logPath = @"logs\errors.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(logPath));
            File.AppendAllText(logPath, message + Environment.NewLine + Environment.NewLine);
        }
        private async void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
            string cnnStr = ConfigurationManager.ConnectionStrings["SaleReportdb"].ConnectionString;


            string filter = txtfilter.Text; 

            string query = "SELECT * FROM PRODUCTSALES WHERE PRODUCTNAME LIKE @name";

            var conn = new SqlConnection(cnnStr);
            var cmd = new SqlCommand(query, conn);
                
            cmd.Parameters.AddWithValue("@name", "%" + filter + "%"); 

            conn.Open();
            var adapter = new SqlDataAdapter(cmd);
                    
                DataTable dt = new DataTable();
                adapter.Fill(dt); 

                tblgetdata.DataSource = dt;
        }
    }
}
