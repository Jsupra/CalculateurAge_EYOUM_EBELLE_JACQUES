using System.Threading.Tasks;
using CalculateurAge.Resultat;

namespace CalculateurAge
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

       private async void onCalculerClicked (object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entryNom.Text))
            {
                DisplayAlert("Erreur", "Veuillez entrer votre nom.", "OK");
                return;
            }
            DateTime d = PickerDate.Date;
            int age = DateTime.Now.Year - d.Year;

            if ( d.Date > DateTime.Now.AddYears(-age)) age--;
           await Shell.Current.GoToAsync($"{nameof(Resultat.ResultatPage)}?Nom={entryNom.Text}&Age={age}");
        }
    }
}
