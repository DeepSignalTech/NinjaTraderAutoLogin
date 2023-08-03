# NinjaTraderAutoLogin

This console application is intended to allow the user to automatically log in for NinjaTrader 8.1.x. The user must run the application with at least 2 arguments. It must include the login name and the password surrounded by quotes.

    NTLogin.exe "LOGIN_NAME" "PASSWORD"

Optionally it can include a third parameter if the NinjaTrader.exe is not at the default installation location of "C:\Program Files\NinjaTrader 8\bin\NinjaTrader.exe".

    NTLogin.exe "LOGIN_NAME" "PASSWORD" "C:\Program Files\NinjaTrader 8\bin\NinjaTrader.exe"

Change the "C:\Program Files\NinjaTrader 8\bin\NinjaTrader.exe" to the installation location.

We created a Windows shortcut for NTLogin in which we modified the Target field in the Shortcut tab to include the additional parameters. Now just double click on the shortcut and you can be automatically logged into NinjaTrader without having to manually type in your password every time.

** Please note the LOGIN_NAME is currently only a placeholder for future development in case we need it. The application assumes the login name is already saved in the Login Dialog. The application only runs NinjaTrader and pastes the password from the arguments into the password text box.
