using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace StudentClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ================= REGISTER =================
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (var client = new WebClient())
            {
                var data = new NameValueCollection();
                data["username"] = username;
                data["password"] = password;

                byte[] response = client.UploadValues(
                    "http://localhost/student-api/api.php?action=register",
                    "POST",
                    data
                );

                string result = Encoding.UTF8.GetString(response);
                MessageBox.Show(result);
            }
        }

       
        // ================= VIEW USERS =================
        private void btnView_Click_1(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                string url = "http://localhost/student-api/api.php?action=view";

                string json = client.DownloadString(url);

                var users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(json);

                lstUsers.Items.Clear();

                foreach (var user in users)
                {
                    lstUsers.Items.Add(user.username + " - " + user.password);
                }
            }
        }
        // ================= UPDATE PASSWORD =================
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                var data = new NameValueCollection();

                data["username"] = txtUsername.Text;
                data["password"] = txtPassword.Text;

                byte[] response = client.UploadValues(
                    "http://localhost/student-api/api.php?action=update",
                    "POST",
                    data
                );

                string result = Encoding.UTF8.GetString(response);
                MessageBox.Show(result);
            }
        }

        // ================= DELETE USER =================
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                var data = new NameValueCollection();

                data["username"] = txtUsername.Text;

                byte[] response = client.UploadValues(
                    "http://localhost/student-api/api.php?action=delete",
                    "POST",
                    data
                );

                string result = Encoding.UTF8.GetString(response);
                MessageBox.Show(result);
            }
        }
        // ================= LOGIN =================
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                var data = new NameValueCollection();

                data["username"] = txtUsername.Text;
                data["password"] = txtPassword.Text;

                byte[] response = client.UploadValues(
                    "http://localhost/student-api/api.php?action=login",
                    "POST",
                    data
                );

                string result = Encoding.UTF8.GetString(response);
                MessageBox.Show(result);
            }
        }
    }

    // ================= USER CLASS =================
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}