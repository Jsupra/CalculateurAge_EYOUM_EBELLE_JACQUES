namespace CalculateurAge.Resultat;


[QueryProperty(nameof(Nom), "Nom")]
[QueryProperty(nameof(Age), "Age")]
public partial class ResultatPage : ContentPage
{
    public string Nom { get; set; }
    public string Age { get; set; }

    public ResultatPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        lblMessage.Text = $"Bonjour {Nom}, vous avez {Age} ans.";
    }

    private async void onRetourClicked(object sender, EventArgs e)
    {
       await Shell.Current.GoToAsync("..");
    }
}