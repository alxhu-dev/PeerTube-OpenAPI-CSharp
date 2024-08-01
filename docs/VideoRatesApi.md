# PeerTubeApiClient.Api.VideoRatesApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1UsersMeVideosVideoIdRatingGet**](VideoRatesApi.md#apiv1usersmevideosvideoidratingget) | **GET** /api/v1/users/me/videos/{videoId}/rating | Get rate of my user for a video |
| [**ApiV1VideosIdRatePut**](VideoRatesApi.md#apiv1videosidrateput) | **PUT** /api/v1/videos/{id}/rate | Like/dislike a video |

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

            var apiInstance = new VideoRatesApi(config);
            var videoId = 56;  // int | The video id

            try
            {
                // Get rate of my user for a video
                GetMeVideoRating result = apiInstance.ApiV1UsersMeVideosVideoIdRatingGet(videoId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoRatesApi.ApiV1UsersMeVideosVideoIdRatingGet: " + e.Message);
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
    Debug.Print("Exception when calling VideoRatesApi.ApiV1UsersMeVideosVideoIdRatingGetWithHttpInfo: " + e.Message);
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

<a id="apiv1videosidrateput"></a>
# **ApiV1VideosIdRatePut**
> void ApiV1VideosIdRatePut (ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = null, ApiV1VideosIdRatePutRequest? apiV1VideosIdRatePutRequest = null)

Like/dislike a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdRatePutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoRatesApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var xPeertubeVideoPassword = "xPeertubeVideoPassword_example";  // string? | Required on password protected video (optional) 
            var apiV1VideosIdRatePutRequest = new ApiV1VideosIdRatePutRequest?(); // ApiV1VideosIdRatePutRequest? |  (optional) 

            try
            {
                // Like/dislike a video
                apiInstance.ApiV1VideosIdRatePut(id, xPeertubeVideoPassword, apiV1VideosIdRatePutRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoRatesApi.ApiV1VideosIdRatePut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdRatePutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Like/dislike a video
    apiInstance.ApiV1VideosIdRatePutWithHttpInfo(id, xPeertubeVideoPassword, apiV1VideosIdRatePutRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoRatesApi.ApiV1VideosIdRatePutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **xPeertubeVideoPassword** | **string?** | Required on password protected video | [optional]  |
| **apiV1VideosIdRatePutRequest** | [**ApiV1VideosIdRatePutRequest?**](ApiV1VideosIdRatePutRequest?.md) |  | [optional]  |

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
| **404** | video does not exist |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

