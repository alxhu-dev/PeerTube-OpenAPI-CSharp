# PeerTubeApiClient.Api.ServerBlocksApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1BlocklistStatusGet**](ServerBlocksApi.md#apiv1blockliststatusget) | **GET** /api/v1/blocklist/status | Get block status of accounts/hosts |
| [**ApiV1ServerBlocklistServersGet**](ServerBlocksApi.md#apiv1serverblocklistserversget) | **GET** /api/v1/server/blocklist/servers | List server blocks |
| [**ApiV1ServerBlocklistServersHostDelete**](ServerBlocksApi.md#apiv1serverblocklistservershostdelete) | **DELETE** /api/v1/server/blocklist/servers/{host} | Unblock a server by its domain |
| [**ApiV1ServerBlocklistServersPost**](ServerBlocksApi.md#apiv1serverblocklistserverspost) | **POST** /api/v1/server/blocklist/servers | Block a server |

<a id="apiv1blockliststatusget"></a>
# **ApiV1BlocklistStatusGet**
> BlockStatus ApiV1BlocklistStatusGet (List<string>? accounts = null, List<string>? hosts = null)

Get block status of accounts/hosts

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1BlocklistStatusGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new ServerBlocksApi(config);
            var accounts = new List<string>?(); // List<string>? | Check if these accounts are blocked (optional) 
            var hosts = new List<string>?(); // List<string>? | Check if these hosts are blocked (optional) 

            try
            {
                // Get block status of accounts/hosts
                BlockStatus result = apiInstance.ApiV1BlocklistStatusGet(accounts, hosts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ServerBlocksApi.ApiV1BlocklistStatusGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1BlocklistStatusGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get block status of accounts/hosts
    ApiResponse<BlockStatus> response = apiInstance.ApiV1BlocklistStatusGetWithHttpInfo(accounts, hosts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ServerBlocksApi.ApiV1BlocklistStatusGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **accounts** | [**List&lt;string&gt;?**](string.md) | Check if these accounts are blocked | [optional]  |
| **hosts** | [**List&lt;string&gt;?**](string.md) | Check if these hosts are blocked | [optional]  |

### Return type

[**BlockStatus**](BlockStatus.md)

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

<a id="apiv1serverblocklistserversget"></a>
# **ApiV1ServerBlocklistServersGet**
> void ApiV1ServerBlocklistServersGet (int? start = null, int? count = null, string? sort = null)

List server blocks

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ServerBlocklistServersGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ServerBlocksApi(config);
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List server blocks
                apiInstance.ApiV1ServerBlocklistServersGet(start, count, sort);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ServerBlocksApi.ApiV1ServerBlocklistServersGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ServerBlocklistServersGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List server blocks
    apiInstance.ApiV1ServerBlocklistServersGetWithHttpInfo(start, count, sort);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ServerBlocksApi.ApiV1ServerBlocklistServersGetWithHttpInfo: " + e.Message);
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

void (empty response body)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1serverblocklistservershostdelete"></a>
# **ApiV1ServerBlocklistServersHostDelete**
> void ApiV1ServerBlocklistServersHostDelete (string host)

Unblock a server by its domain

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ServerBlocklistServersHostDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ServerBlocksApi(config);
            var host = "host_example";  // string | server domain to unblock

            try
            {
                // Unblock a server by its domain
                apiInstance.ApiV1ServerBlocklistServersHostDelete(host);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ServerBlocksApi.ApiV1ServerBlocklistServersHostDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ServerBlocklistServersHostDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Unblock a server by its domain
    apiInstance.ApiV1ServerBlocklistServersHostDeleteWithHttpInfo(host);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ServerBlocksApi.ApiV1ServerBlocklistServersHostDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **host** | **string** | server domain to unblock |  |

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
| **404** | account block does not exist |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1serverblocklistserverspost"></a>
# **ApiV1ServerBlocklistServersPost**
> void ApiV1ServerBlocklistServersPost (ApiV1ServerBlocklistServersPostRequest? apiV1ServerBlocklistServersPostRequest = null)

Block a server

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ServerBlocklistServersPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ServerBlocksApi(config);
            var apiV1ServerBlocklistServersPostRequest = new ApiV1ServerBlocklistServersPostRequest?(); // ApiV1ServerBlocklistServersPostRequest? |  (optional) 

            try
            {
                // Block a server
                apiInstance.ApiV1ServerBlocklistServersPost(apiV1ServerBlocklistServersPostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ServerBlocksApi.ApiV1ServerBlocklistServersPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ServerBlocklistServersPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Block a server
    apiInstance.ApiV1ServerBlocklistServersPostWithHttpInfo(apiV1ServerBlocklistServersPostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ServerBlocksApi.ApiV1ServerBlocklistServersPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **apiV1ServerBlocklistServersPostRequest** | [**ApiV1ServerBlocklistServersPostRequest?**](ApiV1ServerBlocklistServersPostRequest?.md) |  | [optional]  |

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
| **409** | self-blocking forbidden |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

