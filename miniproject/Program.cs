/*using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SendEmailWithGoogleSMTP
{
    class Program
    {
        static void Main(string[] args)
        {
            string fromMail = "";
            string fromPassword = "";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Test Subject";
            message.To.Add(new MailAddress(""));
            message.Body = "<html><body> Test Body </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
        }
    }
}*/



using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Define the URL endpoint where you want to send the POST request
        string url = "https://api.ktu.edu.in/ktu-web-portal-api/anon/announcemnts";

        // Define the content to be sent in the request body
        string requestBody = "{\r\n\"number\": 0,\r\n\"size\": 10,\r\n\"searchText\":\"btech\"\r\n}";
        //string contentType = "";

        // Create an instance of HttpClient
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Create a StringContent object with the request body
                StringContent content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                // Send the POST request and await the response
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Check if the response is successful (status code 200-299)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseContent = await response.Content.ReadAsStringAsync();

                    //JArray array = JArray.Parse(responseContent);

                    JObject array = JObject.Parse(responseContent);
                    JArray contents = (JArray)array["content"];
                    string name = (string)contents[0]["message"];66
                    Console.WriteLine(name);



                    // Access and print each element of the array
                    /*Console.WriteLine("Elements of the array:");
                    foreach (var element in array)
                    {
                        Console.WriteLine(element);
                    }*/

                    //contentType = response.ContentType;
                    //Console.WriteLine("Response: " + responseContent);
                    //Console.WriteLine($"{responseContent}\n");
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}

