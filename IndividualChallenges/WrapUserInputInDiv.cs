using System.Web;

public void WrapUserInputInDiv(string userInput)
{
    // Secure: Encode user input to prevent XSS attacks
    var encodedInput = HttpUtility.HtmlEncode(userInput);
    var content = "<div>" + encodedInput + "</div>";
    Console.WriteLine("Generated content: " + content);
}
