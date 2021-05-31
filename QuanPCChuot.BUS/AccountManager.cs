using QuanPCChuot.DAL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace QuanPCChuot.BUS
{
    public static partial class AccountManager
    {
        public static BindingList<DTO.Account> GetAllAccounts()
        {
            using (var db = new Model1())
            {
                db.Accounts.Load();
                // return db.Accounts.Select(p => new { p.ID, p.Name, p.Username, p.Password, p.Telephone, p.IsAdmin, p.CreatedDate }).tob;
                return db.Accounts.Local.ToBindingList();
            }
        }
    }
}
