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
        private Encryptor _encryptor;
        private Decryptor _decryptor;
        private int _defaultE = 23;

        public MainWindow()
        {
            InitializeComponent();

            inputE.Text = _defaultE.ToString();
        }


        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            int E = _defaultE;
            int.TryParse(inputE.Text, out E);

            _encryptor = new Encryptor(E, 512);
            inputP.Text = _encryptor.P.ToString();
            inputQ.Text = _encryptor.Q.ToString();
            inputN.Text = _encryptor.N.ToString();

            _decryptor = new Decryptor();
            inputD.Text = _decryptor.getD(_encryptor.P, _encryptor.Q, _encryptor.E).ToString();
        }


        private void BtnGo_Click(object sender, RoutedEventArgs e)
        {
            if (_encryptor == null || _decryptor == null)
                return;

            var anyValue = 23;
            var m = new BigInteger(anyValue);
            if (BigInteger.TryParse(inputM.Text, out m) == true)
            {
                inputResultC.Text = _encryptor.Encrypt(m).ToString();
            }

            var c = new BigInteger(anyValue);
            if (BigInteger.TryParse(inputC.Text, out c) == true)
            {
                inputResultM.Text = _decryptor.Decrypt(_encryptor.P, _encryptor.Q, _encryptor.E, c).ToString();
            }
        }
    }
}

