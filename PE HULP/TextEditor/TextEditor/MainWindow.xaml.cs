using System.IO;
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
using Microsoft.Win32;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _fileName = "editor.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files|*.txt|Word documenten|*.docx|Alle files|*.*";
            if (ofd.ShowDialog() == true)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    editorTextBox.Text = sr.ReadToEnd();
                }
            }
            else
            {
                editorTextBox.Text = string.Empty;
            }
            _fileName = ofd.FileName;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                sw.Write(editorTextBox.Text);
            }
        }

        private void saveAsButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = _fileName;
            sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    sw.Write(editorTextBox.Text);
                }
            }
        }
    }
}