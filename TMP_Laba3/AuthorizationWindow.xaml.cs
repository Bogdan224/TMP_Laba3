using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace TMP_Laba3
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

            //CultureInfo currentInputLanguage = InputLanguageManager.Current.CurrentInputLanguage;
            //LangTextBlock.Text = currentInputLanguage.DisplayName;
            //bool isCapsLockOn = Console.CapsLock;
            //KeyTextBlock.Text = $"Клавиша {(isCapsLockOn ? "CapsLock нажата" : "CapsLock не нажата")}";
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        public void UpdateLang()
        {

        }
    }
}
