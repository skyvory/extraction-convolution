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

using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace extraction_front
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void exeFileButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog filedialog = new Microsoft.Win32.OpenFileDialog();
            filedialog.Filter = "Executables (*.exe)|*.exe|All Files (*.*)|*.*";
            filedialog.FilterIndex = 1;
            filedialog.Multiselect = false;

            if (filedialog.ShowDialog() == true)
            {
                string filename = filedialog.FileName;
                versatileSingleExePathText.Text = filename;
            }
        }

        private void sourceFileDirectoryButt_Click(object sender, RoutedEventArgs e)
        {
            if (CommonFileDialog.IsPlatformSupported)
            {
                var dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                CommonFileDialogResult result = dialog.ShowDialog();
                if (result == CommonFileDialogResult.Ok)
                {
                    versatileSingleSourceDirectoryPathText.Text = dialog.FileName;
                }
            }
            else
            {
                var dialog = new System.Windows.Forms.FolderBrowserDialog();
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result.ToString() == "OK")
                {
                    versatileSingleSourceDirectoryPathText.Text = dialog.SelectedPath;
                }
            }
        }

        private void versatileSingleExtractButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(versatileSingleExePathText.Text) || string.IsNullOrWhiteSpace(versatileSingleFormatText.Text) || string.IsNullOrWhiteSpace(versatileSingleSourceDirectoryPathText.Text))
            {
                MessageBox.Show("All fields are required to fill.");
                return;
            }

            string exePath = versatileSingleExePathText.Text;
            string format = versatileSingleFormatText.Text;
            string folderPath = versatileSingleSourceDirectoryPathText.Text;
            
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
            //FileInfo[] files = dirInfo.GetFiles("*.png");
            string[] files = Directory.GetFiles(folderPath, "*.png");

            int filesCount = files.Length;
            string args;
            System.IO.Directory.CreateDirectory("extraction");
            string workingdirectory = System.IO.Directory.GetCurrentDirectory() + "\\extraction";

             // change status text
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).statusText.Text = "Extracting...";
                }
            }

            foreach (string file in files)
            {
                // Console.WriteLine(file);
                args = "/C \"";
                args += exePath;
                args += "\" \"";
                args += file;
                args += "\"";

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.WorkingDirectory = workingdirectory;
                startInfo.FileName = "cmd.exe";

                startInfo.Arguments = args;
                process.StartInfo = startInfo;

                // >>>Update extraction count
                process.Start();
                process.WaitForExit();
            }

            // change status text
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).statusText.Text = "Idle";
                }
            }
        }

    }
}
