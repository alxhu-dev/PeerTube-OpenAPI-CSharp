# PeerTubeApiClient.Api.UserExportsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteUserExport**](UserExportsApi.md#deleteuserexport) | **DELETE** /api/v1/users/{userId}/exports/{id} | Delete a user export |
| [**ListUserExports**](UserExportsApi.md#listuserexports) | **GET** /api/v1/users/{userId}/exports | List user exports |
| [**RequestUserExport**](UserExportsApi.md#requestuserexport) | **POST** /api/v1/users/{userId}/exports/request | Request user export |

<a id="deleteuserexport"></a>
# **DeleteUserExport**
> void DeleteUserExport (int userId, int id)

Delete a user export

**PeerTube >= 6.1**

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class DeleteUserExportExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserExportsApi(config);
            var userId = 56;  // int | User id
            var id = 56;  // int | Entity id

            try
            {
                // Delete a user export
                apiInstance.DeleteUserExport(userId, id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserExportsApi.DeleteUserExport: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteUserExportWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a user export
    apiInstance.DeleteUserExportWithHttpInfo(userId, id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserExportsApi.DeleteUserExportWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userId** | **int** | User id |  |
| **id** | **int** | Entity id |  |

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

<a id="listuserexports"></a>
# **ListUserExports**
> ListUserExports200Response ListUserExports (int userId)

List user exports

**PeerTube >= 6.1**

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ListUserExportsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserExportsApi(config);
            var userId = 56;  // int | User id

            try
            {
                // List user exports
                ListUserExports200Response result = apiInstance.ListUserExports(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserExportsApi.ListUserExports: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListUserExportsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List user exports
    ApiResponse<ListUserExports200Response> response = apiInstance.ListUserExportsWithHttpInfo(userId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserExportsApi.ListUserExportsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userId** | **int** | User id |  |

### Return type

[**ListUserExports200Response**](ListUserExports200Response.md)

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

<a id="requestuserexport"></a>
# **RequestUserExport**
> RequestUserExport200Response RequestUserExport (int userId, RequestUserExportRequest? requestUserExportRequest = null)

Request user export

Request an archive of user data. An email is sent when the archive is ready.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class RequestUserExportExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserExportsApi(config);
            var userId = 56;  // int | User id
            var requestUserExportRequest = new RequestUserExportRequest?(); // RequestUserExportRequest? |  (optional) 

            try
            {
                // Request user export
                RequestUserExport200Response result = apiInstance.RequestUserExport(userId, requestUserExportRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserExportsApi.RequestUserExport: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the RequestUserExportWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Request user export
    ApiResponse<RequestUserExport200Response> response = apiInstance.RequestUserExportWithHttpInfo(userId, requestUserExportRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserExportsApi.RequestUserExportWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userId** | **int** | User id |  |
| **requestUserExportRequest** | [**RequestUserExportRequest?**](RequestUserExportRequest?.md) |  | [optional]  |

### Return type

[**RequestUserExport200Response**](RequestUserExport200Response.md)

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

