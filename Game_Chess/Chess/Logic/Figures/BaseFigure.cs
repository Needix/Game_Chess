using System;
using System.Collections.Generic;

namespace Game_Chess.Chess.Logic.Figures {
    public abstract class BaseFigure {
        public enum Files {
            A = 0,
            B = 1,
            C = 2,
            D = 3,
            E = 4,
            F = 5,
            G = 6,
            H = 7
        }

        public int X { get; set; }
        public int Y { get; set; }
        public String Name { get; private set; }

        private readonly Player.Teams _team;
        public Player.Teams Team { get { return _team; } }

        public List<Point> PossibleMovements { get; set; } 

        protected BaseFigure(int x, int y, String name, Player.Teams team) {
            this.X = x;
            this.Y = y;
            this._team = team;
            this.Name = name;
        }

        public abstract List<Point> NextMovements(BaseFigure[,] grid, bool inclusiveAttackMoves);

        public Boolean ChangePosition(int deltaX, int deltaY) { return MoveTo(X + deltaX, Y + deltaY); }
        public abstract Boolean MoveTo(int x, int y);
    }
}
