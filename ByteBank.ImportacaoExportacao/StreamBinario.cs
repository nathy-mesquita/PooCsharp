using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.ImportacaoExportacao
{
    partial class Program
    {
        static void EscritaBinaria()
        {
            using (var fs = new FileStream("ContaCorrente.txt", FileMode.Create))
            using (var escritor = new BinaryWriter(fs))
            {
                escritor.Write(4374);
                escritor.Write(31186);
                escritor.Write(1000.00);
                escritor.Write("Nathaly Mesquita");
            }
        }

        static void LeituraBinaria()
        {
            using (var fs = new FileStream("ContaCorrente.txt", FileMode.Open))
            using (var leitor = new BinaryReader(fs))
            {
                var agencia = leitor.ReadInt32();
                var conta = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var titular = leitor.ReadString();

                Console.WriteLine($"{titular} {agencia}/{conta} R${saldo}");
                Console.ReadLine();
            }
        } 
    }
}
