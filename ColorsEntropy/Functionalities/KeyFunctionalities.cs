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
            key = new Bitmap(fileFunctionalities.OpenFile(Constants.SAVE_KEY_PATH));
            try {
                int[] keySizes = Constants.KEY_SIZES;
                if (!keySizes.Contains(key.Width) || !keySizes.Contains(key.Height)) return false;
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

        public static void RemoveKey() {
            using (Bitmap temporalKey = new Bitmap(key)) {
                for (int row = 0; row < temporalKey.Height; row++) {
                    for (int col = 0; col < temporalKey.Width; col++) {
                        temporalKey.SetPixel(row, col, Color.FromArgb(0, 0, 0, 0));
                    }
                }
                try {
                    //key.Dispose();
                    temporalKey.Save(Constants.SAVE_KEY_PATH, ImageFormat.Jpeg);
                    fileFunctionalities.DeleteFile(Constants.SAVE_KEY_PATH);
                } catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
            }  
        }  

        public static void KeyAction(string[] paths, bool encrypt, int times) {
            for (int nPath = 0; nPath < paths.Length; nPath ++) { // Multiselección: Un fichero por iteración
                byte[] file = fileFunctionalities.GetFile(paths[nPath]);
                int i;
                int byteLimitMax = Constants.MAX_LIMIT_BYTE + 1;
                for (int time = 0; time < times; time ++) {
                    i = 0; // Renicio del while para una nueva encriptación, si no, no entrará en el while la segunda vez. 
                    // Transposición encriptar
                    if (encrypt) {
                        Caesar(file, key.Width, encrypt);
                    }
                    //Console.WriteLine("nLoops: " + time);
                    while (i < file.Length) {
                        for (int row = 0; row < key.Height; row++) {
                            for (int col = 0; col < key.Width; col++) {
                                // Cada píxel son 4 posiciones del array y a cada píxel se sumarán o restarán en orden secuencial esas posiciones.
                                MatchCollection colorParams = Regex.Matches(key.GetPixel(row, col).ToString(), Constants.ONLY_NUMBERS_REGEX);
                                foreach (Match match in colorParams) {
                                    if (int.TryParse(match.Value, out int pixelParam)) {
                                        int fileValue = Convert.ToInt32(file[i]);
                                        if (encrypt) {
                                            int preparedValue = fileValue + pixelParam; // Se suma el parámetro del pixel a el valor del byte del fichero.
                                            if (preparedValue > Constants.MAX_LIMIT_BYTE) { // Si entra, debe ser mayor a 255
                                                                                            // Se resta el máximo de bytes posibles (256) para reducirlo a un valor aceptable en función del pixelParam.
                                                preparedValue -= byteLimitMax;
                                            }
                                            file[i] = (byte)preparedValue;
                                        } else {
                                            int preparedValue = fileValue - pixelParam;
                                            if (preparedValue < 0) {
                                                preparedValue += byteLimitMax;
                                            }
                                            file[i] = (byte)preparedValue;
                                        }
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
                        Caesar(file, key.Width, encrypt);
                    }
                }   
                
                string currentPath = paths[nPath];
                fileFunctionalities.SaveFile(currentPath, file); // Sobreescribir

                string preparedCurrentPath = currentPath;
                if (encrypt) {
                    preparedCurrentPath = currentPath + Constants.COLORS_ENTROPY_EXTENSION;
                } else {
                    if (preparedCurrentPath.EndsWith(Constants.COLORS_ENTROPY_EXTENSION)) {
                        preparedCurrentPath = preparedCurrentPath.Substring(0, preparedCurrentPath.LastIndexOf("."));
                    }
                }
                fileFunctionalities.RenameFile(currentPath, preparedCurrentPath);
            }
        }

        private static void Caesar(byte[] file, int key, bool encrypt) {
            byte[] byteLegend = Constants.DISORDERED_BYTE_LEGEND;
            int byteLegendLength = byteLegend.Length;
            int byteLimitMax = Constants.MAX_LIMIT_BYTE + 1;
            int position;
            for (int i = 0; i < file.Length; i++) {
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

    }
}
