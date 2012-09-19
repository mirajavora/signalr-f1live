namespace F1.Service
{
    partial class Form1
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
            this.EndPointUrl = new System.Windows.Forms.TextBox();
            this.ReloadButton = new System.Windows.Forms.Button();
            this.ListData = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // EndPointUrl
            // 
            this.EndPointUrl.Location = new System.Drawing.Point(12, 12);
            this.EndPointUrl.Name = "EndPointUrl";
            this.EndPointUrl.Size = new System.Drawing.Size(312, 20);
            this.EndPointUrl.TabIndex = 0;
            this.EndPointUrl.Text = "http://localhost:49232/";
            // 
            // ReloadButton
            // 
            this.ReloadButton.Location = new System.Drawing.Point(330, 10);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(163, 23);
            this.ReloadButton.TabIndex = 1;
            this.ReloadButton.Text = "ReLoad";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // ListData
            // 
            this.ListData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.ListData.Location = new System.Drawing.Point(12, 38);
            this.ListData.Name = "ListData";
            this.ListData.Size = new System.Drawing.Size(712, 323);
            this.ListData.TabIndex = 2;
            this.ListData.UseCompatibleStateImageBehavior = false;
            this.ListData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "";
            this.columnHeader1.Text = "Action";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Result";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 373);
            this.Controls.Add(this.ListData);
            this.Controls.Add(this.ReloadButton);
            this.Controls.Add(this.EndPointUrl);
            this.Name = "Form1";
            this.Text = "F1 Service";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EndPointUrl;
        private System.Windows.Forms.Button ReloadButton;
        private System.Windows.Forms.ListView ListData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

