using Skattekalkulator.Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skattekalkulator.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Calculator cal = null;
        public MainViewModel()
        {
            cal = new Calculator();
        }

        #region Properties
        
        //Alder
        private int _age = 0;    
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged("TaxToPay");
            }
        }

        //Lønn
        private Decimal _salary = 0m;
        public Decimal Salery
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
                OnPropertyChanged("TaxToPay");
            }
        }

        //Avgift og betale
        public String TaxToPay
        {
            get
            {
                if (Age > 0 && Salery > 0)
                {
                    Decimal t = cal.GetTax(Age, Salery);


                    if(t < 100 && t > 0)
                        InfoMessage = "Kreves ikke inn";
                    else
                        InfoMessage = "";

                    OnPropertyChanged("InfoMessage");
                    return t.ToString("0.00");
                }
                else
                {
                    InfoMessage = "";
                    OnPropertyChanged("InfoMessage");
                    return "0";
                }
            }
        }
        
        public String InfoMessage
        {
            get;
            set;
        }        
        #endregion
        
        #region Utils
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
