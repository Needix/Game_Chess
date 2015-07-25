namespace Game_Chess.Chess.Logic.Figures {
    public class Knight : BaseFigure { //Springer

        public Knight(int x, int y, Player.Teams team) : base(x, y, "Knight", team) {}
        public override bool MoveTo(int x, int y) {
            throw new System.NotImplementedException();
        }
    }
}