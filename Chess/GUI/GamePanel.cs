using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Game_Chess.Chess.Logic;
using Game_Chess.Chess.Logic.Figures;

namespace Game_Chess.Chess.GUI {
    class GamePanel : UserControl {
        public Boolean DrawChess { get; set; }

        private readonly Color WHITE_COLOR = Color.FromArgb(255,206,158);
        private readonly Color BLACK_COLOR = Color.FromArgb(209, 139, 71);

        private readonly Thread _redrawThread;

        private readonly GameLogic _logic;

        public GamePanel() {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);

            _logic = new GameLogic(this);

            _redrawThread = new Thread(RedrawThread);
            _redrawThread.Name = "RedrawThread";
            _redrawThread.Start();

            DrawChess = true;
        }

        private void RedrawThread() {
            try {
                while (true) {
                    Thread.Sleep(250);
                    Invalidate();
                }
            } catch(ThreadInterruptedException) {
                Debug.WriteLine("Redrawing interrupted. Aborting RedrawThread...");
            }
        }
        public void Close() { _redrawThread.Interrupt(); }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.Clear(Color.White);

            if (!DrawChess) return;
            DrawGamePieces(g);
            DrawMoves(g);
            DrawCheckmate(g);
            DrawFigures(g);
        }

        private void DrawGamePieces(Graphics g) {
            Brush whiteBrush = new SolidBrush(WHITE_COLOR);
            Brush blackBrush = new SolidBrush(BLACK_COLOR);
            Brush curBrush = whiteBrush;
            int xPerField = Width / GameLogic.GRID_SIZE;
            int yPerField = Height / GameLogic.GRID_SIZE;

            int curY = 0;
            for(int y = 0; y < GameLogic.GRID_SIZE; y++) {
                int curX = 0;
                for(int x = 0; x < GameLogic.GRID_SIZE; x++) {
                    g.FillRectangle(curBrush, curX, curY, xPerField, yPerField);

                    curBrush = curBrush == whiteBrush ? blackBrush : whiteBrush;
                    curX += xPerField;
                }
                curBrush = curBrush == whiteBrush ? blackBrush : whiteBrush;
                curY += yPerField;
            }
        }

        private void DrawMoves(Graphics g) {
            
        }

        private void DrawCheckmate(Graphics g) {
            
        }

        private void DrawFigures(Graphics g) {
            int xPerField = Width / GameLogic.GRID_SIZE;
            int yPerField = Height / GameLogic.GRID_SIZE;
            Font font = new Font("Arial", 20);

            Player[] players = _logic.Player;
            foreach (Player curPlayer in players) {
                List<BaseFigure> figures = curPlayer.Figures;
                foreach (BaseFigure figure in figures) {
                    int x = figure.X*xPerField;
                    int y = figure.Y*yPerField;
                    Color color = figure.Team == Player.Teams.TeamWhite ? Color.White : Color.Black;
                    Brush brush = new SolidBrush(color);

                    g.DrawString(figure.Name, font, brush, x, y);
                }
            }
        }
    }
}
