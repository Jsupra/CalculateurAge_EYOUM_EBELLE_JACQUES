using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateurAge.ViewModels
{
    public class CalculateurViewModel : BaseViewModel
    {
        private string _nom = "";
        private DateTime _DateNaissance = DateTime.Today.AddYears(-20);
        private string _resultat = "";
        private bool _resultatVisible;

        public string Nom
        {
            get { return _nom; }
            set
            {
                if (setField(ref _nom, value))
                    CalculerCommand.refresh();
            }


        }
        public DateTime DateNaissance
        {
            get => _DateNaissance;
            set => setField(ref _DateNaissance, value);
        }
        public string Resultat
        {
            get => _resultat;
            set => setField(ref _resultat, value);
        }
        public bool ResultatVisible { 
            get => _resultatVisible;
            set => setField(ref _resultatVisible, value);
        }
        public RelayCommand calculerCommand { get; }

        public CalculateurViewModel()
        {
            calculerCommand = new RelayCommand(
                Calculer,
                () => !string.IsNullOrWhiteSpace(Nom)
            );
        }

        private void calculer()
        {
            int age = DateTime.Today.Year;
            if (DateNaissance.Date > DateTime.Today.AddYears(-age)) age--;

            Resultat = $"{Nom}, vous avez ${age} ans";
            ResultatVisible = true ;
        }
    }
}
