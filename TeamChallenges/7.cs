using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;

namespace InsecureLoginAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private const string connectionString = "Server=myServer;Database=myDB;User Id=admin;Password=admin123;";

        // 1. SQL Injection (Unsanitized user input in queries)
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            string username = model.Username;
            string password = model.Password;
            string query = $"SELECT * FROM Users WHERE Username = @username AND Password = @password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username); 
                cmd.Parameters.AddWithValue("@Password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return Ok("Login Successful");
                }
                else
                {
                    return Unauthorized("Login Failed");
                }
            }
        }

        // 2. Insecure Password Storage (Plaintext password handling)
        [HttpPost("storePassword")]
        public IActionResult StorePassword([FromBody] string password)
        {
            System.IO.File.WriteAllText("passwords.txt", password); // Storing password in plaintext            
            return Ok("Password stored securely... NOT");
        }

        // 3. Improper Exception Handling (Sensitive info logged)
        [HttpGet("testError")]
        public IActionResult TestError()
        {
            try
            {
                throw new Exception("Critical Error!"); // Unhandled exception
            }
            catch (Exception ex)
            {
                // Logging exception details to file (vulnerable)
                System.IO.File.AppendAllText("error_log.txt", ex.Message);
                return BadRequest("An error occurred");
            }
        }

        // 4. Hardcoded Credentials (Vulnerable to compromise)
        [HttpGet("adminAccess")]
        public IActionResult AdminAccess()
        {
            string adminPassword = Environment.GetEnvironmentVariable("PASSWORD"); 
            if (adminPassword == "admin123")
            {
                return Ok("Admin access granted");
            }
            return Unauthorized("Access denied");
        }

        // 5. Unvalidated Input Handling (XSS vulnerability in HTML response)
        [HttpGet("greet")]
        public IActionResult GreetUser(string username)
        {
            string safeInput = HttpUtility.HtmlEncode(username); 
            string response = $"<h1>Hello, {safeInput}!</h1>"; 
            return Content(response); // Vulnerable to XSS
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
