using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CefSharp;

namespace OneStop
{
    public partial class OS_Browser : Form
    {
        public OS_Browser()
        {
            InitializeComponent();
            wbMain.AllowNavigation = true;
            wbMain.AllowWebBrowserDrop = true;
            wbMain.IsWebBrowserContextMenuEnabled = true;
            wbMain.ScrollBarsEnabled = true;
            wbMain.Navigate("http://www.google.com/");
        }

        private void CheckKeys(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                wbMain.Navigate(tstxtURL.Text);
            }
        }

        private void tsbBack_Click(object sender, EventArgs e)
        {
            wbMain.GoBack();
        }

        private void tsbForward_Click(object sender, EventArgs e)
        {
            wbMain.GoForward();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (wbMain != null)
            {
                wbMain.Navigate(tstxtURL.Text);
            }
            else
            {
                MessageBox.Show("Select a valid URL");
            }
        }

    }
}
