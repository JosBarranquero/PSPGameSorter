using System;

namespace PSPGameSorter
{
    class MissingFoldersException : Exception
    {
        public MissingFoldersException()
            : base(Strings.NO_FOLDER_MESSAGE)
        { }
    }
}
