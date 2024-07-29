# PeerTubeApiClient.Api.RunnerJobsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1RunnersJobsGet**](RunnerJobsApi.md#apiv1runnersjobsget) | **GET** /api/v1/runners/jobs | List jobs |
| [**ApiV1RunnersJobsJobUUIDAbortPost**](RunnerJobsApi.md#apiv1runnersjobsjobuuidabortpost) | **POST** /api/v1/runners/jobs/{jobUUID}/abort | Abort job |
| [**ApiV1RunnersJobsJobUUIDAcceptPost**](RunnerJobsApi.md#apiv1runnersjobsjobuuidacceptpost) | **POST** /api/v1/runners/jobs/{jobUUID}/accept | Accept job |
| [**ApiV1RunnersJobsJobUUIDCancelGet**](RunnerJobsApi.md#apiv1runnersjobsjobuuidcancelget) | **GET** /api/v1/runners/jobs/{jobUUID}/cancel | Cancel a job |
| [**ApiV1RunnersJobsJobUUIDDelete**](RunnerJobsApi.md#apiv1runnersjobsjobuuiddelete) | **DELETE** /api/v1/runners/jobs/{jobUUID} | Delete a job |
| [**ApiV1RunnersJobsJobUUIDErrorPost**](RunnerJobsApi.md#apiv1runnersjobsjobuuiderrorpost) | **POST** /api/v1/runners/jobs/{jobUUID}/error | Post job error |
| [**ApiV1RunnersJobsJobUUIDSuccessPost**](RunnerJobsApi.md#apiv1runnersjobsjobuuidsuccesspost) | **POST** /api/v1/runners/jobs/{jobUUID}/success | Post job success |
| [**ApiV1RunnersJobsJobUUIDUpdatePost**](RunnerJobsApi.md#apiv1runnersjobsjobuuidupdatepost) | **POST** /api/v1/runners/jobs/{jobUUID}/update | Update job |
| [**ApiV1RunnersJobsRequestPost**](RunnerJobsApi.md#apiv1runnersjobsrequestpost) | **POST** /api/v1/runners/jobs/request | Request a new job |

<a id="apiv1runnersjobsget"></a>
# **ApiV1RunnersJobsGet**
> ApiV1RunnersJobsGet200Response ApiV1RunnersJobsGet (int? start = null, int? count = null, string? sort = null, string? search = null, List<RunnerJobState>? stateOneOf = null)

List jobs

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersJobsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RunnerJobsApi(config);
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = "updatedAt";  // string? | Sort runner jobs by criteria (optional) 
            var search = "search_example";  // string? | Plain text search, applied to various parts of the model depending on endpoint (optional) 
            var stateOneOf = new List<RunnerJobState>?(); // List<RunnerJobState>? |  (optional) 

            try
            {
                // List jobs
                ApiV1RunnersJobsGet200Response result = apiInstance.ApiV1RunnersJobsGet(start, count, sort, search, stateOneOf);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersJobsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List jobs
    ApiResponse<ApiV1RunnersJobsGet200Response> response = apiInstance.ApiV1RunnersJobsGetWithHttpInfo(start, count, sort, search, stateOneOf);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort runner jobs by criteria | [optional]  |
| **search** | **string?** | Plain text search, applied to various parts of the model depending on endpoint | [optional]  |
| **stateOneOf** | [**List&lt;RunnerJobState&gt;?**](RunnerJobState.md) |  | [optional]  |

### Return type

[**ApiV1RunnersJobsGet200Response**](ApiV1RunnersJobsGet200Response.md)

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

<a id="apiv1runnersjobsjobuuidabortpost"></a>
# **ApiV1RunnersJobsJobUUIDAbortPost**
> void ApiV1RunnersJobsJobUUIDAbortPost (Guid jobUUID, ApiV1RunnersJobsJobUUIDAbortPostRequest? apiV1RunnersJobsJobUUIDAbortPostRequest = null)

Abort job

API used by PeerTube runners

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersJobsJobUUIDAbortPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new RunnerJobsApi(config);
            var jobUUID = "jobUUID_example";  // Guid | 
            var apiV1RunnersJobsJobUUIDAbortPostRequest = new ApiV1RunnersJobsJobUUIDAbortPostRequest?(); // ApiV1RunnersJobsJobUUIDAbortPostRequest? |  (optional) 

            try
            {
                // Abort job
                apiInstance.ApiV1RunnersJobsJobUUIDAbortPost(jobUUID, apiV1RunnersJobsJobUUIDAbortPostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsJobUUIDAbortPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersJobsJobUUIDAbortPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Abort job
    apiInstance.ApiV1RunnersJobsJobUUIDAbortPostWithHttpInfo(jobUUID, apiV1RunnersJobsJobUUIDAbortPostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsJobUUIDAbortPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **jobUUID** | **Guid** |  |  |
| **apiV1RunnersJobsJobUUIDAbortPostRequest** | [**ApiV1RunnersJobsJobUUIDAbortPostRequest?**](ApiV1RunnersJobsJobUUIDAbortPostRequest?.md) |  | [optional]  |

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

<a id="apiv1runnersjobsjobuuidacceptpost"></a>
# **ApiV1RunnersJobsJobUUIDAcceptPost**
> ApiV1RunnersJobsJobUUIDAcceptPost200Response ApiV1RunnersJobsJobUUIDAcceptPost (Guid jobUUID, ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = null)

Accept job

API used by PeerTube runners

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersJobsJobUUIDAcceptPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new RunnerJobsApi(config);
            var jobUUID = "jobUUID_example";  // Guid | 
            var apiV1RunnersUnregisterPostRequest = new ApiV1RunnersUnregisterPostRequest?(); // ApiV1RunnersUnregisterPostRequest? |  (optional) 

            try
            {
                // Accept job
                ApiV1RunnersJobsJobUUIDAcceptPost200Response result = apiInstance.ApiV1RunnersJobsJobUUIDAcceptPost(jobUUID, apiV1RunnersUnregisterPostRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsJobUUIDAcceptPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersJobsJobUUIDAcceptPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Accept job
    ApiResponse<ApiV1RunnersJobsJobUUIDAcceptPost200Response> response = apiInstance.ApiV1RunnersJobsJobUUIDAcceptPostWithHttpInfo(jobUUID, apiV1RunnersUnregisterPostRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsJobUUIDAcceptPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **jobUUID** | **Guid** |  |  |
| **apiV1RunnersUnregisterPostRequest** | [**ApiV1RunnersUnregisterPostRequest?**](ApiV1RunnersUnregisterPostRequest?.md) |  | [optional]  |

### Return type

[**ApiV1RunnersJobsJobUUIDAcceptPost200Response**](ApiV1RunnersJobsJobUUIDAcceptPost200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1runnersjobsjobuuidcancelget"></a>
# **ApiV1RunnersJobsJobUUIDCancelGet**
> void ApiV1RunnersJobsJobUUIDCancelGet (Guid jobUUID)

Cancel a job

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersJobsJobUUIDCancelGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RunnerJobsApi(config);
            var jobUUID = "jobUUID_example";  // Guid | 

            try
            {
                // Cancel a job
                apiInstance.ApiV1RunnersJobsJobUUIDCancelGet(jobUUID);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsJobUUIDCancelGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersJobsJobUUIDCancelGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Cancel a job
    apiInstance.ApiV1RunnersJobsJobUUIDCancelGetWithHttpInfo(jobUUID);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsJobUUIDCancelGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **jobUUID** | **Guid** |  |  |

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

<a id="apiv1runnersjobsjobuuiddelete"></a>
# **ApiV1RunnersJobsJobUUIDDelete**
> void ApiV1RunnersJobsJobUUIDDelete (Guid jobUUID)

Delete a job

The endpoint will first cancel the job if needed, and then remove it from the database. Children jobs will also be removed

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersJobsJobUUIDDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RunnerJobsApi(config);
            var jobUUID = "jobUUID_example";  // Guid | 

            try
            {
                // Delete a job
                apiInstance.ApiV1RunnersJobsJobUUIDDelete(jobUUID);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsJobUUIDDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersJobsJobUUIDDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a job
    apiInstance.ApiV1RunnersJobsJobUUIDDeleteWithHttpInfo(jobUUID);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsJobUUIDDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **jobUUID** | **Guid** |  |  |

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

<a id="apiv1runnersjobsjobuuiderrorpost"></a>
# **ApiV1RunnersJobsJobUUIDErrorPost**
> void ApiV1RunnersJobsJobUUIDErrorPost (Guid jobUUID, ApiV1RunnersJobsJobUUIDErrorPostRequest? apiV1RunnersJobsJobUUIDErrorPostRequest = null)

Post job error

API used by PeerTube runners

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersJobsJobUUIDErrorPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new RunnerJobsApi(config);
            var jobUUID = "jobUUID_example";  // Guid | 
            var apiV1RunnersJobsJobUUIDErrorPostRequest = new ApiV1RunnersJobsJobUUIDErrorPostRequest?(); // ApiV1RunnersJobsJobUUIDErrorPostRequest? |  (optional) 

            try
            {
                // Post job error
                apiInstance.ApiV1RunnersJobsJobUUIDErrorPost(jobUUID, apiV1RunnersJobsJobUUIDErrorPostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsJobUUIDErrorPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersJobsJobUUIDErrorPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Post job error
    apiInstance.ApiV1RunnersJobsJobUUIDErrorPostWithHttpInfo(jobUUID, apiV1RunnersJobsJobUUIDErrorPostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsJobUUIDErrorPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **jobUUID** | **Guid** |  |  |
| **apiV1RunnersJobsJobUUIDErrorPostRequest** | [**ApiV1RunnersJobsJobUUIDErrorPostRequest?**](ApiV1RunnersJobsJobUUIDErrorPostRequest?.md) |  | [optional]  |

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

<a id="apiv1runnersjobsjobuuidsuccesspost"></a>
# **ApiV1RunnersJobsJobUUIDSuccessPost**
> void ApiV1RunnersJobsJobUUIDSuccessPost (Guid jobUUID, ApiV1RunnersJobsJobUUIDSuccessPostRequest? apiV1RunnersJobsJobUUIDSuccessPostRequest = null)

Post job success

API used by PeerTube runners

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersJobsJobUUIDSuccessPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new RunnerJobsApi(config);
            var jobUUID = "jobUUID_example";  // Guid | 
            var apiV1RunnersJobsJobUUIDSuccessPostRequest = new ApiV1RunnersJobsJobUUIDSuccessPostRequest?(); // ApiV1RunnersJobsJobUUIDSuccessPostRequest? |  (optional) 

            try
            {
                // Post job success
                apiInstance.ApiV1RunnersJobsJobUUIDSuccessPost(jobUUID, apiV1RunnersJobsJobUUIDSuccessPostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsJobUUIDSuccessPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersJobsJobUUIDSuccessPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Post job success
    apiInstance.ApiV1RunnersJobsJobUUIDSuccessPostWithHttpInfo(jobUUID, apiV1RunnersJobsJobUUIDSuccessPostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsJobUUIDSuccessPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **jobUUID** | **Guid** |  |  |
| **apiV1RunnersJobsJobUUIDSuccessPostRequest** | [**ApiV1RunnersJobsJobUUIDSuccessPostRequest?**](ApiV1RunnersJobsJobUUIDSuccessPostRequest?.md) |  | [optional]  |

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

<a id="apiv1runnersjobsjobuuidupdatepost"></a>
# **ApiV1RunnersJobsJobUUIDUpdatePost**
> void ApiV1RunnersJobsJobUUIDUpdatePost (Guid jobUUID, ApiV1RunnersJobsJobUUIDUpdatePostRequest? apiV1RunnersJobsJobUUIDUpdatePostRequest = null)

Update job

API used by PeerTube runners

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersJobsJobUUIDUpdatePostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new RunnerJobsApi(config);
            var jobUUID = "jobUUID_example";  // Guid | 
            var apiV1RunnersJobsJobUUIDUpdatePostRequest = new ApiV1RunnersJobsJobUUIDUpdatePostRequest?(); // ApiV1RunnersJobsJobUUIDUpdatePostRequest? |  (optional) 

            try
            {
                // Update job
                apiInstance.ApiV1RunnersJobsJobUUIDUpdatePost(jobUUID, apiV1RunnersJobsJobUUIDUpdatePostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsJobUUIDUpdatePost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersJobsJobUUIDUpdatePostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update job
    apiInstance.ApiV1RunnersJobsJobUUIDUpdatePostWithHttpInfo(jobUUID, apiV1RunnersJobsJobUUIDUpdatePostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsJobUUIDUpdatePostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **jobUUID** | **Guid** |  |  |
| **apiV1RunnersJobsJobUUIDUpdatePostRequest** | [**ApiV1RunnersJobsJobUUIDUpdatePostRequest?**](ApiV1RunnersJobsJobUUIDUpdatePostRequest?.md) |  | [optional]  |

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

<a id="apiv1runnersjobsrequestpost"></a>
# **ApiV1RunnersJobsRequestPost**
> ApiV1RunnersJobsRequestPost200Response ApiV1RunnersJobsRequestPost (ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = null)

Request a new job

API used by PeerTube runners

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1RunnersJobsRequestPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new RunnerJobsApi(config);
            var apiV1RunnersUnregisterPostRequest = new ApiV1RunnersUnregisterPostRequest?(); // ApiV1RunnersUnregisterPostRequest? |  (optional) 

            try
            {
                // Request a new job
                ApiV1RunnersJobsRequestPost200Response result = apiInstance.ApiV1RunnersJobsRequestPost(apiV1RunnersUnregisterPostRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsRequestPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1RunnersJobsRequestPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Request a new job
    ApiResponse<ApiV1RunnersJobsRequestPost200Response> response = apiInstance.ApiV1RunnersJobsRequestPostWithHttpInfo(apiV1RunnersUnregisterPostRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RunnerJobsApi.ApiV1RunnersJobsRequestPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **apiV1RunnersUnregisterPostRequest** | [**ApiV1RunnersUnregisterPostRequest?**](ApiV1RunnersUnregisterPostRequest?.md) |  | [optional]  |

### Return type

[**ApiV1RunnersJobsRequestPost200Response**](ApiV1RunnersJobsRequestPost200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

