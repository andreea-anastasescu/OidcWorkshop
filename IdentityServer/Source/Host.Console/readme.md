Self-hosting a WebApi with Owin is easy…

Just start a console application, add the nuget packages and start your server like:
WebApp.Start("https://localhost:12345", app => ...some action...
);
The SSL configuration is not really well documented, as it is not really part of the programming model, rather the configuration part. In case of hosting under IIS, it is more explicitly requested for an https binding.

In this case, it has to be done manually, using the ‘netsh’ command, like:

```D:\>netsh http add sslcert ipport=0.0.0.0:12345 certhash=1bc86a6dd1e7f4ecffec37f0214a2ce6422c72c2 appid={00000000-0000-0000-0000-000000000000} certstorename=MY
Where certhash is the thumbprint of the certificate which is to be used for ssl communication.```

Of course it has to be a trusted certificate, even if a self-signed one is used for local/dev purposes and the hosting process needs to have access to its private keys.

To check the certificates which are alocated on ssl ports just run:
```netsh http show sslcert```
