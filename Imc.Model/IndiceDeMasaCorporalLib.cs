namespace Imc.Model;

public static class IndiceDeMasaCorporalLib
{
    public static decimal IndiceDeMasaCorporal(decimal peso, decimal estatura)
	{
		return peso / (estatura * estatura); ;
	}

	public static string DeterminaEstadoNutricional(decimal IMC)
	{
		string estadoNutricional = IMC switch
		{
			//Con el sufijo m, le indicamos a c# que la constante literal se convierta a tipo decimal
			< 18.5m => "Peso Bajo",
			< 25.00m => "Peso normal",
			< 30.00m => "Sobrepeso",
			< 40.00m => "Obesidad",
			_ => "Obesidad Extrema"
		};

		return estadoNutricional;
	}

}
