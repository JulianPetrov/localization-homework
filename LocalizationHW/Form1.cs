using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;

namespace LocalizationHW
{
    public partial class Form1 : Form
    {

        string lang;
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lang = "bg-BG";
            ChangeLanguage(lang);
        }

        private void radioBtnChangeToUS_CheckedChanged(object sender, EventArgs e)
        {
            lang = "en-US";
            ChangeLanguage(lang);
        }

        private void ChangeLanguage(string lang)
        {
            CultureInfo cultureInfo = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            ComponentResourceManager resource = new ComponentResourceManager(this.GetType());
            this.Text = resource.GetString("$this.Text", cultureInfo);
            ApplyResourcesToControls(this,resource,cultureInfo);
            
        }

        private void ApplyResourcesToControls(Control control, ComponentResourceManager resource, CultureInfo cultureInfo)
        {
            foreach (Control c in control.Controls)
            {
                resource.ApplyResources(c, c.Name, cultureInfo);
                if(c.HasChildren) 
                    ApplyResourcesToControls(c,resource,cultureInfo);
            }
        }


    }
}
