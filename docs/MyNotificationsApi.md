# PeerTubeApiClient.Api.MyNotificationsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1UsersMeNotificationSettingsPut**](MyNotificationsApi.md#apiv1usersmenotificationsettingsput) | **PUT** /api/v1/users/me/notification-settings | Update my notification settings |
| [**ApiV1UsersMeNotificationsGet**](MyNotificationsApi.md#apiv1usersmenotificationsget) | **GET** /api/v1/users/me/notifications | List my notifications |
| [**ApiV1UsersMeNotificationsReadAllPost**](MyNotificationsApi.md#apiv1usersmenotificationsreadallpost) | **POST** /api/v1/users/me/notifications/read-all | Mark all my notification as read |
| [**ApiV1UsersMeNotificationsReadPost**](MyNotificationsApi.md#apiv1usersmenotificationsreadpost) | **POST** /api/v1/users/me/notifications/read | Mark notifications as read by their id |

<a id="apiv1usersmenotificationsettingsput"></a>
# **ApiV1UsersMeNotificationSettingsPut**
> void ApiV1UsersMeNotificationSettingsPut (ApiV1UsersMeNotificationSettingsPutRequest? apiV1UsersMeNotificationSettingsPutRequest = null)

Update my notification settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeNotificationSettingsPutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MyNotificationsApi(config);
            var apiV1UsersMeNotificationSettingsPutRequest = new ApiV1UsersMeNotificationSettingsPutRequest?(); // ApiV1UsersMeNotificationSettingsPutRequest? |  (optional) 

            try
            {
                // Update my notification settings
                apiInstance.ApiV1UsersMeNotificationSettingsPut(apiV1UsersMeNotificationSettingsPutRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MyNotificationsApi.ApiV1UsersMeNotificationSettingsPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeNotificationSettingsPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update my notification settings
    apiInstance.ApiV1UsersMeNotificationSettingsPutWithHttpInfo(apiV1UsersMeNotificationSettingsPutRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MyNotificationsApi.ApiV1UsersMeNotificationSettingsPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **apiV1UsersMeNotificationSettingsPutRequest** | [**ApiV1UsersMeNotificationSettingsPutRequest?**](ApiV1UsersMeNotificationSettingsPutRequest?.md) |  | [optional]  |

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

<a id="apiv1usersmenotificationsget"></a>
# **ApiV1UsersMeNotificationsGet**
> NotificationListResponse ApiV1UsersMeNotificationsGet (bool? unread = null, int? start = null, int? count = null, string? sort = null)

List my notifications

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeNotificationsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MyNotificationsApi(config);
            var unread = true;  // bool? | only list unread notifications (optional) 
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List my notifications
                NotificationListResponse result = apiInstance.ApiV1UsersMeNotificationsGet(unread, start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MyNotificationsApi.ApiV1UsersMeNotificationsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeNotificationsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List my notifications
    ApiResponse<NotificationListResponse> response = apiInstance.ApiV1UsersMeNotificationsGetWithHttpInfo(unread, start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MyNotificationsApi.ApiV1UsersMeNotificationsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **unread** | **bool?** | only list unread notifications | [optional]  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort column | [optional]  |

### Return type

[**NotificationListResponse**](NotificationListResponse.md)

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

<a id="apiv1usersmenotificationsreadallpost"></a>
# **ApiV1UsersMeNotificationsReadAllPost**
> void ApiV1UsersMeNotificationsReadAllPost ()

Mark all my notification as read

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeNotificationsReadAllPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MyNotificationsApi(config);

            try
            {
                // Mark all my notification as read
                apiInstance.ApiV1UsersMeNotificationsReadAllPost();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MyNotificationsApi.ApiV1UsersMeNotificationsReadAllPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeNotificationsReadAllPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Mark all my notification as read
    apiInstance.ApiV1UsersMeNotificationsReadAllPostWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MyNotificationsApi.ApiV1UsersMeNotificationsReadAllPostWithHttpInfo: " + e.Message);
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

<a id="apiv1usersmenotificationsreadpost"></a>
# **ApiV1UsersMeNotificationsReadPost**
> void ApiV1UsersMeNotificationsReadPost (ApiV1UsersMeNotificationsReadPostRequest? apiV1UsersMeNotificationsReadPostRequest = null)

Mark notifications as read by their id

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1UsersMeNotificationsReadPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MyNotificationsApi(config);
            var apiV1UsersMeNotificationsReadPostRequest = new ApiV1UsersMeNotificationsReadPostRequest?(); // ApiV1UsersMeNotificationsReadPostRequest? |  (optional) 

            try
            {
                // Mark notifications as read by their id
                apiInstance.ApiV1UsersMeNotificationsReadPost(apiV1UsersMeNotificationsReadPostRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MyNotificationsApi.ApiV1UsersMeNotificationsReadPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1UsersMeNotificationsReadPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Mark notifications as read by their id
    apiInstance.ApiV1UsersMeNotificationsReadPostWithHttpInfo(apiV1UsersMeNotificationsReadPostRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MyNotificationsApi.ApiV1UsersMeNotificationsReadPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **apiV1UsersMeNotificationsReadPostRequest** | [**ApiV1UsersMeNotificationsReadPostRequest?**](ApiV1UsersMeNotificationsReadPostRequest?.md) |  | [optional]  |

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

