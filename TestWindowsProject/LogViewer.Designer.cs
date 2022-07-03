
namespace TestWindowsProject
{
    partial class LogViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReadLog = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.chkSubFolder = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnGRPCLogFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReadLog
            // 
            this.btnReadLog.AutoSize = true;
            this.btnReadLog.Location = new System.Drawing.Point(12, 12);
            this.btnReadLog.Name = "btnReadLog";
            this.btnReadLog.Size = new System.Drawing.Size(207, 32);
            this.btnReadLog.TabIndex = 0;
            this.btnReadLog.Text = "Read Open Banking Log Files";
            this.btnReadLog.UseVisualStyleBackColor = true;
            this.btnReadLog.Click += new System.EventHandler(this.btnReadLog_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(12, 125);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(924, 396);
            this.txtResult.TabIndex = 1;
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(304, 22);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(294, 22);
            this.txtFolder.TabIndex = 2;
            this.txtFolder.Text = "C:\\Temp\\Token Issue - Consent\\WEB01_22";
            // 
            // chkSubFolder
            // 
            this.chkSubFolder.AutoSize = true;
            this.chkSubFolder.Location = new System.Drawing.Point(634, 10);
            this.chkSubFolder.Name = "chkSubFolder";
            this.chkSubFolder.Size = new System.Drawing.Size(107, 21);
            this.chkSubFolder.TabIndex = 3;
            this.chkSubFolder.Text = "Sub Folder?";
            this.chkSubFolder.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(634, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnGRPCLogFile
            // 
            this.btnGRPCLogFile.AutoSize = true;
            this.btnGRPCLogFile.Location = new System.Drawing.Point(12, 78);
            this.btnGRPCLogFile.Name = "btnGRPCLogFile";
            this.btnGRPCLogFile.Size = new System.Drawing.Size(207, 32);
            this.btnGRPCLogFile.TabIndex = 0;
            this.btnGRPCLogFile.Text = "gRPC Log File Reading";
            this.btnGRPCLogFile.UseVisualStyleBackColor = true;
            this.btnGRPCLogFile.Click += new System.EventHandler(this.btnReadLog_Click);
            // 
            // LogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 533);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.chkSubFolder);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnGRPCLogFile);
            this.Controls.Add(this.btnReadLog);
            this.Name = "LogViewer";
            this.Text = "LogViewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadLog;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.CheckBox chkSubFolder;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnGRPCLogFile;
    }
}