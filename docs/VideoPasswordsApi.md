# PeerTubeApiClient.Api.VideoPasswordsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1VideosIdPasswordsGet**](VideoPasswordsApi.md#apiv1videosidpasswordsget) | **GET** /api/v1/videos/{id}/passwords | List video passwords |
| [**ApiV1VideosIdPasswordsPut**](VideoPasswordsApi.md#apiv1videosidpasswordsput) | **PUT** /api/v1/videos/{id}/passwords | Update video passwords |
| [**ApiV1VideosIdPasswordsVideoPasswordIdDelete**](VideoPasswordsApi.md#apiv1videosidpasswordsvideopasswordiddelete) | **DELETE** /api/v1/videos/{id}/passwords/{videoPasswordId} | Delete a video password |

<a id="apiv1videosidpasswordsget"></a>
# **ApiV1VideosIdPasswordsGet**
> VideoPasswordList ApiV1VideosIdPasswordsGet (ApiV1VideosOwnershipIdAcceptPostIdParameter id, int? start = null, int? count = null, string? sort = null)

List video passwords

**PeerTube >= 6.0**

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdPasswordsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoPasswordsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List video passwords
                VideoPasswordList result = apiInstance.ApiV1VideosIdPasswordsGet(id, start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPasswordsApi.ApiV1VideosIdPasswordsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdPasswordsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List video passwords
    ApiResponse<VideoPasswordList> response = apiInstance.ApiV1VideosIdPasswordsGetWithHttpInfo(id, start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPasswordsApi.ApiV1VideosIdPasswordsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort column | [optional]  |

### Return type

[**VideoPasswordList**](VideoPasswordList.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | successful operation |  -  |
| **400** | video is not password protected |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1videosidpasswordsput"></a>
# **ApiV1VideosIdPasswordsPut**
> void ApiV1VideosIdPasswordsPut (ApiV1VideosOwnershipIdAcceptPostIdParameter id, ApiV1VideosIdPasswordsPutRequest? apiV1VideosIdPasswordsPutRequest = null)

Update video passwords

**PeerTube >= 6.0**

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdPasswordsPutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoPasswordsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var apiV1VideosIdPasswordsPutRequest = new ApiV1VideosIdPasswordsPutRequest?(); // ApiV1VideosIdPasswordsPutRequest? |  (optional) 

            try
            {
                // Update video passwords
                apiInstance.ApiV1VideosIdPasswordsPut(id, apiV1VideosIdPasswordsPutRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPasswordsApi.ApiV1VideosIdPasswordsPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdPasswordsPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update video passwords
    apiInstance.ApiV1VideosIdPasswordsPutWithHttpInfo(id, apiV1VideosIdPasswordsPutRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPasswordsApi.ApiV1VideosIdPasswordsPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **apiV1VideosIdPasswordsPutRequest** | [**ApiV1VideosIdPasswordsPutRequest?**](ApiV1VideosIdPasswordsPutRequest?.md) |  | [optional]  |

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
| **400** | video is not password protected |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1videosidpasswordsvideopasswordiddelete"></a>
# **ApiV1VideosIdPasswordsVideoPasswordIdDelete**
> void ApiV1VideosIdPasswordsVideoPasswordIdDelete (ApiV1VideosOwnershipIdAcceptPostIdParameter id, int videoPasswordId)

Delete a video password

**PeerTube >= 6.0**

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdPasswordsVideoPasswordIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoPasswordsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var videoPasswordId = 56;  // int | The video password id

            try
            {
                // Delete a video password
                apiInstance.ApiV1VideosIdPasswordsVideoPasswordIdDelete(id, videoPasswordId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPasswordsApi.ApiV1VideosIdPasswordsVideoPasswordIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdPasswordsVideoPasswordIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a video password
    apiInstance.ApiV1VideosIdPasswordsVideoPasswordIdDeleteWithHttpInfo(id, videoPasswordId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPasswordsApi.ApiV1VideosIdPasswordsVideoPasswordIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **videoPasswordId** | **int** | The video password id |  |

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
| **400** | video is not password protected |  -  |
| **403** | cannot delete the last password of the protected video |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

