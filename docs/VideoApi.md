# PeerTubeApiClient.Api.VideoApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AddLive**](VideoApi.md#addlive) | **POST** /api/v1/videos/live | Create a live |
| [**AddView**](VideoApi.md#addview) | **POST** /api/v1/videos/{id}/views | Notify user is watching a video |
| [**ApiV1VideosIdStudioEditPost**](VideoApi.md#apiv1videosidstudioeditpost) | **POST** /api/v1/videos/{id}/studio/edit | Create a studio task |
| [**ApiV1VideosIdWatchingPut**](VideoApi.md#apiv1videosidwatchingput) | **PUT** /api/v1/videos/{id}/watching | Set watching progress of a video |
| [**DelVideo**](VideoApi.md#delvideo) | **DELETE** /api/v1/videos/{id} | Delete a video |
| [**DeleteVideoSourceFile**](VideoApi.md#deletevideosourcefile) | **DELETE** /api/v1/videos/{id}/source/file | Delete video source file |
| [**GetAccountVideos**](VideoApi.md#getaccountvideos) | **GET** /api/v1/accounts/{name}/videos | List videos of an account |
| [**GetCategories**](VideoApi.md#getcategories) | **GET** /api/v1/videos/categories | List available video categories |
| [**GetLanguages**](VideoApi.md#getlanguages) | **GET** /api/v1/videos/languages | List available video languages |
| [**GetLicences**](VideoApi.md#getlicences) | **GET** /api/v1/videos/licences | List available video licences |
| [**GetLiveId**](VideoApi.md#getliveid) | **GET** /api/v1/videos/live/{id} | Get information about a live |
| [**GetVideo**](VideoApi.md#getvideo) | **GET** /api/v1/videos/{id} | Get a video |
| [**GetVideoChannelVideos**](VideoApi.md#getvideochannelvideos) | **GET** /api/v1/video-channels/{channelHandle}/videos | List videos of a video channel |
| [**GetVideoDesc**](VideoApi.md#getvideodesc) | **GET** /api/v1/videos/{id}/description | Get complete video description |
| [**GetVideoPrivacyPolicies**](VideoApi.md#getvideoprivacypolicies) | **GET** /api/v1/videos/privacies | List available video privacy policies |
| [**GetVideoSource**](VideoApi.md#getvideosource) | **GET** /api/v1/videos/{id}/source | Get video source file metadata |
| [**GetVideos**](VideoApi.md#getvideos) | **GET** /api/v1/videos | List videos |
| [**ListVideoStoryboards**](VideoApi.md#listvideostoryboards) | **GET** /api/v1/videos/{id}/storyboards | List storyboards of a video |
| [**PutVideo**](VideoApi.md#putvideo) | **PUT** /api/v1/videos/{id} | Update a video |
| [**ReplaceVideoSourceResumable**](VideoApi.md#replacevideosourceresumable) | **PUT** /api/v1/videos/{id}/source/replace-resumable | Send chunk for the resumable replacement of a video |
| [**ReplaceVideoSourceResumableCancel**](VideoApi.md#replacevideosourceresumablecancel) | **DELETE** /api/v1/videos/{id}/source/replace-resumable | Cancel the resumable replacement of a video |
| [**ReplaceVideoSourceResumableInit**](VideoApi.md#replacevideosourceresumableinit) | **POST** /api/v1/videos/{id}/source/replace-resumable | Initialize the resumable replacement of a video |
| [**RequestVideoToken**](VideoApi.md#requestvideotoken) | **POST** /api/v1/videos/{id}/token | Request video token |
| [**SearchVideos**](VideoApi.md#searchvideos) | **GET** /api/v1/search/videos | Search videos |
| [**UpdateLiveId**](VideoApi.md#updateliveid) | **PUT** /api/v1/videos/live/{id} | Update information about a live |
| [**UploadLegacy**](VideoApi.md#uploadlegacy) | **POST** /api/v1/videos/upload | Upload a video |
| [**UploadResumable**](VideoApi.md#uploadresumable) | **PUT** /api/v1/videos/upload-resumable | Send chunk for the resumable upload of a video |
| [**UploadResumableCancel**](VideoApi.md#uploadresumablecancel) | **DELETE** /api/v1/videos/upload-resumable | Cancel the resumable upload of a video, deleting any data uploaded so far |
| [**UploadResumableInit**](VideoApi.md#uploadresumableinit) | **POST** /api/v1/videos/upload-resumable | Initialize the resumable upload of a video |

<a id="addlive"></a>
# **AddLive**
> VideoUploadResponse AddLive (int channelId, string name, bool? saveReplay = null, LiveVideoReplaySettings? replaySettings = null, bool? permanentLive = null, LiveVideoLatencyMode? latencyMode = null, System.IO.Stream? thumbnailfile = null, System.IO.Stream? previewfile = null, VideoPrivacySet? privacy = null, int? category = null, int? licence = null, string? language = null, string? description = null, string? support = null, bool? nsfw = null, List<string>? tags = null, bool? commentsEnabled = null, VideoCommentsPolicySet? commentsPolicy = null, bool? downloadEnabled = null)

Create a live

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class AddLiveExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoApi(config);
            var channelId = 56;  // int | Channel id that will contain this live video
            var name = "name_example";  // string | Live video/replay name
            var saveReplay = true;  // bool? |  (optional) 
            var replaySettings = new LiveVideoReplaySettings?(); // LiveVideoReplaySettings? |  (optional) 
            var permanentLive = true;  // bool? | User can stream multiple times in a permanent live (optional) 
            var latencyMode = new LiveVideoLatencyMode?(); // LiveVideoLatencyMode? |  (optional) 
            var thumbnailfile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? | Live video/replay thumbnail file (optional) 
            var previewfile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? | Live video/replay preview file (optional) 
            var privacy = new VideoPrivacySet?(); // VideoPrivacySet? |  (optional) 
            var category = 56;  // int? | category id of the video (see [/videos/categories](#operation/getCategories)) (optional) 
            var licence = 56;  // int? | licence id of the video (see [/videos/licences](#operation/getLicences)) (optional) 
            var language = "language_example";  // string? | language id of the video (see [/videos/languages](#operation/getLanguages)) (optional) 
            var description = "description_example";  // string? | Live video/replay description (optional) 
            var support = "support_example";  // string? | A text tell the audience how to support the creator (optional) 
            var nsfw = true;  // bool? | Whether or not this live video/replay contains sensitive content (optional) 
            var tags = new List<string>?(); // List<string>? | Live video/replay tags (maximum 5 tags each between 2 and 30 characters) (optional) 
            var commentsEnabled = true;  // bool? | Deprecated in 6.2, use commentsPolicy instead (optional) 
            var commentsPolicy = new VideoCommentsPolicySet?(); // VideoCommentsPolicySet? |  (optional) 
            var downloadEnabled = true;  // bool? | Enable or disable downloading for the replay of this live video (optional) 

            try
            {
                // Create a live
                VideoUploadResponse result = apiInstance.AddLive(channelId, name, saveReplay, replaySettings, permanentLive, latencyMode, thumbnailfile, previewfile, privacy, category, licence, language, description, support, nsfw, tags, commentsEnabled, commentsPolicy, downloadEnabled);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.AddLive: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AddLiveWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a live
    ApiResponse<VideoUploadResponse> response = apiInstance.AddLiveWithHttpInfo(channelId, name, saveReplay, replaySettings, permanentLive, latencyMode, thumbnailfile, previewfile, privacy, category, licence, language, description, support, nsfw, tags, commentsEnabled, commentsPolicy, downloadEnabled);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.AddLiveWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channelId** | **int** | Channel id that will contain this live video |  |
| **name** | **string** | Live video/replay name |  |
| **saveReplay** | **bool?** |  | [optional]  |
| **replaySettings** | [**LiveVideoReplaySettings?**](LiveVideoReplaySettings?.md) |  | [optional]  |
| **permanentLive** | **bool?** | User can stream multiple times in a permanent live | [optional]  |
| **latencyMode** | [**LiveVideoLatencyMode?**](LiveVideoLatencyMode?.md) |  | [optional]  |
| **thumbnailfile** | **System.IO.Stream?****System.IO.Stream?** | Live video/replay thumbnail file | [optional]  |
| **previewfile** | **System.IO.Stream?****System.IO.Stream?** | Live video/replay preview file | [optional]  |
| **privacy** | [**VideoPrivacySet?**](VideoPrivacySet?.md) |  | [optional]  |
| **category** | **int?** | category id of the video (see [/videos/categories](#operation/getCategories)) | [optional]  |
| **licence** | **int?** | licence id of the video (see [/videos/licences](#operation/getLicences)) | [optional]  |
| **language** | **string?** | language id of the video (see [/videos/languages](#operation/getLanguages)) | [optional]  |
| **description** | **string?** | Live video/replay description | [optional]  |
| **support** | **string?** | A text tell the audience how to support the creator | [optional]  |
| **nsfw** | **bool?** | Whether or not this live video/replay contains sensitive content | [optional]  |
| **tags** | [**List&lt;string&gt;?**](string.md) | Live video/replay tags (maximum 5 tags each between 2 and 30 characters) | [optional]  |
| **commentsEnabled** | **bool?** | Deprecated in 6.2, use commentsPolicy instead | [optional]  |
| **commentsPolicy** | [**VideoCommentsPolicySet?**](VideoCommentsPolicySet?.md) |  | [optional]  |
| **downloadEnabled** | **bool?** | Enable or disable downloading for the replay of this live video | [optional]  |

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
| **400** | Disambiguate via &#x60;code&#x60;: - default type for a validation error - &#x60;live_conflicting_permanent_and_save_replay&#x60; for conflicting parameters set  |  -  |
| **403** | Disambiguate via &#x60;code&#x60;: - &#x60;live_not_enabled&#x60; for a disabled live feature - &#x60;live_not_allowing_replay&#x60; for a disabled replay feature - &#x60;max_instance_lives_limit_reached&#x60; for the absolute concurrent live limit - &#x60;max_user_lives_limit_reached&#x60; for the user concurrent live limit  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="addview"></a>
# **AddView**
> void AddView (ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo)

Notify user is watching a video

Call this endpoint regularly (every 5-10 seconds for example) to notify the server the user is watching the video. After a while, PeerTube will increase video's viewers counter. If the user is authenticated, PeerTube will also store the current player time.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class AddViewExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var userViewingVideo = new UserViewingVideo(); // UserViewingVideo | 

            try
            {
                // Notify user is watching a video
                apiInstance.AddView(id, userViewingVideo);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.AddView: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AddViewWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Notify user is watching a video
    apiInstance.AddViewWithHttpInfo(id, userViewingVideo);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.AddViewWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **userViewingVideo** | [**UserViewingVideo**](UserViewingVideo.md) |  |  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

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

            var apiInstance = new VideoApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid

            try
            {
                // Create a studio task
                apiInstance.ApiV1VideosIdStudioEditPost(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.ApiV1VideosIdStudioEditPost: " + e.Message);
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
    Debug.Print("Exception when calling VideoApi.ApiV1VideosIdStudioEditPostWithHttpInfo: " + e.Message);
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

<a id="apiv1videosidwatchingput"></a>
# **ApiV1VideosIdWatchingPut**
> void ApiV1VideosIdWatchingPut (ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo)

Set watching progress of a video

This endpoint has been deprecated. Use `/videos/{id}/views` instead

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdWatchingPutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var userViewingVideo = new UserViewingVideo(); // UserViewingVideo | 

            try
            {
                // Set watching progress of a video
                apiInstance.ApiV1VideosIdWatchingPut(id, userViewingVideo);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.ApiV1VideosIdWatchingPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdWatchingPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Set watching progress of a video
    apiInstance.ApiV1VideosIdWatchingPutWithHttpInfo(id, userViewingVideo);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.ApiV1VideosIdWatchingPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **userViewingVideo** | [**UserViewingVideo**](UserViewingVideo.md) |  |  |

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="delvideo"></a>
# **DelVideo**
> void DelVideo (ApiV1VideosOwnershipIdAcceptPostIdParameter id)

Delete a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class DelVideoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid

            try
            {
                // Delete a video
                apiInstance.DelVideo(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.DelVideo: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DelVideoWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a video
    apiInstance.DelVideoWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.DelVideoWithHttpInfo: " + e.Message);
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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletevideosourcefile"></a>
# **DeleteVideoSourceFile**
> void DeleteVideoSourceFile (ApiV1VideosOwnershipIdAcceptPostIdParameter id)

Delete video source file

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class DeleteVideoSourceFileExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid

            try
            {
                // Delete video source file
                apiInstance.DeleteVideoSourceFile(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.DeleteVideoSourceFile: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteVideoSourceFileWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete video source file
    apiInstance.DeleteVideoSourceFileWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.DeleteVideoSourceFileWithHttpInfo: " + e.Message);
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
| **404** | video source not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getaccountvideos"></a>
# **GetAccountVideos**
> VideoListResponse GetAccountVideos (string name, GetAccountVideosCategoryOneOfParameter? categoryOneOf = null, bool? isLive = null, GetAccountVideosTagsOneOfParameter? tagsOneOf = null, GetAccountVideosTagsAllOfParameter? tagsAllOf = null, GetAccountVideosLicenceOneOfParameter? licenceOneOf = null, GetAccountVideosLanguageOneOfParameter? languageOneOf = null, GetAccountVideosTagsAllOfParameter? autoTagOneOf = null, string? nsfw = null, bool? isLocal = null, int? include = null, VideoPrivacySet? privacyOneOf = null, bool? hasHLSFiles = null, bool? hasWebVideoFiles = null, string? skipCount = null, int? start = null, int? count = null, string? sort = null, bool? excludeAlreadyWatched = null)

List videos of an account

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetAccountVideosExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoApi(config);
            var name = chocobozzz | chocobozzz@example.org;  // string | The username or handle of the account
            var categoryOneOf = new GetAccountVideosCategoryOneOfParameter?(); // GetAccountVideosCategoryOneOfParameter? | category id of the video (see [/videos/categories](#operation/getCategories)) (optional) 
            var isLive = true;  // bool? | whether or not the video is a live (optional) 
            var tagsOneOf = new GetAccountVideosTagsOneOfParameter?(); // GetAccountVideosTagsOneOfParameter? | tag(s) of the video (optional) 
            var tagsAllOf = new GetAccountVideosTagsAllOfParameter?(); // GetAccountVideosTagsAllOfParameter? | tag(s) of the video, where all should be present in the video (optional) 
            var licenceOneOf = new GetAccountVideosLicenceOneOfParameter?(); // GetAccountVideosLicenceOneOfParameter? | licence id of the video (see [/videos/licences](#operation/getLicences)) (optional) 
            var languageOneOf = new GetAccountVideosLanguageOneOfParameter?(); // GetAccountVideosLanguageOneOfParameter? | language id of the video (see [/videos/languages](#operation/getLanguages)). Use `_unknown` to filter on videos that don't have a video language (optional) 
            var autoTagOneOf = new GetAccountVideosTagsAllOfParameter?(); // GetAccountVideosTagsAllOfParameter? | **PeerTube >= 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional) 
            var nsfw = "true";  // string? | whether to include nsfw videos, if any (optional) 
            var isLocal = true;  // bool? | **PeerTube >= 4.0** Display only local or remote objects (optional) 
            var include = 0;  // int? | **PeerTube >= 4.0** Include additional videos in results (can be combined using bitwise or operator) - `0` NONE - `1` NOT_PUBLISHED_STATE - `2` BLACKLISTED - `4` BLOCKED_OWNER - `8` FILES - `16` CAPTIONS - `32` VIDEO SOURCE  (optional) 
            var privacyOneOf = new VideoPrivacySet?(); // VideoPrivacySet? | **PeerTube >= 4.0** Display only videos in this specific privacy/privacies (optional) 
            var hasHLSFiles = true;  // bool? | **PeerTube >= 4.0** Display only videos that have HLS files (optional) 
            var hasWebVideoFiles = true;  // bool? | **PeerTube >= 6.0** Display only videos that have Web Video files (optional) 
            var skipCount = "true";  // string? | if you don't need the `total` in the response (optional)  (default to false)
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = "name";  // string? |  (optional) 
            var excludeAlreadyWatched = true;  // bool? | Whether or not to exclude videos that are in the user's video history (optional) 

            try
            {
                // List videos of an account
                VideoListResponse result = apiInstance.GetAccountVideos(name, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.GetAccountVideos: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAccountVideosWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List videos of an account
    ApiResponse<VideoListResponse> response = apiInstance.GetAccountVideosWithHttpInfo(name, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.GetAccountVideosWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string** | The username or handle of the account |  |
| **categoryOneOf** | [**GetAccountVideosCategoryOneOfParameter?**](GetAccountVideosCategoryOneOfParameter?.md) | category id of the video (see [/videos/categories](#operation/getCategories)) | [optional]  |
| **isLive** | **bool?** | whether or not the video is a live | [optional]  |
| **tagsOneOf** | [**GetAccountVideosTagsOneOfParameter?**](GetAccountVideosTagsOneOfParameter?.md) | tag(s) of the video | [optional]  |
| **tagsAllOf** | [**GetAccountVideosTagsAllOfParameter?**](GetAccountVideosTagsAllOfParameter?.md) | tag(s) of the video, where all should be present in the video | [optional]  |
| **licenceOneOf** | [**GetAccountVideosLicenceOneOfParameter?**](GetAccountVideosLicenceOneOfParameter?.md) | licence id of the video (see [/videos/licences](#operation/getLicences)) | [optional]  |
| **languageOneOf** | [**GetAccountVideosLanguageOneOfParameter?**](GetAccountVideosLanguageOneOfParameter?.md) | language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language | [optional]  |
| **autoTagOneOf** | [**GetAccountVideosTagsAllOfParameter?**](GetAccountVideosTagsAllOfParameter?.md) | **PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags | [optional]  |
| **nsfw** | **string?** | whether to include nsfw videos, if any | [optional]  |
| **isLocal** | **bool?** | **PeerTube &gt;&#x3D; 4.0** Display only local or remote objects | [optional]  |
| **include** | **int?** | **PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  | [optional]  |
| **privacyOneOf** | [**VideoPrivacySet?**](VideoPrivacySet?.md) | **PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies | [optional]  |
| **hasHLSFiles** | **bool?** | **PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files | [optional]  |
| **hasWebVideoFiles** | **bool?** | **PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files | [optional]  |
| **skipCount** | **string?** | if you don&#39;t need the &#x60;total&#x60; in the response | [optional] [default to false] |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** |  | [optional]  |
| **excludeAlreadyWatched** | **bool?** | Whether or not to exclude videos that are in the user&#39;s video history | [optional]  |

### Return type

[**VideoListResponse**](VideoListResponse.md)

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

<a id="getcategories"></a>
# **GetCategories**
> List&lt;string&gt; GetCategories ()

List available video categories

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetCategoriesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoApi(config);

            try
            {
                // List available video categories
                List<string> result = apiInstance.GetCategories();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.GetCategories: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetCategoriesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List available video categories
    ApiResponse<List<string>> response = apiInstance.GetCategoriesWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.GetCategoriesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

**List<string>**

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

<a id="getlanguages"></a>
# **GetLanguages**
> List&lt;string&gt; GetLanguages ()

List available video languages

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetLanguagesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoApi(config);

            try
            {
                // List available video languages
                List<string> result = apiInstance.GetLanguages();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.GetLanguages: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetLanguagesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List available video languages
    ApiResponse<List<string>> response = apiInstance.GetLanguagesWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.GetLanguagesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

**List<string>**

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

<a id="getlicences"></a>
# **GetLicences**
> List&lt;string&gt; GetLicences ()

List available video licences

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetLicencesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoApi(config);

            try
            {
                // List available video licences
                List<string> result = apiInstance.GetLicences();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.GetLicences: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetLicencesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List available video licences
    ApiResponse<List<string>> response = apiInstance.GetLicencesWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.GetLicencesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

**List<string>**

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

<a id="getliveid"></a>
# **GetLiveId**
> LiveVideoResponse GetLiveId (ApiV1VideosOwnershipIdAcceptPostIdParameter id)

Get information about a live

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetLiveIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid

            try
            {
                // Get information about a live
                LiveVideoResponse result = apiInstance.GetLiveId(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.GetLiveId: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetLiveIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get information about a live
    ApiResponse<LiveVideoResponse> response = apiInstance.GetLiveIdWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.GetLiveIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |

### Return type

[**LiveVideoResponse**](LiveVideoResponse.md)

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

<a id="getvideo"></a>
# **GetVideo**
> VideoDetails GetVideo (ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = null)

Get a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetVideoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var xPeertubeVideoPassword = "xPeertubeVideoPassword_example";  // string? | Required on password protected video (optional) 

            try
            {
                // Get a video
                VideoDetails result = apiInstance.GetVideo(id, xPeertubeVideoPassword);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.GetVideo: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetVideoWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a video
    ApiResponse<VideoDetails> response = apiInstance.GetVideoWithHttpInfo(id, xPeertubeVideoPassword);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.GetVideoWithHttpInfo: " + e.Message);
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

[**VideoDetails**](VideoDetails.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **403** | provide a correct password to access this password protected video |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getvideochannelvideos"></a>
# **GetVideoChannelVideos**
> VideoListResponse GetVideoChannelVideos (string channelHandle, GetAccountVideosCategoryOneOfParameter? categoryOneOf = null, bool? isLive = null, GetAccountVideosTagsOneOfParameter? tagsOneOf = null, GetAccountVideosTagsAllOfParameter? tagsAllOf = null, GetAccountVideosLicenceOneOfParameter? licenceOneOf = null, GetAccountVideosLanguageOneOfParameter? languageOneOf = null, GetAccountVideosTagsAllOfParameter? autoTagOneOf = null, string? nsfw = null, bool? isLocal = null, int? include = null, VideoPrivacySet? privacyOneOf = null, bool? hasHLSFiles = null, bool? hasWebVideoFiles = null, string? skipCount = null, int? start = null, int? count = null, string? sort = null, bool? excludeAlreadyWatched = null)

List videos of a video channel

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetVideoChannelVideosExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoApi(config);
            var channelHandle = my_username | my_username@example.com;  // string | The video channel handle
            var categoryOneOf = new GetAccountVideosCategoryOneOfParameter?(); // GetAccountVideosCategoryOneOfParameter? | category id of the video (see [/videos/categories](#operation/getCategories)) (optional) 
            var isLive = true;  // bool? | whether or not the video is a live (optional) 
            var tagsOneOf = new GetAccountVideosTagsOneOfParameter?(); // GetAccountVideosTagsOneOfParameter? | tag(s) of the video (optional) 
            var tagsAllOf = new GetAccountVideosTagsAllOfParameter?(); // GetAccountVideosTagsAllOfParameter? | tag(s) of the video, where all should be present in the video (optional) 
            var licenceOneOf = new GetAccountVideosLicenceOneOfParameter?(); // GetAccountVideosLicenceOneOfParameter? | licence id of the video (see [/videos/licences](#operation/getLicences)) (optional) 
            var languageOneOf = new GetAccountVideosLanguageOneOfParameter?(); // GetAccountVideosLanguageOneOfParameter? | language id of the video (see [/videos/languages](#operation/getLanguages)). Use `_unknown` to filter on videos that don't have a video language (optional) 
            var autoTagOneOf = new GetAccountVideosTagsAllOfParameter?(); // GetAccountVideosTagsAllOfParameter? | **PeerTube >= 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional) 
            var nsfw = "true";  // string? | whether to include nsfw videos, if any (optional) 
            var isLocal = true;  // bool? | **PeerTube >= 4.0** Display only local or remote objects (optional) 
            var include = 0;  // int? | **PeerTube >= 4.0** Include additional videos in results (can be combined using bitwise or operator) - `0` NONE - `1` NOT_PUBLISHED_STATE - `2` BLACKLISTED - `4` BLOCKED_OWNER - `8` FILES - `16` CAPTIONS - `32` VIDEO SOURCE  (optional) 
            var privacyOneOf = new VideoPrivacySet?(); // VideoPrivacySet? | **PeerTube >= 4.0** Display only videos in this specific privacy/privacies (optional) 
            var hasHLSFiles = true;  // bool? | **PeerTube >= 4.0** Display only videos that have HLS files (optional) 
            var hasWebVideoFiles = true;  // bool? | **PeerTube >= 6.0** Display only videos that have Web Video files (optional) 
            var skipCount = "true";  // string? | if you don't need the `total` in the response (optional)  (default to false)
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = "name";  // string? |  (optional) 
            var excludeAlreadyWatched = true;  // bool? | Whether or not to exclude videos that are in the user's video history (optional) 

            try
            {
                // List videos of a video channel
                VideoListResponse result = apiInstance.GetVideoChannelVideos(channelHandle, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.GetVideoChannelVideos: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetVideoChannelVideosWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List videos of a video channel
    ApiResponse<VideoListResponse> response = apiInstance.GetVideoChannelVideosWithHttpInfo(channelHandle, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.GetVideoChannelVideosWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channelHandle** | **string** | The video channel handle |  |
| **categoryOneOf** | [**GetAccountVideosCategoryOneOfParameter?**](GetAccountVideosCategoryOneOfParameter?.md) | category id of the video (see [/videos/categories](#operation/getCategories)) | [optional]  |
| **isLive** | **bool?** | whether or not the video is a live | [optional]  |
| **tagsOneOf** | [**GetAccountVideosTagsOneOfParameter?**](GetAccountVideosTagsOneOfParameter?.md) | tag(s) of the video | [optional]  |
| **tagsAllOf** | [**GetAccountVideosTagsAllOfParameter?**](GetAccountVideosTagsAllOfParameter?.md) | tag(s) of the video, where all should be present in the video | [optional]  |
| **licenceOneOf** | [**GetAccountVideosLicenceOneOfParameter?**](GetAccountVideosLicenceOneOfParameter?.md) | licence id of the video (see [/videos/licences](#operation/getLicences)) | [optional]  |
| **languageOneOf** | [**GetAccountVideosLanguageOneOfParameter?**](GetAccountVideosLanguageOneOfParameter?.md) | language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language | [optional]  |
| **autoTagOneOf** | [**GetAccountVideosTagsAllOfParameter?**](GetAccountVideosTagsAllOfParameter?.md) | **PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags | [optional]  |
| **nsfw** | **string?** | whether to include nsfw videos, if any | [optional]  |
| **isLocal** | **bool?** | **PeerTube &gt;&#x3D; 4.0** Display only local or remote objects | [optional]  |
| **include** | **int?** | **PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  | [optional]  |
| **privacyOneOf** | [**VideoPrivacySet?**](VideoPrivacySet?.md) | **PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies | [optional]  |
| **hasHLSFiles** | **bool?** | **PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files | [optional]  |
| **hasWebVideoFiles** | **bool?** | **PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files | [optional]  |
| **skipCount** | **string?** | if you don&#39;t need the &#x60;total&#x60; in the response | [optional] [default to false] |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** |  | [optional]  |
| **excludeAlreadyWatched** | **bool?** | Whether or not to exclude videos that are in the user&#39;s video history | [optional]  |

### Return type

[**VideoListResponse**](VideoListResponse.md)

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

<a id="getvideodesc"></a>
# **GetVideoDesc**
> string GetVideoDesc (ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = null)

Get complete video description

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetVideoDescExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var xPeertubeVideoPassword = "xPeertubeVideoPassword_example";  // string? | Required on password protected video (optional) 

            try
            {
                // Get complete video description
                string result = apiInstance.GetVideoDesc(id, xPeertubeVideoPassword);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.GetVideoDesc: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetVideoDescWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get complete video description
    ApiResponse<string> response = apiInstance.GetVideoDescWithHttpInfo(id, xPeertubeVideoPassword);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.GetVideoDescWithHttpInfo: " + e.Message);
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

**string**

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

<a id="getvideoprivacypolicies"></a>
# **GetVideoPrivacyPolicies**
> List&lt;string&gt; GetVideoPrivacyPolicies ()

List available video privacy policies

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetVideoPrivacyPoliciesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoApi(config);

            try
            {
                // List available video privacy policies
                List<string> result = apiInstance.GetVideoPrivacyPolicies();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.GetVideoPrivacyPolicies: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetVideoPrivacyPoliciesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List available video privacy policies
    ApiResponse<List<string>> response = apiInstance.GetVideoPrivacyPoliciesWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.GetVideoPrivacyPoliciesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

**List<string>**

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

<a id="getvideosource"></a>
# **GetVideoSource**
> VideoSource GetVideoSource (ApiV1VideosOwnershipIdAcceptPostIdParameter id)

Get video source file metadata

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetVideoSourceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid

            try
            {
                // Get video source file metadata
                VideoSource result = apiInstance.GetVideoSource(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.GetVideoSource: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetVideoSourceWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get video source file metadata
    ApiResponse<VideoSource> response = apiInstance.GetVideoSourceWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.GetVideoSourceWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |

### Return type

[**VideoSource**](VideoSource.md)

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

<a id="getvideos"></a>
# **GetVideos**
> VideoListResponse GetVideos (GetAccountVideosCategoryOneOfParameter? categoryOneOf = null, bool? isLive = null, GetAccountVideosTagsOneOfParameter? tagsOneOf = null, GetAccountVideosTagsAllOfParameter? tagsAllOf = null, GetAccountVideosLicenceOneOfParameter? licenceOneOf = null, GetAccountVideosLanguageOneOfParameter? languageOneOf = null, GetAccountVideosTagsAllOfParameter? autoTagOneOf = null, string? nsfw = null, bool? isLocal = null, int? include = null, VideoPrivacySet? privacyOneOf = null, bool? hasHLSFiles = null, bool? hasWebVideoFiles = null, string? skipCount = null, int? start = null, int? count = null, string? sort = null, bool? excludeAlreadyWatched = null)

List videos

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetVideosExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoApi(config);
            var categoryOneOf = new GetAccountVideosCategoryOneOfParameter?(); // GetAccountVideosCategoryOneOfParameter? | category id of the video (see [/videos/categories](#operation/getCategories)) (optional) 
            var isLive = true;  // bool? | whether or not the video is a live (optional) 
            var tagsOneOf = new GetAccountVideosTagsOneOfParameter?(); // GetAccountVideosTagsOneOfParameter? | tag(s) of the video (optional) 
            var tagsAllOf = new GetAccountVideosTagsAllOfParameter?(); // GetAccountVideosTagsAllOfParameter? | tag(s) of the video, where all should be present in the video (optional) 
            var licenceOneOf = new GetAccountVideosLicenceOneOfParameter?(); // GetAccountVideosLicenceOneOfParameter? | licence id of the video (see [/videos/licences](#operation/getLicences)) (optional) 
            var languageOneOf = new GetAccountVideosLanguageOneOfParameter?(); // GetAccountVideosLanguageOneOfParameter? | language id of the video (see [/videos/languages](#operation/getLanguages)). Use `_unknown` to filter on videos that don't have a video language (optional) 
            var autoTagOneOf = new GetAccountVideosTagsAllOfParameter?(); // GetAccountVideosTagsAllOfParameter? | **PeerTube >= 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional) 
            var nsfw = "true";  // string? | whether to include nsfw videos, if any (optional) 
            var isLocal = true;  // bool? | **PeerTube >= 4.0** Display only local or remote objects (optional) 
            var include = 0;  // int? | **PeerTube >= 4.0** Include additional videos in results (can be combined using bitwise or operator) - `0` NONE - `1` NOT_PUBLISHED_STATE - `2` BLACKLISTED - `4` BLOCKED_OWNER - `8` FILES - `16` CAPTIONS - `32` VIDEO SOURCE  (optional) 
            var privacyOneOf = new VideoPrivacySet?(); // VideoPrivacySet? | **PeerTube >= 4.0** Display only videos in this specific privacy/privacies (optional) 
            var hasHLSFiles = true;  // bool? | **PeerTube >= 4.0** Display only videos that have HLS files (optional) 
            var hasWebVideoFiles = true;  // bool? | **PeerTube >= 6.0** Display only videos that have Web Video files (optional) 
            var skipCount = "true";  // string? | if you don't need the `total` in the response (optional)  (default to false)
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = "name";  // string? |  (optional) 
            var excludeAlreadyWatched = true;  // bool? | Whether or not to exclude videos that are in the user's video history (optional) 

            try
            {
                // List videos
                VideoListResponse result = apiInstance.GetVideos(categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.GetVideos: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetVideosWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List videos
    ApiResponse<VideoListResponse> response = apiInstance.GetVideosWithHttpInfo(categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.GetVideosWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **categoryOneOf** | [**GetAccountVideosCategoryOneOfParameter?**](GetAccountVideosCategoryOneOfParameter?.md) | category id of the video (see [/videos/categories](#operation/getCategories)) | [optional]  |
| **isLive** | **bool?** | whether or not the video is a live | [optional]  |
| **tagsOneOf** | [**GetAccountVideosTagsOneOfParameter?**](GetAccountVideosTagsOneOfParameter?.md) | tag(s) of the video | [optional]  |
| **tagsAllOf** | [**GetAccountVideosTagsAllOfParameter?**](GetAccountVideosTagsAllOfParameter?.md) | tag(s) of the video, where all should be present in the video | [optional]  |
| **licenceOneOf** | [**GetAccountVideosLicenceOneOfParameter?**](GetAccountVideosLicenceOneOfParameter?.md) | licence id of the video (see [/videos/licences](#operation/getLicences)) | [optional]  |
| **languageOneOf** | [**GetAccountVideosLanguageOneOfParameter?**](GetAccountVideosLanguageOneOfParameter?.md) | language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language | [optional]  |
| **autoTagOneOf** | [**GetAccountVideosTagsAllOfParameter?**](GetAccountVideosTagsAllOfParameter?.md) | **PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags | [optional]  |
| **nsfw** | **string?** | whether to include nsfw videos, if any | [optional]  |
| **isLocal** | **bool?** | **PeerTube &gt;&#x3D; 4.0** Display only local or remote objects | [optional]  |
| **include** | **int?** | **PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  | [optional]  |
| **privacyOneOf** | [**VideoPrivacySet?**](VideoPrivacySet?.md) | **PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies | [optional]  |
| **hasHLSFiles** | **bool?** | **PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files | [optional]  |
| **hasWebVideoFiles** | **bool?** | **PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files | [optional]  |
| **skipCount** | **string?** | if you don&#39;t need the &#x60;total&#x60; in the response | [optional] [default to false] |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** |  | [optional]  |
| **excludeAlreadyWatched** | **bool?** | Whether or not to exclude videos that are in the user&#39;s video history | [optional]  |

### Return type

[**VideoListResponse**](VideoListResponse.md)

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

<a id="listvideostoryboards"></a>
# **ListVideoStoryboards**
> ListVideoStoryboards200Response ListVideoStoryboards (ApiV1VideosOwnershipIdAcceptPostIdParameter id)

List storyboards of a video

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
    public class ListVideoStoryboardsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid

            try
            {
                // List storyboards of a video
                ListVideoStoryboards200Response result = apiInstance.ListVideoStoryboards(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.ListVideoStoryboards: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListVideoStoryboardsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List storyboards of a video
    ApiResponse<ListVideoStoryboards200Response> response = apiInstance.ListVideoStoryboardsWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.ListVideoStoryboardsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |

### Return type

[**ListVideoStoryboards200Response**](ListVideoStoryboards200Response.md)

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

<a id="putvideo"></a>
# **PutVideo**
> void PutVideo (ApiV1VideosOwnershipIdAcceptPostIdParameter id, System.IO.Stream? thumbnailfile = null, System.IO.Stream? previewfile = null, int? category = null, int? licence = null, string? language = null, VideoPrivacySet? privacy = null, string? description = null, string? waitTranscoding = null, string? support = null, bool? nsfw = null, string? name = null, List<string>? tags = null, bool? commentsEnabled = null, VideoCommentsPolicySet? commentsPolicy = null, bool? downloadEnabled = null, DateTime? originallyPublishedAt = null, VideoScheduledUpdate? scheduleUpdate = null, List<string>? videoPasswords = null)

Update a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class PutVideoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var thumbnailfile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? | Video thumbnail file (optional) 
            var previewfile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? | Video preview file (optional) 
            var category = 56;  // int? | category id of the video (see [/videos/categories](#operation/getCategories)) (optional) 
            var licence = 56;  // int? | licence id of the video (see [/videos/licences](#operation/getLicences)) (optional) 
            var language = "language_example";  // string? | language id of the video (see [/videos/languages](#operation/getLanguages)) (optional) 
            var privacy = new VideoPrivacySet?(); // VideoPrivacySet? |  (optional) 
            var description = "description_example";  // string? | Video description (optional) 
            var waitTranscoding = "waitTranscoding_example";  // string? | Whether or not we wait transcoding before publish the video (optional) 
            var support = "support_example";  // string? | A text tell the audience how to support the video creator (optional) 
            var nsfw = true;  // bool? | Whether or not this video contains sensitive content (optional) 
            var name = "name_example";  // string? | Video name (optional) 
            var tags = new List<string>?(); // List<string>? | Video tags (maximum 5 tags each between 2 and 30 characters) (optional) 
            var commentsEnabled = true;  // bool? | Deprecated in 6.2, use commentsPolicy instead (optional) 
            var commentsPolicy = new VideoCommentsPolicySet?(); // VideoCommentsPolicySet? |  (optional) 
            var downloadEnabled = true;  // bool? | Enable or disable downloading for this video (optional) 
            var originallyPublishedAt = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Date when the content was originally published (optional) 
            var scheduleUpdate = new VideoScheduledUpdate?(); // VideoScheduledUpdate? |  (optional) 
            var videoPasswords = new List<string>?(); // List<string>? |  (optional) 

            try
            {
                // Update a video
                apiInstance.PutVideo(id, thumbnailfile, previewfile, category, licence, language, privacy, description, waitTranscoding, support, nsfw, name, tags, commentsEnabled, commentsPolicy, downloadEnabled, originallyPublishedAt, scheduleUpdate, videoPasswords);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.PutVideo: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PutVideoWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update a video
    apiInstance.PutVideoWithHttpInfo(id, thumbnailfile, previewfile, category, licence, language, privacy, description, waitTranscoding, support, nsfw, name, tags, commentsEnabled, commentsPolicy, downloadEnabled, originallyPublishedAt, scheduleUpdate, videoPasswords);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.PutVideoWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **thumbnailfile** | **System.IO.Stream?****System.IO.Stream?** | Video thumbnail file | [optional]  |
| **previewfile** | **System.IO.Stream?****System.IO.Stream?** | Video preview file | [optional]  |
| **category** | **int?** | category id of the video (see [/videos/categories](#operation/getCategories)) | [optional]  |
| **licence** | **int?** | licence id of the video (see [/videos/licences](#operation/getLicences)) | [optional]  |
| **language** | **string?** | language id of the video (see [/videos/languages](#operation/getLanguages)) | [optional]  |
| **privacy** | [**VideoPrivacySet?**](VideoPrivacySet?.md) |  | [optional]  |
| **description** | **string?** | Video description | [optional]  |
| **waitTranscoding** | **string?** | Whether or not we wait transcoding before publish the video | [optional]  |
| **support** | **string?** | A text tell the audience how to support the video creator | [optional]  |
| **nsfw** | **bool?** | Whether or not this video contains sensitive content | [optional]  |
| **name** | **string?** | Video name | [optional]  |
| **tags** | [**List&lt;string&gt;?**](string.md) | Video tags (maximum 5 tags each between 2 and 30 characters) | [optional]  |
| **commentsEnabled** | **bool?** | Deprecated in 6.2, use commentsPolicy instead | [optional]  |
| **commentsPolicy** | [**VideoCommentsPolicySet?**](VideoCommentsPolicySet?.md) |  | [optional]  |
| **downloadEnabled** | **bool?** | Enable or disable downloading for this video | [optional]  |
| **originallyPublishedAt** | **DateTime?** | Date when the content was originally published | [optional]  |
| **scheduleUpdate** | [**VideoScheduledUpdate?**](VideoScheduledUpdate?.md) |  | [optional]  |
| **videoPasswords** | [**List&lt;string&gt;?**](string.md) |  | [optional]  |

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

            var apiInstance = new VideoApi(config);
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
                Debug.Print("Exception when calling VideoApi.ReplaceVideoSourceResumable: " + e.Message);
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
    Debug.Print("Exception when calling VideoApi.ReplaceVideoSourceResumableWithHttpInfo: " + e.Message);
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

            var apiInstance = new VideoApi(config);
            var uploadId = "uploadId_example";  // string | Created session id to proceed with. If you didn't send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. 
            var contentLength = 0;  // decimal | 

            try
            {
                // Cancel the resumable replacement of a video
                apiInstance.ReplaceVideoSourceResumableCancel(uploadId, contentLength);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.ReplaceVideoSourceResumableCancel: " + e.Message);
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
    Debug.Print("Exception when calling VideoApi.ReplaceVideoSourceResumableCancelWithHttpInfo: " + e.Message);
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

            var apiInstance = new VideoApi(config);
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
                Debug.Print("Exception when calling VideoApi.ReplaceVideoSourceResumableInit: " + e.Message);
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
    Debug.Print("Exception when calling VideoApi.ReplaceVideoSourceResumableInitWithHttpInfo: " + e.Message);
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

<a id="requestvideotoken"></a>
# **RequestVideoToken**
> VideoTokenResponse RequestVideoToken (ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = null)

Request video token

Request special tokens that expire quickly to use them in some context (like accessing private static files)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class RequestVideoTokenExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var xPeertubeVideoPassword = "xPeertubeVideoPassword_example";  // string? | Required on password protected video (optional) 

            try
            {
                // Request video token
                VideoTokenResponse result = apiInstance.RequestVideoToken(id, xPeertubeVideoPassword);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.RequestVideoToken: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the RequestVideoTokenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Request video token
    ApiResponse<VideoTokenResponse> response = apiInstance.RequestVideoTokenWithHttpInfo(id, xPeertubeVideoPassword);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.RequestVideoTokenWithHttpInfo: " + e.Message);
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

[**VideoTokenResponse**](VideoTokenResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | incorrect parameters |  -  |
| **404** | video not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="searchvideos"></a>
# **SearchVideos**
> VideoListResponse SearchVideos (string search, GetAccountVideosCategoryOneOfParameter? categoryOneOf = null, bool? isLive = null, GetAccountVideosTagsOneOfParameter? tagsOneOf = null, GetAccountVideosTagsAllOfParameter? tagsAllOf = null, GetAccountVideosLicenceOneOfParameter? licenceOneOf = null, GetAccountVideosLanguageOneOfParameter? languageOneOf = null, GetAccountVideosTagsAllOfParameter? autoTagOneOf = null, string? nsfw = null, bool? isLocal = null, int? include = null, VideoPrivacySet? privacyOneOf = null, List<string>? uuids = null, bool? hasHLSFiles = null, bool? hasWebVideoFiles = null, string? skipCount = null, int? start = null, int? count = null, string? searchTarget = null, string? sort = null, bool? excludeAlreadyWatched = null, string? host = null, DateTime? startDate = null, DateTime? endDate = null, DateTime? originallyPublishedStartDate = null, DateTime? originallyPublishedEndDate = null, int? durationMin = null, int? durationMax = null)

Search videos

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class SearchVideosExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoApi(config);
            var search = "search_example";  // string | String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete video information and interact with it. 
            var categoryOneOf = new GetAccountVideosCategoryOneOfParameter?(); // GetAccountVideosCategoryOneOfParameter? | category id of the video (see [/videos/categories](#operation/getCategories)) (optional) 
            var isLive = true;  // bool? | whether or not the video is a live (optional) 
            var tagsOneOf = new GetAccountVideosTagsOneOfParameter?(); // GetAccountVideosTagsOneOfParameter? | tag(s) of the video (optional) 
            var tagsAllOf = new GetAccountVideosTagsAllOfParameter?(); // GetAccountVideosTagsAllOfParameter? | tag(s) of the video, where all should be present in the video (optional) 
            var licenceOneOf = new GetAccountVideosLicenceOneOfParameter?(); // GetAccountVideosLicenceOneOfParameter? | licence id of the video (see [/videos/licences](#operation/getLicences)) (optional) 
            var languageOneOf = new GetAccountVideosLanguageOneOfParameter?(); // GetAccountVideosLanguageOneOfParameter? | language id of the video (see [/videos/languages](#operation/getLanguages)). Use `_unknown` to filter on videos that don't have a video language (optional) 
            var autoTagOneOf = new GetAccountVideosTagsAllOfParameter?(); // GetAccountVideosTagsAllOfParameter? | **PeerTube >= 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional) 
            var nsfw = "true";  // string? | whether to include nsfw videos, if any (optional) 
            var isLocal = true;  // bool? | **PeerTube >= 4.0** Display only local or remote objects (optional) 
            var include = 0;  // int? | **PeerTube >= 4.0** Include additional videos in results (can be combined using bitwise or operator) - `0` NONE - `1` NOT_PUBLISHED_STATE - `2` BLACKLISTED - `4` BLOCKED_OWNER - `8` FILES - `16` CAPTIONS - `32` VIDEO SOURCE  (optional) 
            var privacyOneOf = new VideoPrivacySet?(); // VideoPrivacySet? | **PeerTube >= 4.0** Display only videos in this specific privacy/privacies (optional) 
            var uuids = new List<string>?(); // List<string>? | Find elements with specific UUIDs (optional) 
            var hasHLSFiles = true;  // bool? | **PeerTube >= 4.0** Display only videos that have HLS files (optional) 
            var hasWebVideoFiles = true;  // bool? | **PeerTube >= 6.0** Display only videos that have Web Video files (optional) 
            var skipCount = "true";  // string? | if you don't need the `total` in the response (optional)  (default to false)
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var searchTarget = "local";  // string? | If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn't have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional) 
            var sort = "name";  // string? | Sort videos by criteria (prefixing with `-` means `DESC` order):  (optional) 
            var excludeAlreadyWatched = true;  // bool? | Whether or not to exclude videos that are in the user's video history (optional) 
            var host = "host_example";  // string? | Find elements owned by this host (optional) 
            var startDate = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Get videos that are published after this date (optional) 
            var endDate = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Get videos that are published before this date (optional) 
            var originallyPublishedStartDate = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Get videos that are originally published after this date (optional) 
            var originallyPublishedEndDate = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Get videos that are originally published before this date (optional) 
            var durationMin = 56;  // int? | Get videos that have this minimum duration (optional) 
            var durationMax = 56;  // int? | Get videos that have this maximum duration (optional) 

            try
            {
                // Search videos
                VideoListResponse result = apiInstance.SearchVideos(search, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, uuids, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, searchTarget, sort, excludeAlreadyWatched, host, startDate, endDate, originallyPublishedStartDate, originallyPublishedEndDate, durationMin, durationMax);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.SearchVideos: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchVideosWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search videos
    ApiResponse<VideoListResponse> response = apiInstance.SearchVideosWithHttpInfo(search, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, uuids, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, searchTarget, sort, excludeAlreadyWatched, host, startDate, endDate, originallyPublishedStartDate, originallyPublishedEndDate, durationMin, durationMax);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.SearchVideosWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **search** | **string** | String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete video information and interact with it.  |  |
| **categoryOneOf** | [**GetAccountVideosCategoryOneOfParameter?**](GetAccountVideosCategoryOneOfParameter?.md) | category id of the video (see [/videos/categories](#operation/getCategories)) | [optional]  |
| **isLive** | **bool?** | whether or not the video is a live | [optional]  |
| **tagsOneOf** | [**GetAccountVideosTagsOneOfParameter?**](GetAccountVideosTagsOneOfParameter?.md) | tag(s) of the video | [optional]  |
| **tagsAllOf** | [**GetAccountVideosTagsAllOfParameter?**](GetAccountVideosTagsAllOfParameter?.md) | tag(s) of the video, where all should be present in the video | [optional]  |
| **licenceOneOf** | [**GetAccountVideosLicenceOneOfParameter?**](GetAccountVideosLicenceOneOfParameter?.md) | licence id of the video (see [/videos/licences](#operation/getLicences)) | [optional]  |
| **languageOneOf** | [**GetAccountVideosLanguageOneOfParameter?**](GetAccountVideosLanguageOneOfParameter?.md) | language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language | [optional]  |
| **autoTagOneOf** | [**GetAccountVideosTagsAllOfParameter?**](GetAccountVideosTagsAllOfParameter?.md) | **PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags | [optional]  |
| **nsfw** | **string?** | whether to include nsfw videos, if any | [optional]  |
| **isLocal** | **bool?** | **PeerTube &gt;&#x3D; 4.0** Display only local or remote objects | [optional]  |
| **include** | **int?** | **PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  | [optional]  |
| **privacyOneOf** | [**VideoPrivacySet?**](VideoPrivacySet?.md) | **PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies | [optional]  |
| **uuids** | [**List&lt;string&gt;?**](string.md) | Find elements with specific UUIDs | [optional]  |
| **hasHLSFiles** | **bool?** | **PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files | [optional]  |
| **hasWebVideoFiles** | **bool?** | **PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files | [optional]  |
| **skipCount** | **string?** | if you don&#39;t need the &#x60;total&#x60; in the response | [optional] [default to false] |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **searchTarget** | **string?** | If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  | [optional]  |
| **sort** | **string?** | Sort videos by criteria (prefixing with &#x60;-&#x60; means &#x60;DESC&#x60; order):  | [optional]  |
| **excludeAlreadyWatched** | **bool?** | Whether or not to exclude videos that are in the user&#39;s video history | [optional]  |
| **host** | **string?** | Find elements owned by this host | [optional]  |
| **startDate** | **DateTime?** | Get videos that are published after this date | [optional]  |
| **endDate** | **DateTime?** | Get videos that are published before this date | [optional]  |
| **originallyPublishedStartDate** | **DateTime?** | Get videos that are originally published after this date | [optional]  |
| **originallyPublishedEndDate** | **DateTime?** | Get videos that are originally published before this date | [optional]  |
| **durationMin** | **int?** | Get videos that have this minimum duration | [optional]  |
| **durationMax** | **int?** | Get videos that have this maximum duration | [optional]  |

### Return type

[**VideoListResponse**](VideoListResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **500** | search index unavailable |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updateliveid"></a>
# **UpdateLiveId**
> void UpdateLiveId (ApiV1VideosOwnershipIdAcceptPostIdParameter id, LiveVideoUpdate? liveVideoUpdate = null)

Update information about a live

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class UpdateLiveIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var liveVideoUpdate = new LiveVideoUpdate?(); // LiveVideoUpdate? |  (optional) 

            try
            {
                // Update information about a live
                apiInstance.UpdateLiveId(id, liveVideoUpdate);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.UpdateLiveId: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateLiveIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update information about a live
    apiInstance.UpdateLiveIdWithHttpInfo(id, liveVideoUpdate);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoApi.UpdateLiveIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **liveVideoUpdate** | [**LiveVideoUpdate?**](LiveVideoUpdate?.md) |  | [optional]  |

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
| **400** | bad parameters or trying to update a live that has already started |  -  |
| **403** | trying to save replay of the live but saving replay is not enabled on the instance |  -  |

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

            var apiInstance = new VideoApi(config);
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
                Debug.Print("Exception when calling VideoApi.UploadLegacy: " + e.Message);
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
    Debug.Print("Exception when calling VideoApi.UploadLegacyWithHttpInfo: " + e.Message);
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

            var apiInstance = new VideoApi(config);
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
                Debug.Print("Exception when calling VideoApi.UploadResumable: " + e.Message);
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
    Debug.Print("Exception when calling VideoApi.UploadResumableWithHttpInfo: " + e.Message);
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

            var apiInstance = new VideoApi(config);
            var uploadId = "uploadId_example";  // string | Created session id to proceed with. If you didn't send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. 
            var contentLength = 0;  // decimal | 

            try
            {
                // Cancel the resumable upload of a video, deleting any data uploaded so far
                apiInstance.UploadResumableCancel(uploadId, contentLength);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoApi.UploadResumableCancel: " + e.Message);
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
    Debug.Print("Exception when calling VideoApi.UploadResumableCancelWithHttpInfo: " + e.Message);
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

            var apiInstance = new VideoApi(config);
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
                Debug.Print("Exception when calling VideoApi.UploadResumableInit: " + e.Message);
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
    Debug.Print("Exception when calling VideoApi.UploadResumableInitWithHttpInfo: " + e.Message);
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

