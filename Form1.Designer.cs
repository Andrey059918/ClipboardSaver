namespace ClipboardSaver
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TextBox_Path = new System.Windows.Forms.TextBox();
            this.Button_Browse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_Open = new System.Windows.Forms.Button();
            this.NotifyIcon_Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuStrip_Tray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_Browse = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator_1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_Startup = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Minimized = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckBox_Startup = new System.Windows.Forms.CheckBox();
            this.CheckBox_Minimized = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStrip_Tray.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox_Path
            // 
            this.TextBox_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBox_Path.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TextBox_Path.Location = new System.Drawing.Point(10, 25);
            this.TextBox_Path.Margin = new System.Windows.Forms.Padding(0);
            this.TextBox_Path.Name = "TextBox_Path";
            this.TextBox_Path.Size = new System.Drawing.Size(500, 26);
            this.TextBox_Path.TabIndex = 0;
            // 
            // Button_Browse
            // 
            this.Button_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Browse.Location = new System.Drawing.Point(10, 51);
            this.Button_Browse.Margin = new System.Windows.Forms.Padding(0);
            this.Button_Browse.Name = "Button_Browse";
            this.Button_Browse.Size = new System.Drawing.Size(250, 26);
            this.Button_Browse.TabIndex = 1;
            this.Button_Browse.Text = "Изменить папку";
            this.Button_Browse.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Папка для сохранения";
            // 
            // Button_Open
            // 
            this.Button_Open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Open.Location = new System.Drawing.Point(260, 51);
            this.Button_Open.Margin = new System.Windows.Forms.Padding(0);
            this.Button_Open.Name = "Button_Open";
            this.Button_Open.Size = new System.Drawing.Size(250, 26);
            this.Button_Open.TabIndex = 6;
            this.Button_Open.Text = "Открыть папку";
            this.Button_Open.UseVisualStyleBackColor = true;
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
            // ContextMenuStrip_Tray
            // 
            this.ContextMenuStrip_Tray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Browse,
            this.MenuItem_Open,
            this.ToolStripSeparator_1,
            this.MenuItem_Startup,
            this.MenuItem_Minimized,
            this.MenuItem_Exit});
            this.ContextMenuStrip_Tray.Name = "ContextMenuStrip_Tray";
            this.ContextMenuStrip_Tray.Size = new System.Drawing.Size(196, 142);
            // 
            // MenuItem_Browse
            // 
            this.MenuItem_Browse.Name = "MenuItem_Browse";
            this.MenuItem_Browse.Size = new System.Drawing.Size(195, 22);
            this.MenuItem_Browse.Text = "Изменить папку";
            // 
            // MenuItem_Open
            // 
            this.MenuItem_Open.Name = "MenuItem_Open";
            this.MenuItem_Open.Size = new System.Drawing.Size(195, 22);
            this.MenuItem_Open.Text = "Открыть папку";
            // 
            // ToolStripSeparator_1
            // 
            this.ToolStripSeparator_1.Name = "ToolStripSeparator_1";
            this.ToolStripSeparator_1.Size = new System.Drawing.Size(192, 6);
            // 
            // MenuItem_Startup
            // 
            this.MenuItem_Startup.Name = "MenuItem_Startup";
            this.MenuItem_Startup.Size = new System.Drawing.Size(195, 22);
            this.MenuItem_Startup.Text = "Запускать с Windows";
            // 
            // MenuItem_Minimized
            // 
            this.MenuItem_Minimized.Name = "MenuItem_Minimized";
            this.MenuItem_Minimized.Size = new System.Drawing.Size(195, 22);
            this.MenuItem_Minimized.Text = "Запускать свернуто";
            // 
            // CheckBox_Startup
            // 
            this.CheckBox_Startup.AutoSize = true;
            this.CheckBox_Startup.Location = new System.Drawing.Point(10, 111);
            this.CheckBox_Startup.Name = "CheckBox_Startup";
            this.CheckBox_Startup.Size = new System.Drawing.Size(135, 17);
            this.CheckBox_Startup.TabIndex = 9;
            this.CheckBox_Startup.Text = "Запускать с Windows";
            this.CheckBox_Startup.UseVisualStyleBackColor = true;
            // 
            // CheckBox_Minimized
            // 
            this.CheckBox_Minimized.AutoSize = true;
            this.CheckBox_Minimized.Location = new System.Drawing.Point(10, 134);
            this.CheckBox_Minimized.Name = "CheckBox_Minimized";
            this.CheckBox_Minimized.Size = new System.Drawing.Size(128, 17);
            this.CheckBox_Minimized.TabIndex = 10;
            this.CheckBox_Minimized.Text = "Запускать свернуто";
            this.CheckBox_Minimized.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 7;
            // 
            // MenuItem_Exit
            // 
            this.MenuItem_Exit.Name = "MenuItem_Exit";
            this.MenuItem_Exit.Size = new System.Drawing.Size(195, 22);
            this.MenuItem_Exit.Text = "Выход";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 163);
            this.Controls.Add(this.CheckBox_Minimized);
            this.Controls.Add(this.CheckBox_Startup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Button_Open);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_Browse);
            this.Controls.Add(this.TextBox_Path);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Clipboard Saver";
            this.ContextMenuStrip_Tray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_Path;
        private System.Windows.Forms.Button Button_Browse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_Open;
        private System.Windows.Forms.NotifyIcon NotifyIcon_Tray;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_Tray;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Browse;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Open;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator_1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Startup;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Minimized;
        private System.Windows.Forms.CheckBox CheckBox_Startup;
        private System.Windows.Forms.CheckBox CheckBox_Minimized;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Exit;
    }
}

