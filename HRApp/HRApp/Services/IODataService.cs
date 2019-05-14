using HRApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Services
{
    public interface IODataService
    {
        Task Login(string serverAddress, string userName, string password);
        Task<List<NhanVien>> GetAllEmployee();
        Task<NhanVien> GetEmployee(string maNhanVien);
    }
}
