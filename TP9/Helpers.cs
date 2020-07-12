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
            {"a", ".- "}, {"b", "-... "}, {"c", "-.-. "}, {"d", "-.. "},
            {"e", ". "}, {"f", "..-. "}, {"g", "--. "}, {"h", ".... "},
            {"i", ".. "}, {"j", ".--- "}, {"k", "-.- "}, {"l", ".-.. "},
            {"m", "-- "}, {"n", "-. "}, {"o", "--- "}, {"p", ".--. "},
            {"q", "--.- "}, {"r", ".-. "}, {"s", "... "}, {"t", "- "},
            {"u", "..- "}, {"v", "...- "}, {"w", ".-- "}, {"x", "-..- "},
            {"y", "-.-- "}, {"z", "--.. "}, {" ", "/ "}, {"1", ".---- "}, {"2", "..--- "},
            {"3", "...-- "}, {"4", "....- "}, {"5", "..... "}, {"6", "-.... "},
            {"7", "--... "}, {"8", "---.. "}, {"9", "----. "}, {"0", "----- "}
        };

        public static string MorseATexto(string TextoMorse)
        {
            string textoTraducido = "";
            string[] letraMorse = TextoMorse.Split(" ");

            foreach(string codigo in letraMorse)
            {
                foreach (KeyValuePair<string, string> elemento in ClavesMorse)
                {
                    if (elemento.Value == codigo + " ")
                    {
                        textoTraducido = textoTraducido + elemento.Key;
                    }
                }
            }
            return textoTraducido;
        }

        public static string TextoAMorse(string TextoCastellano)
        {
            string textoTraducido = "";

            foreach (char caracter in TextoCastellano)
            {
                foreach(KeyValuePair<string, string> elemento in ClavesMorse)
                {
                    if (elemento.Key == caracter.ToString())
                    {
                        textoTraducido = textoTraducido + elemento.Value;
                    }
                }
            }
            return textoTraducido;
        }

        public static void GuardarEnArchivotxt(string TextoMorse)
        {
            string carpetaMorse = @"C:\Repogit\tp9\tpn9-AgustinF98\TP9\Morse";
            string fecha = DateTime.Now.ToString("dd-MM-yy");
            string Archivotxt = carpetaMorse + @"\morse_[" + fecha + "].txt";

            if (!Directory.Exists(carpetaMorse))
            {
                Directory.CreateDirectory(carpetaMorse);
            }
            File.WriteAllText(Archivotxt, TextoMorse);
        }

        public static string LeerArchivotxt()
        {
            string carpetaMorse = @"C:\Repogit\tp9\tpn9-AgustinF98\TP9\Morse";
            string fecha = DateTime.Now.ToString("dd-MM-yy");
            string Archivotxt = carpetaMorse + @"\morse_[" + fecha + "].txt";

            string Archivotxt2 = carpetaMorse + @"\texto_[" + fecha + "].txt";
            string TextoEnMorse = File.ReadAllText(Archivotxt);
            string TextoTraducido = MorseATexto(TextoEnMorse);

            File.WriteAllText(Archivotxt2, TextoTraducido);

            return TextoTraducido;
        }
    }
}
