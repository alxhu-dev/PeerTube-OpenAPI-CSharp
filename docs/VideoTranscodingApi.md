# PeerTubeApiClient.Api.VideoTranscodingApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1VideosIdStudioEditPost**](VideoTranscodingApi.md#apiv1videosidstudioeditpost) | **POST** /api/v1/videos/{id}/studio/edit | Create a studio task |
| [**CreateVideoTranscoding**](VideoTranscodingApi.md#createvideotranscoding) | **POST** /api/v1/videos/{id}/transcoding | Create a transcoding job |

<a id="apiv1videosidstudioeditpost"></a>
# **ApiV1VideosIdStudioEditPost**
> void ApiV1VideosIdStudioEditPost (ApiV1VideosOwnershipIdAcceptPostIdParameter id)

Create a studio task

Create a task to edit a video  (cut, add intro/outro etc)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdStudioEditPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoTranscodingApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid

            try
            {
                // Create a studio task
                apiInstance.ApiV1VideosIdStudioEditPost(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoTranscodingApi.ApiV1VideosIdStudioEditPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdStudioEditPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a studio task
    apiInstance.ApiV1VideosIdStudioEditPostWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoTranscodingApi.ApiV1VideosIdStudioEditPostWithHttpInfo: " + e.Message);
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

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | successful operation |  -  |
| **400** | incorrect parameters |  -  |
| **404** | video not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="createvideotranscoding"></a>
# **CreateVideoTranscoding**
> void CreateVideoTranscoding (ApiV1VideosOwnershipIdAcceptPostIdParameter id, CreateVideoTranscodingRequest? createVideoTranscodingRequest = null)

Create a transcoding job

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class CreateVideoTranscodingExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoTranscodingApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var createVideoTranscodingRequest = new CreateVideoTranscodingRequest?(); // CreateVideoTranscodingRequest? |  (optional) 

            try
            {
                // Create a transcoding job
                apiInstance.CreateVideoTranscoding(id, createVideoTranscodingRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoTranscodingApi.CreateVideoTranscoding: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateVideoTranscodingWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a transcoding job
    apiInstance.CreateVideoTranscodingWithHttpInfo(id, createVideoTranscodingRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoTranscodingApi.CreateVideoTranscodingWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **createVideoTranscodingRequest** | [**CreateVideoTranscodingRequest?**](CreateVideoTranscodingRequest?.md) |  | [optional]  |

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
| **404** | video does not exist |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

