using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoWindow _videoWindow;

        public MainWindow()
        {
            InitializeComponent();
            videosListBox.Items.Add("Videos/video1.mp4");
            videosListBox.Items.Add("Videos/video2.mp4");
            videosListBox.Items.Add("Videos/video3.mp4");
        }

        private void vidoesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string path = (string)videosListBox.SelectedItem;

            if (newWindowCheckBox.IsChecked == true)
            {
                _videoWindow = new VideoWindow(path);
                _videoWindow.Show();
            }
            else
            {
                if (_videoWindow == null || !_videoWindow.IsVisible)
                {
                    _videoWindow = new VideoWindow(path);
                    _videoWindow.Show();
                }
                else
                {
                    _videoWindow.LoadVideo(path);
                    _videoWindow.Activate();
                }
            }
        }
    }
}