using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public interface IAdminRepository
    {
        IEnumerable<Admin> GetAdmins();
        Admin GetAdminByID(int adminId);
        void InsertAdmin(Admin admin);
        void DeleteAdmin(int adminId);
        void UpdateAdmin(Admin admin);
        Admin GetAdminByUsername(String username);
        bool CheckLogin(string username, string pass);
    }
}