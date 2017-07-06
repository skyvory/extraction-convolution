using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace extraction_front
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(packfilepathtext.Text) || string.IsNullOrWhiteSpace(keyfilepathtext.Text) || string.IsNullOrWhiteSpace(exefilepathtext.Text))
            {
                MessageBox.Show("All fields are required to fill.");
                return;
            }

            if (RadioButton1.IsChecked == true)
            {
               //
            }
            else if (RadioButton2.IsChecked == true)
            {
                //
            }

            string args = "/C ..\\exfp3_v3.exe \"";
            args += packfilepathtext.Text;
            args += "\" \"";
            args += keyfilepathtext.Text;
            args += "\" \"";
            args += exefilepathtext.Text;
            args += "\"";

            System.IO.Directory.CreateDirectory("extraction");
            string workingdirectory = System.IO.Directory.GetCurrentDirectory() + "\\extraction";

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = workingdirectory;
            startInfo.FileName = "cmd.exe";

            startInfo.Arguments = args;
            process.StartInfo = startInfo;
            process.Start();
        }

        private void packfilebutton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog filedialog = new Microsoft.Win32.OpenFileDialog();
            filedialog.Filter = "Pack File (*.pack,*.packwhatever)|*.pack;*.packwhatever|All Files (*.*)|*.*";
            filedialog.FilterIndex = 1;
            filedialog.Multiselect = false;

            if (filedialog.ShowDialog() == true)
            {
                string packfilename = filedialog.FileName;
                packfilepathtext.Text = packfilename;
            }
        }

        private void keyfilebutton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog filedialog = new Microsoft.Win32.OpenFileDialog();
            filedialog.Filter = "Key File (*.fkey)|*.fkey|All Files (*.*)|*.*";
            filedialog.FilterIndex = 1;
            filedialog.Multiselect = false;

            if (filedialog.ShowDialog() == true)
            {
                string filename = filedialog.FileName;
                keyfilepathtext.Text = filename;
            }
        }

        private void exefilebutton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog filedialog = new Microsoft.Win32.OpenFileDialog();
            filedialog.Filter = "Executables (*.exe)|*.exe|All Files (*.*)|*.*";
            filedialog.FilterIndex = 1;
            filedialog.Multiselect = false;

            if (filedialog.ShowDialog() == true)
            {
                string filename = filedialog.FileName;
                exefilepathtext.Text = filename;
            }
        }
    }
}
