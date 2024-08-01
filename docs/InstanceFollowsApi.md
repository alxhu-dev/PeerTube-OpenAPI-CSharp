# PeerTubeApiClient.Api.InstanceFollowsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1ServerFollowersGet**](InstanceFollowsApi.md#apiv1serverfollowersget) | **GET** /api/v1/server/followers | List instances following the server |
| [**ApiV1ServerFollowersNameWithHostAcceptPost**](InstanceFollowsApi.md#apiv1serverfollowersnamewithhostacceptpost) | **POST** /api/v1/server/followers/{nameWithHost}/accept | Accept a pending follower to your server |
| [**ApiV1ServerFollowersNameWithHostDelete**](InstanceFollowsApi.md#apiv1serverfollowersnamewithhostdelete) | **DELETE** /api/v1/server/followers/{nameWithHost} | Remove or reject a follower to your server |
| [**ApiV1ServerFollowersNameWithHostRejectPost**](InstanceFollowsApi.md#apiv1serverfollowersnamewithhostrejectpost) | **POST** /api/v1/server/followers/{nameWithHost}/reject | Reject a pending follower to your server |
| [**ApiV1ServerFollowingGet**](InstanceFollowsApi.md#apiv1serverfollowingget) | **GET** /api/v1/server/following | List instances followed by the server |
| [**ApiV1ServerFollowingHostOrHandleDelete**](InstanceFollowsApi.md#apiv1serverfollowinghostorhandledelete) | **DELETE** /api/v1/server/following/{hostOrHandle} | Unfollow an actor (PeerTube instance, channel or account) |
| [**ApiV1ServerFollowingPost**](InstanceFollowsApi.md#apiv1serverfollowingpost) | **POST** /api/v1/server/following | Follow a list of actors (PeerTube instance, channel or account) |

<a id="apiv1serverfollowersget"></a>
# **ApiV1ServerFollowersGet**
> GetAccountFollowers200Response ApiV1ServerFollowersGet (string? state = null, string? actorType = null, int? start = null, int? count = null, string? sort = null)

List instances following the server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ServerFollowersGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new InstanceFollowsApi(config);
            var state = "pending";  // string? |  (optional) 
            var actorType = "Person";  // string? |  (optional) 
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List instances following the server
                GetAccountFollowers200Response result = apiInstance.ApiV1ServerFollowersGet(state, actorType, start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InstanceFollowsApi.ApiV1ServerFollowersGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ServerFollowersGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List instances following the server
    ApiResponse<GetAccountFollowers200Response> response = apiInstance.ApiV1ServerFollowersGetWithHttpInfo(state, actorType, start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InstanceFollowsApi.ApiV1ServerFollowersGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **state** | **string?** |  | [optional]  |
| **actorType** | **string?** |  | [optional]  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort column | [optional]  |

### Return type

[**GetAccountFollowers200Response**](GetAccountFollowers200Response.md)

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

<a id="apiv1serverfollowersnamewithhostacceptpost"></a>
# **ApiV1ServerFollowersNameWithHostAcceptPost**
> void ApiV1ServerFollowersNameWithHostAcceptPost (string nameWithHost)

Accept a pending follower to your server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ServerFollowersNameWithHostAcceptPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InstanceFollowsApi(config);
            var nameWithHost = "nameWithHost_example";  // string | The remote actor handle to remove from your followers

            try
            {
                // Accept a pending follower to your server
                apiInstance.ApiV1ServerFollowersNameWithHostAcceptPost(nameWithHost);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InstanceFollowsApi.ApiV1ServerFollowersNameWithHostAcceptPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ServerFollowersNameWithHostAcceptPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Accept a pending follower to your server
    apiInstance.ApiV1ServerFollowersNameWithHostAcceptPostWithHttpInfo(nameWithHost);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InstanceFollowsApi.ApiV1ServerFollowersNameWithHostAcceptPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **nameWithHost** | **string** | The remote actor handle to remove from your followers |  |

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
| **404** | follower not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1serverfollowersnamewithhostdelete"></a>
# **ApiV1ServerFollowersNameWithHostDelete**
> void ApiV1ServerFollowersNameWithHostDelete (string nameWithHost)

Remove or reject a follower to your server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ServerFollowersNameWithHostDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InstanceFollowsApi(config);
            var nameWithHost = "nameWithHost_example";  // string | The remote actor handle to remove from your followers

            try
            {
                // Remove or reject a follower to your server
                apiInstance.ApiV1ServerFollowersNameWithHostDelete(nameWithHost);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InstanceFollowsApi.ApiV1ServerFollowersNameWithHostDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ServerFollowersNameWithHostDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Remove or reject a follower to your server
    apiInstance.ApiV1ServerFollowersNameWithHostDeleteWithHttpInfo(nameWithHost);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InstanceFollowsApi.ApiV1ServerFollowersNameWithHostDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **nameWithHost** | **string** | The remote actor handle to remove from your followers |  |

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
| **404** | follower not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1serverfollowersnamewithhostrejectpost"></a>
# **ApiV1ServerFollowersNameWithHostRejectPost**
> void ApiV1ServerFollowersNameWithHostRejectPost (string nameWithHost)

Reject a pending follower to your server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ServerFollowersNameWithHostRejectPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InstanceFollowsApi(config);
            var nameWithHost = "nameWithHost_example";  // string | The remote actor handle to remove from your followers

            try
            {
                // Reject a pending follower to your server
                apiInstance.ApiV1ServerFollowersNameWithHostRejectPost(nameWithHost);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InstanceFollowsApi.ApiV1ServerFollowersNameWithHostRejectPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ServerFollowersNameWithHostRejectPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Reject a pending follower to your server
    apiInstance.ApiV1ServerFollowersNameWithHostRejectPostWithHttpInfo(nameWithHost);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InstanceFollowsApi.ApiV1ServerFollowersNameWithHostRejectPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **nameWithHost** | **string** | The remote actor handle to remove from your followers |  |

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
| **404** | follower not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1serverfollowingget"></a>
# **ApiV1ServerFollowingGet**
> GetAccountFollowers200Response ApiV1ServerFollowingGet (string? state = null, string? actorType = null, int? start = null, int? count = null, string? sort = null)

List instances followed by the server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ServerFollowingGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new InstanceFollowsApi(config);
            var state = "pending";  // string? |  (optional) 
            var actorType = "Person";  // string? |  (optional) 
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List instances followed by the server
                GetAccountFollowers200Response result = apiInstance.ApiV1ServerFollowingGet(state, actorType, start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InstanceFollowsApi.ApiV1ServerFollowingGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ServerFollowingGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List instances followed by the server
    ApiResponse<GetAccountFollowers200Response> response = apiInstance.ApiV1ServerFollowingGetWithHttpInfo(state, actorType, start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InstanceFollowsApi.ApiV1ServerFollowingGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **state** | **string?** |  | [optional]  |
| **actorType** | **string?** |  | [optional]  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort column | [optional]  |

### Return type

[**GetAccountFollowers200Response**](GetAccountFollowers200Response.md)

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

<a id="apiv1serverfollowinghostorhandledelete"></a>
# **ApiV1ServerFollowingHostOrHandleDelete**
> void ApiV1ServerFollowingHostOrHandleDelete (string hostOrHandle)

Unfollow an actor (PeerTube instance, channel or account)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ServerFollowingHostOrHandleDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InstanceFollowsApi(config);
            var hostOrHandle = "hostOrHandle_example";  // string | The hostOrHandle to unfollow

            try
            {
                // Unfollow an actor (PeerTube instance, channel or account)
                apiInstance.ApiV1ServerFollowingHostOrHandleDelete(hostOrHandle);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InstanceFollowsApi.ApiV1ServerFollowingHostOrHandleDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ServerFollowingHostOrHandleDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Unfollow an actor (PeerTube instance, channel or account)
    apiInstance.ApiV1ServerFollowingHostOrHandleDeleteWithHttpInfo(hostOrHandle);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InstanceFollowsApi.ApiV1ServerFollowingHostOrHandleDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **hostOrHandle** | **string** | The hostOrHandle to unfollow |  |

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
| **404** | host or handle not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1serverfollowingpost"></a>
# **ApiV1ServerFollowingPost**
> void ApiV1ServerFollowingPost (ApiV1ServerFollowingPostRequest? apiV1ServerFollowingPostRequest = null)

Follow a list of actors (PeerTube instance, channel or account)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ServerFollowingPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InstanceFollowsApi(config);
            var apiV1ServerFollowingPostRequest = new ApiV1ServerFollowingPostRequest?(); // ApiV1ServerFollowingPostRequest? |  (optional) 

            try
            {
                // Follow a list of actors (PeerTube instance, channel or account)
                apiInstance.ApiV1ServerFollowingPost(apiV1ServerFollowingPostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InstanceFollowsApi.ApiV1ServerFollowingPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ServerFollowingPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Follow a list of actors (PeerTube instance, channel or account)
    apiInstance.ApiV1ServerFollowingPostWithHttpInfo(apiV1ServerFollowingPostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InstanceFollowsApi.ApiV1ServerFollowingPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **apiV1ServerFollowingPostRequest** | [**ApiV1ServerFollowingPostRequest?**](ApiV1ServerFollowingPostRequest?.md) |  | [optional]  |

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
| **500** | cannot follow a non-HTTPS server |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

