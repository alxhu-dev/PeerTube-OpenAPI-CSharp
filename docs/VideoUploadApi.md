# PeerTubeApiClient.Api.VideoUploadApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ImportVideo**](VideoUploadApi.md#importvideo) | **POST** /api/v1/videos/imports | Import a video |
| [**ReplaceVideoSourceResumable**](VideoUploadApi.md#replacevideosourceresumable) | **PUT** /api/v1/videos/{id}/source/replace-resumable | Send chunk for the resumable replacement of a video |
| [**ReplaceVideoSourceResumableCancel**](VideoUploadApi.md#replacevideosourceresumablecancel) | **DELETE** /api/v1/videos/{id}/source/replace-resumable | Cancel the resumable replacement of a video |
| [**ReplaceVideoSourceResumableInit**](VideoUploadApi.md#replacevideosourceresumableinit) | **POST** /api/v1/videos/{id}/source/replace-resumable | Initialize the resumable replacement of a video |
| [**UploadLegacy**](VideoUploadApi.md#uploadlegacy) | **POST** /api/v1/videos/upload | Upload a video |
| [**UploadResumable**](VideoUploadApi.md#uploadresumable) | **PUT** /api/v1/videos/upload-resumable | Send chunk for the resumable upload of a video |
| [**UploadResumableCancel**](VideoUploadApi.md#uploadresumablecancel) | **DELETE** /api/v1/videos/upload-resumable | Cancel the resumable upload of a video, deleting any data uploaded so far |
| [**UploadResumableInit**](VideoUploadApi.md#uploadresumableinit) | **POST** /api/v1/videos/upload-resumable | Initialize the resumable upload of a video |

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

            var apiInstance = new VideoUploadApi(config);
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
                Debug.Print("Exception when calling VideoUploadApi.ImportVideo: " + e.Message);
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
    Debug.Print("Exception when calling VideoUploadApi.ImportVideoWithHttpInfo: " + e.Message);
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

<a id="replacevideosourceresumable"></a>
# **ReplaceVideoSourceResumable**
> void ReplaceVideoSourceResumable (string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = null)

Send chunk for the resumable replacement of a video

**PeerTube >= 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the replacement of a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ReplaceVideoSourceResumableExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoUploadApi(config);
            var uploadId = "uploadId_example";  // string | Created session id to proceed with. If you didn't send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. 
            var contentRange = bytes 0-262143/2469036;  // string | Specifies the bytes in the file that the request is uploading.  For example, a value of `bytes 0-262143/1000000` shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. 
            var contentLength = 262144;  // decimal | Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube's web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. 
            var body = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? |  (optional) 

            try
            {
                // Send chunk for the resumable replacement of a video
                apiInstance.ReplaceVideoSourceResumable(uploadId, contentRange, contentLength, body);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoUploadApi.ReplaceVideoSourceResumable: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ReplaceVideoSourceResumableWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Send chunk for the resumable replacement of a video
    apiInstance.ReplaceVideoSourceResumableWithHttpInfo(uploadId, contentRange, contentLength, body);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoUploadApi.ReplaceVideoSourceResumableWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uploadId** | **string** | Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload.  |  |
| **contentRange** | **string** | Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file.  |  |
| **contentLength** | **decimal** | Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health.  |  |
| **body** | **System.IO.Stream?****System.IO.Stream?** |  | [optional]  |

### Return type

void (empty response body)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: application/octet-stream
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | last chunk received: successful operation |  -  |
| **308** | resume incomplete |  * Range -  <br>  * Content-Length -  <br>  |
| **403** | video didn&#39;t pass file replacement filter |  -  |
| **404** | replace upload not found |  -  |
| **409** | chunk doesn&#39;t match range |  -  |
| **422** | video unreadable |  -  |
| **429** | too many concurrent requests |  -  |
| **503** | upload is already being processed |  * Retry-After -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="replacevideosourceresumablecancel"></a>
# **ReplaceVideoSourceResumableCancel**
> void ReplaceVideoSourceResumableCancel (string uploadId, decimal contentLength)

Cancel the resumable replacement of a video

**PeerTube >= 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the replacement of a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ReplaceVideoSourceResumableCancelExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoUploadApi(config);
            var uploadId = "uploadId_example";  // string | Created session id to proceed with. If you didn't send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. 
            var contentLength = 0;  // decimal | 

            try
            {
                // Cancel the resumable replacement of a video
                apiInstance.ReplaceVideoSourceResumableCancel(uploadId, contentLength);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoUploadApi.ReplaceVideoSourceResumableCancel: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ReplaceVideoSourceResumableCancelWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Cancel the resumable replacement of a video
    apiInstance.ReplaceVideoSourceResumableCancelWithHttpInfo(uploadId, contentLength);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoUploadApi.ReplaceVideoSourceResumableCancelWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uploadId** | **string** | Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload.  |  |
| **contentLength** | **decimal** |  |  |

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
| **204** | source file replacement cancelled |  * Content-Length -  <br>  |
| **404** | source file replacement not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="replacevideosourceresumableinit"></a>
# **ReplaceVideoSourceResumableInit**
> void ReplaceVideoSourceResumableInit (decimal xUploadContentLength, string xUploadContentType, VideoReplaceSourceRequestResumable? videoReplaceSourceRequestResumable = null)

Initialize the resumable replacement of a video

**PeerTube >= 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the replacement of a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ReplaceVideoSourceResumableInitExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoUploadApi(config);
            var xUploadContentLength = 2469036;  // decimal | Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.
            var xUploadContentType = video/mp4;  // string | MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.
            var videoReplaceSourceRequestResumable = new VideoReplaceSourceRequestResumable?(); // VideoReplaceSourceRequestResumable? |  (optional) 

            try
            {
                // Initialize the resumable replacement of a video
                apiInstance.ReplaceVideoSourceResumableInit(xUploadContentLength, xUploadContentType, videoReplaceSourceRequestResumable);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoUploadApi.ReplaceVideoSourceResumableInit: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ReplaceVideoSourceResumableInitWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Initialize the resumable replacement of a video
    apiInstance.ReplaceVideoSourceResumableInitWithHttpInfo(xUploadContentLength, xUploadContentType, videoReplaceSourceRequestResumable);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoUploadApi.ReplaceVideoSourceResumableInitWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xUploadContentLength** | **decimal** | Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading. |  |
| **xUploadContentType** | **string** | MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary. |  |
| **videoReplaceSourceRequestResumable** | [**VideoReplaceSourceRequestResumable?**](VideoReplaceSourceRequestResumable?.md) |  | [optional]  |

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
| **200** | file already exists, send a [&#x60;resume&#x60;](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) request instead |  -  |
| **201** | created |  * Location -  <br>  * Content-Length -  <br>  |
| **413** | Disambiguate via &#x60;code&#x60;: - &#x60;max_file_size_reached&#x60; for the absolute file size limit - &#x60;quota_reached&#x60; for quota limits whether daily or global  |  -  |
| **415** | video type unsupported |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="uploadlegacy"></a>
# **UploadLegacy**
> VideoUploadResponse UploadLegacy (string name, int channelId, System.IO.Stream videofile, VideoPrivacySet? privacy = null, int? category = null, int? licence = null, string? language = null, string? description = null, bool? waitTranscoding = null, bool? generateTranscription = null, string? support = null, bool? nsfw = null, List<string>? tags = null, bool? commentsEnabled = null, VideoCommentsPolicySet? commentsPolicy = null, bool? downloadEnabled = null, DateTime? originallyPublishedAt = null, VideoScheduledUpdate? scheduleUpdate = null, System.IO.Stream? thumbnailfile = null, System.IO.Stream? previewfile = null, List<string>? videoPasswords = null)

Upload a video

Uses a single request to upload a video.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class UploadLegacyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoUploadApi(config);
            var name = "name_example";  // string | Video name
            var channelId = 56;  // int | Channel id that will contain this video
            var videofile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream | Video file
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
                // Upload a video
                VideoUploadResponse result = apiInstance.UploadLegacy(name, channelId, videofile, privacy, category, licence, language, description, waitTranscoding, generateTranscription, support, nsfw, tags, commentsEnabled, commentsPolicy, downloadEnabled, originallyPublishedAt, scheduleUpdate, thumbnailfile, previewfile, videoPasswords);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoUploadApi.UploadLegacy: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UploadLegacyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Upload a video
    ApiResponse<VideoUploadResponse> response = apiInstance.UploadLegacyWithHttpInfo(name, channelId, videofile, privacy, category, licence, language, description, waitTranscoding, generateTranscription, support, nsfw, tags, commentsEnabled, commentsPolicy, downloadEnabled, originallyPublishedAt, scheduleUpdate, thumbnailfile, previewfile, videoPasswords);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoUploadApi.UploadLegacyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string** | Video name |  |
| **channelId** | **int** | Channel id that will contain this video |  |
| **videofile** | **System.IO.Stream****System.IO.Stream** | Video file |  |
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
| **403** | video didn&#39;t pass upload filter |  -  |
| **408** | upload has timed out |  -  |
| **413** | If the response has no body, it means the reverse-proxy didn&#39;t let it through. Otherwise disambiguate via &#x60;code&#x60;: - &#x60;quota_reached&#x60; for quota limits whether daily or global  |  * X-File-Maximum-Size - Maximum file size for the banner <br>  |
| **415** | video type unsupported |  -  |
| **422** | video unreadable |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="uploadresumable"></a>
# **UploadResumable**
> VideoUploadResponse UploadResumable (string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = null)

Send chunk for the resumable upload of a video

Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the upload of a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class UploadResumableExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoUploadApi(config);
            var uploadId = "uploadId_example";  // string | Created session id to proceed with. If you didn't send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. 
            var contentRange = bytes 0-262143/2469036;  // string | Specifies the bytes in the file that the request is uploading.  For example, a value of `bytes 0-262143/1000000` shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. 
            var contentLength = 262144;  // decimal | Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube's web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. 
            var body = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? |  (optional) 

            try
            {
                // Send chunk for the resumable upload of a video
                VideoUploadResponse result = apiInstance.UploadResumable(uploadId, contentRange, contentLength, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoUploadApi.UploadResumable: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UploadResumableWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Send chunk for the resumable upload of a video
    ApiResponse<VideoUploadResponse> response = apiInstance.UploadResumableWithHttpInfo(uploadId, contentRange, contentLength, body);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoUploadApi.UploadResumableWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uploadId** | **string** | Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload.  |  |
| **contentRange** | **string** | Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file.  |  |
| **contentLength** | **decimal** | Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health.  |  |
| **body** | **System.IO.Stream?****System.IO.Stream?** |  | [optional]  |

### Return type

[**VideoUploadResponse**](VideoUploadResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: application/octet-stream
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | last chunk received |  * Content-Length -  <br>  |
| **308** | resume incomplete |  * Range -  <br>  * Content-Length -  <br>  |
| **403** | video didn&#39;t pass upload filter |  -  |
| **404** | upload not found |  -  |
| **409** | chunk doesn&#39;t match range |  -  |
| **422** | video unreadable |  -  |
| **429** | too many concurrent requests |  -  |
| **503** | upload is already being processed |  * Retry-After -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="uploadresumablecancel"></a>
# **UploadResumableCancel**
> void UploadResumableCancel (string uploadId, decimal contentLength)

Cancel the resumable upload of a video, deleting any data uploaded so far

Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the upload of a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class UploadResumableCancelExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoUploadApi(config);
            var uploadId = "uploadId_example";  // string | Created session id to proceed with. If you didn't send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. 
            var contentLength = 0;  // decimal | 

            try
            {
                // Cancel the resumable upload of a video, deleting any data uploaded so far
                apiInstance.UploadResumableCancel(uploadId, contentLength);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoUploadApi.UploadResumableCancel: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UploadResumableCancelWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Cancel the resumable upload of a video, deleting any data uploaded so far
    apiInstance.UploadResumableCancelWithHttpInfo(uploadId, contentLength);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoUploadApi.UploadResumableCancelWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uploadId** | **string** | Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload.  |  |
| **contentLength** | **decimal** |  |  |

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
| **204** | upload cancelled |  * Content-Length -  <br>  |
| **404** | upload not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="uploadresumableinit"></a>
# **UploadResumableInit**
> void UploadResumableInit (decimal xUploadContentLength, string xUploadContentType, VideoUploadRequestResumable? videoUploadRequestResumable = null)

Initialize the resumable upload of a video

Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the upload of a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class UploadResumableInitExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoUploadApi(config);
            var xUploadContentLength = 2469036;  // decimal | Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.
            var xUploadContentType = video/mp4;  // string | MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.
            var videoUploadRequestResumable = new VideoUploadRequestResumable?(); // VideoUploadRequestResumable? |  (optional) 

            try
            {
                // Initialize the resumable upload of a video
                apiInstance.UploadResumableInit(xUploadContentLength, xUploadContentType, videoUploadRequestResumable);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoUploadApi.UploadResumableInit: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UploadResumableInitWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Initialize the resumable upload of a video
    apiInstance.UploadResumableInitWithHttpInfo(xUploadContentLength, xUploadContentType, videoUploadRequestResumable);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoUploadApi.UploadResumableInitWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xUploadContentLength** | **decimal** | Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading. |  |
| **xUploadContentType** | **string** | MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary. |  |
| **videoUploadRequestResumable** | [**VideoUploadRequestResumable?**](VideoUploadRequestResumable?.md) |  | [optional]  |

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
| **200** | file already exists, send a [&#x60;resume&#x60;](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) request instead |  -  |
| **201** | created |  * Location -  <br>  * Content-Length -  <br>  |
| **413** | Disambiguate via &#x60;code&#x60;: - &#x60;max_file_size_reached&#x60; for the absolute file size limit - &#x60;quota_reached&#x60; for quota limits whether daily or global  |  -  |
| **415** | video type unsupported |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

