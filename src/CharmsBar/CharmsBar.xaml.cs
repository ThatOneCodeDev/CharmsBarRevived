﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Runtime.InteropServices;

namespace CharmsBarRevived
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CharmsBar : Window
    {
        public CharmsBar()
        {
            // Here we obtain the current primary screen resolution. 
            var dispWidth = SystemParameters.PrimaryScreenWidth;
            var dispHeight = SystemParameters.PrimaryScreenHeight;
            Debug.WriteLine($"(Screen Resolution): Width:{dispWidth} Height:{dispHeight}");
            // Setting neccesary values to ensure the window is shown correctly.
            Topmost = true;
            ShowInTaskbar = false;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            AllowsTransparency = true;
            Height = dispHeight;
            Width = 75; // 80 to 90 is magic spot.
            WindowStartupLocation = WindowStartupLocation.Manual;
            Left = dispWidth - Width;
            Top = 0;
            Debug.WriteLine($"Starting Charms Bar with a height of: {Height}px, and a left location at: {Left}px ");
            BrushConverter converter = new();
            var brush = (Brush)converter.ConvertFromString("#212121");
            Background = brush;
            //Background = Brushes.Transparent;
            InitializeComponent();
        }

        /// <summary>
        /// Queries User32.dll to trigger a keyboard keypress event.
        /// </summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwExtraInfo"></param>
        /// <returns>Optional message from User32.dll</returns>
        [DllImport("User32")]
        private static extern int keybd_event(byte bVk, byte bScan, uint dwFlags, long dwExtraInfo);

        private void Search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            byte winKey = (byte)KeyInterop.VirtualKeyFromKey(Key.LWin);
            byte sKey = (byte)KeyInterop.VirtualKeyFromKey(Key.S);
            const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
            const uint KEYEVENTF_KEYUP = 0x0002;
            // Discard any values returned from User32.
            _ = keybd_event(winKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
            _ = keybd_event(sKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
            _ = keybd_event(winKey, 0, KEYEVENTF_KEYUP, 0);
            _ = keybd_event(sKey, 0, KEYEVENTF_KEYUP, 0);
        }

        private void Share_MouseDown(object sender, MouseButtonEventArgs e)
        {
            byte printScreenKey = (byte)KeyInterop.VirtualKeyFromKey(Key.PrintScreen);
            const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
            const uint KEYEVENTF_KEYUP = 0x0002;
            // Discard any values returned from User32.
            _ = keybd_event(printScreenKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
            _ = keybd_event(printScreenKey, 0, KEYEVENTF_KEYUP, 0);
        }

        /// <summary>
        /// Start button click logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Win_MouseDown(object sender, MouseButtonEventArgs e)
        {
            byte winKey = (byte)KeyInterop.VirtualKeyFromKey(Key.LWin);
            const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
            const uint KEYEVENTF_KEYUP = 0x0002;
            // Discard any values returned from User32.
            _ = keybd_event(winKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
            _ = keybd_event(winKey, 0, KEYEVENTF_KEYUP, 0);
        }

        private void Devices_MouseDown(object sender, MouseButtonEventArgs e)
        {
            byte winKey = (byte)KeyInterop.VirtualKeyFromKey(Key.LWin);
            byte pKey = (byte)KeyInterop.VirtualKeyFromKey(Key.P);
            const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
            const uint KEYEVENTF_KEYUP = 0x0002;
            // Discard any values returned from User32.
            _ = keybd_event(winKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
            _ = keybd_event(pKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
            _ = keybd_event(winKey, 0, KEYEVENTF_KEYUP, 0);
            _ = keybd_event(pKey, 0, KEYEVENTF_KEYUP, 0);
        }

        private void Settings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            byte winKey = (byte)KeyInterop.VirtualKeyFromKey(Key.LWin);
            byte iKey = (byte)KeyInterop.VirtualKeyFromKey(Key.I);
            const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
            const uint KEYEVENTF_KEYUP = 0x0002;
            // Discard any values returned from User32.
            _ = keybd_event(winKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
            _ = keybd_event(iKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
            _ = keybd_event(winKey, 0, KEYEVENTF_KEYUP, 0);
            _ = keybd_event(iKey, 0, KEYEVENTF_KEYUP, 0);
        }
    }
}
