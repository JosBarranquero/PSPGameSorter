namespace PSPGameSorter
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnScan = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.cbWin = new MetroSet_UI.Controls.MetroSetControlBox();
            this.cmbDrive = new MetroSet_UI.Controls.MetroSetComboBox();
            this.lbContent = new MetroSet_UI.Controls.MetroSetListBox();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(177, 412);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Scan drive";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(521, 73);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUp
            // 
            this.btnUp.Enabled = false;
            this.btnUp.Location = new System.Drawing.Point(462, 131);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(28, 23);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Enabled = false;
            this.btnDown.Location = new System.Drawing.Point(462, 177);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(28, 23);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnSort
            // 
            this.btnSort.Enabled = false;
            this.btnSort.Location = new System.Drawing.Point(279, 367);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 6;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // cbWin
            // 
            this.cbWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWin.CloseHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cbWin.CloseHoverForeColor = System.Drawing.Color.White;
            this.cbWin.CloseNormalForeColor = System.Drawing.Color.Gray;
            this.cbWin.DisabledForeColor = System.Drawing.Color.DimGray;
            this.cbWin.IsDerivedStyle = true;
            this.cbWin.Location = new System.Drawing.Point(521, -1);
            this.cbWin.MaximizeBox = false;
            this.cbWin.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cbWin.MaximizeHoverForeColor = System.Drawing.Color.Gray;
            this.cbWin.MaximizeNormalForeColor = System.Drawing.Color.Gray;
            this.cbWin.MinimizeBox = true;
            this.cbWin.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cbWin.MinimizeHoverForeColor = System.Drawing.Color.Gray;
            this.cbWin.MinimizeNormalForeColor = System.Drawing.Color.Gray;
            this.cbWin.Name = "cbWin";
            this.cbWin.Size = new System.Drawing.Size(100, 25);
            this.cbWin.Style = MetroSet_UI.Enums.Style.Light;
            this.cbWin.StyleManager = null;
            this.cbWin.TabIndex = 7;
            this.cbWin.Text = "Nothing";
            this.cbWin.ThemeAuthor = "Narwin";
            this.cbWin.ThemeName = "MetroLite";
            // 
            // cmbDrive
            // 
            this.cmbDrive.AllowDrop = true;
            this.cmbDrive.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmbDrive.BackColor = System.Drawing.Color.Transparent;
            this.cmbDrive.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cmbDrive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmbDrive.CausesValidation = false;
            this.cmbDrive.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmbDrive.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.cmbDrive.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.cmbDrive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cmbDrive.FormattingEnabled = true;
            this.cmbDrive.IsDerivedStyle = true;
            this.cmbDrive.ItemHeight = 20;
            this.cmbDrive.Location = new System.Drawing.Point(430, 382);
            this.cmbDrive.Name = "cmbDrive";
            this.cmbDrive.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cmbDrive.SelectedItemForeColor = System.Drawing.Color.White;
            this.cmbDrive.Size = new System.Drawing.Size(121, 26);
            this.cmbDrive.Style = MetroSet_UI.Enums.Style.Light;
            this.cmbDrive.StyleManager = null;
            this.cmbDrive.TabIndex = 8;
            this.cmbDrive.ThemeAuthor = "Narwin";
            this.cmbDrive.ThemeName = "MetroLite";
            this.cmbDrive.SelectedIndexChanged += new System.EventHandler(this.cmbDrive_SelectedIndexChanged);
            // 
            // lbContent
            // 
            this.lbContent.BackColor = System.Drawing.Color.White;
            this.lbContent.BorderColor = System.Drawing.Color.LightGray;
            this.lbContent.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.lbContent.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.lbContent.Enabled = false;
            this.lbContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbContent.HoveredItemBackColor = System.Drawing.Color.LightGray;
            this.lbContent.HoveredItemColor = System.Drawing.Color.DimGray;
            this.lbContent.IsDerivedStyle = true;
            this.lbContent.ItemHeight = 30;
            this.lbContent.Location = new System.Drawing.Point(61, 95);
            this.lbContent.MultiSelect = false;
            this.lbContent.Name = "lbContent";
            this.lbContent.SelectedIndex = -1;
            this.lbContent.SelectedItem = null;
            this.lbContent.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.lbContent.SelectedItemColor = System.Drawing.Color.White;
            this.lbContent.SelectedText = null;
            this.lbContent.SelectedValue = null;
            this.lbContent.ShowBorder = true;
            this.lbContent.ShowScrollBar = false;
            this.lbContent.Size = new System.Drawing.Size(385, 253);
            this.lbContent.Style = MetroSet_UI.Enums.Style.Light;
            this.lbContent.StyleManager = null;
            this.lbContent.TabIndex = 9;
            this.lbContent.ThemeAuthor = "Narwin";
            this.lbContent.ThemeName = "MetroLite";
            // 
            // frmMain
            // 
            this.AllowResize = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(626, 457);
            this.Controls.Add(this.lbContent);
            this.Controls.Add(this.cmbDrive);
            this.Controls.Add(this.cbWin);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnScan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "PSP Game Sorter";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ClientSizeChanged += new System.EventHandler(this.frmMain_ClientSizeChanged);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnSort;
        private MetroSet_UI.Controls.MetroSetControlBox cbWin;
        private MetroSet_UI.Controls.MetroSetComboBox cmbDrive;
        private MetroSet_UI.Controls.MetroSetListBox lbContent;
    }
}

