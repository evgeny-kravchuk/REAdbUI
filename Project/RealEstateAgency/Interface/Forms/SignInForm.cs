using System;
using System.Windows.Forms;

namespace Interface.Forms
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        #region Поля TextBox
        public string Login { get { return textBoxLogin.Text; } }
        public string Password { get { return textBoxPassword.Text; } }
        #endregion

        #region Кнопки
        public Button SignIn { get { return btnSignIn; } }
        public Button SignUp { get { return btnSignUp; } }
        public Button Exit { get { return btnExit; } }
        #endregion

        #region Обработчики кнопок
        private void SignIn_Click(object sender, EventArgs e) { }
        private void SignUp_Click(object sender, EventArgs e) { }
        private void Exit_Click(object sender, EventArgs e) { }
        #endregion

        private void SignIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) | e.KeyChar == '\b' | Char.IsNumber(e.KeyChar)) return;
            else
                e.Handled = true;
        }
    }
}
