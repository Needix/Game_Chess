using System;
using System.Collections.Generic;
using System.Diagnostics;
using Game_Chess.Chess.Logic.Figures;

namespace Game_Chess.Chess.Logic {
    public class Player {
        public enum Teams {
            TeamWhite = 1,
            TeamBlack = 2
        }

        private readonly String _name;
        public String Name { get { return _name; } }

        public long PlayedSeconds { get; private set; }

        private readonly List<BaseFigure> _figures = new List<BaseFigure>();
        public List<BaseFigure> Figures { get { return _figures; } }

        private readonly Teams _team;
        public Teams Team { get { return _team; } }

        public Player(String name, Teams team) {
            this._name = name;
            this._team = team;

            InitFigures();
        }

        private void InitFigures() {
            if (Team == Teams.TeamWhite) {
                _figures.Add(new Rook(0, 0, Team));
                _figures.Add(new Knight(1, 0, Team));
                _figures.Add(new Bishop(2, 0, Team));
                _figures.Add(new Queen(3, 0, Team));
                _figures.Add(new King(4, 0, Team));
                _figures.Add(new Bishop(5, 0, Team));
                _figures.Add(new Knight(6, 0, Team));
                _figures.Add(new Rook(7, 0, Team));

                for(int i = 0; i < 8; i++) {
                    _figures.Add(new Pawn(i, 1, Team));   
                }
            } else {
                _figures.Add(new Rook(0, 7, Team));
                _figures.Add(new Knight(1, 7, Team));
                _figures.Add(new Bishop(2, 7, Team));
                _figures.Add(new Queen(3, 7, Team));
                _figures.Add(new King(4, 7, Team));
                _figures.Add(new Bishop(5, 7, Team));
                _figures.Add(new Knight(6, 7, Team));
                _figures.Add(new Rook(7, 7, Team));

                for(int i = 0; i < 8; i++) {
                    _figures.Add(new Pawn(i, 6, Team));
                }
            }
        }

        public void AddSecondsToTimer(long seconds) {
            PlayedSeconds = PlayedSeconds + seconds;
        }
    }
}
