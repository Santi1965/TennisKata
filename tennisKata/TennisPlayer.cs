using System;
namespace tennisKata
{
    public class TennisPlayer
    {
        private string _playerName;
        private int _player;
        private int _points;
        private int _games;
        private int _sets;
        private bool _winner;


        public TennisPlayer(int player, string playerName = "DefaultName")
        {
            _playerName = $"{playerName}-({player})";
            _player = player;

            _points = 0;
            _games = 0;
            _sets = 0;
            _winner = false;
        }

        public string GetName()
        {
            return _playerName;
        }

        public bool GetWinner()
        {
            return _winner;
        }
        public void SetWinner()
        {
            _winner = true;
        }

        public void AddGame()
        {
            _games++;
        }
        public int GetGames()
        {
            return _games;
        }
        public void ResetGames()
        {
            _games = 0;
        }

        public void AddSet()
        {
            _sets++;
        }
        public int GetSets()
        {
            return _sets;
        }

        public int AddPoint()
        {
            _points++;
            return _player;
        }
        public int GetPoints()
        {
            return _points;
        }
        public void ResetPoints()
        {
            _points = 0;
        }


        public int GetTennisPoints()
        {
            if (_points == 1)
            {
                return 15;
            }
            else if (_points == 2)
            {
                return 30;
            }
            else if (_points >= 3)
            {
                return 40;
            }
            else
            {
                return 0;
            }

        }
    }
}
