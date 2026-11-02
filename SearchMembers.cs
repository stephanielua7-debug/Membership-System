using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MembershipSystem
{
    public partial class SearchMembers : Form
    {
        public SearchMembers()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchID = txtSearchID.Text; // Assuming your textbox is named txtSearchID
            bool found = false;

            for (int i = 0; i < Member.indexCounter; i++)
            {
                if (searchID == Member.id[i])
                {
                    // If found, show their info (example: putting it in labels or textboxes)
                    MessageBox.Show("Member Found!\nName: " + Member.FirstName[i] + " " + Member.MiddleName[i]+ ""+ Member.LastName[i]+ "" + Member.Gender[i] + ""+ Member.MobileNumber[i] + "" + Member.BirthDate[i] + "" +Member.Email[i]);

                    // Optional: If you have a DataGridView on this form, highlight the row
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("Member ID not found.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string searchID = txtSearchID.Text;
            int foundIndex = -1;

            // 1. Find the index of the person to delete
            for (int i = 0; i < Member.indexCounter; i++)
            {
                if (searchID == Member.id[i])
                {
                    foundIndex = i;
                    break;
                }
            }

            if (foundIndex != -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this member?", "Confirm", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // 2. Shift all elements after the found index to the left
                    for (int i = foundIndex; i < Member.indexCounter - 1; i++)
                    {
                        Member.id[i] = Member.id[i + 1];
                        Member.FirstName[i] = Member.FirstName[i + 1];
                        Member.LastName[i] = Member.LastName[i + 1];
                        Member.Password[i] = Member.Password[i + 1];
                        Member.Status[i] = Member.Status[i + 1];
                        // Repeat for all other arrays (Email, Gender, etc.)
                    }

                    // 3. Decrease the counter
                    Member.indexCounter--;

                    MessageBox.Show("Member deleted successfully!");
                    txtSearchID.Clear();
                }
            }
            else
            {
                MessageBox.Show("Member ID not found.");
            }
        }

        private void LoadApplicants()
        {
            dgvApplicantsView.Rows.Clear();
            for (int i = 0; i < Member.indexCounter; i++)
            {
                dgvApplicantsView.Rows.Add(
                    Member.id[i],
                    Member.FirstName[i],
                    Member.MiddleName[i],
                    Member.LastName[i],
                    Member.Gender[i],
                    Member.BirthDate[i],
                    Member.Email[i],
                    Member.Status[i]
                );
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvApplicantsView.ColumnCount = 8;
            string[] columnNames = new string[] { "ID Number", "First Name", "Middle Name", "Last Name", "Gender", "Birth Date", "Email", "Status" };

            for (int x = 0; x < columnNames.Length; x++)
            {
                dgvApplicantsView.Columns[x].Name = columnNames[x];
            }

            LoadApplicants();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
