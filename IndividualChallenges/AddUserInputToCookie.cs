public void AddUserInputToCookie(string userInput)
{
    // Validate and sanitize user input
    string sanitizedInput = SanitizeInput(userInput);
    
    if (IsValidInput(sanitizedInput))
    {
        Response.Cookies.Add(new HttpCookie("SessionID", sanitizedInput));
        Console.WriteLine("Cookie added with user input: " + sanitizedInput);
    }
    else
    {
        Console.WriteLine("Invalid user input.");
    }
}

private string SanitizeInput(string input)
{
    // Implement input sanitization logic here
    // For example, remove any dangerous characters or patterns
    return input.Replace("<", "").Replace(">", "").Replace("'", "").Replace("\"", "");
}

private bool IsValidInput(string input)
{
    // Implement input validation logic here
    // For example, check the length and allowed characters
    return !string.IsNullOrEmpty(input) && input.Length <= 100; // Example validation
}
