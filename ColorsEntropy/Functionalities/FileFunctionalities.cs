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
    }
}
