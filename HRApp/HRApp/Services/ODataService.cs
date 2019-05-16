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
                    .Expand("BoPhan")
                    .FindEntryAsync();
                if (!result.Equals(null))
                {
                    NhanVien nhanVien = new NhanVien
                    {
                        Id = (int)result["Id"],
                        Name = (string)result["TenNhanVien"],
                        maNhanVien = (string)result["maNhanVien"],
                        department = (result["boPhan"] as IDictionary<string, object>)["tenBoPhan"] as string,
                        supervisor = (string)result["tenNguoiQuanLy"],
                        image = (string)result["ContentHinhAnh"]
                    };
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
        public async Task<BoPhan> GetDepartment(string tenBoPhan)
        {
            try
            {
                string type = $"{prefix}_Module_BusinessObjects_{typeof(BoPhan).Name}";
                var result = await _client
                               .For(type)
                               .Filter($"tenBoPhan eq '{tenBoPhan}'")
                               .Expand("NhanVien")
                               .FindEntryAsync();
                if(result != null)
                {
                    BoPhan department = new BoPhan
                    {
                        Id = (int)result["Id"],
                        Code = (string)result["maBoPhan"]
                    };
                    return department;
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
        public async Task<List<NgayLe>> GetHolidays()
        {
            try
            {
                string type = $"{prefix}_Module_BusinessObjects_{typeof(NgayLe).Name}";
                var results = await _client
                             .For(type)
                             .FindEntriesAsync();
                if (results != null)
                {
                    List<NgayLe> holidays = new List<NgayLe>();
                    foreach (var result in results)
                    {
                        NgayLe holiday = new NgayLe
                        {
                            TenNgayLe = (string)result["tenNgayLe"],
                            SoNgayNghi = (int?)result["soNgayNghi"],
                            NgayBatDau = (DateTime)result["ngayBatDauNghi"],
                            NgayKetThuc = (DateTime?)result["ngayKetThuc"],
                            GhiChu = (string)result["ghiChu"]
                        };
                        holidays.Add(holiday);
                    }
                    return holidays;
                }
                else
                    return null;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public async Task SaveLeave(LanNghiPhep lanNghiPhep)
        {
            var properties = lanNghiPhep.GetType().GetProperties();
            try
            {
                string type = $"{prefix}_Module_BusinessObjects_{typeof(LanNghiPhep).Name}";
                string nhanvien = $"{prefix}_Module_BusinessObjects_{typeof(NhanVien).Name}";
                var nhanVien = await _client
                               .For(nhanvien)
                               .Key(lanNghiPhep.NhanVien)
                               .FindEntryAsync();
                var lanNghi = await _client
                              .For(type)
                              .Set(new { ngayTaoDonXin = lanNghiPhep.NgayTaoDonXin,
                                         nguoiNghiPhep = nhanVien,
                                         ngayNghi = lanNghiPhep.NgayNghi,
                                         lyDo = lanNghiPhep.LyDo,
                                         soNgayNghi = lanNghiPhep.SoNgayNghi})
                              .InsertEntryAsync();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
    }
}
