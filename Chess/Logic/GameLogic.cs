using System.Windows.Forms;
using Game_Chess.Chess.GUI;

namespace Game_Chess.Chess.Logic {
    class GameLogic {
        public static int GRID_SIZE = 8;

        private readonly GamePanel _panel;

        private Field[,] _gameGrid = new Field[GRID_SIZE, GRID_SIZE];
        public Field[,] GameGrid { get { return _gameGrid; } }

        public Player[] Player { get; private set; }
        private Player.Teams _currentPlayer;
        public Player.Teams CurrentPlayer { get{return _currentPlayer;} }
        public void SwitchCurrentPlayer() { _currentPlayer = _currentPlayer == Logic.Player.Teams.TeamWhite ? Logic.Player.Teams.TeamBlack : Logic.Player.Teams.TeamWhite; }

        public GameLogic(GamePanel panel) {
            _panel = panel;

            Player = new Player[2];
            Player[0] = new Player("Player1", Logic.Player.Teams.TeamWhite);
            Player[1] = new Player("Player2", Logic.Player.Teams.TeamBlack);
        }
    }
}
