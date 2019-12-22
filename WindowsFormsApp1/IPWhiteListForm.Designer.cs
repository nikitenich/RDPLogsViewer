namespace RDPLogsViewer
{
    partial class IPWhiteListForm
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
            this.whiteListGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.maskTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.addExceptionButton = new System.Windows.Forms.Button();
            this.deleteIPbutton = new System.Windows.Forms.Button();
            this.isSpecificIPCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.whiteListGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // whiteListGridView
            // 
            this.whiteListGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.whiteListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.whiteListGridView.Location = new System.Drawing.Point(12, 12);
            this.whiteListGridView.Name = "whiteListGridView";
            this.whiteListGridView.Size = new System.Drawing.Size(248, 190);
            this.whiteListGridView.TabIndex = 0;
            this.whiteListGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.whiteListGridView_DataError);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Для диапазона";
            // 
            // maskTextBox
            // 
            this.maskTextBox.Location = new System.Drawing.Point(355, 87);
            this.maskTextBox.MaxLength = 2;
            this.maskTextBox.Name = "maskTextBox";
            this.maskTextBox.Size = new System.Drawing.Size(22, 20);
            this.maskTextBox.TabIndex = 24;
            this.maskTextBox.Text = "16";
            this.maskTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MaskTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Маска";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(355, 61);
            this.ipTextBox.MaxLength = 15;
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(100, 20);
            this.ipTextBox.TabIndex = 26;
            this.ipTextBox.Text = "95.158.237.233";
            this.ipTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IpTextBox_KeyPress);
            // 
            // addExceptionButton
            // 
            this.addExceptionButton.Image = global::RDPLogsViewer.Properties.Resources.create;
            this.addExceptionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addExceptionButton.Location = new System.Drawing.Point(281, 12);
            this.addExceptionButton.Name = "addExceptionButton";
            this.addExceptionButton.Size = new System.Drawing.Size(112, 38);
            this.addExceptionButton.TabIndex = 25;
            this.addExceptionButton.Text = "Добавить исключение";
            this.addExceptionButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addExceptionButton.UseVisualStyleBackColor = true;
            this.addExceptionButton.Click += new System.EventHandler(this.addExceptionButton_Click);
            // 
            // deleteIPbutton
            // 
            this.deleteIPbutton.Image = global::RDPLogsViewer.Properties.Resources.delete;
            this.deleteIPbutton.Location = new System.Drawing.Point(431, 12);
            this.deleteIPbutton.Name = "deleteIPbutton";
            this.deleteIPbutton.Size = new System.Drawing.Size(112, 38);
            this.deleteIPbutton.TabIndex = 3;
            this.deleteIPbutton.Text = "Удалить";
            this.deleteIPbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteIPbutton.UseVisualStyleBackColor = true;
            this.deleteIPbutton.Click += new System.EventHandler(this.deleteIPbutton_Click);
            // 
            // isSpecificIPCheckBox
            // 
            this.isSpecificIPCheckBox.AutoSize = true;
            this.isSpecificIPCheckBox.Location = new System.Drawing.Point(383, 90);
            this.isSpecificIPCheckBox.Name = "isSpecificIPCheckBox";
            this.isSpecificIPCheckBox.Size = new System.Drawing.Size(101, 17);
            this.isSpecificIPCheckBox.TabIndex = 29;
            this.isSpecificIPCheckBox.Text = "Конкретный IP";
            this.isSpecificIPCheckBox.UseVisualStyleBackColor = true;
            this.isSpecificIPCheckBox.CheckedChanged += new System.EventHandler(this.isSpecificIPCheckBox_CheckedChanged);
            // 
            // IPWhiteListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 214);
            this.Controls.Add(this.isSpecificIPCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maskTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addExceptionButton);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.deleteIPbutton);
            this.Controls.Add(this.whiteListGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IPWhiteListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Белый список IP";
            ((System.ComponentModel.ISupportInitialize)(this.whiteListGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView whiteListGridView;
        private System.Windows.Forms.Button deleteIPbutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox maskTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addExceptionButton;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.CheckBox isSpecificIPCheckBox;
    }
}