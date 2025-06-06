﻿using System.Drawing;

namespace ColorsEntropy.Utils {
    class Constants {

        // Cifrado
        public const int MAX_LIMIT_BYTE = 255;
        public const int MIN_LIMIT_COLOR_KEY = 1;
        public const int MAX_LIMIT_KEY_SIZE_COMBO = 40;
        public const int MIN_LIMIT_KEY_SIZE_COMBO = 10;
        public const int ACTION_TIMES = 2;


        // Control MessageBox
        public const int COLORS_MSG_BOX_LETTER_WIDTH = 6;
        public const int COLORS_MSG_BOX_RIGHT_SPACE = 27;
        public const int COLORS_MSG_BOX_HEIGHT = 110;
        public const int COLORS_MSG_BOX_LABEL_X = 10;
        public const int COLORS_MSG_BOX_LABEL_Y = 15;
        public const int COLORS_MSG_BOX_BUTTON_Y = 40;
        public const int DEFAULT_COMMONS_FUNCTIONALITY_CODE = 2;
        public const int CANCEL_FUNCTIONALITY_CODE = 0;
        public const int SECONDARY_FUNCTIONALITY_CODE = 1;
        public const string COLORS_MSG_BOX_ACCEPT_BUTTON = "Aceptar";
        public const string COLORS_MSG_BOX_CANCEL_BUTTON = "Cancelar";
        public const string COLORS_MSG_BOX_INFO_TITLE = "Información";
        public const string COLORS_MSG_BOX_ERROR_TITLE = "Error";
        public const string KEY_FORMAT_ERROR = "CLAVE - La clave tiene un formato erróneo.";
        public const string NEW_KEY_CREATED = "CLAVE - Se ha creado la clave.";
        

        // Clave
        public const string SAVE_KEY_PATH = "./KEY.png";
        public const string COLORS_ENTROPY_EXTENSION = ".cee";
        public const string COLORS_ENTROPY_PASSWORD_EXTENSION = ".cep";
        public const string ONLY_NUMBERS_REGEX = @"\d+";
        public const string OPEN_FILE_DIALOG_FILTER = "ALL|*.*|.CEE|*.cee";
        public const string OPEN_FILE_DIALOG_PASSWORD_FILTER = "ALL|*.*|.CEP|*.cep";
        public const string ENCRYPT_TEXT = "CIFRAR";
        public const string DECRYPT_TEXT = "DESCIFRAR";
        public const string NEUTRAL_STATE = "· · ·";
        public const string ENABLED_ACTION_BUTTON_TEXT = "ACCIÓN";
        public const string DISABLED_STATE_ACTION_BUTTON = "# # #";
        public const string SCREEN_CLICK = "MODO: CLIC EN EL PANEL";
        public static int[] KEY_SIZES = { 10, 15, 20, 25, 30, 35, 40 };


        // Contraseña
        public const int PASSWORD_MIN_LENGTH = 10;
        public const string ACCEPT = "ACEPTAR";

        public static byte[] DISORDERED_BYTE_LEGEND = {
            135,
            30,
            75,
            41,
            17,
            108,
            36,
            26,
            142,
            79,
            214,
            34,
            68,
            113,
            61,
            155,
            28,
            243,
            46,
            91,
            63,
            169,
            191,
            241,
            226,
            38,
            77,
            222,
            218,
            33,
            1,
            134,
            117,
            65,
            125,
            50,
            153,
            127,
            187,
            6,
            8,
            200,
            238,
            112,
            242,
            255,
            123,
            86,
            175,
            85,
            110,
            212,
            230,
            171,
            73,
            106,
            53,
            31,
            102,
            204,
            231,
            35,
            148,
            229,
            197,
            18,
            132,
            66,
            220,
            141,
            244,
            122,
            126,
            83,
            92,
            84,
            94,
            67,
            74,
            173,
            101,
            19,
            99,
            87,
            98,
            62,
            107,
            233,
            120,
            178,
            119,
            130,
            149,
            185,
            207,
            96,
            93,
            217,
            39,
            170,
            151,
            172,
            216,
            29,
            160,
            168,
            237,
            146,
            136,
            205,
            219,
            88,
            37,
            165,
            161,
            45,
            57,
            193,
            12,
            147,
            253,
            21,
            249,
            9,
            138,
            59,
            24,
            64,
            239,
            162,
            2,
            225,
            143,
            198,
            51,
            78,
            158,
            90,
            0,
            232,
            89,
            157,
            208,
            15,
            95,
            240,
            154,
            167,
            163,
            104,
            129,
            44,
            174,
            76,
            42,
            118,
            140,
            156,
            195,
            206,
            103,
            54,
            49,
            20,
            121,
            223,
            176,
            215,
            150,
            47,
            213,
            196,
            81,
            82,
            250,
            211,
            179,
            152,
            25,
            235,
            188,
            184,
            177,
            109,
            40,
            71,
            199,
            190,
            145,
            137,
            48,
            116,
            55,
            251,
            201,
            164,
            16,
            203,
            22,
            70,
            60,
            224,
            210,
            114,
            248,
            4,
            10,
            100,
            115,
            11,
            254,
            133,
            182,
            72,
            247,
            23,
            166,
            52,
            124,
            7,
            252,
            194,
            80,
            14,
            246,
            186,
            159,
            202,
            236,
            209,
            180,
            32,
            144,
            105,
            221,
            3,
            234,
            227,
            183,
            27,
            245,
            131,
            5,
            13,
            111,
            128,
            181,
            43,
            228,
            97,
            139,
            69,
            58,
            56,
            192,
            189
        };

        // Común
        public const char COMMA = ',';
        public const string CANCELED_OPERATION = "La operación se ha cancelado.";

        // Color formulario y controles
        public static Color CONTROLS_GENERAL_COLOR_ONE = Color.FromArgb(32, 32, 32);
        public static Color CONTROLS_GENERAL_COLOR_TWO = Color.FromArgb(25, 25, 25);

    }
}
