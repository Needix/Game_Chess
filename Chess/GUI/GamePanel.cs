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

        private int xPerField;
        private int yPerField;

        private readonly Thread _redrawThread;

        private readonly GameLogic _logic;

        public GamePanel() {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);

            _logic = new GameLogic(this);

            _redrawThread = new Thread(RedrawThread);
            _redrawThread.Name = "RedrawThread";
            _redrawThread.Start();

            xPerField = Width / GameLogic.GRID_SIZE; 
            yPerField = Height / GameLogic.GRID_SIZE;

            DrawChess = true;

            this.MouseClick += _logic.MouseClick;
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
            DrawSelected(g);
            DrawCheckmate(g);
            DrawFigures(g);
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);

            xPerField = Width / GameLogic.GRID_SIZE;
            yPerField = Height / GameLogic.GRID_SIZE;
        }

        private void DrawGamePieces(Graphics g) {
            Brush whiteBrush = new SolidBrush(WHITE_COLOR);
            Brush blackBrush = new SolidBrush(BLACK_COLOR);
            Brush curBrush = whiteBrush;

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

        private void DrawSelected(Graphics g) {
            Field f = _logic.SelectedField;
            if (f == null) return;

            Brush brush = new SolidBrush(Color.Red);
            g.FillRectangle(brush, f.Figure.X*xPerField, f.Figure.Y*yPerField, xPerField, yPerField);

            brush = new SolidBrush(Color.Yellow);
            //TODO Save NextMovements so it doesnt get calculated every frame
            List<Point> possibleMoves = f.Figure.NextMovements(_logic.ConvertGameGridToBaseFigureGrid(), true);
            foreach (Point curPoint in possibleMoves) {
                g.FillRectangle(brush,curPoint.X*xPerField, curPoint.Y*yPerField, xPerField, yPerField);   
            }
        }

        private void DrawCheckmate(Graphics g) {
            
        }

        private void DrawFigures(Graphics g) {
            Font font = new Font("Arial", 20);

            List<BaseFigure> figures = _logic.GridFigures;
            foreach(BaseFigure figure in figures) {
                int x = figure.X * xPerField;
                int y = figure.Y * yPerField;
                Color color = figure.Team == Player.Teams.TeamWhite ? Color.White : Color.Black;
                Brush brush = new SolidBrush(color);

                g.DrawString(figure.Name, font, brush, x, y);
            }
        }
    }
}
