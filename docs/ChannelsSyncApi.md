# PeerTubeApiClient.Api.ChannelsSyncApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AddVideoChannelSync**](ChannelsSyncApi.md#addvideochannelsync) | **POST** /api/v1/video-channel-syncs | Create a synchronization for a video channel |
| [**ApiV1AccountsNameVideoChannelSyncsGet**](ChannelsSyncApi.md#apiv1accountsnamevideochannelsyncsget) | **GET** /api/v1/accounts/{name}/video-channel-syncs | List the synchronizations of video channels of an account |
| [**ApiV1VideoChannelsChannelHandleImportVideosPost**](ChannelsSyncApi.md#apiv1videochannelschannelhandleimportvideospost) | **POST** /api/v1/video-channels/{channelHandle}/import-videos | Import videos in channel |
| [**DelVideoChannelSync**](ChannelsSyncApi.md#delvideochannelsync) | **DELETE** /api/v1/video-channel-syncs/{channelSyncId} | Delete a video channel synchronization |
| [**TriggerVideoChannelSync**](ChannelsSyncApi.md#triggervideochannelsync) | **POST** /api/v1/video-channel-syncs/{channelSyncId}/sync | Triggers the channel synchronization job, fetching all the videos from the remote channel |

<a id="addvideochannelsync"></a>
# **AddVideoChannelSync**
> AddVideoChannelSync200Response AddVideoChannelSync (VideoChannelSyncCreate? videoChannelSyncCreate = null)

Create a synchronization for a video channel

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class AddVideoChannelSyncExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChannelsSyncApi(config);
            var videoChannelSyncCreate = new VideoChannelSyncCreate?(); // VideoChannelSyncCreate? |  (optional) 

            try
            {
                // Create a synchronization for a video channel
                AddVideoChannelSync200Response result = apiInstance.AddVideoChannelSync(videoChannelSyncCreate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChannelsSyncApi.AddVideoChannelSync: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AddVideoChannelSyncWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a synchronization for a video channel
    ApiResponse<AddVideoChannelSync200Response> response = apiInstance.AddVideoChannelSyncWithHttpInfo(videoChannelSyncCreate);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ChannelsSyncApi.AddVideoChannelSyncWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **videoChannelSyncCreate** | [**VideoChannelSyncCreate?**](VideoChannelSyncCreate?.md) |  | [optional]  |

### Return type

[**AddVideoChannelSync200Response**](AddVideoChannelSync200Response.md)

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

<a id="apiv1accountsnamevideochannelsyncsget"></a>
# **ApiV1AccountsNameVideoChannelSyncsGet**
> VideoChannelSyncList ApiV1AccountsNameVideoChannelSyncsGet (string name, int? start = null, int? count = null, string? sort = null)

List the synchronizations of video channels of an account

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1AccountsNameVideoChannelSyncsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new ChannelsSyncApi(config);
            var name = chocobozzz | chocobozzz@example.org;  // string | The username or handle of the account
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List the synchronizations of video channels of an account
                VideoChannelSyncList result = apiInstance.ApiV1AccountsNameVideoChannelSyncsGet(name, start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChannelsSyncApi.ApiV1AccountsNameVideoChannelSyncsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1AccountsNameVideoChannelSyncsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List the synchronizations of video channels of an account
    ApiResponse<VideoChannelSyncList> response = apiInstance.ApiV1AccountsNameVideoChannelSyncsGetWithHttpInfo(name, start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ChannelsSyncApi.ApiV1AccountsNameVideoChannelSyncsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string** | The username or handle of the account |  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort column | [optional]  |

### Return type

[**VideoChannelSyncList**](VideoChannelSyncList.md)

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

<a id="apiv1videochannelschannelhandleimportvideospost"></a>
# **ApiV1VideoChannelsChannelHandleImportVideosPost**
> void ApiV1VideoChannelsChannelHandleImportVideosPost (string channelHandle, ImportVideosInChannelCreate? importVideosInChannelCreate = null)

Import videos in channel

Import a remote channel/playlist videos into a channel

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1VideoChannelsChannelHandleImportVideosPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChannelsSyncApi(config);
            var channelHandle = my_username | my_username@example.com;  // string | The video channel handle
            var importVideosInChannelCreate = new ImportVideosInChannelCreate?(); // ImportVideosInChannelCreate? |  (optional) 

            try
            {
                // Import videos in channel
                apiInstance.ApiV1VideoChannelsChannelHandleImportVideosPost(channelHandle, importVideosInChannelCreate);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChannelsSyncApi.ApiV1VideoChannelsChannelHandleImportVideosPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1VideoChannelsChannelHandleImportVideosPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Import videos in channel
    apiInstance.ApiV1VideoChannelsChannelHandleImportVideosPostWithHttpInfo(channelHandle, importVideosInChannelCreate);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ChannelsSyncApi.ApiV1VideoChannelsChannelHandleImportVideosPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channelHandle** | **string** | The video channel handle |  |
| **importVideosInChannelCreate** | [**ImportVideosInChannelCreate?**](ImportVideosInChannelCreate?.md) |  | [optional]  |

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

<a id="delvideochannelsync"></a>
# **DelVideoChannelSync**
> void DelVideoChannelSync (int channelSyncId)

Delete a video channel synchronization

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class DelVideoChannelSyncExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChannelsSyncApi(config);
            var channelSyncId = 56;  // int | Channel Sync id

            try
            {
                // Delete a video channel synchronization
                apiInstance.DelVideoChannelSync(channelSyncId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChannelsSyncApi.DelVideoChannelSync: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DelVideoChannelSyncWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a video channel synchronization
    apiInstance.DelVideoChannelSyncWithHttpInfo(channelSyncId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ChannelsSyncApi.DelVideoChannelSyncWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channelSyncId** | **int** | Channel Sync id |  |

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

<a id="triggervideochannelsync"></a>
# **TriggerVideoChannelSync**
> void TriggerVideoChannelSync (int channelSyncId)

Triggers the channel synchronization job, fetching all the videos from the remote channel

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class TriggerVideoChannelSyncExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChannelsSyncApi(config);
            var channelSyncId = 56;  // int | Channel Sync id

            try
            {
                // Triggers the channel synchronization job, fetching all the videos from the remote channel
                apiInstance.TriggerVideoChannelSync(channelSyncId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChannelsSyncApi.TriggerVideoChannelSync: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the TriggerVideoChannelSyncWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Triggers the channel synchronization job, fetching all the videos from the remote channel
    apiInstance.TriggerVideoChannelSyncWithHttpInfo(channelSyncId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ChannelsSyncApi.TriggerVideoChannelSyncWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **channelSyncId** | **int** | Channel Sync id |  |

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

