using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game_Chess.Chess.Logic.Figures;

namespace Game_Chess.Chess.Logic {
    class Player {
        public enum Teams {
            TeamWhite = 1,
            TeamBlack = 2
        }

        public String Name { get; set; }

        private readonly List<BaseFigure> _figures = new List<BaseFigure>();
        public List<BaseFigure> Figures { get { return _figures; } }

        private readonly Teams _team;
        public Teams Team { get { return _team; } }

        public Player(String name, Teams team) {
            this.Name = name;
            this._team = team;

            InitFigures();
        }

        private void InitFigures() {
            _figures.Add(new );
        }
    }
}
