# PeerTubeApiClient.Api.PluginsApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AddPlugin**](PluginsApi.md#addplugin) | **POST** /api/v1/plugins/install | Install a plugin |
| [**ApiV1PluginsNpmNamePublicSettingsGet**](PluginsApi.md#apiv1pluginsnpmnamepublicsettingsget) | **GET** /api/v1/plugins/{npmName}/public-settings | Get a plugin&#39;s public settings |
| [**ApiV1PluginsNpmNameRegisteredSettingsGet**](PluginsApi.md#apiv1pluginsnpmnameregisteredsettingsget) | **GET** /api/v1/plugins/{npmName}/registered-settings | Get a plugin&#39;s registered settings |
| [**ApiV1PluginsNpmNameSettingsPut**](PluginsApi.md#apiv1pluginsnpmnamesettingsput) | **PUT** /api/v1/plugins/{npmName}/settings | Set a plugin&#39;s settings |
| [**GetAvailablePlugins**](PluginsApi.md#getavailableplugins) | **GET** /api/v1/plugins/available | List available plugins |
| [**GetPlugin**](PluginsApi.md#getplugin) | **GET** /api/v1/plugins/{npmName} | Get a plugin |
| [**GetPlugins**](PluginsApi.md#getplugins) | **GET** /api/v1/plugins | List plugins |
| [**UninstallPlugin**](PluginsApi.md#uninstallplugin) | **POST** /api/v1/plugins/uninstall | Uninstall a plugin |
| [**UpdatePlugin**](PluginsApi.md#updateplugin) | **POST** /api/v1/plugins/update | Update a plugin |

<a id="addplugin"></a>
# **AddPlugin**
> void AddPlugin (AddPluginRequest? addPluginRequest = null)

Install a plugin

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class AddPluginExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PluginsApi(config);
            var addPluginRequest = new AddPluginRequest?(); // AddPluginRequest? |  (optional) 

            try
            {
                // Install a plugin
                apiInstance.AddPlugin(addPluginRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PluginsApi.AddPlugin: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AddPluginWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Install a plugin
    apiInstance.AddPluginWithHttpInfo(addPluginRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PluginsApi.AddPluginWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **addPluginRequest** | [**AddPluginRequest?**](AddPluginRequest?.md) |  | [optional]  |

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
| **400** | should have either &#x60;npmName&#x60; or &#x60;path&#x60; set |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1pluginsnpmnamepublicsettingsget"></a>
# **ApiV1PluginsNpmNamePublicSettingsGet**
> Dictionary&lt;string, Object&gt; ApiV1PluginsNpmNamePublicSettingsGet (string npmName)

Get a plugin's public settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1PluginsNpmNamePublicSettingsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new PluginsApi(config);
            var npmName = peertube-plugin-auth-ldap;  // string | name of the plugin/theme on npmjs.com or in its package.json

            try
            {
                // Get a plugin's public settings
                Dictionary<string, Object> result = apiInstance.ApiV1PluginsNpmNamePublicSettingsGet(npmName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PluginsApi.ApiV1PluginsNpmNamePublicSettingsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1PluginsNpmNamePublicSettingsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a plugin's public settings
    ApiResponse<Dictionary<string, Object>> response = apiInstance.ApiV1PluginsNpmNamePublicSettingsGetWithHttpInfo(npmName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PluginsApi.ApiV1PluginsNpmNamePublicSettingsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **npmName** | **string** | name of the plugin/theme on npmjs.com or in its package.json |  |

### Return type

**Dictionary<string, Object>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **404** | plugin not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1pluginsnpmnameregisteredsettingsget"></a>
# **ApiV1PluginsNpmNameRegisteredSettingsGet**
> Dictionary&lt;string, Object&gt; ApiV1PluginsNpmNameRegisteredSettingsGet (string npmName)

Get a plugin's registered settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1PluginsNpmNameRegisteredSettingsGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PluginsApi(config);
            var npmName = peertube-plugin-auth-ldap;  // string | name of the plugin/theme on npmjs.com or in its package.json

            try
            {
                // Get a plugin's registered settings
                Dictionary<string, Object> result = apiInstance.ApiV1PluginsNpmNameRegisteredSettingsGet(npmName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PluginsApi.ApiV1PluginsNpmNameRegisteredSettingsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1PluginsNpmNameRegisteredSettingsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a plugin's registered settings
    ApiResponse<Dictionary<string, Object>> response = apiInstance.ApiV1PluginsNpmNameRegisteredSettingsGetWithHttpInfo(npmName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PluginsApi.ApiV1PluginsNpmNameRegisteredSettingsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **npmName** | **string** | name of the plugin/theme on npmjs.com or in its package.json |  |

### Return type

**Dictionary<string, Object>**

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **404** | plugin not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv1pluginsnpmnamesettingsput"></a>
# **ApiV1PluginsNpmNameSettingsPut**
> void ApiV1PluginsNpmNameSettingsPut (string npmName, ApiV1PluginsNpmNameSettingsPutRequest? apiV1PluginsNpmNameSettingsPutRequest = null)

Set a plugin's settings

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ApiV1PluginsNpmNameSettingsPutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PluginsApi(config);
            var npmName = peertube-plugin-auth-ldap;  // string | name of the plugin/theme on npmjs.com or in its package.json
            var apiV1PluginsNpmNameSettingsPutRequest = new ApiV1PluginsNpmNameSettingsPutRequest?(); // ApiV1PluginsNpmNameSettingsPutRequest? |  (optional) 

            try
            {
                // Set a plugin's settings
                apiInstance.ApiV1PluginsNpmNameSettingsPut(npmName, apiV1PluginsNpmNameSettingsPutRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PluginsApi.ApiV1PluginsNpmNameSettingsPut: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV1PluginsNpmNameSettingsPutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Set a plugin's settings
    apiInstance.ApiV1PluginsNpmNameSettingsPutWithHttpInfo(npmName, apiV1PluginsNpmNameSettingsPutRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PluginsApi.ApiV1PluginsNpmNameSettingsPutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **npmName** | **string** | name of the plugin/theme on npmjs.com or in its package.json |  |
| **apiV1PluginsNpmNameSettingsPutRequest** | [**ApiV1PluginsNpmNameSettingsPutRequest?**](ApiV1PluginsNpmNameSettingsPutRequest?.md) |  | [optional]  |

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
| **404** | plugin not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getavailableplugins"></a>
# **GetAvailablePlugins**
> PluginResponse GetAvailablePlugins (string? search = null, int? pluginType = null, string? currentPeerTubeEngine = null, int? start = null, int? count = null, string? sort = null)

List available plugins

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetAvailablePluginsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PluginsApi(config);
            var search = "search_example";  // string? |  (optional) 
            var pluginType = 56;  // int? |  (optional) 
            var currentPeerTubeEngine = "currentPeerTubeEngine_example";  // string? |  (optional) 
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List available plugins
                PluginResponse result = apiInstance.GetAvailablePlugins(search, pluginType, currentPeerTubeEngine, start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PluginsApi.GetAvailablePlugins: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAvailablePluginsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List available plugins
    ApiResponse<PluginResponse> response = apiInstance.GetAvailablePluginsWithHttpInfo(search, pluginType, currentPeerTubeEngine, start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PluginsApi.GetAvailablePluginsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **search** | **string?** |  | [optional]  |
| **pluginType** | **int?** |  | [optional]  |
| **currentPeerTubeEngine** | **string?** |  | [optional]  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort column | [optional]  |

### Return type

[**PluginResponse**](PluginResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **503** | plugin index unavailable |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getplugin"></a>
# **GetPlugin**
> Plugin GetPlugin (string npmName)

Get a plugin

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetPluginExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PluginsApi(config);
            var npmName = peertube-plugin-auth-ldap;  // string | name of the plugin/theme on npmjs.com or in its package.json

            try
            {
                // Get a plugin
                Plugin result = apiInstance.GetPlugin(npmName);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PluginsApi.GetPlugin: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetPluginWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a plugin
    ApiResponse<Plugin> response = apiInstance.GetPluginWithHttpInfo(npmName);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PluginsApi.GetPluginWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **npmName** | **string** | name of the plugin/theme on npmjs.com or in its package.json |  |

### Return type

[**Plugin**](Plugin.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **404** | plugin not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getplugins"></a>
# **GetPlugins**
> PluginResponse GetPlugins (int? pluginType = null, bool? uninstalled = null, int? start = null, int? count = null, string? sort = null)

List plugins

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetPluginsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PluginsApi(config);
            var pluginType = 56;  // int? |  (optional) 
            var uninstalled = true;  // bool? |  (optional) 
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = -createdAt;  // string? | Sort column (optional) 

            try
            {
                // List plugins
                PluginResponse result = apiInstance.GetPlugins(pluginType, uninstalled, start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PluginsApi.GetPlugins: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetPluginsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List plugins
    ApiResponse<PluginResponse> response = apiInstance.GetPluginsWithHttpInfo(pluginType, uninstalled, start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PluginsApi.GetPluginsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **pluginType** | **int?** |  | [optional]  |
| **uninstalled** | **bool?** |  | [optional]  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort column | [optional]  |

### Return type

[**PluginResponse**](PluginResponse.md)

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

<a id="uninstallplugin"></a>
# **UninstallPlugin**
> void UninstallPlugin (UninstallPluginRequest? uninstallPluginRequest = null)

Uninstall a plugin

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class UninstallPluginExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PluginsApi(config);
            var uninstallPluginRequest = new UninstallPluginRequest?(); // UninstallPluginRequest? |  (optional) 

            try
            {
                // Uninstall a plugin
                apiInstance.UninstallPlugin(uninstallPluginRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PluginsApi.UninstallPlugin: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UninstallPluginWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Uninstall a plugin
    apiInstance.UninstallPluginWithHttpInfo(uninstallPluginRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PluginsApi.UninstallPluginWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **uninstallPluginRequest** | [**UninstallPluginRequest?**](UninstallPluginRequest?.md) |  | [optional]  |

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
| **404** | existing plugin not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updateplugin"></a>
# **UpdatePlugin**
> void UpdatePlugin (AddPluginRequest? addPluginRequest = null)

Update a plugin

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class UpdatePluginExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PluginsApi(config);
            var addPluginRequest = new AddPluginRequest?(); // AddPluginRequest? |  (optional) 

            try
            {
                // Update a plugin
                apiInstance.UpdatePlugin(addPluginRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PluginsApi.UpdatePlugin: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdatePluginWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update a plugin
    apiInstance.UpdatePluginWithHttpInfo(addPluginRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PluginsApi.UpdatePluginWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **addPluginRequest** | [**AddPluginRequest?**](AddPluginRequest?.md) |  | [optional]  |

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
| **400** | should have either &#x60;npmName&#x60; or &#x60;path&#x60; set |  -  |
| **404** | existing plugin not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

