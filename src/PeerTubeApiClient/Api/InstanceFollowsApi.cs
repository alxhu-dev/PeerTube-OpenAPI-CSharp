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
    public interface IInstanceFollowsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// List instances following the server
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetAccountFollowers200Response</returns>
        GetAccountFollowers200Response ApiV1ServerFollowersGet(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0);

        /// <summary>
        /// List instances following the server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetAccountFollowers200Response</returns>
        ApiResponse<GetAccountFollowers200Response> ApiV1ServerFollowersGetWithHttpInfo(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0);
        /// <summary>
        /// Accept a pending follower to your server
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1ServerFollowersNameWithHostAcceptPost(string nameWithHost, int operationIndex = 0);

        /// <summary>
        /// Accept a pending follower to your server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1ServerFollowersNameWithHostAcceptPostWithHttpInfo(string nameWithHost, int operationIndex = 0);
        /// <summary>
        /// Remove or reject a follower to your server
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1ServerFollowersNameWithHostDelete(string nameWithHost, int operationIndex = 0);

        /// <summary>
        /// Remove or reject a follower to your server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1ServerFollowersNameWithHostDeleteWithHttpInfo(string nameWithHost, int operationIndex = 0);
        /// <summary>
        /// Reject a pending follower to your server
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1ServerFollowersNameWithHostRejectPost(string nameWithHost, int operationIndex = 0);

        /// <summary>
        /// Reject a pending follower to your server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1ServerFollowersNameWithHostRejectPostWithHttpInfo(string nameWithHost, int operationIndex = 0);
        /// <summary>
        /// List instances followed by the server
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetAccountFollowers200Response</returns>
        GetAccountFollowers200Response ApiV1ServerFollowingGet(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0);

        /// <summary>
        /// List instances followed by the server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetAccountFollowers200Response</returns>
        ApiResponse<GetAccountFollowers200Response> ApiV1ServerFollowingGetWithHttpInfo(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0);
        /// <summary>
        /// Unfollow an actor (PeerTube instance, channel or account)
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="hostOrHandle">The hostOrHandle to unfollow</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1ServerFollowingHostOrHandleDelete(string hostOrHandle, int operationIndex = 0);

        /// <summary>
        /// Unfollow an actor (PeerTube instance, channel or account)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="hostOrHandle">The hostOrHandle to unfollow</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1ServerFollowingHostOrHandleDeleteWithHttpInfo(string hostOrHandle, int operationIndex = 0);
        /// <summary>
        /// Follow a list of actors (PeerTube instance, channel or account)
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1ServerFollowingPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1ServerFollowingPost(ApiV1ServerFollowingPostRequest? apiV1ServerFollowingPostRequest = default(ApiV1ServerFollowingPostRequest?), int operationIndex = 0);

        /// <summary>
        /// Follow a list of actors (PeerTube instance, channel or account)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1ServerFollowingPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1ServerFollowingPostWithHttpInfo(ApiV1ServerFollowingPostRequest? apiV1ServerFollowingPostRequest = default(ApiV1ServerFollowingPostRequest?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IInstanceFollowsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// List instances following the server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetAccountFollowers200Response</returns>
        System.Threading.Tasks.Task<GetAccountFollowers200Response> ApiV1ServerFollowersGetAsync(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List instances following the server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetAccountFollowers200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetAccountFollowers200Response>> ApiV1ServerFollowersGetWithHttpInfoAsync(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Accept a pending follower to your server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1ServerFollowersNameWithHostAcceptPostAsync(string nameWithHost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Accept a pending follower to your server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1ServerFollowersNameWithHostAcceptPostWithHttpInfoAsync(string nameWithHost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Remove or reject a follower to your server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1ServerFollowersNameWithHostDeleteAsync(string nameWithHost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Remove or reject a follower to your server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1ServerFollowersNameWithHostDeleteWithHttpInfoAsync(string nameWithHost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Reject a pending follower to your server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1ServerFollowersNameWithHostRejectPostAsync(string nameWithHost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Reject a pending follower to your server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1ServerFollowersNameWithHostRejectPostWithHttpInfoAsync(string nameWithHost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List instances followed by the server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetAccountFollowers200Response</returns>
        System.Threading.Tasks.Task<GetAccountFollowers200Response> ApiV1ServerFollowingGetAsync(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List instances followed by the server
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetAccountFollowers200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetAccountFollowers200Response>> ApiV1ServerFollowingGetWithHttpInfoAsync(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Unfollow an actor (PeerTube instance, channel or account)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="hostOrHandle">The hostOrHandle to unfollow</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1ServerFollowingHostOrHandleDeleteAsync(string hostOrHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Unfollow an actor (PeerTube instance, channel or account)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="hostOrHandle">The hostOrHandle to unfollow</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1ServerFollowingHostOrHandleDeleteWithHttpInfoAsync(string hostOrHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Follow a list of actors (PeerTube instance, channel or account)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1ServerFollowingPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1ServerFollowingPostAsync(ApiV1ServerFollowingPostRequest? apiV1ServerFollowingPostRequest = default(ApiV1ServerFollowingPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Follow a list of actors (PeerTube instance, channel or account)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1ServerFollowingPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1ServerFollowingPostWithHttpInfoAsync(ApiV1ServerFollowingPostRequest? apiV1ServerFollowingPostRequest = default(ApiV1ServerFollowingPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IInstanceFollowsApi : IInstanceFollowsApiSync, IInstanceFollowsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class InstanceFollowsApi : IInstanceFollowsApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceFollowsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public InstanceFollowsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceFollowsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public InstanceFollowsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="InstanceFollowsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public InstanceFollowsApi(PeerTubeApiClient.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="InstanceFollowsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public InstanceFollowsApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
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
        /// List instances following the server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetAccountFollowers200Response</returns>
        public GetAccountFollowers200Response ApiV1ServerFollowersGet(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<GetAccountFollowers200Response> localVarResponse = ApiV1ServerFollowersGetWithHttpInfo(state, actorType, start, count, sort);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List instances following the server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetAccountFollowers200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<GetAccountFollowers200Response> ApiV1ServerFollowersGetWithHttpInfo(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0)
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

            if (state != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "state", state));
            }
            if (actorType != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "actorType", actorType));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (count != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "count", count));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }

            localVarRequestOptions.Operation = "InstanceFollowsApi.ApiV1ServerFollowersGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GetAccountFollowers200Response>("/api/v1/server/followers", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1ServerFollowersGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List instances following the server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetAccountFollowers200Response</returns>
        public async System.Threading.Tasks.Task<GetAccountFollowers200Response> ApiV1ServerFollowersGetAsync(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<GetAccountFollowers200Response> localVarResponse = await ApiV1ServerFollowersGetWithHttpInfoAsync(state, actorType, start, count, sort, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List instances following the server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetAccountFollowers200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<GetAccountFollowers200Response>> ApiV1ServerFollowersGetWithHttpInfoAsync(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (state != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "state", state));
            }
            if (actorType != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "actorType", actorType));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (count != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "count", count));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }

            localVarRequestOptions.Operation = "InstanceFollowsApi.ApiV1ServerFollowersGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetAccountFollowers200Response>("/api/v1/server/followers", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1ServerFollowersGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Accept a pending follower to your server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1ServerFollowersNameWithHostAcceptPost(string nameWithHost, int operationIndex = 0)
        {
            ApiV1ServerFollowersNameWithHostAcceptPostWithHttpInfo(nameWithHost);
        }

        /// <summary>
        /// Accept a pending follower to your server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1ServerFollowersNameWithHostAcceptPostWithHttpInfo(string nameWithHost, int operationIndex = 0)
        {
            // verify the required parameter 'nameWithHost' is set
            if (nameWithHost == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'nameWithHost' when calling InstanceFollowsApi->ApiV1ServerFollowersNameWithHostAcceptPost");
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

            localVarRequestOptions.PathParameters.Add("nameWithHost", PeerTubeApiClient.Client.ClientUtils.ParameterToString(nameWithHost)); // path parameter

            localVarRequestOptions.Operation = "InstanceFollowsApi.ApiV1ServerFollowersNameWithHostAcceptPost";
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
            var localVarResponse = this.Client.Post<Object>("/api/v1/server/followers/{nameWithHost}/accept", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1ServerFollowersNameWithHostAcceptPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Accept a pending follower to your server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1ServerFollowersNameWithHostAcceptPostAsync(string nameWithHost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1ServerFollowersNameWithHostAcceptPostWithHttpInfoAsync(nameWithHost, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Accept a pending follower to your server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1ServerFollowersNameWithHostAcceptPostWithHttpInfoAsync(string nameWithHost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'nameWithHost' is set
            if (nameWithHost == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'nameWithHost' when calling InstanceFollowsApi->ApiV1ServerFollowersNameWithHostAcceptPost");
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

            localVarRequestOptions.PathParameters.Add("nameWithHost", PeerTubeApiClient.Client.ClientUtils.ParameterToString(nameWithHost)); // path parameter

            localVarRequestOptions.Operation = "InstanceFollowsApi.ApiV1ServerFollowersNameWithHostAcceptPost";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/server/followers/{nameWithHost}/accept", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1ServerFollowersNameWithHostAcceptPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Remove or reject a follower to your server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1ServerFollowersNameWithHostDelete(string nameWithHost, int operationIndex = 0)
        {
            ApiV1ServerFollowersNameWithHostDeleteWithHttpInfo(nameWithHost);
        }

        /// <summary>
        /// Remove or reject a follower to your server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1ServerFollowersNameWithHostDeleteWithHttpInfo(string nameWithHost, int operationIndex = 0)
        {
            // verify the required parameter 'nameWithHost' is set
            if (nameWithHost == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'nameWithHost' when calling InstanceFollowsApi->ApiV1ServerFollowersNameWithHostDelete");
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

            localVarRequestOptions.PathParameters.Add("nameWithHost", PeerTubeApiClient.Client.ClientUtils.ParameterToString(nameWithHost)); // path parameter

            localVarRequestOptions.Operation = "InstanceFollowsApi.ApiV1ServerFollowersNameWithHostDelete";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/server/followers/{nameWithHost}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1ServerFollowersNameWithHostDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Remove or reject a follower to your server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1ServerFollowersNameWithHostDeleteAsync(string nameWithHost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1ServerFollowersNameWithHostDeleteWithHttpInfoAsync(nameWithHost, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Remove or reject a follower to your server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1ServerFollowersNameWithHostDeleteWithHttpInfoAsync(string nameWithHost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'nameWithHost' is set
            if (nameWithHost == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'nameWithHost' when calling InstanceFollowsApi->ApiV1ServerFollowersNameWithHostDelete");
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

            localVarRequestOptions.PathParameters.Add("nameWithHost", PeerTubeApiClient.Client.ClientUtils.ParameterToString(nameWithHost)); // path parameter

            localVarRequestOptions.Operation = "InstanceFollowsApi.ApiV1ServerFollowersNameWithHostDelete";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/server/followers/{nameWithHost}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1ServerFollowersNameWithHostDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Reject a pending follower to your server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1ServerFollowersNameWithHostRejectPost(string nameWithHost, int operationIndex = 0)
        {
            ApiV1ServerFollowersNameWithHostRejectPostWithHttpInfo(nameWithHost);
        }

        /// <summary>
        /// Reject a pending follower to your server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1ServerFollowersNameWithHostRejectPostWithHttpInfo(string nameWithHost, int operationIndex = 0)
        {
            // verify the required parameter 'nameWithHost' is set
            if (nameWithHost == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'nameWithHost' when calling InstanceFollowsApi->ApiV1ServerFollowersNameWithHostRejectPost");
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

            localVarRequestOptions.PathParameters.Add("nameWithHost", PeerTubeApiClient.Client.ClientUtils.ParameterToString(nameWithHost)); // path parameter

            localVarRequestOptions.Operation = "InstanceFollowsApi.ApiV1ServerFollowersNameWithHostRejectPost";
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
            var localVarResponse = this.Client.Post<Object>("/api/v1/server/followers/{nameWithHost}/reject", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1ServerFollowersNameWithHostRejectPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Reject a pending follower to your server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1ServerFollowersNameWithHostRejectPostAsync(string nameWithHost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1ServerFollowersNameWithHostRejectPostWithHttpInfoAsync(nameWithHost, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Reject a pending follower to your server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="nameWithHost">The remote actor handle to remove from your followers</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1ServerFollowersNameWithHostRejectPostWithHttpInfoAsync(string nameWithHost, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'nameWithHost' is set
            if (nameWithHost == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'nameWithHost' when calling InstanceFollowsApi->ApiV1ServerFollowersNameWithHostRejectPost");
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

            localVarRequestOptions.PathParameters.Add("nameWithHost", PeerTubeApiClient.Client.ClientUtils.ParameterToString(nameWithHost)); // path parameter

            localVarRequestOptions.Operation = "InstanceFollowsApi.ApiV1ServerFollowersNameWithHostRejectPost";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/server/followers/{nameWithHost}/reject", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1ServerFollowersNameWithHostRejectPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List instances followed by the server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetAccountFollowers200Response</returns>
        public GetAccountFollowers200Response ApiV1ServerFollowingGet(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<GetAccountFollowers200Response> localVarResponse = ApiV1ServerFollowingGetWithHttpInfo(state, actorType, start, count, sort);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List instances followed by the server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetAccountFollowers200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<GetAccountFollowers200Response> ApiV1ServerFollowingGetWithHttpInfo(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0)
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

            if (state != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "state", state));
            }
            if (actorType != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "actorType", actorType));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (count != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "count", count));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }

            localVarRequestOptions.Operation = "InstanceFollowsApi.ApiV1ServerFollowingGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GetAccountFollowers200Response>("/api/v1/server/following", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1ServerFollowingGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List instances followed by the server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetAccountFollowers200Response</returns>
        public async System.Threading.Tasks.Task<GetAccountFollowers200Response> ApiV1ServerFollowingGetAsync(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<GetAccountFollowers200Response> localVarResponse = await ApiV1ServerFollowingGetWithHttpInfoAsync(state, actorType, start, count, sort, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List instances followed by the server 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="state"> (optional)</param>
        /// <param name="actorType"> (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetAccountFollowers200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<GetAccountFollowers200Response>> ApiV1ServerFollowingGetWithHttpInfoAsync(string? state = default(string?), string? actorType = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (state != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "state", state));
            }
            if (actorType != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "actorType", actorType));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (count != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "count", count));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }

            localVarRequestOptions.Operation = "InstanceFollowsApi.ApiV1ServerFollowingGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetAccountFollowers200Response>("/api/v1/server/following", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1ServerFollowingGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Unfollow an actor (PeerTube instance, channel or account) 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="hostOrHandle">The hostOrHandle to unfollow</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1ServerFollowingHostOrHandleDelete(string hostOrHandle, int operationIndex = 0)
        {
            ApiV1ServerFollowingHostOrHandleDeleteWithHttpInfo(hostOrHandle);
        }

        /// <summary>
        /// Unfollow an actor (PeerTube instance, channel or account) 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="hostOrHandle">The hostOrHandle to unfollow</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1ServerFollowingHostOrHandleDeleteWithHttpInfo(string hostOrHandle, int operationIndex = 0)
        {
            // verify the required parameter 'hostOrHandle' is set
            if (hostOrHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'hostOrHandle' when calling InstanceFollowsApi->ApiV1ServerFollowingHostOrHandleDelete");
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

            localVarRequestOptions.PathParameters.Add("hostOrHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(hostOrHandle)); // path parameter

            localVarRequestOptions.Operation = "InstanceFollowsApi.ApiV1ServerFollowingHostOrHandleDelete";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/server/following/{hostOrHandle}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1ServerFollowingHostOrHandleDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Unfollow an actor (PeerTube instance, channel or account) 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="hostOrHandle">The hostOrHandle to unfollow</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1ServerFollowingHostOrHandleDeleteAsync(string hostOrHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1ServerFollowingHostOrHandleDeleteWithHttpInfoAsync(hostOrHandle, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Unfollow an actor (PeerTube instance, channel or account) 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="hostOrHandle">The hostOrHandle to unfollow</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1ServerFollowingHostOrHandleDeleteWithHttpInfoAsync(string hostOrHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'hostOrHandle' is set
            if (hostOrHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'hostOrHandle' when calling InstanceFollowsApi->ApiV1ServerFollowingHostOrHandleDelete");
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

            localVarRequestOptions.PathParameters.Add("hostOrHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(hostOrHandle)); // path parameter

            localVarRequestOptions.Operation = "InstanceFollowsApi.ApiV1ServerFollowingHostOrHandleDelete";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/server/following/{hostOrHandle}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1ServerFollowingHostOrHandleDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Follow a list of actors (PeerTube instance, channel or account) 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1ServerFollowingPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1ServerFollowingPost(ApiV1ServerFollowingPostRequest? apiV1ServerFollowingPostRequest = default(ApiV1ServerFollowingPostRequest?), int operationIndex = 0)
        {
            ApiV1ServerFollowingPostWithHttpInfo(apiV1ServerFollowingPostRequest);
        }

        /// <summary>
        /// Follow a list of actors (PeerTube instance, channel or account) 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1ServerFollowingPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1ServerFollowingPostWithHttpInfo(ApiV1ServerFollowingPostRequest? apiV1ServerFollowingPostRequest = default(ApiV1ServerFollowingPostRequest?), int operationIndex = 0)
        {
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

            localVarRequestOptions.Data = apiV1ServerFollowingPostRequest;

            localVarRequestOptions.Operation = "InstanceFollowsApi.ApiV1ServerFollowingPost";
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
            var localVarResponse = this.Client.Post<Object>("/api/v1/server/following", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1ServerFollowingPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Follow a list of actors (PeerTube instance, channel or account) 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1ServerFollowingPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1ServerFollowingPostAsync(ApiV1ServerFollowingPostRequest? apiV1ServerFollowingPostRequest = default(ApiV1ServerFollowingPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1ServerFollowingPostWithHttpInfoAsync(apiV1ServerFollowingPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Follow a list of actors (PeerTube instance, channel or account) 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1ServerFollowingPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1ServerFollowingPostWithHttpInfoAsync(ApiV1ServerFollowingPostRequest? apiV1ServerFollowingPostRequest = default(ApiV1ServerFollowingPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

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

            localVarRequestOptions.Data = apiV1ServerFollowingPostRequest;

            localVarRequestOptions.Operation = "InstanceFollowsApi.ApiV1ServerFollowingPost";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/server/following", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1ServerFollowingPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
