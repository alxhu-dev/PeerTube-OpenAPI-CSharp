# PeerTubeApiClient.Api.VideoOwnershipChangeApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1VideosIdGiveOwnershipPost**](VideoOwnershipChangeApi.md#apiv1videosidgiveownershippost) | **POST** /api/v1/videos/{id}/give-ownership | Request ownership change |
| [**ApiV1VideosOwnershipGet**](VideoOwnershipChangeApi.md#apiv1videosownershipget) | **GET** /api/v1/videos/ownership | List video ownership changes |
| [**ApiV1VideosOwnershipIdAcceptPost**](VideoOwnershipChangeApi.md#apiv1videosownershipidacceptpost) | **POST** /api/v1/videos/ownership/{id}/accept | Accept ownership change request |
| [**ApiV1VideosOwnershipIdRefusePost**](VideoOwnershipChangeApi.md#apiv1videosownershipidrefusepost) | **POST** /api/v1/videos/ownership/{id}/refuse | Refuse ownership change request |

<a id="apiv1videosidgiveownershippost"></a>
# **ApiV1VideosIdGiveOwnershipPost**
> void ApiV1VideosIdGiveOwnershipPost (ApiV1VideosOwnershipIdAcceptPostIdParameter id, string username)

Request ownership change

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdGiveOwnershipPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoOwnershipChangeApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var username = "username_example";  // string | 

            try
            {
                // Request ownership change
                apiInstance.ApiV1VideosIdGiveOwnershipPost(id, username);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoOwnershipChangeApi.ApiV1VideosIdGiveOwnershipPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdGiveOwnershipPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Request ownership change
    apiInstance.ApiV1VideosIdGiveOwnershipPostWithHttpInfo(id, username);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoOwnershipChangeApi.ApiV1VideosIdGiveOwnershipPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **username** | **string** |  |  |

### Return type

void (empty response body)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | successful operation |  -  |
| **400** | changing video ownership to a remote account is not supported yet |  -  |
| **404** | video not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1videosownershipget"></a>
# **ApiV1VideosOwnershipGet**
> void ApiV1VideosOwnershipGet ()

List video ownership changes

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosOwnershipGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoOwnershipChangeApi(config);

            try
            {
                // List video ownership changes
                apiInstance.ApiV1VideosOwnershipGet();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoOwnershipChangeApi.ApiV1VideosOwnershipGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosOwnershipGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List video ownership changes
    apiInstance.ApiV1VideosOwnershipGetWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoOwnershipChangeApi.ApiV1VideosOwnershipGetWithHttpInfo: " + e.Message);
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

<a id="apiv1videosownershipidacceptpost"></a>
# **ApiV1VideosOwnershipIdAcceptPost**
> void ApiV1VideosOwnershipIdAcceptPost (ApiV1VideosOwnershipIdAcceptPostIdParameter id)

Accept ownership change request

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosOwnershipIdAcceptPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoOwnershipChangeApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid

            try
            {
                // Accept ownership change request
                apiInstance.ApiV1VideosOwnershipIdAcceptPost(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoOwnershipChangeApi.ApiV1VideosOwnershipIdAcceptPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosOwnershipIdAcceptPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Accept ownership change request
    apiInstance.ApiV1VideosOwnershipIdAcceptPostWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoOwnershipChangeApi.ApiV1VideosOwnershipIdAcceptPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |

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
| **403** | cannot terminate an ownership change of another user |  -  |
| **404** | video ownership change not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1videosownershipidrefusepost"></a>
# **ApiV1VideosOwnershipIdRefusePost**
> void ApiV1VideosOwnershipIdRefusePost (ApiV1VideosOwnershipIdAcceptPostIdParameter id)

Refuse ownership change request

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosOwnershipIdRefusePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoOwnershipChangeApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid

            try
            {
                // Refuse ownership change request
                apiInstance.ApiV1VideosOwnershipIdRefusePost(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoOwnershipChangeApi.ApiV1VideosOwnershipIdRefusePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosOwnershipIdRefusePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Refuse ownership change request
    apiInstance.ApiV1VideosOwnershipIdRefusePostWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoOwnershipChangeApi.ApiV1VideosOwnershipIdRefusePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |

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
| **403** | cannot terminate an ownership change of another user |  -  |
| **404** | video ownership change not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

