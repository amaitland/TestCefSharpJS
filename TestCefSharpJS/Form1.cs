using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace TestCefSharpJS
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromeBrowser;

        public Form1()
        {
            InitializeComponent();

            CefSettings cefsettings = new CefSettings();
            cefsettings.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:40.0) Gecko/20100101 Firefox/40.0";
            cefsettings.LogSeverity = LogSeverity.Disable;
            cefsettings.CefCommandLineArgs.Add("enable-npapi", "1");
            cefsettings.CefCommandLineArgs.Add("disable-bundled-ppapi-flash", "1");

            Cef.Initialize(cefsettings);

            chromeBrowser = new ChromiumWebBrowser("https://www.google.com/");
            chromeBrowser.RegisterJsObject("jsObject", this, false);

            chromeBrowser.Size = new Size(800, 600);
            chromeBrowser.Dock = DockStyle.Fill;

            this.panelChrome.Controls.Add(chromeBrowser);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
