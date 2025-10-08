using System;
using System.Globalization;
namespace Imc.Gui;

public partial class MainPage : ContentPage
{

	//Constructor de la clase MainPage()
	public MainPage()
	{
		Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
		InitializeComponent();
		PesoEntry.Text = string.Empty;
		EstaturaEntry.Text = string.Empty;
		ImcLabel.Text = string.Empty;
		SituacionNutricionalLabel.Text = string.Empty;
	}

	private void OnCalcularButtonClicked(object sender, EventArgs e)
	{
		//Accedemos a los valores del PesoEntry y lo almacenamos en la variable peso
		decimal peso = Convert.ToDecimal(PesoEntry.Text);
		decimal estatura = Convert.ToDecimal(EstaturaEntry.Text);
		decimal IMC = IndiceDeMasaCorporal(peso, estatura);

		//Actualizamos la vista conviertiendo el valor decimal del IMC a cadena
		ImcLabel.Text = IMC.ToString("G6");
		SituacionNutricionalLabel.Text = DeterminaEstadoNutricional(IMC);

	}

	private void OnLimpiarButtonClicked(object sender, EventArgs e)
	{
		PesoEntry.Text = string.Empty;
		EstaturaEntry.Text = string.Empty;
		ImcLabel.Text = string.Empty;
		SituacionNutricionalLabel.Text = string.Empty;
	}

	private decimal IndiceDeMasaCorporal(decimal peso, decimal estatura)
	{
		return peso / (estatura * estatura); ;
	}

	private string DeterminaEstadoNutricional(decimal IMC)
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

