

using EcoAlert_Maui.Views;
using Plugin.LocalNotification;
using PrestaYaApp.Views.Dashboard;

namespace EcoAlert_Maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        int numberStatusAlert = 1;
        private readonly List<Murl> listUrl =
            new List<Murl>()
            { new Murl() { Url = "https://www.instagram.com/p/C8Se7bGMxzs/?igsh=MWkxMTB2YzB5end0cw==" },
              new Murl() { Url = "https://www.instagram.com/p/C8SZ-j7vRzr/?igsh=NnV3cTM3dTlyZjQ4" }
            };

        protected override void OnAppearing()
        {
            carousel.ItemsSource = listUrl;
        }
        private async void btnMenu_Clicked(object sender, EventArgs e)
        {
            var menuPopups = new MenuPopups();
            menuPopups.Disappearing += MenuPopups_Disappearing;
            await Navigation.PushAsync(menuPopups);
        }

        private async void MenuPopups_Disappearing(object? sender, EventArgs e)
        {
            // esparar la pagina
            await ValidateNavigatePage();
        }
        private async Task ValidateNavigatePage()
        {
            var pageSelected = MenuPopups.typePage;
            dynamic pageselected = new Page();
            if (pageSelected == "DirMonitoreo")
            {
                pageselected = new DirMonitoreo();
            }
            if (pageSelected == "Auxilio")
            {
                pageselected = new Auxilio();
            }
            if (pageSelected == "Guia")
            {
                pageselected = new Guia();

            }
            await Navigation.PushAsync(pageselected);

        }
        private async void changeStatus_Tapped(object sender, TappedEventArgs e)
        {
            IncrementInterval();
            await IdentifyStatusAlert();

        }
        private async Task CreateNotification(string status)
        {
            await Task.Delay(5000);
            var notificationId = new Random().Next(0, 1000);
            var request = new NotificationRequest
            {
                NotificationId = notificationId,
                Title = "EcoAlert",
                Subtitle = "Se ha detectado un cambio",
                Description = status,
                CategoryType = NotificationCategoryType.Error
            };
            await LocalNotificationCenter.Current.Show(request);
        }
        private void IncrementInterval()
        {
            if (numberStatusAlert < 3)
            {
                numberStatusAlert++;
            }
            else
            {
                numberStatusAlert = 1;
            }
        }
        private async Task IdentifyStatusAlert()
        {
            string status = "";
            if (numberStatusAlert == 1)
            {
                frameStatus.BackgroundColor = Colors.Green;
                status = "Condiciones Seguras";
            }
            if (numberStatusAlert == 2)
            {
                frameStatus.BackgroundColor = Color.FromArgb("#FFA500");
                status = "Precaución";
            }
            if (numberStatusAlert == 3)
            {
                frameStatus.BackgroundColor = Color.FromArgb("#CA0202");
                status = "Peligro Inminente";
            }

            lblStatus.Text = status;
            await CreateNotification(status);
        }
    }
    public class Murl
    {
        public string Url { get; set; }
    }
}
