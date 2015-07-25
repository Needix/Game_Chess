namespace Game_Chess.Chess.Logic.Figures {
    public class Rook : BaseFigure { //Turm
        public Rook(int x, int y, Player.Teams team) : base(x, y, "Rook", team) {}

        public override bool MoveTo(int x, int y) {
            throw new System.NotImplementedException();
        }
    }
}