using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class ValidationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Redirect("FifteenForm.aspx");
            }
        }
        protected void cv_password_SValidate(object source, ServerValidateEventArgs args)
        {

            /// Declaring a string variable
            string strPath;
            /// Initialization by the value of the player file address from the Users folder
            strPath = Server.MapPath(Request.ApplicationPath) +
                    "Users\\" + txt_username.Text + ".txt";
            /// If there is a player file with his data in the Users folder
            if (File.Exists(strPath))
            {
                /// Open the file and read the fifth line
                string Line = File.ReadLines(strPath).Skip(4).First();
                /// Highlighting a substring starting at character 10 that contains the player's password
                string NewString = Line.Substring(10);
                /// If the password from the file matches the password entered in the web form
                if (NewString.Equals(txt_password.Text))
                {
                    /// Save player file url
                    Session["Path"] = strPath;
                    /// Set txt_password to pass validation
                    args.IsValid = true;
                }
                /// If the password from the file does not match the password entered in the web form
                else
                {
                    /// Set txt_password to fail validation
                    args.IsValid = false;
                    ///  Set incorrect password error string
                    this.cv_password.ErrorMessage = "Password is not valid";
                }
                /// Close player file
            }
            /// If there is no player file with his data in the Users folder
            else
            {
                /// Declaring a string variable
                string NewPassword;
                /// Initializing the variable with the value of the password entered in the web form
                NewPassword = txt_password.Text;
                /// Verify that the password contains exactly eight digits
                /// If the password check is passed, that is, it consists of eight digits
                bool first = NewPassword.All(char.IsDigit);
                if (first && NewPassword.Length == 8)
                {
                    /// Create file with player name
                    FileStream files = new FileStream(strPath, FileMode.Create);
                    StreamWriter file = new StreamWriter(files);
                    /// Add the player's name to the file, in the format "Name: Ann" 
                    file.WriteLine(String.Concat("Name: ", txt_username.Text));
                    /// Add the player's age to the file, in the format "Age: 20"
                    file.WriteLine(String.Concat("Age: ", txt_age.Text));
                    /// Add the player's phone to the file, in the format "Telephone: 70564231"
                    file.WriteLine(String.Concat("Telephone: ", txt_telephone.Text));
                    /// Add the player's mail to the file, in the format "Email: Ann@gmail.com"
                    file.WriteLine(String.Concat("Email: ", txt_email.Text));
                    /// Add the player's password to the file, in the format "Password: 13243546"
                    file.WriteLine(String.Concat("Password: ", txt_password.Text));
                    /// Close player file
                    file.Close();
                    /// Save player file url
                    Session["Path"] = strPath;
                    /// Set txt_password to pass validation
                    args.IsValid = true;
                }
                /// If password verification failed, that is, it does not consist of eight digits
                else
                {
                    /// Set txt_password to fail validation
                    args.IsValid = true;
                    /// Set incorrect password error string
                    this.cv_password.ErrorMessage = "Password is not valid";
                }
            }
        }
    }
}