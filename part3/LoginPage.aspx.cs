using System;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;

public partial class part3_LoginPage : System.Web.UI.Page
{
    private const string BLANK_USERNAME = "Username cannot be empty";
    private const string BLANK_PASSWORD = "Password cannot be empty";
    private const string USER_TAKEN = "Username has been taken";

    private bool _alreadyLoggedIn;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var loginCookie = Request.Cookies[Constants.LOGIN_COOKIE];
            var user = loginCookie?.Values[Constants.LOGIN_USER];
            _alreadyLoggedIn = loginCookie != null && !string.IsNullOrEmpty(user);
            loginSignUp.Text = _alreadyLoggedIn ? $"{user}" : "Log In";

            btnLogin.Enabled = !_alreadyLoggedIn;
            btnCreateAccount.Enabled = !_alreadyLoggedIn;

            // Hide the logout button if the user is not logged in
            btnLogout.Visible = _alreadyLoggedIn;
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (ValidateUserLogin() && ValidateUserPw())
        {
            if (Dao.DoesCustomerExist(tbxUser.Text, tbxPw.Text))
            {
                SetLoggedInUser(tbxUser.Text);
                errLogin.Text = $"Successfully logged in as user {tbxUserCreate.Text}";
                errLogin.ForeColor = Color.Green;
            }
            else
            {
                errLogin.ForeColor = Color.Red;
                errLogin.Text = "Invalid login, please ensure the username and password are correct";
            }
        }
    }

    private void SetLoggedInUser(string user)
    {
        var cookie = new HttpCookie(Constants.LOGIN_COOKIE);
        cookie.Values.Add(Constants.LOGIN_USER, user);
        cookie.Expires = DateTime.MaxValue;
        Response.Cookies.Add(cookie);
    }

    private bool CheckFieldNotEmpty(TextBox tbx, Label errLabel, string errMsg)
    {
        var valid = !string.IsNullOrEmpty(tbx.Text);
        errLabel.Text = valid ? "" : errMsg;
        return valid;
    }

    private bool ValidateUserLogin() => CheckFieldNotEmpty(tbxUser, errUser, BLANK_USERNAME);
    private bool ValidateUserPw() => CheckFieldNotEmpty(tbxPw, errPw, BLANK_PASSWORD);

    protected void btnCreateAccount_Click(object sender, EventArgs e)
    {
        if (ValidUserCreate() && ValidPwCreate())
        {
            Dao.AddUserToDatabase(tbxUserCreate.Text, tbxPwCreate.Text);
            SetLoggedInUser(tbxUserCreate.Text);
            errCreate.Text = $"Successfully created user {tbxUserCreate.Text}";
            errCreate.ForeColor = Color.Green;
        }
    }

    private bool ValidUserCreate()
    {
        if (!CheckFieldNotEmpty(tbxUserCreate, errUserCreate, BLANK_USERNAME))
            return false;

        var taken = Dao.IsUsernameTaken(tbxUserCreate.Text);
        errUserCreate.Text = taken ? USER_TAKEN : "";
        return !taken;
    }

    private bool ValidPwCreate() => CheckFieldNotEmpty(tbxPwCreate, errPwCreate, BLANK_PASSWORD);

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        SetLoggedInUser("");
    }
}