using System;
using System.Reflection;
using System.Windows.Forms;

namespace CircleInput2
{
    public partial class Author : Form
    {
        public Author()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.kasa-parasol.tk/circle-input2/");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/KasaParasol");
        }

        private void Author_Load(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly().GetName();
            var ver = assembly.Version;
            var additonal = ver.Major == 0 ? "(public-beta)" : "";

            label3.Text = $"v{ver.Major}.{ver.Minor}.{ver.Build}.{ver.Revision} {additonal}";
        }
    }
}
