using ColorsEntropy.Utils;
using System;
using System.IO;

namespace ColorsEntropy.Functionalities {
    class FileFunctionalities {

        public FileFunctionalities() { }

        public FileStream OpenFile(string path) {
            return File.Open(path, FileMode.Open);
        }

        public byte[] GetFile(string path) {
            return File.ReadAllBytes(path);
        }

        public void SaveFile(string path, byte[] file) {
            File.WriteAllBytes(path, file);
        }

        public void RenameFile(string currentPath, string preparedCurrentPath) {
            File.Move(currentPath, preparedCurrentPath);
        }

        public void DeleteFile(string path) {
            File.Delete(path);
        }

        public void PreparedSaveFile(bool mode, bool actionType, string currentPath, byte[] file) {
            this.SaveFile(currentPath, file); // Sobreescribir

            string extension = Constants.COLORS_ENTROPY_EXTENSION;
            if (!actionType) {
                extension = Constants.COLORS_ENTROPY_PASSWORD_EXTENSION;
            }

            string preparedCurrentPath = currentPath;
            if (mode) {
                preparedCurrentPath = currentPath + extension;
            } else {
                if (preparedCurrentPath.EndsWith(extension)) {
                    preparedCurrentPath = preparedCurrentPath.Substring(0, preparedCurrentPath.LastIndexOf("."));
                }
            }
            this.RenameFile(currentPath, preparedCurrentPath);
        }
    }
}
