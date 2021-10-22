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
            if (folderPath.Text == "") {
                MessageBox.Show("Veuillez saisir le chemin d'accès au dossier");
                return;
            }
            if (repoPath.Text == "") {
                MessageBox.Show("Veuillez saisir le lien d'un repertoire Git");
                return;
            }

            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = "/C cd " + folderPath.Text + "&& git clone " + repoPath.Text;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                folderPath.Text = dialog.SelectedPath;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (folderPath.Text != "")
            {
                MessageBox.Show("Veuillez saisir un chemin d'accès");
                return;
            }

            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = "/C cd " + folderPath.Text + "&& git add .";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (CommitMessage.Text != "")
            {
                MessageBox.Show("Veuillez saisir un message commit");
                return;
            }

            if (folderPath.Text != "")
            {
                MessageBox.Show("Veuillez saisir un chemin d'accès");
                return;
            }

            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = "/C cd " + folderPath.Text + "&& git commit m- \"" + CommitMessage.Text + "\"";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (folderPath.Text != "")
            {
                MessageBox.Show("Veuillez saisir un chemin d'accès");
                return;
            }

            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = "/C cd " + folderPath.Text + "&& git push origin";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit();
        }
    }
}