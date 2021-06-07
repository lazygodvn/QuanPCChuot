﻿using QuanPCChuot.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanPCChuot.BUS
{
    public static class LogManager
    {
        public static DataTable GetAllLogs()
        {
            using (var db = new Model1())
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(long));
                dt.Columns.Add("Staff name", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Created date", typeof(DateTime));

                db.Logs.Load();
                var d = db.Logs.Local.ToBindingList();

                foreach (var dr in d)
                {
                    var row = dt.NewRow();
                    row["ID"] = dr.ID;
                    row["Staff name"] = dr.Account.Name;
                    row["Description"] = dr.Description;
                    row["Created date"] = dr.CreatedDate;
                    dt.Rows.Add(row);
                }

                return dt;
            }
        }

        public static DTO.Log GetLogByID(long ID)
        {
            using (var db = new Model1())
            {
                db.Logs.Load();
                db.Accounts.Load();
                var data = db.Logs.Local.Where(p => p.ID == ID).FirstOrDefault();
                if (data == null)
                    MessageBox.Show("Log by this ID isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return data;
            }
        }

        public static void AddLog(long accID, string message)
        {
            using (var db = new Model1())
            {
                DTO.Log log = new DTO.Log();

                log.Description = message;
                log.StaffID = accID;
                log.CreatedDate = DateTime.Now;

                db.Logs.Add(log);
                db.SaveChanges();
            }
        }
    }
}
