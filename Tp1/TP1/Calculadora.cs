using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Calculadora
    {
        public double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado;
            double num1 = numero1.getNumero();
            double num2 = numero2.getNumero();
            if (num2 != 0)
            {
                switch (operador)
                {
                    case "+":
                        resultado = num1 + num2;
                        break;
                    case "-":
                        resultado = num1 - num2;
                        break;
                    case "*":
                        resultado = num1 * num2;
                        break;
                    case "/":
                        resultado = num1 / num2;
                        break;
                    default:
                        resultado = 0;
                        break;
                }
                return resultado;
            }
            else {
                return 0;
            }

                }
        public string Validar(string operador)
        {

            if (!(operador == "+" || operador == "-" || operador == "*" || operador == "/"))
            {
                return "+";
            }
            else { return operador; }
        }

    }
}
