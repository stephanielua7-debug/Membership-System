using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MembershipSystem
{
    public partial class NewMember : Form
    {
        public NewMember()
        {
            InitializeComponent();

            cmbGender.Items.Add("Female");
            cmbGender.Items.Add("Male");

            // Set the initial ID when the form opens
            string currentYear = DateTime.Now.Year.ToString();
            lblIDNumber.Text = currentYear.ToString() + "-" + Member.idCounter.ToString("D4");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Member.indexCounter < 100)
            {
                // Inside your registration save logic
                int i = Member.idCounter; // Use your current counter
                Member.ImagePath[i] = browseLocator;


                Member.Password[Member.indexCounter] = txtPassword.Text;
                Member.Status[Member.indexCounter] = "Pending";

                Member.id[Member.indexCounter] = lblIDNumber.Text;

                // 2. Save the names
                Member.FirstName[Member.indexCounter] = txtFirstName.Text;
                Member.MiddleName[Member.indexCounter] = txtMiddleName.Text;
                Member.LastName[Member.indexCounter] = txtLastName.Text;

                // 3. Save contact info
                Member.MobileNumber[Member.indexCounter] = txtMobileNumber.Text;
                Member.Email[Member.indexCounter] = txtEmail.Text;

                // 4. Save gender and birthdate (Don't forget these!)
                Member.Gender[Member.indexCounter] = cmbGender.Text;
                Member.BirthDate[Member.indexCounter] = dtpBirthDate.Value.ToShortDateString();

                Member.Password[Member.indexCounter] = txtPassword.Text;

                Member.ImagePath[Member.indexCounter] = browseLocator;

                // 5. Increment your counters
                Member.indexCounter++; 
        Member.idCounter++;    

        MessageBox.Show("Member successfully registered!", "Success");

        // 6. Reset the form
        txtFirstName.Clear();
        txtMiddleName.Clear();
        txtLastName.Clear();
        txtMobileNumber.Clear();
        txtEmail.Clear();
        txtPassword.Clear();
        cmbGender.SelectedIndex = -1;

        // 7. Refresh the ID label for the NEXT person
        string currentYear = DateTime.Now.Year.ToString();
                lblIDNumber.Text = currentYear.ToString() + "-" + Member.idCounter.ToString("D4");
            }
    else
    {
        MessageBox.Show("The member database is full!");
    }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtMobileNumber.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtReType.Clear();

            // Reset ComboBox
            cmbGender.SelectedIndex = -1;

            // Reset DateTimePicker to today's date
            dtpBirthDate.Value = DateTime.Now;

            // Optional: Set focus back to the first field
            txtFirstName.Focus();
        }
        string browseLocator;

        private void btnBrowsePhoto_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Title = "Open Image file";
                openFile.Filter = "Image Files (*.jpg; *.jpeg; *.gif; *bmp; *.png)| *.jpg; *.jpeg; *.gif; *.bmp; *.png";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    picProfileTab.Image = new Bitmap(openFile.FileName);
                    browseLocator = openFile.FileName;
                }
                openFile.Dispose();
            }
            catch
            {
                MessageBox.Show("Error Uploading Image");
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
