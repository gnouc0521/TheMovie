using Movie.Debugging;

namespace Movie
{
    public class MovieConsts
    {
        public const string LocalizationSourceName = "Movie";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "2c2a54c2895b439184446bad2c078696";
    }
}
