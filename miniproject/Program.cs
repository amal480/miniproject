using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using miniproject;

class Program
{
    static async Task Main(string[] args)
    {
        // Define the URL endpoint where you want to send the POST request
        string url = "https://api.ktu.edu.in/ktu-web-portal-api/anon/announcemnts";
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True;Encrypt=false";

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

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseContent = await response.Content.ReadAsStringAsync();

                    string path = @"C:\Users\mohan\Documents\MyTest.txt";
                    if (!File.Exists(path))
                    {
                        File.WriteAllText(path, responseContent);
                    }


                    string currentHash = CalculateHash(responseContent);
                    Console.WriteLine(currentHash);

                    string readText = File.ReadAllText(path);
                    string oldHash = CalculateHash(readText);
                    Console.WriteLine(oldHash);

                    var newdata=JsonConvert.DeserializeObject<Datamodel>(responseContent);
                    var olddata = JsonConvert.DeserializeObject<Datamodel>(readText);
                    Console.WriteLine(newdata.content[0].subject);

                    if(currentHash!= oldHash)
                    {

                    }

                    //JArray array = JArray.Parse(responseContent);

                    JObject array = JObject.Parse(responseContent);
                    JArray contents = (JArray)array["content"];
                    //foreach
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

    static string CalculateHash(string input)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

