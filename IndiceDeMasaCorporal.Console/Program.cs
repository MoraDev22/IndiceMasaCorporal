using System;
using System.Globalization;

namespace IndiceMasaCorporal
{
    class IMC
    {
        //Propiedades de instancia
        protected float peso;
        protected float estatura;

        //Constructor
        public IMC(float peso, float estatura)
        {
            this.peso = peso;
            this.estatura = estatura;
        }
        
        //Método para calcular el IMC
        public string CalcularIMC()
        {
            double estatura_cuadrado = Math.Pow(Estatura, 2);
            double IMC_CALCULADO = Peso / estatura_cuadrado;
            return (IMC_CALCULADO > 0) ? EstadoNutricional(IMC_CALCULADO) : "Error, valores no esperados";
        }

        //Método para evaluar el estado nutricional
        public string EstadoNutricional(double IMC)
        {
            //Usamos solo 4 decimales
            string IMC_FORMATEADO = $"{IMC:F4}";

            string estadoNutricional = IMC switch
            {
                < 18.5 => "Bajo peso",
                >= 18.5 and < 25 => "Peso normal",
                >= 25 and < 30 => "Sobrepeso",
                >= 30 and < 40 => "Obesidad",
                >= 40 => "Obesidad Extrema",
                _ => "Valor no esperado"
            };

            return mostrarInformacion(IMC_FORMATEADO, estadoNutricional);
        }

        //Método encargado de mostrar la información del estado de nutrición del usuario
        public string mostrarInformacion(string IMC, string estado)
        {
            return $@"
                Información Estado Nutricional:
                 - Índice de masa corporal: {IMC}
                 - Estado de nutrición: {estado}";
        }

        //getter y setter para la propiedad peso
        public float Peso
        {
            get { return this.peso; }
            set { this.peso = value; }
        }
        
        //getter y setter para la propiedad estatura
        public float Estatura
        {
            get { return this.estatura; }
            set { this.estatura = value; }
        }

    }
    class Program
    {
        public static void Main(string[] args)
        {
            //Forzamos la cultura regional que usa .NET a "en-US" en todo el programa para la interpretación de números
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            try
            {
                //Pedimos los datos al usuario
                Console.Write("Introduce tu peso (kgs): ");
                float peso = float.Parse(Console.ReadLine());
                Console.Write("\nIntroduce tu estatura (mts): ");
                float estatura = float.Parse(Console.ReadLine());

                //Creamos una instancia de la clase IMC
                IMC IMC = new IMC(peso, estatura);
                Console.WriteLine(IMC.CalcularIMC());
            }
            catch
            {
                Console.WriteLine("Error inesperado, solo se admiten valores númericos. Intentalo nuevamente");
            }


        }
    }
}