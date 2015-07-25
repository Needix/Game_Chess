namespace Game_Chess.Chess.Logic.Figures {
    public class Pawn : BaseFigure { //Bauer

        public Pawn(int x, int y, Player.Teams team) : base(x, y, "Pawn", team) {}
        public override bool MoveTo(int x, int y) {
            throw new System.NotImplementedException();
        }
    }
}