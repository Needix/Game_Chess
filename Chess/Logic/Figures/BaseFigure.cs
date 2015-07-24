using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Chess.Chess.Logic.Figures {
    abstract class BaseFigure {

        public int X { get; set; }
        public int Y { get; set; }
        public String Name { get; private set; }

        private readonly Player.Teams _team;
        public Player.Teams Team { get { return _team; } }

        protected BaseFigure(int x, int y, String name, Player.Teams team) {
            this.X = x;
            this.Y = y;
            this._team = team;
            this.Name = name;
        }
    }
}
