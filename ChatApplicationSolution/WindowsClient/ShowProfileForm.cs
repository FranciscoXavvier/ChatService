using ChatServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsClient.UserServiceRef;

namespace WindowsClient
{
    public partial class ShowProfileForm : Form
    {
        UserServiceClient userService;
        ChatChoiceForm chref;
        public ShowProfileForm(ChatChoiceForm chform_ref)
        {
            InitializeComponent();
            userService = new UserServiceClient("BasicHttpBinding_IUserService");
            loadControlValues();
            chref = chform_ref;
        }

        private void loadControlValues()
        {
            this.tbEmail.Text = LoggedInUser.Email;
            this.tbName.Text = LoggedInUser.Name;
            this.tbPassword.Text = LoggedInUser.Password;
            this.tbUsername.Text = LoggedInUser.Username;
        }



        private void pswhideview_CheckedChanged(object sender, EventArgs e)
        {
            if (pswhideview.Checked)
            {
                tbPassword.UseSystemPasswordChar = false;
                var checkbox = (CheckBox)sender;
                checkbox.Text = "Click To Hide";
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
                var checkbox = (CheckBox)sender;
                checkbox.Text = "Click To View";
            }
        }
    }
}
