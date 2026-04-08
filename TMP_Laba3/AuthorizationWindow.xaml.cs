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
        private string _path;

        Seeker seeker = new Seeker();

        public AuthorizationWindow()
        {
            InitializeComponent();

            var path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", ".."));
            _path = Path.Combine(path, "USERS.txt");

            this.PreviewKeyDown += AuthorizationWindow_PreviewKeyDown;
            this.PreviewKeyUp += AuthorizationWindow_PreviewKeyUp;
            UpdateLanguageAndCapsLock();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameUserTextBox.Text)
                || string.IsNullOrWhiteSpace(PasswordTextBox.Password))
            {
                MessageBox.Show("Заполните поля ввода!");
                return;
            }
                

            var _name = NameUserTextBox.Text;
            var _password = PasswordTextBox.Password;

            Person? _person = seeker.Seek(_name, _password, _path);

            if (_person != null)
            {
                MenuWindow menuWindow = new MenuWindow(_person);
                menuWindow.Show();
                this.Close();
            }
            else
                MessageBox.Show("Такого пользователя не существует!");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NameUserTextBox.Text = string.Empty;
            PasswordTextBox.Password = string.Empty;
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
