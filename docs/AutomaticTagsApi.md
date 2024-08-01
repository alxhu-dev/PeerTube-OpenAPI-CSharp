# PeerTubeApiClient.Api.AutomaticTagsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1AutomaticTagsAccountsAccountNameAvailableGet**](AutomaticTagsApi.md#apiv1automatictagsaccountsaccountnameavailableget) | **GET** /api/v1/automatic-tags/accounts/{accountName}/available | Get account available auto tags |
| [**ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsGet**](AutomaticTagsApi.md#apiv1automatictagspoliciesaccountsaccountnamecommentsget) | **GET** /api/v1/automatic-tags/policies/accounts/{accountName}/comments | Get account auto tag policies on comments |
| [**ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPut**](AutomaticTagsApi.md#apiv1automatictagspoliciesaccountsaccountnamecommentsput) | **PUT** /api/v1/automatic-tags/policies/accounts/{accountName}/comments | Update account auto tag policies on comments |
| [**ApiV1AutomaticTagsServerAvailableGet**](AutomaticTagsApi.md#apiv1automatictagsserveravailableget) | **GET** /api/v1/automatic-tags/server/available | Get server available auto tags |

<a id="apiv1automatictagsaccountsaccountnameavailableget"></a>
# **ApiV1AutomaticTagsAccountsAccountNameAvailableGet**
> AutomaticTagAvailable ApiV1AutomaticTagsAccountsAccountNameAvailableGet (string accountName)

Get account available auto tags

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
    public class ApiV1AutomaticTagsAccountsAccountNameAvailableGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AutomaticTagsApi(config);
            var accountName = "accountName_example";  // string | account name to get auto tag policies

            try
            {
                // Get account available auto tags
                AutomaticTagAvailable result = apiInstance.ApiV1AutomaticTagsAccountsAccountNameAvailableGet(accountName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AutomaticTagsApi.ApiV1AutomaticTagsAccountsAccountNameAvailableGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AutomaticTagsAccountsAccountNameAvailableGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get account available auto tags
    ApiResponse<AutomaticTagAvailable> response = apiInstance.ApiV1AutomaticTagsAccountsAccountNameAvailableGetWithHttpInfo(accountName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AutomaticTagsApi.ApiV1AutomaticTagsAccountsAccountNameAvailableGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **accountName** | **string** | account name to get auto tag policies |  |

### Return type

[**AutomaticTagAvailable**](AutomaticTagAvailable.md)

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

<a id="apiv1automatictagspoliciesaccountsaccountnamecommentsget"></a>
# **ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsGet**
> CommentAutoTagPolicies ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsGet (string accountName)

Get account auto tag policies on comments

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
    public class ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AutomaticTagsApi(config);
            var accountName = "accountName_example";  // string | account name to get auto tag policies

            try
            {
                // Get account auto tag policies on comments
                CommentAutoTagPolicies result = apiInstance.ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsGet(accountName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AutomaticTagsApi.ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get account auto tag policies on comments
    ApiResponse<CommentAutoTagPolicies> response = apiInstance.ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsGetWithHttpInfo(accountName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AutomaticTagsApi.ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **accountName** | **string** | account name to get auto tag policies |  |

### Return type

[**CommentAutoTagPolicies**](CommentAutoTagPolicies.md)

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

<a id="apiv1automatictagspoliciesaccountsaccountnamecommentsput"></a>
# **ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPut**
> void ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPut (string accountName, ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPutRequest? apiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPutRequest = null)

Update account auto tag policies on comments

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
    public class ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AutomaticTagsApi(config);
            var accountName = "accountName_example";  // string | account name to update auto tag policies
            var apiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPutRequest = new ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPutRequest?(); // ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPutRequest? |  (optional) 

            try
            {
                // Update account auto tag policies on comments
                apiInstance.ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPut(accountName, apiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPutRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AutomaticTagsApi.ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update account auto tag policies on comments
    apiInstance.ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPutWithHttpInfo(accountName, apiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPutRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AutomaticTagsApi.ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **accountName** | **string** | account name to update auto tag policies |  |
| **apiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPutRequest** | [**ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPutRequest?**](ApiV1AutomaticTagsPoliciesAccountsAccountNameCommentsPutRequest?.md) |  | [optional]  |

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

<a id="apiv1automatictagsserveravailableget"></a>
# **ApiV1AutomaticTagsServerAvailableGet**
> AutomaticTagAvailable ApiV1AutomaticTagsServerAvailableGet ()

Get server available auto tags

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
    public class ApiV1AutomaticTagsServerAvailableGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AutomaticTagsApi(config);

            try
            {
                // Get server available auto tags
                AutomaticTagAvailable result = apiInstance.ApiV1AutomaticTagsServerAvailableGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AutomaticTagsApi.ApiV1AutomaticTagsServerAvailableGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AutomaticTagsServerAvailableGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get server available auto tags
    ApiResponse<AutomaticTagAvailable> response = apiInstance.ApiV1AutomaticTagsServerAvailableGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AutomaticTagsApi.ApiV1AutomaticTagsServerAvailableGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**AutomaticTagAvailable**](AutomaticTagAvailable.md)

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

