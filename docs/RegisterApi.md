# PeerTubeApiClient.Api.RegisterApi

All URIs are relative to *https://peertube2.cpy.re*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AcceptRegistration**](RegisterApi.md#acceptregistration) | **POST** /api/v1/users/registrations/{registrationId}/accept | Accept registration |
| [**DeleteRegistration**](RegisterApi.md#deleteregistration) | **DELETE** /api/v1/users/registrations/{registrationId} | Delete registration |
| [**ListRegistrations**](RegisterApi.md#listregistrations) | **GET** /api/v1/users/registrations | List registrations |
| [**RegisterUser**](RegisterApi.md#registeruser) | **POST** /api/v1/users/register | Register a user |
| [**RejectRegistration**](RegisterApi.md#rejectregistration) | **POST** /api/v1/users/registrations/{registrationId}/reject | Reject registration |
| [**RequestRegistration**](RegisterApi.md#requestregistration) | **POST** /api/v1/users/registrations/request | Request registration |
| [**ResendEmailToVerifyRegistration**](RegisterApi.md#resendemailtoverifyregistration) | **POST** /api/v1/users/registrations/ask-send-verify-email | Resend verification link to registration email |
| [**ResendEmailToVerifyUser**](RegisterApi.md#resendemailtoverifyuser) | **POST** /api/v1/users/ask-send-verify-email | Resend user verification link |
| [**VerifyRegistrationEmail**](RegisterApi.md#verifyregistrationemail) | **POST** /api/v1/users/registrations/{registrationId}/verify-email | Verify a registration email |
| [**VerifyUser**](RegisterApi.md#verifyuser) | **POST** /api/v1/users/{id}/verify-email | Verify a user |

<a id="acceptregistration"></a>
# **AcceptRegistration**
> void AcceptRegistration (int registrationId, UserRegistrationAcceptOrReject? userRegistrationAcceptOrReject = null)

Accept registration

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class AcceptRegistrationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RegisterApi(config);
            var registrationId = 56;  // int | Registration ID
            var userRegistrationAcceptOrReject = new UserRegistrationAcceptOrReject?(); // UserRegistrationAcceptOrReject? |  (optional) 

            try
            {
                // Accept registration
                apiInstance.AcceptRegistration(registrationId, userRegistrationAcceptOrReject);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RegisterApi.AcceptRegistration: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AcceptRegistrationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Accept registration
    apiInstance.AcceptRegistrationWithHttpInfo(registrationId, userRegistrationAcceptOrReject);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RegisterApi.AcceptRegistrationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **registrationId** | **int** | Registration ID |  |
| **userRegistrationAcceptOrReject** | [**UserRegistrationAcceptOrReject?**](UserRegistrationAcceptOrReject?.md) |  | [optional]  |

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

<a id="deleteregistration"></a>
# **DeleteRegistration**
> void DeleteRegistration (int registrationId)

Delete registration

Delete the registration entry. It will not remove the user associated with this registration (if any)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class DeleteRegistrationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RegisterApi(config);
            var registrationId = 56;  // int | Registration ID

            try
            {
                // Delete registration
                apiInstance.DeleteRegistration(registrationId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RegisterApi.DeleteRegistration: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteRegistrationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete registration
    apiInstance.DeleteRegistrationWithHttpInfo(registrationId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RegisterApi.DeleteRegistrationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **registrationId** | **int** | Registration ID |  |

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

<a id="listregistrations"></a>
# **ListRegistrations**
> ListRegistrations200Response ListRegistrations (int? start = null, int? count = null, string? search = null, string? sort = null)

List registrations

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ListRegistrationsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RegisterApi(config);
            var start = 56;  // int? | Offset used to paginate results (optional) 
            var count = 15;  // int? | Number of items to return (optional)  (default to 15)
            var search = "search_example";  // string? |  (optional) 
            var sort = "-createdAt";  // string? |  (optional) 

            try
            {
                // List registrations
                ListRegistrations200Response result = apiInstance.ListRegistrations(start, count, search, sort);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RegisterApi.ListRegistrations: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListRegistrationsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List registrations
    ApiResponse<ListRegistrations200Response> response = apiInstance.ListRegistrationsWithHttpInfo(start, count, search, sort);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RegisterApi.ListRegistrationsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **int?** | Offset used to paginate results | [optional]  |
| **count** | **int?** | Number of items to return | [optional] [default to 15] |
| **search** | **string?** |  | [optional]  |
| **sort** | **string?** |  | [optional]  |

### Return type

[**ListRegistrations200Response**](ListRegistrations200Response.md)

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

<a id="registeruser"></a>
# **RegisterUser**
> void RegisterUser (RegisterUser registerUser)

Register a user

Signup has to be enabled and signup approval is not required

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class RegisterUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new RegisterApi(config);
            var registerUser = new RegisterUser(); // RegisterUser | 

            try
            {
                // Register a user
                apiInstance.RegisterUser(registerUser);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RegisterApi.RegisterUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the RegisterUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Register a user
    apiInstance.RegisterUserWithHttpInfo(registerUser);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RegisterApi.RegisterUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **registerUser** | [**RegisterUser**](RegisterUser.md) |  |  |

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
| **400** | request error |  -  |
| **403** | user registration is not enabled, user limit is reached, registration is not allowed for the ip, requires approval or blocked by a plugin |  -  |
| **409** | a user with this username, channel name or email already exists |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="rejectregistration"></a>
# **RejectRegistration**
> void RejectRegistration (int registrationId, UserRegistrationAcceptOrReject? userRegistrationAcceptOrReject = null)

Reject registration

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class RejectRegistrationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            // Configure OAuth2 access token for authorization: OAuth2
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RegisterApi(config);
            var registrationId = 56;  // int | Registration ID
            var userRegistrationAcceptOrReject = new UserRegistrationAcceptOrReject?(); // UserRegistrationAcceptOrReject? |  (optional) 

            try
            {
                // Reject registration
                apiInstance.RejectRegistration(registrationId, userRegistrationAcceptOrReject);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RegisterApi.RejectRegistration: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the RejectRegistrationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Reject registration
    apiInstance.RejectRegistrationWithHttpInfo(registrationId, userRegistrationAcceptOrReject);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RegisterApi.RejectRegistrationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **registrationId** | **int** | Registration ID |  |
| **userRegistrationAcceptOrReject** | [**UserRegistrationAcceptOrReject?**](UserRegistrationAcceptOrReject?.md) |  | [optional]  |

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

<a id="requestregistration"></a>
# **RequestRegistration**
> UserRegistration RequestRegistration (UserRegistrationRequest? userRegistrationRequest = null)

Request registration

Signup has to be enabled and require approval on the instance

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class RequestRegistrationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new RegisterApi(config);
            var userRegistrationRequest = new UserRegistrationRequest?(); // UserRegistrationRequest? |  (optional) 

            try
            {
                // Request registration
                UserRegistration result = apiInstance.RequestRegistration(userRegistrationRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RegisterApi.RequestRegistration: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the RequestRegistrationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Request registration
    ApiResponse<UserRegistration> response = apiInstance.RequestRegistrationWithHttpInfo(userRegistrationRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RegisterApi.RequestRegistrationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userRegistrationRequest** | [**UserRegistrationRequest?**](UserRegistrationRequest?.md) |  | [optional]  |

### Return type

[**UserRegistration**](UserRegistration.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | successful operation |  -  |
| **400** | request error or signup approval is not enabled on the instance |  -  |
| **403** | user registration is not enabled, user limit is reached, registration is not allowed for the ip or blocked by a plugin |  -  |
| **409** | a user or registration with this username, channel name or email already exists |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="resendemailtoverifyregistration"></a>
# **ResendEmailToVerifyRegistration**
> void ResendEmailToVerifyRegistration (ResendEmailToVerifyRegistrationRequest? resendEmailToVerifyRegistrationRequest = null)

Resend verification link to registration email

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class ResendEmailToVerifyRegistrationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new RegisterApi(config);
            var resendEmailToVerifyRegistrationRequest = new ResendEmailToVerifyRegistrationRequest?(); // ResendEmailToVerifyRegistrationRequest? |  (optional) 

            try
            {
                // Resend verification link to registration email
                apiInstance.ResendEmailToVerifyRegistration(resendEmailToVerifyRegistrationRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RegisterApi.ResendEmailToVerifyRegistration: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ResendEmailToVerifyRegistrationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Resend verification link to registration email
    apiInstance.ResendEmailToVerifyRegistrationWithHttpInfo(resendEmailToVerifyRegistrationRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RegisterApi.ResendEmailToVerifyRegistrationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **resendEmailToVerifyRegistrationRequest** | [**ResendEmailToVerifyRegistrationRequest?**](ResendEmailToVerifyRegistrationRequest?.md) |  | [optional]  |

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
            var apiInstance = new RegisterApi(config);
            var resendEmailToVerifyUserRequest = new ResendEmailToVerifyUserRequest?(); // ResendEmailToVerifyUserRequest? |  (optional) 

            try
            {
                // Resend user verification link
                apiInstance.ResendEmailToVerifyUser(resendEmailToVerifyUserRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RegisterApi.ResendEmailToVerifyUser: " + e.Message);
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
    Debug.Print("Exception when calling RegisterApi.ResendEmailToVerifyUserWithHttpInfo: " + e.Message);
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

<a id="verifyregistrationemail"></a>
# **VerifyRegistrationEmail**
> void VerifyRegistrationEmail (int registrationId, VerifyRegistrationEmailRequest? verifyRegistrationEmailRequest = null)

Verify a registration email

Following a user registration request, the user will receive an email asking to click a link containing a secret. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using PeerTubeApiClient.Api;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Model;

namespace Example
{
    public class VerifyRegistrationEmailExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://peertube2.cpy.re";
            var apiInstance = new RegisterApi(config);
            var registrationId = 56;  // int | Registration ID
            var verifyRegistrationEmailRequest = new VerifyRegistrationEmailRequest?(); // VerifyRegistrationEmailRequest? |  (optional) 

            try
            {
                // Verify a registration email
                apiInstance.VerifyRegistrationEmail(registrationId, verifyRegistrationEmailRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RegisterApi.VerifyRegistrationEmail: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the VerifyRegistrationEmailWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Verify a registration email
    apiInstance.VerifyRegistrationEmailWithHttpInfo(registrationId, verifyRegistrationEmailRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RegisterApi.VerifyRegistrationEmailWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **registrationId** | **int** | Registration ID |  |
| **verifyRegistrationEmailRequest** | [**VerifyRegistrationEmailRequest?**](VerifyRegistrationEmailRequest?.md) |  | [optional]  |

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
| **404** | registration not found |  -  |

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
            var apiInstance = new RegisterApi(config);
            var id = 56;  // int | Entity id
            var verifyUserRequest = new VerifyUserRequest?(); // VerifyUserRequest? |  (optional) 

            try
            {
                // Verify a user
                apiInstance.VerifyUser(id, verifyUserRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RegisterApi.VerifyUser: " + e.Message);
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
    Debug.Print("Exception when calling RegisterApi.VerifyUserWithHttpInfo: " + e.Message);
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

