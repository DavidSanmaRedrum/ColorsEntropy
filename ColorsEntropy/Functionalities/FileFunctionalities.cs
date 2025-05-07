using ColorsEntropy.Utils;
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

        public void PreparedSaveFile(bool mode, bool actionType, string currentPath, byte[] file) {
            

            string extension = Constants.COLORS_ENTROPY_EXTENSION;
            if (!actionType && mode) { // Contraseña encriptado
                extension = Constants.COLORS_ENTROPY_PASSWORD_EXTENSION;
                this.SaveFile(currentPath, file); // Sobreescribir
            } else if (!actionType) { // Contraseña desencriptado
                extension = Constants.COLORS_ENTROPY_PASSWORD_EXTENSION;
                string path = this.PrepareCurrentPath(currentPath, extension, mode);
                this.SaveFile(this.CreateNewFilename(path), file);
                return;
            } else { // Key
                this.SaveFile(currentPath, file); // Sobreescribir
            }
            this.RenameFile(currentPath, this.PrepareCurrentPath(currentPath, extension, mode));
        }

        private string PrepareCurrentPath(string currentPath, string extension, bool mode) {
            string preparedCurrentPath = currentPath;
            if (mode) {
                preparedCurrentPath = currentPath + extension;
            } else {
                if (preparedCurrentPath.EndsWith(extension)) {
                    preparedCurrentPath = preparedCurrentPath.Substring(0, preparedCurrentPath.LastIndexOf("."));
                }
            }
            return preparedCurrentPath;
        }

        private string CreateNewFilename(string path) {
            string[] dirs = path.Split('\\');
            string filename = path.Substring(path.LastIndexOf("\\") + 1, dirs[dirs.Length - 1].Length);
            string newFileName = '_' + filename;
            return path.Replace(filename, newFileName);
        }

    }
}
