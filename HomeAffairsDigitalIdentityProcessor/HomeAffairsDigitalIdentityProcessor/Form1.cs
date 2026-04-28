using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeAffairsDigitalIdentityProcessor
{
    public partial class HomeAffairsDigitalIdentityProcessor : Form
    {
        private CitizenProfile profile;
        private string validationMessage;

        public HomeAffairsDigitalIdentityProcessor()
        {
            InitializeComponent();
            txtOutput.ReadOnly = true;
            txtOutput.BackColor = System.Drawing.Color.White;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please enter an ID number.");
                return;
            }

            if (cmbCitizen.SelectedIndex == -1)
            {
                MessageBox.Show("Please select citizenship.");
                return;
            }

            profile = new CitizenProfile(
                txtName.Text,
                txtID.Text,
                cmbCitizen.SelectedItem.ToString()
            );

            validationMessage = profile.ValidateID();

            txtOutput.Text = validationMessage;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (profile == null)
            {
                MessageBox.Show("Please validate first.");
                return;
            }

            txtOutput.Text = profile.GenerateSummary(validationMessage);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCitizen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void HomeAffairsDigitalIdentityProcessor_Load(object sender, EventArgs e)
        {

        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblCitizen_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
