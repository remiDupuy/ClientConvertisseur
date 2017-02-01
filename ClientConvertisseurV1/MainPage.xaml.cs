using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ClientConvertisseurV1.Model;
using ClientConvertisseurV1.Service;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClientConvertisseurV1
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Devise> listDevises;
        public MainPage()
        {
            this.InitializeComponent();
            ActionGetData();
        }

        private async void ActionGetData()
        {
            var result = await WSService.Instance.getAllDevisesAsync();
            listDevises = new List<Devise>(result);
            this.cbxDevise.DataContext = listDevises;
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            double mtEuros = -1;
            try
            {
                mtEuros = Convert.ToDouble(this.txtMtEuros.Text);
            }
            catch
            {
                
            }
            if(mtEuros != -1 && mtEuros > 0)
            {
                try
                {
                    Devise selectDevise = (Devise)this.cbxDevise.SelectedItem;
                    double mtConvert = selectDevise.Taux * mtEuros;
                    this.txtMtConvert.Text = Convert.ToString(mtConvert);
                }
                catch 
                {

                   
                }
            }
           

            

            

            

        }
    }
}
