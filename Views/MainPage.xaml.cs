

using Plugin.LocalNotification;

namespace EcoAlert_Maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        int numberStatusAlert = 1;
        private void btnMenu_Clicked(object sender, EventArgs e)
        {

        }


        private async void changeStatus_Tapped(object sender, TappedEventArgs e)
        {
            IncrementInterval();
            await IdentifyStatusAlert();
            
        }
        private async Task CreateNotification(string status )
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
            string status="";
            if ( numberStatusAlert == 1)
            {
                frameStatus.BackgroundColor = Colors.Green;
                status = "Condiciones Seguras";
            }
            if ( numberStatusAlert == 2)
            {
                frameStatus.BackgroundColor = Color.FromArgb("#FFA500");
                status = "Precaución";
            }
            if ( numberStatusAlert == 3)
            {
                frameStatus.BackgroundColor = Color.FromArgb("#CA0202");
                status = "Peligro Inminente";
            }

            lblStatus.Text = status;
            await CreateNotification(status);
        }
    }

}
