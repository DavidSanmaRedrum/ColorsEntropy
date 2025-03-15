
namespace ColorsEntropy {
    partial class colorsEntropyView {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(colorsEntropyView));
            this.actionFileBtn = new System.Windows.Forms.Button();
            this.decryptFileBtn = new System.Windows.Forms.Button();
            this.openFileOfl = new System.Windows.Forms.OpenFileDialog();
            this.optionsStripTs = new System.Windows.Forms.ToolStrip();
            this.openFileBtn = new System.Windows.Forms.ToolStripButton();
            this.separatorStrip1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.separatorStrip2 = new System.Windows.Forms.ToolStripSeparator();
            this.actionLbl = new System.Windows.Forms.ToolStripLabel();
            this.optionsStripTs.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionFileBtn
            // 
            this.actionFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionFileBtn.Location = new System.Drawing.Point(119, 64);
            this.actionFileBtn.Name = "actionFileBtn";
            this.actionFileBtn.Size = new System.Drawing.Size(178, 57);
            this.actionFileBtn.TabIndex = 0;
            this.actionFileBtn.Text = " ";
            this.actionFileBtn.UseVisualStyleBackColor = true;
            this.actionFileBtn.Click += new System.EventHandler(this.ActionFileBtn_Click);
            // 
            // decryptFileBtn
            // 
            this.decryptFileBtn.Location = new System.Drawing.Point(0, 0);
            this.decryptFileBtn.Name = "decryptFileBtn";
            this.decryptFileBtn.Size = new System.Drawing.Size(75, 23);
            this.decryptFileBtn.TabIndex = 3;
            // 
            // openFileOfl
            // 
            this.openFileOfl.FileName = "openFileDialog1";
            // 
            // optionsStripTs
            // 
            this.optionsStripTs.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.optionsStripTs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileBtn,
            this.separatorStrip1,
            this.toolStripButton1,
            this.separatorStrip2,
            this.actionLbl});
            this.optionsStripTs.Location = new System.Drawing.Point(0, 0);
            this.optionsStripTs.Name = "optionsStripTs";
            this.optionsStripTs.Size = new System.Drawing.Size(411, 27);
            this.optionsStripTs.TabIndex = 2;
            this.optionsStripTs.Text = "toolStrip1";
            // 
            // openFileBtn
            // 
            this.openFileBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("openFileBtn.Image")));
            this.openFileBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(29, 24);
            this.openFileBtn.Text = "toolStripButton1";
            this.openFileBtn.ToolTipText = "Abrir archivos";
            this.openFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // separatorStrip1
            // 
            this.separatorStrip1.Name = "separatorStrip1";
            this.separatorStrip1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // separatorStrip2
            // 
            this.separatorStrip2.Name = "separatorStrip2";
            this.separatorStrip2.Size = new System.Drawing.Size(6, 27);
            // 
            // actionLbl
            // 
            this.actionLbl.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionLbl.Name = "actionLbl";
            this.actionLbl.Size = new System.Drawing.Size(18, 24);
            this.actionLbl.Text = " ";
            // 
            // colorsEntropyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 166);
            this.Controls.Add(this.optionsStripTs);
            this.Controls.Add(this.decryptFileBtn);
            this.Controls.Add(this.actionFileBtn);
            this.Name = "colorsEntropyView";
            this.Text = "Colors Entropy";
            this.Load += new System.EventHandler(this.ColorsEntropyView_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorsEntropyView_MouseDown);
            this.optionsStripTs.ResumeLayout(false);
            this.optionsStripTs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button actionFileBtn;
        private System.Windows.Forms.Button decryptFileBtn;
        private System.Windows.Forms.OpenFileDialog openFileOfl;
        private System.Windows.Forms.ToolStrip optionsStripTs;
        private System.Windows.Forms.ToolStripButton openFileBtn;
        private System.Windows.Forms.ToolStripLabel actionLbl;
        private System.Windows.Forms.ToolStripSeparator separatorStrip1;
        private System.Windows.Forms.ToolStripSeparator separatorStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

