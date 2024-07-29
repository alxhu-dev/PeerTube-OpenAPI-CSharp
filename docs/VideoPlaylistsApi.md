# PeerTubeApiClient.Api.VideoPlaylistsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AddPlaylist**](VideoPlaylistsApi.md#addplaylist) | **POST** /api/v1/video-playlists | Create a video playlist |
| [**AddVideoPlaylistVideo**](VideoPlaylistsApi.md#addvideoplaylistvideo) | **POST** /api/v1/video-playlists/{playlistId}/videos | Add a video in a playlist |
| [**ApiV1AccountsNameVideoPlaylistsGet**](VideoPlaylistsApi.md#apiv1accountsnamevideoplaylistsget) | **GET** /api/v1/accounts/{name}/video-playlists | List playlists of an account |
| [**ApiV1UsersMeVideoPlaylistsVideosExistGet**](VideoPlaylistsApi.md#apiv1usersmevideoplaylistsvideosexistget) | **GET** /api/v1/users/me/video-playlists/videos-exist | Check video exists in my playlists |
| [**ApiV1VideoChannelsChannelHandleVideoPlaylistsGet**](VideoPlaylistsApi.md#apiv1videochannelschannelhandlevideoplaylistsget) | **GET** /api/v1/video-channels/{channelHandle}/video-playlists | List playlists of a channel |
| [**ApiV1VideoPlaylistsPlaylistIdDelete**](VideoPlaylistsApi.md#apiv1videoplaylistsplaylistiddelete) | **DELETE** /api/v1/video-playlists/{playlistId} | Delete a video playlist |
| [**ApiV1VideoPlaylistsPlaylistIdGet**](VideoPlaylistsApi.md#apiv1videoplaylistsplaylistidget) | **GET** /api/v1/video-playlists/{playlistId} | Get a video playlist |
| [**ApiV1VideoPlaylistsPlaylistIdPut**](VideoPlaylistsApi.md#apiv1videoplaylistsplaylistidput) | **PUT** /api/v1/video-playlists/{playlistId} | Update a video playlist |
| [**DelVideoPlaylistVideo**](VideoPlaylistsApi.md#delvideoplaylistvideo) | **DELETE** /api/v1/video-playlists/{playlistId}/videos/{playlistElementId} | Delete an element from a playlist |
| [**GetPlaylistPrivacyPolicies**](VideoPlaylistsApi.md#getplaylistprivacypolicies) | **GET** /api/v1/video-playlists/privacies | List available playlist privacy policies |
| [**GetPlaylists**](VideoPlaylistsApi.md#getplaylists) | **GET** /api/v1/video-playlists | List video playlists |
| [**GetVideoPlaylistVideos**](VideoPlaylistsApi.md#getvideoplaylistvideos) | **GET** /api/v1/video-playlists/{playlistId}/videos | List videos of a playlist |
| [**PutVideoPlaylistVideo**](VideoPlaylistsApi.md#putvideoplaylistvideo) | **PUT** /api/v1/video-playlists/{playlistId}/videos/{playlistElementId} | Update a playlist element |
| [**ReorderVideoPlaylist**](VideoPlaylistsApi.md#reordervideoplaylist) | **POST** /api/v1/video-playlists/{playlistId}/videos/reorder | Reorder a playlist |
| [**SearchPlaylists**](VideoPlaylistsApi.md#searchplaylists) | **GET** /api/v1/search/video-playlists | Search playlists |

<a id="addplaylist"></a>
# **AddPlaylist**
> AddPlaylist200Response AddPlaylist (string displayName, System.IO.Stream? thumbnailfile = null, VideoPlaylistPrivacySet? privacy = null, string? description = null, int? videoChannelId = null)

Create a video playlist

If the video playlist is set as public, `videoChannelId` is mandatory.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class AddPlaylistExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoPlaylistsApi(config);
            var displayName = "displayName_example";  // string | Video playlist display name
            var thumbnailfile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? | Video playlist thumbnail file (optional) 
            var privacy = new VideoPlaylistPrivacySet?(); // VideoPlaylistPrivacySet? |  (optional) 
            var description = "description_example";  // string? | Video playlist description (optional) 
            var videoChannelId = new int?(); // int? | Video channel in which the playlist will be published (optional) 

            try
            {
                // Create a video playlist
                AddPlaylist200Response result = apiInstance.AddPlaylist(displayName, thumbnailfile, privacy, description, videoChannelId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPlaylistsApi.AddPlaylist: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AddPlaylistWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a video playlist
    ApiResponse<AddPlaylist200Response> response = apiInstance.AddPlaylistWithHttpInfo(displayName, thumbnailfile, privacy, description, videoChannelId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPlaylistsApi.AddPlaylistWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **displayName** | **string** | Video playlist display name |  |
| **thumbnailfile** | **System.IO.Stream?****System.IO.Stream?** | Video playlist thumbnail file | [optional]  |
| **privacy** | [**VideoPlaylistPrivacySet?**](VideoPlaylistPrivacySet?.md) |  | [optional]  |
| **description** | **string?** | Video playlist description | [optional]  |
| **videoChannelId** | [**int?**](int?.md) | Video channel in which the playlist will be published | [optional]  |

### Return type

[**AddPlaylist200Response**](AddPlaylist200Response.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

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

            var apiInstance = new VideoPlaylistsApi(config);
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
                Debug.Print("Exception when calling VideoPlaylistsApi.AddVideoPlaylistVideo: " + e.Message);
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
    Debug.Print("Exception when calling VideoPlaylistsApi.AddVideoPlaylistVideoWithHttpInfo: " + e.Message);
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

<a id="apiv1accountsnamevideoplaylistsget"></a>
# **ApiV1AccountsNameVideoPlaylistsGet**
> ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response ApiV1AccountsNameVideoPlaylistsGet (string name, int? start = null, int? count = null, string? sort = null, string? search = null, VideoPlaylistTypeSet? playlistType = null)

List playlists of an account

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1AccountsNameVideoPlaylistsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoPlaylistsApi(config);
            var name = chocobozzz | chocobozzz@example.org;  // string | The username or handle of the account
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 
            var search = "search_example";  // string? | Plain text search, applied to various parts of the model depending on endpoint (optional) 
            var playlistType = new VideoPlaylistTypeSet?(); // VideoPlaylistTypeSet? |  (optional) 

            try
            {
                // List playlists of an account
                ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response result = apiInstance.ApiV1AccountsNameVideoPlaylistsGet(name, start, count, sort, search, playlistType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPlaylistsApi.ApiV1AccountsNameVideoPlaylistsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AccountsNameVideoPlaylistsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List playlists of an account
    ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> response = apiInstance.ApiV1AccountsNameVideoPlaylistsGetWithHttpInfo(name, start, count, sort, search, playlistType);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPlaylistsApi.ApiV1AccountsNameVideoPlaylistsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string** | The username or handle of the account |  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort column | [optional]  |
| **search** | **string?** | Plain text search, applied to various parts of the model depending on endpoint | [optional]  |
| **playlistType** | [**VideoPlaylistTypeSet?**](VideoPlaylistTypeSet?.md) |  | [optional]  |

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1usersmevideoplaylistsvideosexistget"></a>
# **ApiV1UsersMeVideoPlaylistsVideosExistGet**
> ApiV1UsersMeVideoPlaylistsVideosExistGet200Response ApiV1UsersMeVideoPlaylistsVideosExistGet (List<int> videoIds)

Check video exists in my playlists

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeVideoPlaylistsVideosExistGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoPlaylistsApi(config);
            var videoIds = new List<int>(); // List<int> | The video ids to check

            try
            {
                // Check video exists in my playlists
                ApiV1UsersMeVideoPlaylistsVideosExistGet200Response result = apiInstance.ApiV1UsersMeVideoPlaylistsVideosExistGet(videoIds);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPlaylistsApi.ApiV1UsersMeVideoPlaylistsVideosExistGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeVideoPlaylistsVideosExistGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Check video exists in my playlists
    ApiResponse<ApiV1UsersMeVideoPlaylistsVideosExistGet200Response> response = apiInstance.ApiV1UsersMeVideoPlaylistsVideosExistGetWithHttpInfo(videoIds);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPlaylistsApi.ApiV1UsersMeVideoPlaylistsVideosExistGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **videoIds** | [**List&lt;int&gt;**](int.md) | The video ids to check |  |

### Return type

[**ApiV1UsersMeVideoPlaylistsVideosExistGet200Response**](ApiV1UsersMeVideoPlaylistsVideosExistGet200Response.md)

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

<a id="apiv1videochannelschannelhandlevideoplaylistsget"></a>
# **ApiV1VideoChannelsChannelHandleVideoPlaylistsGet**
> ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response ApiV1VideoChannelsChannelHandleVideoPlaylistsGet (string channelHandle, int? start = null, int? count = null, string? sort = null, VideoPlaylistTypeSet? playlistType = null)

List playlists of a channel

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideoChannelsChannelHandleVideoPlaylistsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoPlaylistsApi(config);
            var channelHandle = my_username | my_username@example.com;  // string | The video channel handle
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 
            var playlistType = new VideoPlaylistTypeSet?(); // VideoPlaylistTypeSet? |  (optional) 

            try
            {
                // List playlists of a channel
                ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response result = apiInstance.ApiV1VideoChannelsChannelHandleVideoPlaylistsGet(channelHandle, start, count, sort, playlistType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPlaylistsApi.ApiV1VideoChannelsChannelHandleVideoPlaylistsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideoChannelsChannelHandleVideoPlaylistsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List playlists of a channel
    ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> response = apiInstance.ApiV1VideoChannelsChannelHandleVideoPlaylistsGetWithHttpInfo(channelHandle, start, count, sort, playlistType);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPlaylistsApi.ApiV1VideoChannelsChannelHandleVideoPlaylistsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channelHandle** | **string** | The video channel handle |  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort column | [optional]  |
| **playlistType** | [**VideoPlaylistTypeSet?**](VideoPlaylistTypeSet?.md) |  | [optional]  |

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1videoplaylistsplaylistiddelete"></a>
# **ApiV1VideoPlaylistsPlaylistIdDelete**
> void ApiV1VideoPlaylistsPlaylistIdDelete (int playlistId)

Delete a video playlist

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideoPlaylistsPlaylistIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoPlaylistsApi(config);
            var playlistId = 56;  // int | Playlist id

            try
            {
                // Delete a video playlist
                apiInstance.ApiV1VideoPlaylistsPlaylistIdDelete(playlistId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPlaylistsApi.ApiV1VideoPlaylistsPlaylistIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideoPlaylistsPlaylistIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a video playlist
    apiInstance.ApiV1VideoPlaylistsPlaylistIdDeleteWithHttpInfo(playlistId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPlaylistsApi.ApiV1VideoPlaylistsPlaylistIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **playlistId** | **int** | Playlist id |  |

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

<a id="apiv1videoplaylistsplaylistidget"></a>
# **ApiV1VideoPlaylistsPlaylistIdGet**
> VideoPlaylist ApiV1VideoPlaylistsPlaylistIdGet (int playlistId)

Get a video playlist

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideoPlaylistsPlaylistIdGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoPlaylistsApi(config);
            var playlistId = 56;  // int | Playlist id

            try
            {
                // Get a video playlist
                VideoPlaylist result = apiInstance.ApiV1VideoPlaylistsPlaylistIdGet(playlistId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPlaylistsApi.ApiV1VideoPlaylistsPlaylistIdGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideoPlaylistsPlaylistIdGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a video playlist
    ApiResponse<VideoPlaylist> response = apiInstance.ApiV1VideoPlaylistsPlaylistIdGetWithHttpInfo(playlistId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPlaylistsApi.ApiV1VideoPlaylistsPlaylistIdGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **playlistId** | **int** | Playlist id |  |

### Return type

[**VideoPlaylist**](VideoPlaylist.md)

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

<a id="apiv1videoplaylistsplaylistidput"></a>
# **ApiV1VideoPlaylistsPlaylistIdPut**
> void ApiV1VideoPlaylistsPlaylistIdPut (int playlistId, string? displayName = null, System.IO.Stream? thumbnailfile = null, VideoPlaylistPrivacySet? privacy = null, string? description = null, int? videoChannelId = null)

Update a video playlist

If the video playlist is set as public, the playlist must have a assigned channel.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideoPlaylistsPlaylistIdPutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoPlaylistsApi(config);
            var playlistId = 56;  // int | Playlist id
            var displayName = "displayName_example";  // string? | Video playlist display name (optional) 
            var thumbnailfile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? | Video playlist thumbnail file (optional) 
            var privacy = new VideoPlaylistPrivacySet?(); // VideoPlaylistPrivacySet? |  (optional) 
            var description = "description_example";  // string? | Video playlist description (optional) 
            var videoChannelId = new int?(); // int? | Video channel in which the playlist will be published (optional) 

            try
            {
                // Update a video playlist
                apiInstance.ApiV1VideoPlaylistsPlaylistIdPut(playlistId, displayName, thumbnailfile, privacy, description, videoChannelId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPlaylistsApi.ApiV1VideoPlaylistsPlaylistIdPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideoPlaylistsPlaylistIdPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update a video playlist
    apiInstance.ApiV1VideoPlaylistsPlaylistIdPutWithHttpInfo(playlistId, displayName, thumbnailfile, privacy, description, videoChannelId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPlaylistsApi.ApiV1VideoPlaylistsPlaylistIdPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **playlistId** | **int** | Playlist id |  |
| **displayName** | **string?** | Video playlist display name | [optional]  |
| **thumbnailfile** | **System.IO.Stream?****System.IO.Stream?** | Video playlist thumbnail file | [optional]  |
| **privacy** | [**VideoPlaylistPrivacySet?**](VideoPlaylistPrivacySet?.md) |  | [optional]  |
| **description** | **string?** | Video playlist description | [optional]  |
| **videoChannelId** | [**int?**](int?.md) | Video channel in which the playlist will be published | [optional]  |

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

<a id="delvideoplaylistvideo"></a>
# **DelVideoPlaylistVideo**
> void DelVideoPlaylistVideo (int playlistId, int playlistElementId)

Delete an element from a playlist

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class DelVideoPlaylistVideoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoPlaylistsApi(config);
            var playlistId = 56;  // int | Playlist id
            var playlistElementId = 56;  // int | Playlist element id

            try
            {
                // Delete an element from a playlist
                apiInstance.DelVideoPlaylistVideo(playlistId, playlistElementId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPlaylistsApi.DelVideoPlaylistVideo: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DelVideoPlaylistVideoWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete an element from a playlist
    apiInstance.DelVideoPlaylistVideoWithHttpInfo(playlistId, playlistElementId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPlaylistsApi.DelVideoPlaylistVideoWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **playlistId** | **int** | Playlist id |  |
| **playlistElementId** | **int** | Playlist element id |  |

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

<a id="getplaylistprivacypolicies"></a>
# **GetPlaylistPrivacyPolicies**
> List&lt;string&gt; GetPlaylistPrivacyPolicies ()

List available playlist privacy policies

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetPlaylistPrivacyPoliciesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoPlaylistsApi(config);

            try
            {
                // List available playlist privacy policies
                List<string> result = apiInstance.GetPlaylistPrivacyPolicies();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPlaylistsApi.GetPlaylistPrivacyPolicies: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetPlaylistPrivacyPoliciesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List available playlist privacy policies
    ApiResponse<List<string>> response = apiInstance.GetPlaylistPrivacyPoliciesWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPlaylistsApi.GetPlaylistPrivacyPoliciesWithHttpInfo: " + e.Message);
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

<a id="getplaylists"></a>
# **GetPlaylists**
> ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response GetPlaylists (int? start = null, int? count = null, string? sort = null, VideoPlaylistTypeSet? playlistType = null)

List video playlists

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetPlaylistsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoPlaylistsApi(config);
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 
            var playlistType = new VideoPlaylistTypeSet?(); // VideoPlaylistTypeSet? |  (optional) 

            try
            {
                // List video playlists
                ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response result = apiInstance.GetPlaylists(start, count, sort, playlistType);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPlaylistsApi.GetPlaylists: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetPlaylistsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List video playlists
    ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> response = apiInstance.GetPlaylistsWithHttpInfo(start, count, sort, playlistType);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPlaylistsApi.GetPlaylistsWithHttpInfo: " + e.Message);
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
| **playlistType** | [**VideoPlaylistTypeSet?**](VideoPlaylistTypeSet?.md) |  | [optional]  |

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
            var apiInstance = new VideoPlaylistsApi(config);
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
                Debug.Print("Exception when calling VideoPlaylistsApi.GetVideoPlaylistVideos: " + e.Message);
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
    Debug.Print("Exception when calling VideoPlaylistsApi.GetVideoPlaylistVideosWithHttpInfo: " + e.Message);
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

<a id="putvideoplaylistvideo"></a>
# **PutVideoPlaylistVideo**
> void PutVideoPlaylistVideo (int playlistId, int playlistElementId, PutVideoPlaylistVideoRequest? putVideoPlaylistVideoRequest = null)

Update a playlist element

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class PutVideoPlaylistVideoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoPlaylistsApi(config);
            var playlistId = 56;  // int | Playlist id
            var playlistElementId = 56;  // int | Playlist element id
            var putVideoPlaylistVideoRequest = new PutVideoPlaylistVideoRequest?(); // PutVideoPlaylistVideoRequest? |  (optional) 

            try
            {
                // Update a playlist element
                apiInstance.PutVideoPlaylistVideo(playlistId, playlistElementId, putVideoPlaylistVideoRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPlaylistsApi.PutVideoPlaylistVideo: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PutVideoPlaylistVideoWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update a playlist element
    apiInstance.PutVideoPlaylistVideoWithHttpInfo(playlistId, playlistElementId, putVideoPlaylistVideoRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPlaylistsApi.PutVideoPlaylistVideoWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **playlistId** | **int** | Playlist id |  |
| **playlistElementId** | **int** | Playlist element id |  |
| **putVideoPlaylistVideoRequest** | [**PutVideoPlaylistVideoRequest?**](PutVideoPlaylistVideoRequest?.md) |  | [optional]  |

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

<a id="reordervideoplaylist"></a>
# **ReorderVideoPlaylist**
> void ReorderVideoPlaylist (int playlistId, ReorderVideoPlaylistRequest? reorderVideoPlaylistRequest = null)

Reorder a playlist

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ReorderVideoPlaylistExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoPlaylistsApi(config);
            var playlistId = 56;  // int | Playlist id
            var reorderVideoPlaylistRequest = new ReorderVideoPlaylistRequest?(); // ReorderVideoPlaylistRequest? |  (optional) 

            try
            {
                // Reorder a playlist
                apiInstance.ReorderVideoPlaylist(playlistId, reorderVideoPlaylistRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoPlaylistsApi.ReorderVideoPlaylist: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ReorderVideoPlaylistWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Reorder a playlist
    apiInstance.ReorderVideoPlaylistWithHttpInfo(playlistId, reorderVideoPlaylistRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoPlaylistsApi.ReorderVideoPlaylistWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **playlistId** | **int** | Playlist id |  |
| **reorderVideoPlaylistRequest** | [**ReorderVideoPlaylistRequest?**](ReorderVideoPlaylistRequest?.md) |  | [optional]  |

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
            var apiInstance = new VideoPlaylistsApi(config);
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
                Debug.Print("Exception when calling VideoPlaylistsApi.SearchPlaylists: " + e.Message);
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
    Debug.Print("Exception when calling VideoPlaylistsApi.SearchPlaylistsWithHttpInfo: " + e.Message);
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

