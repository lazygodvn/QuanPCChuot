using System;
using System.Windows.Forms;

namespace QuanPCChuot.UI.Controls
{
    public partial class AccountManager : UserControl
    {
        public AccountManager()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            dgvAcc.DataSource = BUS.AccountManager.GetAllAccounts();

            AddBinding();
        }

        public void AddBinding()
        {
            if (dgvAcc.DataSource != null)
            {
                tbID.DataBindings.Add(new Binding("Text", dgvAcc.DataSource, "ID"));
                tbName.DataBindings.Add(new Binding("Text", dgvAcc.DataSource, "Name"));
                tbUsername.DataBindings.Add(new Binding("Text", dgvAcc.DataSource, "Username"));
                // tbPassword.DataBindings.Add(new Binding("Text", dgvAcc.DataSource, "Password"));
                tbTelephone.DataBindings.Add(new Binding("Text", dgvAcc.DataSource, "Telephone"));
                cbIsAdmin.DataBindings.Add(new Binding("Enabled", dgvAcc.DataSource, "IsAdmin"));
                dtpCreatedDate.DataBindings.Add(new Binding("Value", dgvAcc.DataSource, "CreatedDate"));
            }
        }

    }
}
