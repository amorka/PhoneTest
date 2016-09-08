using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        }

    }
}
