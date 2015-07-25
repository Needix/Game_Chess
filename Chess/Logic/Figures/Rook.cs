using System;
using System.Collections.Generic;

namespace Game_Chess.Chess.Logic.Figures {
    public class Rook : BaseFigure { //Turm
        public Rook(int x, int y, Player.Teams team) : base(x, y, "Rook", team) {}
        
        public override List<Point> NextMovements(BaseFigure[,] grid, bool inclusiveAttackMoves) {
            List<Point> curList = new List<Point>();
            try {
                for(int x = 1; x < GameLogic.GRID_SIZE; x++) {
                    int newX = X + x;
                    int newY = Y;
                    if(grid[newX, newY] != null) {
                        if(grid[newX, newY].Team != Team && inclusiveAttackMoves)
                            curList.Add(new Point(newX, newY));
                        break;
                    }
                    curList.Add(new Point(newX, newY));
                }
            } catch(IndexOutOfRangeException) { }

            try {
                for(int x = 1; x < GameLogic.GRID_SIZE; x++) {
                    int newX = X - x;
                    int newY = Y;
                    if(grid[newX, newY] != null) {
                        if(grid[newX, newY].Team != Team && inclusiveAttackMoves)
                            curList.Add(new Point(newX, newY));
                        break;
                    }
                    curList.Add(new Point(newX, newY));
                }
            } catch(IndexOutOfRangeException) { }

            try {
                for(int y = 1; y < GameLogic.GRID_SIZE; y++) {
                    int newX = X;
                    int newY = Y + y;
                    if(grid[newX, newY] != null) {
                        if(grid[newX, newY].Team != Team && inclusiveAttackMoves)
                            curList.Add(new Point(newX, newY));
                        break;
                    }
                    curList.Add(new Point(newX, newY));
                }
            } catch(IndexOutOfRangeException) { }

            try {
                for(int y = 1; y < GameLogic.GRID_SIZE; y++) {
                    int newX = X;
                    int newY = Y - y;
                    if(grid[newX, newY] != null) {
                        if(grid[newX, newY].Team != Team && inclusiveAttackMoves)
                            curList.Add(new Point(newX, newY));
                        break;
                    }
                    curList.Add(new Point(newX, newY));
                }
            } catch(IndexOutOfRangeException) { }

            return curList;
        }

        public override bool MoveTo(int x, int y) {
            throw new System.NotImplementedException();
        }
    }
}