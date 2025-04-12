using ColorsEntropy.Functionalities;
using ColorsEntropy.Models;
using ColorsEntropy.Utils;
using ColorsEntropy.Views;
using System.Drawing;
using System.Threading.Tasks;

namespace ColorsEntropy.Controllers {
    class ColorsEntropyController {

        private static int keyEdgeLength = 0;
        private static string linearPassword = "";

        // Funcionalidad de claves
        public static void CreateKey(int keyEdgeLength) {
            KeyFunctionalities.CreateKey(keyEdgeLength); // Lo mismo para X como para Y.
        }

        public static bool CheckKey() {
            return KeyFunctionalities.IsValidKey();
        }

        public static void EncryptFiles(string[] paths, string linearPassword) {
            Task.Run(() => {
                KeyFunctionalities.KeyAction(paths, true, linearPassword, Constants.ACTION_TIMES);
            });
        }

        public static void DecryptFiles(string[] paths, string linearPassword) {
            Task.Run(() => {
                KeyFunctionalities.KeyAction(paths, false, linearPassword, Constants.ACTION_TIMES);
            });
        }

        // Vistas:
        public static void MakeCreateKeyView() {
            CreateKeyView createKeyView = new CreateKeyView();
            createKeyView.KeyViewShow();
        }

        public static void SetKeyEdgeLength(int keyEdgeLen) {
            keyEdgeLength = keyEdgeLen;
        }

        public static int GetKeyEdgeLength() {
            return keyEdgeLength;
        }

        public static void SetLinearPassword(string password) {
            linearPassword = password;
        }

        public static string GetLinearPassword() {
            return linearPassword;
        }

        public static int CallCEMessageBox(int height, string title, string message, bool acceptAndCancel, Icon icon) {
            ColorsEntropyMessageBox messageBox = new ColorsEntropyMessageBox(height, title, message, acceptAndCancel, icon);
            return messageBox.ShowCEMessageBox();
        }

    }
}
