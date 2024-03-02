using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.DAO;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public class AdminRepository : IAdminRepository
    {
        public Admin GetAdminByID(int adminId) => AdminDAO.Instance.GetAdminByID(adminId);
        public IEnumerable<Admin> GetAdmins() => AdminDAO.Instance.GetAdminlist();
        public void InsertAdmin(Admin admin) => AdminDAO.Instance.AddNew(admin);
        public void DeleteAdmin(int adminId) => AdminDAO.Instance.Remove(adminId);
        public void UpdateAdmin(Admin admin) => AdminDAO.Instance.Update(admin); 

        public bool CheckLogin(string username, string pass) => AdminDAO.Instance.VerifyPassword(username, pass);

        public Admin GetAdminByUsername(string username) => AdminDAO.Instance.GetAdminByUsername(username);
    }
}