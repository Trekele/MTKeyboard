using System.Drawing;
namespace MTKeyboardPlugin
{
    class InfoUpdate
    {
        public static Plugin plugin { get; set; }
        public string feature { get; set; }
        public Info info { get; set; }
    }

    class Info
    {
        public PlayersInfo playersInfo { get; set; }
        public TeamsInfo teamsInfo { get; set; }
        public TeamsScore teamsScore { get; set; }
        public Me me { get; set; }
        public MatchState matchState { get; set; }
        public MatchInfo matchInfo { get; set; }
    }

    class PlayersInfo
    {
        public string player0 { get; set; }
        public string player1 { get; set; }
        public string player2 { get; set; }
        public string player3 { get; set; }
        public string player4 { get; set; }
        public string player5 { get; set; }
        public string player6 { get; set; }
        public string player7 { get; set; }
        public string player8 { get; set; }
        public string player9 { get; set; }
    }

    class TeamsInfo
    {
        public string team1 { get; set; }
        public string team2 { get; set; }
    }

    class TeamsScore
    {
        public int? team1_score { get; set; }
        public int? team2_score { get; set; }
    }

    class Me
    {
        public string steamId { get; set; }
        public string name { get; set; }
        private int? _goals;
        public int? goals 
        { 
            get
            {
                return _goals;
            }
            set
            {
                RocketLeagueLib.SetGoals(Color.Red, value.ToString());
                _goals = value;
            }
        }
        public string score { get; set; }
        public string deaths { get; set; }
        public string team { get; set; }
        public string team_score { get; set; }
    }

    class MatchState
    {
        public bool? started { get; set; }
        public bool? ended { get; set; }

    }

    class MatchInfo
    {
        public string matchType { get; set; }
        public bool? ranked { get; set; }
        public int? maxPlayers { get; set; }
        public string gameMode { get; set; }
        
        private string _gameState;
        public string gameState 
        { 
            get {return _gameState;}
            set
            {
                InfoUpdate.plugin.print("Setting me goals");
                _gameState = value;
            } 
        }
        public string gameType { get; set; }
    }
}