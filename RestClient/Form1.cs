using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtRestURI_TextChanged(object sender, EventArgs e)
        {

        }

        #region UI Event Handlers
        private void btnGo_Click(object sender, EventArgs e)
        {
            RestClient rClient = new RestClient();
            rClient.endPoint = txtRequestURI.Text;

            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();
            txtResponse.Text = strResponse;
        }
        #endregion
    }
}
