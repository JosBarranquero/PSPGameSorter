using System;

namespace PSPGameSorter
{
    [Serializable]
    class MissingGamesException : Exception
    {
        public MissingGamesException() 
            : base(Strings.NO_GAMES_MESSAGE)
        { }
    }
}
