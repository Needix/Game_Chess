using System.ComponentModel;
using System.Windows.Forms;

namespace Game_Chess.Chess.GUI {
    public partial class GUI : Form {
        public GUI() {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);

            gamePanel1.Close();
        }
    }
}
