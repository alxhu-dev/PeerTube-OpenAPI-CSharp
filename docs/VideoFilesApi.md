# PeerTubeApiClient.Api.VideoFilesApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DelVideoHLS**](VideoFilesApi.md#delvideohls) | **DELETE** /api/v1/videos/{id}/hls | Delete video HLS files |
| [**DelVideoWebVideos**](VideoFilesApi.md#delvideowebvideos) | **DELETE** /api/v1/videos/{id}/web-videos | Delete video Web Video files |

<a id="delvideohls"></a>
# **DelVideoHLS**
> void DelVideoHLS (ApiV1VideosOwnershipIdAcceptPostIdParameter id)

Delete video HLS files

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class DelVideoHLSExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoFilesApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid

            try
            {
                // Delete video HLS files
                apiInstance.DelVideoHLS(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoFilesApi.DelVideoHLS: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DelVideoHLSWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete video HLS files
    apiInstance.DelVideoHLSWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoFilesApi.DelVideoHLSWithHttpInfo: " + e.Message);
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
| **404** | video does not exist |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="delvideowebvideos"></a>
# **DelVideoWebVideos**
> void DelVideoWebVideos (ApiV1VideosOwnershipIdAcceptPostIdParameter id)

Delete video Web Video files

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
    public class DelVideoWebVideosExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoFilesApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid

            try
            {
                // Delete video Web Video files
                apiInstance.DelVideoWebVideos(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoFilesApi.DelVideoWebVideos: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DelVideoWebVideosWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete video Web Video files
    apiInstance.DelVideoWebVideosWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoFilesApi.DelVideoWebVideosWithHttpInfo: " + e.Message);
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
| **404** | video does not exist |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

