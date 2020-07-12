using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using todo.Models;

namespace todo.Models
{
    public class ExcelEmail
    {

        public async Task EmailExcel(string id, string student_no)
        {


            var collection = await DocumentDBRepository<Item>.GetItemsAsync(d => d.Id == id);

            MemoryStream outputStream = new MemoryStream();
            ExcelPackage package = new ExcelPackage(outputStream);

            ExcelWorksheet Sheet = package.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "ID";
            Sheet.Cells["B1"].Value = "Student Number";
            Sheet.Cells["C1"].Value = "First Name";
            Sheet.Cells["D1"].Value = "Last Name";
            Sheet.Cells["E1"].Value = "Email Address";
            Sheet.Cells["F1"].Value = "Home Address";
            Sheet.Cells["G1"].Value = "Contact Number";
            Sheet.Cells["H1"].Value = "Photo Path";
            Sheet.Cells["I1"].Value = "Status";
            int row = 2;
            string email = "";
            string Fname = "";
            string Lname = "";
            string studentNO = "";
            foreach (var item in collection)
            {

                Sheet.Cells[string.Format("A{0}", row)].Value = item.Id;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.Student_Number;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.First_Name;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.Last_Name;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.Email;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.Home_Address;
                Sheet.Cells[string.Format("G{0}", row)].Value = item.Mobile;
                Sheet.Cells[string.Format("H{0}", row)].Value = item.Photo_Path;
                Sheet.Cells[string.Format("I{0}", row)].Value = item.Status;
                email = item.Email;
                Fname = item.First_Name;
                Lname = item.Last_Name;
                studentNO = item.Student_Number;
                row++;
            }


            Sheet.Cells["A:AZ"].AutoFitColumns();

            package.Save();





            outputStream.Position = 0;

            Attachment attachment = new Attachment(outputStream, studentNO + ".xlsx", "application/vnd.ms-excel");



            string from = "codeshedding@gmail.com"; //example:- sourabh9303@gmail.com

            using (MailMessage mail = new MailMessage(from, email))

            {

                mail.Subject = "Student Details";

                mail.Body = "Good Day " + Fname + " " + Lname + " " + "We Have Attached An Excel Document Including Your Student Details.";

                if (attachment != null)

                {



                    mail.Attachments.Add(attachment);

                }


                mail.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.EnableSsl = true;

                NetworkCredential networkCredential = new NetworkCredential(from, "thirdyearproject2020");

                smtp.UseDefaultCredentials = true;

                smtp.Credentials = networkCredential;

                smtp.Port = 587;

                smtp.Send(mail);

            }


        }


    }
}