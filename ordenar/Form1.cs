using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ordenar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random x = new Random();
        int anchoCelda = 30;

        private void Form1_Load(object sender, EventArgs e)
        {
            txtNum.Multiline = false;
            txtMatriz.Multiline = true;
            txtMatriz.ScrollBars = ScrollBars.Both;
            txtMatriz.WordWrap = false;
            txtMatriz.ReadOnly = true;
            txtMatriz.Font = new Font("Courier New", 12);
        }

        float factorAncho = 1.8f; // Puedes ajustar este factor
        float factorAlto = 1.2f;
        private async void txtNum_Click(object sender, EventArgs e)
        {
            txtMatriz.Clear();

            if (int.TryParse(txtNum.Text, out int def) && def > 0)
            {
                int[,] matriz = new int[def, def];
                int altoCelda = 30;
                int margen = 20;

                txtMatriz.Width = (int)((def * anchoCelda + margen) * factorAncho);
                txtMatriz.Height = (int)((def * altoCelda + margen) * factorAlto);

                CenterTextBox();

                // Generar la matriz con valores aleatorios
                for (int i = 0; i < def; i++)
                {
                    for (int j = 0; j < def; j++)
                    {
                        matriz[i, j] = x.Next(50);
                    }
                }

                // Imprimir la matriz original
                for (int i = 0; i < def; i++)
                {
                    string row = "| ";
                    for (int j = 0; j < def; j++)
                    {
                        row += matriz[i, j].ToString("D2") + " | ";
                    }
                    txtMatriz.AppendText(row + Environment.NewLine);

                    if (i < def - 1)
                    {
                        string separator = "|";
                        for (int j = 0; j < def; j++)
                        {
                            separator += new string('_', 4) + "|";
                        }
                        txtMatriz.AppendText(separator + Environment.NewLine);
                    }

                    await Task.Delay(500);
                }

                await Task.Delay(1000);

                // Ordenar la matriz de menor a mayor
                var orden = matriz.Cast<int>().OrderBy(x => x).ToArray();

                int k = 0;
                txtMatriz.AppendText(Environment.NewLine + "Matriz Ordenada:" + Environment.NewLine);
                txtMatriz.Clear();

                // Imprimir la matriz ordenada
                for (int i = 0; i < def; i++)
                {
                    string row = "| ";
                    for (int j = 0; j < def; j++)
                    {
                        row += orden[k++].ToString("D2") + " | ";
                    }
                    txtMatriz.AppendText(row + Environment.NewLine);

                    if (i < def - 1)
                    {
                        string separator = "|";
                        for (int j = 0; j < def; j++)
                        {
                            separator += new string('_', 4) + "|";
                        }
                        txtMatriz.AppendText(separator + Environment.NewLine);
                    }

                    await Task.Delay(500);
                }
            }
            else if(txtNum.Text == "")
            { }
            else
            {
                MessageBox.Show("Ingresa solo números enteros positivos.");
            }
        }

        private void CenterTextBox()
        {
            txtMatriz.Left = (this.ClientSize.Width - txtMatriz.Width) / 2;
            txtMatriz.Top = (this.ClientSize.Height - txtMatriz.Height) / 2;
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtMatriz_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
