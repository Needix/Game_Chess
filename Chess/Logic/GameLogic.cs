using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Game_Chess.Chess.GUI;
using Game_Chess.Chess.Logic.Figures;

namespace Game_Chess.Chess.Logic {
    class GameLogic {
        private static GameLogic _instance;
        public static GameLogic GetInstance { get { return _instance; } }

        public static int GRID_SIZE = 8;

        private readonly GamePanel _panel;

        private readonly Field[,] _gameGrid = new Field[GRID_SIZE, GRID_SIZE];
        public Field[,] GameGrid { get { return _gameGrid; } }

        public List<BaseFigure> GridFigures { get; private set; }
        public List<BaseFigure> DestroyedFigures { get; private set; }

        public Player[] Player { get; private set; }
        private Player.Teams _currentPlayer = Logic.Player.Teams.TeamWhite;
        public Player.Teams CurrentPlayer { get{return _currentPlayer;} }
        public void SwitchCurrentPlayer() { _currentPlayer = _currentPlayer == Logic.Player.Teams.TeamWhite ? Logic.Player.Teams.TeamBlack : Logic.Player.Teams.TeamWhite; }

        public Field SelectedField { get; set; }

        public GameLogic(GamePanel panel) {
            _panel = panel;
            _instance = this;

            GridFigures = new List<BaseFigure>();
            DestroyedFigures = new List<BaseFigure>();

            InitGameGrid();

            Player = new Player[2];
            Player[0] = new Player("Player1", Logic.Player.Teams.TeamWhite);
            Player[1] = new Player("Player2", Logic.Player.Teams.TeamBlack);
        }

        private void InitGameGrid() {
            const Player.Teams teamWhite = Logic.Player.Teams.TeamWhite;
            const Player.Teams teamBlack = Logic.Player.Teams.TeamBlack;

            //TeamWhite
            _gameGrid[0, 0] = new Field(new Rook(0, 0, teamBlack));
            _gameGrid[1, 0] = new Field(new Knight(1, 0, teamBlack));
            _gameGrid[2, 0] = new Field(new Bishop(2, 0, teamBlack));
            _gameGrid[3, 0] = new Field(new Queen(3, 0, teamBlack));
            _gameGrid[4, 0] = new Field(new King(4, 0, teamBlack));
            _gameGrid[5, 0] = new Field(new Bishop(5, 0, teamBlack));
            _gameGrid[6, 0] = new Field(new Knight(6, 0, teamBlack));
            _gameGrid[7, 0] = new Field(new Rook(7, 0, teamBlack));
            for(int i = 0; i < GRID_SIZE; i++) {
                _gameGrid[i, 1] = new Field(new Pawn(i, 1, teamBlack));
            }

            //TeamBlack
            _gameGrid[0, 7] = new Field(new Rook(0, 7, teamWhite));
            _gameGrid[1, 7] = new Field(new Knight(1, 7, teamWhite));
            _gameGrid[2, 7] = new Field(new Bishop(2, 7, teamWhite));
            _gameGrid[3, 7] = new Field(new Queen(3, 7, teamWhite));
            _gameGrid[4, 7] = new Field(new King(4, 7, teamWhite));
            _gameGrid[5, 7] = new Field(new Bishop(5, 7, teamWhite));
            _gameGrid[6, 7] = new Field(new Knight(6, 7, teamWhite));
            _gameGrid[7, 7] = new Field(new Rook(7, 7, teamWhite));
            for(int i = 0; i < GRID_SIZE; i++) {
                _gameGrid[i, 6] = new Field(new Pawn(i, 6, teamWhite));
            }

            //Unused fields
            for (int y = 0; y < GRID_SIZE; y++) {
                for (int x = 0; x < GRID_SIZE; x++) {
                    Field curField = _gameGrid[x, y];
                    if(curField == null) _gameGrid[x, y] = new Field(null);
                }
            }

            //Add figures to GridFigures
            for (int y = 0; y < GRID_SIZE; y++) {
                for (int x = 0; x < GRID_SIZE; x++) {
                    BaseFigure figure = _gameGrid[x,y].Figure;
                    if(figure!=null) GridFigures.Add(figure);
                }
            }
        }

        public void MouseClick(object sender, MouseEventArgs e) {
            int xPerField = _panel.Width/GRID_SIZE;
            int yPerField = _panel.Height/GRID_SIZE;
            int fieldX = e.Location.X / xPerField;
            int fieldY = e.Location.Y / yPerField;
            if (fieldX >= GRID_SIZE || fieldY >= GRID_SIZE) return;

            Field newField = _gameGrid[fieldX, fieldY];
            BaseFigure newFigure = newField.Figure;
            bool movementSuccessfull = TryMovement(newField);
            if (!movementSuccessfull) {
                if(newFigure == null)
                    Debug.WriteLine("You have to select a figure first!"); 
                else if(newFigure.Team!=_currentPlayer)
                    Debug.WriteLine("Wrong player! ("+newFigure.Team+" tried to make a move. Its "+_currentPlayer+" players turn!)"); 
                else
                    SelectedField = newField == SelectedField ? null : newField;
            }
        }

        private void CalculateNextMovements() {
            foreach (BaseFigure curFigure in GridFigures) {
                
            }
        }

        public BaseFigure[,] ConvertGameGridToBaseFigureGrid() {
            BaseFigure[,] resultGrid = new BaseFigure[GRID_SIZE, GRID_SIZE];
            for (int y = 0; y < GRID_SIZE; y++) {
                for (int x = 0; x < GRID_SIZE; x++) {
                    resultGrid[x, y] = _gameGrid[x, y].Figure;
                }
            }
            return resultGrid;
        }

        private bool TryMovement(Field newField) {
            BaseFigure newFigure = newField.Figure;
            if (SelectedField == null) return false;
            //TODO Finish TryMovement
            return false;
        }
    }
}
