using System.Text;

string sourcePath = "C:\\Users\\Usuario\\Downloads\\test conversion"; // reemplazar por carpeta origen
string destinationPath = "C:\\Users\\Usuario\\Downloads\\test conversion - convertido"; // reemplazar por carpeta destino

try
{
    if (!Directory.Exists(sourcePath))
    {
        Console.WriteLine("La carpeta de origen no existe.");
    }

    if (string.IsNullOrEmpty(destinationPath))
    {
        Console.WriteLine("La ruta de destino no puede estar vacía.");
    }

    ConvertFiles(sourcePath, destinationPath);
    Console.WriteLine("Conversión completada exitosamente!");
}
catch (Exception ex)
{
    Console.WriteLine($"Ocurrió un error: {ex.Message}");
}

Console.WriteLine("\nPresione cualquier tecla para salir...");
Console.ReadKey();

static void ConvertFiles(string sourcePath, string destinationPath)
{
    foreach (string file in Directory.GetFiles(sourcePath, "*.sql", SearchOption.AllDirectories))
    {
        string relativePath = file.Substring(sourcePath.Length + 1);
        string newFile = Path.Combine(destinationPath, relativePath);
        if (!string.IsNullOrEmpty(newFile))
        {
            string newDir = Path.GetDirectoryName(newFile);
            if (!Directory.Exists(newDir))
            {
                Directory.CreateDirectory(newDir);
            }

            string content = File.ReadAllText(file);
            File.WriteAllText(newFile, content, new UTF8Encoding(true));

            Console.WriteLine($"Convertido: {relativePath}");
        }
    }
}