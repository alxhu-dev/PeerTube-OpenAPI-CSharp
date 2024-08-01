# PeerTubeApiClient.Api.SessionApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetOAuthClient**](SessionApi.md#getoauthclient) | **GET** /api/v1/oauth-clients/local | Login prerequisite |
| [**GetOAuthToken**](SessionApi.md#getoauthtoken) | **POST** /api/v1/users/token | Login |
| [**RevokeOAuthToken**](SessionApi.md#revokeoauthtoken) | **POST** /api/v1/users/revoke-token | Logout |

<a id="getoauthclient"></a>
# **GetOAuthClient**
> OAuthClient GetOAuthClient ()

Login prerequisite

You need to retrieve a client id and secret before [logging in](#operation/getOAuthToken).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetOAuthClientExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new SessionApi(config);

            try
            {
                // Login prerequisite
                OAuthClient result = apiInstance.GetOAuthClient();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SessionApi.GetOAuthClient: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetOAuthClientWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Login prerequisite
    ApiResponse<OAuthClient> response = apiInstance.GetOAuthClientWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SessionApi.GetOAuthClientWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**OAuthClient**](OAuthClient.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getoauthtoken"></a>
# **GetOAuthToken**
> GetOAuthToken200Response GetOAuthToken (string? clientId = null, string? clientSecret = null, string? grantType = null, string? username = null, string? password = null, string? refreshToken = null)

Login

With your [client id and secret](#operation/getOAuthClient), you can retrieve an access and refresh tokens.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetOAuthTokenExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new SessionApi(config);
            var clientId = "clientId_example";  // string? |  (optional) 
            var clientSecret = "clientSecret_example";  // string? |  (optional) 
            var grantType = "password";  // string? |  (optional)  (default to password)
            var username = "username_example";  // string? | immutable name of the user, used to find or mention its actor (optional) 
            var password = "password_example";  // string? |  (optional) 
            var refreshToken = "refreshToken_example";  // string? |  (optional) 

            try
            {
                // Login
                GetOAuthToken200Response result = apiInstance.GetOAuthToken(clientId, clientSecret, grantType, username, password, refreshToken);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SessionApi.GetOAuthToken: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetOAuthTokenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Login
    ApiResponse<GetOAuthToken200Response> response = apiInstance.GetOAuthTokenWithHttpInfo(clientId, clientSecret, grantType, username, password, refreshToken);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SessionApi.GetOAuthTokenWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **clientId** | **string?** |  | [optional]  |
| **clientSecret** | **string?** |  | [optional]  |
| **grantType** | **string?** |  | [optional] [default to password] |
| **username** | **string?** | immutable name of the user, used to find or mention its actor | [optional]  |
| **password** | **string?** |  | [optional]  |
| **refreshToken** | **string?** |  | [optional]  |

### Return type

[**GetOAuthToken200Response**](GetOAuthToken200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | Disambiguate via &#x60;code&#x60;: - &#x60;invalid_client&#x60; for an unmatched &#x60;client_id&#x60; - &#x60;invalid_grant&#x60; for unmatched credentials  |  -  |
| **401** | Disambiguate via &#x60;code&#x60;: - default value for a regular authentication failure - &#x60;invalid_token&#x60; for an expired token - &#x60;missing_two_factor&#x60; if two factor header is missing  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="revokeoauthtoken"></a>
# **RevokeOAuthToken**
> void RevokeOAuthToken ()

Logout

Revokes your access token and its associated refresh token, destroying your current session.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class RevokeOAuthTokenExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SessionApi(config);

            try
            {
                // Logout
                apiInstance.RevokeOAuthToken();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SessionApi.RevokeOAuthToken: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the RevokeOAuthTokenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Logout
    apiInstance.RevokeOAuthTokenWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SessionApi.RevokeOAuthTokenWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

void (empty response body)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

