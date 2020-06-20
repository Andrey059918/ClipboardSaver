namespace ClipboardSaver
{
    partial class ClipboardSaver
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClipboardSaver));
			this.ContextMenuStrip_Tray = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MenuItem_Browse = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem_BrowseLast = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripSeparator_1 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItem_Suspend = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem_Startup = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.NotifyIcon_Tray = new System.Windows.Forms.NotifyIcon(this.components);
			this.MenuItem_Name = new System.Windows.Forms.ToolStripMenuItem();
			this.ContextMenuStrip_Tray.SuspendLayout();
			this.SuspendLayout();
			// 
			// ContextMenuStrip_Tray
			// 
			this.ContextMenuStrip_Tray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Browse,
            this.MenuItem_BrowseLast,
            this.MenuItem_Open,
            this.MenuItem_Name,
            this.ToolStripSeparator_1,
            this.MenuItem_Suspend,
            this.MenuItem_Startup,
            this.MenuItem_Exit});
			this.ContextMenuStrip_Tray.Name = "ContextMenuStrip_Tray";
			this.ContextMenuStrip_Tray.Size = new System.Drawing.Size(237, 186);
			// 
			// MenuItem_Browse
			// 
			this.MenuItem_Browse.Name = "MenuItem_Browse";
			this.MenuItem_Browse.Size = new System.Drawing.Size(236, 22);
			this.MenuItem_Browse.Text = "Изменить папку";
			// 
			// MenuItem_BrowseLast
			// 
			this.MenuItem_BrowseLast.Name = "MenuItem_BrowseLast";
			this.MenuItem_BrowseLast.Size = new System.Drawing.Size(236, 22);
			this.MenuItem_BrowseLast.Text = "Последние папки";
			// 
			// MenuItem_Open
			// 
			this.MenuItem_Open.Name = "MenuItem_Open";
			this.MenuItem_Open.Size = new System.Drawing.Size(236, 22);
			this.MenuItem_Open.Text = "Открыть папку";
			// 
			// ToolStripSeparator_1
			// 
			this.ToolStripSeparator_1.Name = "ToolStripSeparator_1";
			this.ToolStripSeparator_1.Size = new System.Drawing.Size(233, 6);
			// 
			// MenuItem_Suspend
			// 
			this.MenuItem_Suspend.Name = "MenuItem_Suspend";
			this.MenuItem_Suspend.Size = new System.Drawing.Size(236, 22);
			this.MenuItem_Suspend.Text = "Приостановить сохранение";
			// 
			// MenuItem_Startup
			// 
			this.MenuItem_Startup.Name = "MenuItem_Startup";
			this.MenuItem_Startup.Size = new System.Drawing.Size(236, 22);
			this.MenuItem_Startup.Text = "Запускать с Windows";
			// 
			// MenuItem_Exit
			// 
			this.MenuItem_Exit.Name = "MenuItem_Exit";
			this.MenuItem_Exit.Size = new System.Drawing.Size(236, 22);
			this.MenuItem_Exit.Text = "Выход";
			// 
			// NotifyIcon_Tray
			// 
			this.NotifyIcon_Tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.NotifyIcon_Tray.BalloonTipText = "Программа работает в фоновом режиме";
			this.NotifyIcon_Tray.BalloonTipTitle = "Clipboard Saver";
			this.NotifyIcon_Tray.ContextMenuStrip = this.ContextMenuStrip_Tray;
			this.NotifyIcon_Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon_Tray.Icon")));
			this.NotifyIcon_Tray.Text = "Clipboard Saver";
			// 
			// MenuItem_Name
			// 
			this.MenuItem_Name.Name = "MenuItem_Name";
			this.MenuItem_Name.Size = new System.Drawing.Size(236, 22);
			this.MenuItem_Name.Text = "Запрашивать имя";
			// 
			// ClipboardSaver
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(268, 38);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ClipboardSaver";
			this.Text = "Clipboard Saver";
			this.ContextMenuStrip_Tray.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_Tray;
        private System.Windows.Forms.NotifyIcon NotifyIcon_Tray;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Startup;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_1;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Suspend;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Open;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Browse;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_BrowseLast;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Name;
	}
}

