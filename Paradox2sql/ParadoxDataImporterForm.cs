using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Paradox2sql.Properties;

namespace Paradox2sql
{
    public partial class ParadoxDataImporterForm : Form
    {
        #region Fields

        private string paradoxLocation;
        private string sqlConnectionString;

        #endregion Fields



        #region Constructors
        public ParadoxDataImporterForm()
        {
            InitializeComponent();
        }
        #endregion Constructors

        #region Properties
        public string ParadoxLocation
        {
            get { return paradoxLocation; }
            set
            {
                paradoxLocation = paradoxLocationTextBox.Text = Settings.Default.ParadoxLocation = value;
                Settings.Default.Save();
            }
        }

        public string SqlConnectionString
        {
            get { return sqlConnectionString; }
            set
            {
                sqlConnectionString = Settings.Default.SqlConnection = value;
                Settings.Default.Save();
            }

        }
        #endregion Properties

        #region Methods
        #region Protected Methods
        protected override void OnClosed(EventArgs e)
        {
            Settings.Default.Save();
            base.OnClosed(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ParadoxLocation = Settings.Default.ParadoxLocation;
            sqlConnectionStringTextBox.Text = Settings.Default.SqlConnection;
        }
        #endregion Protected Methods
        #region Private Methods



        /// <summary>Test for a valid SQL Server datetime string.</summary>
        /// <param name="value">The date string to test.</param>
        /// <returns>True if the parameter is a SQL Sever datetime; otherwise false.</returns>
        static bool IsValidSqlDateTimeNative(string value)
        {
            bool valid = false;
            DateTime testDate = DateTime.MinValue;
            System.Data.SqlTypes.SqlDateTime sdt;
            if (DateTime.TryParse(value, out testDate))
            {
                try
                {
                    sdt = new System.Data.SqlTypes.SqlDateTime(testDate);
                    valid = true;
                }
                catch (System.Data.SqlTypes.SqlTypeException) { }
            }

            return valid;
        }

        private static dynamic ConvertTo(object source, Type dest)
        {
            try
            {
                /* 
                 * Sometimes DateTime values that are valid according to the DateTime type 
                 * can still give out of range errors when we try importing them to SQL. 
                 */
                if (dest == typeof(DateTime) && !IsValidSqlDateTimeNative(source.ToString()))
                    return DBNull.Value;

                return Convert.ChangeType(source, dest);
            }
            catch
            {
                return DBNull.Value;
            }
        }

        private static string GenerateSqlCreateTableScript(DataTable tableToCreate)
        {
            var result = "CREATE TABLE [" + tableToCreate.TableName + "] (";

            for (var i = 0; i < tableToCreate.Columns.Count; i++)
            {
                DataColumn tableColumn = tableToCreate.Columns[i];
                result += "\n [" + tableColumn.ColumnName + "] ";
                /// TODO: Use System.Double to real/double and Memo to String
                if (tableColumn.DataType.ToString().Contains("System.Int32"))
                    result += " int ";
                else if (tableColumn.DataType.ToString().Contains("System.DateTime"))
                    result += " datetime ";
                else
                    result += " nvarchar(255) ";

                if (tableColumn.AutoIncrement)
                    result += " IDENTITY(" + tableColumn.AutoIncrementSeed.ToString() + "," + tableColumn.AutoIncrementStep.ToString() + ") ";

                if (!tableColumn.AllowDBNull)
                    result += " NOT NULL ";

                result += ",";
            }

            return result.Substring(0, result.Length - 1) + ")";
        }

        private void LogInfo()
        {
            LogInfo(string.Empty);
        }



        private void LogInfo(IEnumerable<string> lines)
        {
            logTextBox.Lines = logTextBox.Lines.Concat(lines).ToArray();
            logTextBox.SelectionStart = logTextBox.TextLength;
            logTextBox.ScrollToCaret();
            Invalidate();
        }

        private void LogInfo(string format, params object[] args)
        {
            LogInfo(new string[] { string.Format("{0:yyyy-MM-dd hh:mm:ss:tt} - ", DateTime.Now) + (args.Length > 0 ? string.Format(format, args) : format) });
        }

        private void SetParadoxLocationButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.RootFolder = Environment.SpecialFolder.Desktop;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ParadoxLocation = dialog.SelectedPath;
                }
            }
        }

        private void SqlConnectionStringTextBox_TextChanged(object sender, EventArgs e)
        {
            SqlConnectionString = sqlConnectionStringTextBox.Text;
        }
        #endregion Private Methods
        #endregion Methods

        private void ImportButtonAsync_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ParadoxLocation) || !Directory.Exists(ParadoxLocation))
                throw new InvalidOperationException("The paradox location was not specified.");

            foreach (var f in Directory.GetFiles(ParadoxLocation, "*.db", SearchOption.TopDirectoryOnly))
            {
                var tableName = Path.GetFileNameWithoutExtension(f);
                try
                {
                    using (var paradoxConnection = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Paradox 4.x;Data Source={0};", paradoxLocationTextBox.Text)))
                    {
                        using (var da = new OleDbDataAdapter(string.Format("SELECT * FROM {0};", tableName), paradoxConnection))
                        {
                            var tableToImport = new DataTable(tableName);
                            paradoxConnection.Open();
                            da.Fill(tableToImport);
                            var createTablequery = GenerateSqlCreateTableScript(tableToImport);
                            using (SqlConnection connection = new SqlConnection(SqlConnectionString))
                            {
                                using (var adapter = new SqlDataAdapter(createTablequery, connection))
                                {
                                    if (connection.State != ConnectionState.Open)
                                        connection.Open();

                                    if (this.chkCrearTablas.Checked)
                                    {
                                        LogInfo("Creating table {0}.", tableName);
                                        adapter.SelectCommand.ExecuteNonQuery();
                                    }

                                    if (this.chkCopiarDatos.Checked)
                                    {
                                        LogInfo("Importing table {0}.", tableName);
                                        int count = 0;
                                        foreach (DataRow row in tableToImport.Rows)
                                        {
                                            // This will not always work. The paradox data can not be trusted
                                            //var values = string.Join(",", row.ItemArray.Select(v => "'" + v.ToString().Replace("'", string.Empty) + "'").ToArray());
                                            /* Validate every field, and use null if not valid.
                                             * Slower, but safer. */
                                            var validatedData = new List<object>();
                                            for (var i = 0; i < row.Table.Columns.Count; i++)
                                            {
                                                Type dataType = row.Table.Columns[i].DataType;
                                                var value = ConvertTo(row[i], dataType);
                                                validatedData.Add(value);
                                            }

                                            var values = string.Join(",", validatedData.Select(v => "'" + v.ToString().Replace("'", string.Empty) + "'").ToArray());
                                            adapter.InsertCommand = new SqlCommand("INSERT INTO [" + tableName + "] VALUES (" + values + ")", connection);
                                            adapter.InsertCommand.ExecuteNonQuery();
                                            count++;
                                        }

                                        LogInfo("Imported table {0} with {1} records correctly.", tableName, count);
                                    }
                                    //Task.Yield();
                                }
                            }
                        }
                    }
                }
                catch (SqlException sex)
                {
                    LogInfo(sex.Message);
                    return;
                }
                catch (Exception ex) 
                { 
                    LogInfo(ex.Message); 
                }
            }
        }
    }
}
