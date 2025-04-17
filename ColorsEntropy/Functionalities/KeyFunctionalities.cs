using ColorsEntropy.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text.RegularExpressions;

namespace ColorsEntropy.Functionalities {
    class KeyFunctionalities {

        private static FileFunctionalities fileFunctionalities = new FileFunctionalities();
        private static Bitmap key = null;

        public static void CreateKey(int keyEdgeLength) {
            int keyWidth = keyEdgeLength;
            int keyHeight = keyEdgeLength;
            Bitmap key = new Bitmap(keyWidth, keyHeight);
            Random random = new Random();
            HashSet<Color> keyColors = new HashSet<Color>(1); // Sin colores repetidos para ofuscar más.
            int positionCounter = 0;

            while (keyColors.Count < key.Height * key.Width) {
                for (int col = 0; col < key.Width; col++) {
                    // De 1 a 255
                    int alpha = random.Next(Constants.MIN_LIMIT_COLOR_KEY, Constants.MAX_LIMIT_BYTE + 1);
                    int red = random.Next(Constants.MIN_LIMIT_COLOR_KEY, Constants.MAX_LIMIT_BYTE + 1);
                    int green = random.Next(Constants.MIN_LIMIT_COLOR_KEY, Constants.MAX_LIMIT_BYTE + 1);
                    int blue = random.Next(Constants.MIN_LIMIT_COLOR_KEY, Constants.MAX_LIMIT_BYTE + 1);

                    keyColors.Add(Color.FromArgb(alpha, red, green, blue));
                }
            }
            Color[] keyColorsArray = keyColors.ToArray();

            for (int row = 0; row < key.Height; row++) {
                for (int col = 0; col < key.Width; col++) {
                    key.SetPixel(row, col, keyColorsArray[positionCounter]);
                    positionCounter++;
                }
            }

            key.Save(Constants.SAVE_KEY_PATH, ImageFormat.Jpeg);
        }

        public static bool IsValidKey() { // Haré que devuelva mensajes de texto.
            try {
                key = new Bitmap(fileFunctionalities.OpenFile(Constants.SAVE_KEY_PATH));
                int[] keySizes = Constants.KEY_SIZES;
                if ((!keySizes.Contains(key.Width) || !keySizes.Contains(key.Height)) && key.Height != key.Width) return false;
                for (int row = 0; row < key.Height; row++) {
                    for (int col = 0; col < key.Width; col++) {
                        if (key.GetPixel(row, col).ToString().Split(Constants.COMMA).Contains((Constants.MIN_LIMIT_COLOR_KEY - 1).ToString())) {
                            return false;
                        }
                    }
                }
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public static bool KeyAction(string[] paths, bool encrypt, string linearPassword, int times) {
            if (null != linearPassword && linearPassword.Length >= Constants.PASSWORD_MIN_LENGTH) {
                return LinearKeyAction(paths, linearPassword, encrypt, times);
            }

            for (int nPath = 0; nPath < paths.Length; nPath ++) { // Multiselección: Un fichero por iteración
                byte[] file = fileFunctionalities.GetFile(paths[nPath]);
                int i;
                for (int time = 0; time < times; time ++) {
                    i = 0; // Renicio del while para una nueva encriptación, si no, no entrará en el while la segunda vez. 
                    // Transposición encriptar
                    if (encrypt) {
                        Caesar(file, key.Width, 0, encrypt);
                    }

                    while (i < file.Length) {
                        for (int row = 0; row < key.Height; row++) {
                            for (int col = 0; col < key.Width; col++) {
                                // Cada píxel son 4 posiciones del array y a cada píxel se sumarán o restarán en orden secuencial esas posiciones.
                                MatchCollection colorParams = Regex.Matches(key.GetPixel(row, col).ToString(), Constants.ONLY_NUMBERS_REGEX);
                                foreach (Match match in colorParams) {
                                    if (int.TryParse(match.Value, out int pixelParam)) { // Convertir un string a int de manera segura
                                        int fileValue = Convert.ToInt32(file[i]);
                                        ActionControl(encrypt, fileValue, pixelParam, i, file);
                                        /* Control por si los 4 parámetros de los colores y la longitud del array no son múltiplos (encajan justamente).
                                            Se rompe el bucle para esto. Esto es viable porque se controla desde el bucle interno.*/
                                        if (i == file.Length - 1) {
                                            col = key.Width;
                                            row = key.Height;
                                            i = file.Length;
                                            break;
                                        };
                                    }
                                    i++;
                                }
                            }
                        }
                    }
                    // Transposición desencriptar
                    if (!encrypt) {
                        Caesar(file, key.Width, 0, encrypt);
                    }
                }
                fileFunctionalities.PreparedSaveFile(encrypt, true, paths[nPath], file);
            }
            return true;
        }

        private static bool LinearKeyAction(string[] paths, string key, bool encrypt, int times) {
            int i;
            byte[] file;

            for (int nPath = 0; nPath < paths.Length; nPath++) {
                file = fileFunctionalities.GetFile(paths[nPath]);

                file = PasswordProcess(file, key, encrypt);
                if (null == file) {
                    return false;
                }

                int linearPasswordLen = 0;
                if (encrypt) {
                    linearPasswordLen = key.Length;
                }

                for (int time = 0; time < times; time++) {
                    i = 0;
                    // Transposición encriptar
                    if (encrypt) {
                        Caesar(file, key.Length, linearPasswordLen, encrypt);
                    }
                    while (i < file.Length - linearPasswordLen) {
                        for (int kPos = 0; kPos < key.Length; kPos++) {
                            ActionControl(encrypt, file[i], key[kPos], i, file);
                            if (i == file.Length - linearPasswordLen - 1) {
                                i = file.Length - linearPasswordLen;
                                break;
                            };
                            i++;
                        }
                    }
                    // Transposición desencriptar
                    if (!encrypt) {
                        Caesar(file, key.Length, linearPasswordLen, encrypt);
                    }
                }
                fileFunctionalities.PreparedSaveFile(encrypt, false, paths[nPath], file); 
            }
            return true;
        }

        private static void ActionControl(bool mode, int fileValue, int keyValue, int index, byte[] file) {
            int byteLimitMax = Constants.MAX_LIMIT_BYTE + 1;
            if (mode) {
                int preparedValue = fileValue + keyValue; // Se suma el parámetro del pixel al valor del byte del fichero.
                if (preparedValue > Constants.MAX_LIMIT_BYTE) { // Si entra, debe ser mayor a 255
                                                                // Se resta el máximo de bytes posibles (256) para reducirlo a un valor aceptable en función del pixelParam.
                    preparedValue -= byteLimitMax;
                }
                file[index] = (byte)preparedValue;
            } else {
                int preparedValue = fileValue - keyValue;
                if (preparedValue < 0) {
                    preparedValue += byteLimitMax;
                }
                file[index] = (byte)preparedValue;
            }
        }

        private static void Caesar(byte[] file, int key, int linearPasswordLen, bool encrypt) {
            byte[] byteLegend = Constants.DISORDERED_BYTE_LEGEND;
            int byteLegendLength = byteLegend.Length;
            int byteLimitMax = Constants.MAX_LIMIT_BYTE + 1;
            int position;

            for (int i = 0; i < file.Length - linearPasswordLen; i++) {
                for (int j = 0; j < byteLegendLength; j++) {
                    if (byteLegend[j] == file[i] && encrypt) {
                        position = j + key;
                        if (position > Constants.MAX_LIMIT_BYTE) {
                            position -= byteLimitMax;
                        }
                        file[i] = byteLegend[position];
                        j = byteLegendLength;
                    } else if (byteLegend[j] == file[i]) {
                        position = j - key;
                        if (position < 0) { 
                            position += byteLimitMax; 
                        }
                        file[i] = byteLegend[position];
                        j = byteLegendLength;
                    }
                }
            }
        }

        private static byte[] PasswordProcess(byte[] file, string password, bool encrypt) {
            List<byte> preparedFile = file.ToList();
            int byteLimitMax = Constants.MAX_LIMIT_BYTE + 1;
            int letterValue;

            if (encrypt) {
                for (int i = 0; i < password.Length; i++) {
                    letterValue = (byte)password[i];
                    if (i == password.Length - 1) {    
                        letterValue += password[0]; // Ofuscar el último byte con el primer carácter de la contraseña sin cifrar.
                    } else {
                        letterValue += password[i + 1];
                    }
                    if (letterValue > Constants.MAX_LIMIT_BYTE) {
                        letterValue -= byteLimitMax;
                    }
                    preparedFile.Add((byte)letterValue);
                }
                return preparedFile.ToArray();
            } else {
                string result = "";
                byte[] passwordIntoFile = preparedFile.Skip(preparedFile.Count - password.Length).ToArray();

                for (int i = passwordIntoFile.Length - 1; i > -1; i --) {
                    letterValue = passwordIntoFile[i];
                    if (i == passwordIntoFile.Length - 1) {
                        letterValue -= password[0];
                    } else {
                        letterValue -= password[i + 1];
                    }
                    if (letterValue < 0) {
                        letterValue += byteLimitMax;
                    }
                    result = (char)letterValue + result;
                }
                if (!result.Equals(password)) return null;
                // Borrar el rango de chars de la password
                return preparedFile.Take(preparedFile.Count - password.Length).ToArray(); // funciona
            }
        }

    }
}
