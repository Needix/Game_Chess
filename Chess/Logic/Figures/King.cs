namespace Game_Chess.Chess.Logic.Figures {
    public class King : BaseFigure {
        public King(int x, int y, Player.Teams team) : base(x, y, "King", team) {}
        public override bool MoveTo(int x, int y) {
            throw new System.NotImplementedException();
        }
    }
}