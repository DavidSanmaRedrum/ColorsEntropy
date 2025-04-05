using ColorsEntropy.Controllers;
using ColorsEntropy.Utils;
using ColorsEntropy.Views;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ColorsEntropy {
    public partial class colorsEntropyView : Form {

        private string[] filePaths = null; // Multiselección
        private bool action = true;
        private Icon icon = Properties.Resources.Icon;

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
                    ColorsEntropyController.CallCEMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_INFO_TITLE, Constants.NEW_KEY_CREATED, false, this.icon);
                }
                Application.Exit();
            } else if (!ColorsEntropyController.CheckKey()) {
                ColorsEntropyController.CallCEMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_ERROR_TITLE, Constants.KEY_FORMAT_ERROR, false, this.icon);
                Application.Exit();
            } else {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.actionLbl.ForeColor = Color.White;
                this.optionsStripTs.BackColor = Constants.CONTROLS_GENERAL_COLOR_TWO;
                this.openFileOfl.Filter = Constants.OPEN_FILE_DIALOG_FILTER;
                this.openFileOfl.Multiselect = true;
                this.ResetSystem();
                this.Opacity = 1;
            }
        }

        private void ActionFileBtn_Click(object sender, EventArgs e) {
            if (!action) {
                ColorsEntropyController.EncryptFiles(this.filePaths);
            } else {
                ColorsEntropyController.DecryptFiles(this.filePaths);
            }
            this.ResetSystem();
        }

        private void OpenFileBtn_Click(object sender, EventArgs e) {
            if (this.openFileOfl.ShowDialog() == DialogResult.OK) {
                this.filePaths = this.openFileOfl.FileNames;
                this.actionLbl.Text = Constants.SCREEN_CLICK;
                this.cancelActionBtn.Enabled = true;
                this.openFileBtn.Enabled = false;
            } else {
                ColorsEntropyController.CallCEMessageBox(Constants.COLORS_MSG_BOX_HEIGHT, Constants.COLORS_MSG_BOX_INFO_TITLE, Constants.CANCELED_OPERATION, false, this.icon);
            }
        }

        private void CancelActionBtn_Click(object sender, EventArgs e) {
            this.ResetSystem();
        }

        private void AboutBtn_Click(object sender, EventArgs e) {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void ColorsEntropyView_MouseDown(object sender, MouseEventArgs e) {
            Color stateColor = Constants.CONTROLS_GENERAL_COLOR_ONE;
            if (this.action && this.filePaths != null) { // Encriptar
                this.action = false; 
                stateColor = Color.Red;
                this.actionLbl.Text = Constants.ENCRYPT_TEXT;
                this.actionLbl.ForeColor = stateColor;
                this.actionFileBtn.Text = Constants.ENABLED_ACTION_BUTTON_TEXT;
                this.actionFileBtn.Enabled = true;
            } else if (this.filePaths != null) { // Desencriptar
                this.action = true;
                stateColor = Color.Green;
                this.actionLbl.Text = Constants.DECRYPT_TEXT;
                this.actionLbl.ForeColor = stateColor;
            }
            this.BackColor = stateColor;
        }

        private void ResetSystem() {
            this.actionFileBtn.Text = Constants.DISABLED_STATE_ACTION_BUTTON;
            this.actionFileBtn.Enabled = false;
            this.openFileBtn.Enabled = true;
            this.cancelActionBtn.Enabled = false;
            this.filePaths = null;
            this.openFileOfl.FileName = "";
            this.BackColor = Constants.CONTROLS_GENERAL_COLOR_ONE;
            this.actionLbl.ForeColor = Color.Black;
            this.actionLbl.Text = Constants.NEUTRAL_STATE;
            this.actionLbl.ForeColor = Color.White;
            this.action = true;
        }
        
    }
}
