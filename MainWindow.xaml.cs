using System;
using System.Diagnostics;
using System.Windows;
namespace labo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            label.Content = "Version Windows : " + Environment.OSVersion.Version;

        }

        private void CloneRepo(object sender, RoutedEventArgs e)
        {
            int error = 0;
            if (folderPath.Text == "") {
                error++;
                MessageBox.Show("Veuillez saisir le chemin du dossier");
            }
            if (repoPath.Text == "") {
                error++;
                MessageBox.Show("Veuillez saisir le lien d'un repertoire Git");
            }
            if (error == 0)
            {

                Process proc = new Process();
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.Arguments = "/C cd " + folderPath.Text + "&& git clone " + repoPath.Text;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.Start();
                proc.WaitForExit();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                folderPath.Text = dialog.SelectedPath;
            }
        }
    }
}