using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Input;
using TMP_Laba3_Authorization;

namespace TMP_Laba3
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private static string _path = @$"C:\Users\{Environment.UserName}\Downloads\USERS.txt";

        Seeker seeker = new Seeker();

        public AuthorizationWindow()
        {
            InitializeComponent();

            this.PreviewKeyDown += AuthorizationWindow_PreviewKeyDown;
            this.PreviewKeyUp += AuthorizationWindow_PreviewKeyUp;
            UpdateLanguageAndCapsLock();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            //ЗАГЛУШКА
            MenuWindow menuWindow = new MenuWindow(new Person("Boss", "boss", UserRole.OO));
            menuWindow.Show();
            this.Close();
            MessageBox.Show("Вход нужно доделать!");
            return;


            if (string.IsNullOrWhiteSpace(NameUserTextBox.Text) 
                || string.IsNullOrWhiteSpace(PasswordTextBox.Text))
                MessageBox.Show("Заполните поля ввода!");

            var _name = NameUserTextBox.Text;
            var _password = PasswordTextBox.Text;

            Person _person = seeker.Seek(_name, _password, _path);

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
