using HtmlAgilityPack;

namespace deneme.Models
{
    public class Liste
    {
        //Listenin değerleri
        public string dateValue;
        public string vesselValue;
        public string voyValue;
        public string fromValue;
        public string toValue;
        public string arrivalValue;
        public string truckValue;
        public string trailerValue;
        public string driverValue;
        public string blValue;
        //Siteden çektiğimiz değerleri controllerden gönderdiğimiz parametre ile alıp hepsini teker teker aktarır
        public Liste(List<HtmlNode> columns)
        {
            dateValue = columns[0].FirstChild.FirstChild?.InnerText; 
            vesselValue = columns[1].FirstChild.FirstChild?.InnerText;
            voyValue = columns[2].FirstChild.FirstChild?.InnerText;
            fromValue = columns[3].FirstChild.FirstChild?.InnerText;
            toValue = columns[4].FirstChild.FirstChild?.InnerText;
            arrivalValue = columns[5].FirstChild.FirstChild?.InnerText;
            truckValue = columns[6].FirstChild.FirstChild?.InnerText;
            trailerValue = columns[7].FirstChild.FirstChild?.InnerText;
            driverValue = columns[8].FirstChild.FirstChild?.InnerText;
            blValue = columns[9].FirstChild.FirstChild?.InnerText;
        }
    }
}
