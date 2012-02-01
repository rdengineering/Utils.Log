namespace Utils.Log
{
    partial class FormLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLog));
            this.btn_clear = new System.Windows.Forms.Button();
            this.chk_alarm = new System.Windows.Forms.CheckBox();
            this.chk_warning = new System.Windows.Forms.CheckBox();
            this.chk_message = new System.Windows.Forms.CheckBox();
            this.logTable1 = new Utils.Log.LogTable();
            this.SuspendLayout();
            // 
            // btn_clear
            // 
            this.btn_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_clear.Location = new System.Drawing.Point(449, 0);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(85, 40);
            this.btn_clear.TabIndex = 1;
            this.btn_clear.Text = "CLEAR";
            this.btn_clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // chk_alarm
            // 
            this.chk_alarm.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_alarm.Checked = true;
            this.chk_alarm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_alarm.Location = new System.Drawing.Point(0, 0);
            this.chk_alarm.Name = "chk_alarm";
            this.chk_alarm.Size = new System.Drawing.Size(40, 40);
            this.chk_alarm.TabIndex = 2;
            this.chk_alarm.UseVisualStyleBackColor = true;
            // 
            // chk_warning
            // 
            this.chk_warning.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_warning.Checked = true;
            this.chk_warning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_warning.Location = new System.Drawing.Point(40, 0);
            this.chk_warning.Name = "chk_warning";
            this.chk_warning.Size = new System.Drawing.Size(40, 40);
            this.chk_warning.TabIndex = 3;
            this.chk_warning.UseVisualStyleBackColor = true;
            // 
            // chk_message
            // 
            this.chk_message.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_message.Checked = true;
            this.chk_message.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_message.Location = new System.Drawing.Point(80, 0);
            this.chk_message.Name = "chk_message";
            this.chk_message.Size = new System.Drawing.Size(40, 40);
            this.chk_message.TabIndex = 4;
            this.chk_message.UseVisualStyleBackColor = true;
            // 
            // logTable1
            // 
            this.logTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logTable1.Location = new System.Drawing.Point(0, 41);
            this.logTable1.Name = "logTable1";
            this.logTable1.Size = new System.Drawing.Size(534, 171);
            this.logTable1.TabIndex = 0;
            // 
            // FormLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 212);
            this.Controls.Add(this.chk_message);
            this.Controls.Add(this.chk_warning);
            this.Controls.Add(this.chk_alarm);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.logTable1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1360, 780);
            this.Name = "FormLog";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LOG";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LogTable logTable1;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.CheckBox chk_alarm;
        private System.Windows.Forms.CheckBox chk_warning;
        private System.Windows.Forms.CheckBox chk_message;
    }
}