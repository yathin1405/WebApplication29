using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Net.Mail;


namespace WebApplication29.Models
{
    public class Booking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BookingID { get; set; }
        //public Guid Tour_ID { get; set; }
        //[ForeignKey("Tour_ID")]
        public virtual Tour Tours { get; set; }
        public int Cust_ID { get; set; }

        public int NumAdults { get; set; }
        public int NumKids { get; set; }
        public virtual Tour deposit { get; set; }
        public virtual Tour TotalCost { get; set; }
        public virtual Tour Discount { get; set; }
        public static void BuildEmailTemplate(string sendto)
        {
            string from, to, bcc, cc, subject, body;
            from = "ParadiseTravels@gmail.com"; //makeemail
            to = sendto.Trim();
            bcc = "";
            cc = "";
            subject = "Paradise Travels Customer";
            StringBuilder sb = new StringBuilder();
            sb.Append("You Have Been Registered As A Customer At Paradise Travels.");
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }


        public static void SendEmail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("ParadiseTravels@gmail.com", "ParadiseTravels1");
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}