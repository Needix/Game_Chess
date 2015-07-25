using System;
using System.Collections.Generic;

namespace Game_Chess.Chess.Logic.Figures {
    public class Pawn : BaseFigure { //Bauer

        public Pawn(int x, int y, Player.Teams team) : base(x, y, "Pawn", team) {}
        public override List<Point> NextMovements(BaseFigure[,] grid, bool inclusiveAttackMoves) {
            List<Point> result = new List<Point>();

            int direction = 1;
            if (Team == Player.Teams.TeamWhite) direction = -1;

            try {
                if (grid[X, Y + direction] == null) result.Add(new Point(X, Y + direction)); //Normal movement
            } catch (IndexOutOfRangeException) {}

            try {
                if(((Y == 6 && Team == Player.Teams.TeamWhite) || (Y == 1 && Team == Player.Teams.TeamBlack)) //Pawn is on start position
                        && grid[X, Y + direction] == null //And can move 1 step
                        && grid[X, Y + 2 * direction] == null) //And can move 2 steps
                    result.Add(new Point(X, Y + 2 * direction));
            } catch (IndexOutOfRangeException) {}

            try {
                if(inclusiveAttackMoves && grid[X + 1, Y + direction] != null && grid[X + 1, Y + direction].Team != Team) //Move diagonal & attack enemy
                    result.Add(new Point(X + 1, Y + direction));
            } catch(IndexOutOfRangeException) { }

            try {
                if(inclusiveAttackMoves && grid[X - 1, Y + direction] != null && grid[X - 1, Y + direction].Team != Team) //Move diagonal & attack enemy
                    result.Add(new Point(X - 1, Y + direction));
            } catch(IndexOutOfRangeException) { }
            
            return result;
        }

        public override bool MoveTo(int x, int y) {
            throw new System.NotImplementedException();
        }
    }
}