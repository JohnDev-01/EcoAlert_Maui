namespace PrestaYaApp.Views.Dashboard;

public partial class MenuPopups : ContentPage
{
	public MenuPopups()
	{
		InitializeComponent();
	}
	public static string? typePage;
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		this.TranslationX = -Width; // Comienza fuera de la pantalla por la izquierda
		this.Opacity = 0;
		await Task.WhenAll(
			this.TranslateTo(0, 0, 1500, Easing.SpringOut), // Mueve desde la izquierda
			this.FadeTo(1, 500) // Cambia la opacidad a 1 simultáneamente
		);
		typePage = null;
	}
	private async void btnBack_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
    }

    private void DirMonitoreo_Tapped(object sender, TappedEventArgs e)
    {
        typePage = "DirMonitoreo";
        btnBack_Clicked(sender, e);
    }

    private void guia_Tapped(object sender, TappedEventArgs e)
    {
        typePage = "Guia";
        btnBack_Clicked(sender, e);
    }

    private void auxilio_Tapped(object sender, TappedEventArgs e)
    {
        typePage = "Auxilio";
        btnBack_Clicked(sender, e);
    }
}