using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace PhoneTester
{
    class Requester
    {
        private static Requester _instance;

        public static Requester Instance {
            get {
                if (_instance == null) {
                    _instance = new Requester();
                }
                return _instance;
            }
        }

        private Requester() { }

        string base_page_url;
        public string LoadStartPage(string url,string number) {
            string page=String.Empty;
            base_page_url= url;
            using (var wreq = new HttpRequest()) {
                //var reqParam = new RequestParams();
                //wreq.UserAgent = Http.ChromeUserAgent();
                //wreq.AddHeader(HttpHeader.ContentType.ToString(), "application/x-www-form-urlencoded");
                //wreq.AddHeader(HttpHeader.Accept.ToString(), "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                //wreq.AddHeader(HttpHeader.Referer.ToString(), "http://www.kody.su/check-tel");
                //wreq.AddHeader(HttpHeader.ContentLanguage.ToString(), "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3");
                //reqParam["number"]= number;
                //page = wreq.Post(url, reqParam).ToString();

                var reqParam = new RequestParams();
                wreq.UserAgent = Http.ChromeUserAgent();

                wreq.AddHeader(HttpHeader.ContentType.ToString(), "application/x-www-form-urlencoded; charset=UTF-8");
                wreq.AddHeader(HttpHeader.Accept.ToString(), "*/*");
                wreq.AddHeader(HttpHeader.Referer.ToString(), "https://gsm-inform.ru/api/info/");
                wreq.AddHeader(HttpHeader.ContentLanguage.ToString(), "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3");

                reqParam["phone"] = number;
                reqParam["get-phone-info"] ="on";
                //byte[] resp = wreq.Post("https://gsm-inform.ru/api/info/", reqParam).ToString();
                dynamic obj_page =JsonConvert.DeserializeObject(wreq.Post("https://gsm-inform.ru/api/info/", reqParam).ToString());
                page = "Страна: <strong>"+ obj_page.country+ "</ strong >";
            }
            return page;
        }
    }
}
