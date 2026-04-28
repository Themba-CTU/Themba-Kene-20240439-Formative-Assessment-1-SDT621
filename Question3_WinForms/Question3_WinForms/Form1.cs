namespace Question3_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lstLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string lang = txtLanguage.Text.Trim();
            if (string.IsNullOrEmpty(lang))
            {
                MessageBox.Show("Please enter a programming language.");
                return;
            }

            // Prevent duplicates
            foreach (var item in lstLanguages.Items)
            { 
             if (item.ToString().ToLower() == lang.ToLower())
             {
                 MessageBox.Show("This programming language is already in the list.");
                 return;
             }
            }
            // Add the language to the list
            lstLanguages.Items.Add(lang);
            txtLanguage.Clear();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (lstLanguages.SelectedItem == null)
            {
                MessageBox.Show("Please select a programming language to remove.");
                return;
            }

            string removed = lstLanguages.SelectedItem.ToString();
            lstLanguages.Items.Remove(removed);

            // Display date & time
            lblOutput.Text = $"Removed '{removed}' on {DateTime.Now}";
        }

        private void txtLanguage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
