using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MediaPlayer
{
    /// <summary>
    /// Interaction logic for VideoWindow.xaml
    /// </summary>
    public partial class VideoWindow : Window
    {
        public VideoWindow(string videoPath)
        {
            InitializeComponent();
            LoadVideo(videoPath);
        }

        public void LoadVideo(string videoPath)
        {
            

            if (!File.Exists(videoPath))
            {
                MessageBox.Show("Video bestaat niet","Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Title = videoPath;
                videoMediaElement.Source = new Uri(videoPath, UriKind.Relative);
                videoMediaElement.Stop();
                videoMediaElement.Play();
            }
        }
    }
}
