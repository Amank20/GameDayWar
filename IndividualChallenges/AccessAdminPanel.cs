public void AccessAdminPanel(string username, string password)
{ 
    string storedUsername = "admin"; // Stored username (in reality, this would be securely stored)
    string storedPassword = "yourSecurePassword"; // Stored password (hashed and salted in reality)

    // Check if the provided username and password match the stored ones
    if (username == storedUsername && password == storedPassword)
    {
        Console.WriteLine("Access to Admin Panel Granted!");
    }
    else
    {
        Console.WriteLine("Access Denied.");
    }
}
