# PeerTubeApiClient.Api.VideoChannelsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AddVideoChannel**](VideoChannelsApi.md#addvideochannel) | **POST** /api/v1/video-channels | Create a video channel |
| [**ApiV1AccountsNameVideoChannelSyncsGet**](VideoChannelsApi.md#apiv1accountsnamevideochannelsyncsget) | **GET** /api/v1/accounts/{name}/video-channel-syncs | List the synchronizations of video channels of an account |
| [**ApiV1AccountsNameVideoChannelsGet**](VideoChannelsApi.md#apiv1accountsnamevideochannelsget) | **GET** /api/v1/accounts/{name}/video-channels | List video channels of an account |
| [**ApiV1VideoChannelsChannelHandleAvatarDelete**](VideoChannelsApi.md#apiv1videochannelschannelhandleavatardelete) | **DELETE** /api/v1/video-channels/{channelHandle}/avatar | Delete channel avatar |
| [**ApiV1VideoChannelsChannelHandleAvatarPickPost**](VideoChannelsApi.md#apiv1videochannelschannelhandleavatarpickpost) | **POST** /api/v1/video-channels/{channelHandle}/avatar/pick | Update channel avatar |
| [**ApiV1VideoChannelsChannelHandleBannerDelete**](VideoChannelsApi.md#apiv1videochannelschannelhandlebannerdelete) | **DELETE** /api/v1/video-channels/{channelHandle}/banner | Delete channel banner |
| [**ApiV1VideoChannelsChannelHandleBannerPickPost**](VideoChannelsApi.md#apiv1videochannelschannelhandlebannerpickpost) | **POST** /api/v1/video-channels/{channelHandle}/banner/pick | Update channel banner |
| [**ApiV1VideoChannelsChannelHandleImportVideosPost**](VideoChannelsApi.md#apiv1videochannelschannelhandleimportvideospost) | **POST** /api/v1/video-channels/{channelHandle}/import-videos | Import videos in channel |
| [**ApiV1VideoChannelsChannelHandleVideoPlaylistsGet**](VideoChannelsApi.md#apiv1videochannelschannelhandlevideoplaylistsget) | **GET** /api/v1/video-channels/{channelHandle}/video-playlists | List playlists of a channel |
| [**DelVideoChannel**](VideoChannelsApi.md#delvideochannel) | **DELETE** /api/v1/video-channels/{channelHandle} | Delete a video channel |
| [**GetVideoChannel**](VideoChannelsApi.md#getvideochannel) | **GET** /api/v1/video-channels/{channelHandle} | Get a video channel |
| [**GetVideoChannelFollowers**](VideoChannelsApi.md#getvideochannelfollowers) | **GET** /api/v1/video-channels/{channelHandle}/followers | List followers of a video channel |
| [**GetVideoChannelVideos**](VideoChannelsApi.md#getvideochannelvideos) | **GET** /api/v1/video-channels/{channelHandle}/videos | List videos of a video channel |
| [**GetVideoChannels**](VideoChannelsApi.md#getvideochannels) | **GET** /api/v1/video-channels | List video channels |
| [**PutVideoChannel**](VideoChannelsApi.md#putvideochannel) | **PUT** /api/v1/video-channels/{channelHandle} | Update a video channel |
| [**SearchChannels**](VideoChannelsApi.md#searchchannels) | **GET** /api/v1/search/video-channels | Search channels |

<a id="addvideochannel"></a>
# **AddVideoChannel**
> AddVideoChannel200Response AddVideoChannel (VideoChannelCreate? videoChannelCreate = null)

Create a video channel

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class AddVideoChannelExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoChannelsApi(config);
            var videoChannelCreate = new VideoChannelCreate?(); // VideoChannelCreate? |  (optional) 

            try
            {
                // Create a video channel
                AddVideoChannel200Response result = apiInstance.AddVideoChannel(videoChannelCreate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChannelsApi.AddVideoChannel: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AddVideoChannelWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a video channel
    ApiResponse<AddVideoChannel200Response> response = apiInstance.AddVideoChannelWithHttpInfo(videoChannelCreate);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChannelsApi.AddVideoChannelWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **videoChannelCreate** | [**VideoChannelCreate?**](VideoChannelCreate?.md) |  | [optional]  |

### Return type

[**AddVideoChannel200Response**](AddVideoChannel200Response.md)

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

<a id="apiv1accountsnamevideochannelsyncsget"></a>
# **ApiV1AccountsNameVideoChannelSyncsGet**
> VideoChannelSyncList ApiV1AccountsNameVideoChannelSyncsGet (string name, int? start = null, int? count = null, string? sort = null)

List the synchronizations of video channels of an account

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1AccountsNameVideoChannelSyncsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoChannelsApi(config);
            var name = chocobozzz | chocobozzz@example.org;  // string | The username or handle of the account
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List the synchronizations of video channels of an account
                VideoChannelSyncList result = apiInstance.ApiV1AccountsNameVideoChannelSyncsGet(name, start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChannelsApi.ApiV1AccountsNameVideoChannelSyncsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AccountsNameVideoChannelSyncsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List the synchronizations of video channels of an account
    ApiResponse<VideoChannelSyncList> response = apiInstance.ApiV1AccountsNameVideoChannelSyncsGetWithHttpInfo(name, start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChannelsApi.ApiV1AccountsNameVideoChannelSyncsGetWithHttpInfo: " + e.Message);
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

### Return type

[**VideoChannelSyncList**](VideoChannelSyncList.md)

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

<a id="apiv1accountsnamevideochannelsget"></a>
# **ApiV1AccountsNameVideoChannelsGet**
> VideoChannelList ApiV1AccountsNameVideoChannelsGet (string name, bool? withStats = null, int? start = null, int? count = null, string? sort = null)

List video channels of an account

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1AccountsNameVideoChannelsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoChannelsApi(config);
            var name = chocobozzz | chocobozzz@example.org;  // string | The username or handle of the account
            var withStats = true;  // bool? | include daily view statistics for the last 30 days and total views (only if authentified as the account user) (optional) 
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List video channels of an account
                VideoChannelList result = apiInstance.ApiV1AccountsNameVideoChannelsGet(name, withStats, start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChannelsApi.ApiV1AccountsNameVideoChannelsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AccountsNameVideoChannelsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List video channels of an account
    ApiResponse<VideoChannelList> response = apiInstance.ApiV1AccountsNameVideoChannelsGetWithHttpInfo(name, withStats, start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChannelsApi.ApiV1AccountsNameVideoChannelsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string** | The username or handle of the account |  |
| **withStats** | **bool?** | include daily view statistics for the last 30 days and total views (only if authentified as the account user) | [optional]  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort column | [optional]  |

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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1videochannelschannelhandleavatardelete"></a>
# **ApiV1VideoChannelsChannelHandleAvatarDelete**
> void ApiV1VideoChannelsChannelHandleAvatarDelete (string channelHandle)

Delete channel avatar

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideoChannelsChannelHandleAvatarDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoChannelsApi(config);
            var channelHandle = my_username | my_username@example.com;  // string | The video channel handle

            try
            {
                // Delete channel avatar
                apiInstance.ApiV1VideoChannelsChannelHandleAvatarDelete(channelHandle);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChannelsApi.ApiV1VideoChannelsChannelHandleAvatarDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideoChannelsChannelHandleAvatarDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete channel avatar
    apiInstance.ApiV1VideoChannelsChannelHandleAvatarDeleteWithHttpInfo(channelHandle);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChannelsApi.ApiV1VideoChannelsChannelHandleAvatarDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channelHandle** | **string** | The video channel handle |  |

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

<a id="apiv1videochannelschannelhandleavatarpickpost"></a>
# **ApiV1VideoChannelsChannelHandleAvatarPickPost**
> ApiV1UsersMeAvatarPickPost200Response ApiV1VideoChannelsChannelHandleAvatarPickPost (string channelHandle, System.IO.Stream? avatarfile = null)

Update channel avatar

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideoChannelsChannelHandleAvatarPickPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoChannelsApi(config);
            var channelHandle = my_username | my_username@example.com;  // string | The video channel handle
            var avatarfile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? | The file to upload. (optional) 

            try
            {
                // Update channel avatar
                ApiV1UsersMeAvatarPickPost200Response result = apiInstance.ApiV1VideoChannelsChannelHandleAvatarPickPost(channelHandle, avatarfile);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChannelsApi.ApiV1VideoChannelsChannelHandleAvatarPickPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideoChannelsChannelHandleAvatarPickPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update channel avatar
    ApiResponse<ApiV1UsersMeAvatarPickPost200Response> response = apiInstance.ApiV1VideoChannelsChannelHandleAvatarPickPostWithHttpInfo(channelHandle, avatarfile);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChannelsApi.ApiV1VideoChannelsChannelHandleAvatarPickPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channelHandle** | **string** | The video channel handle |  |
| **avatarfile** | **System.IO.Stream?****System.IO.Stream?** | The file to upload. | [optional]  |

### Return type

[**ApiV1UsersMeAvatarPickPost200Response**](ApiV1UsersMeAvatarPickPost200Response.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **413** | image file too large |  * X-File-Maximum-Size - Maximum file size for the banner <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1videochannelschannelhandlebannerdelete"></a>
# **ApiV1VideoChannelsChannelHandleBannerDelete**
> void ApiV1VideoChannelsChannelHandleBannerDelete (string channelHandle)

Delete channel banner

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideoChannelsChannelHandleBannerDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoChannelsApi(config);
            var channelHandle = my_username | my_username@example.com;  // string | The video channel handle

            try
            {
                // Delete channel banner
                apiInstance.ApiV1VideoChannelsChannelHandleBannerDelete(channelHandle);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChannelsApi.ApiV1VideoChannelsChannelHandleBannerDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideoChannelsChannelHandleBannerDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete channel banner
    apiInstance.ApiV1VideoChannelsChannelHandleBannerDeleteWithHttpInfo(channelHandle);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChannelsApi.ApiV1VideoChannelsChannelHandleBannerDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channelHandle** | **string** | The video channel handle |  |

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

<a id="apiv1videochannelschannelhandlebannerpickpost"></a>
# **ApiV1VideoChannelsChannelHandleBannerPickPost**
> ApiV1VideoChannelsChannelHandleBannerPickPost200Response ApiV1VideoChannelsChannelHandleBannerPickPost (string channelHandle, System.IO.Stream? bannerfile = null)

Update channel banner

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideoChannelsChannelHandleBannerPickPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoChannelsApi(config);
            var channelHandle = my_username | my_username@example.com;  // string | The video channel handle
            var bannerfile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? | The file to upload. (optional) 

            try
            {
                // Update channel banner
                ApiV1VideoChannelsChannelHandleBannerPickPost200Response result = apiInstance.ApiV1VideoChannelsChannelHandleBannerPickPost(channelHandle, bannerfile);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChannelsApi.ApiV1VideoChannelsChannelHandleBannerPickPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideoChannelsChannelHandleBannerPickPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update channel banner
    ApiResponse<ApiV1VideoChannelsChannelHandleBannerPickPost200Response> response = apiInstance.ApiV1VideoChannelsChannelHandleBannerPickPostWithHttpInfo(channelHandle, bannerfile);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChannelsApi.ApiV1VideoChannelsChannelHandleBannerPickPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channelHandle** | **string** | The video channel handle |  |
| **bannerfile** | **System.IO.Stream?****System.IO.Stream?** | The file to upload. | [optional]  |

### Return type

[**ApiV1VideoChannelsChannelHandleBannerPickPost200Response**](ApiV1VideoChannelsChannelHandleBannerPickPost200Response.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **413** | image file too large |  * X-File-Maximum-Size - Maximum file size for the banner <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1videochannelschannelhandleimportvideospost"></a>
# **ApiV1VideoChannelsChannelHandleImportVideosPost**
> void ApiV1VideoChannelsChannelHandleImportVideosPost (string channelHandle, ImportVideosInChannelCreate? importVideosInChannelCreate = null)

Import videos in channel

Import a remote channel/playlist videos into a channel

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideoChannelsChannelHandleImportVideosPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoChannelsApi(config);
            var channelHandle = my_username | my_username@example.com;  // string | The video channel handle
            var importVideosInChannelCreate = new ImportVideosInChannelCreate?(); // ImportVideosInChannelCreate? |  (optional) 

            try
            {
                // Import videos in channel
                apiInstance.ApiV1VideoChannelsChannelHandleImportVideosPost(channelHandle, importVideosInChannelCreate);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChannelsApi.ApiV1VideoChannelsChannelHandleImportVideosPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideoChannelsChannelHandleImportVideosPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Import videos in channel
    apiInstance.ApiV1VideoChannelsChannelHandleImportVideosPostWithHttpInfo(channelHandle, importVideosInChannelCreate);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChannelsApi.ApiV1VideoChannelsChannelHandleImportVideosPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channelHandle** | **string** | The video channel handle |  |
| **importVideosInChannelCreate** | [**ImportVideosInChannelCreate?**](ImportVideosInChannelCreate?.md) |  | [optional]  |

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
            var apiInstance = new VideoChannelsApi(config);
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
                Debug.Print("Exception when calling VideoChannelsApi.ApiV1VideoChannelsChannelHandleVideoPlaylistsGet: " + e.Message);
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
    Debug.Print("Exception when calling VideoChannelsApi.ApiV1VideoChannelsChannelHandleVideoPlaylistsGetWithHttpInfo: " + e.Message);
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

<a id="delvideochannel"></a>
# **DelVideoChannel**
> void DelVideoChannel (string channelHandle)

Delete a video channel

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class DelVideoChannelExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoChannelsApi(config);
            var channelHandle = my_username | my_username@example.com;  // string | The video channel handle

            try
            {
                // Delete a video channel
                apiInstance.DelVideoChannel(channelHandle);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChannelsApi.DelVideoChannel: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DelVideoChannelWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a video channel
    apiInstance.DelVideoChannelWithHttpInfo(channelHandle);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChannelsApi.DelVideoChannelWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channelHandle** | **string** | The video channel handle |  |

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

<a id="getvideochannel"></a>
# **GetVideoChannel**
> VideoChannel GetVideoChannel (string channelHandle)

Get a video channel

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetVideoChannelExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoChannelsApi(config);
            var channelHandle = my_username | my_username@example.com;  // string | The video channel handle

            try
            {
                // Get a video channel
                VideoChannel result = apiInstance.GetVideoChannel(channelHandle);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChannelsApi.GetVideoChannel: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetVideoChannelWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a video channel
    ApiResponse<VideoChannel> response = apiInstance.GetVideoChannelWithHttpInfo(channelHandle);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChannelsApi.GetVideoChannelWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channelHandle** | **string** | The video channel handle |  |

### Return type

[**VideoChannel**](VideoChannel.md)

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

<a id="getvideochannelfollowers"></a>
# **GetVideoChannelFollowers**
> GetAccountFollowers200Response GetVideoChannelFollowers (string channelHandle, int? start = null, int? count = null, string? sort = null, string? search = null)

List followers of a video channel

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetVideoChannelFollowersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoChannelsApi(config);
            var channelHandle = my_username | my_username@example.com;  // string | The video channel handle
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = "createdAt";  // string? | Sort followers by criteria (optional) 
            var search = "search_example";  // string? | Plain text search, applied to various parts of the model depending on endpoint (optional) 

            try
            {
                // List followers of a video channel
                GetAccountFollowers200Response result = apiInstance.GetVideoChannelFollowers(channelHandle, start, count, sort, search);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChannelsApi.GetVideoChannelFollowers: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetVideoChannelFollowersWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List followers of a video channel
    ApiResponse<GetAccountFollowers200Response> response = apiInstance.GetVideoChannelFollowersWithHttpInfo(channelHandle, start, count, sort, search);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChannelsApi.GetVideoChannelFollowersWithHttpInfo: " + e.Message);
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
| **sort** | **string?** | Sort followers by criteria | [optional]  |
| **search** | **string?** | Plain text search, applied to various parts of the model depending on endpoint | [optional]  |

### Return type

[**GetAccountFollowers200Response**](GetAccountFollowers200Response.md)

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
            var apiInstance = new VideoChannelsApi(config);
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
                Debug.Print("Exception when calling VideoChannelsApi.GetVideoChannelVideos: " + e.Message);
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
    Debug.Print("Exception when calling VideoChannelsApi.GetVideoChannelVideosWithHttpInfo: " + e.Message);
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

<a id="getvideochannels"></a>
# **GetVideoChannels**
> VideoChannelList GetVideoChannels (int? start = null, int? count = null, string? sort = null)

List video channels

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetVideoChannelsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoChannelsApi(config);
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List video channels
                VideoChannelList result = apiInstance.GetVideoChannels(start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChannelsApi.GetVideoChannels: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetVideoChannelsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List video channels
    ApiResponse<VideoChannelList> response = apiInstance.GetVideoChannelsWithHttpInfo(start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChannelsApi.GetVideoChannelsWithHttpInfo: " + e.Message);
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

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="putvideochannel"></a>
# **PutVideoChannel**
> void PutVideoChannel (string channelHandle, VideoChannelUpdate? videoChannelUpdate = null)

Update a video channel

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class PutVideoChannelExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoChannelsApi(config);
            var channelHandle = my_username | my_username@example.com;  // string | The video channel handle
            var videoChannelUpdate = new VideoChannelUpdate?(); // VideoChannelUpdate? |  (optional) 

            try
            {
                // Update a video channel
                apiInstance.PutVideoChannel(channelHandle, videoChannelUpdate);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoChannelsApi.PutVideoChannel: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PutVideoChannelWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update a video channel
    apiInstance.PutVideoChannelWithHttpInfo(channelHandle, videoChannelUpdate);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoChannelsApi.PutVideoChannelWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channelHandle** | **string** | The video channel handle |  |
| **videoChannelUpdate** | [**VideoChannelUpdate?**](VideoChannelUpdate?.md) |  | [optional]  |

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
            var apiInstance = new VideoChannelsApi(config);
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
                Debug.Print("Exception when calling VideoChannelsApi.SearchChannels: " + e.Message);
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
    Debug.Print("Exception when calling VideoChannelsApi.SearchChannelsWithHttpInfo: " + e.Message);
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

