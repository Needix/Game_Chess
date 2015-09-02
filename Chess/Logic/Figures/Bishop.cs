using System;
using System.Collections.Generic;

namespace Game_Chess.Chess.Logic.Figures {
    public class Bishop : BaseFigure { //Laeufer
        public Bishop(int x, int y, Player.Teams team) : base(x, y, "Bishop", team) {}

        public override List<Point> NextMovements(BaseFigure[,] grid, bool inclusiveAttackMoves) {
            List<Point> curList = new List<Point>();
            try {
                for(int i = 1; i < GameLogic.GRID_SIZE; i++) {
                    int newX = X + i;
                    int newY = Y + i;
                    if (grid[newX, newY] != null) {
                        if(grid[newX, newY].Team != Team && inclusiveAttackMoves)
                            curList.Add(new Point(newX, newY));
                        break;   
                    }
                    curList.Add(new Point(newX, newY));
                }
            } catch(IndexOutOfRangeException) { }

            try {
                for(int i = 1; i < GameLogic.GRID_SIZE; i++) {
                    int newX = X + i;
                    int newY = Y - i;
                    if(grid[newX, newY] != null) {
                        if(grid[newX, newY].Team != Team && inclusiveAttackMoves)
                            curList.Add(new Point(newX, newY));
                        break;
                    }
                    curList.Add(new Point(newX, newY));
                }
            } catch(IndexOutOfRangeException) { }

            try {
                for(int i = 1; i < GameLogic.GRID_SIZE; i++) {
                    int newX = X - i;
                    int newY = Y + i;
                    if(grid[newX, newY] != null) {
                        if(grid[newX, newY].Team != Team && inclusiveAttackMoves)
                            curList.Add(new Point(newX, newY));
                        break;
                    }
                    curList.Add(new Point(newX, newY));
                }
            } catch(IndexOutOfRangeException) { }

            try {
                for(int i = 1; i < GameLogic.GRID_SIZE; i++) {
                    int newX = X - i;
                    int newY = Y - i;
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