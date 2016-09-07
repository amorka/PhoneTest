using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public string LoadStartPage(string url) {
            string page=String.Empty;
            base_page_url= url;
            HttpWebRequest wreq = (HttpWebRequest)WebRequest.Create(url);
            wreq.Method="GET";
            wreq.ContentType="text/html; charset=utf-8";

            HttpWebResponse resp = (HttpWebResponse)wreq.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.Default);
            page = sr.ReadToEnd();
            sr.Dispose();
            resp.Close();
            return page;
        }
    }
}
