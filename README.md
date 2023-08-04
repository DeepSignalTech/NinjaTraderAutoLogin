# NinjaTraderAutoLogin

This console application is intended to allow the user to automatically log in for NinjaTrader 8.1.x. The user must run the application with at least 2 arguments. It must include the login name and the password surrounded by quotes.

    NTLogin.exe "LOGIN_NAME" "PASSWORD"

Optionally it can include a third parameter if the NinjaTrader.exe is not at the default installation location of "C:\Program Files\NinjaTrader 8\bin\NinjaTrader.exe".

    NTLogin.exe "LOGIN_NAME" "PASSWORD" "C:\Program Files\NinjaTrader 8\bin\NinjaTrader.exe"

Change the "C:\Program Files\NinjaTrader 8\bin\NinjaTrader.exe" to the installation location.

We created a Windows shortcut for NTLogin in which we modified the Target field in the Shortcut tab to include the additional parameters. Now just double click on the shortcut and you can be automatically logged into NinjaTrader without having to manually type in your password every time.

** Please note the LOGIN_NAME is currently only a placeholder for future development in case we need it. The application assumes the login name is already saved in the Login Dialog. The application only runs NinjaTrader and pastes the password from the arguments into the password text box.


HOW TO USE THE NTLOGIN

Assuming you compiled it with Visual Studio, you can right click on the NTLogin.exe in Windows Explorer, copy the file then paste as a shortcut on your desktop.

In the "NTLogin.exe - Shortcut" file on your desktop, right click, click on Properties, then Shortcut. In the Target edit field you need to add on your username and password. The field should look something like this:

Target: [some folder]\NTLogin.exe "YOUR_USERNAME" "YOUR_PASSWORD"

Where the [some folder] is wherever you compiled it, then you need to fill in YOUR_USERNAME and YOUR_PASSWORD with your Ninja username and password.

Then just double click on the "NTLogin.exe - Shortcut" and Ninja should automatically fill in your password for you. 
