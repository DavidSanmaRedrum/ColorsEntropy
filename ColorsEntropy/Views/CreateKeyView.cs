using ColorsEntropy.Controllers;
using ColorsEntropy.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorsEntropy.Views {
    public partial class CreateKeyView : Form {
        public CreateKeyView() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void KeyViewShow() {
            this.ShowDialog();
        }

        private void CreateKeyView_Load(object sender, EventArgs e) {
            Color black = Constants.CONTROLS_GENERAL_COLOR_ONE;
            Color white = Color.White;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.BackColor = black;
            this.FillCombo();
            this.createKeyBtn.ForeColor = black;
            this.createKeyGBox.ForeColor = white;
            this.createKeyCBox.BackColor = black;
            this.createKeyCBox.ForeColor = white;
            this.createKeyCBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.createKeyCBox.SelectedIndex = 0;
        }

        private void FillCombo() {
            int[] sizes = Constants.KEY_SIZES;
            for (int i = 0; i < sizes.Length; i ++) {
                this.createKeyCBox.Items.Add(sizes[i].ToString() + " X " + sizes[i].ToString());
            }
        }

        private void CreateKeyBtn_Click(object sender, EventArgs e) {
            int edgeLength = Convert.ToInt32(this.createKeyCBox.SelectedItem.ToString().Substring(0, 2));
            ColorsEntropyController.SetKeyEdgeLength(edgeLength);
            this.Close();
        }

    }
}
