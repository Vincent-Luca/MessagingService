using Client.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Helpers
{
    public class MessageHandler
    {
        private string[] MessageParts;

        

        public MessageHandler()
        {

        }

        public void MessageManagment(string[] message = null)
        {
            
            MessageParts = message;


            switch (MessageParts[0])
            {
                case "ConnectionConfirmation":
                    ClientApp.Instance.UserData.RemoteEndPoint = MessageParts[1];
                    break;

                case "LoginFailure":

                    if (MessageParts[1].Contains("No_Account_with_this_Username_or_Password"))
                    {
                        MessageBox.Show("No Account with this Username and Password found, please try again");
                    }
                    break;

                case "LoginSuccess":
                    ClientApp.Instance.UserData.UserID = int.Parse(MessageParts[1]);
                    Login.Instance.Invoke((MethodInvoker)(() => { Login.Instance.loginconfirmed(); }));
                    break;

                case "CreateAccountFailure":
                    if (MessageParts[1].Contains("Account_with_this_Username_already_exists"))
                    {
                        MessageBox.Show("Account with this Username already exists, please choose something else");
                    }
                    Register.Instance.Invoke((MethodInvoker)(() => { Register.Instance.Failure(); }));
                    break;

                case "CreateAccountSuccess":
                    Register.Instance.ConfirmCreateAccount();
                    break;

                default:
                    break;
            }
        }
    }
}
