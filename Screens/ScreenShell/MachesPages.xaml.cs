using Bola_Cheia.ServicesRest;

namespace Bola_Cheia.Screens.ScreenShell;

public partial class MachesPages : ContentPage
{
	GETconfrontos confrontos = new GETconfrontos();
    private Button lastClickedButton = null;
    DateTime dataI = DateTime.Now;
    DateTime dataF = DateTime.Now;
    DateTime hoje = DateTime.Now;
    public MachesPages()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        InitializeComponent();
		pega_confrontos();
	} 
	public async void pega_confrontos()
	{
        dataF = dataF.AddDays(1);
        listMaches.ItemsSource = null;
        listMaches.ItemsSource = await confrontos.getConfrontos($"https://api.football-data.org/v4/matches?competitions=PL,BL1,SA,BSA,PD,LF1,PLL&dateFrom={dataI.ToString("yyyy-MM-dd")}&dateTo={dataF.ToString("yyyy-MM-dd")}");
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
       
        dataI = dataI.AddDays(-1);
        dataF = dataF.AddDays(-1);
        string data = string.Format("Jogos do dia: {0:dd-MM-yyyy}", dataI);
        Console.WriteLine(dataI);
        Jdata.Text = data;
        Console.WriteLine(dataI.ToString("dd-MM-yyyy"));
        listMaches.ItemsSource = null;
        listMaches.ItemsSource = await confrontos.getConfrontos($"https://api.football-data.org/v4/matches?competitions=PL,BL1,SA,BSA,PD,LF1,PLL&dateFrom={dataI.ToString("yyyy-MM-dd")}&dateTo={dataF.ToString("yyyy-MM-dd")}");
        lastClickedButton = button1;
        

    }

    private async void Button_Clicked3(object sender, EventArgs e)
    {
        {
            dataI = dataI.AddDays(1);
            dataF = dataF.AddDays(1);

            string data = string.Format("Jogos do dia: {0:dd-MM-yyyy}", dataI);
            Console.WriteLine(dataI);
            Jdata.Text = data;
            listMaches.ItemsSource = null;
            listMaches.ItemsSource = await confrontos.getConfrontos($"https://api.football-data.org/v4/matches?competitions=PL,BL1,SA,BSA,PD,LF1,PLL&dateFrom={dataI.ToString("yyyy-MM-dd")}&dateTo={dataF.ToString("yyyy-MM-dd")}");
            lastClickedButton = button2;
        }

    }
}