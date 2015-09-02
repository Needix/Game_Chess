using System;
using System.Collections.Generic;

namespace Game_Chess.Chess.Logic.Figures {
    public class Queen : BaseFigure {
        public Queen(int x, int y, Player.Teams team) : base(x, y, "Queen", team) {}

        public override List<Point> NextMovements(BaseFigure[,] grid, bool inclusiveAttackMoves) {
            List<Point> result = new List<Point>();
            AddBishopMovement(grid, result, inclusiveAttackMoves);
            AddRookMovement(grid, result, inclusiveAttackMoves);
            //return EraseDuplicateEntries(result);
            return result;
        }

        private void AddRookMovement(BaseFigure[,] grid, List<Point> curList, bool inclusiveAttackMoves) {
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
        }
        private void AddBishopMovement(BaseFigure[,] grid, List<Point> curList, bool inclusiveAttackMoves) {
            try {
                for(int i = 1; i < GameLogic.GRID_SIZE; i++) {
                    int newX = X + i;
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
        }

        /*
        private List<Point> EraseDuplicateEntries(List<Point> p) {
            List<Point> newList = new List<Point>();
            foreach(Point curPoint in p) {
                Boolean found = false;
                foreach(Point checkPoint in newList) {
                    if(curPoint.Equals(checkPoint)) {
                        found = true;
                        break;
                    }
                }
                if(!found) newList.Add(curPoint);
            }
            return newList;
        }
        */

        public override bool MoveTo(int x, int y) {
            throw new System.NotImplementedException();
        }
    }
}