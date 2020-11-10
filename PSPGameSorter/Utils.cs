using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSPGameSorter
{
    class Utils
    {
        private static Utils myself;

        private string curDrive;

        public static Utils Instance
        {
            get
            {
                if (myself == null)
                {
                    myself = new Utils();
                }

                return myself;
            }
        }
        public string CurrentDrive
        {
            get { return curDrive; }
            set { curDrive = value; }
        }

        private Utils() { } // Making the class constructor private
    }
}
