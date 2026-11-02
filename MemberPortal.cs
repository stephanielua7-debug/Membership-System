using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MembershipSystem
{
    public partial class MemberPortal : Form
    {
        public MemberPortal(string name, string id, string status)
        {
            InitializeComponent();

            lblWelcome.Text = "Welcome: " + name;
            lblIDNumber.Text = " ID: " + id;
            lblStatus.Text = "Status: " + status;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (dgvApplicants.SelectedRows.Count > 0)
            {
                // 1. Get the index of the selected row
                int selectedIndex = dgvApplicants.SelectedRows[0].Index;

                // 2. Update the data source
                Member.Status[selectedIndex] = "Accepted";

                // 3. Update the UI cell directly (Assuming 'Status' is the 7th column, index 7)
                // Check your column index in the designer!
                dgvApplicants.Rows[selectedIndex].Cells["Status"].Value = "Accepted";

                // 4. Feedback for the user
                string name = Member.FirstName[selectedIndex];
                MessageBox.Show(name + " has been accepted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a row first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
         

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvApplicants.SelectedRows.Count > 0)
            {
                dgvApplicants.Rows.RemoveAt(dgvApplicants.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Please select the full row to delete.");
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Log out?", "Confirm", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Form1 login = new Form1();
                login.Show();
                this.Close(); // Completely closes the portal
            }
        }


        private void MemberPortal_Load_1(object sender, EventArgs e)
        {

            dgvApplicants.ColumnCount = 9;
            string[] columnNames = new string[] { "ID Number", "First Name", "Middle Name", "Last Name", "Gender", "Birth Date", "Email", "Status","Password" };

            for (int x = 0; x < columnNames.Length; x++)
            {
                dgvApplicants.Columns[x].Name = columnNames[x];
            }

            LoadApplicants(); // Call the method to fill the grid

        }
        private void LoadApplicants()
        {
            dgvApplicants.Rows.Clear(); // Clear existing rows to avoid duplicates

            // Use a for loop to go through your static arrays in the Member class
            for (int i = 0; i < Member.indexCounter; i++)
            {
                dgvApplicants.Rows.Add(
                    Member.id[i],         // Access the array at current index 'i'
                    Member.FirstName[i],
                    Member.MiddleName[i],
                    Member.LastName[i],
                    Member.Gender[i],
                    Member.BirthDate[i],
                    Member.Email[i],
                    Member.Password[i],
                    "Pending"             // Initial status for applicants
                );
            }
        }

        private void btnSearchMembers_Click(object sender, EventArgs e)
        {
            // 1. Create an instance of the SearchMembers form
            SearchMembers searchForm = new SearchMembers();

            // 2. Show the search form
            searchForm.Show();

            // 3. Optional: Hide the current PortalCSS if you don't want both open
            // this.Hide();
        }
    }
}


