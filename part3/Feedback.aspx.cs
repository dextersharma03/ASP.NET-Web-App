using System;
using System.Drawing;

public partial class part3_Feedback : System.Web.UI.Page
{
    private const string EMPTY_FIELD = "This field cannot be empty.";

    protected void Page_Load(object sender, EventArgs e)
    {
        var loginCookie = Request.Cookies[Constants.LOGIN_COOKIE];
        var user = loginCookie?.Values[Constants.LOGIN_USER];
        var loggedIn = loginCookie != null && !string.IsNullOrEmpty(user);
        loginSignUp.Text = loggedIn ? $"{user}" : "Log In";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var submit = true;
        submit &= ValidateName();
        submit &= ValidateEmail();
        submit &= ValidateSubject();
        submit &= ValidateDetails();

        errSubmit.Text = submit ? "Summited form!" : "Failed to submit form. Please ensure all fields are valid.";
        errSubmit.ForeColor = submit ? Color.Green : Color.Red;
    }

    protected void tbxName_TextChanged(object sender, EventArgs e) => ValidateName();

    private bool ValidateName()
    {
        var valid = !string.IsNullOrEmpty(tbxName.Text);
        errName.Text = valid ? "" : EMPTY_FIELD;
        return valid;
    }

    protected void tbxEmail_TextChanged(object sender, EventArgs e) => ValidateEmail();

    private bool ValidateEmail()
    {
        var valid = !string.IsNullOrEmpty(tbxEmail.Text);
        errEmail.Text = valid ? "" : EMPTY_FIELD;

        try
        {
            var addr = new System.Net.Mail.MailAddress(tbxEmail.Text);
        }
        catch
        {
            valid = false;
            errEmail.Text = $"{errEmail.Text} Invalid email address.";
        }

        return valid;
    }

    protected void tbxSubject_TextChanged(object sender, EventArgs e) => ValidateSubject();

    private bool ValidateSubject()
    {
        var valid = !string.IsNullOrEmpty(tbxSubject.Text);
        errSubject.Text = valid ? "" : EMPTY_FIELD;
        return valid;
    }

    protected void tbxDetails_TextChanged(object sender, EventArgs e) => ValidateDetails();

    private bool ValidateDetails()
    {
        var valid = !string.IsNullOrEmpty(tbxDetails.Text);
        errDetails.Text = valid ? "" : EMPTY_FIELD;
        return valid;
    }
}