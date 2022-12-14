using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsClient.UserServiceRef;
using ChatServiceLibrary.Models;

namespace WindowsClient
{
    public partial class LoginForm : Form
    {
        UserServiceClient userService;
        public LoginForm()
        {
            InitializeComponent();
            userService = new UserServiceClient("BasicHttpBinding_IUserService");
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
                Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            User user = userService.Login(username, password);

            // Change the Login State
            if (user.Username != null)
            {
                LoggedInUser.UserId = user.UserId;
                LoggedInUser.Username = user.Username;
                LoggedInUser.Password = user.Password;

                Console.WriteLine(LoggedInUser.Username);
                MessageBox.Show("Successfully LoggedIn !", "Congrats", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ChatChoiceForm choiceForm = new ChatChoiceForm();
                this.Hide();
                choiceForm.Show();
            }

            else
            {
                MessageBox.Show("Please enter Correct Username and Password", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pswhideview_CheckedChanged(object sender, EventArgs e)
        {
            if (pswhideview.Checked)
            {
                tbPassword.UseSystemPasswordChar = true;
                var checkbox = (CheckBox)sender;
                checkbox.Text = "Click To View";
            }
            else
            {
                tbPassword.UseSystemPasswordChar = false;
                var checkbox = (CheckBox)sender;
                checkbox.Text = "Click To Hide";
            }
        }
    }
}
