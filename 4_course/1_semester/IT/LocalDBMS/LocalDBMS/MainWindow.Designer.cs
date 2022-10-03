namespace LocalDBMS
{
    partial class MainWindow
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputPanel = new System.Windows.Forms.Panel();
            this.AcceptInputButton = new System.Windows.Forms.Button();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.MenuStrip.SuspendLayout();
            this.InputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Location = new System.Drawing.Point(12, 27);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(884, 481);
            this.TabControl.TabIndex = 0;
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.Window;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.databaseToolStripMenuItem, this.TableMenuItem });
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(908, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.createToolStripMenuItem, this.openToolStripMenuItem, this.SaveMenuItem });
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.CreateDatabase_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.LoadDatabase_Click);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SaveMenuItem.Text = "Save";
            this.SaveMenuItem.Visible = false;
            // 
            // TableMenuItem
            // 
            this.TableMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.createToolStripMenuItem1, this.deleteToolStripMenuItem });
            this.TableMenuItem.Name = "TableMenuItem";
            this.TableMenuItem.Size = new System.Drawing.Size(46, 20);
            this.TableMenuItem.Text = "Table";
            this.TableMenuItem.Visible = false;
            // 
            // createToolStripMenuItem1
            // 
            this.createToolStripMenuItem1.Name = "createToolStripMenuItem1";
            this.createToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.createToolStripMenuItem1.Text = "Create";
            this.createToolStripMenuItem1.Click += new System.EventHandler(this.CreateTable_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.MouseHover += DeleteItem_Hover;
            // 
            // InputPanel
            // 
            this.InputPanel.Controls.Add(this.AcceptInputButton);
            this.InputPanel.Controls.Add(this.TextBox);
            this.InputPanel.Location = new System.Drawing.Point(0, 27);
            this.InputPanel.Name = "InputPanel";
            this.InputPanel.Size = new System.Drawing.Size(908, 481);
            this.InputPanel.TabIndex = 2;
            this.InputPanel.Visible = false;
            // 
            // AcceptInputButton
            // 
            this.AcceptInputButton.Location = new System.Drawing.Point(521, 219);
            this.AcceptInputButton.Name = "AcceptInputButton";
            this.AcceptInputButton.Size = new System.Drawing.Size(92, 21);
            this.AcceptInputButton.TabIndex = 1;
            this.AcceptInputButton.Text = "Enter";
            this.AcceptInputButton.UseVisualStyleBackColor = true;
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(339, 220);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(156, 20);
            this.TextBox.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(908, 520);
            this.Controls.Add(this.InputPanel);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.MenuStrip);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "LocalDBMS";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.InputPanel.ResumeLayout(false);
            this.InputPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public System.Windows.Forms.Button AcceptInputButton;

        public System.Windows.Forms.Panel InputPanel;
        public System.Windows.Forms.TextBox TextBox;

        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        public System.Windows.Forms.ToolStripMenuItem TableMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

        public System.Windows.Forms.MenuStrip MenuStrip;

        public System.Windows.Forms.TabControl TabControl;

        #endregion
    }
}