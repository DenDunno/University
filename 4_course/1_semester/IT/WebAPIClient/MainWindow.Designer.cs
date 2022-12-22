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
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddColumnMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputPanel = new System.Windows.Forms.Panel();
            this.DeleteDatabaseTextBox = new System.Windows.Forms.TextBox();
            this.DeleteDatabaseButton = new System.Windows.Forms.Button();
            this.SetupDatabaseTextbox = new System.Windows.Forms.TextBox();
            this.SetupDatabaseButton = new System.Windows.Forms.Button();
            this.GetDatabaseTextBox = new System.Windows.Forms.TextBox();
            this.SaveDatabaseTextButton = new System.Windows.Forms.TextBox();
            this.Output = new System.Windows.Forms.RichTextBox();
            this.AddRowTextBox = new System.Windows.Forms.TextBox();
            this.AddRowButton = new System.Windows.Forms.Button();
            this.CreateDatabaseTextBox = new System.Windows.Forms.TextBox();
            this.AddColumnTextBox = new System.Windows.Forms.TextBox();
            this.CreateDatabaseButton = new System.Windows.Forms.Button();
            this.AddColumnButton = new System.Windows.Forms.Button();
            this.GetDatabaseButton = new System.Windows.Forms.Button();
            this.RemoveRowIndexTextBox = new System.Windows.Forms.TextBox();
            this.PutColumnIndexTextBox = new System.Windows.Forms.TextBox();
            this.RemoveRowTextBox = new System.Windows.Forms.TextBox();
            this.PutValueButton = new System.Windows.Forms.Button();
            this.RemoveRowButton = new System.Windows.Forms.Button();
            this.PutValueTextBox = new System.Windows.Forms.TextBox();
            this.RemoveColumnIndexTextBox = new System.Windows.Forms.TextBox();
            this.SaveDatabaseButton = new System.Windows.Forms.Button();
            this.RemoveColumnTextBox = new System.Windows.Forms.TextBox();
            this.CreateTableButton = new System.Windows.Forms.Button();
            this.RemoveColumnButton = new System.Windows.Forms.Button();
            this.PutRowIndexTextBox = new System.Windows.Forms.TextBox();
            this.DeleteTableTextBox = new System.Windows.Forms.TextBox();
            this.CreateTableTextBox = new System.Windows.Forms.TextBox();
            this.DeleteTableButton = new System.Windows.Forms.Button();
            this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.miniToolStrip.SuspendLayout();
            this.InputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Location = new System.Drawing.Point(16, 33);
            this.TabControl.Margin = new System.Windows.Forms.Padding(4);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1179, 592);
            this.TabControl.TabIndex = 0;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.SystemColors.Window;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.databaseToolStripMenuItem, this.TableMenuItem});
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.miniToolStrip.Size = new System.Drawing.Size(1211, 28);
            this.miniToolStrip.TabIndex = 1;
            this.miniToolStrip.Visible = false;
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.createToolStripMenuItem, this.openToolStripMenuItem, this.SaveMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.Size = new System.Drawing.Size(121, 24);
            this.SaveMenuItem.Text = "Save";
            this.SaveMenuItem.Visible = false;
            // 
            // TableMenuItem
            // 
            this.TableMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.createToolStripMenuItem1, this.deleteToolStripMenuItem, this.AddColumnMenuItem});
            this.TableMenuItem.Name = "TableMenuItem";
            this.TableMenuItem.Size = new System.Drawing.Size(56, 24);
            this.TableMenuItem.Text = "Table";
            this.TableMenuItem.Visible = false;
            // 
            // createToolStripMenuItem1
            // 
            this.createToolStripMenuItem1.Name = "createToolStripMenuItem1";
            this.createToolStripMenuItem1.Size = new System.Drawing.Size(159, 24);
            this.createToolStripMenuItem1.Text = "Create";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // AddColumnMenuItem
            // 
            this.AddColumnMenuItem.Name = "AddColumnMenuItem";
            this.AddColumnMenuItem.Size = new System.Drawing.Size(159, 24);
            this.AddColumnMenuItem.Text = "Add column";
            this.AddColumnMenuItem.Visible = false;
            // 
            // InputPanel
            // 
            this.InputPanel.Controls.Add(this.DeleteDatabaseTextBox);
            this.InputPanel.Controls.Add(this.DeleteDatabaseButton);
            this.InputPanel.Controls.Add(this.SetupDatabaseTextbox);
            this.InputPanel.Controls.Add(this.SetupDatabaseButton);
            this.InputPanel.Controls.Add(this.GetDatabaseTextBox);
            this.InputPanel.Controls.Add(this.SaveDatabaseTextButton);
            this.InputPanel.Controls.Add(this.Output);
            this.InputPanel.Controls.Add(this.AddRowTextBox);
            this.InputPanel.Controls.Add(this.AddRowButton);
            this.InputPanel.Controls.Add(this.CreateDatabaseTextBox);
            this.InputPanel.Controls.Add(this.AddColumnTextBox);
            this.InputPanel.Controls.Add(this.CreateDatabaseButton);
            this.InputPanel.Controls.Add(this.AddColumnButton);
            this.InputPanel.Controls.Add(this.GetDatabaseButton);
            this.InputPanel.Controls.Add(this.RemoveRowIndexTextBox);
            this.InputPanel.Controls.Add(this.PutColumnIndexTextBox);
            this.InputPanel.Controls.Add(this.RemoveRowTextBox);
            this.InputPanel.Controls.Add(this.PutValueButton);
            this.InputPanel.Controls.Add(this.RemoveRowButton);
            this.InputPanel.Controls.Add(this.PutValueTextBox);
            this.InputPanel.Controls.Add(this.RemoveColumnIndexTextBox);
            this.InputPanel.Controls.Add(this.SaveDatabaseButton);
            this.InputPanel.Controls.Add(this.RemoveColumnTextBox);
            this.InputPanel.Controls.Add(this.CreateTableButton);
            this.InputPanel.Controls.Add(this.RemoveColumnButton);
            this.InputPanel.Controls.Add(this.PutRowIndexTextBox);
            this.InputPanel.Controls.Add(this.DeleteTableTextBox);
            this.InputPanel.Controls.Add(this.CreateTableTextBox);
            this.InputPanel.Controls.Add(this.DeleteTableButton);
            this.InputPanel.Location = new System.Drawing.Point(0, 33);
            this.InputPanel.Margin = new System.Windows.Forms.Padding(4);
            this.InputPanel.Name = "InputPanel";
            this.InputPanel.Size = new System.Drawing.Size(1211, 592);
            this.InputPanel.TabIndex = 2;
            // 
            // DeleteDatabaseTextBox
            // 
            this.DeleteDatabaseTextBox.Location = new System.Drawing.Point(266, 20);
            this.DeleteDatabaseTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteDatabaseTextBox.Name = "DeleteDatabaseTextBox";
            this.DeleteDatabaseTextBox.Size = new System.Drawing.Size(140, 22);
            this.DeleteDatabaseTextBox.TabIndex = 30;
            // 
            // DeleteDatabaseButton
            // 
            this.DeleteDatabaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.DeleteDatabaseButton.Location = new System.Drawing.Point(414, 8);
            this.DeleteDatabaseButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteDatabaseButton.Name = "DeleteDatabaseButton";
            this.DeleteDatabaseButton.Size = new System.Drawing.Size(180, 40);
            this.DeleteDatabaseButton.TabIndex = 29;
            this.DeleteDatabaseButton.Text = "Delete database";
            this.DeleteDatabaseButton.UseVisualStyleBackColor = true;
            this.DeleteDatabaseButton.Click += new System.EventHandler(this.DeleteDatabaseButton_Click);
            // 
            // SetupDatabaseTextbox
            // 
            this.SetupDatabaseTextbox.Location = new System.Drawing.Point(266, 68);
            this.SetupDatabaseTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.SetupDatabaseTextbox.Name = "SetupDatabaseTextbox";
            this.SetupDatabaseTextbox.Size = new System.Drawing.Size(140, 22);
            this.SetupDatabaseTextbox.TabIndex = 28;
            // 
            // SetupDatabaseButton
            // 
            this.SetupDatabaseButton.BackColor = System.Drawing.SystemColors.Window;
            this.SetupDatabaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.SetupDatabaseButton.Location = new System.Drawing.Point(414, 56);
            this.SetupDatabaseButton.Margin = new System.Windows.Forms.Padding(4);
            this.SetupDatabaseButton.Name = "SetupDatabaseButton";
            this.SetupDatabaseButton.Size = new System.Drawing.Size(180, 40);
            this.SetupDatabaseButton.TabIndex = 27;
            this.SetupDatabaseButton.Text = "Setup database";
            this.SetupDatabaseButton.UseVisualStyleBackColor = false;
            this.SetupDatabaseButton.Click += new System.EventHandler(this.SetupDatabaseButton_Click);
            // 
            // GetDatabaseTextBox
            // 
            this.GetDatabaseTextBox.Location = new System.Drawing.Point(266, 116);
            this.GetDatabaseTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.GetDatabaseTextBox.Name = "GetDatabaseTextBox";
            this.GetDatabaseTextBox.Size = new System.Drawing.Size(140, 22);
            this.GetDatabaseTextBox.TabIndex = 26;
            // 
            // SaveDatabaseTextButton
            // 
            this.SaveDatabaseTextButton.Location = new System.Drawing.Point(266, 164);
            this.SaveDatabaseTextButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveDatabaseTextButton.Name = "SaveDatabaseTextButton";
            this.SaveDatabaseTextButton.Size = new System.Drawing.Size(140, 22);
            this.SaveDatabaseTextButton.TabIndex = 25;
            // 
            // Output
            // 
            this.Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.Output.Location = new System.Drawing.Point(665, 0);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(376, 592);
            this.Output.TabIndex = 12;
            this.Output.Text = "";
            // 
            // AddRowTextBox
            // 
            this.AddRowTextBox.Location = new System.Drawing.Point(266, 406);
            this.AddRowTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddRowTextBox.Name = "AddRowTextBox";
            this.AddRowTextBox.Size = new System.Drawing.Size(140, 22);
            this.AddRowTextBox.TabIndex = 24;
            // 
            // AddRowButton
            // 
            this.AddRowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.AddRowButton.Location = new System.Drawing.Point(414, 394);
            this.AddRowButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddRowButton.Name = "AddRowButton";
            this.AddRowButton.Size = new System.Drawing.Size(180, 40);
            this.AddRowButton.TabIndex = 23;
            this.AddRowButton.Text = "Add row";
            this.AddRowButton.UseVisualStyleBackColor = true;
            this.AddRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // CreateDatabaseTextBox
            // 
            this.CreateDatabaseTextBox.Location = new System.Drawing.Point(266, 212);
            this.CreateDatabaseTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CreateDatabaseTextBox.Name = "CreateDatabaseTextBox";
            this.CreateDatabaseTextBox.Size = new System.Drawing.Size(140, 22);
            this.CreateDatabaseTextBox.TabIndex = 11;
            // 
            // AddColumnTextBox
            // 
            this.AddColumnTextBox.Location = new System.Drawing.Point(266, 358);
            this.AddColumnTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddColumnTextBox.Name = "AddColumnTextBox";
            this.AddColumnTextBox.Size = new System.Drawing.Size(140, 22);
            this.AddColumnTextBox.TabIndex = 22;
            // 
            // CreateDatabaseButton
            // 
            this.CreateDatabaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.CreateDatabaseButton.Location = new System.Drawing.Point(414, 200);
            this.CreateDatabaseButton.Margin = new System.Windows.Forms.Padding(4);
            this.CreateDatabaseButton.Name = "CreateDatabaseButton";
            this.CreateDatabaseButton.Size = new System.Drawing.Size(180, 40);
            this.CreateDatabaseButton.TabIndex = 10;
            this.CreateDatabaseButton.Text = "Create database";
            this.CreateDatabaseButton.UseVisualStyleBackColor = true;
            this.CreateDatabaseButton.Click += new System.EventHandler(this.CreateDatabaseButton_Click);
            // 
            // AddColumnButton
            // 
            this.AddColumnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.AddColumnButton.Location = new System.Drawing.Point(414, 346);
            this.AddColumnButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddColumnButton.Name = "AddColumnButton";
            this.AddColumnButton.Size = new System.Drawing.Size(180, 40);
            this.AddColumnButton.TabIndex = 21;
            this.AddColumnButton.Text = "Add column";
            this.AddColumnButton.UseVisualStyleBackColor = true;
            this.AddColumnButton.Click += new System.EventHandler(this.AddColumnButton_Click);
            // 
            // GetDatabaseButton
            // 
            this.GetDatabaseButton.BackColor = System.Drawing.SystemColors.Window;
            this.GetDatabaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.GetDatabaseButton.Location = new System.Drawing.Point(414, 104);
            this.GetDatabaseButton.Margin = new System.Windows.Forms.Padding(4);
            this.GetDatabaseButton.Name = "GetDatabaseButton";
            this.GetDatabaseButton.Size = new System.Drawing.Size(180, 40);
            this.GetDatabaseButton.TabIndex = 7;
            this.GetDatabaseButton.Text = "Get database";
            this.GetDatabaseButton.UseVisualStyleBackColor = false;
            this.GetDatabaseButton.Click += new System.EventHandler(this.GetDatabaseButton_Click);
            // 
            // RemoveRowIndexTextBox
            // 
            this.RemoveRowIndexTextBox.Location = new System.Drawing.Point(188, 502);
            this.RemoveRowIndexTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveRowIndexTextBox.Name = "RemoveRowIndexTextBox";
            this.RemoveRowIndexTextBox.Size = new System.Drawing.Size(70, 22);
            this.RemoveRowIndexTextBox.TabIndex = 20;
            // 
            // PutColumnIndexTextBox
            // 
            this.PutColumnIndexTextBox.Location = new System.Drawing.Point(188, 550);
            this.PutColumnIndexTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PutColumnIndexTextBox.Name = "PutColumnIndexTextBox";
            this.PutColumnIndexTextBox.Size = new System.Drawing.Size(70, 22);
            this.PutColumnIndexTextBox.TabIndex = 0;
            // 
            // RemoveRowTextBox
            // 
            this.RemoveRowTextBox.Location = new System.Drawing.Point(266, 502);
            this.RemoveRowTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveRowTextBox.Name = "RemoveRowTextBox";
            this.RemoveRowTextBox.Size = new System.Drawing.Size(140, 22);
            this.RemoveRowTextBox.TabIndex = 19;
            // 
            // PutValueButton
            // 
            this.PutValueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.PutValueButton.Location = new System.Drawing.Point(414, 538);
            this.PutValueButton.Margin = new System.Windows.Forms.Padding(4);
            this.PutValueButton.Name = "PutValueButton";
            this.PutValueButton.Size = new System.Drawing.Size(180, 40);
            this.PutValueButton.TabIndex = 1;
            this.PutValueButton.Text = "Put value";
            this.PutValueButton.UseVisualStyleBackColor = true;
            this.PutValueButton.Click += new System.EventHandler(this.PutValueButton_Click);
            // 
            // RemoveRowButton
            // 
            this.RemoveRowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.RemoveRowButton.Location = new System.Drawing.Point(414, 490);
            this.RemoveRowButton.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveRowButton.Name = "RemoveRowButton";
            this.RemoveRowButton.Size = new System.Drawing.Size(180, 40);
            this.RemoveRowButton.TabIndex = 18;
            this.RemoveRowButton.Text = "Remove row";
            this.RemoveRowButton.UseVisualStyleBackColor = true;
            this.RemoveRowButton.Click += new System.EventHandler(this.RemoveRowButton_Click);
            // 
            // PutValueTextBox
            // 
            this.PutValueTextBox.Location = new System.Drawing.Point(266, 550);
            this.PutValueTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PutValueTextBox.Name = "PutValueTextBox";
            this.PutValueTextBox.Size = new System.Drawing.Size(140, 22);
            this.PutValueTextBox.TabIndex = 3;
            // 
            // RemoveColumnIndexTextBox
            // 
            this.RemoveColumnIndexTextBox.Location = new System.Drawing.Point(188, 454);
            this.RemoveColumnIndexTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveColumnIndexTextBox.Name = "RemoveColumnIndexTextBox";
            this.RemoveColumnIndexTextBox.Size = new System.Drawing.Size(70, 22);
            this.RemoveColumnIndexTextBox.TabIndex = 17;
            // 
            // SaveDatabaseButton
            // 
            this.SaveDatabaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.SaveDatabaseButton.Location = new System.Drawing.Point(414, 152);
            this.SaveDatabaseButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveDatabaseButton.Name = "SaveDatabaseButton";
            this.SaveDatabaseButton.Size = new System.Drawing.Size(180, 40);
            this.SaveDatabaseButton.TabIndex = 5;
            this.SaveDatabaseButton.Text = "Save database";
            this.SaveDatabaseButton.UseVisualStyleBackColor = true;
            this.SaveDatabaseButton.Click += new System.EventHandler(this.SaveDatabaseButton_Click);
            // 
            // RemoveColumnTextBox
            // 
            this.RemoveColumnTextBox.Location = new System.Drawing.Point(266, 454);
            this.RemoveColumnTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveColumnTextBox.Name = "RemoveColumnTextBox";
            this.RemoveColumnTextBox.Size = new System.Drawing.Size(140, 22);
            this.RemoveColumnTextBox.TabIndex = 16;
            // 
            // CreateTableButton
            // 
            this.CreateTableButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.CreateTableButton.Location = new System.Drawing.Point(414, 248);
            this.CreateTableButton.Margin = new System.Windows.Forms.Padding(4);
            this.CreateTableButton.Name = "CreateTableButton";
            this.CreateTableButton.Size = new System.Drawing.Size(180, 40);
            this.CreateTableButton.TabIndex = 8;
            this.CreateTableButton.Text = "Create table";
            this.CreateTableButton.UseVisualStyleBackColor = true;
            this.CreateTableButton.Click += new System.EventHandler(this.CreateTableButton_Click);
            // 
            // RemoveColumnButton
            // 
            this.RemoveColumnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.RemoveColumnButton.Location = new System.Drawing.Point(414, 442);
            this.RemoveColumnButton.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveColumnButton.Name = "RemoveColumnButton";
            this.RemoveColumnButton.Size = new System.Drawing.Size(180, 40);
            this.RemoveColumnButton.TabIndex = 15;
            this.RemoveColumnButton.Text = "Remove column";
            this.RemoveColumnButton.UseVisualStyleBackColor = true;
            this.RemoveColumnButton.Click += new System.EventHandler(this.RemoveColumnButton_Click);
            // 
            // PutRowIndexTextBox
            // 
            this.PutRowIndexTextBox.Location = new System.Drawing.Point(110, 550);
            this.PutRowIndexTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PutRowIndexTextBox.Name = "PutRowIndexTextBox";
            this.PutRowIndexTextBox.Size = new System.Drawing.Size(70, 22);
            this.PutRowIndexTextBox.TabIndex = 2;
            // 
            // DeleteTableTextBox
            // 
            this.DeleteTableTextBox.Location = new System.Drawing.Point(266, 308);
            this.DeleteTableTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteTableTextBox.Name = "DeleteTableTextBox";
            this.DeleteTableTextBox.Size = new System.Drawing.Size(140, 22);
            this.DeleteTableTextBox.TabIndex = 14;
            // 
            // CreateTableTextBox
            // 
            this.CreateTableTextBox.Location = new System.Drawing.Point(266, 260);
            this.CreateTableTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CreateTableTextBox.Name = "CreateTableTextBox";
            this.CreateTableTextBox.Size = new System.Drawing.Size(140, 22);
            this.CreateTableTextBox.TabIndex = 9;
            // 
            // DeleteTableButton
            // 
            this.DeleteTableButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.DeleteTableButton.Location = new System.Drawing.Point(414, 296);
            this.DeleteTableButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteTableButton.Name = "DeleteTableButton";
            this.DeleteTableButton.Size = new System.Drawing.Size(180, 40);
            this.DeleteTableButton.TabIndex = 13;
            this.DeleteTableButton.Text = "Delete table";
            this.DeleteTableButton.UseVisualStyleBackColor = true;
            this.DeleteTableButton.Click += new System.EventHandler(this.DeleteTableButton_Click);
            // 
            // dataGridBoolColumn1
            // 
            this.dataGridBoolColumn1.Width = -1;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.Width = -1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1211, 640);
            this.Controls.Add(this.InputPanel);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.miniToolStrip);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.miniToolStrip.ResumeLayout(false);
            this.miniToolStrip.PerformLayout();
            this.InputPanel.ResumeLayout(false);
            this.InputPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        public System.Windows.Forms.TextBox DeleteDatabaseTextBox;
        public System.Windows.Forms.Button DeleteDatabaseButton;

        public System.Windows.Forms.TextBox SetupDatabaseTextbox;
        public System.Windows.Forms.Button SetupDatabaseButton;

        public System.Windows.Forms.TextBox SaveDatabaseTextButton;
        public System.Windows.Forms.TextBox GetDatabaseTextBox;

        public System.Windows.Forms.TextBox DeleteTableTextBox;
        public System.Windows.Forms.Button DeleteTableButton;
        public System.Windows.Forms.TextBox RemoveColumnTextBox;
        public System.Windows.Forms.Button RemoveColumnButton;
        public System.Windows.Forms.TextBox RemoveColumnIndexTextBox;
        public System.Windows.Forms.TextBox RemoveRowIndexTextBox;
        public System.Windows.Forms.TextBox RemoveRowTextBox;
        public System.Windows.Forms.Button RemoveRowButton;
        public System.Windows.Forms.TextBox AddColumnTextBox;
        public System.Windows.Forms.Button AddColumnButton;
        public System.Windows.Forms.TextBox AddRowTextBox;
        public System.Windows.Forms.Button AddRowButton;

        private System.Windows.Forms.RichTextBox Output;

        public System.Windows.Forms.Button GetDatabaseButton;

        public System.Windows.Forms.TextBox CreateTableTextBox;
        public System.Windows.Forms.Button CreateTableButton;
        public System.Windows.Forms.TextBox CreateDatabaseTextBox;
        public System.Windows.Forms.Button CreateDatabaseButton;

        public System.Windows.Forms.TextBox PutRowIndexTextBox;
        public System.Windows.Forms.TextBox PutValueTextBox;
        public System.Windows.Forms.Button SaveDatabaseButton;

        public System.Windows.Forms.ToolStripMenuItem AddColumnMenuItem;

        private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;

        public System.Windows.Forms.Button PutValueButton;

        public System.Windows.Forms.Panel InputPanel;
        public System.Windows.Forms.TextBox PutColumnIndexTextBox;

        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        public System.Windows.Forms.ToolStripMenuItem TableMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

        private System.Windows.Forms.MenuStrip miniToolStrip;

        public System.Windows.Forms.TabControl TabControl;

        #endregion
    }
}