namespace Question3_WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlMain = new Panel();
            lblOutput = new Label();
            btnRemove = new Button();
            btnAdd = new Button();
            txtLanguage = new TextBox();
            lstLanguages = new ListBox();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Controls.Add(lblOutput);
            pnlMain.Controls.Add(btnRemove);
            pnlMain.Controls.Add(btnAdd);
            pnlMain.Controls.Add(txtLanguage);
            pnlMain.Controls.Add(lstLanguages);
            pnlMain.Location = new Point(361, 79);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(488, 332);
            pnlMain.TabIndex = 0;
            pnlMain.Paint += pnlMain_Paint;
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.ForeColor = Color.Gray;
            lblOutput.Location = new Point(180, 243);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(0, 20);
            lblOutput.TabIndex = 4;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Crimson;
            btnRemove.Location = new Point(249, 194);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(158, 29);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DodgerBlue;
            btnAdd.Location = new Point(107, 194);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(136, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add Language";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtLanguage
            // 
            txtLanguage.Location = new Point(107, 161);
            txtLanguage.Name = "txtLanguage";
            txtLanguage.PlaceholderText = "Enter programming language";
            txtLanguage.Size = new Size(300, 27);
            txtLanguage.TabIndex = 1;
            txtLanguage.TextChanged += txtLanguage_TextChanged;
            // 
            // lstLanguages
            // 
            lstLanguages.FormattingEnabled = true;
            lstLanguages.Location = new Point(107, 30);
            lstLanguages.Name = "lstLanguages";
            lstLanguages.Size = new Size(300, 124);
            lstLanguages.TabIndex = 0;
            lstLanguages.Tag = "";
            lstLanguages.SelectedIndexChanged += lstLanguages_SelectedIndexChanged;
            // 
            // lblTitle
            // 
            lblTitle.Cursor = Cursors.SizeNS;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Black;
            lblTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1222, 31);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "My Favourite Programming Languages";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1222, 617);
            Controls.Add(lblTitle);
            Controls.Add(pnlMain);
            ForeColor = Color.White;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Favourite Programming Languages";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Label lblTitle;
        private ListBox lstLanguages;
        private TextBox txtLanguage;
        private Button btnAdd;
        private Button btnRemove;
        private Label lblOutput;
    }
}
