This is a sample Api which exposes protected resources.

e.g. making a GET request ```http://localhost:8232/api/topexpeditions```
without an access token, will result in receiving a 401 response code (Unauthorized).

Having a proper access token, a request can be made also with curl/powershell:Invoke-WebRequest

```
> Invoke-WebRequest -Uri http://localhost:8232/api/topexpeditions -H @ {"Authorization"="Bearer <access token>"}
```
