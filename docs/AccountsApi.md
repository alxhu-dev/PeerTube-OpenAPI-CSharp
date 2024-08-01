# PeerTubeApiClient.Api.AccountsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1AccountsNameRatingsGet**](AccountsApi.md#apiv1accountsnameratingsget) | **GET** /api/v1/accounts/{name}/ratings | List ratings of an account |
| [**ApiV1AccountsNameVideoChannelSyncsGet**](AccountsApi.md#apiv1accountsnamevideochannelsyncsget) | **GET** /api/v1/accounts/{name}/video-channel-syncs | List the synchronizations of video channels of an account |
| [**ApiV1AccountsNameVideoChannelsGet**](AccountsApi.md#apiv1accountsnamevideochannelsget) | **GET** /api/v1/accounts/{name}/video-channels | List video channels of an account |
| [**ApiV1AccountsNameVideoPlaylistsGet**](AccountsApi.md#apiv1accountsnamevideoplaylistsget) | **GET** /api/v1/accounts/{name}/video-playlists | List playlists of an account |
| [**GetAccount**](AccountsApi.md#getaccount) | **GET** /api/v1/accounts/{name} | Get an account |
| [**GetAccountFollowers**](AccountsApi.md#getaccountfollowers) | **GET** /api/v1/accounts/{name}/followers | List followers of an account |
| [**GetAccountVideos**](AccountsApi.md#getaccountvideos) | **GET** /api/v1/accounts/{name}/videos | List videos of an account |
| [**GetAccounts**](AccountsApi.md#getaccounts) | **GET** /api/v1/accounts | List accounts |

<a id="apiv1accountsnameratingsget"></a>
# **ApiV1AccountsNameRatingsGet**
> List&lt;VideoRating&gt; ApiV1AccountsNameRatingsGet (string name, int? start = null, int? count = null, string? sort = null, string? rating = null)

List ratings of an account

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1AccountsNameRatingsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AccountsApi(config);
            var name = chocobozzz | chocobozzz@example.org;  // string | The username or handle of the account
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 
            var rating = "like";  // string? | Optionally filter which ratings to retrieve (optional) 

            try
            {
                // List ratings of an account
                List<VideoRating> result = apiInstance.ApiV1AccountsNameRatingsGet(name, start, count, sort, rating);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountsApi.ApiV1AccountsNameRatingsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AccountsNameRatingsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List ratings of an account
    ApiResponse<List<VideoRating>> response = apiInstance.ApiV1AccountsNameRatingsGetWithHttpInfo(name, start, count, sort, rating);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountsApi.ApiV1AccountsNameRatingsGetWithHttpInfo: " + e.Message);
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
| **rating** | **string?** | Optionally filter which ratings to retrieve | [optional]  |

### Return type

[**List&lt;VideoRating&gt;**](VideoRating.md)

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
            var apiInstance = new AccountsApi(config);
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
                Debug.Print("Exception when calling AccountsApi.ApiV1AccountsNameVideoChannelSyncsGet: " + e.Message);
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
    Debug.Print("Exception when calling AccountsApi.ApiV1AccountsNameVideoChannelSyncsGetWithHttpInfo: " + e.Message);
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
            var apiInstance = new AccountsApi(config);
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
                Debug.Print("Exception when calling AccountsApi.ApiV1AccountsNameVideoChannelsGet: " + e.Message);
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
    Debug.Print("Exception when calling AccountsApi.ApiV1AccountsNameVideoChannelsGetWithHttpInfo: " + e.Message);
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
            var apiInstance = new AccountsApi(config);
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
                Debug.Print("Exception when calling AccountsApi.ApiV1AccountsNameVideoPlaylistsGet: " + e.Message);
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
    Debug.Print("Exception when calling AccountsApi.ApiV1AccountsNameVideoPlaylistsGetWithHttpInfo: " + e.Message);
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

<a id="getaccount"></a>
# **GetAccount**
> Account GetAccount (string name)

Get an account

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetAccountExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new AccountsApi(config);
            var name = chocobozzz | chocobozzz@example.org;  // string | The username or handle of the account

            try
            {
                // Get an account
                Account result = apiInstance.GetAccount(name);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountsApi.GetAccount: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAccountWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get an account
    ApiResponse<Account> response = apiInstance.GetAccountWithHttpInfo(name);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountsApi.GetAccountWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string** | The username or handle of the account |  |

### Return type

[**Account**](Account.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **404** | account not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getaccountfollowers"></a>
# **GetAccountFollowers**
> GetAccountFollowers200Response GetAccountFollowers (string name, int? start = null, int? count = null, string? sort = null, string? search = null)

List followers of an account

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetAccountFollowersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AccountsApi(config);
            var name = chocobozzz | chocobozzz@example.org;  // string | The username or handle of the account
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = "createdAt";  // string? | Sort followers by criteria (optional) 
            var search = "search_example";  // string? | Plain text search, applied to various parts of the model depending on endpoint (optional) 

            try
            {
                // List followers of an account
                GetAccountFollowers200Response result = apiInstance.GetAccountFollowers(name, start, count, sort, search);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountsApi.GetAccountFollowers: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAccountFollowersWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List followers of an account
    ApiResponse<GetAccountFollowers200Response> response = apiInstance.GetAccountFollowersWithHttpInfo(name, start, count, sort, search);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountsApi.GetAccountFollowersWithHttpInfo: " + e.Message);
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
            var apiInstance = new AccountsApi(config);
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
                Debug.Print("Exception when calling AccountsApi.GetAccountVideos: " + e.Message);
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
    Debug.Print("Exception when calling AccountsApi.GetAccountVideosWithHttpInfo: " + e.Message);
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

<a id="getaccounts"></a>
# **GetAccounts**
> GetAccounts200Response GetAccounts (int? start = null, int? count = null, string? sort = null)

List accounts

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetAccountsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new AccountsApi(config);
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List accounts
                GetAccounts200Response result = apiInstance.GetAccounts(start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountsApi.GetAccounts: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAccountsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List accounts
    ApiResponse<GetAccounts200Response> response = apiInstance.GetAccountsWithHttpInfo(start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountsApi.GetAccountsWithHttpInfo: " + e.Message);
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

[**GetAccounts200Response**](GetAccounts200Response.md)

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

