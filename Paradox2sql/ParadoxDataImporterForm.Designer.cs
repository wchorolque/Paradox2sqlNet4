namespace Paradox2sql
{
    partial class ParadoxDataImporterForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button importButton;

        private System.Windows.Forms.Button setParadoxLocationButton;

        private System.Windows.Forms.Label pathToParadoxLabel;

        private System.Windows.Forms.Label sqlConnectionStringLabel;

        private System.Windows.Forms.TextBox logTextBox;

        private System.Windows.Forms.TextBox paradoxLocationTextBox;

        private System.Windows.Forms.TextBox sqlConnectionStringTextBox;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.importButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.pathToParadoxLabel = new System.Windows.Forms.Label();
            this.paradoxLocationTextBox = new System.Windows.Forms.TextBox();
            this.setParadoxLocationButton = new System.Windows.Forms.Button();
            this.sqlConnectionStringLabel = new System.Windows.Forms.Label();
            this.sqlConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.chkCrearTablas = new System.Windows.Forms.CheckBox();
            this.chkCopiarDatos = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.Location = new System.Drawing.Point(560, 75);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 3;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.ImportButtonAsync_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.logTextBox.Location = new System.Drawing.Point(12, 104);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(627, 446);
            this.logTextBox.TabIndex = 4;
            this.logTextBox.WordWrap = false;
            // 
            // pathToParadoxLabel
            // 
            this.pathToParadoxLabel.AutoSize = true;
            this.pathToParadoxLabel.Location = new System.Drawing.Point(9, 9);
            this.pathToParadoxLabel.Name = "pathToParadoxLabel";
            this.pathToParadoxLabel.Size = new System.Drawing.Size(110, 13);
            this.pathToParadoxLabel.TabIndex = 5;
            this.pathToParadoxLabel.Text = "Paradox files location:";
            // 
            // paradoxLocationTextBox
            // 
            this.paradoxLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paradoxLocationTextBox.Location = new System.Drawing.Point(130, 5);
            this.paradoxLocationTextBox.Name = "paradoxLocationTextBox";
            this.paradoxLocationTextBox.Size = new System.Drawing.Size(476, 20);
            this.paradoxLocationTextBox.TabIndex = 6;
            // 
            // setParadoxLocationButton
            // 
            this.setParadoxLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setParadoxLocationButton.Location = new System.Drawing.Point(612, 4);
            this.setParadoxLocationButton.Name = "setParadoxLocationButton";
            this.setParadoxLocationButton.Size = new System.Drawing.Size(23, 23);
            this.setParadoxLocationButton.TabIndex = 7;
            this.setParadoxLocationButton.Text = "..";
            this.setParadoxLocationButton.UseVisualStyleBackColor = true;
            this.setParadoxLocationButton.Click += new System.EventHandler(this.SetParadoxLocationButton_Click);
            // 
            // sqlConnectionStringLabel
            // 
            this.sqlConnectionStringLabel.AutoSize = true;
            this.sqlConnectionStringLabel.Location = new System.Drawing.Point(9, 40);
            this.sqlConnectionStringLabel.Name = "sqlConnectionStringLabel";
            this.sqlConnectionStringLabel.Size = new System.Drawing.Size(115, 13);
            this.sqlConnectionStringLabel.TabIndex = 8;
            this.sqlConnectionStringLabel.Text = "SQL connection string:";
            // 
            // sqlConnectionStringTextBox
            // 
            this.sqlConnectionStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlConnectionStringTextBox.Location = new System.Drawing.Point(130, 35);
            this.sqlConnectionStringTextBox.Name = "sqlConnectionStringTextBox";
            this.sqlConnectionStringTextBox.Size = new System.Drawing.Size(505, 20);
            this.sqlConnectionStringTextBox.TabIndex = 9;
            this.sqlConnectionStringTextBox.Text = "Data Source=.;Initial Catalog=ImportParadox;Persist Security Info=True;User ID=us" +
    "er;Password=password";
            this.sqlConnectionStringTextBox.TextChanged += new System.EventHandler(this.SqlConnectionStringTextBox_TextChanged);
            // 
            // chkCrearTablas
            // 
            this.chkCrearTablas.AutoSize = true;
            this.chkCrearTablas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCrearTablas.Checked = true;
            this.chkCrearTablas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCrearTablas.Location = new System.Drawing.Point(209, 61);
            this.chkCrearTablas.Name = "chkCrearTablas";
            this.chkCrearTablas.Size = new System.Drawing.Size(107, 17);
            this.chkCrearTablas.TabIndex = 10;
            this.chkCrearTablas.Text = "CREAR TABLAS";
            this.chkCrearTablas.UseVisualStyleBackColor = true;
            // 
            // chkCopiarDatos
            // 
            this.chkCopiarDatos.AutoSize = true;
            this.chkCopiarDatos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCopiarDatos.Checked = true;
            this.chkCopiarDatos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopiarDatos.Location = new System.Drawing.Point(352, 61);
            this.chkCopiarDatos.Name = "chkCopiarDatos";
            this.chkCopiarDatos.Size = new System.Drawing.Size(111, 17);
            this.chkCopiarDatos.TabIndex = 11;
            this.chkCopiarDatos.Text = "CARGAR DATOS";
            this.chkCopiarDatos.UseVisualStyleBackColor = true;
            // 
            // ParadoxDataImporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 562);
            this.Controls.Add(this.chkCopiarDatos);
            this.Controls.Add(this.chkCrearTablas);
            this.Controls.Add(this.sqlConnectionStringTextBox);
            this.Controls.Add(this.sqlConnectionStringLabel);
            this.Controls.Add(this.setParadoxLocationButton);
            this.Controls.Add(this.paradoxLocationTextBox);
            this.Controls.Add(this.pathToParadoxLabel);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.importButton);
            this.Name = "ParadoxDataImporterForm";
            this.Text = "Paradox Data Importer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCrearTablas;
        private System.Windows.Forms.CheckBox chkCopiarDatos;
    }
}

