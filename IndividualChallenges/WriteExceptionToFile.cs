public void WriteExceptionToFile(Exception ex)
{
    try
    {
        DoSomethingRisky();
    }
    catch (Exception caughtEx)
    {
        LogExceptionToFile(caughtEx);
    }
}


private void LogExceptionToFile(Exception ex)
{
    try
    {
        string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");
        string logMessage = $"{DateTime.Now}: {ex.ToString()}";
        
        // Append to the log file to avoid overwriting previous logs
        File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
    }
    catch (Exception logEx)
    {
        // Handle any exceptions that occur during logging
        Console.WriteLine("Failed to log exception: " + logEx.ToString());
    }
}
