# PeerTubeApiClient.Api.VideoFeedsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetSyndicatedComments**](VideoFeedsApi.md#getsyndicatedcomments) | **GET** /feeds/video-comments.{format} | Comments on videos feeds |
| [**GetSyndicatedSubscriptionVideos**](VideoFeedsApi.md#getsyndicatedsubscriptionvideos) | **GET** /feeds/subscriptions.{format} | Videos of subscriptions feeds |
| [**GetSyndicatedVideos**](VideoFeedsApi.md#getsyndicatedvideos) | **GET** /feeds/videos.{format} | Common videos feeds |
| [**GetVideosPodcastFeed**](VideoFeedsApi.md#getvideospodcastfeed) | **GET** /feeds/podcast/videos.xml | Videos podcast feed |

<a id="getsyndicatedcomments"></a>
# **GetSyndicatedComments**
> List&lt;VideoCommentsForXMLInner&gt; GetSyndicatedComments (string format, string? videoId = null, string? accountId = null, string? accountName = null, string? videoChannelId = null, string? videoChannelName = null)

Comments on videos feeds

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetSyndicatedCommentsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoFeedsApi(config);
            var format = "xml";  // string | format expected (we focus on making `rss` the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))
            var videoId = "videoId_example";  // string? | limit listing comments to a specific video (optional) 
            var accountId = "accountId_example";  // string? | limit listing comments to videos of a specific account (optional) 
            var accountName = "accountName_example";  // string? | limit listing comments to videos of a specific account (optional) 
            var videoChannelId = "videoChannelId_example";  // string? | limit listing comments to videos of a specific video channel (optional) 
            var videoChannelName = "videoChannelName_example";  // string? | limit listing comments to videos of a specific video channel (optional) 

            try
            {
                // Comments on videos feeds
                List<VideoCommentsForXMLInner> result = apiInstance.GetSyndicatedComments(format, videoId, accountId, accountName, videoChannelId, videoChannelName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoFeedsApi.GetSyndicatedComments: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSyndicatedCommentsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Comments on videos feeds
    ApiResponse<List<VideoCommentsForXMLInner>> response = apiInstance.GetSyndicatedCommentsWithHttpInfo(format, videoId, accountId, accountName, videoChannelId, videoChannelName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoFeedsApi.GetSyndicatedCommentsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **format** | **string** | format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss)) |  |
| **videoId** | **string?** | limit listing comments to a specific video | [optional]  |
| **accountId** | **string?** | limit listing comments to videos of a specific account | [optional]  |
| **accountName** | **string?** | limit listing comments to videos of a specific account | [optional]  |
| **videoChannelId** | **string?** | limit listing comments to videos of a specific video channel | [optional]  |
| **videoChannelName** | **string?** | limit listing comments to videos of a specific video channel | [optional]  |

### Return type

[**List&lt;VideoCommentsForXMLInner&gt;**](VideoCommentsForXMLInner.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml, application/rss+xml, text/xml, application/atom+xml, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  * Cache-Control -  <br>  |
| **400** | Arises when:   - videoId filter is mixed with a channel filter  |  -  |
| **404** | video, video channel or account not found |  -  |
| **406** | accept header unsupported |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getsyndicatedsubscriptionvideos"></a>
# **GetSyndicatedSubscriptionVideos**
> List&lt;VideosForXMLInner&gt; GetSyndicatedSubscriptionVideos (string format, string accountId, string token, string? sort = null, string? nsfw = null, bool? isLocal = null, int? include = null, VideoPrivacySet? privacyOneOf = null, bool? hasHLSFiles = null, bool? hasWebVideoFiles = null)

Videos of subscriptions feeds

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetSyndicatedSubscriptionVideosExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoFeedsApi(config);
            var format = "xml";  // string | format expected (we focus on making `rss` the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))
            var accountId = "accountId_example";  // string | limit listing to a specific account
            var token = "token_example";  // string | private token allowing access
            var sort = -createdAt;  // string? | Sort column (optional) 
            var nsfw = "true";  // string? | whether to include nsfw videos, if any (optional) 
            var isLocal = true;  // bool? | **PeerTube >= 4.0** Display only local or remote objects (optional) 
            var include = 0;  // int? | **PeerTube >= 4.0** Include additional videos in results (can be combined using bitwise or operator) - `0` NONE - `1` NOT_PUBLISHED_STATE - `2` BLACKLISTED - `4` BLOCKED_OWNER - `8` FILES - `16` CAPTIONS - `32` VIDEO SOURCE  (optional) 
            var privacyOneOf = new VideoPrivacySet?(); // VideoPrivacySet? | **PeerTube >= 4.0** Display only videos in this specific privacy/privacies (optional) 
            var hasHLSFiles = true;  // bool? | **PeerTube >= 4.0** Display only videos that have HLS files (optional) 
            var hasWebVideoFiles = true;  // bool? | **PeerTube >= 6.0** Display only videos that have Web Video files (optional) 

            try
            {
                // Videos of subscriptions feeds
                List<VideosForXMLInner> result = apiInstance.GetSyndicatedSubscriptionVideos(format, accountId, token, sort, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoFeedsApi.GetSyndicatedSubscriptionVideos: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSyndicatedSubscriptionVideosWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Videos of subscriptions feeds
    ApiResponse<List<VideosForXMLInner>> response = apiInstance.GetSyndicatedSubscriptionVideosWithHttpInfo(format, accountId, token, sort, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoFeedsApi.GetSyndicatedSubscriptionVideosWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **format** | **string** | format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss)) |  |
| **accountId** | **string** | limit listing to a specific account |  |
| **token** | **string** | private token allowing access |  |
| **sort** | **string?** | Sort column | [optional]  |
| **nsfw** | **string?** | whether to include nsfw videos, if any | [optional]  |
| **isLocal** | **bool?** | **PeerTube &gt;&#x3D; 4.0** Display only local or remote objects | [optional]  |
| **include** | **int?** | **PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  | [optional]  |
| **privacyOneOf** | [**VideoPrivacySet?**](VideoPrivacySet?.md) | **PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies | [optional]  |
| **hasHLSFiles** | **bool?** | **PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files | [optional]  |
| **hasWebVideoFiles** | **bool?** | **PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files | [optional]  |

### Return type

[**List&lt;VideosForXMLInner&gt;**](VideosForXMLInner.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml, application/rss+xml, text/xml, application/atom+xml, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  * Cache-Control -  <br>  |
| **406** | accept header unsupported |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getsyndicatedvideos"></a>
# **GetSyndicatedVideos**
> List&lt;VideosForXMLInner&gt; GetSyndicatedVideos (string format, string? accountId = null, string? accountName = null, string? videoChannelId = null, string? videoChannelName = null, string? sort = null, string? nsfw = null, bool? isLocal = null, int? include = null, VideoPrivacySet? privacyOneOf = null, bool? hasHLSFiles = null, bool? hasWebVideoFiles = null)

Common videos feeds

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetSyndicatedVideosExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoFeedsApi(config);
            var format = "xml";  // string | format expected (we focus on making `rss` the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))
            var accountId = "accountId_example";  // string? | limit listing to a specific account (optional) 
            var accountName = "accountName_example";  // string? | limit listing to a specific account (optional) 
            var videoChannelId = "videoChannelId_example";  // string? | limit listing to a specific video channel (optional) 
            var videoChannelName = "videoChannelName_example";  // string? | limit listing to a specific video channel (optional) 
            var sort = -createdAt;  // string? | Sort column (optional) 
            var nsfw = "true";  // string? | whether to include nsfw videos, if any (optional) 
            var isLocal = true;  // bool? | **PeerTube >= 4.0** Display only local or remote objects (optional) 
            var include = 0;  // int? | **PeerTube >= 4.0** Include additional videos in results (can be combined using bitwise or operator) - `0` NONE - `1` NOT_PUBLISHED_STATE - `2` BLACKLISTED - `4` BLOCKED_OWNER - `8` FILES - `16` CAPTIONS - `32` VIDEO SOURCE  (optional) 
            var privacyOneOf = new VideoPrivacySet?(); // VideoPrivacySet? | **PeerTube >= 4.0** Display only videos in this specific privacy/privacies (optional) 
            var hasHLSFiles = true;  // bool? | **PeerTube >= 4.0** Display only videos that have HLS files (optional) 
            var hasWebVideoFiles = true;  // bool? | **PeerTube >= 6.0** Display only videos that have Web Video files (optional) 

            try
            {
                // Common videos feeds
                List<VideosForXMLInner> result = apiInstance.GetSyndicatedVideos(format, accountId, accountName, videoChannelId, videoChannelName, sort, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoFeedsApi.GetSyndicatedVideos: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSyndicatedVideosWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Common videos feeds
    ApiResponse<List<VideosForXMLInner>> response = apiInstance.GetSyndicatedVideosWithHttpInfo(format, accountId, accountName, videoChannelId, videoChannelName, sort, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoFeedsApi.GetSyndicatedVideosWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **format** | **string** | format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss)) |  |
| **accountId** | **string?** | limit listing to a specific account | [optional]  |
| **accountName** | **string?** | limit listing to a specific account | [optional]  |
| **videoChannelId** | **string?** | limit listing to a specific video channel | [optional]  |
| **videoChannelName** | **string?** | limit listing to a specific video channel | [optional]  |
| **sort** | **string?** | Sort column | [optional]  |
| **nsfw** | **string?** | whether to include nsfw videos, if any | [optional]  |
| **isLocal** | **bool?** | **PeerTube &gt;&#x3D; 4.0** Display only local or remote objects | [optional]  |
| **include** | **int?** | **PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  | [optional]  |
| **privacyOneOf** | [**VideoPrivacySet?**](VideoPrivacySet?.md) | **PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies | [optional]  |
| **hasHLSFiles** | **bool?** | **PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files | [optional]  |
| **hasWebVideoFiles** | **bool?** | **PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files | [optional]  |

### Return type

[**List&lt;VideosForXMLInner&gt;**](VideosForXMLInner.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/xml, application/rss+xml, text/xml, application/atom+xml, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  * Cache-Control -  <br>  |
| **404** | video channel or account not found |  -  |
| **406** | accept header unsupported |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getvideospodcastfeed"></a>
# **GetVideosPodcastFeed**
> void GetVideosPodcastFeed (string videoChannelId)

Videos podcast feed

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetVideosPodcastFeedExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoFeedsApi(config);
            var videoChannelId = "videoChannelId_example";  // string | Limit listing to a specific video channel

            try
            {
                // Videos podcast feed
                apiInstance.GetVideosPodcastFeed(videoChannelId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoFeedsApi.GetVideosPodcastFeed: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetVideosPodcastFeedWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Videos podcast feed
    apiInstance.GetVideosPodcastFeedWithHttpInfo(videoChannelId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoFeedsApi.GetVideosPodcastFeedWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **videoChannelId** | **string** | Limit listing to a specific video channel |  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  * Cache-Control -  <br>  |
| **404** | video channel not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

