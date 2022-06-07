using System.IO;

namespace TPN8_Coronel_Francisco_Exequiel
{   
    public class Program
    {
        static void Main(string[] args)
        {
            string PATH, archivocvs = @"C:\Users\execo\Escritorio\Universidad\3ero\1erCuatrimestre\TallerDeLenguajes1\Practica\TPN82022\index.cvs";
            System.Console.WriteLine("Ingrese la ruta a indexar: ");
            PATH = Console.ReadLine();
            if(Directory.GetDirectories(PATH).Length != 0)
            {

                System.Console.WriteLine("\nDirectorios: \n");
                foreach(var subdirectorio in Directory.GetDirectories(PATH))
                {

                    System.Console.WriteLine($"\t{subdirectorio.Replace(PATH+@"\","")}\\\n");
                }
            } else {
                Console.WriteLine("\nLa ruta especificada no tiene subdirectorios!");
            }
            if(Directory.GetFiles(PATH).Length != 0)
            {
                System.Console.WriteLine("\nArchivos: \n");
                foreach (var archivo in Directory.GetFiles(PATH))
                {
                    Console.WriteLine($"\t{archivo.Replace(PATH+@"\","")}\n");
                }
            } else {
                Console.WriteLine("\nLa ruta especificada no tiene archivos!");
            }
            
            if(!File.Exists(archivocvs))
            {
                File.Create(archivocvs);
            }
           StreamWriter archivoW = new StreamWriter(archivocvs);
           archivoW.WriteLine("indice;titulo;extension");
           int indice=1;
           string [] aux; 
           foreach(var item in Directory.GetFiles(PATH))
           {   
               aux=item.Replace(PATH+@"\","").Split('.');
               archivoW.WriteLine($"{indice};{aux[0]};{aux[1]}");
               indice++;
           }
           archivoW.Close();
        }
    }
}
