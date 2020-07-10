using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace Helpers
{
    static class SoporteParaConfiguracion
    {
        public static void CrearArchivoDeConfiguracion(string Ruta)
        {
            FileStream Archivo = new FileStream(Ruta + @"\destino.dat", FileMode.Create);
            BinaryWriter ArchivoBinario = new BinaryWriter(Archivo);
            ArchivoBinario.Close();
            Archivo.Close();
        }

        public static string LeerConfiguracion(string Ruta)
        {
            FileStream Archivo = new FileStream(Ruta + @"\destino.dat", FileMode.OpenOrCreate, FileAccess.Read);
            BinaryReader LeerArchivoBinario = new BinaryReader(Archivo);
            string Datos = LeerArchivoBinario.ReadString();
            LeerArchivoBinario.Close();
            Archivo.Close();

            return Datos;
        }
    }

    static class ConversorDeMorse
    {
        public static Dictionary<string, string> ClavesMorse = new Dictionary<string, string>()
        {
            {"A", ".-"}, {"B", "-..."}, {"C", "-.-."}, {"D", "-.."},
            {"E", "."}, {"F", "..-."}, {"G", "--."}, {"H", "...."},
            {"I", ".."}, {"J", ".---"}, {"K", "-.-"}, {"L", ".-.."},
            {"M", "--"}, {"N", "-."}, {"O", "---"}, {"P", ".--."},
            {"Q", "--.-"}, {"R", ".-."}, {"S", "..."}, {"T", "-"},
            {"U", "..-"}, {"V", "...-"}, {"W", ".--"}, {"X", "-..-"},
            {"Y", "-.--"}, {" ", "/"}, {"Z", "--.."}, {"1", ".----"}, {"2", "..---"},
            {"3", "...--"}, {"4", "....-"}, {"5", "....."}, {"6", "-...."},
            {"7", "--..."}, {"8", "---.."}, {"9", "----."}, {"0", "-----"},
        };

        /*public static string MorseATexto(string TextoMorse)
        {
            string textoTraducido;

            foreach(string caracter in TextoMorse)
            {

            }
            
            return textoTraducido;
        }*/

        public static string TextoAMorse(string TextoCastellano)
        {
            string textoTraducido = "";

            foreach (char caracter in TextoCastellano)
            {
                foreach(KeyValuePair<string, string> valor in ClavesMorse)
                {
                    if (valor.Key == caracter.ToString())
                    {
                        textoTraducido = valor.Value;
                    }
                }
            }

            return textoTraducido;
        }
    }
}
