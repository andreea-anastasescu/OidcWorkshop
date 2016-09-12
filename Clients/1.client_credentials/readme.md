
# Implementing the client credentials grant type
With the client credentials grant type, an app sends its own credentials (the Client ID and Client Secret) to an endpoint that is set up to generate an access token. 
If the credentials are valid, Authorization Server/IdP returns an access token to the client app.



![client_credentials flow](/Clients/1.client_credentials/image001.png)
<br/>(image source: https://www.ibm.com/developerworks/library/se-oauthjavapt2/)

#Use cases

Most typically, this grant type is used when the app is also the resource owner. 
For example, an app may need to access an API which exposes data that it uses to perform its work, rather than data specifically owned by the end user.
In the 'Adventure Travel Agency' case, the list of expeditions is such a resource
This grant type flow occurs strictly between a client app and the authorization server. An end user does not participate in this grant type flow. 

