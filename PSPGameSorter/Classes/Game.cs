using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSPGameSorter
{
    class Game : IComparable
    {
        private string _name;
        private string _path;

        public Game()
        {
            _name = null;
            _path = null;
        }

        public Game(string name, string path)
        {
            _name = name;
            _path = path;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Game other = obj as Game;
            if (other != null)
                return this._name.CompareTo(other._name);
            else
                throw new ArgumentException();
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
