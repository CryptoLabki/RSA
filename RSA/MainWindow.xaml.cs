using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;



namespace RSA
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            while (true)
            {
                Console.WriteLine(RandomGenerator.GetNumber(226, 222));


                Console.ReadKey();
            }

        }
    }
}

