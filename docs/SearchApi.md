# PeerTubeApiClient.Api.SearchApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**SearchChannels**](SearchApi.md#searchchannels) | **GET** /api/v1/search/video-channels | Search channels |
| [**SearchPlaylists**](SearchApi.md#searchplaylists) | **GET** /api/v1/search/video-playlists | Search playlists |
| [**SearchVideos**](SearchApi.md#searchvideos) | **GET** /api/v1/search/videos | Search videos |

<a id="searchchannels"></a>
# **SearchChannels**
> VideoChannelList SearchChannels (string search, int? start = null, int? count = null, string? searchTarget = null, string? sort = null, string? host = null, List<string>? handles = null)

Search channels

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class SearchChannelsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new SearchApi(config);
            var search = "search_example";  // string | String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete channel information and interact with it. 
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var searchTarget = "local";  // string? | If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn't have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional) 
            var sort = -createdAt;  // string? | Sort column (optional) 
            var host = "host_example";  // string? | Find elements owned by this host (optional) 
            var handles = new List<string>?(); // List<string>? | Find elements with these handles (optional) 

            try
            {
                // Search channels
                VideoChannelList result = apiInstance.SearchChannels(search, start, count, searchTarget, sort, host, handles);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SearchApi.SearchChannels: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchChannelsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search channels
    ApiResponse<VideoChannelList> response = apiInstance.SearchChannelsWithHttpInfo(search, start, count, searchTarget, sort, host, handles);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SearchApi.SearchChannelsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **search** | **string** | String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete channel information and interact with it.  |  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **searchTarget** | **string?** | If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  | [optional]  |
| **sort** | **string?** | Sort column | [optional]  |
| **host** | **string?** | Find elements owned by this host | [optional]  |
| **handles** | [**List&lt;string&gt;?**](string.md) | Find elements with these handles | [optional]  |

### Return type

[**VideoChannelList**](VideoChannelList.md)

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

<a id="searchplaylists"></a>
# **SearchPlaylists**
> ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response SearchPlaylists (string search, int? start = null, int? count = null, string? searchTarget = null, string? sort = null, string? host = null, List<string>? uuids = null)

Search playlists

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class SearchPlaylistsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new SearchApi(config);
            var search = "search_example";  // string | String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete playlist information and interact with it. 
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var searchTarget = "local";  // string? | If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn't have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional) 
            var sort = -createdAt;  // string? | Sort column (optional) 
            var host = "host_example";  // string? | Find elements owned by this host (optional) 
            var uuids = new List<string>?(); // List<string>? | Find elements with specific UUIDs (optional) 

            try
            {
                // Search playlists
                ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response result = apiInstance.SearchPlaylists(search, start, count, searchTarget, sort, host, uuids);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SearchApi.SearchPlaylists: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchPlaylistsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search playlists
    ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> response = apiInstance.SearchPlaylistsWithHttpInfo(search, start, count, searchTarget, sort, host, uuids);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SearchApi.SearchPlaylistsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **search** | **string** | String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete playlist information and interact with it.  |  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **searchTarget** | **string?** | If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  | [optional]  |
| **sort** | **string?** | Sort column | [optional]  |
| **host** | **string?** | Find elements owned by this host | [optional]  |
| **uuids** | [**List&lt;string&gt;?**](string.md) | Find elements with specific UUIDs | [optional]  |

### Return type

[**ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response**](ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response.md)

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
            var apiInstance = new SearchApi(config);
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
                Debug.Print("Exception when calling SearchApi.SearchVideos: " + e.Message);
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
    Debug.Print("Exception when calling SearchApi.SearchVideosWithHttpInfo: " + e.Message);
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

