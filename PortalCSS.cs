using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MembershipSystem
{
    public partial class PortalCSS : Form
    {
        private string UserName;
        private string UserID;
        public PortalCSS( string name, string id)
        {
            InitializeComponent();

            this.UserName = name;
            this.UserID = id;

            lblWelcome.Text = "Welcome, " + name;
            lblStudentID.Text = "ID Number: " + id;

            LoadProfile();
            LoadEvents();
            LoadResources();
            LoadCertificates();
            LoadAnnouncements();
            LoadQuickActions();
        }

        private void LoadProfile()
        {
            lblIDNumber.Text = "ID Number: " + this.UserID;

            // 1. Find the index for the logged-in UserID
            int index = -1;
            for (int i = 0; i < Member.id.Length; i++)
            {
                if (Member.id[i] == this.UserID)
                {
                    index = i;
                    break;
                }
            }

            // 2. Load the image from the array
            if (index != -1 && !string.IsNullOrEmpty(Member.ImagePath[index]))
            {
                string path = Member.ImagePath[index];
                if (System.IO.File.Exists(path))
                {
                    picProfileTab.Image = Image.FromFile(path);
                    picProfileTab.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }


        private void LoadStudentData()
        {
            // 1. Find the index of the logged-in user in the Member arrays
            int index = -1;
            for (int i = 0; i < Member.id.Length; i++)
            {
                if (Member.id[i] == this.UserID)
                {
                    index = i;
                    break;
                }
            }

            // 2. If we found the user, fill the textboxes
            if (index != -1)
            {
                // Filling textboxes using concatenation (no dollar signs)
                txtFirstName.Text = Member.FirstName[index];
                txtMiddleName.Text = Member.MiddleName[index];
                txtLastName.Text = Member.LastName[index];
                cmbGender.Text = Member.Gender[index];
                txtEmail.Text = Member.Email[index];
                txtMobileNumber.Text = Member.MobileNumber[index];

                // Handle the Birth Date (DateTime picker)
                // Convert the string from your array into a DateTime object
                dtpBirthDate.Value = DateTime.Parse(Member.BirthDate[index]);
            }
        }
        private void LoadEvents()
        {
            ListBox eventList = new ListBox();
            eventList.Items.Add("Orientation Day");
            eventList.Items.Add("Seminar 2026");
            eventList.Items.Add("Workshop UI Design");

            eventList.Dock = DockStyle.Fill;

            tabEvents.Controls.Add(eventList);
        }
        private void LoadResources()
        {
            Button btnDownload = new Button();
            btnDownload.Text = "Download Materials";
            btnDownload.Location = new Point(20, 20);

            tabResources.Controls.Add(btnDownload);
        }

        private void LoadCertificates()
        {
            ListView certList = new ListView();
            certList.View = View.List;
            certList.Items.Add("HTML Certificate");
            certList.Items.Add("C# Certificate");

            certList.Dock = DockStyle.Fill;

            tabCertificates.Controls.Add(certList);
        }

        private void LoadAnnouncements()
        {
            TextBox txtAnnouncements = new TextBox();
            txtAnnouncements.Multiline = true;
            txtAnnouncements.Text = "Welcome! New updates will appear here.";
            txtAnnouncements.Dock = DockStyle.Fill;

            tabAnnouncements.Controls.Add(txtAnnouncements);
        }

        private void LoadQuickActions()
        {
            Button btnApply = new Button();
            btnApply.Text = "Apply Membership";
            btnApply.Location = new Point(20, 20);

            Button btnRefresh = new Button();
            btnRefresh.Text = "Refresh Data";
            btnRefresh.Location = new Point(20, 60);

            tabQuickActions.Controls.Add(btnApply);
            tabQuickActions.Controls.Add(btnRefresh);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
                MessageBox.Show("Please search and select a record first.");
            

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            // Load the image logic
            if (!string.IsNullOrEmpty(MembershipSystem.UserID.CurrentUserImagePath) && System.IO.File.Exists(MembershipSystem.UserID.CurrentUserImagePath))
            {
                picProfileTab.Image = Image.FromFile(MembershipSystem.UserID.CurrentUserImagePath);
            }
            else
            {
                MessageBox.Show("No image found.");
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picProfileTab_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PortalCSS_Load(object sender, EventArgs e)
        {
            LoadStudentData();
        }
    }
}
