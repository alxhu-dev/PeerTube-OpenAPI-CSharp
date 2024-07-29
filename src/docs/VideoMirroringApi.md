# PeerTubeApiClient.Api.VideoMirroringApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DelMirroredVideo**](VideoMirroringApi.md#delmirroredvideo) | **DELETE** /api/v1/server/redundancy/videos/{redundancyId} | Delete a mirror done on a video |
| [**GetMirroredVideos**](VideoMirroringApi.md#getmirroredvideos) | **GET** /api/v1/server/redundancy/videos | List videos being mirrored |
| [**PutMirroredVideo**](VideoMirroringApi.md#putmirroredvideo) | **POST** /api/v1/server/redundancy/videos | Mirror a video |

<a id="delmirroredvideo"></a>
# **DelMirroredVideo**
> void DelMirroredVideo (string redundancyId)

Delete a mirror done on a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class DelMirroredVideoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoMirroringApi(config);
            var redundancyId = "redundancyId_example";  // string | id of an existing redundancy on a video

            try
            {
                // Delete a mirror done on a video
                apiInstance.DelMirroredVideo(redundancyId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoMirroringApi.DelMirroredVideo: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DelMirroredVideoWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a mirror done on a video
    apiInstance.DelMirroredVideoWithHttpInfo(redundancyId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoMirroringApi.DelMirroredVideoWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **redundancyId** | **string** | id of an existing redundancy on a video |  |

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
| **404** | video redundancy not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getmirroredvideos"></a>
# **GetMirroredVideos**
> List&lt;VideoRedundancy&gt; GetMirroredVideos (string target, int? start = null, int? count = null, string? sort = null)

List videos being mirrored

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetMirroredVideosExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoMirroringApi(config);
            var target = "my-videos";  // string | direction of the mirror
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = "name";  // string? | Sort abuses by criteria (optional) 

            try
            {
                // List videos being mirrored
                List<VideoRedundancy> result = apiInstance.GetMirroredVideos(target, start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoMirroringApi.GetMirroredVideos: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetMirroredVideosWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List videos being mirrored
    ApiResponse<List<VideoRedundancy>> response = apiInstance.GetMirroredVideosWithHttpInfo(target, start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoMirroringApi.GetMirroredVideosWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **target** | **string** | direction of the mirror |  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort abuses by criteria | [optional]  |

### Return type

[**List&lt;VideoRedundancy&gt;**](VideoRedundancy.md)

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

<a id="putmirroredvideo"></a>
# **PutMirroredVideo**
> void PutMirroredVideo (PutMirroredVideoRequest? putMirroredVideoRequest = null)

Mirror a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class PutMirroredVideoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoMirroringApi(config);
            var putMirroredVideoRequest = new PutMirroredVideoRequest?(); // PutMirroredVideoRequest? |  (optional) 

            try
            {
                // Mirror a video
                apiInstance.PutMirroredVideo(putMirroredVideoRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoMirroringApi.PutMirroredVideo: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PutMirroredVideoWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Mirror a video
    apiInstance.PutMirroredVideoWithHttpInfo(putMirroredVideoRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoMirroringApi.PutMirroredVideoWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **putMirroredVideoRequest** | [**PutMirroredVideoRequest?**](PutMirroredVideoRequest?.md) |  | [optional]  |

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
| **400** | cannot mirror a local video |  -  |
| **404** | video does not exist |  -  |
| **409** | video is already mirrored |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

