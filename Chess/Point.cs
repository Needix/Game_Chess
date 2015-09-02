namespace Game_Chess.Chess {
    public class Point {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y) {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) {
            if (this == obj) return true;
            Point p = obj as Point;
            if(p == null) return false;
            return X == p.X && Y == p.Y;
        }

        public override int GetHashCode() {
            return X ^ Y;
        }
    }
}