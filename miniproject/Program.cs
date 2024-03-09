using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
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
                    foreach (var element in contents)
                    {
                    string name = (string)element["subject"];
                    Console.WriteLine(name+"\n");

                        string fromMail = "amalm292003@gmail.com";
                        string fromPassword = "hais nifb ddkm rzrh";

                        MailMessage message = new MailMessage();
                        message.From = new MailAddress(fromMail);
                        message.Subject = name;
                        message.To.Add(new MailAddress("amalmohan480@gmail.com"));
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

