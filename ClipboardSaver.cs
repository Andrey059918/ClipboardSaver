using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClipboardSaver {
    public partial class ClipboardSaver : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AddClipboardFormatListener(IntPtr hwnd);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        List<String> Paths;
        Boolean Pause = false;


        public ClipboardSaver()
        {
            InitializeComponent();

            NotifyIcon_Tray.Visible = true;
            Visible = false;
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;

            LoadConfig();
            RefreshLastDirs();
            SetEvents();
            MenuItem_Startup.Checked = GetStartWithWindows();

            AddClipboardFormatListener(this.Handle);
        }
        private void SetEvents() {
            MenuItem_Startup.Click += (s, a) => {
                MenuItem_Startup.Checked = !MenuItem_Startup.Checked;
                SetStartWithWindows(MenuItem_Startup.Checked);
            };
            MenuItem_Suspend.Click += (s, a) => {
                Pause = !MenuItem_Suspend.Checked;
                MenuItem_Suspend.Checked = Pause;
            };
            MenuItem_Name.Click += (s, a) => {
                MenuItem_Name.Checked = !MenuItem_Name.Checked;
                SaveConfig();
            };
            MenuItem_Browse.Click += (s, a) => BrowseFolder();
            MenuItem_Open.Click += (s, a) => System.Diagnostics.Process.Start(Paths[0]);
            MenuItem_BrowseLast.DropDownItemClicked += (s, a) => {
                String pth = Paths.Find(b => b == a.ClickedItem.Text);
                Paths.Remove(pth);
                Paths.Insert(0, pth);
                MenuItem_Browse.Text = Paths[0];
                SaveConfig();
                RefreshLastDirs();
            };
            MenuItem_Exit.Click += (s, a) => {
                NotifyIcon_Tray.Visible = false;
                Application.Exit();
            };
            FormClosing += (s, a) => NotifyIcon_Tray.Visible = false;
            this.ResizeBegin += (s, a) => {
                WindowState = FormWindowState.Minimized;
                Visible = false;
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            };
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
        private void BrowseFolder() {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK && Directory.Exists(dlg.SelectedPath)) {
                if (Paths.Any(a => a == dlg.SelectedPath)) {
                    Paths.Remove(dlg.SelectedPath);
                    Paths.Insert(0, dlg.SelectedPath);
                }
                else {
                    Paths.Insert(0, dlg.SelectedPath);
                    if (Paths.Count > 10) {
                        Paths.RemoveAt(10);
                    }
                }
                SaveConfig();
                RefreshLastDirs();
            }
            MenuItem_Browse.Text = Paths[0];
        }
        private void SaveConfig()
        {
            File.WriteAllText("ClipboardSaver.conf", MenuItem_Name.Checked.ToString()+"\n"+ String.Join("\n",Paths));
        }
        private void LoadConfig()
        {
            Paths = new List<string>();
            if (File.Exists("ClipboardSaver.conf")) {
                File.ReadAllLines("ClipboardSaver.conf").ToList().ForEach(a => {
                    if (a == "True") {
                        MenuItem_Name.Checked = true;
                    }
                    else if (a == "False") {
                        MenuItem_Name.Checked = false;
                    }
                    else if (Directory.Exists(a.Trim())) {
                        Paths.Add(a.Trim());
                    }
                });
            }
            if (Paths.Count == 0) {
                Paths.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) +"\\ClipboardSaver");
            }
            MenuItem_Browse.Text = Paths[0];
        }
        private void RefreshLastDirs() {
            MenuItem_BrowseLast.DropDownItems.Clear();
            if (Paths.Count > 1) {
                for (int i = 1; i < Paths.Count; i++) {
                    MenuItem_BrowseLast.DropDownItems.Add(Paths[i]);
                }
                MenuItem_BrowseLast.Enabled = true;
            }
            else {
                MenuItem_BrowseLast.Enabled = false;
            }
        }
        
        public String GetTimeStamp() {
            DateTime now = DateTime.Now;
            return String.Join("-", now.Year, now.Month.ToString().PadLeft(2, '0'), now.Day.ToString().PadLeft(2, '0')) + "." + String.Join("-", now.Hour.ToString().PadLeft(2, '0'), now.Minute.ToString().PadLeft(2, '0'), now.Second.ToString().PadLeft(2, '0'));
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x031D)
            {
                if (Clipboard.ContainsImage() && !Pause) {
                    using (Image img = GetImageFromClipboard()) {
                        img.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        Directory.CreateDirectory(Paths[0]);
                        String imgName = "Image." + GetTimeStamp();
                        if (MenuItem_Name.Checked) {
                            Boolean repeat = true;
                            while (repeat) {
                                String name = Interaction.InputBox("Имя файла (без расширения):", "Сохранить изображение", imgName);
                                if (String.IsNullOrWhiteSpace(name)) {
                                    repeat = false;
                                }
                                else if (Path.GetInvalidFileNameChars().Any(a=>name.Contains(a))) {
                                    if (MessageBox.Show("Введено некорректное имя файла. Повторить?", "Сохранить изображение", MessageBoxButtons.OKCancel) == DialogResult.Cancel) {
                                        repeat = false;
                                    }
                                }
                                else if (File.Exists(Paths[0] + "\\" + name + ".png")) {
                                    if (MessageBox.Show("Такой файл уже существует. Заменить?", "Сохранить изображение", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                                        imgName = name;
                                        repeat = false;
                                    }
                                }
                                else {
                                    imgName = name;
                                    repeat = false;
                                }
                            }
                        }
                        img.Save(Paths[0] + "\\" + imgName + ".png", ImageFormat.Png);
                    }
                }
            }
        }
        private Image GetImageFromClipboard()
        {
            if (Clipboard.GetDataObject() == null) return null;
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Dib)) {
                try {
                    var dib = ((MemoryStream)(Clipboard.GetDataObject().GetData(DataFormats.Dib))).ToArray();
                    var width = BitConverter.ToInt32(dib, 4);
                    var height = BitConverter.ToInt32(dib, 8);
                    var bpp = BitConverter.ToInt16(dib, 14);
                    if (bpp == 32) {
                        var gch = GCHandle.Alloc(dib, GCHandleType.Pinned);
                        Bitmap bmp = null;
                        try {
                            var ptr = new IntPtr((long)gch.AddrOfPinnedObject() + 52);
                            bmp = new Bitmap(width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format32bppArgb, ptr);
                            return new Bitmap(bmp);
                        }
                        finally {
                            gch.Free();
                            if (bmp != null)
                                bmp.Dispose();
                        }
                    }
                }
                catch { }
            }
            return Clipboard.ContainsImage() ? Clipboard.GetImage() : null;
        }
    }
}
