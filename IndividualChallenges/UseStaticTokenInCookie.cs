using System;
using System.Web;
using System.Security.Cryptography;

public void UseDynamicTokenInCookie()
{
    // Generate a unique, secure token
    string token = GenerateSecureToken();
    
    // Create a cookie with the secure token
    HttpCookie authCookie = new HttpCookie("auth", token);
    Response.Cookies.Add(authCookie);
    Console.WriteLine("Dynamic authentication token added to cookies.");
}

private string GenerateSecureToken()
{
    using (var rng = new RNGCryptoServiceProvider())
    {
        byte[] tokenData = new byte[32];
        rng.GetBytes(tokenData);
        return Convert.ToBase64String(tokenData);
    }
}
