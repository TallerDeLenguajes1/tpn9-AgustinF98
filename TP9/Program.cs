using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Helpers;

namespace TP9_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string Ruta = @"C:\Repogit\tp9\tpn9-AgustinF98\TP9";
            
            List<string> ListadoArchivos;

            if (File.Exists("destino.dat"))
            {
                //Console.WriteLine("El archivo 'destino.dat' no existe. Se creara a continuacion.\n");
                SoporteParaConfiguracion.LeerConfiguracion(Ruta);
            }
            else
            {
                SoporteParaConfiguracion.CrearArchivoDeConfiguracion(Ruta);
                SoporteParaConfiguracion.LeerConfiguracion(Ruta);
            }

            string Destino = Ruta + @"\destino.dat";
            string DirectorioRaiz = @"C:\Repogit\tp9\tpn9-AgustinF98\TP9_1\bin\Debug";
            ListadoArchivos = Directory.GetFiles(DirectorioRaiz).ToList();
            Console.WriteLine("Listado de archivos: ");

            foreach (string archivos in ListadoArchivos)
            {
                Console.WriteLine(archivos);
                if(Path.GetExtension(archivos) == ".mp3" || Path.GetExtension(archivos) == ".txt")
                {
                    if (File.Exists(Destino))
                    {
                        File.Delete(Destino);
                    }
                    File.Move(archivos, Destino);
                }
            }


            //-------------- PUNTO 2 --------------

            string TextoMorse, TextoCastellano;
            string carpetaMorse = Ruta + @"\Morse";

            Console.WriteLine("Ingrese un texto para traducirla a codigo morse: ");
            TextoCastellano = Console.ReadLine();
            TextoMorse = ConversorDeMorse.TextoAMorse(TextoCastellano);

            if (!Directory.Exists(carpetaMorse))
            {
                Directory.CreateDirectory(carpetaMorse);
            }
        }
    }
}
