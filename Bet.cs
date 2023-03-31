namespace Tippekupong
{
    internal class Bet
    {
        private string _userBet;

        public Bet(string userBet)
        {
            _userBet = userBet;
        }

        public string CurrentBet()
        {
            return _userBet;
        }
    }
}
