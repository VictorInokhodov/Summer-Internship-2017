namespace Inokhodov_Victor_Tanks
{
    partial class InfoForm
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
            this.InfoTextBox = new System.Windows.Forms.RichTextBox();
            this.clTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctlBallDataGridView = new System.Windows.Forms.DataGridView();
            this.ctlTanksDataGridView = new System.Windows.Forms.DataGridView();
            this.clTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlBallDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlTanksDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoTextBox
            // 
            this.InfoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoTextBox.Location = new System.Drawing.Point(0, 0);
            this.InfoTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.InfoTextBox.Name = "InfoTextBox";
            this.InfoTextBox.ReadOnly = true;
            this.InfoTextBox.Size = new System.Drawing.Size(458, 334);
            this.InfoTextBox.TabIndex = 0;
            this.InfoTextBox.Text = "";
            // 
            // clTabControl
            // 
            this.clTabControl.Controls.Add(this.tabPage1);
            this.clTabControl.Controls.Add(this.tabPage2);
            this.clTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clTabControl.Location = new System.Drawing.Point(0, 0);
            this.clTabControl.Name = "clTabControl";
            this.clTabControl.SelectedIndex = 0;
            this.clTabControl.Size = new System.Drawing.Size(458, 334);
            this.clTabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctlBallDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(450, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ball";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctlTanksDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(450, 308);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tanks";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctlBallDataGridView
            // 
            this.ctlBallDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlBallDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlBallDataGridView.Location = new System.Drawing.Point(3, 3);
            this.ctlBallDataGridView.Name = "ctlBallDataGridView";
            this.ctlBallDataGridView.Size = new System.Drawing.Size(444, 302);
            this.ctlBallDataGridView.TabIndex = 0;
            // 
            // ctlTanksDataGridView
            // 
            this.ctlTanksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctlTanksDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlTanksDataGridView.Location = new System.Drawing.Point(3, 3);
            this.ctlTanksDataGridView.Name = "ctlTanksDataGridView";
            this.ctlTanksDataGridView.Size = new System.Drawing.Size(444, 302);
            this.ctlTanksDataGridView.TabIndex = 0;
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 334);
            this.Controls.Add(this.clTabControl);
            this.Controls.Add(this.InfoTextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InfoForm";
            this.Text = "InfoForm";
            this.Load += new System.EventHandler(this.InfoForm_Load);
            this.clTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctlBallDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlTanksDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox InfoTextBox;
        private System.Windows.Forms.TabControl clTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView ctlBallDataGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView ctlTanksDataGridView;
    }
}