using HRApp.Models;
using Xamarin.Forms;

namespace HRApp.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            CustomRender();
        }
        public void CustomRender()
        {
            usernameInput.Completed += (s, e) => passwordInput.Focus();
            passwordInput.Completed += (s, e) => LoginEvent(s, e);
        }
        private void LoginEvent(object sender, System.EventArgs e)
        {
            User user = new User(usernameInput.Text, passwordInput.Text);
            if(user.CheckInput())
            {
                DisplayAlert("Đăng Nhập", "Đăng Nhập Thành Công", "Xác Nhận");
            }
            else
            {
                DisplayAlert("Đăng Nhập", "Đăng Nhập Thất Bại. Tên Đăng Nhập Hoặc Mật Khẩu Không Được Đẻ Trống", "Quay Lại");
;           }
        }
    }
}
