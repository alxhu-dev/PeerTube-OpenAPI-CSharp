# PeerTubeApiClient.Api.AccountBlocksApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1BlocklistStatusGet**](AccountBlocksApi.md#apiv1blockliststatusget) | **GET** /api/v1/blocklist/status | Get block status of accounts/hosts |
| [**ApiV1ServerBlocklistAccountsAccountNameDelete**](AccountBlocksApi.md#apiv1serverblocklistaccountsaccountnamedelete) | **DELETE** /api/v1/server/blocklist/accounts/{accountName} | Unblock an account by its handle |
| [**ApiV1ServerBlocklistAccountsGet**](AccountBlocksApi.md#apiv1serverblocklistaccountsget) | **GET** /api/v1/server/blocklist/accounts | List account blocks |
| [**ApiV1ServerBlocklistAccountsPost**](AccountBlocksApi.md#apiv1serverblocklistaccountspost) | **POST** /api/v1/server/blocklist/accounts | Block an account |

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
            var apiInstance = new AccountBlocksApi(config);
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
                Debug.Print("Exception when calling AccountBlocksApi.ApiV1BlocklistStatusGet: " + e.Message);
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
    Debug.Print("Exception when calling AccountBlocksApi.ApiV1BlocklistStatusGetWithHttpInfo: " + e.Message);
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

<a id="apiv1serverblocklistaccountsaccountnamedelete"></a>
# **ApiV1ServerBlocklistAccountsAccountNameDelete**
> void ApiV1ServerBlocklistAccountsAccountNameDelete (string accountName)

Unblock an account by its handle

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ServerBlocklistAccountsAccountNameDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AccountBlocksApi(config);
            var accountName = "accountName_example";  // string | account to unblock, in the form `username@domain`

            try
            {
                // Unblock an account by its handle
                apiInstance.ApiV1ServerBlocklistAccountsAccountNameDelete(accountName);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountBlocksApi.ApiV1ServerBlocklistAccountsAccountNameDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ServerBlocklistAccountsAccountNameDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Unblock an account by its handle
    apiInstance.ApiV1ServerBlocklistAccountsAccountNameDeleteWithHttpInfo(accountName);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountBlocksApi.ApiV1ServerBlocklistAccountsAccountNameDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **accountName** | **string** | account to unblock, in the form &#x60;username@domain&#x60; |  |

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
| **201** | successful operation |  -  |
| **404** | account or account block does not exist |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1serverblocklistaccountsget"></a>
# **ApiV1ServerBlocklistAccountsGet**
> void ApiV1ServerBlocklistAccountsGet (int? start = null, int? count = null, string? sort = null)

List account blocks

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ServerBlocklistAccountsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AccountBlocksApi(config);
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List account blocks
                apiInstance.ApiV1ServerBlocklistAccountsGet(start, count, sort);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountBlocksApi.ApiV1ServerBlocklistAccountsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ServerBlocklistAccountsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List account blocks
    apiInstance.ApiV1ServerBlocklistAccountsGetWithHttpInfo(start, count, sort);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountBlocksApi.ApiV1ServerBlocklistAccountsGetWithHttpInfo: " + e.Message);
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

<a id="apiv1serverblocklistaccountspost"></a>
# **ApiV1ServerBlocklistAccountsPost**
> void ApiV1ServerBlocklistAccountsPost (ApiV1ServerBlocklistAccountsPostRequest? apiV1ServerBlocklistAccountsPostRequest = null)

Block an account

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ServerBlocklistAccountsPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AccountBlocksApi(config);
            var apiV1ServerBlocklistAccountsPostRequest = new ApiV1ServerBlocklistAccountsPostRequest?(); // ApiV1ServerBlocklistAccountsPostRequest? |  (optional) 

            try
            {
                // Block an account
                apiInstance.ApiV1ServerBlocklistAccountsPost(apiV1ServerBlocklistAccountsPostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountBlocksApi.ApiV1ServerBlocklistAccountsPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ServerBlocklistAccountsPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Block an account
    apiInstance.ApiV1ServerBlocklistAccountsPostWithHttpInfo(apiV1ServerBlocklistAccountsPostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountBlocksApi.ApiV1ServerBlocklistAccountsPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **apiV1ServerBlocklistAccountsPostRequest** | [**ApiV1ServerBlocklistAccountsPostRequest?**](ApiV1ServerBlocklistAccountsPostRequest?.md) |  | [optional]  |

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
| **409** | self-blocking forbidden |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

