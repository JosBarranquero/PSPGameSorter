using System;
using System.Collections.Generic;
using System.IO;

namespace PSPGameSorter
{
    /// <summary>
    /// This class is Singleton because I hate myself
    /// </summary>
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

        /// <summary>
        /// Check for presence of ISO/ and PSP/GAME/ folders in the drive
        /// TODO, remove bool return, make it throw an exception, for sexual reasons
        /// </summary>
        /// <returns></returns>
        public bool CheckFolders()
        {
            string isoFolder = _curDrive + Strings.PSP_ISO;
            string gameFolder = _curDrive + Strings.PSP_GAME;

            return (Directory.Exists(isoFolder) && Directory.Exists(gameFolder));
        }

        /// <summary>
        /// Retrieve the games in the drive, if they exist.
        /// If they don't MissingGamesException is thrown.
        /// If they do, they are load into _driveGames as Game class objects, and the names are returned in a string[]
        /// </summary>
        /// <returns>Names list of the games in the drive</returns>
        /// <exception cref="MissingGamesException">No games in the drive</exception>
        public string[] RetrieveGames()
        {
            _driveGames = new List<Game>();     // New list

            string isoFolder = _curDrive + Strings.PSP_ISO;
            string gameFolder = _curDrive + Strings.PSP_GAME;

            string[] isoResults = Directory.GetFiles(isoFolder, Strings.PSP_EXT);   // Look for .iso and .cso files
            string[] gameResults = Directory.GetDirectories(gameFolder);    // Look for folders in game directory

            if (isoResults.Length == 0 && gameResults.Length == 0)  // No games
                throw new MissingGamesException();

            foreach (string gamePath in isoResults)
            {
                string name = Path.GetFileNameWithoutExtension(gamePath);
                _driveGames.Add(new Game(name, gamePath));      // We store the game in the list
            }

            foreach (string gamePath in gameResults)
            {
                string name = new DirectoryInfo(gamePath).Name;
                // The path will redirect to the EBOOT.PBP file inside the directory
                _driveGames.Add(new Game(name, string.Format(@"{0}\{1}", gamePath, Strings.PSP_EBOOT)));
            }

            _driveGames.Sort();     // We first sort alphabetically

            string[] gameList = new string[_driveGames.Count];  // The list of games to be shown on screen
            for (int i = 0; i < _driveGames.Count; ++i)
            {
                gameList[i] = _driveGames[i].ToString();
            }

            return gameList;
        }

        /// <summary>
        /// Move the game in the list
        /// </summary>
        /// <param name="position">Position of the element to be moved</param>
        /// <param name="direction">Direction, -1 is up, 1 is down</param>
        /// <exception cref="ArgumentOutOfRangeException">Index validation is not made in this method</exception>
        public void MoveGame(int position, int direction)
        {
            if (position >= _driveGames.Count || position + direction > _driveGames.Count)
                throw new ArgumentOutOfRangeException();

            Game aux = _driveGames[position];
            _driveGames.RemoveAt(position);
            _driveGames.Insert(position + direction, aux);
        }

        /// <summary>
        /// Sorting in PSP system software is done by checking the creation time by default.
        /// We cycle through the items in _driveGames and set the new CreationTime
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="IOException"></exception>
        public void Sort()
        {
            // Games list has to be reversed, as the ones in the bottom must have the oldest CreationTime
            _driveGames.Reverse();

            foreach (Game game in _driveGames)
            {
                try
                { 
                    File.SetCreationTime(game.Path, DateTime.Now);

                    // Should not be necessary, but just so we don't have files with newer CreationTime than LastWriteTime
                    File.SetLastWriteTime(game.Path, DateTime.Now);
                } catch (Exception e) 
                { 
                    _driveGames.Reverse();
                    throw;
                }
            }

            // We undo the reversing
            _driveGames.Reverse();
        }
    }
}
