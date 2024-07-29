# PeerTubeApiClient.Api.UserImportsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetLatestUserImport**](UserImportsApi.md#getlatestuserimport) | **GET** /api/v1/users/{userId}/imports/latest | Get latest user import |
| [**UserImportResumable**](UserImportsApi.md#userimportresumable) | **PUT** /api/v1/users/{userId}/imports/import-resumable | Send chunk for the resumable user import |
| [**UserImportResumableCancel**](UserImportsApi.md#userimportresumablecancel) | **DELETE** /api/v1/users/{userId}/imports/import-resumable | Cancel the resumable user import |
| [**UserImportResumableInit**](UserImportsApi.md#userimportresumableinit) | **POST** /api/v1/users/{userId}/imports/import-resumable | Initialize the resumable user import |

<a id="getlatestuserimport"></a>
# **GetLatestUserImport**
> GetLatestUserImport200Response GetLatestUserImport (int userId)

Get latest user import

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
    public class GetLatestUserImportExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserImportsApi(config);
            var userId = 56;  // int | User id

            try
            {
                // Get latest user import
                GetLatestUserImport200Response result = apiInstance.GetLatestUserImport(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserImportsApi.GetLatestUserImport: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetLatestUserImportWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get latest user import
    ApiResponse<GetLatestUserImport200Response> response = apiInstance.GetLatestUserImportWithHttpInfo(userId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserImportsApi.GetLatestUserImportWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userId** | **int** | User id |  |

### Return type

[**GetLatestUserImport200Response**](GetLatestUserImport200Response.md)

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

<a id="userimportresumable"></a>
# **UserImportResumable**
> void UserImportResumable (string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = null)

Send chunk for the resumable user import

**PeerTube >= 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the import of the archive

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class UserImportResumableExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserImportsApi(config);
            var uploadId = "uploadId_example";  // string | Created session id to proceed with. If you didn't send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. 
            var contentRange = bytes 0-262143/2469036;  // string | Specifies the bytes in the file that the request is uploading.  For example, a value of `bytes 0-262143/1000000` shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. 
            var contentLength = 262144;  // decimal | Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube's web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. 
            var body = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? |  (optional) 

            try
            {
                // Send chunk for the resumable user import
                apiInstance.UserImportResumable(uploadId, contentRange, contentLength, body);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserImportsApi.UserImportResumable: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UserImportResumableWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Send chunk for the resumable user import
    apiInstance.UserImportResumableWithHttpInfo(uploadId, contentRange, contentLength, body);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserImportsApi.UserImportResumableWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uploadId** | **string** | Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload.  |  |
| **contentRange** | **string** | Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file.  |  |
| **contentLength** | **decimal** | Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health.  |  |
| **body** | **System.IO.Stream?****System.IO.Stream?** |  | [optional]  |

### Return type

void (empty response body)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: application/octet-stream
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | last chunk received: successful operation |  -  |
| **308** | resume incomplete |  * Range -  <br>  * Content-Length -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="userimportresumablecancel"></a>
# **UserImportResumableCancel**
> void UserImportResumableCancel (string uploadId, decimal contentLength)

Cancel the resumable user import

**PeerTube >= 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the resumable user import

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class UserImportResumableCancelExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserImportsApi(config);
            var uploadId = "uploadId_example";  // string | Created session id to proceed with. If you didn't send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. 
            var contentLength = 0;  // decimal | 

            try
            {
                // Cancel the resumable user import
                apiInstance.UserImportResumableCancel(uploadId, contentLength);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserImportsApi.UserImportResumableCancel: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UserImportResumableCancelWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Cancel the resumable user import
    apiInstance.UserImportResumableCancelWithHttpInfo(uploadId, contentLength);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserImportsApi.UserImportResumableCancelWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uploadId** | **string** | Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload.  |  |
| **contentLength** | **decimal** |  |  |

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
| **204** | import cancelled |  * Content-Length -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="userimportresumableinit"></a>
# **UserImportResumableInit**
> void UserImportResumableInit (decimal xUploadContentLength, string xUploadContentType, UserImportResumable? userImportResumable = null)

Initialize the resumable user import

**PeerTube >= 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the import of the archive

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class UserImportResumableInitExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserImportsApi(config);
            var xUploadContentLength = 2469036;  // decimal | Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.
            var xUploadContentType = video/mp4;  // string | MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.
            var userImportResumable = new UserImportResumable?(); // UserImportResumable? |  (optional) 

            try
            {
                // Initialize the resumable user import
                apiInstance.UserImportResumableInit(xUploadContentLength, xUploadContentType, userImportResumable);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserImportsApi.UserImportResumableInit: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UserImportResumableInitWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Initialize the resumable user import
    apiInstance.UserImportResumableInitWithHttpInfo(xUploadContentLength, xUploadContentType, userImportResumable);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserImportsApi.UserImportResumableInitWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xUploadContentLength** | **decimal** | Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading. |  |
| **xUploadContentType** | **string** | MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary. |  |
| **userImportResumable** | [**UserImportResumable?**](UserImportResumable?.md) |  | [optional]  |

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
| **201** | created |  * Location -  <br>  * Content-Length -  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

