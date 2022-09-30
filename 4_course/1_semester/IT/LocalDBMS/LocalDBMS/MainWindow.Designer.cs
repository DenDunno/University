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
            this.CreateDatabaseButton = new System.Windows.Forms.Button();
            this.DatabaseNameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.LoadDatabaseButton = new System.Windows.Forms.Button();
            this.EntryPanel = new System.Windows.Forms.Panel();
            this.EntryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateDatabaseButton
            // 
            this.CreateDatabaseButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CreateDatabaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateDatabaseButton.Location = new System.Drawing.Point(178, 115);
            this.CreateDatabaseButton.Name = "CreateDatabaseButton";
            this.CreateDatabaseButton.Size = new System.Drawing.Size(133, 48);
            this.CreateDatabaseButton.TabIndex = 0;
            this.CreateDatabaseButton.Text = "Create database";
            this.CreateDatabaseButton.UseVisualStyleBackColor = false;
            this.CreateDatabaseButton.Click += new System.EventHandler(this.CreateDatabaseButton_Click);
            // 
            // DatabaseNameTextBox
            // 
            this.DatabaseNameTextBox.Location = new System.Drawing.Point(345, 143);
            this.DatabaseNameTextBox.Name = "DatabaseNameTextBox";
            this.DatabaseNameTextBox.Size = new System.Drawing.Size(165, 20);
            this.DatabaseNameTextBox.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NameLabel.Location = new System.Drawing.Point(374, 115);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(104, 26);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadDatabaseButton
            // 
            this.LoadDatabaseButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.LoadDatabaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadDatabaseButton.Location = new System.Drawing.Point(178, 219);
            this.LoadDatabaseButton.Name = "LoadDatabaseButton";
            this.LoadDatabaseButton.Size = new System.Drawing.Size(133, 48);
            this.LoadDatabaseButton.TabIndex = 3;
            this.LoadDatabaseButton.Text = "Load database";
            this.LoadDatabaseButton.UseVisualStyleBackColor = false;
            this.LoadDatabaseButton.Click += new System.EventHandler(this.LoadDatabaseButton_Click);
            // 
            // EntryPanel
            // 
            this.EntryPanel.Controls.Add(this.DatabaseNameTextBox);
            this.EntryPanel.Controls.Add(this.NameLabel);
            this.EntryPanel.Controls.Add(this.LoadDatabaseButton);
            this.EntryPanel.Controls.Add(this.CreateDatabaseButton);
            this.EntryPanel.Location = new System.Drawing.Point(87, 69);
            this.EntryPanel.Name = "EntryPanel";
            this.EntryPanel.Size = new System.Drawing.Size(690, 360);
            this.EntryPanel.TabIndex = 4;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(908, 520);
            this.Controls.Add(this.EntryPanel);
            this.DoubleBuffered = true;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "LocalDBMS";
            this.EntryPanel.ResumeLayout(false);
            this.EntryPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        public System.Windows.Forms.Panel EntryPanel;

        public System.Windows.Forms.Button LoadDatabaseButton;

        public System.Windows.Forms.Label NameLabel;

        public System.Windows.Forms.TextBox DatabaseNameTextBox;

        public System.Windows.Forms.Button CreateDatabaseButton;

        #endregion
    }
}