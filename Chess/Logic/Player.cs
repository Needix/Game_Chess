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

            RegisterFigures();
        }

        private void RegisterFigures() {
            List<BaseFigure> figures = GameLogic.GetInstance.GridFigures;
            foreach (BaseFigure curFigure in figures) {
                if(curFigure.Team == _team) _figures.Add(curFigure);
            }
        }

        public void AddSecondsToTimer(long seconds) {
            PlayedSeconds = PlayedSeconds + seconds;
        }
    }
}
