# PeerTubeApiClient.Api.HomepageApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1CustomPagesHomepageInstanceGet**](HomepageApi.md#apiv1custompageshomepageinstanceget) | **GET** /api/v1/custom-pages/homepage/instance | Get instance custom homepage |
| [**ApiV1CustomPagesHomepageInstancePut**](HomepageApi.md#apiv1custompageshomepageinstanceput) | **PUT** /api/v1/custom-pages/homepage/instance | Set instance custom homepage |

<a id="apiv1custompageshomepageinstanceget"></a>
# **ApiV1CustomPagesHomepageInstanceGet**
> CustomHomepage ApiV1CustomPagesHomepageInstanceGet ()

Get instance custom homepage

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1CustomPagesHomepageInstanceGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new HomepageApi(config);

            try
            {
                // Get instance custom homepage
                CustomHomepage result = apiInstance.ApiV1CustomPagesHomepageInstanceGet();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling HomepageApi.ApiV1CustomPagesHomepageInstanceGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1CustomPagesHomepageInstanceGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get instance custom homepage
    ApiResponse<CustomHomepage> response = apiInstance.ApiV1CustomPagesHomepageInstanceGetWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling HomepageApi.ApiV1CustomPagesHomepageInstanceGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**CustomHomepage**](CustomHomepage.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **404** | No homepage set |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1custompageshomepageinstanceput"></a>
# **ApiV1CustomPagesHomepageInstancePut**
> void ApiV1CustomPagesHomepageInstancePut (ApiV1CustomPagesHomepageInstancePutRequest? apiV1CustomPagesHomepageInstancePutRequest = null)

Set instance custom homepage

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1CustomPagesHomepageInstancePutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new HomepageApi(config);
            var apiV1CustomPagesHomepageInstancePutRequest = new ApiV1CustomPagesHomepageInstancePutRequest?(); // ApiV1CustomPagesHomepageInstancePutRequest? |  (optional) 

            try
            {
                // Set instance custom homepage
                apiInstance.ApiV1CustomPagesHomepageInstancePut(apiV1CustomPagesHomepageInstancePutRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling HomepageApi.ApiV1CustomPagesHomepageInstancePut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1CustomPagesHomepageInstancePutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Set instance custom homepage
    apiInstance.ApiV1CustomPagesHomepageInstancePutWithHttpInfo(apiV1CustomPagesHomepageInstancePutRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling HomepageApi.ApiV1CustomPagesHomepageInstancePutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **apiV1CustomPagesHomepageInstancePutRequest** | [**ApiV1CustomPagesHomepageInstancePutRequest?**](ApiV1CustomPagesHomepageInstancePutRequest?.md) |  | [optional]  |

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

