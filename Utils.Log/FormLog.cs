using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utils.Log
{
    public partial class FormLog : Form
    {
        public FormLog()
        {
            InitializeComponent();

            this.chk_alarm.CheckedChanged += this.chk_CheckedChanged;
            this.chk_warning.CheckedChanged += this.chk_CheckedChanged;
            this.chk_message.CheckedChanged += this.chk_CheckedChanged;
        }

        void chk_CheckedChanged(object sender, EventArgs e)
        {
            this.logTable1.Filter(this.chk_alarm.Checked, this.chk_warning.Checked, this.chk_message.Checked);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            log_manager.Instance.Clear();
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream myStream = myAssembly.GetManifestResourceStream("Utils.Log.alarm_icon.png");
            Image image = new Bitmap(myStream);

            this.chk_alarm.Image = image;

            myStream = myAssembly.GetManifestResourceStream("Utils.Log.warning_icon.png");
            image = new Bitmap(myStream);
            this.chk_warning.Image = image;

            myStream = myAssembly.GetManifestResourceStream("Utils.Log.message_icon.png");
            image = new Bitmap(myStream);
            this.chk_message.Image = image;

            myStream = myAssembly.GetManifestResourceStream("Utils.Log.clear_icon.png");
            image = new Bitmap(myStream);
            this.btn_clear.Image = image;

            //this.Icon = Utils.LogResource.log_icon;
            //this.chk_alarm.Image = LogResource.alarm_icon;
            //this.chk_warning.Image = LogResource.warning_icon;
            //this.chk_message.Image = LogResource.message_icon;
            //this.btn_clear.Image = LogResource.clear_icon;
        }
    }
}
