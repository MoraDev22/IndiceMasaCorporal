using Imc.Model;
using System.Globalization;
namespace Imc.Gui;
public partial class MainPage : ContentPage
{

	//Constructor de la clase MainPage()
	public MainPage()
	{
		Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
		InitializeComponent();
		LimpiarInformacion();
	}

	private void OnCalcularButtonClicked(object sender, EventArgs e)
	{
		//Accedemos a los valores del PesoEntry y lo almacenamos en la variable peso
		decimal peso = Convert.ToDecimal(PesoEntry.Text);
		decimal estatura = Convert.ToDecimal(EstaturaEntry.Text);
		decimal IMC = IndiceDeMasaCorporalLib.IndiceDeMasaCorporal(peso, estatura);

		//Actualizamos la vista conviertiendo el valor decimal del IMC a cadena
		ImcLabel.Text = IMC.ToString("G6");
		SituacionNutricionalLabel.Text = IndiceDeMasaCorporalLib.DeterminaEstadoNutricional(IMC);

	}

	private void OnLimpiarButtonClicked(object sender, EventArgs e)
	{
		LimpiarInformacion();
	}

	private void LimpiarInformacion()
	{
		PesoEntry.Text = string.Empty;
		EstaturaEntry.Text = string.Empty;
		ImcLabel.Text = string.Empty;
		SituacionNutricionalLabel.Text = string.Empty;
	}

}

