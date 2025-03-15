using ColorsEntropy.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorsEntropy.Models {
    class ColorsEntropyMessageBox {
        private Form colorsMessageBox;
        private int functionality = Constants.CANCEL_FUNCTIONALITY_CODE;

        public ColorsEntropyMessageBox(int height, string title, string message, bool acceptAndCancel, Icon icon) {
            // Longitud del mensaje * ancho en píxeles de una letra mayúscula.
            int messageWidth = message.Length * Constants.COLORS_MSG_BOX_LETTER_WIDTH;

            this.colorsMessageBox = new Form();
            this.colorsMessageBox.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.colorsMessageBox.StartPosition = FormStartPosition.CenterScreen;
            this.colorsMessageBox.Size = new Size(messageWidth + Constants.COLORS_MSG_BOX_RIGHT_SPACE, height);
            this.colorsMessageBox.MinimizeBox = false;
            this.colorsMessageBox.MaximizeBox = false;
            this.colorsMessageBox.Text = title;
            this.colorsMessageBox.Icon = icon;
            this.colorsMessageBox.BackColor = Constants.CONTROLS_GENERAL_COLOR_ONE;

            Color white = Color.White;

            // Mensaje
            Label msg = new Label();
            msg.Text = message;
            msg.Width = messageWidth;
            msg.Location = new Point(Constants.COLORS_MSG_BOX_LABEL_X, Constants.COLORS_MSG_BOX_LABEL_Y);
            msg.ForeColor = white;
            this.colorsMessageBox.Controls.Add(msg);

            string defaultButtonMessage = Constants.COLORS_MSG_BOX_ACCEPT_BUTTON;
            if (acceptAndCancel) {
                Button secondaryBtn = new Button();
                secondaryBtn.Click += new EventHandler(this.SecondaryBtn_Click);
                secondaryBtn.Text = Constants.COLORS_MSG_BOX_CANCEL_BUTTON;
                secondaryBtn.Location = new Point(messageWidth - secondaryBtn.Width * 2, Constants.COLORS_MSG_BOX_BUTTON_Y);
                secondaryBtn.ForeColor = white;
                this.colorsMessageBox.Controls.Add(secondaryBtn);
            }

            // Botón por defecto, aceptar o guardar.
            Button defaultBtn = new Button();
            defaultBtn.Click += new EventHandler(this.DefaultBtn_Click);
            defaultBtn.Text = defaultButtonMessage;
            defaultBtn.Location = new Point(messageWidth - defaultBtn.Width, Constants.COLORS_MSG_BOX_BUTTON_Y);
            defaultBtn.ForeColor = white;
            this.colorsMessageBox.Controls.Add(defaultBtn);
        }

        public int ShowCEMessageBox() {
            this.colorsMessageBox.ShowDialog();
            return this.functionality;
        }

        private void SecondaryBtn_Click(object sender, EventArgs e) {
            this.functionality = Constants.SECONDARY_FUNCTIONALITY_CODE;
            this.colorsMessageBox.Close();
        }

        private void DefaultBtn_Click(object sender, EventArgs e) {
            this.functionality = Constants.DEFAULT_COMMONS_FUNCTIONALITY_CODE;
            this.colorsMessageBox.Close();
        }
        
    }
}
