# PeerTubeApiClient.Api.UsersApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AddUser**](UsersApi.md#adduser) | **POST** /api/v1/users | Create a user |
| [**ConfirmTwoFactorRequest**](UsersApi.md#confirmtwofactorrequest) | **POST** /api/v1/users/{id}/two-factor/confirm-request | Confirm two factor auth |
| [**DelUser**](UsersApi.md#deluser) | **DELETE** /api/v1/users/{id} | Delete a user |
| [**DisableTwoFactor**](UsersApi.md#disabletwofactor) | **POST** /api/v1/users/{id}/two-factor/disable | Disable two factor auth |
| [**GetUser**](UsersApi.md#getuser) | **GET** /api/v1/users/{id} | Get a user |
| [**GetUsers**](UsersApi.md#getusers) | **GET** /api/v1/users | List users |
| [**PutUser**](UsersApi.md#putuser) | **PUT** /api/v1/users/{id} | Update a user |
| [**RequestTwoFactor**](UsersApi.md#requesttwofactor) | **POST** /api/v1/users/{id}/two-factor/request | Request two factor auth |
| [**ResendEmailToVerifyUser**](UsersApi.md#resendemailtoverifyuser) | **POST** /api/v1/users/ask-send-verify-email | Resend user verification link |
| [**VerifyUser**](UsersApi.md#verifyuser) | **POST** /api/v1/users/{id}/verify-email | Verify a user |

<a id="adduser"></a>
# **AddUser**
> AddUserResponse AddUser (AddUser addUser)

Create a user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class AddUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UsersApi(config);
            var addUser = new AddUser(); // AddUser | If the smtp server is configured, you can leave the password empty and an email will be sent asking the user to set it first. 

            try
            {
                // Create a user
                AddUserResponse result = apiInstance.AddUser(addUser);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UsersApi.AddUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AddUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a user
    ApiResponse<AddUserResponse> response = apiInstance.AddUserWithHttpInfo(addUser);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UsersApi.AddUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **addUser** | [**AddUser**](AddUser.md) | If the smtp server is configured, you can leave the password empty and an email will be sent asking the user to set it first.  |  |

### Return type

[**AddUserResponse**](AddUserResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | user created |  -  |
| **403** | insufficient authority to create an admin or moderator |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="confirmtwofactorrequest"></a>
# **ConfirmTwoFactorRequest**
> void ConfirmTwoFactorRequest (int id, ConfirmTwoFactorRequestRequest? confirmTwoFactorRequestRequest = null)

Confirm two factor auth

Confirm a two factor authentication request

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ConfirmTwoFactorRequestExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UsersApi(config);
            var id = 56;  // int | Entity id
            var confirmTwoFactorRequestRequest = new ConfirmTwoFactorRequestRequest?(); // ConfirmTwoFactorRequestRequest? |  (optional) 

            try
            {
                // Confirm two factor auth
                apiInstance.ConfirmTwoFactorRequest(id, confirmTwoFactorRequestRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UsersApi.ConfirmTwoFactorRequest: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ConfirmTwoFactorRequestWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Confirm two factor auth
    apiInstance.ConfirmTwoFactorRequestWithHttpInfo(id, confirmTwoFactorRequestRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UsersApi.ConfirmTwoFactorRequestWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | Entity id |  |
| **confirmTwoFactorRequestRequest** | [**ConfirmTwoFactorRequestRequest?**](ConfirmTwoFactorRequestRequest?.md) |  | [optional]  |

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
| **403** | invalid request token or OTP token |  -  |
| **404** | user not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deluser"></a>
# **DelUser**
> void DelUser (int id)

Delete a user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class DelUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UsersApi(config);
            var id = 56;  // int | Entity id

            try
            {
                // Delete a user
                apiInstance.DelUser(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UsersApi.DelUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DelUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a user
    apiInstance.DelUserWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UsersApi.DelUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
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

<a id="disabletwofactor"></a>
# **DisableTwoFactor**
> void DisableTwoFactor (int id, RequestTwoFactorRequest? requestTwoFactorRequest = null)

Disable two factor auth

Disable two factor authentication of a user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class DisableTwoFactorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UsersApi(config);
            var id = 56;  // int | Entity id
            var requestTwoFactorRequest = new RequestTwoFactorRequest?(); // RequestTwoFactorRequest? |  (optional) 

            try
            {
                // Disable two factor auth
                apiInstance.DisableTwoFactor(id, requestTwoFactorRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UsersApi.DisableTwoFactor: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DisableTwoFactorWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Disable two factor auth
    apiInstance.DisableTwoFactorWithHttpInfo(id, requestTwoFactorRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UsersApi.DisableTwoFactorWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | Entity id |  |
| **requestTwoFactorRequest** | [**RequestTwoFactorRequest?**](RequestTwoFactorRequest?.md) |  | [optional]  |

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
| **403** | invalid password |  -  |
| **404** | user not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getuser"></a>
# **GetUser**
> GetUser200Response GetUser (int id, bool? withStats = null)

Get a user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UsersApi(config);
            var id = 56;  // int | Entity id
            var withStats = true;  // bool? | include statistics about the user (only available as a moderator/admin) (optional) 

            try
            {
                // Get a user
                GetUser200Response result = apiInstance.GetUser(id, withStats);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UsersApi.GetUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a user
    ApiResponse<GetUser200Response> response = apiInstance.GetUserWithHttpInfo(id, withStats);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UsersApi.GetUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | Entity id |  |
| **withStats** | **bool?** | include statistics about the user (only available as a moderator/admin) | [optional]  |

### Return type

[**GetUser200Response**](GetUser200Response.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | As an admin/moderator, you can request a response augmented with statistics about the user&#39;s moderation relations and videos usage, by using the &#x60;withStats&#x60; parameter.  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getusers"></a>
# **GetUsers**
> List&lt;User&gt; GetUsers (string? search = null, bool? blocked = null, int? start = null, int? count = null, string? sort = null)

List users

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class GetUsersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UsersApi(config);
            var search = "search_example";  // string? | Plain text search that will match with user usernames or emails (optional) 
            var blocked = true;  // bool? | Filter results down to (un)banned users (optional) 
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var sort = "-id";  // string? | Sort users by criteria (optional) 

            try
            {
                // List users
                List<User> result = apiInstance.GetUsers(search, blocked, start, count, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UsersApi.GetUsers: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetUsersWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List users
    ApiResponse<List<User>> response = apiInstance.GetUsersWithHttpInfo(search, blocked, start, count, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UsersApi.GetUsersWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **search** | **string?** | Plain text search that will match with user usernames or emails | [optional]  |
| **blocked** | **bool?** | Filter results down to (un)banned users | [optional]  |
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **sort** | **string?** | Sort users by criteria | [optional]  |

### Return type

[**List&lt;User&gt;**](User.md)

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

<a id="putuser"></a>
# **PutUser**
> void PutUser (int id, UpdateUser updateUser)

Update a user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class PutUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UsersApi(config);
            var id = 56;  // int | Entity id
            var updateUser = new UpdateUser(); // UpdateUser | 

            try
            {
                // Update a user
                apiInstance.PutUser(id, updateUser);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UsersApi.PutUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PutUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update a user
    apiInstance.PutUserWithHttpInfo(id, updateUser);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UsersApi.PutUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | Entity id |  |
| **updateUser** | [**UpdateUser**](UpdateUser.md) |  |  |

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

<a id="requesttwofactor"></a>
# **RequestTwoFactor**
> List&lt;RequestTwoFactorResponse&gt; RequestTwoFactor (int id, RequestTwoFactorRequest? requestTwoFactorRequest = null)

Request two factor auth

Request two factor authentication for a user

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class RequestTwoFactorExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UsersApi(config);
            var id = 56;  // int | Entity id
            var requestTwoFactorRequest = new RequestTwoFactorRequest?(); // RequestTwoFactorRequest? |  (optional) 

            try
            {
                // Request two factor auth
                List<RequestTwoFactorResponse> result = apiInstance.RequestTwoFactor(id, requestTwoFactorRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UsersApi.RequestTwoFactor: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the RequestTwoFactorWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Request two factor auth
    ApiResponse<List<RequestTwoFactorResponse>> response = apiInstance.RequestTwoFactorWithHttpInfo(id, requestTwoFactorRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UsersApi.RequestTwoFactorWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | Entity id |  |
| **requestTwoFactorRequest** | [**RequestTwoFactorRequest?**](RequestTwoFactorRequest?.md) |  | [optional]  |

### Return type

[**List&lt;RequestTwoFactorResponse&gt;**](RequestTwoFactorResponse.md)

### Authorization

[OAuth2](../README.md#OAuth2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **403** | invalid password |  -  |
| **404** | user not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="resendemailtoverifyuser"></a>
# **ResendEmailToVerifyUser**
> void ResendEmailToVerifyUser (ResendEmailToVerifyUserRequest? resendEmailToVerifyUserRequest = null)

Resend user verification link

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ResendEmailToVerifyUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new UsersApi(config);
            var resendEmailToVerifyUserRequest = new ResendEmailToVerifyUserRequest?(); // ResendEmailToVerifyUserRequest? |  (optional) 

            try
            {
                // Resend user verification link
                apiInstance.ResendEmailToVerifyUser(resendEmailToVerifyUserRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UsersApi.ResendEmailToVerifyUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ResendEmailToVerifyUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Resend user verification link
    apiInstance.ResendEmailToVerifyUserWithHttpInfo(resendEmailToVerifyUserRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UsersApi.ResendEmailToVerifyUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **resendEmailToVerifyUserRequest** | [**ResendEmailToVerifyUserRequest?**](ResendEmailToVerifyUserRequest?.md) |  | [optional]  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | successful operation |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="verifyuser"></a>
# **VerifyUser**
> void VerifyUser (int id, VerifyUserRequest? verifyUserRequest = null)

Verify a user

Following a user registration, the new user will receive an email asking to click a link containing a secret. This endpoint can also be used to verify a new email set in the user account. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class VerifyUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new UsersApi(config);
            var id = 56;  // int | Entity id
            var verifyUserRequest = new VerifyUserRequest?(); // VerifyUserRequest? |  (optional) 

            try
            {
                // Verify a user
                apiInstance.VerifyUser(id, verifyUserRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UsersApi.VerifyUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the VerifyUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Verify a user
    apiInstance.VerifyUserWithHttpInfo(id, verifyUserRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UsersApi.VerifyUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | Entity id |  |
| **verifyUserRequest** | [**VerifyUserRequest?**](VerifyUserRequest?.md) |  | [optional]  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | successful operation |  -  |
| **403** | invalid verification string |  -  |
| **404** | user not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

