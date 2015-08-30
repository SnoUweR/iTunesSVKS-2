namespace iTunesSVKS_2.SettingsControls
{
    partial class SettingsForm
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
            this.lvObjects = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNetwork = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPlayer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.iPlayerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iPlayerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lvObjects
            // 
            this.lvObjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnNetwork,
            this.columnPlayer});
            this.lvObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvObjects.FullRowSelect = true;
            this.lvObjects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvObjects.Location = new System.Drawing.Point(0, 0);
            this.lvObjects.MultiSelect = false;
            this.lvObjects.Name = "lvObjects";
            this.lvObjects.OwnerDraw = true;
            this.lvObjects.Size = new System.Drawing.Size(186, 346);
            this.lvObjects.TabIndex = 0;
            this.lvObjects.UseCompatibleStateImageBehavior = false;
            this.lvObjects.View = System.Windows.Forms.View.Details;
            this.lvObjects.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvObjects_DrawColumnHeader);
            this.lvObjects.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvObjects_DrawSubItem);
            // 
            // columnName
            // 
            this.columnName.Text = "Название";
            // 
            // columnNetwork
            // 
            this.columnNetwork.Text = "N";
            // 
            // columnPlayer
            // 
            this.columnPlayer.Text = "P";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvObjects);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Size = new System.Drawing.Size(598, 346);
            this.splitContainer1.SplitterDistance = 186;
            this.splitContainer1.TabIndex = 1;
            // 
            // iPlayerBindingSource
            // 
            this.iPlayerBindingSource.DataSource = typeof(iTunesSVKS_2.Players.IPlayer);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 346);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iPlayerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvObjects;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnNetwork;
        private System.Windows.Forms.ColumnHeader columnPlayer;
        private System.Windows.Forms.BindingSource iPlayerBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer1;

    }
}