using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneTester
{
    class Worker
    {
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
            StreamReader sr = new StreamReader(file_path);
            string phone = "";
            while ((phone = sr.ReadLine())!= null) {
                string page =Requester.Instance.LoadStartPage("http://www.kody.su/check-tel?number=" + phone + "#text");
                string Patern = @"Страна:\s.\w{6}.(\w+)..\w{6}...\w{2}..\w{2}.+\[(.+)\]";
                Regex reg = new Regex(Patern, RegexOptions.IgnoreCase);
                Match match = reg.Match(page);
                DBAdapter.Instance.AddPhone(new PhoneInfo() { phone=phone,country= match.Groups[1].Value });
            }
        }

    }
}
