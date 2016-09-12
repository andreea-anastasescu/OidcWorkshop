
# Implementing the client credentials grant type (OAuth2)
With the client credentials grant type, an app sends its own credentials (ususally with a pair of Client ID and Client Secret, but it is also possible to use a certificate instead of client secret) to an endpoint that is set up to generate an access token. 
If the credentials are valid, Authorization Server/IdP returns an access token to the client app.

![client_credentials](/Clients/1.client_credentials/image001.png)
<br/>(image source: https://www.ibm.com/developerworks/library/se-oauthjavapt2/)

##Use cases

Most typically, this grant type is used when the app is also the resource owner. 
For example, an app may need to access an API which exposes data that it uses to perform its work, rather than data specifically owned by the end user.
In the 'Adventure Travel Agency' case, the list of expeditions is such a resource
This grant type flow occurs strictly between a client app and the authorization server. An end user does not participate in this grant type flow.

##Roles

Roles specify the "actors" that participate in the OAuth flow. Let's do a quick overview of the client credentials roles to help illustrate where Apigee Edge fits in. For a complete discussion of OAuth 2.0 roles, see the [IETF OAuth 2.0 specification](https://tools.ietf.org/html/draft-ietf-oauth-v2-31). 

* 'Client' as Resourse Owner -- The app that needs access to a protected resource. Typically, with this flow, the app runs on server rather than locally on the user's laptop or device.
* local Identity Server as Authorization Server -- In this flow, the idServer is the OAuth authorization server. Its role is to generate access tokens, validate access token.
* 'Api' as the Resource Server -- The backend service that stores the protected data that the client app needs permission to access. 

![client_credentials](/Clients/1.client_credentials/client_credentials_flow.png)
