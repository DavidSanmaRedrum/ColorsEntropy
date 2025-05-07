using ColorsEntropy.Controllers;
using ColorsEntropy.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorsEntropy.Views {
    public partial class SetPasswordView : Form {

        private string password = "";
        private bool isAcceptButtonPressed = false;

        public SetPasswordView() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SetPasswordView_Load(object sender, EventArgs e) {
            Color white = Color.White;
            Color black = Constants.CONTROLS_GENERAL_COLOR_ONE;

            this.isAcceptButtonPressed = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = black;
            this.ForeColor = white;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.generalBox.ForeColor = white;
            this.acceptBtn.ForeColor = black;
            this.acceptBtn.Enabled = false;
            this.acceptBtn.Text = Constants.DISABLED_STATE_ACTION_BUTTON;
            this.cancelBtn.ForeColor = black;
            this.passwordTextBox.PasswordChar = '*';
        }

        private void acceptBtn_Click(object sender, EventArgs e) {
            ColorsEntropyController.SetLinearPassword(this.password);
            this.isAcceptButtonPressed = true;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e) {
            this.password = "";
            ColorsEntropyController.SetLinearPassword(this.password);
            this.Close();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e) {
            string pass = this.passwordTextBox.Text;
            int passwordMinLen = Constants.PASSWORD_MIN_LENGTH;
            if (pass.Length >= passwordMinLen) {
                this.password = pass;
                this.acceptBtn.ForeColor = Color.DarkGreen;
                this.acceptBtn.Text = Constants.ACCEPT;
                this.acceptBtn.Enabled = true;
            } else {
                string textButton = "#" + pass.Length + "#";
                if (pass.Length == 0) {
                    textButton = Constants.DISABLED_STATE_ACTION_BUTTON;
                }
                this.acceptBtn.ForeColor = Color.Black;
                this.acceptBtn.Text = textButton;
                this.acceptBtn.Enabled = false;
            }
        }

        private void SetPasswordView_FormClosed(object sender, FormClosedEventArgs e) {
            if (!this.isAcceptButtonPressed) { // Si no se ha pulsado el botón de aceptar se settea la contraseña a "";
                this.password = "";
                ColorsEntropyController.SetLinearPassword(this.password);
            }
        }

    }
}
