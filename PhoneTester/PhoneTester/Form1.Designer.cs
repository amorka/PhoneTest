namespace PhoneTester
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
            this.lbInternetStatus = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.окноВизуализацииЗапросовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.базаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотреВсехЗаписейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортИзФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbInternetStatus
            // 
            this.lbInternetStatus.AutoSize = true;
            this.lbInternetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInternetStatus.Location = new System.Drawing.Point(21, 37);
            this.lbInternetStatus.Name = "lbInternetStatus";
            this.lbInternetStatus.Size = new System.Drawing.Size(73, 20);
            this.lbInternetStatus.TabIndex = 0;
            this.lbInternetStatus.Text = "Internet";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.окноВизуализацииЗапросовToolStripMenuItem,
            this.базаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(674, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // окноВизуализацииЗапросовToolStripMenuItem
            // 
            this.окноВизуализацииЗапросовToolStripMenuItem.Name = "окноВизуализацииЗапросовToolStripMenuItem";
            this.окноВизуализацииЗапросовToolStripMenuItem.Size = new System.Drawing.Size(181, 20);
            this.окноВизуализацииЗапросовToolStripMenuItem.Text = "Окно визуализации запросов";
            this.окноВизуализацииЗапросовToolStripMenuItem.Click += new System.EventHandler(this.окноВизуализацииЗапросовToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Загрузить главную страницу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // базаToolStripMenuItem
            // 
            this.базаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.просмотреВсехЗаписейToolStripMenuItem,
            this.импортИзФайлаToolStripMenuItem});
            this.базаToolStripMenuItem.Name = "базаToolStripMenuItem";
            this.базаToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.базаToolStripMenuItem.Text = "База";
            // 
            // просмотреВсехЗаписейToolStripMenuItem
            // 
            this.просмотреВсехЗаписейToolStripMenuItem.Name = "просмотреВсехЗаписейToolStripMenuItem";
            this.просмотреВсехЗаписейToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.просмотреВсехЗаписейToolStripMenuItem.Text = "Просмотре всех записей";
            this.просмотреВсехЗаписейToolStripMenuItem.Click += new System.EventHandler(this.просмотреВсехЗаписейToolStripMenuItem_Click);
            // 
            // импортИзФайлаToolStripMenuItem
            // 
            this.импортИзФайлаToolStripMenuItem.Name = "импортИзФайлаToolStripMenuItem";
            this.импортИзФайлаToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.импортИзФайлаToolStripMenuItem.Text = "Импорт из файла";
            this.импортИзФайлаToolStripMenuItem.Click += new System.EventHandler(this.импортИзФайлаToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbInternetStatus);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbInternetStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem окноВизуализацииЗапросовToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem базаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотреВсехЗаписейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортИзФайлаToolStripMenuItem;
    }
}

