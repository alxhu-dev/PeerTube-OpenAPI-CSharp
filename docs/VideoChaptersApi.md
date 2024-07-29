# PeerTubeApiClient.Api.VideoChaptersApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetVideoChapters**](VideoChaptersApi.md#getvideochapters) | **GET** /api/v1/videos/{id}/chapters | Get chapters of a video |
| [**ReplaceVideoChapters**](VideoChaptersApi.md#replacevideochapters) | **PUT** /api/v1/videos/{id}/chapters | Replace video chapters |

<a id="getvideochapters"></a>
# **GetVideoChapters**
> VideoChapters GetVideoChapters (ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = null)

Get chapters of a video

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
    public class GetVideoChaptersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoChaptersApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var xPeertubeVideoPassword = "xPeertubeVideoPassword_example";  // string? | Required on password protected video (optional) 

            try
            {
                // Get chapters of a video
                VideoChapters result = apiInstance.GetVideoChapters(id, xPeertubeVideoPassword);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChaptersApi.GetVideoChapters: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetVideoChaptersWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get chapters of a video
    ApiResponse<VideoChapters> response = apiInstance.GetVideoChaptersWithHttpInfo(id, xPeertubeVideoPassword);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChaptersApi.GetVideoChaptersWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **xPeertubeVideoPassword** | **string?** | Required on password protected video | [optional]  |

### Return type

[**VideoChapters**](VideoChapters.md)

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

<a id="replacevideochapters"></a>
# **ReplaceVideoChapters**
> void ReplaceVideoChapters (ApiV1VideosOwnershipIdAcceptPostIdParameter id, ReplaceVideoChaptersRequest? replaceVideoChaptersRequest = null)

Replace video chapters

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
    public class ReplaceVideoChaptersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoChaptersApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var replaceVideoChaptersRequest = new ReplaceVideoChaptersRequest?(); // ReplaceVideoChaptersRequest? |  (optional) 

            try
            {
                // Replace video chapters
                apiInstance.ReplaceVideoChapters(id, replaceVideoChaptersRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChaptersApi.ReplaceVideoChapters: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ReplaceVideoChaptersWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Replace video chapters
    apiInstance.ReplaceVideoChaptersWithHttpInfo(id, replaceVideoChaptersRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChaptersApi.ReplaceVideoChaptersWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **replaceVideoChaptersRequest** | [**ReplaceVideoChaptersRequest?**](ReplaceVideoChaptersRequest?.md) |  | [optional]  |

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
| **404** | video not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

