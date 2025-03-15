
namespace ColorsEntropy.Views {
    partial class CreateKeyView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateKeyView));
            this.createKeyCBox = new System.Windows.Forms.ComboBox();
            this.createKeyGBox = new System.Windows.Forms.GroupBox();
            this.createKeyBtn = new System.Windows.Forms.Button();
            this.createKeyGBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // createKeyCBox
            // 
            this.createKeyCBox.FormattingEnabled = true;
            this.createKeyCBox.Location = new System.Drawing.Point(18, 41);
            this.createKeyCBox.Name = "createKeyCBox";
            this.createKeyCBox.Size = new System.Drawing.Size(212, 24);
            this.createKeyCBox.TabIndex = 0;
            // 
            // createKeyGBox
            // 
            this.createKeyGBox.Controls.Add(this.createKeyBtn);
            this.createKeyGBox.Controls.Add(this.createKeyCBox);
            this.createKeyGBox.Location = new System.Drawing.Point(12, 12);
            this.createKeyGBox.Name = "createKeyGBox";
            this.createKeyGBox.Size = new System.Drawing.Size(399, 92);
            this.createKeyGBox.TabIndex = 1;
            this.createKeyGBox.TabStop = false;
            this.createKeyGBox.Text = "Selecciona un tamaño para la clave:";
            // 
            // createKeyBtn
            // 
            this.createKeyBtn.Location = new System.Drawing.Point(253, 29);
            this.createKeyBtn.Name = "createKeyBtn";
            this.createKeyBtn.Size = new System.Drawing.Size(128, 47);
            this.createKeyBtn.TabIndex = 1;
            this.createKeyBtn.Text = "ACEPTAR";
            this.createKeyBtn.UseVisualStyleBackColor = true;
            this.createKeyBtn.Click += new System.EventHandler(this.CreateKeyBtn_Click);
            // 
            // CreateKeyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 116);
            this.Controls.Add(this.createKeyGBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateKeyView";
            this.Text = "Creación de clave";
            this.Load += new System.EventHandler(this.CreateKeyView_Load);
            this.Shown += new System.EventHandler(this.CreateKeyView_Shown);
            this.createKeyGBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox createKeyCBox;
        private System.Windows.Forms.GroupBox createKeyGBox;
        private System.Windows.Forms.Button createKeyBtn;
    }
}