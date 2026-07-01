// ==========================================================
// Task 1.8: Preprocessor Directives and Code Folding (#region)
// ==========================================================

// 1. PREPROCESSOR DIRECTIVE
// MUST be at the very top of the file! 
// Comment out the line below to switch the application to the "Full" version.
// #define TRIAL_VERSION 

using System;

// 2. CONDITIONAL COMPILATION (#if / #else / #endif)
// The compiler will only include the code block that matches the condition.
#if TRIAL_VERSION
    string appMessage = "Welcome to the TRIAL Version! Please upgrade to unlock all features.";
#else
    string appMessage = "Welcome to the FULL Version! You have access to all premium features.";
#endif

Console.WriteLine(appMessage);
Console.WriteLine("--------------------------------------------------");

// Instantiate the class to test the #region folding
UserAccount myAccount = new UserAccount("greevan.impact");
myAccount.PrintStatus();
myAccount.Deactivate();
myAccount.PrintStatus();


// ==========================================================
// 3. CODE FOLDING WITH #region
// This groups code logically so you can collapse/expand it in your IDE.
// ==========================================================

public class UserAccount
{
    #region Fields
    // Private backing fields (camelCase with underscore prefix)
    private string _username;
    private bool _isActive;
    #endregion

    #region Properties
    // Public properties (PascalCase)
    public string Username 
    { 
        get => _username; 
        set => _username = value; 
    }
    
    public bool IsActive 
    { 
        get => _isActive; 
        set => _isActive = value; 
    }
    #endregion

    #region Constructors
    // Constructor (PascalCase, same name as class)
    public UserAccount(string username)
    {
        _username = username;
        _isActive = true; // Default new users to active
    }
    #endregion

    #region Methods
    // Public methods (PascalCase)
    public void Deactivate()
    {
        _isActive = false;
    }

    public void PrintStatus()
    {
        string status = _isActive ? "Active" : "Inactive";
        Console.WriteLine($"User: {_username} | Status: {status}");
    }
    #endregion
}