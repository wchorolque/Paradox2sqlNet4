﻿using System;
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
        #endregion Fields

        #region Constructors
        public string SqlConnectionString
        }
        #region Methods
        protected override void OnLoad(EventArgs e)

        /// <summary>Test for a valid SQL Server datetime string.</summary>
            return valid;
        private static dynamic ConvertTo(object source, Type dest)
                 * can still give out of range errors when we try importing them to SQL. 
                return Convert.ChangeType(source, dest);
        private static string GenerateSqlCreateTableScript(DataTable table)
            for (var i = 0; i < table.Columns.Count; i++)
                if (table.Columns[i].AutoIncrement)
                if (!table.Columns[i].AllowDBNull)
                result += ",";
            return result.Substring(0, result.Length - 1) + ")";
        private void LogInfo()

        private void LogInfo(IEnumerable<string> lines)
        private void LogInfo(string format, params object[] args)
        private void SetParadoxLocationButton_Click(object sender, EventArgs e)
        private void SqlConnectionStringTextBox_TextChanged(object sender, EventArgs e)
        private void ImportButtonAsync_Click(object sender, EventArgs e)
            foreach (var f in Directory.GetFiles(ParadoxLocation, "*.db", SearchOption.TopDirectoryOnly))
                                    LogInfo("Creating table {0}.", tableName);
                                    foreach (DataRow row in table.Rows)
                                        var values = string.Join(",", validatedData.Select(v => "'" + v.ToString().Replace("'", string.Empty) + "'").ToArray());
                                    LogInfo("Imported table {0} correctly.", tableName);
}