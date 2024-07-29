# PeerTubeApiClient.Api.WatchedWordsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1WatchedWordsAccountsAccountNameListsGet**](WatchedWordsApi.md#apiv1watchedwordsaccountsaccountnamelistsget) | **GET** /api/v1/watched-words/accounts/{accountName}/lists | List account watched words |
| [**ApiV1WatchedWordsAccountsAccountNameListsListIdDelete**](WatchedWordsApi.md#apiv1watchedwordsaccountsaccountnamelistslistiddelete) | **DELETE** /api/v1/watched-words/accounts/{accountName}/lists/{listId} | Delete account watched words |
| [**ApiV1WatchedWordsAccountsAccountNameListsListIdPut**](WatchedWordsApi.md#apiv1watchedwordsaccountsaccountnamelistslistidput) | **PUT** /api/v1/watched-words/accounts/{accountName}/lists/{listId} | Update account watched words |
| [**ApiV1WatchedWordsAccountsAccountNameListsPost**](WatchedWordsApi.md#apiv1watchedwordsaccountsaccountnamelistspost) | **POST** /api/v1/watched-words/accounts/{accountName}/lists | Add account watched words |
| [**ApiV1WatchedWordsServerListsGet**](WatchedWordsApi.md#apiv1watchedwordsserverlistsget) | **GET** /api/v1/watched-words/server/lists | List server watched words |
| [**ApiV1WatchedWordsServerListsListIdDelete**](WatchedWordsApi.md#apiv1watchedwordsserverlistslistiddelete) | **DELETE** /api/v1/watched-words/server/lists/{listId} | Delete server watched words |
| [**ApiV1WatchedWordsServerListsListIdPut**](WatchedWordsApi.md#apiv1watchedwordsserverlistslistidput) | **PUT** /api/v1/watched-words/server/lists/{listId} | Update server watched words |
| [**ApiV1WatchedWordsServerListsPost**](WatchedWordsApi.md#apiv1watchedwordsserverlistspost) | **POST** /api/v1/watched-words/server/lists | Add server watched words |

<a id="apiv1watchedwordsaccountsaccountnamelistsget"></a>
# **ApiV1WatchedWordsAccountsAccountNameListsGet**
> ApiV1WatchedWordsAccountsAccountNameListsGet200Response ApiV1WatchedWordsAccountsAccountNameListsGet (string accountName)

List account watched words

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
    public class ApiV1WatchedWordsAccountsAccountNameListsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WatchedWordsApi(config);
            var accountName = "accountName_example";  // string | account name to list watched words

            try
            {
                // List account watched words
                ApiV1WatchedWordsAccountsAccountNameListsGet200Response result = apiInstance.ApiV1WatchedWordsAccountsAccountNameListsGet(accountName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1WatchedWordsAccountsAccountNameListsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List account watched words
    ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsGet200Response> response = apiInstance.ApiV1WatchedWordsAccountsAccountNameListsGetWithHttpInfo(accountName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **accountName** | **string** | account name to list watched words |  |

### Return type

[**ApiV1WatchedWordsAccountsAccountNameListsGet200Response**](ApiV1WatchedWordsAccountsAccountNameListsGet200Response.md)

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

<a id="apiv1watchedwordsaccountsaccountnamelistslistiddelete"></a>
# **ApiV1WatchedWordsAccountsAccountNameListsListIdDelete**
> void ApiV1WatchedWordsAccountsAccountNameListsListIdDelete (string accountName, string listId)

Delete account watched words

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
    public class ApiV1WatchedWordsAccountsAccountNameListsListIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WatchedWordsApi(config);
            var accountName = "accountName_example";  // string | 
            var listId = "listId_example";  // string | list of watched words to delete

            try
            {
                // Delete account watched words
                apiInstance.ApiV1WatchedWordsAccountsAccountNameListsListIdDelete(accountName, listId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsListIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1WatchedWordsAccountsAccountNameListsListIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete account watched words
    apiInstance.ApiV1WatchedWordsAccountsAccountNameListsListIdDeleteWithHttpInfo(accountName, listId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsListIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **accountName** | **string** |  |  |
| **listId** | **string** | list of watched words to delete |  |

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

<a id="apiv1watchedwordsaccountsaccountnamelistslistidput"></a>
# **ApiV1WatchedWordsAccountsAccountNameListsListIdPut**
> void ApiV1WatchedWordsAccountsAccountNameListsListIdPut (string accountName, string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = null)

Update account watched words

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
    public class ApiV1WatchedWordsAccountsAccountNameListsListIdPutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WatchedWordsApi(config);
            var accountName = "accountName_example";  // string | 
            var listId = "listId_example";  // string | list of watched words to update
            var apiV1WatchedWordsAccountsAccountNameListsPostRequest = new ApiV1WatchedWordsAccountsAccountNameListsPostRequest?(); // ApiV1WatchedWordsAccountsAccountNameListsPostRequest? |  (optional) 

            try
            {
                // Update account watched words
                apiInstance.ApiV1WatchedWordsAccountsAccountNameListsListIdPut(accountName, listId, apiV1WatchedWordsAccountsAccountNameListsPostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsListIdPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1WatchedWordsAccountsAccountNameListsListIdPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update account watched words
    apiInstance.ApiV1WatchedWordsAccountsAccountNameListsListIdPutWithHttpInfo(accountName, listId, apiV1WatchedWordsAccountsAccountNameListsPostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsListIdPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **accountName** | **string** |  |  |
| **listId** | **string** | list of watched words to update |  |
| **apiV1WatchedWordsAccountsAccountNameListsPostRequest** | [**ApiV1WatchedWordsAccountsAccountNameListsPostRequest?**](ApiV1WatchedWordsAccountsAccountNameListsPostRequest?.md) |  | [optional]  |

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

<a id="apiv1watchedwordsaccountsaccountnamelistspost"></a>
# **ApiV1WatchedWordsAccountsAccountNameListsPost**
> ApiV1WatchedWordsAccountsAccountNameListsPost200Response ApiV1WatchedWordsAccountsAccountNameListsPost (string accountName, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = null)

Add account watched words

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
    public class ApiV1WatchedWordsAccountsAccountNameListsPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WatchedWordsApi(config);
            var accountName = "accountName_example";  // string | 
            var apiV1WatchedWordsAccountsAccountNameListsPostRequest = new ApiV1WatchedWordsAccountsAccountNameListsPostRequest?(); // ApiV1WatchedWordsAccountsAccountNameListsPostRequest? |  (optional) 

            try
            {
                // Add account watched words
                ApiV1WatchedWordsAccountsAccountNameListsPost200Response result = apiInstance.ApiV1WatchedWordsAccountsAccountNameListsPost(accountName, apiV1WatchedWordsAccountsAccountNameListsPostRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1WatchedWordsAccountsAccountNameListsPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Add account watched words
    ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsPost200Response> response = apiInstance.ApiV1WatchedWordsAccountsAccountNameListsPostWithHttpInfo(accountName, apiV1WatchedWordsAccountsAccountNameListsPostRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **accountName** | **string** |  |  |
| **apiV1WatchedWordsAccountsAccountNameListsPostRequest** | [**ApiV1WatchedWordsAccountsAccountNameListsPostRequest?**](ApiV1WatchedWordsAccountsAccountNameListsPostRequest?.md) |  | [optional]  |

### Return type

[**ApiV1WatchedWordsAccountsAccountNameListsPost200Response**](ApiV1WatchedWordsAccountsAccountNameListsPost200Response.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1watchedwordsserverlistsget"></a>
# **ApiV1WatchedWordsServerListsGet**
> ApiV1WatchedWordsAccountsAccountNameListsGet200Response ApiV1WatchedWordsServerListsGet ()

List server watched words

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
    public class ApiV1WatchedWordsServerListsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WatchedWordsApi(config);

            try
            {
                // List server watched words
                ApiV1WatchedWordsAccountsAccountNameListsGet200Response result = apiInstance.ApiV1WatchedWordsServerListsGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsServerListsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1WatchedWordsServerListsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List server watched words
    ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsGet200Response> response = apiInstance.ApiV1WatchedWordsServerListsGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsServerListsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**ApiV1WatchedWordsAccountsAccountNameListsGet200Response**](ApiV1WatchedWordsAccountsAccountNameListsGet200Response.md)

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

<a id="apiv1watchedwordsserverlistslistiddelete"></a>
# **ApiV1WatchedWordsServerListsListIdDelete**
> void ApiV1WatchedWordsServerListsListIdDelete (string listId)

Delete server watched words

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
    public class ApiV1WatchedWordsServerListsListIdDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WatchedWordsApi(config);
            var listId = "listId_example";  // string | list of watched words to delete

            try
            {
                // Delete server watched words
                apiInstance.ApiV1WatchedWordsServerListsListIdDelete(listId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsServerListsListIdDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1WatchedWordsServerListsListIdDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete server watched words
    apiInstance.ApiV1WatchedWordsServerListsListIdDeleteWithHttpInfo(listId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsServerListsListIdDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **listId** | **string** | list of watched words to delete |  |

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

<a id="apiv1watchedwordsserverlistslistidput"></a>
# **ApiV1WatchedWordsServerListsListIdPut**
> void ApiV1WatchedWordsServerListsListIdPut (string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = null)

Update server watched words

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
    public class ApiV1WatchedWordsServerListsListIdPutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WatchedWordsApi(config);
            var listId = "listId_example";  // string | list of watched words to update
            var apiV1WatchedWordsAccountsAccountNameListsPostRequest = new ApiV1WatchedWordsAccountsAccountNameListsPostRequest?(); // ApiV1WatchedWordsAccountsAccountNameListsPostRequest? |  (optional) 

            try
            {
                // Update server watched words
                apiInstance.ApiV1WatchedWordsServerListsListIdPut(listId, apiV1WatchedWordsAccountsAccountNameListsPostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsServerListsListIdPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1WatchedWordsServerListsListIdPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update server watched words
    apiInstance.ApiV1WatchedWordsServerListsListIdPutWithHttpInfo(listId, apiV1WatchedWordsAccountsAccountNameListsPostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsServerListsListIdPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **listId** | **string** | list of watched words to update |  |
| **apiV1WatchedWordsAccountsAccountNameListsPostRequest** | [**ApiV1WatchedWordsAccountsAccountNameListsPostRequest?**](ApiV1WatchedWordsAccountsAccountNameListsPostRequest?.md) |  | [optional]  |

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

<a id="apiv1watchedwordsserverlistspost"></a>
# **ApiV1WatchedWordsServerListsPost**
> ApiV1WatchedWordsAccountsAccountNameListsPost200Response ApiV1WatchedWordsServerListsPost (ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = null)

Add server watched words

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
    public class ApiV1WatchedWordsServerListsPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WatchedWordsApi(config);
            var apiV1WatchedWordsAccountsAccountNameListsPostRequest = new ApiV1WatchedWordsAccountsAccountNameListsPostRequest?(); // ApiV1WatchedWordsAccountsAccountNameListsPostRequest? |  (optional) 

            try
            {
                // Add server watched words
                ApiV1WatchedWordsAccountsAccountNameListsPost200Response result = apiInstance.ApiV1WatchedWordsServerListsPost(apiV1WatchedWordsAccountsAccountNameListsPostRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsServerListsPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1WatchedWordsServerListsPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Add server watched words
    ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsPost200Response> response = apiInstance.ApiV1WatchedWordsServerListsPostWithHttpInfo(apiV1WatchedWordsAccountsAccountNameListsPostRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WatchedWordsApi.ApiV1WatchedWordsServerListsPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **apiV1WatchedWordsAccountsAccountNameListsPostRequest** | [**ApiV1WatchedWordsAccountsAccountNameListsPostRequest?**](ApiV1WatchedWordsAccountsAccountNameListsPostRequest?.md) |  | [optional]  |

### Return type

[**ApiV1WatchedWordsAccountsAccountNameListsPost200Response**](ApiV1WatchedWordsAccountsAccountNameListsPost200Response.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

