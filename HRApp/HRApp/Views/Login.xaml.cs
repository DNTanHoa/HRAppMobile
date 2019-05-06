using HRApp.Models;
using HRApp.ViewModels;
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
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
