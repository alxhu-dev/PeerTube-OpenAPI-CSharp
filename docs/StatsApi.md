# PeerTubeApiClient.Api.StatsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1MetricsPlaybackPost**](StatsApi.md#apiv1metricsplaybackpost) | **POST** /api/v1/metrics/playback | Create playback metrics |
| [**GetInstanceStats**](StatsApi.md#getinstancestats) | **GET** /api/v1/server/stats | Get instance stats |

<a id="apiv1metricsplaybackpost"></a>
# **ApiV1MetricsPlaybackPost**
> void ApiV1MetricsPlaybackPost (PlaybackMetricCreate? playbackMetricCreate = null)

Create playback metrics

These metrics are exposed by OpenTelemetry metrics exporter if enabled.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1MetricsPlaybackPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new StatsApi(config);
            var playbackMetricCreate = new PlaybackMetricCreate?(); // PlaybackMetricCreate? |  (optional) 

            try
            {
                // Create playback metrics
                apiInstance.ApiV1MetricsPlaybackPost(playbackMetricCreate);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling StatsApi.ApiV1MetricsPlaybackPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1MetricsPlaybackPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create playback metrics
    apiInstance.ApiV1MetricsPlaybackPostWithHttpInfo(playbackMetricCreate);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling StatsApi.ApiV1MetricsPlaybackPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **playbackMetricCreate** | [**PlaybackMetricCreate?**](PlaybackMetricCreate?.md) |  | [optional]  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getinstancestats"></a>
# **GetInstanceStats**
> ServerStats GetInstanceStats ()

Get instance stats

Get instance public statistics. This endpoint is cached.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetInstanceStatsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new StatsApi(config);

            try
            {
                // Get instance stats
                ServerStats result = apiInstance.GetInstanceStats();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling StatsApi.GetInstanceStats: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetInstanceStatsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get instance stats
    ApiResponse<ServerStats> response = apiInstance.GetInstanceStatsWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling StatsApi.GetInstanceStatsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**ServerStats**](ServerStats.md)

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

