public void AuthenticateWithEnvironmentVariable()
{
    string password = Environment.GetEnvironmentVariable("AUTH_PASSWORD"); // Secure: Uses environment variable
    Console.WriteLine("Authenticating with environment variable.");

    // Simulate authentication
    if (password == "P@ssword!")
    {
        Console.WriteLine("Authentication successful.");
    }
    else
    {
        Console.WriteLine("Authentication failed.");
    }
}
