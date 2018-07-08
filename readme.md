# Windows Keyboard Shortcuts Background Process
A background process which waits for a shortcut to be pressed (a key modifier such as the Alt key along with another key) and opens applications. The application paths and shortcuts are kept in a text file which the application reads from. You can have up to 35 shortcuts working at the same time (limited by number of keys).  
  
For example, if you have the path of Firefox in the text file after the string 'ALT F', the application will wait for Alt + F to be pressed and then open firefox. I have found it a very useful and time saving tool especially as it can be automatically run when Windows starts. It uses very little system resources but if you do want maximum performance for something else, then Alt + Q will end the process.

## Getting Started

### Get a Build

If all you want is to use the background process then you can find a build in the 'Build' folder. There is a pdf which tells you everything you need to know.  
Note: You need .NET Framework 4. This normally means Windows 10 OS.  
(Previous versions of .NET may work but you'll have to use the source code to change the build target and rebuild)

### Using the Source Code
If you want to use the source code, you can find it in the 'Source' folder. It was written in C# using Visual Studio 2015 targeted at .NET Framework 4. It is technically a WinForms application but the 'forms' part has been disabled so it acts like a background process. Almost all of the code is within the Form1.cs file.

## License

You may download/use/distribute/modify/host/sell the code however you like. There are no restrictions.