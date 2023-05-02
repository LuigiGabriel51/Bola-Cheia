

namespace Bola_Cheia;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        InitializeComponent();
        
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            btnExecutarAcao.IsEnabled = false;
            LoadingLayout.IsVisible = true;
            await Task.Delay(200);
            AppShell appShell = new AppShell();
            Application.Current.MainPage = appShell;
        }
        catch (Exception)
        {
            // Trate a exceção
        }
        finally
        {
            btnExecutarAcao.IsEnabled = true;
            LoadingLayout.IsVisible = false;
        }
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        imgPD.IsAnimationPlaying = true;
    }

}

