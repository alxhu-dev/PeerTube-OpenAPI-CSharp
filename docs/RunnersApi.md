# PeerTubeApiClient.Api.RunnersApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1RunnersGet**](RunnersApi.md#apiv1runnersget) | **GET** /api/v1/runners | List runners |
| [**ApiV1RunnersRegisterPost**](RunnersApi.md#apiv1runnersregisterpost) | **POST** /api/v1/runners/register | Register a new runner |
| [**ApiV1RunnersRunnerIdDelete**](RunnersApi.md#apiv1runnersrunneriddelete) | **DELETE** /api/v1/runners/{runnerId} | Delete a runner |
| [**ApiV1RunnersUnregisterPost**](RunnersApi.md#apiv1runnersunregisterpost) | **POST** /api/v1/runners/unregister | Unregister a runner |

<a id="apiv1runnersget"></a>
# **ApiV1RunnersGet**
> ApiV1RunnersGet200Response ApiV1RunnersGet (int? start = null, int? count = null, string? sort = null)

List runners

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RunnersApi(config);
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = "createdAt";  // string? | Sort runners by criteria (optional) 

            try
            {
                // List runners
                ApiV1RunnersGet200Response result = apiInstance.ApiV1RunnersGet(start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnersApi.ApiV1RunnersGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List runners
    ApiResponse<ApiV1RunnersGet200Response> response = apiInstance.ApiV1RunnersGetWithHttpInfo(start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnersApi.ApiV1RunnersGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort runners by criteria | [optional]  |

### Return type

[**ApiV1RunnersGet200Response**](ApiV1RunnersGet200Response.md)

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

<a id="apiv1runnersregisterpost"></a>
# **ApiV1RunnersRegisterPost**
> ApiV1RunnersRegisterPost200Response ApiV1RunnersRegisterPost (ApiV1RunnersRegisterPostRequest? apiV1RunnersRegisterPostRequest = null)

Register a new runner

API used by PeerTube runners

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersRegisterPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new RunnersApi(config);
            var apiV1RunnersRegisterPostRequest = new ApiV1RunnersRegisterPostRequest?(); // ApiV1RunnersRegisterPostRequest? |  (optional) 

            try
            {
                // Register a new runner
                ApiV1RunnersRegisterPost200Response result = apiInstance.ApiV1RunnersRegisterPost(apiV1RunnersRegisterPostRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnersApi.ApiV1RunnersRegisterPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersRegisterPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Register a new runner
    ApiResponse<ApiV1RunnersRegisterPost200Response> response = apiInstance.ApiV1RunnersRegisterPostWithHttpInfo(apiV1RunnersRegisterPostRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnersApi.ApiV1RunnersRegisterPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **apiV1RunnersRegisterPostRequest** | [**ApiV1RunnersRegisterPostRequest?**](ApiV1RunnersRegisterPostRequest?.md) |  | [optional]  |

### Return type

[**ApiV1RunnersRegisterPost200Response**](ApiV1RunnersRegisterPost200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1runnersrunneriddelete"></a>
# **ApiV1RunnersRunnerIdDelete**
> void ApiV1RunnersRunnerIdDelete (int runnerId, ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = null)

Delete a runner

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersRunnerIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RunnersApi(config);
            var runnerId = 56;  // int | 
            var apiV1RunnersUnregisterPostRequest = new ApiV1RunnersUnregisterPostRequest?(); // ApiV1RunnersUnregisterPostRequest? |  (optional) 

            try
            {
                // Delete a runner
                apiInstance.ApiV1RunnersRunnerIdDelete(runnerId, apiV1RunnersUnregisterPostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnersApi.ApiV1RunnersRunnerIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersRunnerIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a runner
    apiInstance.ApiV1RunnersRunnerIdDeleteWithHttpInfo(runnerId, apiV1RunnersUnregisterPostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnersApi.ApiV1RunnersRunnerIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **runnerId** | **int** |  |  |
| **apiV1RunnersUnregisterPostRequest** | [**ApiV1RunnersUnregisterPostRequest?**](ApiV1RunnersUnregisterPostRequest?.md) |  | [optional]  |

### Return type

void (empty response body)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1runnersunregisterpost"></a>
# **ApiV1RunnersUnregisterPost**
> void ApiV1RunnersUnregisterPost (ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = null)

Unregister a runner

API used by PeerTube runners

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersUnregisterPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new RunnersApi(config);
            var apiV1RunnersUnregisterPostRequest = new ApiV1RunnersUnregisterPostRequest?(); // ApiV1RunnersUnregisterPostRequest? |  (optional) 

            try
            {
                // Unregister a runner
                apiInstance.ApiV1RunnersUnregisterPost(apiV1RunnersUnregisterPostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnersApi.ApiV1RunnersUnregisterPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersUnregisterPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Unregister a runner
    apiInstance.ApiV1RunnersUnregisterPostWithHttpInfo(apiV1RunnersUnregisterPostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnersApi.ApiV1RunnersUnregisterPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **apiV1RunnersUnregisterPostRequest** | [**ApiV1RunnersUnregisterPostRequest?**](ApiV1RunnersUnregisterPostRequest?.md) |  | [optional]  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

