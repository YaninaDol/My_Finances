using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace My_Finances
{
  public  class TransactionModel : INotifyPropertyChanged
    {
        private DateTime date;
        private double price;
        private string useFor;
        private bool debit;
        private string _debit;

        public TransactionModel(TransactionModel selectedProduct)
        {
            this.price = selectedProduct.price;
            this.date = selectedProduct.date;
            this.useFor = selectedProduct.useFor;
        }
        public TransactionModel()
        {
            this.Date = DateTime.Now;
        }

        public TransactionModel(string date, string useFor, string price,string debit)
        {
            this.date = DateTime.Parse(date);
            this.price = double.Parse(price);
            this.useFor = useFor;
            this._Debit = debit;
        }

        public string UseFor
        {
            get { return useFor; }
            set { useFor = value; OnPropertyChanged("UseFor"); }
        }
        public bool Debit
        {
            get { return debit; }
            set { if (value == true)
                { _Debit = "Доход"; }
                else { _Debit = "Расход"; }
                debit = value; OnPropertyChanged("Debit"); }
        }
        public string _Debit
        {
            get { return _debit; }
            set {_debit = value; OnPropertyChanged("_Debit"); }
        }

        public double Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged("Price"); }
        }


        public DateTime Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged("Date"); }
        }


        public override string ToString()
        {
            return $"{Date.ToLongDateString()}\t{UseFor}\t{Price}\t{_Debit}\n";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
