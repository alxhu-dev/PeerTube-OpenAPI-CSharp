# PeerTubeApiClient.Api.RunnerRegistrationTokenApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1RunnersRegistrationTokensGeneratePost**](RunnerRegistrationTokenApi.md#apiv1runnersregistrationtokensgeneratepost) | **POST** /api/v1/runners/registration-tokens/generate | Generate registration token |
| [**ApiV1RunnersRegistrationTokensGet**](RunnerRegistrationTokenApi.md#apiv1runnersregistrationtokensget) | **GET** /api/v1/runners/registration-tokens | List registration tokens |
| [**ApiV1RunnersRegistrationTokensRegistrationTokenIdDelete**](RunnerRegistrationTokenApi.md#apiv1runnersregistrationtokensregistrationtokeniddelete) | **DELETE** /api/v1/runners/registration-tokens/{registrationTokenId} | Remove registration token |

<a id="apiv1runnersregistrationtokensgeneratepost"></a>
# **ApiV1RunnersRegistrationTokensGeneratePost**
> void ApiV1RunnersRegistrationTokensGeneratePost ()

Generate registration token

Generate a new runner registration token

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersRegistrationTokensGeneratePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RunnerRegistrationTokenApi(config);

            try
            {
                // Generate registration token
                apiInstance.ApiV1RunnersRegistrationTokensGeneratePost();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnerRegistrationTokenApi.ApiV1RunnersRegistrationTokensGeneratePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersRegistrationTokensGeneratePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Generate registration token
    apiInstance.ApiV1RunnersRegistrationTokensGeneratePostWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnerRegistrationTokenApi.ApiV1RunnersRegistrationTokensGeneratePostWithHttpInfo: " + e.Message);
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
| **204** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1runnersregistrationtokensget"></a>
# **ApiV1RunnersRegistrationTokensGet**
> ApiV1RunnersRegistrationTokensGet200Response ApiV1RunnersRegistrationTokensGet (int? start = null, int? count = null, string? sort = null)

List registration tokens

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersRegistrationTokensGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RunnerRegistrationTokenApi(config);
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = "createdAt";  // string? | Sort registration tokens by criteria (optional) 

            try
            {
                // List registration tokens
                ApiV1RunnersRegistrationTokensGet200Response result = apiInstance.ApiV1RunnersRegistrationTokensGet(start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnerRegistrationTokenApi.ApiV1RunnersRegistrationTokensGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersRegistrationTokensGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List registration tokens
    ApiResponse<ApiV1RunnersRegistrationTokensGet200Response> response = apiInstance.ApiV1RunnersRegistrationTokensGetWithHttpInfo(start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnerRegistrationTokenApi.ApiV1RunnersRegistrationTokensGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort registration tokens by criteria | [optional]  |

### Return type

[**ApiV1RunnersRegistrationTokensGet200Response**](ApiV1RunnersRegistrationTokensGet200Response.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1runnersregistrationtokensregistrationtokeniddelete"></a>
# **ApiV1RunnersRegistrationTokensRegistrationTokenIdDelete**
> void ApiV1RunnersRegistrationTokensRegistrationTokenIdDelete (int registrationTokenId)

Remove registration token

Remove a registration token. Runners that used this token for their registration are automatically removed.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersRegistrationTokensRegistrationTokenIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RunnerRegistrationTokenApi(config);
            var registrationTokenId = 56;  // int | 

            try
            {
                // Remove registration token
                apiInstance.ApiV1RunnersRegistrationTokensRegistrationTokenIdDelete(registrationTokenId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnerRegistrationTokenApi.ApiV1RunnersRegistrationTokensRegistrationTokenIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersRegistrationTokensRegistrationTokenIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Remove registration token
    apiInstance.ApiV1RunnersRegistrationTokensRegistrationTokenIdDeleteWithHttpInfo(registrationTokenId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnerRegistrationTokenApi.ApiV1RunnersRegistrationTokensRegistrationTokenIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **registrationTokenId** | **int** |  |  |

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
| **204** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

