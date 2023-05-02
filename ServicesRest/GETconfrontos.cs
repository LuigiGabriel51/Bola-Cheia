using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bola_Cheia.ServicesRest
{
    class GETconfrontos
    {
        private static readonly string apiKey = "079bf425346a4123873d9d6598081738";

        public async Task<List<Confronto>> getConfrontos(string urll)
        {
            using HttpClient client = new HttpClient();
            string url = urll;
            client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
            var response = await client.GetAsync(url);
            Console.WriteLine(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                JArray maches = JObject.Parse(jsonString)["matches"] as JArray;

                List<Confronto> confrontosList = new List<Confronto>();
                foreach (var team in maches)
                {
                    string campeonato = team["competition"]["name"].ToString();
                    string casa = team["homeTeam"]["name"].ToString();
                    string fora = team["awayTeam"]["name"].ToString();
                    string DateH = team["utcDate"].ToString();
                    string rodada = team["matchday"].ToString();
                    string resultadoC = team["score"]["fullTime"]["home"].ToString();
                    string resultadoF = team["score"]["fullTime"]["away"].ToString();
                    string vencedor = team["score"]["winner"].ToString();
                    string Status = team["status"].ToString();

                    DateTime dateTime = DateTime.Parse(DateH, null, DateTimeStyles.RoundtripKind);
                    DateTime localTime = dateTime.ToLocalTime();

                    if (vencedor == "HOME_TEAM")
                    {
                        vencedor = "CASA";
                    }
                    else if(vencedor == "AWAY_TEAM")
                    {
                        vencedor = "FORA";
                    }
                    else
                    {
                        if (Status == "IN_PLAY" || Status == "LIVE" || Status == "FINISHED")
                        {
                            vencedor = "EMPATE";
                        } else if (Status == "SCHEDULED" || Status == "TIMED")
                        {
                            vencedor = "INDEFINIDO";
                        }
                        else vencedor = "EMPATE";
                    }

                    Confronto jogos = new Confronto
                    {
                          Horario = Convert.ToString(localTime),
                          Competicao = campeonato,
                          nameCasa = casa,
                          nameVisitante = fora,
                          Rodada = Convert.ToInt32(rodada),
                          resultado = $"{resultadoC} X {resultadoF}",
                          Winner = vencedor 
                   };

                   confrontosList.Add(jogos);
                }
                Console.WriteLine("***************************requisicao feita com exito************************ " + maches);
                return confrontosList;
            }
            else
            {
                Console.WriteLine("requisicao feita sem exito \n");
                return null;
            }
        }

    }
    public class Confronto
    {
        public string Horario { get; set; }
        public string Competicao { get; set; }
        public string nameCasa { get; set; }
        public string nameVisitante { get; set; }
        public int Rodada { get; set; }
        public string Winner { get; set; }
        public string resultado { get; set; }
    }


}

