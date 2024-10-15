using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string directoryPath = @"C:\Users\Junior\Videos"; // Mude para o seu diretório

        // Verifica se o diretório existe
        if (Directory.Exists(directoryPath))
        {
            //  todos os arquivos do diretório
            string[] files = Directory.GetFiles(directoryPath);

            foreach (string file in files)
            {
                //  data de criação do arquivo
                DateTime creationTime = File.GetCreationTime(file);
                TimeSpan age = DateTime.Now - creationTime;

                // Verifica se o arquivo tem mais de 7 dias (1 semana)
                if (age.TotalDays > 7)
                {
                    try
                    {
                        File.Delete(file); // Apaga o arquivo
                        Console.WriteLine($"Arquivo apagado: {file}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao apagar o arquivo {file}: {ex.Message}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Diretório não encontrado.");
        }
    }
}
