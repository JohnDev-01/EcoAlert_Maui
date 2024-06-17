namespace EcoAlert_Maui.Views;

public partial class IntroPage : ContentPage
{
	public IntroPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        await AnimateIcons();
    }
    private async Task AnimateIcons()
    {
        await Task.WhenAll(IconoEcoAlert.FadeTo(1, 1500)); 
         //ecoalert1.TranslateTo(0,0,1500), ecoalert2.TranslateTo(0, 0, 1500));
        
        for (int i = 0; i < 1; i++) {
            await IconoEcoAlert.FadeTo(0, 1100);
            await IconoEcoAlert.FadeTo(1, 1100);
        }
        Application.Current.MainPage = new NavigationPage(new MainPage());
    }
}