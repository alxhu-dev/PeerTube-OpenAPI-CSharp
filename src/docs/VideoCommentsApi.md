# PeerTubeApiClient.Api.VideoCommentsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1UsersMeVideosCommentsGet**](VideoCommentsApi.md#apiv1usersmevideoscommentsget) | **GET** /api/v1/users/me/videos/comments | List comments on user&#39;s videos |
| [**ApiV1VideosCommentsGet**](VideoCommentsApi.md#apiv1videoscommentsget) | **GET** /api/v1/videos/comments | List instance comments |
| [**ApiV1VideosIdCommentThreadsGet**](VideoCommentsApi.md#apiv1videosidcommentthreadsget) | **GET** /api/v1/videos/{id}/comment-threads | List threads of a video |
| [**ApiV1VideosIdCommentThreadsPost**](VideoCommentsApi.md#apiv1videosidcommentthreadspost) | **POST** /api/v1/videos/{id}/comment-threads | Create a thread |
| [**ApiV1VideosIdCommentThreadsThreadIdGet**](VideoCommentsApi.md#apiv1videosidcommentthreadsthreadidget) | **GET** /api/v1/videos/{id}/comment-threads/{threadId} | Get a thread |
| [**ApiV1VideosIdCommentsCommentIdApprovePost**](VideoCommentsApi.md#apiv1videosidcommentscommentidapprovepost) | **POST** /api/v1/videos/{id}/comments/{commentId}/approve | Approve a comment |
| [**ApiV1VideosIdCommentsCommentIdDelete**](VideoCommentsApi.md#apiv1videosidcommentscommentiddelete) | **DELETE** /api/v1/videos/{id}/comments/{commentId} | Delete a comment or a reply |
| [**ApiV1VideosIdCommentsCommentIdPost**](VideoCommentsApi.md#apiv1videosidcommentscommentidpost) | **POST** /api/v1/videos/{id}/comments/{commentId} | Reply to a thread of a video |

<a id="apiv1usersmevideoscommentsget"></a>
# **ApiV1UsersMeVideosCommentsGet**
> ApiV1UsersMeVideosCommentsGet200Response ApiV1UsersMeVideosCommentsGet (string? search = null, string? searchAccount = null, string? searchVideo = null, int? videoId = null, int? videoChannelId = null, GetAccountVideosTagsAllOfParameter? autoTagOneOf = null, bool? isHeldForReview = null)

List comments on user's videos

**PeerTube >= 6.2**

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeVideosCommentsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoCommentsApi(config);
            var search = "search_example";  // string? | Plain text search, applied to various parts of the model depending on endpoint (optional) 
            var searchAccount = "searchAccount_example";  // string? | Filter comments by searching on the account (optional) 
            var searchVideo = "searchVideo_example";  // string? | Filter comments by searching on the video (optional) 
            var videoId = 56;  // int? | Limit results on this specific video (optional) 
            var videoChannelId = 56;  // int? | Limit results on this specific video channel (optional) 
            var autoTagOneOf = new GetAccountVideosTagsAllOfParameter?(); // GetAccountVideosTagsAllOfParameter? | **PeerTube >= 6.2** filter on comments that contain one of these automatic tags (optional) 
            var isHeldForReview = true;  // bool? | only display comments that are held for review (optional) 

            try
            {
                // List comments on user's videos
                ApiV1UsersMeVideosCommentsGet200Response result = apiInstance.ApiV1UsersMeVideosCommentsGet(search, searchAccount, searchVideo, videoId, videoChannelId, autoTagOneOf, isHeldForReview);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoCommentsApi.ApiV1UsersMeVideosCommentsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeVideosCommentsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List comments on user's videos
    ApiResponse<ApiV1UsersMeVideosCommentsGet200Response> response = apiInstance.ApiV1UsersMeVideosCommentsGetWithHttpInfo(search, searchAccount, searchVideo, videoId, videoChannelId, autoTagOneOf, isHeldForReview);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoCommentsApi.ApiV1UsersMeVideosCommentsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **search** | **string?** | Plain text search, applied to various parts of the model depending on endpoint | [optional]  |
| **searchAccount** | **string?** | Filter comments by searching on the account | [optional]  |
| **searchVideo** | **string?** | Filter comments by searching on the video | [optional]  |
| **videoId** | **int?** | Limit results on this specific video | [optional]  |
| **videoChannelId** | **int?** | Limit results on this specific video channel | [optional]  |
| **autoTagOneOf** | [**GetAccountVideosTagsAllOfParameter?**](GetAccountVideosTagsAllOfParameter?.md) | **PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags | [optional]  |
| **isHeldForReview** | **bool?** | only display comments that are held for review | [optional]  |

### Return type

[**ApiV1UsersMeVideosCommentsGet200Response**](ApiV1UsersMeVideosCommentsGet200Response.md)

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

<a id="apiv1videoscommentsget"></a>
# **ApiV1VideosCommentsGet**
> ApiV1UsersMeVideosCommentsGet200Response ApiV1VideosCommentsGet (string? search = null, string? searchAccount = null, string? searchVideo = null, int? videoId = null, int? videoChannelId = null, GetAccountVideosTagsAllOfParameter? autoTagOneOf = null, bool? isLocal = null, bool? onLocalVideo = null)

List instance comments

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosCommentsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoCommentsApi(config);
            var search = "search_example";  // string? | Plain text search, applied to various parts of the model depending on endpoint (optional) 
            var searchAccount = "searchAccount_example";  // string? | Filter comments by searching on the account (optional) 
            var searchVideo = "searchVideo_example";  // string? | Filter comments by searching on the video (optional) 
            var videoId = 56;  // int? | Limit results on this specific video (optional) 
            var videoChannelId = 56;  // int? | Limit results on this specific video channel (optional) 
            var autoTagOneOf = new GetAccountVideosTagsAllOfParameter?(); // GetAccountVideosTagsAllOfParameter? | **PeerTube >= 6.2** filter on comments that contain one of these automatic tags (optional) 
            var isLocal = true;  // bool? | **PeerTube >= 4.0** Display only local or remote objects (optional) 
            var onLocalVideo = true;  // bool? | Display only objects of local or remote videos (optional) 

            try
            {
                // List instance comments
                ApiV1UsersMeVideosCommentsGet200Response result = apiInstance.ApiV1VideosCommentsGet(search, searchAccount, searchVideo, videoId, videoChannelId, autoTagOneOf, isLocal, onLocalVideo);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoCommentsApi.ApiV1VideosCommentsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosCommentsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List instance comments
    ApiResponse<ApiV1UsersMeVideosCommentsGet200Response> response = apiInstance.ApiV1VideosCommentsGetWithHttpInfo(search, searchAccount, searchVideo, videoId, videoChannelId, autoTagOneOf, isLocal, onLocalVideo);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoCommentsApi.ApiV1VideosCommentsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **search** | **string?** | Plain text search, applied to various parts of the model depending on endpoint | [optional]  |
| **searchAccount** | **string?** | Filter comments by searching on the account | [optional]  |
| **searchVideo** | **string?** | Filter comments by searching on the video | [optional]  |
| **videoId** | **int?** | Limit results on this specific video | [optional]  |
| **videoChannelId** | **int?** | Limit results on this specific video channel | [optional]  |
| **autoTagOneOf** | [**GetAccountVideosTagsAllOfParameter?**](GetAccountVideosTagsAllOfParameter?.md) | **PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags | [optional]  |
| **isLocal** | **bool?** | **PeerTube &gt;&#x3D; 4.0** Display only local or remote objects | [optional]  |
| **onLocalVideo** | **bool?** | Display only objects of local or remote videos | [optional]  |

### Return type

[**ApiV1UsersMeVideosCommentsGet200Response**](ApiV1UsersMeVideosCommentsGet200Response.md)

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

<a id="apiv1videosidcommentthreadsget"></a>
# **ApiV1VideosIdCommentThreadsGet**
> CommentThreadResponse ApiV1VideosIdCommentThreadsGet (ApiV1VideosOwnershipIdAcceptPostIdParameter id, int? start = null, int? count = null, string? sort = null, string? xPeertubeVideoPassword = null)

List threads of a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdCommentThreadsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoCommentsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = "-createdAt";  // string? | Sort comments by criteria (optional) 
            var xPeertubeVideoPassword = "xPeertubeVideoPassword_example";  // string? | Required on password protected video (optional) 

            try
            {
                // List threads of a video
                CommentThreadResponse result = apiInstance.ApiV1VideosIdCommentThreadsGet(id, start, count, sort, xPeertubeVideoPassword);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoCommentsApi.ApiV1VideosIdCommentThreadsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdCommentThreadsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List threads of a video
    ApiResponse<CommentThreadResponse> response = apiInstance.ApiV1VideosIdCommentThreadsGetWithHttpInfo(id, start, count, sort, xPeertubeVideoPassword);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoCommentsApi.ApiV1VideosIdCommentThreadsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort comments by criteria | [optional]  |
| **xPeertubeVideoPassword** | **string?** | Required on password protected video | [optional]  |

### Return type

[**CommentThreadResponse**](CommentThreadResponse.md)

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

<a id="apiv1videosidcommentthreadspost"></a>
# **ApiV1VideosIdCommentThreadsPost**
> CommentThreadPostResponse ApiV1VideosIdCommentThreadsPost (ApiV1VideosOwnershipIdAcceptPostIdParameter id, ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = null)

Create a thread

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdCommentThreadsPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoCommentsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var apiV1VideosIdCommentThreadsPostRequest = new ApiV1VideosIdCommentThreadsPostRequest?(); // ApiV1VideosIdCommentThreadsPostRequest? |  (optional) 

            try
            {
                // Create a thread
                CommentThreadPostResponse result = apiInstance.ApiV1VideosIdCommentThreadsPost(id, apiV1VideosIdCommentThreadsPostRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoCommentsApi.ApiV1VideosIdCommentThreadsPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdCommentThreadsPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a thread
    ApiResponse<CommentThreadPostResponse> response = apiInstance.ApiV1VideosIdCommentThreadsPostWithHttpInfo(id, apiV1VideosIdCommentThreadsPostRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoCommentsApi.ApiV1VideosIdCommentThreadsPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **apiV1VideosIdCommentThreadsPostRequest** | [**ApiV1VideosIdCommentThreadsPostRequest?**](ApiV1VideosIdCommentThreadsPostRequest?.md) |  | [optional]  |

### Return type

[**CommentThreadPostResponse**](CommentThreadPostResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **404** | video does not exist |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1videosidcommentthreadsthreadidget"></a>
# **ApiV1VideosIdCommentThreadsThreadIdGet**
> VideoCommentThreadTree ApiV1VideosIdCommentThreadsThreadIdGet (ApiV1VideosOwnershipIdAcceptPostIdParameter id, int threadId, string? xPeertubeVideoPassword = null)

Get a thread

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdCommentThreadsThreadIdGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new VideoCommentsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var threadId = 56;  // int | The thread id (root comment id)
            var xPeertubeVideoPassword = "xPeertubeVideoPassword_example";  // string? | Required on password protected video (optional) 

            try
            {
                // Get a thread
                VideoCommentThreadTree result = apiInstance.ApiV1VideosIdCommentThreadsThreadIdGet(id, threadId, xPeertubeVideoPassword);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoCommentsApi.ApiV1VideosIdCommentThreadsThreadIdGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdCommentThreadsThreadIdGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a thread
    ApiResponse<VideoCommentThreadTree> response = apiInstance.ApiV1VideosIdCommentThreadsThreadIdGetWithHttpInfo(id, threadId, xPeertubeVideoPassword);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoCommentsApi.ApiV1VideosIdCommentThreadsThreadIdGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **threadId** | **int** | The thread id (root comment id) |  |
| **xPeertubeVideoPassword** | **string?** | Required on password protected video | [optional]  |

### Return type

[**VideoCommentThreadTree**](VideoCommentThreadTree.md)

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

<a id="apiv1videosidcommentscommentidapprovepost"></a>
# **ApiV1VideosIdCommentsCommentIdApprovePost**
> void ApiV1VideosIdCommentsCommentIdApprovePost (ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId)

Approve a comment

**PeerTube >= 6.2** Approve a comment that requires a review

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdCommentsCommentIdApprovePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoCommentsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var commentId = 56;  // int | The comment id

            try
            {
                // Approve a comment
                apiInstance.ApiV1VideosIdCommentsCommentIdApprovePost(id, commentId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoCommentsApi.ApiV1VideosIdCommentsCommentIdApprovePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdCommentsCommentIdApprovePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Approve a comment
    apiInstance.ApiV1VideosIdCommentsCommentIdApprovePostWithHttpInfo(id, commentId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoCommentsApi.ApiV1VideosIdCommentsCommentIdApprovePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **commentId** | **int** | The comment id |  |

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

<a id="apiv1videosidcommentscommentiddelete"></a>
# **ApiV1VideosIdCommentsCommentIdDelete**
> void ApiV1VideosIdCommentsCommentIdDelete (ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId)

Delete a comment or a reply

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdCommentsCommentIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoCommentsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var commentId = 56;  // int | The comment id

            try
            {
                // Delete a comment or a reply
                apiInstance.ApiV1VideosIdCommentsCommentIdDelete(id, commentId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoCommentsApi.ApiV1VideosIdCommentsCommentIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdCommentsCommentIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a comment or a reply
    apiInstance.ApiV1VideosIdCommentsCommentIdDeleteWithHttpInfo(id, commentId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoCommentsApi.ApiV1VideosIdCommentsCommentIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **commentId** | **int** | The comment id |  |

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
| **403** | cannot remove comment of another user |  -  |
| **404** | comment or video does not exist |  -  |
| **409** | comment is already deleted |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1videosidcommentscommentidpost"></a>
# **ApiV1VideosIdCommentsCommentIdPost**
> CommentThreadPostResponse ApiV1VideosIdCommentsCommentIdPost (ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, string? xPeertubeVideoPassword = null, ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = null)

Reply to a thread of a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdCommentsCommentIdPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoCommentsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var commentId = 56;  // int | The comment id
            var xPeertubeVideoPassword = "xPeertubeVideoPassword_example";  // string? | Required on password protected video (optional) 
            var apiV1VideosIdCommentThreadsPostRequest = new ApiV1VideosIdCommentThreadsPostRequest?(); // ApiV1VideosIdCommentThreadsPostRequest? |  (optional) 

            try
            {
                // Reply to a thread of a video
                CommentThreadPostResponse result = apiInstance.ApiV1VideosIdCommentsCommentIdPost(id, commentId, xPeertubeVideoPassword, apiV1VideosIdCommentThreadsPostRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoCommentsApi.ApiV1VideosIdCommentsCommentIdPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdCommentsCommentIdPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Reply to a thread of a video
    ApiResponse<CommentThreadPostResponse> response = apiInstance.ApiV1VideosIdCommentsCommentIdPostWithHttpInfo(id, commentId, xPeertubeVideoPassword, apiV1VideosIdCommentThreadsPostRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoCommentsApi.ApiV1VideosIdCommentsCommentIdPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **commentId** | **int** | The comment id |  |
| **xPeertubeVideoPassword** | **string?** | Required on password protected video | [optional]  |
| **apiV1VideosIdCommentThreadsPostRequest** | [**ApiV1VideosIdCommentThreadsPostRequest?**](ApiV1VideosIdCommentThreadsPostRequest?.md) |  | [optional]  |

### Return type

[**CommentThreadPostResponse**](CommentThreadPostResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **404** | thread or video does not exist |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

