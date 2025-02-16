using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        [DllImport("kernel32")]
        public static extern IntPtr CreateRemoteThread(
IntPtr hProcess,
IntPtr lpThreadAttributes,
uint dwStackSize,
UIntPtr lpStartAddress,
IntPtr lpParameter,
uint dwCreationFlags,
out IntPtr lpThreadId
);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(
            UInt32 dwDesiredAccess,
            Int32 bInheritHandle,
            Int32 dwProcessId
            );

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(
        IntPtr hObject
        );

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool VirtualFreeEx(
            IntPtr hProcess,
            IntPtr lpAddress,
            UIntPtr dwSize,
            uint dwFreeType
            );

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern UIntPtr GetProcAddress(
            IntPtr hModule,
            string procName
            );

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(
            IntPtr hProcess,
            IntPtr lpAddress,
            uint dwSize,
            uint flAllocationType,
            uint flProtect
            );

        [DllImport("kernel32.dll")]
        static extern int WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            uint nSize,
            int lpNumberOfBytesWritten
        );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(
            string lpModuleName
            );

        [DllImport("kernel32", SetLastError = true, ExactSpelling = true)]
        internal static extern Int32 WaitForSingleObject(
            IntPtr handle,
            Int32 milliseconds
            );

        public HomePage()
        {
            InitializeComponent();
            ApplyThemeHome();

            string GamePath = Properties.Settings.Default.GamePath;
            string splashPath = System.IO.Path.Combine(GamePath, "FortniteGame", "Content", "Splash", "Splash.bmp");
            string exePath = System.IO.Path.Combine(GamePath, "FortniteGame", "Binaries", "Win64", "FortniteClient-Win64-Shipping.exe");

            if (File.Exists(exePath))
            {
                try
                {
                    if (File.Exists(splashPath))
                    {
                        BitmapImage splashImage = new BitmapImage(new Uri(splashPath));

                        ImageBrush imageBrush = new ImageBrush
                        {
                            ImageSource = splashImage,
                            Stretch = Stretch.Fill
                        };

                        SplashBox.Background = imageBrush;
                    }
                    else
                    {
                        MessageBox.Show("Splash image not found. Default background will be used.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading splash image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Fortnite executable not found. Please check the game path.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Email.Content = Properties.Settings.Default.SavedUsername;
            Path.Content = Properties.Settings.Default.GamePath;
        }

        public static bool Inject(int P, string DllPath)
        {
            IntPtr hndPrc = OpenProcess(0x1F0FFF, 1, P);

            if (hndPrc == IntPtr.Zero) return false;

            IntPtr lpAddress = VirtualAllocEx(hndPrc, (IntPtr)null, (uint)DllPath.Length, 0x1000, 0x40);

            if (lpAddress == IntPtr.Zero) return false;

            byte[] bytes = Encoding.ASCII.GetBytes(DllPath);

            if (WriteProcessMemory(hndPrc, lpAddress, bytes, (uint)bytes.Length, 0) == 0) return false;

            UIntPtr Injector = (UIntPtr)GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

            IntPtr bytesout;
            IntPtr hThread = (IntPtr)CreateRemoteThread(hndPrc, (IntPtr)null, 0, Injector, lpAddress, 0, out bytesout);

            CloseHandle(hndPrc);

            return true;
        }

        public static int PreInject(int ProcessID, string DllPath)
        {
            if (!File.Exists(DllPath)) return 0;

            if (ProcessID == 0) return 1;

            if (!Inject(ProcessID, DllPath)) return 2;

            return 3;
        }

        public void StartFortnite()
        {
            var Username = Properties.Settings.Default.SavedUsername;
            var Password = Properties.Settings.Default.SavedPassword;

            var Fortnite = new Process
            { 
                StartInfo =
                    {
                        FileName = System.IO.Path.Combine(Properties.Settings.Default.GamePath, @"FortniteGame\Binaries\Win64\FortniteClient-Win64-Shipping.exe"),
                        Arguments = $"-noeac -nobe -fltoken=none -NoCodeGuards -epicapp=Fortnite -epicenv=Prod -epicportal -epiclocale=en-us -skippatchcheck -NOSSLPINNING -AUTH_LOGIN={Username} -AUTH_TYPE=epic -AUTH_PASSWORD={Password} -epicportal -noeac -fromfl=be -fltoken=h1cdhchd10150221h130eB56",
                        UseShellExecute = false
                    }
            };

            Fortnite.Start();
            Fortnite.WaitForInputIdle();

            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);

            PreInject(Fortnite.Id, System.IO.Path.Combine(strWorkPath + "\\DLLs\\Nexus.dll"));
            Inject(Fortnite.Id, System.IO.Path.Combine(strWorkPath + "\\DLLs\\Nexus.dll"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Thread(new ThreadStart(StartFortnite)).Start();

            if (File.Exists(Properties.Settings.Default.GamePath + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe"))
            {
                new Thread(new ThreadStart(StartFortnite)).Start();
            }
            else
            {
                MessageBox.Show("I don't think you have your game directory set, please check it in settings.", " Game Path");
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Launch.Content = "3 2 1 LIFT-OFF";
        }

        private void Launch_MouseLeave(object sender, MouseEventArgs e)
        {
            Launch.Content = "Launch Nexus Singleplayer";
        }

        private void ApplyThemeHome()
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

        private void PathBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
