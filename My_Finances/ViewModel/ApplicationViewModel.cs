using GalaSoft.MvvmLight.Command;
using My_Finances.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace My_Finances
{
    public class ApplicationViewModel:INotifyPropertyChanged
    {
        TransactionView transactionView;
        private TransactionModel selectedProduct;

        public FileControl read_write = new FileControl();
        public ObservableCollection<TransactionModel> Transactions { get; set; }
        public double spend { get; set; }
        public double win { get; set; }
        public double sum = 0;
        private DateTime sortDate= DateTime.Now;

     

        public double WinSum()
        {
            List<TransactionModel> _search = null;
            _search = new List<TransactionModel>(Transactions.Where(p => p._Debit == "Доход").ToList());
            foreach (var item in _search)
            {
                sum += item.Price;
            }
            return sum;
        }

        public double SpendSum()
        {
            List<TransactionModel> _search = null;
            _search = new List<TransactionModel>(Transactions.Where(p => p._Debit == "Расход").ToList());
            foreach (var item in _search)
            {
                sum += item.Price;
            }
            return sum;
        }


        public ApplicationViewModel()
        {
            read_write.Read();
            Transactions = new ObservableCollection<TransactionModel>(read_write.transactions);
            win = WinSum();
            spend = SpendSum();
        }

        public TransactionModel SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged("SelectedProduct"); }
        }

       

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(() =>
                {
                    TransactionModel _Transaction = new TransactionModel();
                    SelectedProduct = _Transaction;
                    transactionView = new TransactionView( SelectedProduct);
                    transactionView.ShowDialog();
                    Transactions.Add(_Transaction);
                  
                }));
            }
            set { addCommand = value; }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(() =>
                    {

                        if (SelectedProduct != null)
                        {
                            Transactions.Remove(SelectedProduct);
                        }
                    }));


            }
            set { removeCommand = value; }
        }

        private RelayCommand sumWinComand;
        public RelayCommand SumWinComand
        {
            get
            {
               
                return sumWinComand ??
                    (sumWinComand = new RelayCommand(() =>
                    {
                      
                        win = WinSum();

                    }));

            }
            set { sumWinComand = value; }
        }

        private RelayCommand sumSpendComand;
        public RelayCommand SumSpendComand
        {
            get
            {

                return sumSpendComand ??
                    (sumSpendComand = new RelayCommand(() =>
                    {

                        spend = SpendSum();

                    }));

            }
            set { sumSpendComand = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

