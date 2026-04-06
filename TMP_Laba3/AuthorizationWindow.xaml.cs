using Microsoft.Win32;
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
using static System.Net.Mime.MediaTypeNames;

namespace TMP_Laba3
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private static string _path = @$"C:\Users\{Environment.UserName}\Downloads\USERS.txt";

        FileReader reader = new FileReader();
        List<Person> users;

        Seeker seeker = new Seeker();
        Person _person;

        public AuthorizationWindow()
        {
            InitializeComponent();

            users = reader.Read(_path);

            this.PreviewKeyDown += AuthorizationWindow_PreviewKeyDown;
            this.PreviewKeyUp += AuthorizationWindow_PreviewKeyUp;
            UpdateLanguageAndCapsLock();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameUserTextBox.Text) 
                || string.IsNullOrWhiteSpace(PasswordTextBox.Text))
                MessageBox.Show("Заполните поля ввода!");

            var _name = NameUserTextBox.Text;
            var _password = PasswordTextBox.Text;

            _person = seeker.Seek(_name, _password, users);

            if (_person != null)
                MessageBox.Show("Происходит вход в среду");
            else
                MessageBox.Show("Такого пользователя не существует!");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NameUserTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
        }

        private void AuthorizationWindow_PreviewKeyDown(object sender, KeyEventArgs e)
            => UpdateLanguageAndCapsLock();

        private void AuthorizationWindow_PreviewKeyUp(object sender, KeyEventArgs e)
            => UpdateLanguageAndCapsLock();

        private void UpdateLanguageAndCapsLock()
        {
            string text = "";
            CultureInfo currentInputLanguage = InputLanguageManager.Current.CurrentInputLanguage;

            if (currentInputLanguage.DisplayName == "английский (Соединенные Штаты)")
                text = "Язык ввода Английский";
            else if (currentInputLanguage.DisplayName == "русский (Россия)")
                text = "Язык ввода Русский";
            LangTextBlock.Text = text;

            bool isCapsLockOn = Console.CapsLock;
            KeyTextBlock.Text = $"Клавиша {(isCapsLockOn ? "CapsLock нажата" : "CapsLock не нажата")}";
        }
    }
}
