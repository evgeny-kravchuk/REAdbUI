using System;
using System.Windows.Forms;
using Objects.Validation;

namespace Interface.Forms
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        #region Поля TextBox
        public string Login { get { return textBoxLogin.Text; } }
        public string Password { get { return textBoxPassword.Text; } }
        public string LastName { get { return Functions.FirstUpper(textBoxLastName.Text); } }
        public string FirstName { get { return Functions.FirstUpper(textBoxFirstName.Text); } }
        public string Patronymic { get { return Functions.FirstUpper(textBoxPatronymic.Text); } }
        public string PhoneNumber { get { return maskedTextBoxPhoneNumber.Text; } }
        #endregion

        #region Кнопки
        public Button SignUp { get { return btnSignUp; } }
        public Button Exit { get { return btnExit; } }
        #endregion

        #region Обработчик кнопок
        private void SignUp_Click(object sender, EventArgs e) { }
        private void Exit_Click(object sender, EventArgs e) { }
        #endregion

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) | e.KeyChar == '\b' | Char.IsNumber(e.KeyChar))
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
