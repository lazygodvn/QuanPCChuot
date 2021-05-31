using QuanPCChuot.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanPCChuot.BUS
{
    public static partial class Account
    {
        public enum LoginState
        {
            Unknown = -1,
            NotFound = 0,
            IncorrentPassword = 1,
            CorrectPassword = 2
        }

        public static LoginState Login(string username, string password)
        {
            try
            {
                using (var db = new Model1())
                {
                    var acc = db.Accounts.Where(p => p.Username.ToUpper() == username.ToUpper()).FirstOrDefault();
                    if (acc == null)
                        return LoginState.NotFound;
                    if (acc.Password != password)
                        return LoginState.IncorrentPassword;
                    return LoginState.CorrectPassword;
                }
            }
            catch (Exception ex)
            {
                return LoginState.Unknown;
            }
        }
    }
}
