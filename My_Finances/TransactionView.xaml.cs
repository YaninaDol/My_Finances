using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace My_Finances
{
    /// <summary>
    /// Interaction logic for TransactionView.xaml
    /// </summary>
    public partial class TransactionView : Window
    {
       
        public TransactionView(TransactionModel SelectedProduct)
        {
            InitializeComponent();
            DataContext= SelectedProduct;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
