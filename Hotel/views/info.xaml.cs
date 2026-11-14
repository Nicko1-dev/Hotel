namespace Hotel.views;

public partial class info : ContentPage
{
	public info()
	{
		InitializeComponent();
	}

    private void Voltar(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new views.ContratacaoHospedagem());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }

    }
}