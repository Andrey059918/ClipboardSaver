using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.Win32;

namespace ClipboardSaver
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AddClipboardFormatListener(IntPtr hwnd);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        Boolean LaunchMin = false;

        public Form1()
        {
            InitializeComponent();
            LoadConfig();
            Resize += (s, a) => MinimizeToTray();
            if (LaunchMin) {
                WindowState = FormWindowState.Minimized;
                MinimizeToTray();
            }
            AddClipboardFormatListener(this.Handle);
            NotifyIcon_Tray.DoubleClick += (s, a) => ReturnFromTray();

            MenuItem_Startup.Checked = GetStartWithWindows();
            CheckBox_Startup.Checked = GetStartWithWindows();
            MenuItem_Startup.Click += (s, a) =>
            {
                MenuItem_Startup.Checked = !MenuItem_Startup.Checked;
                CheckBox_Startup.Checked = MenuItem_Startup.Checked;
                SetStartWithWindows(MenuItem_Startup.Checked);
            };
            CheckBox_Startup.Click += (s, a) =>{
                MenuItem_Startup.Checked = CheckBox_Startup.Checked;
                SetStartWithWindows(CheckBox_Startup.Checked); 
            };

            MenuItem_Minimized.Checked = LaunchMin;
            CheckBox_Minimized.Checked = LaunchMin;
            MenuItem_Minimized.Click += (s, a) =>
            {

                LaunchMin = !MenuItem_Minimized.Checked;
                MenuItem_Minimized.Checked = LaunchMin;
                CheckBox_Minimized.Checked = LaunchMin;
                SaveConfig();
            };
            CheckBox_Minimized.Click += (s, a) =>
            {
                LaunchMin = CheckBox_Minimized.Checked;
                MenuItem_Minimized.Checked = LaunchMin;
                SaveConfig();
            };
            
            Button_Browse.Click += (s, a) => BrowseFolder();
            Button_Open.Click += (s, a) => OpenFolder();
            MenuItem_Browse.Click += (s, a) => BrowseFolder();
            MenuItem_Open.Click += (s, a) => OpenFolder();
            MenuItem_Exit.Click += (s, a) => Application.Exit();
        }

        private Boolean GetStartWithWindows() {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                if (key.GetValueNames().Contains("ClipboardSaver"))
                {
                    if (key.GetValue("ClipboardSaver").ToString() == "\"" + Application.ExecutablePath + "\"")
                    {
                        return true;
                    }
                    else
                    {
                        key.DeleteValue("ClipboardSaver", false);
                        return false;
                    }
                }
                else { 
                    return false; 
                }
            }
        }
        private void SetStartWithWindows(Boolean state) {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                if (state)
                {
                    key.SetValue("ClipboardSaver", "\"" + Application.ExecutablePath + "\"");
                }
                else {
                    key.DeleteValue("ClipboardSaver",false);
                }
            }
        }


        public String GetTimeStamp()
        {
            DateTime now = DateTime.Now;
            return String.Join("-", now.Year, now.Month.ToString().PadLeft(2,'0'), now.Day.ToString().PadLeft(2, '0')) +"."+ String.Join("-", now.Hour.ToString().PadLeft(2, '0'), now.Minute.ToString().PadLeft(2, '0'), now.Second.ToString().PadLeft(2, '0'));
        }
        private void SaveConfig()
        {
            File.WriteAllText("ClipboardSaver.conf", TextBox_Path.Text + "\n"+LaunchMin.ToString());
        }
        private void LoadConfig()
        {
            if (File.Exists("ClipboardSaver.conf"))
            {
                var lines =File.ReadAllLines("ClipboardSaver.conf");
                if (Directory.Exists(lines[0].Trim()))
                {
                    TextBox_Path.Text = lines[0].Trim();
                    TextBox_Path.Select(0, 0);
                }
                if (lines[1] == "True") { LaunchMin = true; }
            }
        }

        private void BrowseFolder()
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK&&Directory.Exists(dlg.SelectedPath)) {
                TextBox_Path.Text = dlg.SelectedPath;
                TextBox_Path.Select(0, 0);
                SaveConfig();
            }
        }
        private void OpenFolder()
        {
            try
            {
                System.Diagnostics.Process.Start(TextBox_Path.Text);
            }
            catch { }
        }

        private void MinimizeToTray()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                NotifyIcon_Tray.Visible = true;
                this.ShowInTaskbar = false;
                this.Hide();
            }
        }
        private void ReturnFromTray()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            NotifyIcon_Tray.Visible = false;
            TextBox_Path.Select(0, 0);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x031D)
            {
                if (Clipboard.ContainsImage())
                {
                    try
                    {
                        using (Image img = GetImageFromClipboard())
                        {
                            img.RotateFlip(RotateFlipType.RotateNoneFlipY);
                            img.Save(TextBox_Path.Text + "\\Image." + GetTimeStamp() + ".png", ImageFormat.Png);
                        }
                        label2.Text = "Изображение сохранено";
                        label2.ForeColor = Color.DarkGreen;
                    }
                    catch
                    {
                        label2.Text = "Путь некорректен";
                        label2.ForeColor = Color.DarkRed;
                    }
                }
            }
        }
        private Image GetImageFromClipboard()
        {
            if (Clipboard.GetDataObject() == null) return null;
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Dib))
            {
                var dib = ((System.IO.MemoryStream)Clipboard.GetData(DataFormats.Dib)).ToArray();
                var width = BitConverter.ToInt32(dib, 4);
                var height = BitConverter.ToInt32(dib, 8);
                var bpp = BitConverter.ToInt16(dib, 14);
                if (bpp == 32)
                {
                    var gch = GCHandle.Alloc(dib, GCHandleType.Pinned);
                    Bitmap bmp = null;
                    try
                    {
                        var ptr = new IntPtr((long)gch.AddrOfPinnedObject() + 52);
                        bmp = new Bitmap(width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format32bppArgb, ptr);
                        return new Bitmap(bmp);
                    }
                    finally
                    {
                        gch.Free();
                        if (bmp != null) bmp.Dispose();
                    }
                }
            }
            return Clipboard.ContainsImage() ? Clipboard.GetImage() : null;
        }
    }
}
