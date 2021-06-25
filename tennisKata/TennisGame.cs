using System;
namespace tennisKata
{
    public class TennisGame
    {
        private TennisPlayer _playerOne;
        private TennisPlayer _playerTwo;

        private int _gameSets;

        private Random _rnd;


        public TennisGame(int gameSets, string playerOneName = "DefaultPlayer", string playerTwoName = "DefaultPlayer")
        {
            _playerOne = new TennisPlayer(1, playerOneName);
            _playerTwo = new TennisPlayer(2, playerTwoName);
            _gameSets = gameSets;
            _rnd = new Random();
            gamePlay();

        }



        public void gamePlay()
        {
            int pointWin = 0;
            int pointLoose = 0;
            int[] points = { 0, 0, 0 };
            int[] games = { 0, 0, 0 };
            int[] sets = { 0, 0, 0 };
            int round = 0;
            string[] players = { "Wimbledon Cup", _playerOne.GetName(), _playerTwo.GetName() };

            while (!_playerOne.GetWinner() && !_playerTwo.GetWinner())
            {
                round++;
                pointLoose = _rnd.Next(0, 99) > 50 ? 1 : 2;


                pointWin = pointLoose < 2 ? _playerTwo.AddPoint() : _playerOne.AddPoint();

                points[0] = round;
                points[1] = _playerOne.GetPoints();
                points[2] = _playerTwo.GetPoints();

                int punktW = GetTennisPoints(points[pointWin]);
                int punktL = GetTennisPoints(points[pointLoose]);


                if (points[pointWin] <= 3 && points[pointLoose] <= 3)
                {
                    Console.WriteLine("********************************{0} - Round {1}*************************", players[0], round);
                    Console.WriteLine("{0} wins this point. {0} - {1} / {2} - {3} ", players[pointWin], punktW, players[pointLoose], punktL);

                }



                if (points[pointWin] > 3 && (points[pointWin] - points[pointLoose]) > 1)
                {
                    _playerOne.ResetPoints();
                    _playerTwo.ResetPoints();

                    if (pointWin == 1) _playerOne.AddGame();
                    if (pointWin == 2) _playerTwo.AddGame();
                    games[0] = round;
                    games[1] = _playerOne.GetGames();
                    games[2] = _playerTwo.GetGames();

                    Console.WriteLine("{0} wins this game. {0} - {1} / {2} - {3} ", players[pointWin], games[pointWin], players[pointLoose], games[pointLoose]);

                }


                if (games[pointWin] > 6 && (games[pointWin] - games[pointLoose]) > 1)
                {
                    _playerOne.ResetGames();
                    _playerTwo.ResetGames();
                    games[0] = round;
                    games[1] = _playerOne.GetGames();
                    games[2] = _playerTwo.GetGames();

                    if (pointWin == 1) _playerOne.AddSet();
                    if (pointWin == 2) _playerTwo.AddSet();
                    sets[0] = round;
                    sets[1] = _playerOne.GetSets();
                    sets[2] = _playerTwo.GetSets();

                    Console.WriteLine("{0} wins this set. {0} - {1} / {2} - {3} ", players[pointWin], sets[pointWin], players[pointLoose], sets[pointLoose]);
                }

                if (sets[pointWin] == _gameSets)
                {
                    if (pointWin == 1) _playerOne.winner = true;
                    if (pointWin == 2) _playerTwo.winner = true;

                    Console.WriteLine("*WINWINWINWINWINWINWINWINWINWINWIN*{0} - Round {1}*WINWINWINWINWINWINWINWINWINWINWINWINWIN*", players[0], round);
                    Console.WriteLine("");
                    Console.WriteLine("{0} wins this Cup!!!!. {0} - {1} / {2} - {3} ", players[pointWin], sets[pointWin], players[pointLoose], sets[pointLoose]);
                    Console.WriteLine("");
                    Console.WriteLine("*WINWINWINWINWINWINWINWINWINWINWIN*{0} - Round {1}*WINWINWINWINWINWINWINWINWINWINWINWINWIN*", players[0], round);
                    



                }

                Console.WriteLine("{0} {1}-{2}-{3} ---- {4} {5}-{6}-{7}", _playerOne.GetName(), GetPunkts(_playerOne.GetPoints()), _playerOne.GetGames(), _playerOne.GetSets(), _playerTwo.GetName(), GetPunkts(_playerTwo.GetPoints()), _playerTwo.GetGames(), _playerTwo.GetSets());
            }


        }


        public int GetTennisPoints(int punts)
        {
            if (punts == 1)
            {
                return 15;
            }
            else if (punts == 2)
            {
                return 30;
            }
            else if (punts >= 3)
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

