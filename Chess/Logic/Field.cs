using System.Collections.Generic;
using Game_Chess.Chess.Logic.Figures;

namespace Game_Chess.Chess.Logic {
    class Field {
        public Field(BaseFigure figure) {
            this.Figure = figure;
        }

        /// <summary>
        /// Figure on this field, null if empty
        /// </summary>
        public BaseFigure Figure { get; set; }

        /// <summary>
        /// List of figures that can move on this field in next move
        /// </summary>
        public List<BaseFigure> PossibleMoves { get; set; }

        public void ClearPossibleMoves() {
            PossibleMoves = new List<BaseFigure>();
        } 
    }
}
