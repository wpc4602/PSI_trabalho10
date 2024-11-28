using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace TrabalhoFinalDeModulo10
{
    internal class ContaBancaria_Class
    {
        private double saldoConta { get; set; } = 0.0;
        private string nomeCliente { get; set; }
        private string profissaoCliente { get; set; }
        private int NIFCliente { get; set; } = 999999999;
        public string numContaCliente { get; set; } = "000000000-00-0";
        private DateTime dataAbertura { get; set; }

        // Lista de movimentos da conta, pode ser uma lista de depósitos/saques em formato double
        public List<double> ListaMovimentos { get; set; } = new List<double>();

        // Construtor para inicializar a conta com dados básicos
        public ContaBancaria_Class(string nomeCliente, string profissaoCliente, int NIFCliente, string numContaCliente, DateTime dataAbertura)
        {
            this.nomeCliente = nomeCliente;
            this.profissaoCliente = profissaoCliente;
            this.NIFCliente = NIFCliente;
            this.numContaCliente = numContaCliente;
            this.dataAbertura = dataAbertura;
            this.saldoConta = 0.0;  // Inicializando o saldo como 0
        }

        // Método para retornar a data de abertura formatada
        public string getDataAberturaFormatada()
        {
            return dataAbertura.ToString("dd/MM/yyyy");
        }

        // Método para retornar o saldo formatado em moeda
        public string getSaldoFormatado()
        {
            var cultureInfo = new CultureInfo("pt-PT");
            return saldoConta.ToString("C", cultureInfo);
        }

        // Método para depositar um valor na conta
        public void depositar(double valor)
        {
            if (valor <= 0)
            {
                MessageBox.Show("O valor do depósito deve ser positivo.");
                return;
            }
            saldoConta += valor; // Atualiza o saldo da conta
            ListaMovimentos.Add(valor); // Registra o movimento na lista
            MessageBox.Show($"Depósito de {valor:C} realizado com sucesso.");
        }

        // Método para exibir os movimentos da conta
        public void exibirMovimentos()
        {
            if (ListaMovimentos.Count == 0)
            {
                MessageBox.Show("Não há movimentos registrados na conta.");
                return;
            }

            string movimentos = "Movimentos da conta:\n";
            foreach (var movimento in ListaMovimentos)
            {
                movimentos += movimento.ToString("C") + "\n";  // Exibe cada movimento no formato monetário
            }

            MessageBox.Show(movimentos);
        }

        // Parte comentada do código original
        /*
        private void ListaMovimentos ()
        {
            Lista.Clear ();

            for (int i = 0; i < NIFCliente; i++) // tirar o valor do NIF
            {
                if (int.TryParse(numContaCliente, out int valor))
                {
                    int teste;
                    teste = valor;
                    Lista.Add(teste);
                }
                else
                {
                    MessageBox.Show("Valor inválido.");
                }
            }
        } 
        */

        // Método para adicionar um movimento à lista (exemplo: saque, transferência)
        public void adicionarMovimento(double valor)
        {
            if (valor != 0) // Não adiciona 0, para evitar movimentos inválidos
            {
                ListaMovimentos.Add(valor);
            }
        }
    }
}

