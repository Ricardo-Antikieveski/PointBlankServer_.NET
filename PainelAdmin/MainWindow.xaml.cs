using System.Windows;
using System.Windows.Input;

namespace AuthServer
{
    public partial class MainWindow : Window
    {
        public string SelectedPage { get; set; } = "ServerLog";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
