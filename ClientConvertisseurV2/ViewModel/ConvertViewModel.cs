using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClientConvertisseurV2.Model;
using ClientConvertisseurV2.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Windows.UI.Popups;

namespace ClientConvertisseurV2.ViewModel
{
    class ConvertViewModel: ViewModelBase
    {
        private ObservableCollection<Devise> _comboBoxDevises;
        private string _montantEuros;
        private Devise _comboBoxDeviseItem;
        private string _montantConvert;

        public ObservableCollection<Devise> ComboBoxDevises
        {
            get { return _comboBoxDevises; }
            set
            {
                _comboBoxDevises = value;
                RaisePropertyChanged();// Pour notifier de la modification de ses données
            }
        }


        public string MontantEuros
        {
            get { return _montantEuros; }
            set
            {
                _montantEuros = value;
                RaisePropertyChanged();
            }
        }

        public ICommand BtnSetConversion { get; private set; }

        public Devise ComboBoxDeviseItem
        {
            get
            {
                return _comboBoxDeviseItem;
            }

            set
            {
                _comboBoxDeviseItem = value;
                RaisePropertyChanged();
            }
        }

        public string MontantConvert
        {
            get
            {
                return _montantConvert;
            }

            set
            {
                _montantConvert = value;
                RaisePropertyChanged();
            }
        }

        public ConvertViewModel()
        {
            ActionGetData();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        private async void ActionGetData()
        {
            var result = await WSService.Instance.getAllDevisesAsync();
            ComboBoxDevises = new ObservableCollection<Devise>(result);
        }

        private async void ActionSetConversion()
        {
            try
            {
                double mtFinal = Double.Parse(MontantConvert) / ComboBoxDeviseItem.Taux;
                MontantEuros = mtFinal.ToString();
            }
            catch
            {
                MessageDialog msgDialog = new MessageDialog("Erreur. Vérifiez les champs");
                await msgDialog.ShowAsync();
            }

        }
    }
}
