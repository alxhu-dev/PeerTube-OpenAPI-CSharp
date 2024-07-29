# PeerTubeApiClient.Api.VideosApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AddVideoPlaylistVideo**](VideosApi.md#addvideoplaylistvideo) | **POST** /api/v1/video-playlists/{playlistId}/videos | Add a video in a playlist |
| [**ApiV1UsersMeSubscriptionsVideosGet**](VideosApi.md#apiv1usersmesubscriptionsvideosget) | **GET** /api/v1/users/me/subscriptions/videos | List videos of subscriptions of my user |
| [**ApiV1UsersMeVideosGet**](VideosApi.md#apiv1usersmevideosget) | **GET** /api/v1/users/me/videos | List videos of my user |
| [**ApiV1UsersMeVideosImportsGet**](VideosApi.md#apiv1usersmevideosimportsget) | **GET** /api/v1/users/me/videos/imports | Get video imports of my user |
| [**GetVideoPlaylistVideos**](VideosApi.md#getvideoplaylistvideos) | **GET** /api/v1/video-playlists/{playlistId}/videos | List videos of a playlist |

<a id="addvideoplaylistvideo"></a>
# **AddVideoPlaylistVideo**
> AddVideoPlaylistVideo200Response AddVideoPlaylistVideo (int playlistId, AddVideoPlaylistVideoRequest? addVideoPlaylistVideoRequest = null)

Add a video in a playlist

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class AddVideoPlaylistVideoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideosApi(config);
            var playlistId = 56;  // int | Playlist id
            var addVideoPlaylistVideoRequest = new AddVideoPlaylistVideoRequest?(); // AddVideoPlaylistVideoRequest? |  (optional) 

            try
            {
                // Add a video in a playlist
                AddVideoPlaylistVideo200Response result = apiInstance.AddVideoPlaylistVideo(playlistId, addVideoPlaylistVideoRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideosApi.AddVideoPlaylistVideo: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AddVideoPlaylistVideoWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Add a video in a playlist
    ApiResponse<AddVideoPlaylistVideo200Response> response = apiInstance.AddVideoPlaylistVideoWithHttpInfo(playlistId, addVideoPlaylistVideoRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideosApi.AddVideoPlaylistVideoWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **playlistId** | **int** | Playlist id |  |
| **addVideoPlaylistVideoRequest** | [**AddVideoPlaylistVideoRequest?**](AddVideoPlaylistVideoRequest?.md) |  | [optional]  |

### Return type

[**AddVideoPlaylistVideo200Response**](AddVideoPlaylistVideo200Response.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1usersmesubscriptionsvideosget"></a>
# **ApiV1UsersMeSubscriptionsVideosGet**
> VideoListResponse ApiV1UsersMeSubscriptionsVideosGet (GetAccountVideosCategoryOneOfParameter? categoryOneOf = null, bool? isLive = null, GetAccountVideosTagsOneOfParameter? tagsOneOf = null, GetAccountVideosTagsAllOfParameter? tagsAllOf = null, GetAccountVideosLicenceOneOfParameter? licenceOneOf = null, GetAccountVideosLanguageOneOfParameter? languageOneOf = null, GetAccountVideosTagsAllOfParameter? autoTagOneOf = null, string? nsfw = null, bool? isLocal = null, int? include = null, VideoPrivacySet? privacyOneOf = null, bool? hasHLSFiles = null, bool? hasWebVideoFiles = null, string? skipCount = null, int? start = null, int? count = null, string? sort = null, bool? excludeAlreadyWatched = null)

List videos of subscriptions of my user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeSubscriptionsVideosGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideosApi(config);
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
                // List videos of subscriptions of my user
                VideoListResponse result = apiInstance.ApiV1UsersMeSubscriptionsVideosGet(categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideosApi.ApiV1UsersMeSubscriptionsVideosGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeSubscriptionsVideosGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List videos of subscriptions of my user
    ApiResponse<VideoListResponse> response = apiInstance.ApiV1UsersMeSubscriptionsVideosGetWithHttpInfo(categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideosApi.ApiV1UsersMeSubscriptionsVideosGetWithHttpInfo: " + e.Message);
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

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1usersmevideosget"></a>
# **ApiV1UsersMeVideosGet**
> VideoListResponse ApiV1UsersMeVideosGet (int? start = null, int? count = null, string? sort = null)

List videos of my user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeVideosGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideosApi(config);
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List videos of my user
                VideoListResponse result = apiInstance.ApiV1UsersMeVideosGet(start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideosApi.ApiV1UsersMeVideosGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeVideosGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List videos of my user
    ApiResponse<VideoListResponse> response = apiInstance.ApiV1UsersMeVideosGetWithHttpInfo(start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideosApi.ApiV1UsersMeVideosGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort column | [optional]  |

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

<a id="apiv1usersmevideosimportsget"></a>
# **ApiV1UsersMeVideosImportsGet**
> VideoImportsList ApiV1UsersMeVideosImportsGet (int? start = null, int? count = null, string? sort = null, string? targetUrl = null, decimal? videoChannelSyncId = null, string? search = null)

Get video imports of my user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeVideosImportsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideosApi(config);
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 
            var targetUrl = "targetUrl_example";  // string? | Filter on import target URL (optional) 
            var videoChannelSyncId = 8.14D;  // decimal? | Filter on imports created by a specific channel synchronization (optional) 
            var search = "search_example";  // string? | Search in video names (optional) 

            try
            {
                // Get video imports of my user
                VideoImportsList result = apiInstance.ApiV1UsersMeVideosImportsGet(start, count, sort, targetUrl, videoChannelSyncId, search);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideosApi.ApiV1UsersMeVideosImportsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeVideosImportsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get video imports of my user
    ApiResponse<VideoImportsList> response = apiInstance.ApiV1UsersMeVideosImportsGetWithHttpInfo(start, count, sort, targetUrl, videoChannelSyncId, search);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideosApi.ApiV1UsersMeVideosImportsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort column | [optional]  |
| **targetUrl** | **string?** | Filter on import target URL | [optional]  |
| **videoChannelSyncId** | **decimal?** | Filter on imports created by a specific channel synchronization | [optional]  |
| **search** | **string?** | Search in video names | [optional]  |

### Return type

[**VideoImportsList**](VideoImportsList.md)

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

<a id="getvideoplaylistvideos"></a>
# **GetVideoPlaylistVideos**
> VideoListResponse GetVideoPlaylistVideos (int playlistId, int? start = null, int? count = null)

List videos of a playlist

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetVideoPlaylistVideosExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideosApi(config);
            var playlistId = 56;  // int | Playlist id
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)

            try
            {
                // List videos of a playlist
                VideoListResponse result = apiInstance.GetVideoPlaylistVideos(playlistId, start, count);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideosApi.GetVideoPlaylistVideos: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetVideoPlaylistVideosWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List videos of a playlist
    ApiResponse<VideoListResponse> response = apiInstance.GetVideoPlaylistVideosWithHttpInfo(playlistId, start, count);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideosApi.GetVideoPlaylistVideosWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **playlistId** | **int** | Playlist id |  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |

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

