namespace Game_Chess.Chess.Logic.Figures {
    public class Queen : BaseFigure {
        public Queen(int x, int y, Player.Teams team) : base(x, y, "Queen", team) {}
        public override bool MoveTo(int x, int y) {
            throw new System.NotImplementedException();
        }
    }
}