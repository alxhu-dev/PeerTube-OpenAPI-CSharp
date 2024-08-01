# PeerTubeApiClient.Api.MyHistoryApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1UsersMeHistoryVideosGet**](MyHistoryApi.md#apiv1usersmehistoryvideosget) | **GET** /api/v1/users/me/history/videos | List watched videos history |
| [**ApiV1UsersMeHistoryVideosRemovePost**](MyHistoryApi.md#apiv1usersmehistoryvideosremovepost) | **POST** /api/v1/users/me/history/videos/remove | Clear video history |
| [**ApiV1UsersMeHistoryVideosVideoIdDelete**](MyHistoryApi.md#apiv1usersmehistoryvideosvideoiddelete) | **DELETE** /api/v1/users/me/history/videos/{videoId} | Delete history element |

<a id="apiv1usersmehistoryvideosget"></a>
# **ApiV1UsersMeHistoryVideosGet**
> VideoListResponse ApiV1UsersMeHistoryVideosGet (int? start = null, int? count = null, string? search = null)

List watched videos history

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeHistoryVideosGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MyHistoryApi(config);
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var search = "search_example";  // string? | Plain text search, applied to various parts of the model depending on endpoint (optional) 

            try
            {
                // List watched videos history
                VideoListResponse result = apiInstance.ApiV1UsersMeHistoryVideosGet(start, count, search);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MyHistoryApi.ApiV1UsersMeHistoryVideosGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeHistoryVideosGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List watched videos history
    ApiResponse<VideoListResponse> response = apiInstance.ApiV1UsersMeHistoryVideosGetWithHttpInfo(start, count, search);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MyHistoryApi.ApiV1UsersMeHistoryVideosGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **search** | **string?** | Plain text search, applied to various parts of the model depending on endpoint | [optional]  |

### Return type

[**VideoListResponse**](VideoListResponse.md)

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

<a id="apiv1usersmehistoryvideosremovepost"></a>
# **ApiV1UsersMeHistoryVideosRemovePost**
> void ApiV1UsersMeHistoryVideosRemovePost (DateTime? beforeDate = null)

Clear video history

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeHistoryVideosRemovePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MyHistoryApi(config);
            var beforeDate = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | history before this date will be deleted (optional) 

            try
            {
                // Clear video history
                apiInstance.ApiV1UsersMeHistoryVideosRemovePost(beforeDate);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MyHistoryApi.ApiV1UsersMeHistoryVideosRemovePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeHistoryVideosRemovePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Clear video history
    apiInstance.ApiV1UsersMeHistoryVideosRemovePostWithHttpInfo(beforeDate);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MyHistoryApi.ApiV1UsersMeHistoryVideosRemovePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **beforeDate** | **DateTime?** | history before this date will be deleted | [optional]  |

### Return type

void (empty response body)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1usersmehistoryvideosvideoiddelete"></a>
# **ApiV1UsersMeHistoryVideosVideoIdDelete**
> void ApiV1UsersMeHistoryVideosVideoIdDelete (int videoId)

Delete history element

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeHistoryVideosVideoIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MyHistoryApi(config);
            var videoId = 56;  // int | 

            try
            {
                // Delete history element
                apiInstance.ApiV1UsersMeHistoryVideosVideoIdDelete(videoId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MyHistoryApi.ApiV1UsersMeHistoryVideosVideoIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeHistoryVideosVideoIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete history element
    apiInstance.ApiV1UsersMeHistoryVideosVideoIdDeleteWithHttpInfo(videoId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MyHistoryApi.ApiV1UsersMeHistoryVideosVideoIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **videoId** | **int** |  |  |

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

