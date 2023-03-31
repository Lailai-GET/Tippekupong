namespace Tippekupong
{
    internal class Match
    {
        private string _homeTeam;
        private string _awayTeam;
        private int _homeGoals;
        private int _awayGoals;
        private string _result;

        public Match(string homeName, string awayName)
        {
            _homeTeam = homeName;
            _awayTeam = awayName;
        }
        
        public void AddGoal(string scorer)
        {
            switch (scorer)
            {
                case "H":
                    _homeGoals++;
                    CurrentScore(_homeTeam);
                    break;
                case "B":
                    CurrentScore(_awayTeam);
                    _awayGoals++;
                    break;
                default:
                    CurrentScore("ingen");
                    return;
            }
        }

        public void CurrentScore(string scorer)
        {
            var goalText = scorer != "ingen" ? " GÅÅÅLL!" : "...";
            Console.WriteLine(
                $"{scorer} skåra{goalText} Stillingen er: \r\n {_homeTeam}(H) {_homeGoals} : {_awayGoals} {_awayTeam}");
        }
        public string Result()
        {
            var calc = _homeGoals - _awayGoals;
            _result = calc switch
            {
                > 0 => "H",
                0 => "U",
                < 0 => "B",
            };
            return _result;
        }

        public string ShowScores()
        {
            return $"{_homeTeam} {_homeGoals} : {_awayGoals} {_awayTeam}";
        }
    }
}
