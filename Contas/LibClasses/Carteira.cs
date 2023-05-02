using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Contas.LibClasses
{
    public class Carteira
    {
        public double Saldo { get; private set; }      
        
        public string Dono { get; set; }

        public string CPF { get; set; }

        public bool TarifaCobrada { get; set; }     


        public static double IDAnterior = 0;

        public Carteira()
        {
            IDAnterior++;
            this.ID = IDAnterior; 
        }
        public double ID { get; set; }

        public double LimiteConta { get; set; }

        public DateTime UltimaCobranca { get; set; }   
    public bool Sacar(double Valor, DateTime hora) 
        {
            if (!(hora.Hour > 8 && hora.Hour < 18))
            {
                return false;
            }
            return this.Sacar(Valor);
        }
        public bool Sacar(double Valor)
        {
            if (Valor > this.Saldo)
                return false;

            this.Saldo -= Valor;
            //this.Saldo = Saldo - Valor;
            return true;
        }

    public bool Depositar(double Valor, DateTime hora)
        {
            if (!(hora.Hour > 8 && hora.Hour < 18))
            {
                return false;
            }
            return this.Depositar(Valor);
        }
        public bool Depositar(double Valor)
        {
            this.Saldo += Valor;
            return true;
        }


        public bool Transferir
            (Carteira destino, double valor)
        {
            //se nao tiver saldo cancela transferencia retornando false
            if (this.Saldo <= valor)
                return false;

            //Executa transferencia tirando da conta origram e deposinto na conta destino
            this.Sacar(valor);
            bool tOK = destino.Depositar(valor);
            if (tOK)// se transferencia ocorreu com sucesso retorna true
                return true;
            else// caso ocorrer erro faz o rollback voltando dinheiro para conta de origem
            {
                this.Depositar(valor);
                return false;
            }
        }
        public void CobrarTarifa()
        {
            if (UltimaCobranca.Month != DateTime.Now.Month)
            {
                Saldo -= 19.9;
                UltimaCobranca = DateTime.Now;
                TarifaCobrada = true;
                Console.WriteLine($"Tarifa de R$19,90 cobrada da conta {ID}. Novo saldo: R${Saldo}");
            }
            else
            {
                Console.WriteLine($"Tarifa já foi cobrada este mês da conta {ID}.");
            }
        }
    }
}




