using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Nexus_2._0.Pages;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.Win32;

namespace Nexus_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            Frame.Navigate(new HomePage());
        }
            protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            ApplyTheme();
        }

        private void SetTitleBarColor(Color color)
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            int attr = 35; // DWMWA_CAPTION_COLOR (Windows 11) or 19 (Windows 10)
            int colorValue = (color.R << 16) | (color.G << 8) | color.B;

            DwmSetWindowAttribute(hwnd, attr, ref colorValue, sizeof(int));
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "DLL Files (*.dll)|*.dll",
                Title = "Select a DLL File",
                Multiselect = true // Allow multiple selections
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Join multiple DLL paths into a single argument string, separated by commas
                string dllPaths = string.Join(",", openFileDialog.FileNames.Select(path => $"\"{path}\""));

                MessageBox.Show($"Selected DLL(s): {dllPaths}");

                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "Nexus-PreLoader.exe",
                        WorkingDirectory = @"Injector",
                        UseShellExecute = true,
                        Arguments = dllPaths // Pass as a single argument
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error starting process: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("No DLL selected.");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new HomePage());
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Credits.Content = "Credits"; //dont edit
        }

        private void Credits_MouseLeave(object sender, MouseEventArgs e)
        {
            Credits.Content = "By AmiraIsAmiraOMG";
        }

        private void Button_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Home.Content = "I'm So Lonely";
        }

        private void Home_MouseLeave(object sender, MouseEventArgs e)
        {
            Home.Content = "Nexus Singleplayer";
        }

        private void Button_MouseEnter_2(object sender, MouseEventArgs e)
        {
            Dll.Content = "Needle.exe";
        }

        private void Dll_MouseLeave(object sender, MouseEventArgs e)
        {
            Dll.Content = "Nexus DLL";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Process.Start("https://mods.nexus-utilities.linkpc.net");
        }

        private void Button_MouseEnter_4(object sender, MouseEventArgs e)
        {
            Mods.Content = "Its Like Forge But for FN";
        }

        private void Mods_MouseLeave(object sender, MouseEventArgs e)
        {
            Mods.Content = "Nexus Mods";
        }

        private void Settings_MouseEnter(object sender, MouseEventArgs e)
        {
            Settings.Content = "Beep Boop Baap Beep";
        }

        private void Settings_MouseLeave(object sender, MouseEventArgs e)
        {
            Settings.Content = "Settings";
        }

        private void Button_MouseEnter_5(object sender, MouseEventArgs e)
        {
            News.Content = "*Picks Up Newspaper*";
        }

        private void News_MouseLeave(object sender, MouseEventArgs e)
        {
            News.Content = "News";
        }

        private void Button_MouseEnter_6(object sender, MouseEventArgs e)
        {
            Plugins.Content = "Only DLLS No USBS";
        }

        private void Plugins_MouseLeave(object sender, MouseEventArgs e)
        {
            Plugins.Content = "Plugins";
        }

        private void Button_MouseEnter_7(object sender, MouseEventArgs e)
        {
            CoreFN.Content = "*Dial-up Sounds*";
        }

        private void CoreFN_MouseLeave(object sender, MouseEventArgs e)
        {
            CoreFN.Content = "Nexus Website";
        }


        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new SettingsPage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Process.Start("https://news.nexus-utilities.linkpc.net");
        }

        private void Plugins_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://plugins.nexus-utilities.linkpc.net");
        }

        private void CoreFN_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://nexus-utilities.linkpc.net");
        }

        private void Credits_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://thanks.nexus-utilities.linkpc.net");
        }

        private void ApplyTheme()
        {
            try
            {
                string jsonPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "theme.json");

                // Check if the file exists, create a default one if it doesn't
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
                ""LabelHighlightForeground"": ""#F2000000"",
                ""TitleBarColor"": ""#FF69B4""
            }";

                    // Ensure directory exists before writing
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

                if (theme["TitleBarColor"] != null)
                {
                    string titleBarColorHex = theme["TitleBarColor"].ToString();
                    Color titleBarColor = (Color)ColorConverter.ConvertFromString(titleBarColorHex);
                    SetTitleBarColor(titleBarColor);
                }
                else
                {
                    SetTitleBarColor(Colors.Purple);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading theme: {ex.Message}");
                MessageBox.Show("Now loading default theme.");
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
                ""LabelHighlightForeground"": ""#F2000000"",
                ""TitleBarColor"": ""#FF69B4""
            }";

                // Ensure directory exists before writing
                string jsonPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "theme.json");
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(jsonPath));
                File.WriteAllText(jsonPath, defaultTheme);
                StartNewInstance();
                this.Close();
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
    }
}
