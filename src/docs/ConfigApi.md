# PeerTubeApiClient.Api.ConfigApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV1ConfigInstanceAvatarDelete**](ConfigApi.md#apiv1configinstanceavatardelete) | **DELETE** /api/v1/config/instance-avatar | Delete instance avatar |
| [**ApiV1ConfigInstanceAvatarPickPost**](ConfigApi.md#apiv1configinstanceavatarpickpost) | **POST** /api/v1/config/instance-avatar/pick | Update instance avatar |
| [**ApiV1ConfigInstanceBannerDelete**](ConfigApi.md#apiv1configinstancebannerdelete) | **DELETE** /api/v1/config/instance-banner | Delete instance banner |
| [**ApiV1ConfigInstanceBannerPickPost**](ConfigApi.md#apiv1configinstancebannerpickpost) | **POST** /api/v1/config/instance-banner/pick | Update instance banner |
| [**DelCustomConfig**](ConfigApi.md#delcustomconfig) | **DELETE** /api/v1/config/custom | Delete instance runtime configuration |
| [**GetAbout**](ConfigApi.md#getabout) | **GET** /api/v1/config/about | Get instance \&quot;About\&quot; information |
| [**GetConfig**](ConfigApi.md#getconfig) | **GET** /api/v1/config | Get instance public configuration |
| [**GetCustomConfig**](ConfigApi.md#getcustomconfig) | **GET** /api/v1/config/custom | Get instance runtime configuration |
| [**PutCustomConfig**](ConfigApi.md#putcustomconfig) | **PUT** /api/v1/config/custom | Set instance runtime configuration |

<a id="apiv1configinstanceavatardelete"></a>
# **ApiV1ConfigInstanceAvatarDelete**
> void ApiV1ConfigInstanceAvatarDelete ()

Delete instance avatar

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ConfigInstanceAvatarDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ConfigApi(config);

            try
            {
                // Delete instance avatar
                apiInstance.ApiV1ConfigInstanceAvatarDelete();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigApi.ApiV1ConfigInstanceAvatarDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ConfigInstanceAvatarDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete instance avatar
    apiInstance.ApiV1ConfigInstanceAvatarDeleteWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigApi.ApiV1ConfigInstanceAvatarDeleteWithHttpInfo: " + e.Message);
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

<a id="apiv1configinstanceavatarpickpost"></a>
# **ApiV1ConfigInstanceAvatarPickPost**
> void ApiV1ConfigInstanceAvatarPickPost (System.IO.Stream? avatarfile = null)

Update instance avatar

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ConfigInstanceAvatarPickPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ConfigApi(config);
            var avatarfile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? | The file to upload. (optional) 

            try
            {
                // Update instance avatar
                apiInstance.ApiV1ConfigInstanceAvatarPickPost(avatarfile);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigApi.ApiV1ConfigInstanceAvatarPickPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ConfigInstanceAvatarPickPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update instance avatar
    apiInstance.ApiV1ConfigInstanceAvatarPickPostWithHttpInfo(avatarfile);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigApi.ApiV1ConfigInstanceAvatarPickPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **avatarfile** | **System.IO.Stream?****System.IO.Stream?** | The file to upload. | [optional]  |

### Return type

void (empty response body)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | successful operation |  -  |
| **413** | image file too large |  * X-File-Maximum-Size - Maximum file size for the banner <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1configinstancebannerdelete"></a>
# **ApiV1ConfigInstanceBannerDelete**
> void ApiV1ConfigInstanceBannerDelete ()

Delete instance banner

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ConfigInstanceBannerDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ConfigApi(config);

            try
            {
                // Delete instance banner
                apiInstance.ApiV1ConfigInstanceBannerDelete();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigApi.ApiV1ConfigInstanceBannerDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ConfigInstanceBannerDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete instance banner
    apiInstance.ApiV1ConfigInstanceBannerDeleteWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigApi.ApiV1ConfigInstanceBannerDeleteWithHttpInfo: " + e.Message);
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

<a id="apiv1configinstancebannerpickpost"></a>
# **ApiV1ConfigInstanceBannerPickPost**
> void ApiV1ConfigInstanceBannerPickPost (System.IO.Stream? bannerfile = null)

Update instance banner

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1ConfigInstanceBannerPickPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ConfigApi(config);
            var bannerfile = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream? | The file to upload. (optional) 

            try
            {
                // Update instance banner
                apiInstance.ApiV1ConfigInstanceBannerPickPost(bannerfile);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigApi.ApiV1ConfigInstanceBannerPickPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1ConfigInstanceBannerPickPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update instance banner
    apiInstance.ApiV1ConfigInstanceBannerPickPostWithHttpInfo(bannerfile);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigApi.ApiV1ConfigInstanceBannerPickPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **bannerfile** | **System.IO.Stream?****System.IO.Stream?** | The file to upload. | [optional]  |

### Return type

void (empty response body)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | successful operation |  -  |
| **413** | image file too large |  * X-File-Maximum-Size - Maximum file size for the banner <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="delcustomconfig"></a>
# **DelCustomConfig**
> void DelCustomConfig ()

Delete instance runtime configuration

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class DelCustomConfigExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ConfigApi(config);

            try
            {
                // Delete instance runtime configuration
                apiInstance.DelCustomConfig();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigApi.DelCustomConfig: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DelCustomConfigWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete instance runtime configuration
    apiInstance.DelCustomConfigWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigApi.DelCustomConfigWithHttpInfo: " + e.Message);
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
| **200** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getabout"></a>
# **GetAbout**
> ServerConfigAbout GetAbout ()

Get instance \"About\" information

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetAboutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new ConfigApi(config);

            try
            {
                // Get instance \"About\" information
                ServerConfigAbout result = apiInstance.GetAbout();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigApi.GetAbout: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAboutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get instance \"About\" information
    ApiResponse<ServerConfigAbout> response = apiInstance.GetAboutWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigApi.GetAboutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**ServerConfigAbout**](ServerConfigAbout.md)

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

<a id="getconfig"></a>
# **GetConfig**
> ServerConfig GetConfig ()

Get instance public configuration

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetConfigExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new ConfigApi(config);

            try
            {
                // Get instance public configuration
                ServerConfig result = apiInstance.GetConfig();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigApi.GetConfig: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetConfigWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get instance public configuration
    ApiResponse<ServerConfig> response = apiInstance.GetConfigWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigApi.GetConfigWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**ServerConfig**](ServerConfig.md)

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

<a id="getcustomconfig"></a>
# **GetCustomConfig**
> ServerConfigCustom GetCustomConfig ()

Get instance runtime configuration

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetCustomConfigExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ConfigApi(config);

            try
            {
                // Get instance runtime configuration
                ServerConfigCustom result = apiInstance.GetCustomConfig();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigApi.GetCustomConfig: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetCustomConfigWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get instance runtime configuration
    ApiResponse<ServerConfigCustom> response = apiInstance.GetCustomConfigWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigApi.GetCustomConfigWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**ServerConfigCustom**](ServerConfigCustom.md)

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

<a id="putcustomconfig"></a>
# **PutCustomConfig**
> void PutCustomConfig ()

Set instance runtime configuration

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class PutCustomConfigExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ConfigApi(config);

            try
            {
                // Set instance runtime configuration
                apiInstance.PutCustomConfig();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigApi.PutCustomConfig: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PutCustomConfigWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Set instance runtime configuration
    apiInstance.PutCustomConfigWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigApi.PutCustomConfigWithHttpInfo: " + e.Message);
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
| **200** | successful operation |  -  |
| **400** | Arises when:   - the emailer is disabled and the instance is open to registrations   - web videos and hls are disabled with transcoding enabled - you need at least one enabled  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

