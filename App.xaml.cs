using EcoAlert_Maui.Views;

namespace EcoAlert_Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new IntroPage();
        }
    }
}
