using AngleSharp.Html.Parser;
using CoderCarrer.Domain;
using CoderCarrer.Models;
using HtmlAgilityPack;
using static System.Net.WebRequestMethods;

namespace CoderCarrer.DAL
{
    public class TrabalhaBrasilDAO : IExtratorVaga
    {
        List<Vaga> _lista;
        public List<Vaga> getVagas()
        {
             ExtrairDados().Wait();
            return _lista;
        }

        private async Task<List<Vaga>>  ExtrairDados() {

            var parser = new HtmlParser();
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync("https://www.trabalhabrasil.com.br/");
            var document = await parser.ParseDocumentAsync(content);
            var doc = new HtmlDocument();
            doc.LoadHtml(document.DocumentElement.OuterHtml);

          
            var body = doc.DocumentNode.SelectSingleNode("/html/body");
            var titulo = body.SelectNodes("//h2[contains(@class, 'job__name')]").Select(x => x.InnerText.Trim());
            var detalhe = body.SelectNodes("//h3[contains(@class, 'job__detail')]").Select(x => x.InnerText.Trim());
            var empresa = body.SelectNodes("//h3[contains(@class, 'job__company')]").Select(x => x.InnerText.Trim());
            var descricao = body.SelectNodes("//p[contains(@class, 'job__description')]").Select(x => x.InnerText.Trim());
            var link = doc.DocumentNode.SelectNodes("//a[contains(@class, 'job__vacancy   highlighted ')]").Select(x => x.GetAttributeValue("href", ""));

       
            _lista = new List<Vaga>();

            for (int i = 0; i < titulo.Count(); i++)
            {
                Vaga newVaga = new Vaga();

                newVaga.id_vaga = i;
                newVaga.titulo = titulo.ToArray()[i];
                newVaga.empresa = empresa.ToArray()[i];
                newVaga.descricao_vaga = descricao.ToArray()[i];
                newVaga.salario = detalhe.ToArray()[i];
                newVaga.url = "https://www.trabalhabrasil.com.br/" + link.ToArray()[i];

                _lista.Add(newVaga);

            }
            return _lista;
             

        }


    }
}
;