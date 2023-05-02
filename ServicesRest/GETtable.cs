using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bola_Cheia.ServicesRest
{
    public class GETtable
    {
        private static readonly string apiKey = "079bf425346a4123873d9d6598081738";

        public async Task<List<Times>> getLeague(string urll)
        {
            using HttpClient client = new HttpClient();
            string url = urll;
            client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                JArray standings = JObject.Parse(jsonString)["standings"] as JArray;
                JArray table = (standings[0]["table"]) as JArray;
                List<Times> timesList = new List<Times>();
                foreach (var team in table)
                {
                    int posicao = team["position"].ToObject<int>();
                    var nome = team["team"]["name"].ToString();
                    int pardidasJogadas = team["playedGames"].ToObject<int>();
                    var ultimas5 = team["form"].ToString();
                    int vitorias = team["won"].ToObject<int>();
                    int empates = team["draw"].ToObject<int>();
                    int derrotas = team["lost"].ToObject<int>();
                    int pontos = team["points"].ToObject<int>();
                    int golsPro = team["goalsFor"].ToObject<int>();
                    int golscontra = team["goalsAgainst"].ToObject<int>();
                    int saldoGols = team["goalDifference"].ToObject<int>();
                    var image = team["team"]["crest"].ToString();


                    Times time = new Times
                    {
                        posicao = posicao,
                        infoNome = new Team { Name = nome},
                        pardidasJogadas = pardidasJogadas,
                        ultimas5 = ultimas5,
                        vitorias = vitorias,
                        empates = empates,
                        derrotas = derrotas,
                        pontos = pontos,
                        golsPro = golsPro,
                        golscontra = golscontra,
                        saldoGols = saldoGols,
                        urlImage = image
                    };

                    timesList.Add(time);
                }
                Console.WriteLine("***************************requisicao feita com exito************************ ");
                return timesList;
            }
            else
            {
                Console.WriteLine("requisicao feita sem exito \n");
                return null;
            }
        }

    }
    public class Times
    {
        public int posicao { get; set; }
        public Team infoNome{ get; set; }
        public int pardidasJogadas { get; set; }
        public string ultimas5  { get; set; }
        public int vitorias { get; set; }
        public int empates { get; set; }
        public int derrotas { get; set; }
        public int pontos { get; set;}
        public int golsPro { get; set; }
        public int golscontra { get; set; }
        public int saldoGols { get; set; }
        public string urlImage { get; set; }
    }

    public class Team
    {
        public string Name { get; set; }
        public string CrestUrl { get; set; }
    }
}
