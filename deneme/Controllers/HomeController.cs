using deneme.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace deneme.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            Uri url = new Uri("https://cargonline.samer.com/ferry/StMezzi6_2.idc?transport=METIN+AKDURAK+LOJ+HIZ+ULU+TAS&Data1=2010-01-01&Data2=2022-01-22");//Tarihleri ve şirket ismi verilmiş arama
            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("ulusoy", "SamWeb.18");//Site yetki istemektedir burada siteye girebilmemiz için kullanıcı ad ve soyadını gönderiyoruz. (Önemli)Authorization işlemi
            string html=client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            var satirlar = dokuman.DocumentNode.Descendants("table").ToList()[1].Descendants("tr").ToList();
            satirlar.RemoveRange(0, 2);//Index out of range hatası için 0.2yi siliyoruz çünkü bu kısım grid yapısını bozuyor
            List<Liste> kargoListesi = new List<Liste>();
            //bir foreach yazarak gelen bütün inputları dönüyoruz ve yeni oluşturduğumuz listesinin içerisine aktarıyoruz
            foreach (var satir in satirlar)
            {
                var columns = satir.Descendants("td").ToList();
                kargoListesi.Add(new Liste(columns));
            }
            //yeni oluşturduğumuz listenin içerisine gelen inputları kaydettikten sonra viewde görebilmek için modeldeki listeye aktarıyoruz. Modeldeki liste dolduktan sonra view da gösterebiliriz çünkü.
            Model model = new Model
            {
                KargoListesi = kargoListesi,
            };
            //Sayfaya modeli döndürüyoruz
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}