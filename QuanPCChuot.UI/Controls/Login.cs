using System.ComponentModel;
using System.Windows.Forms;

namespace QuanPCChuot.UI.Controls
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            if (tbUsername.Text.Length == 0 ||
                tbPassword.Text.Length == 0)
            {
                label3.Text = "Username or password cannot be empty!";
                return;
            }
            else
            {
                progressBar1.Visible = true;
                label3.Text = "Logging in...";
                bwLogin.RunWorkerAsync();
            }
        }

        private void bwLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = BUS.Account.Login(tbUsername.Text, tbPassword.Text);
        }

        private void bwLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BUS.Account.LoginState result = (BUS.Account.LoginState)e.Result;
            switch (result)
            {
                case BUS.Account.LoginState.CorrectPassword:
                    // TODO: Correct Password
                    break;
                case BUS.Account.LoginState.IncorrentPassword:
                    // TODO: Incorrect Password
                    break;
                case BUS.Account.LoginState.NotFound:
                    // TODO: Not found
                    break;
                case BUS.Account.LoginState.Unknown:
                    // TODO: Unknown
                    break;
            }
        }
    }
}
