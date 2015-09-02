using System;
using System.Collections.Generic;

namespace Game_Chess.Chess.Logic.Figures {
    public class Knight : BaseFigure { //Springer

        public Knight(int x, int y, Player.Teams team) : base(x, y, "Knight", team) {}

        public override List<Point> NextMovements(BaseFigure[,] grid, bool inclusiveAttackMoves) {
            List<Point> result = new List<Point>();

            try { if(grid[X + 1, Y + 2] == null || (grid[X + 1, Y + 2].Team != Team && inclusiveAttackMoves)) result.Add(new Point(X+1, Y+2)); } catch(IndexOutOfRangeException) { }
            try { if(grid[X - 1, Y + 2] == null || (grid[X - 1, Y + 2].Team != Team && inclusiveAttackMoves)) result.Add(new Point(X - 1, Y + 2)); } catch(IndexOutOfRangeException) { }
            try { if(grid[X + 1, Y - 2] == null || (grid[X + 1, Y - 2].Team != Team && inclusiveAttackMoves)) result.Add(new Point(X + 1, Y - 2)); } catch(IndexOutOfRangeException) { }
            try { if(grid[X - 1, Y - 2] == null || (grid[X - 1, Y - 2].Team != Team && inclusiveAttackMoves)) result.Add(new Point(X - 1, Y - 2)); } catch(IndexOutOfRangeException) { }
            try { if(grid[X + 2, Y + 1] == null || (grid[X + 2, Y + 1].Team != Team && inclusiveAttackMoves)) result.Add(new Point(X + 2, Y + 1)); } catch(IndexOutOfRangeException) { }
            try { if(grid[X - 2, Y + 1] == null || (grid[X - 2, Y + 1].Team != Team && inclusiveAttackMoves)) result.Add(new Point(X - 2, Y + 1)); } catch(IndexOutOfRangeException) { }
            try { if(grid[X + 2, Y - 1] == null || (grid[X + 2, Y - 1].Team != Team && inclusiveAttackMoves)) result.Add(new Point(X + 2, Y - 1)); } catch(IndexOutOfRangeException) { }
            try { if(grid[X - 2, Y - 1] == null || (grid[X - 2, Y - 1].Team != Team && inclusiveAttackMoves)) result.Add(new Point(X - 2, Y - 1)); } catch(IndexOutOfRangeException) { }

            return result;
        }

        public override bool MoveTo(int x, int y) {
            throw new System.NotImplementedException();
        }
    }
}