# PeerTubeApiClient.Api.InstanceRedundancyApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1ServerRedundancyHostPut**](InstanceRedundancyApi.md#apiv1serverredundancyhostput) | **PUT** /api/v1/server/redundancy/{host} | Update a server redundancy policy |

<a id="apiv1serverredundancyhostput"></a>
# **ApiV1ServerRedundancyHostPut**
> void ApiV1ServerRedundancyHostPut (string host, ApiV1ServerRedundancyHostPutRequest? apiV1ServerRedundancyHostPutRequest = null)

Update a server redundancy policy

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ServerRedundancyHostPutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InstanceRedundancyApi(config);
            var host = "host_example";  // string | server domain to mirror
            var apiV1ServerRedundancyHostPutRequest = new ApiV1ServerRedundancyHostPutRequest?(); // ApiV1ServerRedundancyHostPutRequest? |  (optional) 

            try
            {
                // Update a server redundancy policy
                apiInstance.ApiV1ServerRedundancyHostPut(host, apiV1ServerRedundancyHostPutRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InstanceRedundancyApi.ApiV1ServerRedundancyHostPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ServerRedundancyHostPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update a server redundancy policy
    apiInstance.ApiV1ServerRedundancyHostPutWithHttpInfo(host, apiV1ServerRedundancyHostPutRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InstanceRedundancyApi.ApiV1ServerRedundancyHostPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **host** | **string** | server domain to mirror |  |
| **apiV1ServerRedundancyHostPutRequest** | [**ApiV1ServerRedundancyHostPutRequest?**](ApiV1ServerRedundancyHostPutRequest?.md) |  | [optional]  |

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
| **404** | server is not already known |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

