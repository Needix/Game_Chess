namespace Game_Chess.Chess.Logic.Figures {
    public class Bishop : BaseFigure { //Laeufer

        public Bishop(int x, int y, Player.Teams team) : base(x, y, "Bishop", team) {}
        public override bool MoveTo(int x, int y) {
            throw new System.NotImplementedException();
        }
    }
}