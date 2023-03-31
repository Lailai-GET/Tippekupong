namespace Tippekupong
{
    internal class MatchHandler
    {
        private List<Match> _matches;
        private List<Bet> _bets;
        private int _matchCount;
        private string[] _validBets;

        public MatchHandler(int matchCount = 1)
        {
            _matches = new List<Match>();
            _bets = new List<Bet>();
            _matchCount = matchCount;
            _validBets = new[] { "H", "U", "B", "HU", "HB", "UB", "HUB" };
        }

        public void Run()
        {
            CreateMatches();
            Kickoff();
            CheckResults();
        }
        private void CreateMatches()
        {
            for (int i = 0; i < _matchCount; i++)
            {
                Console.Clear();
                Console.WriteLine($"La oss lage kamp{i + 1}!");
                Console.WriteLine("Hva heter hjemmelaget?");
                var homeTeam = Console.ReadLine();
                Console.WriteLine("Hva heter bortelaget?");
                var awayTeam = Console.ReadLine();
                Console.WriteLine(
                    $"Hvem tror du vinner?\r\n{homeTeam} = H, {awayTeam} = B\r\nGyldig tips: \r\n - H, U, B\r\n - halvgardering: HU, HB, UB\r\n - helgardering: HUB");
                var userBet = "";
                bool needValid = false;
                while (!needValid)
                {
                    userBet = Console.ReadLine();
                    if (_validBets.Any(userBet.Equals)) needValid = true;
                    else Console.WriteLine("Se på gyldige tips og prøv igjen.");
                }

                _matches.Add(new Match(homeTeam, awayTeam));
                _bets.Add(new Bet(userBet));
            }
            Console.WriteLine("Lagene er klare for kamp!");
        }

        private void Kickoff()
        {
            Console.Clear();
            Console.WriteLine("En kamp er 5 målforsøk lang, ikkesant?");
            for (int i = 0; i < 5; i++)
            {
                for (var j = 0; j < _matches.Count; j++)
                {
                    var match = _matches[j];
                    Console.WriteLine($"Kamp{j + 1}, runde{i + 1}:");
                    match.AddGoal(RandomGoal());
                }
                Console.WriteLine();
            }
        }

        private void CheckResults()
        {
            Console.WriteLine("*************************************************");
            Console.WriteLine("Da var alle kampene ferdig! La oss se på resultatene...");
            for (int i = 0; i < _matches.Count; i++)
            {
                var match = _matches[i];
                var bet = _bets[i];
                bool winner = bet.CurrentBet().Contains(match.Result());
                string winnerText = winner ? "Hurra, du vant!" : "Æsj, bæsj. Du tapte";
                Console.WriteLine($"Kamp {i}:\r\n{match.ShowScores()}\r\nDu tippet:{_bets[i].CurrentBet()} Resultat: {match.Result()}\r\n{winnerText}");
                Console.WriteLine();
            }
        }

        private string RandomGoal()
        {
            var random = new Random();
            string[] scorers = { "H", "B", "U" };
            return scorers[random.Next(scorers.Length)];
        }
    }
}
