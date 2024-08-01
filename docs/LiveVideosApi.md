# PeerTubeApiClient.Api.LiveVideosApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AddLive**](LiveVideosApi.md#addlive) | **POST** /api/v1/videos/live | Create a live |
| [**ApiV1VideosIdLiveSessionGet**](LiveVideosApi.md#apiv1videosidlivesessionget) | **GET** /api/v1/videos/{id}/live-session | Get live session of a replay |
| [**ApiV1VideosLiveIdSessionsGet**](LiveVideosApi.md#apiv1videosliveidsessionsget) | **GET** /api/v1/videos/live/{id}/sessions | List live sessions |
| [**GetLiveId**](LiveVideosApi.md#getliveid) | **GET** /api/v1/videos/live/{id} | Get information about a live |
| [**UpdateLiveId**](LiveVideosApi.md#updateliveid) | **PUT** /api/v1/videos/live/{id} | Update information about a live |

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

            var apiInstance = new LiveVideosApi(config);
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
                Debug.Print("Exception when calling LiveVideosApi.AddLive: " + e.Message);
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
    Debug.Print("Exception when calling LiveVideosApi.AddLiveWithHttpInfo: " + e.Message);
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

<a id="apiv1videosidlivesessionget"></a>
# **ApiV1VideosIdLiveSessionGet**
> LiveVideoSessionResponse ApiV1VideosIdLiveSessionGet (ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = null)

Get live session of a replay

If the video is a replay of a live, you can find the associated live session using this endpoint

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdLiveSessionGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LiveVideosApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var xPeertubeVideoPassword = "xPeertubeVideoPassword_example";  // string? | Required on password protected video (optional) 

            try
            {
                // Get live session of a replay
                LiveVideoSessionResponse result = apiInstance.ApiV1VideosIdLiveSessionGet(id, xPeertubeVideoPassword);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LiveVideosApi.ApiV1VideosIdLiveSessionGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdLiveSessionGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get live session of a replay
    ApiResponse<LiveVideoSessionResponse> response = apiInstance.ApiV1VideosIdLiveSessionGetWithHttpInfo(id, xPeertubeVideoPassword);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling LiveVideosApi.ApiV1VideosIdLiveSessionGetWithHttpInfo: " + e.Message);
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

[**LiveVideoSessionResponse**](LiveVideoSessionResponse.md)

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

<a id="apiv1videosliveidsessionsget"></a>
# **ApiV1VideosLiveIdSessionsGet**
> ApiV1VideosLiveIdSessionsGet200Response ApiV1VideosLiveIdSessionsGet (ApiV1VideosOwnershipIdAcceptPostIdParameter id)

List live sessions

List all sessions created in a particular live

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosLiveIdSessionsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LiveVideosApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid

            try
            {
                // List live sessions
                ApiV1VideosLiveIdSessionsGet200Response result = apiInstance.ApiV1VideosLiveIdSessionsGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LiveVideosApi.ApiV1VideosLiveIdSessionsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosLiveIdSessionsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List live sessions
    ApiResponse<ApiV1VideosLiveIdSessionsGet200Response> response = apiInstance.ApiV1VideosLiveIdSessionsGetWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling LiveVideosApi.ApiV1VideosLiveIdSessionsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |

### Return type

[**ApiV1VideosLiveIdSessionsGet200Response**](ApiV1VideosLiveIdSessionsGet200Response.md)

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

            var apiInstance = new LiveVideosApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid

            try
            {
                // Get information about a live
                LiveVideoResponse result = apiInstance.GetLiveId(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LiveVideosApi.GetLiveId: " + e.Message);
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
    Debug.Print("Exception when calling LiveVideosApi.GetLiveIdWithHttpInfo: " + e.Message);
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

            var apiInstance = new LiveVideosApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var liveVideoUpdate = new LiveVideoUpdate?(); // LiveVideoUpdate? |  (optional) 

            try
            {
                // Update information about a live
                apiInstance.UpdateLiveId(id, liveVideoUpdate);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling LiveVideosApi.UpdateLiveId: " + e.Message);
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
    Debug.Print("Exception when calling LiveVideosApi.UpdateLiveIdWithHttpInfo: " + e.Message);
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

