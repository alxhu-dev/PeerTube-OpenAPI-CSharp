# PeerTubeApiClient.Api.VideoCaptionsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AddVideoCaption**](VideoCaptionsApi.md#addvideocaption) | **PUT** /api/v1/videos/{id}/captions/{captionLanguage} | Add or replace a video caption |
| [**DelVideoCaption**](VideoCaptionsApi.md#delvideocaption) | **DELETE** /api/v1/videos/{id}/captions/{captionLanguage} | Delete a video caption |
| [**GenerateVideoCaption**](VideoCaptionsApi.md#generatevideocaption) | **POST** /api/v1/videos/{id}/captions/generate | Generate a video caption |
| [**GetVideoCaptions**](VideoCaptionsApi.md#getvideocaptions) | **GET** /api/v1/videos/{id}/captions | List captions of a video |

<a id="addvideocaption"></a>
# **AddVideoCaption**
> void AddVideoCaption (ApiV1VideosOwnershipIdAcceptPostIdParameter id, string captionLanguage, System.IO.Stream? captionfile = null)

Add or replace a video caption

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class AddVideoCaptionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoCaptionsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var captionLanguage = "captionLanguage_example";  // string | The caption language
            var captionfile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? | The file to upload. (optional) 

            try
            {
                // Add or replace a video caption
                apiInstance.AddVideoCaption(id, captionLanguage, captionfile);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoCaptionsApi.AddVideoCaption: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AddVideoCaptionWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Add or replace a video caption
    apiInstance.AddVideoCaptionWithHttpInfo(id, captionLanguage, captionfile);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoCaptionsApi.AddVideoCaptionWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **captionLanguage** | **string** | The caption language |  |
| **captionfile** | **System.IO.Stream?****System.IO.Stream?** | The file to upload. | [optional]  |

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
| **404** | video or language not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="delvideocaption"></a>
# **DelVideoCaption**
> void DelVideoCaption (ApiV1VideosOwnershipIdAcceptPostIdParameter id, string captionLanguage)

Delete a video caption

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class DelVideoCaptionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoCaptionsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var captionLanguage = "captionLanguage_example";  // string | The caption language

            try
            {
                // Delete a video caption
                apiInstance.DelVideoCaption(id, captionLanguage);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoCaptionsApi.DelVideoCaption: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DelVideoCaptionWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a video caption
    apiInstance.DelVideoCaptionWithHttpInfo(id, captionLanguage);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoCaptionsApi.DelVideoCaptionWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **captionLanguage** | **string** | The caption language |  |

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
| **404** | video or language or caption for that language not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="generatevideocaption"></a>
# **GenerateVideoCaption**
> void GenerateVideoCaption (GenerateVideoCaptionRequest? generateVideoCaptionRequest = null)

Generate a video caption

**PeerTube >= 6.2** This feature has to be enabled by the administrator

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GenerateVideoCaptionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoCaptionsApi(config);
            var generateVideoCaptionRequest = new GenerateVideoCaptionRequest?(); // GenerateVideoCaptionRequest? |  (optional) 

            try
            {
                // Generate a video caption
                apiInstance.GenerateVideoCaption(generateVideoCaptionRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoCaptionsApi.GenerateVideoCaption: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GenerateVideoCaptionWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Generate a video caption
    apiInstance.GenerateVideoCaptionWithHttpInfo(generateVideoCaptionRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoCaptionsApi.GenerateVideoCaptionWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **generateVideoCaptionRequest** | [**GenerateVideoCaptionRequest?**](GenerateVideoCaptionRequest?.md) |  | [optional]  |

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

<a id="getvideocaptions"></a>
# **GetVideoCaptions**
> GetVideoCaptions200Response GetVideoCaptions (ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = null)

List captions of a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetVideoCaptionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoCaptionsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var xPeertubeVideoPassword = "xPeertubeVideoPassword_example";  // string? | Required on password protected video (optional) 

            try
            {
                // List captions of a video
                GetVideoCaptions200Response result = apiInstance.GetVideoCaptions(id, xPeertubeVideoPassword);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoCaptionsApi.GetVideoCaptions: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetVideoCaptionsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List captions of a video
    ApiResponse<GetVideoCaptions200Response> response = apiInstance.GetVideoCaptionsWithHttpInfo(id, xPeertubeVideoPassword);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoCaptionsApi.GetVideoCaptionsWithHttpInfo: " + e.Message);
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

[**GetVideoCaptions200Response**](GetVideoCaptions200Response.md)

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

