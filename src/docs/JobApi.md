# PeerTubeApiClient.Api.JobApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1JobsPausePost**](JobApi.md#apiv1jobspausepost) | **POST** /api/v1/jobs/pause | Pause job queue |
| [**ApiV1JobsResumePost**](JobApi.md#apiv1jobsresumepost) | **POST** /api/v1/jobs/resume | Resume job queue |
| [**GetJobs**](JobApi.md#getjobs) | **GET** /api/v1/jobs/{state} | List instance jobs |

<a id="apiv1jobspausepost"></a>
# **ApiV1JobsPausePost**
> void ApiV1JobsPausePost ()

Pause job queue

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1JobsPausePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new JobApi(config);

            try
            {
                // Pause job queue
                apiInstance.ApiV1JobsPausePost();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling JobApi.ApiV1JobsPausePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1JobsPausePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Pause job queue
    apiInstance.ApiV1JobsPausePostWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling JobApi.ApiV1JobsPausePostWithHttpInfo: " + e.Message);
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

<a id="apiv1jobsresumepost"></a>
# **ApiV1JobsResumePost**
> void ApiV1JobsResumePost ()

Resume job queue

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1JobsResumePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new JobApi(config);

            try
            {
                // Resume job queue
                apiInstance.ApiV1JobsResumePost();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling JobApi.ApiV1JobsResumePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1JobsResumePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Resume job queue
    apiInstance.ApiV1JobsResumePostWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling JobApi.ApiV1JobsResumePostWithHttpInfo: " + e.Message);
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

<a id="getjobs"></a>
# **GetJobs**
> GetJobs200Response GetJobs (string state, string? jobType = null, int? start = null, int? count = null, string? sort = null)

List instance jobs

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetJobsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new JobApi(config);
            var state = "";  // string | The state of the job ('' for for no filter)
            var jobType = "activitypub-follow";  // string? | job type (optional) 
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List instance jobs
                GetJobs200Response result = apiInstance.GetJobs(state, jobType, start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling JobApi.GetJobs: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetJobsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List instance jobs
    ApiResponse<GetJobs200Response> response = apiInstance.GetJobsWithHttpInfo(state, jobType, start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling JobApi.GetJobsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **state** | **string** | The state of the job (&#39;&#39; for for no filter) |  |
| **jobType** | **string?** | job type | [optional]  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort column | [optional]  |

### Return type

[**GetJobs200Response**](GetJobs200Response.md)

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

