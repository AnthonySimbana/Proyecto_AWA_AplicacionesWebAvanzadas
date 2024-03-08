using System;
using System.Net.Http;
using System.Text;
using System.Web.UI;
using Newtonsoft.Json;

namespace WebAppWarcraftFriends.pages
{
    public partial class logIn : System.Web.UI.Page
    {
        protected async void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string username = TextBox1.Text;
                string password = TextBox2.Text;

                // Hash the password before sending to the Web API (recommended for security)
                string hashedPassword = HashPassword(password); // Implement a secure hashing function (e.g., bcrypt)

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:7123/"); // Replace with your Web API's base URL

                    var loginData = new { Username = username, Password = hashedPassword };
                    var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/User/Login", content); // Adjust the endpoint as per your API

                    if (response.IsSuccessStatusCode)
                    {
                        Response.Write(response.Content);
                        // Handle successful login (e.g., redirect to another page, set session variables)
                        // You might receive a JWT token or other authentication data from the Web API
                        string responseData = await response.Content.ReadAsStringAsync();
                        // Process the responseData based on your Web API's response format

                        // Redirect to the next page (adjust the URL accordingly)
                        Response.Redirect("/pages/logIn.aspx");
                    }
                    else
                    {
                        // Handle failed login (e.g., display error message)
                        P1.InnerText = "Login failed. Please check your credentials.";
                    }
                }
            }
        }

        private string HashPassword(string password)
        {
            // Implement a secure hashing function (e.g., bcrypt) to hash the password
            // This is a placeholder, replace with your actual hashing logic
            return password;
        }
    }
}
