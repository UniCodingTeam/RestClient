using Newtonsoft.Json;
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
        

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnDeserialise_Click(object sender, EventArgs e)
        {
            debugOutput(txtInput.Text);
            //deserialiseJSON(txtInput.Text);
        }

        #endregion

        #region Debug Output
        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtOutput.Text = txtOutput.Text + strDebugText + Environment.NewLine;
                txtOutput.SelectionStart = txtOutput.TextLength;
                txtOutput.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
        }
        #endregion

        #region JSON Methods
        private void deserialiseJSON(string strJSON)
        {
            try
            {
                var jPerson = JsonConvert.DeserializeObject<dynamic>(strJSON);

                debugOutput("Here is our JSON object: " + jPerson.ToString());
                debugOutput("Here is our firstname: " + jPerson.firstname);
                debugOutput("Here is our address: " + jPerson.address.streetAddress);

                debugOutput("Attempting to print phone numbers... ");

                foreach (var num in jPerson.phoneNumbers)
                {
                    debugOutput(num.type.ToString() + " - " + num.number.ToString());
                }

            }
            catch (Exception ex)
            {
                debugOutput("We had a problem: " + ex.Message.ToString());
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDeserialise_Click_1(object sender, EventArgs e)
        {
            deserialiseJSON(txtInput.Text);
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtOutput.Text = String.Empty;
        }

        private void btnDeserialise_Click_2(object sender, EventArgs e)
        {
            deserialiseJSON(txtInput.Text);
        }
    }
}
