using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;

namespace Nexus_2._0.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            ApplyThemeSettings();
            EmailBox.Text = Properties.Settings.Default.SavedUsername;
            PasswordBox.Text = Properties.Settings.Default.SavedPassword;
            GamePathBox.Text = Properties.Settings.Default.GamePath;
        }

        private void Launch_MouseEnter(object sender, MouseEventArgs e)
        {
            Launch.Content = "Use Black Magic To Alter The Binary Of Your Storage Device";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create a new OpenFileDialog to select a .json file
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            // Set the filter for the dialog to only show .json files
            openFileDialog.Filter = "JSON Files (*.json)|*.json";

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;

                // Set the path for the theme.json that we load the theme from
                string themeFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "theme.json");

                try
                {
                    // Read the content of the selected file
                    string selectedJson = File.ReadAllText(selectedFilePath);

                    // Ensure the Assets folder exists, then overwrite the existing theme.json with the selected content
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(themeFilePath));
                    File.WriteAllText(themeFilePath, selectedJson);

                    // Start a new instance of the application
                    StartNewInstance();

                    // Close the current application
                    Application.Current.Shutdown();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating the theme: {ex.Message}");
                }
            }
        }

        private void StartNewInstance()
        {
            try
            {
                // Get the current application's executable path
                string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

                // Start a new instance of the application
                Process.Start(appPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting new instance: {ex.Message}");
            }
        }

        private void Launch_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Launch.Content = "Save";
        }

        private void UrlInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            Properties.Settings.Default.GamePath = GamePathBox.Text;
            Properties.Settings.Default.Save();
        }

        private void ApplyThemeSettings()
        {
            try
            {
                string jsonPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "theme.json");

                if (!File.Exists(jsonPath))
                {
                    MessageBox.Show("Theme file not found! Creating a default theme file.");

                    string defaultTheme = @"
            {
                ""BackgroundColor"": ""#FFFFFF"",
                ""ForegroundColor"": ""#000000"",
                ""ButtonBackground"": ""#EAEAEA"",
                ""ButtonBorderBrush"": ""#DADADA"",
                ""ButtonForeground"": ""#757575"",
                ""HoverBackground"": ""#C5C5C5"",
                ""PressedBackground"": ""#DADADA"",
                ""PanelBackground"": ""#F7F7F7"",
                ""FooterBackground"": ""#EAEAEA"",
                ""LabelForeground"": ""#000000"",
                ""LabelHighlightForeground"": ""#F2000000""
            }";

                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(jsonPath));
                    File.WriteAllText(jsonPath, defaultTheme);
                }

                string json = File.ReadAllText(jsonPath);
                JObject theme = JObject.Parse(json);

                Application.Current.Resources["BackgroundColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(theme["BackgroundColor"].ToString()));
                Application.Current.Resources["ForegroundColor"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(theme["ForegroundColor"].ToString()));
                Application.Current.Resources["ButtonBackground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(theme["ButtonBackground"].ToString()));
                Application.Current.Resources["ButtonBorderBrush"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(theme["ButtonBorderBrush"].ToString()));
                Application.Current.Resources["ButtonForeground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(theme["ButtonForeground"].ToString()));
                Application.Current.Resources["HoverBackground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(theme["HoverBackground"].ToString()));
                Application.Current.Resources["PressedBackground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(theme["PressedBackground"].ToString()));
                Application.Current.Resources["PanelBackground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(theme["PanelBackground"].ToString()));
                Application.Current.Resources["FooterBackground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(theme["FooterBackground"].ToString()));
                Application.Current.Resources["LabelForeground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(theme["LabelForeground"].ToString()));
                Application.Current.Resources["LabelHighlightForeground"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(theme["LabelHighlightForeground"].ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading theme: {ex.Message}");
            }
        }

        private void Launch_MouseEnter1(object sender, MouseEventArgs e)
        {
            Launch_Copy.Content = "New Lick Of Paint";
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            EmailBox.Text = Properties.Settings.Default.SavedUsername;
            PasswordBox.Text = Properties.Settings.Default.SavedPassword;
            GamePathBox.Text = Properties.Settings.Default.GamePath;
        }

        private void EmailBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Properties.Settings.Default.SavedUsername = EmailBox.Text;
            Properties.Settings.Default.Save();
        }

        private void Launch_Copy_MouseLeave(object sender, MouseEventArgs e)
        {
            Launch_Copy.Content = "Select Theme";
        }

        private void PasswordBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Properties.Settings.Default.SavedPassword = PasswordBox.Text;
            Properties.Settings.Default.Save();
        }

        private void GamePathBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Properties.Settings.Default.GamePath = GamePathBox.Text;
            Properties.Settings.Default.Save();
        }
    }
}
