﻿namespace PSPGameSorter
{
    class Strings
    {
        // PSP folders
        public static string PSP_ISO = "ISO\\";
        public static string PSP_GAME = "PSP\\GAME\\";
        public static string PSP_EXT = "*.?so"; // extensions iso and cso
        public static string PSP_EBOOT = "EBOOT.PBP"; 

        // Errors
        public static string NO_DRIVES_MESSAGE = "How are you even running Windows?\nThere's not even a single active drive...\nI'm literally crying and shaking right now";
        public static string NO_FOLDER_MESSAGE = string.Format("This drive may not be a PSP card. The '{0}' and '{1}' directories are missing", PSP_ISO, PSP_GAME);
        public static string NO_FOLDER_TITLE = "Missing folders";
        public static string NO_GAMES_MESSAGE = "Games could not be found in the expected folders";
        public static string NO_GAMES_TITLE = "Missing games";
        public static string ERROR = "Unexpected error";
    }
}
