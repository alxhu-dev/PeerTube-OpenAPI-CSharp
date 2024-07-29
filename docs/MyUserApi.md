# PeerTubeApiClient.Api.MyUserApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1UsersMeAvatarDelete**](MyUserApi.md#apiv1usersmeavatardelete) | **DELETE** /api/v1/users/me/avatar | Delete my avatar |
| [**ApiV1UsersMeAvatarPickPost**](MyUserApi.md#apiv1usersmeavatarpickpost) | **POST** /api/v1/users/me/avatar/pick | Update my user avatar |
| [**ApiV1UsersMeVideoQuotaUsedGet**](MyUserApi.md#apiv1usersmevideoquotausedget) | **GET** /api/v1/users/me/video-quota-used | Get my user used quota |
| [**ApiV1UsersMeVideosGet**](MyUserApi.md#apiv1usersmevideosget) | **GET** /api/v1/users/me/videos | List videos of my user |
| [**ApiV1UsersMeVideosImportsGet**](MyUserApi.md#apiv1usersmevideosimportsget) | **GET** /api/v1/users/me/videos/imports | Get video imports of my user |
| [**ApiV1UsersMeVideosVideoIdRatingGet**](MyUserApi.md#apiv1usersmevideosvideoidratingget) | **GET** /api/v1/users/me/videos/{videoId}/rating | Get rate of my user for a video |
| [**GetMyAbuses**](MyUserApi.md#getmyabuses) | **GET** /api/v1/users/me/abuses | List my abuses |
| [**GetUserInfo**](MyUserApi.md#getuserinfo) | **GET** /api/v1/users/me | Get my user information |
| [**PutUserInfo**](MyUserApi.md#putuserinfo) | **PUT** /api/v1/users/me | Update my user information |

<a id="apiv1usersmeavatardelete"></a>
# **ApiV1UsersMeAvatarDelete**
> void ApiV1UsersMeAvatarDelete ()

Delete my avatar

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeAvatarDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MyUserApi(config);

            try
            {
                // Delete my avatar
                apiInstance.ApiV1UsersMeAvatarDelete();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MyUserApi.ApiV1UsersMeAvatarDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeAvatarDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete my avatar
    apiInstance.ApiV1UsersMeAvatarDeleteWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MyUserApi.ApiV1UsersMeAvatarDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
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

<a id="apiv1usersmeavatarpickpost"></a>
# **ApiV1UsersMeAvatarPickPost**
> ApiV1UsersMeAvatarPickPost200Response ApiV1UsersMeAvatarPickPost (System.IO.Stream? avatarfile = null)

Update my user avatar

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeAvatarPickPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MyUserApi(config);
            var avatarfile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? | The file to upload (optional) 

            try
            {
                // Update my user avatar
                ApiV1UsersMeAvatarPickPost200Response result = apiInstance.ApiV1UsersMeAvatarPickPost(avatarfile);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MyUserApi.ApiV1UsersMeAvatarPickPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeAvatarPickPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update my user avatar
    ApiResponse<ApiV1UsersMeAvatarPickPost200Response> response = apiInstance.ApiV1UsersMeAvatarPickPostWithHttpInfo(avatarfile);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MyUserApi.ApiV1UsersMeAvatarPickPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **avatarfile** | **System.IO.Stream?****System.IO.Stream?** | The file to upload | [optional]  |

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

<a id="apiv1usersmevideoquotausedget"></a>
# **ApiV1UsersMeVideoQuotaUsedGet**
> ApiV1UsersMeVideoQuotaUsedGet200Response ApiV1UsersMeVideoQuotaUsedGet ()

Get my user used quota

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeVideoQuotaUsedGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MyUserApi(config);

            try
            {
                // Get my user used quota
                ApiV1UsersMeVideoQuotaUsedGet200Response result = apiInstance.ApiV1UsersMeVideoQuotaUsedGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MyUserApi.ApiV1UsersMeVideoQuotaUsedGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeVideoQuotaUsedGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get my user used quota
    ApiResponse<ApiV1UsersMeVideoQuotaUsedGet200Response> response = apiInstance.ApiV1UsersMeVideoQuotaUsedGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MyUserApi.ApiV1UsersMeVideoQuotaUsedGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**ApiV1UsersMeVideoQuotaUsedGet200Response**](ApiV1UsersMeVideoQuotaUsedGet200Response.md)

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

            var apiInstance = new MyUserApi(config);
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
                Debug.Print("Exception when calling MyUserApi.ApiV1UsersMeVideosGet: " + e.Message);
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
    Debug.Print("Exception when calling MyUserApi.ApiV1UsersMeVideosGetWithHttpInfo: " + e.Message);
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

            var apiInstance = new MyUserApi(config);
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
                Debug.Print("Exception when calling MyUserApi.ApiV1UsersMeVideosImportsGet: " + e.Message);
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
    Debug.Print("Exception when calling MyUserApi.ApiV1UsersMeVideosImportsGetWithHttpInfo: " + e.Message);
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

<a id="apiv1usersmevideosvideoidratingget"></a>
# **ApiV1UsersMeVideosVideoIdRatingGet**
> GetMeVideoRating ApiV1UsersMeVideosVideoIdRatingGet (int videoId)

Get rate of my user for a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeVideosVideoIdRatingGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MyUserApi(config);
            var videoId = 56;  // int | The video id

            try
            {
                // Get rate of my user for a video
                GetMeVideoRating result = apiInstance.ApiV1UsersMeVideosVideoIdRatingGet(videoId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MyUserApi.ApiV1UsersMeVideosVideoIdRatingGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeVideosVideoIdRatingGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get rate of my user for a video
    ApiResponse<GetMeVideoRating> response = apiInstance.ApiV1UsersMeVideosVideoIdRatingGetWithHttpInfo(videoId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MyUserApi.ApiV1UsersMeVideosVideoIdRatingGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **videoId** | **int** | The video id |  |

### Return type

[**GetMeVideoRating**](GetMeVideoRating.md)

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

<a id="getmyabuses"></a>
# **GetMyAbuses**
> GetMyAbuses200Response GetMyAbuses (int? id = null, AbuseStateSet? state = null, string? sort = null, int? start = null, int? count = null)

List my abuses

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetMyAbusesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MyUserApi(config);
            var id = 56;  // int? | only list the report with this id (optional) 
            var state = new AbuseStateSet?(); // AbuseStateSet? |  (optional) 
            var sort = "-id";  // string? | Sort abuses by criteria (optional) 
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)

            try
            {
                // List my abuses
                GetMyAbuses200Response result = apiInstance.GetMyAbuses(id, state, sort, start, count);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MyUserApi.GetMyAbuses: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetMyAbusesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List my abuses
    ApiResponse<GetMyAbuses200Response> response = apiInstance.GetMyAbusesWithHttpInfo(id, state, sort, start, count);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MyUserApi.GetMyAbusesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int?** | only list the report with this id | [optional]  |
| **state** | [**AbuseStateSet?**](AbuseStateSet?.md) |  | [optional]  |
| **sort** | **string?** | Sort abuses by criteria | [optional]  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |

### Return type

[**GetMyAbuses200Response**](GetMyAbuses200Response.md)

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

<a id="getuserinfo"></a>
# **GetUserInfo**
> List&lt;User&gt; GetUserInfo ()

Get my user information

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetUserInfoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MyUserApi(config);

            try
            {
                // Get my user information
                List<User> result = apiInstance.GetUserInfo();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MyUserApi.GetUserInfo: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetUserInfoWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get my user information
    ApiResponse<List<User>> response = apiInstance.GetUserInfoWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MyUserApi.GetUserInfoWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;User&gt;**](User.md)

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

<a id="putuserinfo"></a>
# **PutUserInfo**
> void PutUserInfo (UpdateMe updateMe)

Update my user information

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class PutUserInfoExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MyUserApi(config);
            var updateMe = new UpdateMe(); // UpdateMe | 

            try
            {
                // Update my user information
                apiInstance.PutUserInfo(updateMe);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MyUserApi.PutUserInfo: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PutUserInfoWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update my user information
    apiInstance.PutUserInfoWithHttpInfo(updateMe);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MyUserApi.PutUserInfoWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **updateMe** | [**UpdateMe**](UpdateMe.md) |  |  |

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

