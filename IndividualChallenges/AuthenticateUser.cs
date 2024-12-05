public class Authentication
{
 
    public void AuthenticateUser(string password)
    {
        string hashedInputPassword = HashPassword(password);
        // Compare hashed password with stored hashed password
        if (hashedInputPassword == storedHashedPassword)
        {
            GrantAccess();
        }
        else
        {
            Console.WriteLine("Access Denied.");
        }
    }
 
    private void GrantAccess()
    {
        Console.WriteLine("Access Granted!");
    }
 
    private string HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
