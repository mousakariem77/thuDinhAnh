using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.DAO
{
    public class AdminDAO
    {
        private static AdminDAO instance = null;
        private static readonly object instanceLock = new object();
        public static AdminDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AdminDAO();

                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Admin> GetAdminlist()
        {
            var admins = new List<Admin>();
            try 
            {
                using var context = new DBContext();
                admins = context.Admins.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return admins;
        }

        public Admin GetAdminByID(int adminID)
        {
            Admin admin = null;
            try
            {
                using var context = new DBContext();
                admin = context.Admins.SingleOrDefault(c => c.AdminId.Equals(adminID));

            }
            catch (System.Exception)
            {

                throw;
            }
            return admin;
        }

        public void AddNew(Admin admin)
        {
            try
            {
                Admin existingAdmin = GetAdminByID(admin.AdminId);
                if (existingAdmin == null)
                {
                    using (var context = new DBContext())
                    {
                        context.Admins.Add(admin);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The admin already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Admin admin)
        {
            try
            {
                Admin existingAdmin = GetAdminByID(admin.AdminId);
                if (existingAdmin != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Admins.Update(admin);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The admin does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int adminID)
        {
            try
            {
                Admin admin = GetAdminByID(adminID);
                if (admin != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Admins.Remove(admin);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The admin does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Admin GetAdminByUsername(string username)
        {
            Admin admin = null;
            try
            {
                using var context = new DBContext();
                {
                    admin = context.Admins.SingleOrDefault(u => u.Username == username);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving Admin information from the database.", ex);
            }

            return admin;
        }

        public bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return String.Equals(enteredPassword, storedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}