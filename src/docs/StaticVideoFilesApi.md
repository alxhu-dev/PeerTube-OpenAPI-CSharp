# PeerTubeApiClient.Api.StaticVideoFilesApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**StaticStreamingPlaylistsHlsFilenameGet**](StaticVideoFilesApi.md#staticstreamingplaylistshlsfilenameget) | **GET** /static/streaming-playlists/hls/{filename} | Get public HLS video file |
| [**StaticStreamingPlaylistsHlsPrivateFilenameGet**](StaticVideoFilesApi.md#staticstreamingplaylistshlsprivatefilenameget) | **GET** /static/streaming-playlists/hls/private/{filename} | Get private HLS video file |
| [**StaticWebVideosFilenameGet**](StaticVideoFilesApi.md#staticwebvideosfilenameget) | **GET** /static/web-videos/{filename} | Get public Web Video file |
| [**StaticWebVideosPrivateFilenameGet**](StaticVideoFilesApi.md#staticwebvideosprivatefilenameget) | **GET** /static/web-videos/private/{filename} | Get private Web Video file |

<a id="staticstreamingplaylistshlsfilenameget"></a>
# **StaticStreamingPlaylistsHlsFilenameGet**
> void StaticStreamingPlaylistsHlsFilenameGet (string filename)

Get public HLS video file

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class StaticStreamingPlaylistsHlsFilenameGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new StaticVideoFilesApi(config);
            var filename = "filename_example";  // string | Filename

            try
            {
                // Get public HLS video file
                apiInstance.StaticStreamingPlaylistsHlsFilenameGet(filename);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling StaticVideoFilesApi.StaticStreamingPlaylistsHlsFilenameGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StaticStreamingPlaylistsHlsFilenameGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get public HLS video file
    apiInstance.StaticStreamingPlaylistsHlsFilenameGetWithHttpInfo(filename);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling StaticVideoFilesApi.StaticStreamingPlaylistsHlsFilenameGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **filename** | **string** | Filename |  |

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
| **403** | invalid auth |  -  |
| **404** | not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="staticstreamingplaylistshlsprivatefilenameget"></a>
# **StaticStreamingPlaylistsHlsPrivateFilenameGet**
> void StaticStreamingPlaylistsHlsPrivateFilenameGet (string filename, string? videoFileToken = null, bool? reinjectVideoFileToken = null)

Get private HLS video file

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class StaticStreamingPlaylistsHlsPrivateFilenameGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new StaticVideoFilesApi(config);
            var filename = "filename_example";  // string | Filename
            var videoFileToken = "videoFileToken_example";  // string? | Video file token [generated](#operation/requestVideoToken) by PeerTube so you don't need to provide an OAuth token in the request header. (optional) 
            var reinjectVideoFileToken = true;  // bool? | Ask the server to reinject videoFileToken in URLs in m3u8 playlist (optional) 

            try
            {
                // Get private HLS video file
                apiInstance.StaticStreamingPlaylistsHlsPrivateFilenameGet(filename, videoFileToken, reinjectVideoFileToken);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling StaticVideoFilesApi.StaticStreamingPlaylistsHlsPrivateFilenameGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StaticStreamingPlaylistsHlsPrivateFilenameGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get private HLS video file
    apiInstance.StaticStreamingPlaylistsHlsPrivateFilenameGetWithHttpInfo(filename, videoFileToken, reinjectVideoFileToken);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling StaticVideoFilesApi.StaticStreamingPlaylistsHlsPrivateFilenameGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **filename** | **string** | Filename |  |
| **videoFileToken** | **string?** | Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. | [optional]  |
| **reinjectVideoFileToken** | **bool?** | Ask the server to reinject videoFileToken in URLs in m3u8 playlist | [optional]  |

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
| **403** | invalid auth |  -  |
| **404** | not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="staticwebvideosfilenameget"></a>
# **StaticWebVideosFilenameGet**
> void StaticWebVideosFilenameGet (string filename)

Get public Web Video file

**PeerTube >= 6.0**

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class StaticWebVideosFilenameGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new StaticVideoFilesApi(config);
            var filename = "filename_example";  // string | Filename

            try
            {
                // Get public Web Video file
                apiInstance.StaticWebVideosFilenameGet(filename);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling StaticVideoFilesApi.StaticWebVideosFilenameGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StaticWebVideosFilenameGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get public Web Video file
    apiInstance.StaticWebVideosFilenameGetWithHttpInfo(filename);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling StaticVideoFilesApi.StaticWebVideosFilenameGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **filename** | **string** | Filename |  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **404** | not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="staticwebvideosprivatefilenameget"></a>
# **StaticWebVideosPrivateFilenameGet**
> void StaticWebVideosPrivateFilenameGet (string filename, string? videoFileToken = null)

Get private Web Video file

**PeerTube >= 6.0**

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class StaticWebVideosPrivateFilenameGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new StaticVideoFilesApi(config);
            var filename = "filename_example";  // string | Filename
            var videoFileToken = "videoFileToken_example";  // string? | Video file token [generated](#operation/requestVideoToken) by PeerTube so you don't need to provide an OAuth token in the request header. (optional) 

            try
            {
                // Get private Web Video file
                apiInstance.StaticWebVideosPrivateFilenameGet(filename, videoFileToken);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling StaticVideoFilesApi.StaticWebVideosPrivateFilenameGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StaticWebVideosPrivateFilenameGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get private Web Video file
    apiInstance.StaticWebVideosPrivateFilenameGetWithHttpInfo(filename, videoFileToken);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling StaticVideoFilesApi.StaticWebVideosPrivateFilenameGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **filename** | **string** | Filename |  |
| **videoFileToken** | **string?** | Video file token [generated](#operation/requestVideoToken) by PeerTube so you don&#39;t need to provide an OAuth token in the request header. | [optional]  |

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
| **403** | invalid auth |  -  |
| **404** | not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

