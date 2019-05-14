using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Net.Http;
using Simple.OData.Client;
using HRApp.Models;

namespace HRApp.Services
{
    public class ODataService : IODataService
    {
        const string prefix = "QuanLyNhanSu";
        private ODataClient _client;
        public async Task Login(string serverAddress, string userName, string password)
        {
            CreateClient(serverAddress, userName, password);
#if !NO_AUTH
            try
            {
                var task = await _client
                    .For("DevExpress_Persistent_BaseImpl_PermissionPolicy_PermissionPolicyUser")
                    .Filter($"UserName eq '{userName}'")
                    .FindEntryAsync();
            }
            catch (HttpRequestException)
            {
                throw new Exception("LỖi kết nối với Internet/Wifi/3G. Vui lòng kiểm tra lại két nối");
            }
            catch(WebRequestException)
            {
                throw new Exception("Mật Khẩu không đúng. Vui lòng kiểm tra lại hoặc liên hệ người quản");
            }
            catch(Exception exception)
            {
                throw exception;
            }
#endif
        }
        private void CreateClient(string serverAddress, string userName, string password)
        {
            var credential = new NetworkCredential(userName, password);
            var settings = new ODataClientSettings(new Uri(serverAddress), credential);
            _client = new ODataClient(settings);
        }
        public async Task<NhanVien> GetEmployee(string maNhanVien)
        {
            try
            {
                string type = $"{prefix}_Module_BusinessObjects_{typeof(NhanVien).Name}";
                var result = await _client
                    .For(type)
                    .Filter($"maNhanVien eq '{maNhanVien}'")
                    .FindEntryAsync();
                if (!result.Equals(null))
                {
                    NhanVien nhanVien = new NhanVien
                    {
                        Id = (int)result["Id"],
                        Name = (string)result["TenNhanVien"],
                        maNhanVien = (string)result["maNhanVien"]
                    };
                    Console.WriteLine("Tên Nhân Viên Là {0}",nhanVien.Name);
                    return nhanVien;
                }
                else
                    return null;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public async Task<List<NhanVien>> GetAllEmployee()
        {
            try
            {
                string type = $"{prefix}_Module_BusinessObjects_{typeof(NhanVien).Name}";
                var results = await _client
                                .For(type)
                                .FindEntriesAsync();
                var employees = new List<NhanVien>();
                foreach (var result in results)
                {
                    var employee = new NhanVien
                    {
                        Id = (int)result["Id"],
                        userName = (string)result["maNhanVien"],
                        passWord = (string)result["password"],
                        Name = (string)result["TenNhanVien"]
                    };
                    employees.Add(employee);
                }
                return employees;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
    }
}
