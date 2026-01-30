namespace Clock
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelTime = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiTopmost = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowControls = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowDate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowWeekday = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFont = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiForegraundColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiForegroundColor_ControlText = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiForegroundColor_Crimson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiForegroundColor_DarkKhaki = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBackgroundColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBackgroundColor_MenuHighlight = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBackgroundColor_YellowGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBackgroundColor_Orange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiaAlarms = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAutorun = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.checkBoxShowDate = new System.Windows.Forms.CheckBox();
            this.checkBoxShowWeekDay = new System.Windows.Forms.CheckBox();
            this.buttonHideControls = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelTime.ContextMenuStrip = this.contextMenuStrip;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.Location = new System.Drawing.Point(12, 9);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(388, 73);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "CurrentTime";
            this.labelTime.DoubleClick += new System.EventHandler(this.labelTime_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTopmost,
            this.tsmiShowControls,
            this.toolStripSeparator1,
            this.tsmiShowDate,
            this.tsmiShowWeekday,
            this.toolStripSeparator2,
            this.tsmiFont,
            this.tsmiColor,
            this.toolStripSeparator3,
            this.tsmiaAlarms,
            this.toolStripSeparator4,
            this.tsmiAutorun,
            this.toolStripSeparator5,
            this.tsmiExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(241, 355);
            // 
            // tsmiTopmost
            // 
            this.tsmiTopmost.CheckOnClick = true;
            this.tsmiTopmost.Name = "tsmiTopmost";
            this.tsmiTopmost.Size = new System.Drawing.Size(240, 32);
            this.tsmiTopmost.Text = "Topmost";
            // 
            // tsmiShowControls
            // 
            this.tsmiShowControls.Checked = true;
            this.tsmiShowControls.CheckOnClick = true;
            this.tsmiShowControls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiShowControls.Name = "tsmiShowControls";
            this.tsmiShowControls.Size = new System.Drawing.Size(240, 32);
            this.tsmiShowControls.Text = "Show controls";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(237, 6);
            // 
            // tsmiShowDate
            // 
            this.tsmiShowDate.CheckOnClick = true;
            this.tsmiShowDate.Name = "tsmiShowDate";
            this.tsmiShowDate.Size = new System.Drawing.Size(240, 32);
            this.tsmiShowDate.Text = "Show date";
            // 
            // tsmiShowWeekday
            // 
            this.tsmiShowWeekday.CheckOnClick = true;
            this.tsmiShowWeekday.Name = "tsmiShowWeekday";
            this.tsmiShowWeekday.Size = new System.Drawing.Size(240, 32);
            this.tsmiShowWeekday.Text = "Show weekday";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(237, 6);
            // 
            // tsmiFont
            // 
            this.tsmiFont.Name = "tsmiFont";
            this.tsmiFont.Size = new System.Drawing.Size(240, 32);
            this.tsmiFont.Text = "Font";
            // 
            // tsmiColor
            // 
            this.tsmiColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiForegraundColor,
            this.tsmiBackgroundColor});
            this.tsmiColor.Name = "tsmiColor";
            this.tsmiColor.Size = new System.Drawing.Size(240, 32);
            this.tsmiColor.Text = "Color";
            // 
            // tsmiForegraundColor
            // 
            this.tsmiForegraundColor.BackColor = System.Drawing.SystemColors.Control;
            this.tsmiForegraundColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiForegroundColor_ControlText,
            this.tsmiForegroundColor_Crimson,
            this.tsmiForegroundColor_DarkKhaki});
            this.tsmiForegraundColor.Name = "tsmiForegraundColor";
            this.tsmiForegraundColor.Size = new System.Drawing.Size(270, 34);
            this.tsmiForegraundColor.Text = "Foregraund color";
            // 
            // tsmiForegroundColor_ControlText
            // 
            this.tsmiForegroundColor_ControlText.BackColor = System.Drawing.SystemColors.ControlText;
            this.tsmiForegroundColor_ControlText.Checked = true;
            this.tsmiForegroundColor_ControlText.CheckOnClick = true;
            this.tsmiForegroundColor_ControlText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiForegroundColor_ControlText.Name = "tsmiForegroundColor_ControlText";
            this.tsmiForegroundColor_ControlText.Size = new System.Drawing.Size(270, 34);
            this.tsmiForegroundColor_ControlText.Text = " ";
            // 
            // tsmiForegroundColor_Crimson
            // 
            this.tsmiForegroundColor_Crimson.BackColor = System.Drawing.Color.Crimson;
            this.tsmiForegroundColor_Crimson.CheckOnClick = true;
            this.tsmiForegroundColor_Crimson.Name = "tsmiForegroundColor_Crimson";
            this.tsmiForegroundColor_Crimson.Size = new System.Drawing.Size(270, 34);
            this.tsmiForegroundColor_Crimson.Text = " ";
            // 
            // tsmiForegroundColor_DarkKhaki
            // 
            this.tsmiForegroundColor_DarkKhaki.BackColor = System.Drawing.Color.DarkKhaki;
            this.tsmiForegroundColor_DarkKhaki.CheckOnClick = true;
            this.tsmiForegroundColor_DarkKhaki.Name = "tsmiForegroundColor_DarkKhaki";
            this.tsmiForegroundColor_DarkKhaki.Size = new System.Drawing.Size(270, 34);
            this.tsmiForegroundColor_DarkKhaki.Text = " ";
            // 
            // tsmiBackgroundColor
            // 
            this.tsmiBackgroundColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBackgroundColor_MenuHighlight,
            this.tsmiBackgroundColor_YellowGreen,
            this.tsmiBackgroundColor_Orange});
            this.tsmiBackgroundColor.Name = "tsmiBackgroundColor";
            this.tsmiBackgroundColor.Size = new System.Drawing.Size(270, 34);
            this.tsmiBackgroundColor.Text = "Background color";
            // 
            // tsmiBackgroundColor_MenuHighlight
            // 
            this.tsmiBackgroundColor_MenuHighlight.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.tsmiBackgroundColor_MenuHighlight.Checked = true;
            this.tsmiBackgroundColor_MenuHighlight.CheckOnClick = true;
            this.tsmiBackgroundColor_MenuHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiBackgroundColor_MenuHighlight.Name = "tsmiBackgroundColor_MenuHighlight";
            this.tsmiBackgroundColor_MenuHighlight.Size = new System.Drawing.Size(119, 34);
            this.tsmiBackgroundColor_MenuHighlight.Text = " ";
            // 
            // tsmiBackgroundColor_YellowGreen
            // 
            this.tsmiBackgroundColor_YellowGreen.BackColor = System.Drawing.Color.YellowGreen;
            this.tsmiBackgroundColor_YellowGreen.CheckOnClick = true;
            this.tsmiBackgroundColor_YellowGreen.Name = "tsmiBackgroundColor_YellowGreen";
            this.tsmiBackgroundColor_YellowGreen.Size = new System.Drawing.Size(119, 34);
            this.tsmiBackgroundColor_YellowGreen.Text = " ";
            // 
            // tsmiBackgroundColor_Orange
            // 
            this.tsmiBackgroundColor_Orange.BackColor = System.Drawing.Color.Orange;
            this.tsmiBackgroundColor_Orange.CheckOnClick = true;
            this.tsmiBackgroundColor_Orange.Name = "tsmiBackgroundColor_Orange";
            this.tsmiBackgroundColor_Orange.Size = new System.Drawing.Size(119, 34);
            this.tsmiBackgroundColor_Orange.Text = " ";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(237, 6);
            // 
            // tsmiaAlarms
            // 
            this.tsmiaAlarms.Name = "tsmiaAlarms";
            this.tsmiaAlarms.Size = new System.Drawing.Size(240, 32);
            this.tsmiaAlarms.Text = "Alarms";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(237, 6);
            // 
            // tsmiAutorun
            // 
            this.tsmiAutorun.CheckOnClick = true;
            this.tsmiAutorun.Name = "tsmiAutorun";
            this.tsmiAutorun.Size = new System.Drawing.Size(240, 32);
            this.tsmiAutorun.Text = "Autorun";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(237, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.CheckOnClick = true;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(240, 32);
            this.tsmiExit.Text = "Exit";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // checkBoxShowDate
            // 
            this.checkBoxShowDate.AutoSize = true;
            this.checkBoxShowDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxShowDate.Location = new System.Drawing.Point(12, 266);
            this.checkBoxShowDate.Name = "checkBoxShowDate";
            this.checkBoxShowDate.Size = new System.Drawing.Size(194, 41);
            this.checkBoxShowDate.TabIndex = 1;
            this.checkBoxShowDate.Text = "Show date";
            this.checkBoxShowDate.UseVisualStyleBackColor = true;
            this.checkBoxShowDate.CheckedChanged += new System.EventHandler(this.checkBoxShowDate_CheckedChanged);
            // 
            // checkBoxShowWeekDay
            // 
            this.checkBoxShowWeekDay.AutoSize = true;
            this.checkBoxShowWeekDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxShowWeekDay.Location = new System.Drawing.Point(12, 324);
            this.checkBoxShowWeekDay.Name = "checkBoxShowWeekDay";
            this.checkBoxShowWeekDay.Size = new System.Drawing.Size(278, 41);
            this.checkBoxShowWeekDay.TabIndex = 2;
            this.checkBoxShowWeekDay.Text = "Show Week Day";
            this.checkBoxShowWeekDay.UseVisualStyleBackColor = true;
            this.checkBoxShowWeekDay.CheckedChanged += new System.EventHandler(this.checkBoxShowWeekDay_CheckedChanged);
            // 
            // buttonHideControls
            // 
            this.buttonHideControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHideControls.Location = new System.Drawing.Point(12, 371);
            this.buttonHideControls.Name = "buttonHideControls";
            this.buttonHideControls.Size = new System.Drawing.Size(380, 67);
            this.buttonHideControls.TabIndex = 3;
            this.buttonHideControls.Text = "Hide controls";
            this.buttonHideControls.UseVisualStyleBackColor = true;
            this.buttonHideControls.Click += new System.EventHandler(this.buttonHideControls_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Clock PV_522";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(413, 450);
            this.Controls.Add(this.buttonHideControls);
            this.Controls.Add(this.checkBoxShowWeekDay);
            this.Controls.Add(this.checkBoxShowDate);
            this.Controls.Add(this.labelTime);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clock PV_522";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox checkBoxShowDate;
        private System.Windows.Forms.CheckBox checkBoxShowWeekDay;
        private System.Windows.Forms.Button buttonHideControls;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiTopmost;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowControls;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowDate;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowWeekday;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiFont;
        private System.Windows.Forms.ToolStripMenuItem tsmiColor;
        private System.Windows.Forms.ToolStripMenuItem tsmiForegraundColor;
        private System.Windows.Forms.ToolStripMenuItem tsmiBackgroundColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiaAlarms;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiAutorun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiForegroundColor_ControlText;
        private System.Windows.Forms.ToolStripMenuItem tsmiForegroundColor_Crimson;
        private System.Windows.Forms.ToolStripMenuItem tsmiForegroundColor_DarkKhaki;
        private System.Windows.Forms.ToolStripMenuItem tsmiBackgroundColor_MenuHighlight;
        private System.Windows.Forms.ToolStripMenuItem tsmiBackgroundColor_YellowGreen;
        private System.Windows.Forms.ToolStripMenuItem tsmiBackgroundColor_Orange;
    }
}

