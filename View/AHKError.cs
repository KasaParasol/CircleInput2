using System.Windows.Forms;

namespace CircleInput2
{
    public partial class AHKError : Form
    {
        public AHKError()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://hotkeyit.github.io/v2/");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/HotKeyIt/ahkdll");
        }
    }
}
