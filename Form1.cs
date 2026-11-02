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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string userId = txtUserID.Text;
            string password = txtPassword.Text;

            // 1. Check for Admin First (Opens MemberPortal)
            if (userId == "admin" && password == "1234")
            {
                MemberPortal adminForm = new MemberPortal("Admin", "2026-0000", "Active");
                adminForm.Show();
                this.Hide();
                return;
            }

            // 2. Loop to find the Student
            bool found = false;
            for (int i = 0; i < Member.indexCounter; i++)
            {
                if (userId == Member.id[i] && password == Member.Password[i])
                {
                    if (Member.Status[i] == "Accepted")
                    {
                        // --- THIS IS THE SPOT ---
                        string fullName = Member.FirstName[i] + " " + Member.LastName[i];
                        string studentID = Member.id[i];

                        // Call the PortalCSS and pass the 2 arguments
                        PortalCSS studentForm = new PortalCSS(fullName, studentID);
                        studentForm.Show();

                        this.Hide();
                        // ------------------------

                        found = true;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Your account is still Pending approval.");
                        return;
                    }
                }
            }

            if (!found)
            {
                MessageBox.Show("Invalid ID or Password.");
            }
        }




        private void OpenPortal(string name, string id, string status)
        {
            // This creates the new window and sends the user's data to it
            MemberPortal portal = new MemberPortal(name, id, status);
            portal.Show();

            // This hides the login screen
            this.Hide();
        }

        private void OpenStudentPortal(string name, string id)
        {
            PortalCSS studentForm = new PortalCSS(name, id);
            studentForm.Show();
            this.Hide();
        }

        private void llbForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Redirecting to Password Recovery...");

            // Create an instance of the ForgotPassword form
            ForgotPassword resetForm = new ForgotPassword();

            // Open it as a dialog so the user stays on this task
            resetForm.ShowDialog();
        }

        private void llbApplyNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Opening CSS Membership System...");

            // Create an instance of the NewMember form
            NewMember Form1 = new NewMember();
            Form1.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void llbRememberMe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (llbRememberMe.Text == "Remember Me")
            {
                llbRememberMe.Text = "Forget Me";
                MessageBox.Show("Credentials will be saved on next login."); 
            }
            else
            {

                llbRememberMe.Text = "Remember Me";
                MessageBox.Show("Saved credentials cleared.");
            }
        }
    }
}
       