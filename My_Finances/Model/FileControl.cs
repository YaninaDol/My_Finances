using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Finances.Model
{
    public class FileControl
    {
        public ObservableCollection<TransactionModel> transactions { get; set; }
        public string Path;

        public FileControl()
        {
            transactions = new ObservableCollection<TransactionModel>();
            Path = "MyFinance.txt";
        }
        public void Write(ObservableCollection<TransactionModel> _transactions)
        {
            File.Delete(Path);
            foreach (var item in _transactions)
            {
                File.AppendAllText(Path, item.ToString());
            }
        }
        public void Read()
        {
            if (File.Exists(Path))
            {
                string str = File.ReadAllText(Path);
                string[] splStr = str.Split('\n');
                for (int i = 0; i < splStr.Length - 1; i++)
                {
                    string rez = splStr[i];
                    string[] value = rez.Split('\t');

                    this.transactions.Add(new TransactionModel(value[0], value[1], value[2],value[3]));
                }
            }

        }
    }
}
