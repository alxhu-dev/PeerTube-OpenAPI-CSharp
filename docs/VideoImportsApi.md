# PeerTubeApiClient.Api.VideoImportsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1VideosImportsIdCancelPost**](VideoImportsApi.md#apiv1videosimportsidcancelpost) | **POST** /api/v1/videos/imports/{id}/cancel | Cancel video import |
| [**ApiV1VideosImportsIdDelete**](VideoImportsApi.md#apiv1videosimportsiddelete) | **DELETE** /api/v1/videos/imports/{id} | Delete video import |
| [**ImportVideo**](VideoImportsApi.md#importvideo) | **POST** /api/v1/videos/imports | Import a video |

<a id="apiv1videosimportsidcancelpost"></a>
# **ApiV1VideosImportsIdCancelPost**
> void ApiV1VideosImportsIdCancelPost (int id)

Cancel video import

Cancel a pending video import

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosImportsIdCancelPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoImportsApi(config);
            var id = 56;  // int | Entity id

            try
            {
                // Cancel video import
                apiInstance.ApiV1VideosImportsIdCancelPost(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoImportsApi.ApiV1VideosImportsIdCancelPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosImportsIdCancelPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Cancel video import
    apiInstance.ApiV1VideosImportsIdCancelPostWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoImportsApi.ApiV1VideosImportsIdCancelPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | Entity id |  |

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

<a id="apiv1videosimportsiddelete"></a>
# **ApiV1VideosImportsIdDelete**
> void ApiV1VideosImportsIdDelete (int id)

Delete video import

Delete ended video import

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosImportsIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoImportsApi(config);
            var id = 56;  // int | Entity id

            try
            {
                // Delete video import
                apiInstance.ApiV1VideosImportsIdDelete(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoImportsApi.ApiV1VideosImportsIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosImportsIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete video import
    apiInstance.ApiV1VideosImportsIdDeleteWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoImportsApi.ApiV1VideosImportsIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | Entity id |  |

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

<a id="importvideo"></a>
# **ImportVideo**
> VideoUploadResponse ImportVideo (string name, int channelId, VideoPrivacySet? privacy = null, int? category = null, int? licence = null, string? language = null, string? description = null, bool? waitTranscoding = null, bool? generateTranscription = null, string? support = null, bool? nsfw = null, List<string>? tags = null, bool? commentsEnabled = null, VideoCommentsPolicySet? commentsPolicy = null, bool? downloadEnabled = null, DateTime? originallyPublishedAt = null, VideoScheduledUpdate? scheduleUpdate = null, System.IO.Stream? thumbnailfile = null, System.IO.Stream? previewfile = null, List<string>? videoPasswords = null)

Import a video

Import a torrent or magnetURI or HTTP resource (if enabled by the instance administrator)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ImportVideoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoImportsApi(config);
            var name = "name_example";  // string | Video name
            var channelId = 56;  // int | Channel id that will contain this video
            var privacy = new VideoPrivacySet?(); // VideoPrivacySet? |  (optional) 
            var category = 56;  // int? | category id of the video (see [/videos/categories](#operation/getCategories)) (optional) 
            var licence = 56;  // int? | licence id of the video (see [/videos/licences](#operation/getLicences)) (optional) 
            var language = "language_example";  // string? | language id of the video (see [/videos/languages](#operation/getLanguages)) (optional) 
            var description = "description_example";  // string? | Video description (optional) 
            var waitTranscoding = true;  // bool? | Whether or not we wait transcoding before publish the video (optional) 
            var generateTranscription = true;  // bool? | **PeerTube >= 6.2** If enabled by the admin, automatically generate a subtitle of the video (optional) 
            var support = "support_example";  // string? | A text tell the audience how to support the video creator (optional) 
            var nsfw = true;  // bool? | Whether or not this video contains sensitive content (optional) 
            var tags = new List<string>?(); // List<string>? | Video tags (maximum 5 tags each between 2 and 30 characters) (optional) 
            var commentsEnabled = true;  // bool? | Deprecated in 6.2, use commentsPolicy instead (optional) 
            var commentsPolicy = new VideoCommentsPolicySet?(); // VideoCommentsPolicySet? |  (optional) 
            var downloadEnabled = true;  // bool? | Enable or disable downloading for this video (optional) 
            var originallyPublishedAt = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Date when the content was originally published (optional) 
            var scheduleUpdate = new VideoScheduledUpdate?(); // VideoScheduledUpdate? |  (optional) 
            var thumbnailfile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? | Video thumbnail file (optional) 
            var previewfile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? | Video preview file (optional) 
            var videoPasswords = new List<string>?(); // List<string>? |  (optional) 

            try
            {
                // Import a video
                VideoUploadResponse result = apiInstance.ImportVideo(name, channelId, privacy, category, licence, language, description, waitTranscoding, generateTranscription, support, nsfw, tags, commentsEnabled, commentsPolicy, downloadEnabled, originallyPublishedAt, scheduleUpdate, thumbnailfile, previewfile, videoPasswords);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoImportsApi.ImportVideo: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ImportVideoWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Import a video
    ApiResponse<VideoUploadResponse> response = apiInstance.ImportVideoWithHttpInfo(name, channelId, privacy, category, licence, language, description, waitTranscoding, generateTranscription, support, nsfw, tags, commentsEnabled, commentsPolicy, downloadEnabled, originallyPublishedAt, scheduleUpdate, thumbnailfile, previewfile, videoPasswords);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoImportsApi.ImportVideoWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string** | Video name |  |
| **channelId** | **int** | Channel id that will contain this video |  |
| **privacy** | [**VideoPrivacySet?**](VideoPrivacySet?.md) |  | [optional]  |
| **category** | **int?** | category id of the video (see [/videos/categories](#operation/getCategories)) | [optional]  |
| **licence** | **int?** | licence id of the video (see [/videos/licences](#operation/getLicences)) | [optional]  |
| **language** | **string?** | language id of the video (see [/videos/languages](#operation/getLanguages)) | [optional]  |
| **description** | **string?** | Video description | [optional]  |
| **waitTranscoding** | **bool?** | Whether or not we wait transcoding before publish the video | [optional]  |
| **generateTranscription** | **bool?** | **PeerTube &gt;&#x3D; 6.2** If enabled by the admin, automatically generate a subtitle of the video | [optional]  |
| **support** | **string?** | A text tell the audience how to support the video creator | [optional]  |
| **nsfw** | **bool?** | Whether or not this video contains sensitive content | [optional]  |
| **tags** | [**List&lt;string&gt;?**](string.md) | Video tags (maximum 5 tags each between 2 and 30 characters) | [optional]  |
| **commentsEnabled** | **bool?** | Deprecated in 6.2, use commentsPolicy instead | [optional]  |
| **commentsPolicy** | [**VideoCommentsPolicySet?**](VideoCommentsPolicySet?.md) |  | [optional]  |
| **downloadEnabled** | **bool?** | Enable or disable downloading for this video | [optional]  |
| **originallyPublishedAt** | **DateTime?** | Date when the content was originally published | [optional]  |
| **scheduleUpdate** | [**VideoScheduledUpdate?**](VideoScheduledUpdate?.md) |  | [optional]  |
| **thumbnailfile** | **System.IO.Stream?****System.IO.Stream?** | Video thumbnail file | [optional]  |
| **previewfile** | **System.IO.Stream?****System.IO.Stream?** | Video preview file | [optional]  |
| **videoPasswords** | [**List&lt;string&gt;?**](string.md) |  | [optional]  |

### Return type

[**VideoUploadResponse**](VideoUploadResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | &#x60;magnetUri&#x60; or &#x60;targetUrl&#x60; or a torrent file missing |  -  |
| **403** | video didn&#39;t pass pre-import filter |  -  |
| **409** | HTTP or Torrent/magnetURI import not enabled |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

