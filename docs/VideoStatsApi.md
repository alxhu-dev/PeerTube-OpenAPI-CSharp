# PeerTubeApiClient.Api.VideoStatsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1VideosIdStatsOverallGet**](VideoStatsApi.md#apiv1videosidstatsoverallget) | **GET** /api/v1/videos/{id}/stats/overall | Get overall stats of a video |
| [**ApiV1VideosIdStatsRetentionGet**](VideoStatsApi.md#apiv1videosidstatsretentionget) | **GET** /api/v1/videos/{id}/stats/retention | Get retention stats of a video |
| [**ApiV1VideosIdStatsTimeseriesMetricGet**](VideoStatsApi.md#apiv1videosidstatstimeseriesmetricget) | **GET** /api/v1/videos/{id}/stats/timeseries/{metric} | Get timeserie stats of a video |

<a id="apiv1videosidstatsoverallget"></a>
# **ApiV1VideosIdStatsOverallGet**
> VideoStatsOverall ApiV1VideosIdStatsOverallGet (ApiV1VideosOwnershipIdAcceptPostIdParameter id, DateTime? startDate = null, DateTime? endDate = null)

Get overall stats of a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdStatsOverallGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoStatsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var startDate = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Filter stats by start date (optional) 
            var endDate = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Filter stats by end date (optional) 

            try
            {
                // Get overall stats of a video
                VideoStatsOverall result = apiInstance.ApiV1VideosIdStatsOverallGet(id, startDate, endDate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoStatsApi.ApiV1VideosIdStatsOverallGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdStatsOverallGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get overall stats of a video
    ApiResponse<VideoStatsOverall> response = apiInstance.ApiV1VideosIdStatsOverallGetWithHttpInfo(id, startDate, endDate);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoStatsApi.ApiV1VideosIdStatsOverallGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **startDate** | **DateTime?** | Filter stats by start date | [optional]  |
| **endDate** | **DateTime?** | Filter stats by end date | [optional]  |

### Return type

[**VideoStatsOverall**](VideoStatsOverall.md)

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

<a id="apiv1videosidstatsretentionget"></a>
# **ApiV1VideosIdStatsRetentionGet**
> VideoStatsRetention ApiV1VideosIdStatsRetentionGet (ApiV1VideosOwnershipIdAcceptPostIdParameter id)

Get retention stats of a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdStatsRetentionGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoStatsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid

            try
            {
                // Get retention stats of a video
                VideoStatsRetention result = apiInstance.ApiV1VideosIdStatsRetentionGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoStatsApi.ApiV1VideosIdStatsRetentionGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdStatsRetentionGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get retention stats of a video
    ApiResponse<VideoStatsRetention> response = apiInstance.ApiV1VideosIdStatsRetentionGetWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoStatsApi.ApiV1VideosIdStatsRetentionGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |

### Return type

[**VideoStatsRetention**](VideoStatsRetention.md)

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

<a id="apiv1videosidstatstimeseriesmetricget"></a>
# **ApiV1VideosIdStatsTimeseriesMetricGet**
> VideoStatsTimeserie ApiV1VideosIdStatsTimeseriesMetricGet (ApiV1VideosOwnershipIdAcceptPostIdParameter id, string metric, DateTime? startDate = null, DateTime? endDate = null)

Get timeserie stats of a video

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideosIdStatsTimeseriesMetricGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new VideoStatsApi(config);
            var id = new ApiV1VideosOwnershipIdAcceptPostIdParameter(); // ApiV1VideosOwnershipIdAcceptPostIdParameter | The object id, uuid or short uuid
            var metric = "viewers";  // string | The metric to get
            var startDate = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Filter stats by start date (optional) 
            var endDate = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Filter stats by end date (optional) 

            try
            {
                // Get timeserie stats of a video
                VideoStatsTimeserie result = apiInstance.ApiV1VideosIdStatsTimeseriesMetricGet(id, metric, startDate, endDate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling VideoStatsApi.ApiV1VideosIdStatsTimeseriesMetricGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideosIdStatsTimeseriesMetricGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get timeserie stats of a video
    ApiResponse<VideoStatsTimeserie> response = apiInstance.ApiV1VideosIdStatsTimeseriesMetricGetWithHttpInfo(id, metric, startDate, endDate);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling VideoStatsApi.ApiV1VideosIdStatsTimeseriesMetricGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**ApiV1VideosOwnershipIdAcceptPostIdParameter**](ApiV1VideosOwnershipIdAcceptPostIdParameter.md) | The object id, uuid or short uuid |  |
| **metric** | **string** | The metric to get |  |
| **startDate** | **DateTime?** | Filter stats by start date | [optional]  |
| **endDate** | **DateTime?** | Filter stats by end date | [optional]  |

### Return type

[**VideoStatsTimeserie**](VideoStatsTimeserie.md)

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

