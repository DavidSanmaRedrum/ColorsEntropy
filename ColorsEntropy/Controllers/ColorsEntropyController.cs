using ColorsEntropy.Functionalities;
using ColorsEntropy.Models;
using ColorsEntropy.Utils;
using ColorsEntropy.Views;
using System.Drawing;
using System.Threading.Tasks;

namespace ColorsEntropy.Controllers {
    class ColorsEntropyController {

        private static int keyEdgeLength = 0;

        // Funcionalidad de claves
        public static void CreateKey(int keyEdgeLength) {
            KeyFunctionalities.CreateKey(keyEdgeLength); // Lo mismo para X como para Y.
        }

        public static bool CheckKey() {
            return KeyFunctionalities.IsValidKey();
        }

        public static void RemoveKey() {
            KeyFunctionalities.RemoveKey();
        }

        public static void EncryptFiles(string[] paths) {
            Task task = Task.Run(() => {
                KeyFunctionalities.KeyAction(paths, true, Constants.ACTION_TIMES);
            });
        }

        public static void DecryptFiles(string[] paths) {
            Task task = Task.Run(() => {
                KeyFunctionalities.KeyAction(paths, false, Constants.ACTION_TIMES);
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

        public static int CallCEMessageBox(int height, string title, string message, bool acceptAndCancel, Icon icon) {
            ColorsEntropyMessageBox messageBox = new ColorsEntropyMessageBox(height, title, message, acceptAndCancel, icon);
            return messageBox.ShowCEMessageBox();
        }

    }
}
