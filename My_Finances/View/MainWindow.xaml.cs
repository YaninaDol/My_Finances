using My_Finances.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace My_Finances
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        ApplicationViewModel applicationViewModel;
        public FileControl read_write = new FileControl();
        double sum = 0;
        public MainWindow()
        {
          
            InitializeComponent();
            applicationViewModel= new ApplicationViewModel();
            DataContext = applicationViewModel;
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            read_write.Write(applicationViewModel.Transactions);
        }

      
       
    }
}
