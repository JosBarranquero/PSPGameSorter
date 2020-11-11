using System;
using System.Collections.Generic;
using System.IO;

namespace PSPGameSorter
{
    class Utils
    {
        private static Utils _myself;

        private string _curDrive;
        private List<Game> _driveGames; // games in my drive

        public static Utils Instance
        {
            get
            {
                if (_myself == null)
                {
                    _myself = new Utils();
                }

                return _myself;
            }
        }
        public string CurrentDrive
        {
            get { return _curDrive; }
            set { _curDrive = value; }
        }

        private Utils() { } // Making the class constructor private

        public bool CheckFolders()
        {
            string isoFolder = _curDrive + Strings.PSP_ISO;
            string gameFolder = _curDrive + Strings.PSP_GAME;

            return (Directory.Exists(isoFolder) && Directory.Exists(gameFolder));
        }

        public string[] RetrieveGames()
        {
            _driveGames = new List<Game>();

            string isoFolder = _curDrive + Strings.PSP_ISO;
            string gameFolder = _curDrive + Strings.PSP_GAME;

            string[] isoResults = Directory.GetFiles(isoFolder, "*.?so");
            string[] gameResults = Directory.GetDirectories(gameFolder);

            if (isoResults.Length == 0 && gameResults.Length == 0)
            {
                throw new MissingGamesException();
            }

            foreach (string gamePath in isoResults)
            {
                string name = Path.GetFileNameWithoutExtension(gamePath);
                _driveGames.Add(new Game(name, gamePath));
            }

            foreach (string gamePath in gameResults)
            {
                string name = new DirectoryInfo(gamePath).Name;
                _driveGames.Add(new Game(name, gamePath + string.Format(@"\{0}", Strings.PSP_EBOOT)));
            }

            _driveGames.Sort();     // We first sort alphabetically

            string[] gameList = new string[_driveGames.Count];
            for (int i = 0; i < _driveGames.Count; ++i)
            {
                gameList[i] = _driveGames[i].Name;
            }

            return gameList;
        }

        /**
         * Move the game in the list
         */
        public void MoveGame(int position, int direction)
        {
            Game aux = _driveGames[position];
            _driveGames.RemoveAt(position);
            _driveGames.Insert(position + direction, aux);
        }

        public void Sort()
        {
            _driveGames.Reverse();

            foreach (Game game in _driveGames)
            {
                try
                { 
                    File.SetCreationTime(game.Path, DateTime.Now);
                    File.SetLastWriteTime(game.Path, DateTime.Now);
                } catch (Exception e) 
                { 
                    _driveGames.Reverse();
                    throw;
                }
            }
        }
    }
}
