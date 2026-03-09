namespace CyberSec
{
    public static class Constants
    {
        // Scene Names
        public const string SCENE_MAIN_MENU = "MainMenu";
        public const string SCENE_LEVEL_SELECT = "LevelSelect";
        public const string SCENE_LOADING = "LoadingScreen";
        public const string SCENE_GAME_OVER = "GameOver";

        // Level Scene Names
        public const string LEVEL_01 = "Level01_Phishing";
        public const string LEVEL_02 = "Level02_PasswordSecurity";
        public const string LEVEL_03 = "Level03_SocialEngineering";
        public const string LEVEL_04 = "Level04_MalwareDownload";
        public const string LEVEL_05 = "Level05_PublicWiFi";
        public const string LEVEL_06 = "Level06_Ransomware";
        public const string LEVEL_07 = "Level07_TwoFactorAuth";
        public const string LEVEL_08 = "Level08_SafeBrowsing";
        public const string LEVEL_09 = "Level09_DataPrivacy";
        public const string LEVEL_10 = "Level10_FinalAttack";

        // Tags
        public const string TAG_PLAYER = "Player";
        public const string TAG_NPC = "NPC";
        public const string TAG_INTERACTABLE = "Interactable";

        // Event Names
        public const string EVENT_SCORE_CHANGED = "ScoreChanged";
        public const string EVENT_LEVEL_COMPLETE = "LevelComplete";
        public const string EVENT_LEVEL_FAILED = "LevelFailed";
        public const string EVENT_DIALOG_STARTED = "DialogStarted";
        public const string EVENT_DIALOG_ENDED = "DialogEnded";
        public const string EVENT_LOADING_STARTED = "LoadingStarted";
        public const string EVENT_LOADING_COMPLETE = "LoadingComplete";

        // Score Values
        public const int SCORE_CORRECT_ANSWER = 20;
        public const int SCORE_WRONG_ANSWER = -10;
        public const int SCORE_BONUS = 50;
        public const int SCORE_TIME_BONUS = 10;
    }
}
