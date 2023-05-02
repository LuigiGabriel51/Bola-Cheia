using Bola_Cheia.ServicesRest;
using System;

namespace Bola_Cheia.Screens.ScreenShell;

public partial class TablePage : ContentPage
{
	GETtable request = new GETtable();
    public TablePage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        InitializeComponent();

    }

    private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedLeague = (sender as Picker).SelectedItem.ToString();
        switch (selectedLeague)
        {
            case "Premier League":
                listView.ItemsSource = null;
                listView.ItemsSource = await request.getLeague("https://api.football-data.org/v4/competitions/PL/standings");
                imgDestaque.Source = "https://crests.football-data.org/PL.png";
                break;

            case "La Liga":   
                listView.ItemsSource = null;
                listView.ItemsSource = await request.getLeague("https://api.football-data.org/v4/competitions/PD/standings");
                imgDestaque.Source = "https://crests.football-data.org/PD.png";
                break;

            case "Serie A":
                listView.ItemsSource = null;
                listView.ItemsSource = await request.getLeague("https://api.football-data.org/v4/competitions/SA/standings");
                imgDestaque.Source = "https://crests.football-data.org/SA.png";
                break;

            case "Bundesliga":
                listView.ItemsSource = null;
                listView.ItemsSource = await request.getLeague("https://api.football-data.org/v4/competitions/BL1/standings");
                imgDestaque.Source = "https://crests.football-data.org/BL1.png";

                break;

            case "Ligue 1":
                listView.ItemsSource = null;
                listView.ItemsSource = await request.getLeague("https://api.football-data.org/v4/competitions/FL1/standings");
                imgDestaque.Source = "https://crests.football-data.org/FL1.png";
                break;

            case "Campeonato Brasileiro Série A":
                listView.ItemsSource = null;
                listView.ItemsSource =  await request.getLeague("https://api.football-data.org/v4/competitions/BSA/standings");
                imgDestaque.Source = "seriea.png";
                break;

            case "Liga Portugal":
                listView.ItemsSource = null;
                listView.ItemsSource = await request.getLeague("https://api.football-data.org/v4/competitions/PPL/standings");
                imgDestaque.Source = "https://crests.football-data.org/PPL.png";
                break;

            default:
                break;
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Tabela.IsVisible = true;
        LP.IsVisible = false;
        CA.IsVisible = false;
        CI.IsVisible = false;
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {

    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {

    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        Tabela.IsVisible = false;
        LP.IsVisible = true;
        CA.IsVisible = true;
        CI.IsVisible = true;
    }

    private void AnimateFrameBorderColor(Frame frame)
    {
#pragma warning disable CS0612 // O tipo ou membro é obsoleto
        Device.StartTimer(TimeSpan.FromSeconds(1.5), () =>
        {
            Color newColor = GenerateRandomColor();
            frame.BorderColor = newColor;
            return true;
        });
#pragma warning restore CS0612 // O tipo ou membro é obsoleto
    }

    private void AnimateButtonBorderColor(Button button)
    {
#pragma warning disable CS0612 // O tipo ou membro é obsoleto
        Device.StartTimer(TimeSpan.FromSeconds(1.5), () =>
        {
            Color newColor = GenerateRandomColor();
            button.BorderColor = newColor;
            return true;
        });
#pragma warning restore CS0612 // O tipo ou membro é obsoleto
    }

    private Color GenerateRandomColor()
    {
        Random random = new Random();
        byte[] rgb = new byte[3];
        random.NextBytes(rgb);
        return Color.FromRgb(rgb[0], rgb[1], rgb[2]);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        AnimateButtonBorderColor(LP);
        AnimateButtonBorderColor(CA);
        AnimateButtonBorderColor(CI);
        AnimateFrameBorderColor(Tabela);
        AnimateFrameBorderColor(toolbar);
    }
}