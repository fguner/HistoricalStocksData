using System.Net;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using RestSharp;

namespace HistoricalStocksData
{
    class Program
    {
        #region Properties
        static List<String> hisseler;
        static IMongoDatabase mongoDatabase;
        static IMongoCollection<BsonDocument> mongoCollection;
        static List<BsonDocument> allData;

        static string urlApi = "https://www.isyatirim.com.tr/_layouts/15/Isyatirim.Website/Common/Data.aspx/HisseTekil";
        #endregion

        static void Main(string[] args)
        {
            #region Preparing
            hisseler = new List<String>();
            const String connectionString = "mongodb+srv://fguner:fguner123@dividendandcapital.zz0nh.mongodb.net/DividendAndCapital?retryWrites=true&w=majority";
            MongoClient client = new MongoClient(connectionString);
            mongoDatabase = client.GetDatabase("DividendAndCapital");
            mongoCollection = mongoDatabase.GetCollection<BsonDocument>("HistoricalData");
            #endregion Preparing

            #region Hisseler listeye ekleniyor.
            hisseler.Add("BRKSN");
            hisseler.Add("BRMEN");
            hisseler.Add("BRSAN");
            hisseler.Add("BRYAT");
            hisseler.Add("BSOKE");
            hisseler.Add("BTCIM");
            hisseler.Add("BUCIM");
            hisseler.Add("BURCE");
            hisseler.Add("BURVA");
            hisseler.Add("CANTE");
            hisseler.Add("CASA");
            hisseler.Add("CCOLA");
            hisseler.Add("CELHA");
            hisseler.Add("CEMAS");
            hisseler.Add("CEMTS");
            hisseler.Add("CEOEM");
            hisseler.Add("CIMSA");
            hisseler.Add("CLEBI");
            hisseler.Add("CMBTN");
            hisseler.Add("CMENT");
            hisseler.Add("COSMO");
            hisseler.Add("CRDFA");
            hisseler.Add("CRFSA");
            hisseler.Add("CUSAN");
            hisseler.Add("DAGHL");
            hisseler.Add("DAGI");
            hisseler.Add("DARDL");
            hisseler.Add("DENGE");
            hisseler.Add("DERHL");
            hisseler.Add("DERIM");
            hisseler.Add("DESA");
            hisseler.Add("DESPC");
            hisseler.Add("DEVA");
            hisseler.Add("DGATE");
            hisseler.Add("DGGYO");
            hisseler.Add("DGKLB");
            hisseler.Add("DIRIT");
            hisseler.Add("DITAS");
            hisseler.Add("DMSAS");
            hisseler.Add("DNISI");
            hisseler.Add("DOAS");
            hisseler.Add("DOBUR");
            hisseler.Add("DOCO");
            hisseler.Add("DOGUB");
            hisseler.Add("DOHOL");
            hisseler.Add("DOKTA");
            hisseler.Add("DURDO");
            hisseler.Add("DYOBY");
            hisseler.Add("DZGYO");
            hisseler.Add("ECILC");
            hisseler.Add("ECZYT");
            hisseler.Add("EDIP");
            hisseler.Add("EGEEN");
            hisseler.Add("EGGUB");
            hisseler.Add("EGPRO");
            hisseler.Add("EGSER");
            hisseler.Add("EKGYO");
            hisseler.Add("EKIZ");
            hisseler.Add("EMKEL");
            hisseler.Add("EMNIS");
            hisseler.Add("ENJSA");
            hisseler.Add("ENKAI");
            hisseler.Add("EPLAS");
            hisseler.Add("ERBOS");
            hisseler.Add("EREGL");
            hisseler.Add("ERSU");
            hisseler.Add("ESCOM");
            hisseler.Add("ESEN");
            hisseler.Add("ETILR");
            hisseler.Add("ETYAT");
            hisseler.Add("EUHOL");
            hisseler.Add("EUKYO");
            hisseler.Add("EUYO");
            hisseler.Add("FADE");
            hisseler.Add("FENER");
            hisseler.Add("FLAP");
            hisseler.Add("FMIZP");
            hisseler.Add("FONET");
            hisseler.Add("FORMT");
            hisseler.Add("FRIGO");
            hisseler.Add("FROTO");
            hisseler.Add("GARAN");
            hisseler.Add("GARFA");
            hisseler.Add("GEDIK");
            hisseler.Add("GEDZA");
            hisseler.Add("GENTS");
            hisseler.Add("GEREL");
            hisseler.Add("GLBMD");
            hisseler.Add("GLRYH");
            hisseler.Add("GLYHO");
            hisseler.Add("GOLTS");
            hisseler.Add("GOODY");
            hisseler.Add("GOZDE");
            hisseler.Add("GRNYO");
            hisseler.Add("GSDDE");
            hisseler.Add("GSDHO");
            hisseler.Add("GSRAY");
            hisseler.Add("GUBRF");
            hisseler.Add("GWIND");
            hisseler.Add("HALKB");
            hisseler.Add("HATEK");
            hisseler.Add("HDFGS");
            hisseler.Add("HEKTS");
            hisseler.Add("HLGYO");
            hisseler.Add("HUBVC");
            hisseler.Add("HURGZ");
            hisseler.Add("ICBCT");
            hisseler.Add("IDEAS");
            hisseler.Add("IDGYO");
            hisseler.Add("IEYHO");
            hisseler.Add("IHEVA");
            hisseler.Add("IHGZT");
            hisseler.Add("IHLAS");
            hisseler.Add("IHLGM");
            hisseler.Add("IHYAY");
            hisseler.Add("INDES");
            hisseler.Add("INFO");
            hisseler.Add("INTEM");
            hisseler.Add("INVEO");
            hisseler.Add("IPEKE");
            hisseler.Add("ISBIR");
            hisseler.Add("ISBTR");
            hisseler.Add("ISCTR");
            hisseler.Add("ISDMR");
            hisseler.Add("ISFIN");
            hisseler.Add("ISGSY");
            hisseler.Add("ISGYO");
            hisseler.Add("ISKPL");
            hisseler.Add("ISMEN");
            hisseler.Add("ISYAT");
            hisseler.Add("ITTFH");
            hisseler.Add("IZFAS");
            hisseler.Add("IZMDC");
            hisseler.Add("IZTAR");
            hisseler.Add("JANTS");
            hisseler.Add("KAPLM");
            hisseler.Add("KAREL");
            hisseler.Add("KARSN");
            hisseler.Add("KARTN");
            hisseler.Add("KATMR");
            hisseler.Add("KCHOL");
            hisseler.Add("KENT");
            hisseler.Add("KERVN");
            hisseler.Add("KERVT");
            hisseler.Add("KFEIN");
            hisseler.Add("KLGYO");
            hisseler.Add("KLMSN");
            hisseler.Add("KLNMA");
            hisseler.Add("KNFRT");
            hisseler.Add("KONTR");
            hisseler.Add("KONYA");
            hisseler.Add("KORDS");
            hisseler.Add("KOZAA");
            hisseler.Add("KOZAL");
            hisseler.Add("KRDMA");
            hisseler.Add("KRDMB");
            hisseler.Add("KRDMD");
            hisseler.Add("KRGYO");
            hisseler.Add("KRONT");
            hisseler.Add("KRSTL");
            hisseler.Add("KRTEK");
            hisseler.Add("KRVGD");
            hisseler.Add("KSTUR");
            hisseler.Add("KUTPO");
            hisseler.Add("KUYAS");
            hisseler.Add("LIDFA");
            hisseler.Add("LINK");
            hisseler.Add("LKMNH");
            hisseler.Add("LOGO");
            hisseler.Add("LUKSK");
            hisseler.Add("MAALT");
            hisseler.Add("MAKTK");
            hisseler.Add("MARKA");
            hisseler.Add("MARTI");
            hisseler.Add("MAVI");
            hisseler.Add("MEGAP");
            hisseler.Add("MEPET");
            hisseler.Add("MERIT");
            hisseler.Add("MERKO");
            hisseler.Add("METRO");
            hisseler.Add("METUR");
            hisseler.Add("MGROS");
            hisseler.Add("MIPAZ");
            hisseler.Add("MMCAS");
            hisseler.Add("MNDRS");
            hisseler.Add("MPARK");
            hisseler.Add("MRGYO");
            hisseler.Add("MRSHL");
            hisseler.Add("MSGYO");
            hisseler.Add("MTRKS");
            hisseler.Add("MTRYO");
            hisseler.Add("MZHLD");
            hisseler.Add("NATEN");
            hisseler.Add("NETAS");
            hisseler.Add("NIBAS");
            hisseler.Add("NTGAZ");
            hisseler.Add("NTHOL");
            hisseler.Add("NUGYO");
            hisseler.Add("NUHCM");
            hisseler.Add("ODAS");
            hisseler.Add("OLMIP");
            hisseler.Add("ORGE");
            hisseler.Add("ORMA");
            hisseler.Add("OSMEN");
            hisseler.Add("OSTIM");
            hisseler.Add("OTKAR");
            hisseler.Add("OYAKC");
            hisseler.Add("OYAYO");
            hisseler.Add("OYLUM");
            hisseler.Add("OZBAL");
            hisseler.Add("OZGYO");
            hisseler.Add("OZKGY");
            hisseler.Add("OZRDN");
            hisseler.Add("PAGYO");
            hisseler.Add("PAMEL");
            hisseler.Add("PAPIL");
            hisseler.Add("PARSN");
            hisseler.Add("PEGYO");
            hisseler.Add("PEKGY");
            hisseler.Add("PENGD");
            hisseler.Add("PETKM");
            hisseler.Add("PETUN");
            hisseler.Add("PGSUS");
            hisseler.Add("PINSU");
            hisseler.Add("PKART");
            hisseler.Add("PKENT");
            hisseler.Add("PNSUT");
            hisseler.Add("POLHO");
            hisseler.Add("POLTK");
            hisseler.Add("PRKAB");
            hisseler.Add("PRKME");
            hisseler.Add("PRZMA");
            hisseler.Add("PSDTC");
            hisseler.Add("QNBFB");
            hisseler.Add("QNBFL");
            hisseler.Add("QUAGR");
            hisseler.Add("RALYH");
            hisseler.Add("RAYSG");
            hisseler.Add("RHEAG");
            hisseler.Add("RODRG");
            hisseler.Add("ROYAL");
            hisseler.Add("RTALB");
            hisseler.Add("RYGYO");
            hisseler.Add("RYSAS");
            hisseler.Add("SAFKR");
            hisseler.Add("SAHOL");
            hisseler.Add("SAMAT");
            hisseler.Add("SANEL");
            hisseler.Add("SANFM");
            hisseler.Add("SANKO");
            hisseler.Add("SARKY");
            hisseler.Add("SASA");
            hisseler.Add("SAYAS");
            hisseler.Add("SEKFK");
            hisseler.Add("SEKUR");
            hisseler.Add("SELEC");
            hisseler.Add("SELGD");
            hisseler.Add("SERVE");
            hisseler.Add("SEYKM");
            hisseler.Add("SILVR");
            hisseler.Add("SISE");
            hisseler.Add("SKBNK");
            hisseler.Add("SKTAS");
            hisseler.Add("SMART");
            hisseler.Add("SNGYO");
            hisseler.Add("SNKRN");
            hisseler.Add("SNPAM");
            hisseler.Add("SODSN");
            hisseler.Add("SOKM");
            hisseler.Add("SONME");
            hisseler.Add("SRVGY");
            hisseler.Add("SUMAS");
            hisseler.Add("TACTR");
            hisseler.Add("TATGD");
            hisseler.Add("TAVHL");
            hisseler.Add("TBORG");
            hisseler.Add("TCELL");
            hisseler.Add("TDGYO");
            hisseler.Add("TEKTU");
            hisseler.Add("TGSAS");
            hisseler.Add("THYAO");
            hisseler.Add("TIRE");
            hisseler.Add("TKFEN");
            hisseler.Add("TKNSA");
            hisseler.Add("TKURU");
            hisseler.Add("TLMAN");
            hisseler.Add("TMPOL");
            hisseler.Add("TMSN");
            hisseler.Add("TOASO");
            hisseler.Add("TRCAS");
            hisseler.Add("TRGYO");
            hisseler.Add("TRILC");
            hisseler.Add("TSGYO");
            hisseler.Add("TSKB");
            hisseler.Add("TSPOR");
            hisseler.Add("TTKOM");
            hisseler.Add("TTRAK");
            hisseler.Add("TUCLK");
            hisseler.Add("TUKAS");
            hisseler.Add("TUPRS");
            hisseler.Add("TUREX");
            hisseler.Add("TURGG");
            hisseler.Add("TURSG");
            hisseler.Add("UFUK");
            hisseler.Add("ULAS");
            hisseler.Add("ULKER");
            hisseler.Add("ULUSE");
            hisseler.Add("ULUUN");
            hisseler.Add("UMPAS");
            hisseler.Add("USAK");
            hisseler.Add("UTPYA");
            hisseler.Add("UZERB");
            hisseler.Add("VAKBN");
            hisseler.Add("VAKFN");
            hisseler.Add("VAKKO");
            hisseler.Add("VANGD");
            hisseler.Add("VERTU");
            hisseler.Add("VERUS");
            hisseler.Add("VESBE");
            hisseler.Add("VESTL");
            hisseler.Add("VKFYO");
            hisseler.Add("VKGYO");
            hisseler.Add("VKING");
            hisseler.Add("YAPRK");
            hisseler.Add("YATAS");
            hisseler.Add("YAYLA");
            hisseler.Add("YBTAS");
            hisseler.Add("YESIL");
            hisseler.Add("YGGYO");
            hisseler.Add("YGYO");
            hisseler.Add("YKBNK");
            hisseler.Add("YKGYO");
            hisseler.Add("YKSLN");
            hisseler.Add("YONGA");
            hisseler.Add("YUNSA");
            hisseler.Add("YYAPI");
            hisseler.Add("ZOREN");
            #endregion

            Thread thread1 = new Thread(new ThreadStart(partAdd1));
            Thread thread2 = new Thread(new ThreadStart(partAdd2));
            Thread thread3 = new Thread(new ThreadStart(partAdd3));
            Thread thread4 = new Thread(new ThreadStart(partAdd4));
            Thread thread5 = new Thread(new ThreadStart(partAdd5));
            Thread thread6 = new Thread(new ThreadStart(partAdd6));
            Thread thread7 = new Thread(new ThreadStart(partAdd7));
            Thread thread8 = new Thread(new ThreadStart(partAdd8));
            Thread thread9 = new Thread(new ThreadStart(partAdd9));
            Thread thread10 = new Thread(new ThreadStart(partAdd10));
            Thread thread11 = new Thread(new ThreadStart(partAdd11));
            Thread thread12 = new Thread(new ThreadStart(partAdd12));
            Thread thread13 = new Thread(new ThreadStart(partAdd13));
            Thread thread14 = new Thread(new ThreadStart(partAdd14));
            Thread thread15 = new Thread(new ThreadStart(partAdd15));
            Thread thread16 = new Thread(new ThreadStart(partAdd16));

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            thread6.Start();
            thread7.Start();
            thread8.Start();
            thread9.Start();
            thread10.Start();
            thread11.Start();
            thread12.Start();
            thread13.Start();
            thread14.Start();
            thread15.Start();
            thread16.Start();
        }

        static void DeleteSameData()
        {
            /*foreach (var hisse in hisseler)
            {
                var filterHisse = Builders<HistoricalData>.Filter.Eq("Code", hisse);
                List<HistoricalData> allData = mongoCollection.Find<HistoricalData>(filterHisse).ToList<HistoricalData>();

                var sameDatas = allData.GroupBy(x => x.Date).Select(x => x.First()).ToList();

                List<ObjectId> dataIds = sameDatas.Select(x=>x._id).ToList();
                var filter = Builders<HistoricalData>.Filter.In("_id", dataIds);
                List<HistoricalData> allData1 = mongoCollection.Find<HistoricalData>(filterHisse).ToList<HistoricalData>();

                System.Console.WriteLine(hisse +" hissesi için işlem yapılıyor");    
                if(dataIds.Count>0){
                    mongoCollection.DeleteMany(filter);
                }
                System.Console.WriteLine(String.Format("{0} hissesinden {1} adet çoklanmış veri silindi",hisse, sameDatas.Count));
            }*/
        }

        public static void ControlAndAdd(List<HistoricalDataType> responseData)
        {

            foreach (HistoricalDataType item in responseData)
            {
                Console.WriteLine(item.HGDG_HS_KODU + " --> " + item.HGDG_TARIH + " --> " + item.HGDG_KAPANIS);

                mongoCollection.InsertOne(new BsonDocument
                     {
                         {"Code", item.HGDG_HS_KODU},
                         {"Date", item.HGDG_TARIH},
                         {"Amount", item.HGDG_KAPANIS}
                     });
            }
        }

        static void partAdd1()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 0; i < 21; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd2()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 21; i < 42; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd3()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 42; i < 63; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd4()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 63; i < 84; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd5()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 84; i < 105; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd6()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 105; i < 126; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd7()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 126; i < 147; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd8()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 147; i < 168; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd9()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 168; i < 189; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd10()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 189; i < 210; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd11()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 210; i < 231; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd12()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 231; i < 252; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd13()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 252; i < 273; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd14()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 273; i < 294; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd15()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 294; i < 315; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }
        static void partAdd16()
        {

            #region API data prepare
            HistoricalDataTypeParameter HistoricalParameter = new HistoricalDataTypeParameter()
            {
                hisse = "",
                enddate = DateTime.Now.AddDays(-1),
                startdate = DateTime.Now.AddYears(-27)
            };
            #endregion API data prepare

            for (int i = 315; i < 337; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("?hisse=");
                sb.Append(hisseler[i]);
                sb.Append("&startdate=");
                sb.Append(HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                sb.Append("&enddate=");
                sb.Append(HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));

                try
                {
                    var client1 = new RestClient(urlApi);
                    var request = new RestRequest("", Method.Get);
                    request.AddParameter("hisse", hisseler[i]);
                    request.AddParameter("startdate", HistoricalParameter.startdate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    request.AddParameter("enddate", HistoricalParameter.enddate.ToString("dd-MM-yyyy").Replace("\"", ""));
                    RestResponse response = client1.Execute(request);
                    response.Content = response.Content.Replace("\\", "");
                    int index = response.Content.IndexOf("[");
                    string parserObject = response.Content.Substring(index, response.Content.Length - (index + 1));

                    var responseAPI = JsonConvert.DeserializeObject<List<HistoricalDataType>>(parserObject, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    ControlAndAdd(responseAPI);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(hisseler[i] + " hissesi için veriler düzgün işlenmedi.");
                    continue;
                }

            }
        }

    }
}