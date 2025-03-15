using ColorsEntropy.Controllers;
using ColorsEntropy.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ColorsEntropy {
    public partial class colorsEntropyView : Form {

        private string[] filePaths = null; // Multiselección
        private bool action = true;

        public colorsEntropyView() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Opacity = 0;
        }

        private void ColorsEntropyView_Load(object sender, EventArgs e) {
            if (!File.Exists(Constants.SAVE_KEY_PATH)) {
                ColorsEntropyController.MakeCreateKeyView();
                int edgeLength;
                if ((edgeLength = ColorsEntropyController.GetKeyEdgeLength()) > 0) {
                    ColorsEntropyController.CreateKey(edgeLength);
                    MessageBox.Show("Se ha creado la clave.");
                }
                Application.Exit();
            } else {
                if (!ColorsEntropyController.CheckKey()) {
                    MessageBox.Show("Hay un error con la clave.");
                    Application.Exit();
                }
                this.Opacity = 1;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.BackColor = Constants.CONTROLS_GENERAL_COLOR_ONE;
                this.actionLbl.Text = Constants.NEUTRAL_STATE;
                this.actionLbl.ForeColor = Color.White;
                this.optionsStripTs.BackColor = Constants.CONTROLS_GENERAL_COLOR_TWO;
                actionFileBtn.Enabled = false;
                actionFileBtn.Text = Constants.DISABLED_STATE_ACTION_BUTTON;
                openFileOfl.Filter = Constants.OPEN_FILE_DIALOG_FILTER;
                openFileOfl.FileName = "";
                openFileOfl.Multiselect = true;
            }
        }

        private void ActionFileBtn_Click(object sender, EventArgs e) {
            if (!action) {
                ColorsEntropyController.EncryptFiles(this.filePaths);
            } else {
                ColorsEntropyController.DecryptFiles(this.filePaths);
            }
            actionFileBtn.Text = Constants.DISABLED_STATE_ACTION_BUTTON;
            this.actionFileBtn.Enabled = false;
            this.openFileBtn.Enabled = true;
            this.filePaths = null;
            this.BackColor = Constants.CONTROLS_GENERAL_COLOR_ONE;
            this.actionLbl.ForeColor = Color.Black;
            this.actionLbl.Text = Constants.NEUTRAL_STATE;
            this.actionLbl.ForeColor = Color.White;
            this.action = true;
        }

        private void OpenFileBtn_Click(object sender, EventArgs e) {
            if (openFileOfl.ShowDialog() == DialogResult.OK) {
                this.filePaths = openFileOfl.FileNames;
                this.actionLbl.Text = Constants.SCREEN_CLICK;
                this.openFileBtn.Enabled = false;
            } else {
                MessageBox.Show("Se ha cancelado la operación");
            }
        }

        private void ColorsEntropyView_MouseDown(object sender, MouseEventArgs e) {
            Color stateColor = Constants.CONTROLS_GENERAL_COLOR_ONE;
            if (this.action && this.filePaths != null) { // Encriptar
                this.action = false;
                stateColor = Color.Red;
                this.actionLbl.Text = Constants.ENCRYPT_TEXT;
                this.actionLbl.ForeColor = stateColor;
                actionFileBtn.Text = Constants.ENABLED_ACTION_BUTTON_TEXT;
                actionFileBtn.Enabled = true;
            } else if (this.filePaths != null) { // Desencriptar
                this.action = true;
                stateColor = Color.Green;
                this.actionLbl.Text = Constants.DECRYPT_TEXT;
                this.actionLbl.ForeColor = stateColor;
            }
            this.BackColor = stateColor;
        }

        
    }
}
