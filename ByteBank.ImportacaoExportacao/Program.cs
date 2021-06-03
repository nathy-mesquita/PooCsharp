using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ByteBank.ImportacaoExportacao.Modelos;

namespace ByteBank.ImportacaoExportacao
{
    partial class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("escrevendoComAClasseFile.txt","Testando File.WriteAllText");
            Console.WriteLine("Arquivo escrevendoComAClasseFile criado!");

            var bytesArquivo = File.ReadAllBytes("contas.txt");
            Console.WriteLine($"Aquivo contas.txt possui{bytesArquivo.Length} bytes");

            var linhas = File.ReadAllLines("contas.txt");
            Console.WriteLine(linhas.Length);
            foreach (var linha in linhas)
            {
                Console.WriteLine(linha);
            }

            Console.ReadLine();
        }
        
    }
}
