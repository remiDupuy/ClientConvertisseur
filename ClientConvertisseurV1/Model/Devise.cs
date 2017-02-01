using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV1.Model
{
    class Devise
    {
        private int id;
        private String nomDevise;
        private double taux;

        public Devise(int myId, String unNomDevise, double unTaux)
        {
            Id = myId;
            NomDevise = unNomDevise;
            Taux = unTaux;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string NomDevise
        {
            get
            {
                return nomDevise;
            }

            set
            {
                nomDevise = value;
            }
        }

        public double Taux
        {
            get
            {
                return taux;
            }

            set
            {
                taux = value;
            }
        }
    }
}
