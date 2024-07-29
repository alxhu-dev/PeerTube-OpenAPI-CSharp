/*
 * PeerTube
 *
 * The PeerTube API is built on HTTP(S) and is RESTful. You can use your favorite HTTP/REST library for your programming language to use PeerTube. The spec API is fully compatible with [openapi-generator](https://github.com/OpenAPITools/openapi-generator/wiki/API-client-generator-HOWTO) which generates a client SDK in the language of your choice - we generate some client SDKs automatically:  - [Python](https://framagit.org/framasoft/peertube/clients/python) - [Go](https://framagit.org/framasoft/peertube/clients/go) - [Kotlin](https://framagit.org/framasoft/peertube/clients/kotlin)  See the [REST API quick start](https://docs.joinpeertube.org/api/rest-getting-started) for a few examples of using the PeerTube API.  # Authentication  When you sign up for an account on a PeerTube instance, you are given the possibility to generate sessions on it, and authenticate there using an access token. Only __one access token can currently be used at a time__.  ## Roles  Accounts are given permissions based on their role. There are three roles on PeerTube: Administrator, Moderator, and User. See the [roles guide](https://docs.joinpeertube.org/admin/managing-users#roles) for a detail of their permissions.  # Errors  The API uses standard HTTP status codes to indicate the success or failure of the API call, completed by a [RFC7807-compliant](https://tools.ietf.org/html/rfc7807) response body.  ``` HTTP 1.1 404 Not Found Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Video not found\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"status\": 404,   \"title\": \"Not Found\",   \"type\": \"about:blank\" } ```  We provide error `type` (following RFC7807) and `code` (internal PeerTube code) values for [a growing number of cases](https://github.com/Chocobozzz/PeerTube/blob/develop/packages/models/src/server/server-error-code.enum.ts), but it is still optional. Types are used to disambiguate errors that bear the same status code and are non-obvious:  ``` HTTP 1.1 403 Forbidden Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Cannot get this video regarding follow constraints\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"status\": 403,   \"title\": \"Forbidden\",   \"type\": \"https://docs.joinpeertube.org/api-rest-reference.html#section/Errors/does_not_respect_follow_constraints\" } ```  Here a 403 error could otherwise mean that the video is private or blocklisted.  ### Validation errors  Each parameter is evaluated on its own against a set of rules before the route validator proceeds with potential testing involving parameter combinations. Errors coming from validation errors appear earlier and benefit from a more detailed error description:  ``` HTTP 1.1 400 Bad Request Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Incorrect request parameters: id\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"instance\": \"/api/v1/videos/9c9de5e8-0a1e-484a-b099-e80766180\",   \"invalid-params\": {     \"id\": {       \"location\": \"params\",       \"msg\": \"Invalid value\",       \"param\": \"id\",       \"value\": \"9c9de5e8-0a1e-484a-b099-e80766180\"     }   },   \"status\": 400,   \"title\": \"Bad Request\",   \"type\": \"about:blank\" } ```  Where `id` is the name of the field concerned by the error, within the route definition. `invalid-params.<field>.location` can be either 'params', 'body', 'header', 'query' or 'cookies', and `invalid-params.<field>.value` reports the value that didn't pass validation whose `invalid-params.<field>.msg` is about.  ### Deprecated error fields  Some fields could be included with previous versions. They are still included but their use is deprecated: - `error`: superseded by `detail`  # Rate limits  We are rate-limiting all endpoints of PeerTube's API. Custom values can be set by administrators:  | Endpoint (prefix: `/api/v1`) | Calls         | Time frame   | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- --|- -- -- -- -- -- -- -| | `/_*`                         | 50            | 10 seconds   | | `POST /users/token`          | 15            | 5 minutes    | | `POST /users/register`       | 2<sup>*</sup> | 5 minutes    | | `POST /users/ask-send-verify-email` | 3      | 5 minutes    |  Depending on the endpoint, <sup>*</sup>failed requests are not taken into account. A service limit is announced by a `429 Too Many Requests` status code.  You can get details about the current state of your rate limit by reading the following headers:  | Header                  | Description                                                | |- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | `X-RateLimit-Limit`     | Number of max requests allowed in the current time period  | | `X-RateLimit-Remaining` | Number of remaining requests in the current time period    | | `X-RateLimit-Reset`     | Timestamp of end of current time period as UNIX timestamp  | | `Retry-After`           | Seconds to delay after the first `429` is received         |  # CORS  This API features [Cross-Origin Resource Sharing (CORS)](https://fetch.spec.whatwg.org/), allowing cross-domain communication from the browser for some routes:  | Endpoint                    | |- -- -- -- -- -- -- -- -- -- -- -- -- - --| | `/api/_*`                    | | `/download/_*`               | | `/lazy-static/_*`            | | `/.well-known/webfinger`    |  In addition, all routes serving ActivityPub are CORS-enabled for all origins. 
 *
 * The version of the OpenAPI document: 6.2.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Client.Auth;
using PeerTubeApiClient.Model;

namespace PeerTubeApiClient.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IWatchedWordsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// List account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName">account name to list watched words</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1WatchedWordsAccountsAccountNameListsGet200Response</returns>
        ApiV1WatchedWordsAccountsAccountNameListsGet200Response ApiV1WatchedWordsAccountsAccountNameListsGet(string accountName, int operationIndex = 0);

        /// <summary>
        /// List account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName">account name to list watched words</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1WatchedWordsAccountsAccountNameListsGet200Response</returns>
        ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsGet200Response> ApiV1WatchedWordsAccountsAccountNameListsGetWithHttpInfo(string accountName, int operationIndex = 0);
        /// <summary>
        /// Delete account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1WatchedWordsAccountsAccountNameListsListIdDelete(string accountName, string listId, int operationIndex = 0);

        /// <summary>
        /// Delete account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1WatchedWordsAccountsAccountNameListsListIdDeleteWithHttpInfo(string accountName, string listId, int operationIndex = 0);
        /// <summary>
        /// Update account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1WatchedWordsAccountsAccountNameListsListIdPut(string accountName, string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0);

        /// <summary>
        /// Update account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1WatchedWordsAccountsAccountNameListsListIdPutWithHttpInfo(string accountName, string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0);
        /// <summary>
        /// Add account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1WatchedWordsAccountsAccountNameListsPost200Response</returns>
        ApiV1WatchedWordsAccountsAccountNameListsPost200Response ApiV1WatchedWordsAccountsAccountNameListsPost(string accountName, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0);

        /// <summary>
        /// Add account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1WatchedWordsAccountsAccountNameListsPost200Response</returns>
        ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsPost200Response> ApiV1WatchedWordsAccountsAccountNameListsPostWithHttpInfo(string accountName, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0);
        /// <summary>
        /// List server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1WatchedWordsAccountsAccountNameListsGet200Response</returns>
        ApiV1WatchedWordsAccountsAccountNameListsGet200Response ApiV1WatchedWordsServerListsGet(int operationIndex = 0);

        /// <summary>
        /// List server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1WatchedWordsAccountsAccountNameListsGet200Response</returns>
        ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsGet200Response> ApiV1WatchedWordsServerListsGetWithHttpInfo(int operationIndex = 0);
        /// <summary>
        /// Delete server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1WatchedWordsServerListsListIdDelete(string listId, int operationIndex = 0);

        /// <summary>
        /// Delete server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1WatchedWordsServerListsListIdDeleteWithHttpInfo(string listId, int operationIndex = 0);
        /// <summary>
        /// Update server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1WatchedWordsServerListsListIdPut(string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0);

        /// <summary>
        /// Update server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1WatchedWordsServerListsListIdPutWithHttpInfo(string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0);
        /// <summary>
        /// Add server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1WatchedWordsAccountsAccountNameListsPost200Response</returns>
        ApiV1WatchedWordsAccountsAccountNameListsPost200Response ApiV1WatchedWordsServerListsPost(ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0);

        /// <summary>
        /// Add server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1WatchedWordsAccountsAccountNameListsPost200Response</returns>
        ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsPost200Response> ApiV1WatchedWordsServerListsPostWithHttpInfo(ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IWatchedWordsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// List account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName">account name to list watched words</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1WatchedWordsAccountsAccountNameListsGet200Response</returns>
        System.Threading.Tasks.Task<ApiV1WatchedWordsAccountsAccountNameListsGet200Response> ApiV1WatchedWordsAccountsAccountNameListsGetAsync(string accountName, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName">account name to list watched words</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1WatchedWordsAccountsAccountNameListsGet200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsGet200Response>> ApiV1WatchedWordsAccountsAccountNameListsGetWithHttpInfoAsync(string accountName, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1WatchedWordsAccountsAccountNameListsListIdDeleteAsync(string accountName, string listId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1WatchedWordsAccountsAccountNameListsListIdDeleteWithHttpInfoAsync(string accountName, string listId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1WatchedWordsAccountsAccountNameListsListIdPutAsync(string accountName, string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1WatchedWordsAccountsAccountNameListsListIdPutWithHttpInfoAsync(string accountName, string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1WatchedWordsAccountsAccountNameListsPost200Response</returns>
        System.Threading.Tasks.Task<ApiV1WatchedWordsAccountsAccountNameListsPost200Response> ApiV1WatchedWordsAccountsAccountNameListsPostAsync(string accountName, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add account watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1WatchedWordsAccountsAccountNameListsPost200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsPost200Response>> ApiV1WatchedWordsAccountsAccountNameListsPostWithHttpInfoAsync(string accountName, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1WatchedWordsAccountsAccountNameListsGet200Response</returns>
        System.Threading.Tasks.Task<ApiV1WatchedWordsAccountsAccountNameListsGet200Response> ApiV1WatchedWordsServerListsGetAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1WatchedWordsAccountsAccountNameListsGet200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsGet200Response>> ApiV1WatchedWordsServerListsGetWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1WatchedWordsServerListsListIdDeleteAsync(string listId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1WatchedWordsServerListsListIdDeleteWithHttpInfoAsync(string listId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1WatchedWordsServerListsListIdPutAsync(string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1WatchedWordsServerListsListIdPutWithHttpInfoAsync(string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1WatchedWordsAccountsAccountNameListsPost200Response</returns>
        System.Threading.Tasks.Task<ApiV1WatchedWordsAccountsAccountNameListsPost200Response> ApiV1WatchedWordsServerListsPostAsync(ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add server watched words
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1WatchedWordsAccountsAccountNameListsPost200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsPost200Response>> ApiV1WatchedWordsServerListsPostWithHttpInfoAsync(ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IWatchedWordsApi : IWatchedWordsApiSync, IWatchedWordsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class WatchedWordsApi : IWatchedWordsApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="WatchedWordsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public WatchedWordsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WatchedWordsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public WatchedWordsApi(string basePath)
        {
            this.Configuration = PeerTubeApiClient.Client.Configuration.MergeConfigurations(
                PeerTubeApiClient.Client.GlobalConfiguration.Instance,
                new PeerTubeApiClient.Client.Configuration { BasePath = basePath }
            );
            this.Client = new PeerTubeApiClient.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new PeerTubeApiClient.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = PeerTubeApiClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WatchedWordsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public WatchedWordsApi(PeerTubeApiClient.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = PeerTubeApiClient.Client.Configuration.MergeConfigurations(
                PeerTubeApiClient.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new PeerTubeApiClient.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new PeerTubeApiClient.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = PeerTubeApiClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WatchedWordsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public WatchedWordsApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = PeerTubeApiClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public PeerTubeApiClient.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public PeerTubeApiClient.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public PeerTubeApiClient.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public PeerTubeApiClient.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// List account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName">account name to list watched words</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1WatchedWordsAccountsAccountNameListsGet200Response</returns>
        public ApiV1WatchedWordsAccountsAccountNameListsGet200Response ApiV1WatchedWordsAccountsAccountNameListsGet(string accountName, int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsGet200Response> localVarResponse = ApiV1WatchedWordsAccountsAccountNameListsGetWithHttpInfo(accountName);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName">account name to list watched words</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1WatchedWordsAccountsAccountNameListsGet200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsGet200Response> ApiV1WatchedWordsAccountsAccountNameListsGetWithHttpInfo(string accountName, int operationIndex = 0)
        {
            // verify the required parameter 'accountName' is set
            if (accountName == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'accountName' when calling WatchedWordsApi->ApiV1WatchedWordsAccountsAccountNameListsGet");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("accountName", PeerTubeApiClient.Client.ClientUtils.ParameterToString(accountName)); // path parameter

            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsGet";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<ApiV1WatchedWordsAccountsAccountNameListsGet200Response>("/api/v1/watched-words/accounts/{accountName}/lists", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsAccountsAccountNameListsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName">account name to list watched words</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1WatchedWordsAccountsAccountNameListsGet200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1WatchedWordsAccountsAccountNameListsGet200Response> ApiV1WatchedWordsAccountsAccountNameListsGetAsync(string accountName, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsGet200Response> localVarResponse = await ApiV1WatchedWordsAccountsAccountNameListsGetWithHttpInfoAsync(accountName, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName">account name to list watched words</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1WatchedWordsAccountsAccountNameListsGet200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsGet200Response>> ApiV1WatchedWordsAccountsAccountNameListsGetWithHttpInfoAsync(string accountName, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'accountName' is set
            if (accountName == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'accountName' when calling WatchedWordsApi->ApiV1WatchedWordsAccountsAccountNameListsGet");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("accountName", PeerTubeApiClient.Client.ClientUtils.ParameterToString(accountName)); // path parameter

            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsGet";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApiV1WatchedWordsAccountsAccountNameListsGet200Response>("/api/v1/watched-words/accounts/{accountName}/lists", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsAccountsAccountNameListsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1WatchedWordsAccountsAccountNameListsListIdDelete(string accountName, string listId, int operationIndex = 0)
        {
            ApiV1WatchedWordsAccountsAccountNameListsListIdDeleteWithHttpInfo(accountName, listId);
        }

        /// <summary>
        /// Delete account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1WatchedWordsAccountsAccountNameListsListIdDeleteWithHttpInfo(string accountName, string listId, int operationIndex = 0)
        {
            // verify the required parameter 'accountName' is set
            if (accountName == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'accountName' when calling WatchedWordsApi->ApiV1WatchedWordsAccountsAccountNameListsListIdDelete");
            }

            // verify the required parameter 'listId' is set
            if (listId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'listId' when calling WatchedWordsApi->ApiV1WatchedWordsAccountsAccountNameListsListIdDelete");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("accountName", PeerTubeApiClient.Client.ClientUtils.ParameterToString(accountName)); // path parameter
            localVarRequestOptions.PathParameters.Add("listId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(listId)); // path parameter

            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsListIdDelete";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/api/v1/watched-words/accounts/{accountName}/lists/{listId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsAccountsAccountNameListsListIdDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1WatchedWordsAccountsAccountNameListsListIdDeleteAsync(string accountName, string listId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1WatchedWordsAccountsAccountNameListsListIdDeleteWithHttpInfoAsync(accountName, listId, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1WatchedWordsAccountsAccountNameListsListIdDeleteWithHttpInfoAsync(string accountName, string listId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'accountName' is set
            if (accountName == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'accountName' when calling WatchedWordsApi->ApiV1WatchedWordsAccountsAccountNameListsListIdDelete");
            }

            // verify the required parameter 'listId' is set
            if (listId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'listId' when calling WatchedWordsApi->ApiV1WatchedWordsAccountsAccountNameListsListIdDelete");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("accountName", PeerTubeApiClient.Client.ClientUtils.ParameterToString(accountName)); // path parameter
            localVarRequestOptions.PathParameters.Add("listId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(listId)); // path parameter

            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsListIdDelete";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/watched-words/accounts/{accountName}/lists/{listId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsAccountsAccountNameListsListIdDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1WatchedWordsAccountsAccountNameListsListIdPut(string accountName, string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0)
        {
            ApiV1WatchedWordsAccountsAccountNameListsListIdPutWithHttpInfo(accountName, listId, apiV1WatchedWordsAccountsAccountNameListsPostRequest);
        }

        /// <summary>
        /// Update account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1WatchedWordsAccountsAccountNameListsListIdPutWithHttpInfo(string accountName, string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0)
        {
            // verify the required parameter 'accountName' is set
            if (accountName == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'accountName' when calling WatchedWordsApi->ApiV1WatchedWordsAccountsAccountNameListsListIdPut");
            }

            // verify the required parameter 'listId' is set
            if (listId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'listId' when calling WatchedWordsApi->ApiV1WatchedWordsAccountsAccountNameListsListIdPut");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("accountName", PeerTubeApiClient.Client.ClientUtils.ParameterToString(accountName)); // path parameter
            localVarRequestOptions.PathParameters.Add("listId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(listId)); // path parameter
            localVarRequestOptions.Data = apiV1WatchedWordsAccountsAccountNameListsPostRequest;

            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsListIdPut";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Put<Object>("/api/v1/watched-words/accounts/{accountName}/lists/{listId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsAccountsAccountNameListsListIdPut", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1WatchedWordsAccountsAccountNameListsListIdPutAsync(string accountName, string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1WatchedWordsAccountsAccountNameListsListIdPutWithHttpInfoAsync(accountName, listId, apiV1WatchedWordsAccountsAccountNameListsPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1WatchedWordsAccountsAccountNameListsListIdPutWithHttpInfoAsync(string accountName, string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'accountName' is set
            if (accountName == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'accountName' when calling WatchedWordsApi->ApiV1WatchedWordsAccountsAccountNameListsListIdPut");
            }

            // verify the required parameter 'listId' is set
            if (listId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'listId' when calling WatchedWordsApi->ApiV1WatchedWordsAccountsAccountNameListsListIdPut");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("accountName", PeerTubeApiClient.Client.ClientUtils.ParameterToString(accountName)); // path parameter
            localVarRequestOptions.PathParameters.Add("listId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(listId)); // path parameter
            localVarRequestOptions.Data = apiV1WatchedWordsAccountsAccountNameListsPostRequest;

            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsListIdPut";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/api/v1/watched-words/accounts/{accountName}/lists/{listId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsAccountsAccountNameListsListIdPut", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1WatchedWordsAccountsAccountNameListsPost200Response</returns>
        public ApiV1WatchedWordsAccountsAccountNameListsPost200Response ApiV1WatchedWordsAccountsAccountNameListsPost(string accountName, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsPost200Response> localVarResponse = ApiV1WatchedWordsAccountsAccountNameListsPostWithHttpInfo(accountName, apiV1WatchedWordsAccountsAccountNameListsPostRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1WatchedWordsAccountsAccountNameListsPost200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsPost200Response> ApiV1WatchedWordsAccountsAccountNameListsPostWithHttpInfo(string accountName, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0)
        {
            // verify the required parameter 'accountName' is set
            if (accountName == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'accountName' when calling WatchedWordsApi->ApiV1WatchedWordsAccountsAccountNameListsPost");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("accountName", PeerTubeApiClient.Client.ClientUtils.ParameterToString(accountName)); // path parameter
            localVarRequestOptions.Data = apiV1WatchedWordsAccountsAccountNameListsPostRequest;

            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsPost";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<ApiV1WatchedWordsAccountsAccountNameListsPost200Response>("/api/v1/watched-words/accounts/{accountName}/lists", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsAccountsAccountNameListsPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1WatchedWordsAccountsAccountNameListsPost200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1WatchedWordsAccountsAccountNameListsPost200Response> ApiV1WatchedWordsAccountsAccountNameListsPostAsync(string accountName, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsPost200Response> localVarResponse = await ApiV1WatchedWordsAccountsAccountNameListsPostWithHttpInfoAsync(accountName, apiV1WatchedWordsAccountsAccountNameListsPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add account watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="accountName"></param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1WatchedWordsAccountsAccountNameListsPost200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsPost200Response>> ApiV1WatchedWordsAccountsAccountNameListsPostWithHttpInfoAsync(string accountName, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'accountName' is set
            if (accountName == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'accountName' when calling WatchedWordsApi->ApiV1WatchedWordsAccountsAccountNameListsPost");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("accountName", PeerTubeApiClient.Client.ClientUtils.ParameterToString(accountName)); // path parameter
            localVarRequestOptions.Data = apiV1WatchedWordsAccountsAccountNameListsPostRequest;

            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsAccountsAccountNameListsPost";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<ApiV1WatchedWordsAccountsAccountNameListsPost200Response>("/api/v1/watched-words/accounts/{accountName}/lists", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsAccountsAccountNameListsPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1WatchedWordsAccountsAccountNameListsGet200Response</returns>
        public ApiV1WatchedWordsAccountsAccountNameListsGet200Response ApiV1WatchedWordsServerListsGet(int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsGet200Response> localVarResponse = ApiV1WatchedWordsServerListsGetWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// List server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1WatchedWordsAccountsAccountNameListsGet200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsGet200Response> ApiV1WatchedWordsServerListsGetWithHttpInfo(int operationIndex = 0)
        {
            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }


            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsServerListsGet";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<ApiV1WatchedWordsAccountsAccountNameListsGet200Response>("/api/v1/watched-words/server/lists", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsServerListsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1WatchedWordsAccountsAccountNameListsGet200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1WatchedWordsAccountsAccountNameListsGet200Response> ApiV1WatchedWordsServerListsGetAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsGet200Response> localVarResponse = await ApiV1WatchedWordsServerListsGetWithHttpInfoAsync(operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1WatchedWordsAccountsAccountNameListsGet200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsGet200Response>> ApiV1WatchedWordsServerListsGetWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }


            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsServerListsGet";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApiV1WatchedWordsAccountsAccountNameListsGet200Response>("/api/v1/watched-words/server/lists", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsServerListsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1WatchedWordsServerListsListIdDelete(string listId, int operationIndex = 0)
        {
            ApiV1WatchedWordsServerListsListIdDeleteWithHttpInfo(listId);
        }

        /// <summary>
        /// Delete server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1WatchedWordsServerListsListIdDeleteWithHttpInfo(string listId, int operationIndex = 0)
        {
            // verify the required parameter 'listId' is set
            if (listId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'listId' when calling WatchedWordsApi->ApiV1WatchedWordsServerListsListIdDelete");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("listId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(listId)); // path parameter

            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsServerListsListIdDelete";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/api/v1/watched-words/server/lists/{listId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsServerListsListIdDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1WatchedWordsServerListsListIdDeleteAsync(string listId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1WatchedWordsServerListsListIdDeleteWithHttpInfoAsync(listId, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to delete</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1WatchedWordsServerListsListIdDeleteWithHttpInfoAsync(string listId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'listId' is set
            if (listId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'listId' when calling WatchedWordsApi->ApiV1WatchedWordsServerListsListIdDelete");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("listId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(listId)); // path parameter

            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsServerListsListIdDelete";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/watched-words/server/lists/{listId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsServerListsListIdDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1WatchedWordsServerListsListIdPut(string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0)
        {
            ApiV1WatchedWordsServerListsListIdPutWithHttpInfo(listId, apiV1WatchedWordsAccountsAccountNameListsPostRequest);
        }

        /// <summary>
        /// Update server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1WatchedWordsServerListsListIdPutWithHttpInfo(string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0)
        {
            // verify the required parameter 'listId' is set
            if (listId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'listId' when calling WatchedWordsApi->ApiV1WatchedWordsServerListsListIdPut");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("listId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(listId)); // path parameter
            localVarRequestOptions.Data = apiV1WatchedWordsAccountsAccountNameListsPostRequest;

            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsServerListsListIdPut";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Put<Object>("/api/v1/watched-words/server/lists/{listId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsServerListsListIdPut", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1WatchedWordsServerListsListIdPutAsync(string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1WatchedWordsServerListsListIdPutWithHttpInfoAsync(listId, apiV1WatchedWordsAccountsAccountNameListsPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="listId">list of watched words to update</param>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1WatchedWordsServerListsListIdPutWithHttpInfoAsync(string listId, ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'listId' is set
            if (listId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'listId' when calling WatchedWordsApi->ApiV1WatchedWordsServerListsListIdPut");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("listId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(listId)); // path parameter
            localVarRequestOptions.Data = apiV1WatchedWordsAccountsAccountNameListsPostRequest;

            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsServerListsListIdPut";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/api/v1/watched-words/server/lists/{listId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsServerListsListIdPut", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1WatchedWordsAccountsAccountNameListsPost200Response</returns>
        public ApiV1WatchedWordsAccountsAccountNameListsPost200Response ApiV1WatchedWordsServerListsPost(ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsPost200Response> localVarResponse = ApiV1WatchedWordsServerListsPostWithHttpInfo(apiV1WatchedWordsAccountsAccountNameListsPostRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1WatchedWordsAccountsAccountNameListsPost200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsPost200Response> ApiV1WatchedWordsServerListsPostWithHttpInfo(ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.Data = apiV1WatchedWordsAccountsAccountNameListsPostRequest;

            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsServerListsPost";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<ApiV1WatchedWordsAccountsAccountNameListsPost200Response>("/api/v1/watched-words/server/lists", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsServerListsPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1WatchedWordsAccountsAccountNameListsPost200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1WatchedWordsAccountsAccountNameListsPost200Response> ApiV1WatchedWordsServerListsPostAsync(ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsPost200Response> localVarResponse = await ApiV1WatchedWordsServerListsPostWithHttpInfoAsync(apiV1WatchedWordsAccountsAccountNameListsPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add server watched words **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1WatchedWordsAccountsAccountNameListsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1WatchedWordsAccountsAccountNameListsPost200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1WatchedWordsAccountsAccountNameListsPost200Response>> ApiV1WatchedWordsServerListsPostWithHttpInfoAsync(ApiV1WatchedWordsAccountsAccountNameListsPostRequest? apiV1WatchedWordsAccountsAccountNameListsPostRequest = default(ApiV1WatchedWordsAccountsAccountNameListsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.Data = apiV1WatchedWordsAccountsAccountNameListsPostRequest;

            localVarRequestOptions.Operation = "WatchedWordsApi.ApiV1WatchedWordsServerListsPost";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<ApiV1WatchedWordsAccountsAccountNameListsPost200Response>("/api/v1/watched-words/server/lists", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1WatchedWordsServerListsPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
