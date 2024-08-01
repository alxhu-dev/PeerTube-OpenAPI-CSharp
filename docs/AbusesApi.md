# PeerTubeApiClient.Api.AbusesApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1AbusesAbuseIdDelete**](AbusesApi.md#apiv1abusesabuseiddelete) | **DELETE** /api/v1/abuses/{abuseId} | Delete an abuse |
| [**ApiV1AbusesAbuseIdMessagesAbuseMessageIdDelete**](AbusesApi.md#apiv1abusesabuseidmessagesabusemessageiddelete) | **DELETE** /api/v1/abuses/{abuseId}/messages/{abuseMessageId} | Delete an abuse message |
| [**ApiV1AbusesAbuseIdMessagesGet**](AbusesApi.md#apiv1abusesabuseidmessagesget) | **GET** /api/v1/abuses/{abuseId}/messages | List messages of an abuse |
| [**ApiV1AbusesAbuseIdMessagesPost**](AbusesApi.md#apiv1abusesabuseidmessagespost) | **POST** /api/v1/abuses/{abuseId}/messages | Add message to an abuse |
| [**ApiV1AbusesAbuseIdPut**](AbusesApi.md#apiv1abusesabuseidput) | **PUT** /api/v1/abuses/{abuseId} | Update an abuse |
| [**ApiV1AbusesPost**](AbusesApi.md#apiv1abusespost) | **POST** /api/v1/abuses | Report an abuse |
| [**GetAbuses**](AbusesApi.md#getabuses) | **GET** /api/v1/abuses | List abuses |
| [**GetMyAbuses**](AbusesApi.md#getmyabuses) | **GET** /api/v1/users/me/abuses | List my abuses |

<a id="apiv1abusesabuseiddelete"></a>
# **ApiV1AbusesAbuseIdDelete**
> void ApiV1AbusesAbuseIdDelete (int abuseId)

Delete an abuse

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1AbusesAbuseIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AbusesApi(config);
            var abuseId = 56;  // int | Abuse id

            try
            {
                // Delete an abuse
                apiInstance.ApiV1AbusesAbuseIdDelete(abuseId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AbusesApi.ApiV1AbusesAbuseIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AbusesAbuseIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete an abuse
    apiInstance.ApiV1AbusesAbuseIdDeleteWithHttpInfo(abuseId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AbusesApi.ApiV1AbusesAbuseIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **abuseId** | **int** | Abuse id |  |

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
| **404** | block not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1abusesabuseidmessagesabusemessageiddelete"></a>
# **ApiV1AbusesAbuseIdMessagesAbuseMessageIdDelete**
> void ApiV1AbusesAbuseIdMessagesAbuseMessageIdDelete (int abuseId, int abuseMessageId)

Delete an abuse message

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1AbusesAbuseIdMessagesAbuseMessageIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AbusesApi(config);
            var abuseId = 56;  // int | Abuse id
            var abuseMessageId = 56;  // int | Abuse message id

            try
            {
                // Delete an abuse message
                apiInstance.ApiV1AbusesAbuseIdMessagesAbuseMessageIdDelete(abuseId, abuseMessageId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AbusesApi.ApiV1AbusesAbuseIdMessagesAbuseMessageIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AbusesAbuseIdMessagesAbuseMessageIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete an abuse message
    apiInstance.ApiV1AbusesAbuseIdMessagesAbuseMessageIdDeleteWithHttpInfo(abuseId, abuseMessageId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AbusesApi.ApiV1AbusesAbuseIdMessagesAbuseMessageIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **abuseId** | **int** | Abuse id |  |
| **abuseMessageId** | **int** | Abuse message id |  |

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

<a id="apiv1abusesabuseidmessagesget"></a>
# **ApiV1AbusesAbuseIdMessagesGet**
> ApiV1AbusesAbuseIdMessagesGet200Response ApiV1AbusesAbuseIdMessagesGet (int abuseId)

List messages of an abuse

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1AbusesAbuseIdMessagesGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AbusesApi(config);
            var abuseId = 56;  // int | Abuse id

            try
            {
                // List messages of an abuse
                ApiV1AbusesAbuseIdMessagesGet200Response result = apiInstance.ApiV1AbusesAbuseIdMessagesGet(abuseId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AbusesApi.ApiV1AbusesAbuseIdMessagesGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AbusesAbuseIdMessagesGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List messages of an abuse
    ApiResponse<ApiV1AbusesAbuseIdMessagesGet200Response> response = apiInstance.ApiV1AbusesAbuseIdMessagesGetWithHttpInfo(abuseId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AbusesApi.ApiV1AbusesAbuseIdMessagesGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **abuseId** | **int** | Abuse id |  |

### Return type

[**ApiV1AbusesAbuseIdMessagesGet200Response**](ApiV1AbusesAbuseIdMessagesGet200Response.md)

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

<a id="apiv1abusesabuseidmessagespost"></a>
# **ApiV1AbusesAbuseIdMessagesPost**
> void ApiV1AbusesAbuseIdMessagesPost (int abuseId, ApiV1AbusesAbuseIdMessagesPostRequest apiV1AbusesAbuseIdMessagesPostRequest)

Add message to an abuse

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1AbusesAbuseIdMessagesPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AbusesApi(config);
            var abuseId = 56;  // int | Abuse id
            var apiV1AbusesAbuseIdMessagesPostRequest = new ApiV1AbusesAbuseIdMessagesPostRequest(); // ApiV1AbusesAbuseIdMessagesPostRequest | 

            try
            {
                // Add message to an abuse
                apiInstance.ApiV1AbusesAbuseIdMessagesPost(abuseId, apiV1AbusesAbuseIdMessagesPostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AbusesApi.ApiV1AbusesAbuseIdMessagesPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AbusesAbuseIdMessagesPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Add message to an abuse
    apiInstance.ApiV1AbusesAbuseIdMessagesPostWithHttpInfo(abuseId, apiV1AbusesAbuseIdMessagesPostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AbusesApi.ApiV1AbusesAbuseIdMessagesPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **abuseId** | **int** | Abuse id |  |
| **apiV1AbusesAbuseIdMessagesPostRequest** | [**ApiV1AbusesAbuseIdMessagesPostRequest**](ApiV1AbusesAbuseIdMessagesPostRequest.md) |  |  |

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
| **200** | successful operation |  -  |
| **400** | incorrect request parameters |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1abusesabuseidput"></a>
# **ApiV1AbusesAbuseIdPut**
> void ApiV1AbusesAbuseIdPut (int abuseId, ApiV1AbusesAbuseIdPutRequest? apiV1AbusesAbuseIdPutRequest = null)

Update an abuse

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1AbusesAbuseIdPutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AbusesApi(config);
            var abuseId = 56;  // int | Abuse id
            var apiV1AbusesAbuseIdPutRequest = new ApiV1AbusesAbuseIdPutRequest?(); // ApiV1AbusesAbuseIdPutRequest? |  (optional) 

            try
            {
                // Update an abuse
                apiInstance.ApiV1AbusesAbuseIdPut(abuseId, apiV1AbusesAbuseIdPutRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AbusesApi.ApiV1AbusesAbuseIdPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AbusesAbuseIdPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update an abuse
    apiInstance.ApiV1AbusesAbuseIdPutWithHttpInfo(abuseId, apiV1AbusesAbuseIdPutRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AbusesApi.ApiV1AbusesAbuseIdPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **abuseId** | **int** | Abuse id |  |
| **apiV1AbusesAbuseIdPutRequest** | [**ApiV1AbusesAbuseIdPutRequest?**](ApiV1AbusesAbuseIdPutRequest?.md) |  | [optional]  |

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
| **404** | abuse not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1abusespost"></a>
# **ApiV1AbusesPost**
> ApiV1AbusesPost200Response ApiV1AbusesPost (ApiV1AbusesPostRequest apiV1AbusesPostRequest)

Report an abuse

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1AbusesPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AbusesApi(config);
            var apiV1AbusesPostRequest = new ApiV1AbusesPostRequest(); // ApiV1AbusesPostRequest | 

            try
            {
                // Report an abuse
                ApiV1AbusesPost200Response result = apiInstance.ApiV1AbusesPost(apiV1AbusesPostRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AbusesApi.ApiV1AbusesPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AbusesPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Report an abuse
    ApiResponse<ApiV1AbusesPost200Response> response = apiInstance.ApiV1AbusesPostWithHttpInfo(apiV1AbusesPostRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AbusesApi.ApiV1AbusesPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **apiV1AbusesPostRequest** | [**ApiV1AbusesPostRequest**](ApiV1AbusesPostRequest.md) |  |  |

### Return type

[**ApiV1AbusesPost200Response**](ApiV1AbusesPost200Response.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | incorrect request parameters |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getabuses"></a>
# **GetAbuses**
> GetMyAbuses200Response GetAbuses (int? id = null, List<string>? predefinedReason = null, string? search = null, AbuseStateSet? state = null, string? searchReporter = null, string? searchReportee = null, string? searchVideo = null, string? searchVideoChannel = null, string? videoIs = null, string? filter = null, int? start = null, int? count = null, string? sort = null)

List abuses

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetAbusesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AbusesApi(config);
            var id = 56;  // int? | only list the report with this id (optional) 
            var predefinedReason = new List<string>?(); // List<string>? | predefined reason the listed reports should contain (optional) 
            var search = "search_example";  // string? | plain search that will match with video titles, reporter names and more (optional) 
            var state = new AbuseStateSet?(); // AbuseStateSet? |  (optional) 
            var searchReporter = "searchReporter_example";  // string? | only list reports of a specific reporter (optional) 
            var searchReportee = "searchReportee_example";  // string? | only list reports of a specific reportee (optional) 
            var searchVideo = "searchVideo_example";  // string? | only list reports of a specific video (optional) 
            var searchVideoChannel = "searchVideoChannel_example";  // string? | only list reports of a specific video channel (optional) 
            var videoIs = "deleted";  // string? | only list deleted or blocklisted videos (optional) 
            var filter = "video";  // string? | only list account, comment or video reports (optional) 
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = "-id";  // string? | Sort abuses by criteria (optional) 

            try
            {
                // List abuses
                GetMyAbuses200Response result = apiInstance.GetAbuses(id, predefinedReason, search, state, searchReporter, searchReportee, searchVideo, searchVideoChannel, videoIs, filter, start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AbusesApi.GetAbuses: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAbusesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List abuses
    ApiResponse<GetMyAbuses200Response> response = apiInstance.GetAbusesWithHttpInfo(id, predefinedReason, search, state, searchReporter, searchReportee, searchVideo, searchVideoChannel, videoIs, filter, start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AbusesApi.GetAbusesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int?** | only list the report with this id | [optional]  |
| **predefinedReason** | [**List&lt;string&gt;?**](string.md) | predefined reason the listed reports should contain | [optional]  |
| **search** | **string?** | plain search that will match with video titles, reporter names and more | [optional]  |
| **state** | [**AbuseStateSet?**](AbuseStateSet?.md) |  | [optional]  |
| **searchReporter** | **string?** | only list reports of a specific reporter | [optional]  |
| **searchReportee** | **string?** | only list reports of a specific reportee | [optional]  |
| **searchVideo** | **string?** | only list reports of a specific video | [optional]  |
| **searchVideoChannel** | **string?** | only list reports of a specific video channel | [optional]  |
| **videoIs** | **string?** | only list deleted or blocklisted videos | [optional]  |
| **filter** | **string?** | only list account, comment or video reports | [optional]  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort abuses by criteria | [optional]  |

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

            var apiInstance = new AbusesApi(config);
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
                Debug.Print("Exception when calling AbusesApi.GetMyAbuses: " + e.Message);
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
    Debug.Print("Exception when calling AbusesApi.GetMyAbusesWithHttpInfo: " + e.Message);
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

