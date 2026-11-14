using Hotel.Models;

namespace Hotel.views;

public partial class ContratacaoHospedagem : ContentPage
{
	App PropriedadesApp;
	public ContratacaoHospedagem()
	{
		InitializeComponent();
        PropriedadesApp = (App)Application.Current;

		pck_Suite.ItemsSource = PropriedadesApp.lista_quartos;

		dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

		dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
		dtpck_checkout.MaximumDate = dtpck_checkin.Date.Value.AddMonths(6);


    }

    private async void Button_Clicked(object sender, EventArgs e)
	{
		try{
            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_Suite.SelectedItem,
                QntAdultos = Convert.ToInt32(stp_Adultos.Value),
                QntCriancas = Convert.ToInt32(stp_Criancas.Value),
                DataCheckIn = dtpck_checkin.Date.Value,
                DataCheckOut = dtpck_checkout.Date.Value
            };
			await Navigation.PushAsync(new views.HospedagemContratada(){
                BindingContext = h
            });

        } catch(Exception ex) {
		 await DisplayAlert("Error", ex.Message, "OK");
		}
	}

    private void Info(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new views.info());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }

    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;
        DateTime data_selecionada_checkin = elemento.Date.Value;
        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}