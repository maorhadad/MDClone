using MDTest.Model;
using Prism.Commands;
using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Windows.Input;

namespace MDTest.ViewModel
{
    public class EmailViewModel : TabViewModel
    {
        private EmailModel emailModell;
        public ICommand SendEmailCommand { get; set; }
        public EmailViewModel(EmailModel emailModel): base(emailModel)
        {
            this.emailModell = emailModel;
            SendEmailCommand = new DelegateCommand(SendEmail);
            From = "mdCloneMailSender@gmail.com";
        }

        public string From
        {
            get
            {
                return emailModell.From;
            }

            set
            {
                if (emailModell.From != value)
                {
                    emailModell.From = value;
                }
            }
        }
        public string To
        {
            get
            {
                return emailModell.To;
            }

            set
            {
                if (emailModell.To != value)
                {
                    emailModell.To = value;
                }
            }
        }
        public string Title
        {
            get
            {
                return emailModell.Title;
            }

            set
            {
                if (emailModell.Title != value)
                {
                    emailModell.Title = value;
                }
            }
        }
        public string Content
        {
            get
            {
                return emailModell.Content;
            }

            set
            {
                if (emailModell.Content != value)
                {
                    emailModell.Content = value;
                }
            }
        }

        private void SendEmail()
        {
            try
            {

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("mdCloneMailSender", "zaq12WSX"),
                    EnableSsl = true,
                };

                smtpClient.Send(From, To, Title, Content);
                MessageBox.Show(emailModell.ToString(), "Email sent", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Email Error", MessageBoxButtons.OK);
            }
        
        
        }
    }
}
