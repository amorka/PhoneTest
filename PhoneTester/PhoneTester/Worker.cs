using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneTester
{
    class Worker
    {
        public delegate void dlgUpdateCounter();
        public event dlgUpdateCounter UpdateCounter;

        private int start_position = -1;

        private static Worker _instance;
        public static Worker Instance {
            get {
                if (_instance == null) _instance = new Worker();
                return _instance;
            }
        }

        private Worker() {
            start_position = DBAdapter.Instance.GetLastPositionFromFile();
        }

        public void StartReadFile(string file_path) {
            status.instance = new status();
            status.instance.Show();
            Task t = new Task(() => {
                try
                {
                    
                    StreamReader sr = new StreamReader(file_path);
                    string phone = "";
                    while ((phone = sr.ReadLine()) != null)
                    {
                        if (DBAdapter.Instance.GetPhone(phone) == null)
                        {
                            string page = Requester.Instance.LoadStartPage("http://www.kody.su/check-tel#text",phone);
                            //string Patern = @"Страна:\s.\w{6}.(\w+)..\w{6}...\w{2}..\w{2}.+\[(.+)\]";
                            string Patern = @"Страна:\s<strong>([а-яА-Я]+)<\/strong>";
                            Regex reg = new Regex(Patern, RegexOptions.IgnoreCase);
                            Match match = reg.Match(page);
                            if (match.Groups[1].Value != String.Empty)
                            {
                                DBAdapter.Instance.AddPhone(new PhoneInfo() { phone = phone, country = match.Groups[1].Value });
                            }
                            Thread.Sleep(200);
                        }
                        status.instance.Invoke(status.instance.dlgFunc);
                    }
                }
                catch (Exception ex) {
                    
                }
            });
            t.Start();
        }
    }
}
