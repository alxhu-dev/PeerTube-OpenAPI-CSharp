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
    public interface IAbusesApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete an abuse
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1AbusesAbuseIdDelete(int abuseId, int operationIndex = 0);

        /// <summary>
        /// Delete an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1AbusesAbuseIdDeleteWithHttpInfo(int abuseId, int operationIndex = 0);
        /// <summary>
        /// Delete an abuse message
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="abuseMessageId">Abuse message id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1AbusesAbuseIdMessagesAbuseMessageIdDelete(int abuseId, int abuseMessageId, int operationIndex = 0);

        /// <summary>
        /// Delete an abuse message
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="abuseMessageId">Abuse message id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1AbusesAbuseIdMessagesAbuseMessageIdDeleteWithHttpInfo(int abuseId, int abuseMessageId, int operationIndex = 0);
        /// <summary>
        /// List messages of an abuse
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1AbusesAbuseIdMessagesGet200Response</returns>
        ApiV1AbusesAbuseIdMessagesGet200Response ApiV1AbusesAbuseIdMessagesGet(int abuseId, int operationIndex = 0);

        /// <summary>
        /// List messages of an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1AbusesAbuseIdMessagesGet200Response</returns>
        ApiResponse<ApiV1AbusesAbuseIdMessagesGet200Response> ApiV1AbusesAbuseIdMessagesGetWithHttpInfo(int abuseId, int operationIndex = 0);
        /// <summary>
        /// Add message to an abuse
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdMessagesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1AbusesAbuseIdMessagesPost(int abuseId, ApiV1AbusesAbuseIdMessagesPostRequest apiV1AbusesAbuseIdMessagesPostRequest, int operationIndex = 0);

        /// <summary>
        /// Add message to an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdMessagesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1AbusesAbuseIdMessagesPostWithHttpInfo(int abuseId, ApiV1AbusesAbuseIdMessagesPostRequest apiV1AbusesAbuseIdMessagesPostRequest, int operationIndex = 0);
        /// <summary>
        /// Update an abuse
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdPutRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1AbusesAbuseIdPut(int abuseId, ApiV1AbusesAbuseIdPutRequest? apiV1AbusesAbuseIdPutRequest = default(ApiV1AbusesAbuseIdPutRequest?), int operationIndex = 0);

        /// <summary>
        /// Update an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdPutRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1AbusesAbuseIdPutWithHttpInfo(int abuseId, ApiV1AbusesAbuseIdPutRequest? apiV1AbusesAbuseIdPutRequest = default(ApiV1AbusesAbuseIdPutRequest?), int operationIndex = 0);
        /// <summary>
        /// Report an abuse
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1AbusesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1AbusesPost200Response</returns>
        ApiV1AbusesPost200Response ApiV1AbusesPost(ApiV1AbusesPostRequest apiV1AbusesPostRequest, int operationIndex = 0);

        /// <summary>
        /// Report an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1AbusesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1AbusesPost200Response</returns>
        ApiResponse<ApiV1AbusesPost200Response> ApiV1AbusesPostWithHttpInfo(ApiV1AbusesPostRequest apiV1AbusesPostRequest, int operationIndex = 0);
        /// <summary>
        /// List abuses
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="predefinedReason">predefined reason the listed reports should contain (optional)</param>
        /// <param name="search">plain search that will match with video titles, reporter names and more (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="searchReporter">only list reports of a specific reporter (optional)</param>
        /// <param name="searchReportee">only list reports of a specific reportee (optional)</param>
        /// <param name="searchVideo">only list reports of a specific video (optional)</param>
        /// <param name="searchVideoChannel">only list reports of a specific video channel (optional)</param>
        /// <param name="videoIs">only list deleted or blocklisted videos (optional)</param>
        /// <param name="filter">only list account, comment or video reports (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetMyAbuses200Response</returns>
        GetMyAbuses200Response GetAbuses(int? id = default(int?), List<string>? predefinedReason = default(List<string>?), string? search = default(string?), AbuseStateSet? state = default(AbuseStateSet?), string? searchReporter = default(string?), string? searchReportee = default(string?), string? searchVideo = default(string?), string? searchVideoChannel = default(string?), string? videoIs = default(string?), string? filter = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0);

        /// <summary>
        /// List abuses
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="predefinedReason">predefined reason the listed reports should contain (optional)</param>
        /// <param name="search">plain search that will match with video titles, reporter names and more (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="searchReporter">only list reports of a specific reporter (optional)</param>
        /// <param name="searchReportee">only list reports of a specific reportee (optional)</param>
        /// <param name="searchVideo">only list reports of a specific video (optional)</param>
        /// <param name="searchVideoChannel">only list reports of a specific video channel (optional)</param>
        /// <param name="videoIs">only list deleted or blocklisted videos (optional)</param>
        /// <param name="filter">only list account, comment or video reports (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetMyAbuses200Response</returns>
        ApiResponse<GetMyAbuses200Response> GetAbusesWithHttpInfo(int? id = default(int?), List<string>? predefinedReason = default(List<string>?), string? search = default(string?), AbuseStateSet? state = default(AbuseStateSet?), string? searchReporter = default(string?), string? searchReportee = default(string?), string? searchVideo = default(string?), string? searchVideoChannel = default(string?), string? videoIs = default(string?), string? filter = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0);
        /// <summary>
        /// List my abuses
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetMyAbuses200Response</returns>
        GetMyAbuses200Response GetMyAbuses(int? id = default(int?), AbuseStateSet? state = default(AbuseStateSet?), string? sort = default(string?), int? start = default(int?), int? count = default(int?), int operationIndex = 0);

        /// <summary>
        /// List my abuses
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetMyAbuses200Response</returns>
        ApiResponse<GetMyAbuses200Response> GetMyAbusesWithHttpInfo(int? id = default(int?), AbuseStateSet? state = default(AbuseStateSet?), string? sort = default(string?), int? start = default(int?), int? count = default(int?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAbusesApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1AbusesAbuseIdDeleteAsync(int abuseId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1AbusesAbuseIdDeleteWithHttpInfoAsync(int abuseId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete an abuse message
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="abuseMessageId">Abuse message id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1AbusesAbuseIdMessagesAbuseMessageIdDeleteAsync(int abuseId, int abuseMessageId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete an abuse message
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="abuseMessageId">Abuse message id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1AbusesAbuseIdMessagesAbuseMessageIdDeleteWithHttpInfoAsync(int abuseId, int abuseMessageId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List messages of an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1AbusesAbuseIdMessagesGet200Response</returns>
        System.Threading.Tasks.Task<ApiV1AbusesAbuseIdMessagesGet200Response> ApiV1AbusesAbuseIdMessagesGetAsync(int abuseId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List messages of an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1AbusesAbuseIdMessagesGet200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1AbusesAbuseIdMessagesGet200Response>> ApiV1AbusesAbuseIdMessagesGetWithHttpInfoAsync(int abuseId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add message to an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdMessagesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1AbusesAbuseIdMessagesPostAsync(int abuseId, ApiV1AbusesAbuseIdMessagesPostRequest apiV1AbusesAbuseIdMessagesPostRequest, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add message to an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdMessagesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1AbusesAbuseIdMessagesPostWithHttpInfoAsync(int abuseId, ApiV1AbusesAbuseIdMessagesPostRequest apiV1AbusesAbuseIdMessagesPostRequest, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdPutRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1AbusesAbuseIdPutAsync(int abuseId, ApiV1AbusesAbuseIdPutRequest? apiV1AbusesAbuseIdPutRequest = default(ApiV1AbusesAbuseIdPutRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdPutRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1AbusesAbuseIdPutWithHttpInfoAsync(int abuseId, ApiV1AbusesAbuseIdPutRequest? apiV1AbusesAbuseIdPutRequest = default(ApiV1AbusesAbuseIdPutRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Report an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1AbusesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1AbusesPost200Response</returns>
        System.Threading.Tasks.Task<ApiV1AbusesPost200Response> ApiV1AbusesPostAsync(ApiV1AbusesPostRequest apiV1AbusesPostRequest, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Report an abuse
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1AbusesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1AbusesPost200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1AbusesPost200Response>> ApiV1AbusesPostWithHttpInfoAsync(ApiV1AbusesPostRequest apiV1AbusesPostRequest, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List abuses
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="predefinedReason">predefined reason the listed reports should contain (optional)</param>
        /// <param name="search">plain search that will match with video titles, reporter names and more (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="searchReporter">only list reports of a specific reporter (optional)</param>
        /// <param name="searchReportee">only list reports of a specific reportee (optional)</param>
        /// <param name="searchVideo">only list reports of a specific video (optional)</param>
        /// <param name="searchVideoChannel">only list reports of a specific video channel (optional)</param>
        /// <param name="videoIs">only list deleted or blocklisted videos (optional)</param>
        /// <param name="filter">only list account, comment or video reports (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetMyAbuses200Response</returns>
        System.Threading.Tasks.Task<GetMyAbuses200Response> GetAbusesAsync(int? id = default(int?), List<string>? predefinedReason = default(List<string>?), string? search = default(string?), AbuseStateSet? state = default(AbuseStateSet?), string? searchReporter = default(string?), string? searchReportee = default(string?), string? searchVideo = default(string?), string? searchVideoChannel = default(string?), string? videoIs = default(string?), string? filter = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List abuses
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="predefinedReason">predefined reason the listed reports should contain (optional)</param>
        /// <param name="search">plain search that will match with video titles, reporter names and more (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="searchReporter">only list reports of a specific reporter (optional)</param>
        /// <param name="searchReportee">only list reports of a specific reportee (optional)</param>
        /// <param name="searchVideo">only list reports of a specific video (optional)</param>
        /// <param name="searchVideoChannel">only list reports of a specific video channel (optional)</param>
        /// <param name="videoIs">only list deleted or blocklisted videos (optional)</param>
        /// <param name="filter">only list account, comment or video reports (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetMyAbuses200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetMyAbuses200Response>> GetAbusesWithHttpInfoAsync(int? id = default(int?), List<string>? predefinedReason = default(List<string>?), string? search = default(string?), AbuseStateSet? state = default(AbuseStateSet?), string? searchReporter = default(string?), string? searchReportee = default(string?), string? searchVideo = default(string?), string? searchVideoChannel = default(string?), string? videoIs = default(string?), string? filter = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List my abuses
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetMyAbuses200Response</returns>
        System.Threading.Tasks.Task<GetMyAbuses200Response> GetMyAbusesAsync(int? id = default(int?), AbuseStateSet? state = default(AbuseStateSet?), string? sort = default(string?), int? start = default(int?), int? count = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List my abuses
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetMyAbuses200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetMyAbuses200Response>> GetMyAbusesWithHttpInfoAsync(int? id = default(int?), AbuseStateSet? state = default(AbuseStateSet?), string? sort = default(string?), int? start = default(int?), int? count = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAbusesApi : IAbusesApiSync, IAbusesApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class AbusesApi : IAbusesApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbusesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AbusesApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbusesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AbusesApi(string basePath)
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
        /// Initializes a new instance of the <see cref="AbusesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public AbusesApi(PeerTubeApiClient.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="AbusesApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public AbusesApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
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
        /// Delete an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1AbusesAbuseIdDelete(int abuseId, int operationIndex = 0)
        {
            ApiV1AbusesAbuseIdDeleteWithHttpInfo(abuseId);
        }

        /// <summary>
        /// Delete an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1AbusesAbuseIdDeleteWithHttpInfo(int abuseId, int operationIndex = 0)
        {
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

            localVarRequestOptions.PathParameters.Add("abuseId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(abuseId)); // path parameter

            localVarRequestOptions.Operation = "AbusesApi.ApiV1AbusesAbuseIdDelete";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/abuses/{abuseId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AbusesAbuseIdDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1AbusesAbuseIdDeleteAsync(int abuseId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1AbusesAbuseIdDeleteWithHttpInfoAsync(abuseId, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1AbusesAbuseIdDeleteWithHttpInfoAsync(int abuseId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

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

            localVarRequestOptions.PathParameters.Add("abuseId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(abuseId)); // path parameter

            localVarRequestOptions.Operation = "AbusesApi.ApiV1AbusesAbuseIdDelete";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/abuses/{abuseId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AbusesAbuseIdDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete an abuse message 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="abuseMessageId">Abuse message id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1AbusesAbuseIdMessagesAbuseMessageIdDelete(int abuseId, int abuseMessageId, int operationIndex = 0)
        {
            ApiV1AbusesAbuseIdMessagesAbuseMessageIdDeleteWithHttpInfo(abuseId, abuseMessageId);
        }

        /// <summary>
        /// Delete an abuse message 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="abuseMessageId">Abuse message id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1AbusesAbuseIdMessagesAbuseMessageIdDeleteWithHttpInfo(int abuseId, int abuseMessageId, int operationIndex = 0)
        {
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

            localVarRequestOptions.PathParameters.Add("abuseId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(abuseId)); // path parameter
            localVarRequestOptions.PathParameters.Add("abuseMessageId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(abuseMessageId)); // path parameter

            localVarRequestOptions.Operation = "AbusesApi.ApiV1AbusesAbuseIdMessagesAbuseMessageIdDelete";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/abuses/{abuseId}/messages/{abuseMessageId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AbusesAbuseIdMessagesAbuseMessageIdDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete an abuse message 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="abuseMessageId">Abuse message id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1AbusesAbuseIdMessagesAbuseMessageIdDeleteAsync(int abuseId, int abuseMessageId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1AbusesAbuseIdMessagesAbuseMessageIdDeleteWithHttpInfoAsync(abuseId, abuseMessageId, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete an abuse message 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="abuseMessageId">Abuse message id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1AbusesAbuseIdMessagesAbuseMessageIdDeleteWithHttpInfoAsync(int abuseId, int abuseMessageId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

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

            localVarRequestOptions.PathParameters.Add("abuseId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(abuseId)); // path parameter
            localVarRequestOptions.PathParameters.Add("abuseMessageId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(abuseMessageId)); // path parameter

            localVarRequestOptions.Operation = "AbusesApi.ApiV1AbusesAbuseIdMessagesAbuseMessageIdDelete";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/abuses/{abuseId}/messages/{abuseMessageId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AbusesAbuseIdMessagesAbuseMessageIdDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List messages of an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1AbusesAbuseIdMessagesGet200Response</returns>
        public ApiV1AbusesAbuseIdMessagesGet200Response ApiV1AbusesAbuseIdMessagesGet(int abuseId, int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1AbusesAbuseIdMessagesGet200Response> localVarResponse = ApiV1AbusesAbuseIdMessagesGetWithHttpInfo(abuseId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List messages of an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1AbusesAbuseIdMessagesGet200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1AbusesAbuseIdMessagesGet200Response> ApiV1AbusesAbuseIdMessagesGetWithHttpInfo(int abuseId, int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("abuseId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(abuseId)); // path parameter

            localVarRequestOptions.Operation = "AbusesApi.ApiV1AbusesAbuseIdMessagesGet";
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
            var localVarResponse = this.Client.Get<ApiV1AbusesAbuseIdMessagesGet200Response>("/api/v1/abuses/{abuseId}/messages", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AbusesAbuseIdMessagesGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List messages of an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1AbusesAbuseIdMessagesGet200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1AbusesAbuseIdMessagesGet200Response> ApiV1AbusesAbuseIdMessagesGetAsync(int abuseId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1AbusesAbuseIdMessagesGet200Response> localVarResponse = await ApiV1AbusesAbuseIdMessagesGetWithHttpInfoAsync(abuseId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List messages of an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1AbusesAbuseIdMessagesGet200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1AbusesAbuseIdMessagesGet200Response>> ApiV1AbusesAbuseIdMessagesGetWithHttpInfoAsync(int abuseId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("abuseId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(abuseId)); // path parameter

            localVarRequestOptions.Operation = "AbusesApi.ApiV1AbusesAbuseIdMessagesGet";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApiV1AbusesAbuseIdMessagesGet200Response>("/api/v1/abuses/{abuseId}/messages", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AbusesAbuseIdMessagesGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add message to an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdMessagesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1AbusesAbuseIdMessagesPost(int abuseId, ApiV1AbusesAbuseIdMessagesPostRequest apiV1AbusesAbuseIdMessagesPostRequest, int operationIndex = 0)
        {
            ApiV1AbusesAbuseIdMessagesPostWithHttpInfo(abuseId, apiV1AbusesAbuseIdMessagesPostRequest);
        }

        /// <summary>
        /// Add message to an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdMessagesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1AbusesAbuseIdMessagesPostWithHttpInfo(int abuseId, ApiV1AbusesAbuseIdMessagesPostRequest apiV1AbusesAbuseIdMessagesPostRequest, int operationIndex = 0)
        {
            // verify the required parameter 'apiV1AbusesAbuseIdMessagesPostRequest' is set
            if (apiV1AbusesAbuseIdMessagesPostRequest == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'apiV1AbusesAbuseIdMessagesPostRequest' when calling AbusesApi->ApiV1AbusesAbuseIdMessagesPost");
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

            localVarRequestOptions.PathParameters.Add("abuseId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(abuseId)); // path parameter
            localVarRequestOptions.Data = apiV1AbusesAbuseIdMessagesPostRequest;

            localVarRequestOptions.Operation = "AbusesApi.ApiV1AbusesAbuseIdMessagesPost";
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
            var localVarResponse = this.Client.Post<Object>("/api/v1/abuses/{abuseId}/messages", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AbusesAbuseIdMessagesPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add message to an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdMessagesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1AbusesAbuseIdMessagesPostAsync(int abuseId, ApiV1AbusesAbuseIdMessagesPostRequest apiV1AbusesAbuseIdMessagesPostRequest, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1AbusesAbuseIdMessagesPostWithHttpInfoAsync(abuseId, apiV1AbusesAbuseIdMessagesPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Add message to an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdMessagesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1AbusesAbuseIdMessagesPostWithHttpInfoAsync(int abuseId, ApiV1AbusesAbuseIdMessagesPostRequest apiV1AbusesAbuseIdMessagesPostRequest, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'apiV1AbusesAbuseIdMessagesPostRequest' is set
            if (apiV1AbusesAbuseIdMessagesPostRequest == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'apiV1AbusesAbuseIdMessagesPostRequest' when calling AbusesApi->ApiV1AbusesAbuseIdMessagesPost");
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

            localVarRequestOptions.PathParameters.Add("abuseId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(abuseId)); // path parameter
            localVarRequestOptions.Data = apiV1AbusesAbuseIdMessagesPostRequest;

            localVarRequestOptions.Operation = "AbusesApi.ApiV1AbusesAbuseIdMessagesPost";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/abuses/{abuseId}/messages", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AbusesAbuseIdMessagesPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdPutRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1AbusesAbuseIdPut(int abuseId, ApiV1AbusesAbuseIdPutRequest? apiV1AbusesAbuseIdPutRequest = default(ApiV1AbusesAbuseIdPutRequest?), int operationIndex = 0)
        {
            ApiV1AbusesAbuseIdPutWithHttpInfo(abuseId, apiV1AbusesAbuseIdPutRequest);
        }

        /// <summary>
        /// Update an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdPutRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1AbusesAbuseIdPutWithHttpInfo(int abuseId, ApiV1AbusesAbuseIdPutRequest? apiV1AbusesAbuseIdPutRequest = default(ApiV1AbusesAbuseIdPutRequest?), int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("abuseId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(abuseId)); // path parameter
            localVarRequestOptions.Data = apiV1AbusesAbuseIdPutRequest;

            localVarRequestOptions.Operation = "AbusesApi.ApiV1AbusesAbuseIdPut";
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
            var localVarResponse = this.Client.Put<Object>("/api/v1/abuses/{abuseId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AbusesAbuseIdPut", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdPutRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1AbusesAbuseIdPutAsync(int abuseId, ApiV1AbusesAbuseIdPutRequest? apiV1AbusesAbuseIdPutRequest = default(ApiV1AbusesAbuseIdPutRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1AbusesAbuseIdPutWithHttpInfoAsync(abuseId, apiV1AbusesAbuseIdPutRequest, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="abuseId">Abuse id</param>
        /// <param name="apiV1AbusesAbuseIdPutRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1AbusesAbuseIdPutWithHttpInfoAsync(int abuseId, ApiV1AbusesAbuseIdPutRequest? apiV1AbusesAbuseIdPutRequest = default(ApiV1AbusesAbuseIdPutRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("abuseId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(abuseId)); // path parameter
            localVarRequestOptions.Data = apiV1AbusesAbuseIdPutRequest;

            localVarRequestOptions.Operation = "AbusesApi.ApiV1AbusesAbuseIdPut";
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
            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/api/v1/abuses/{abuseId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AbusesAbuseIdPut", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Report an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1AbusesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1AbusesPost200Response</returns>
        public ApiV1AbusesPost200Response ApiV1AbusesPost(ApiV1AbusesPostRequest apiV1AbusesPostRequest, int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1AbusesPost200Response> localVarResponse = ApiV1AbusesPostWithHttpInfo(apiV1AbusesPostRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Report an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1AbusesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1AbusesPost200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1AbusesPost200Response> ApiV1AbusesPostWithHttpInfo(ApiV1AbusesPostRequest apiV1AbusesPostRequest, int operationIndex = 0)
        {
            // verify the required parameter 'apiV1AbusesPostRequest' is set
            if (apiV1AbusesPostRequest == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'apiV1AbusesPostRequest' when calling AbusesApi->ApiV1AbusesPost");
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

            localVarRequestOptions.Data = apiV1AbusesPostRequest;

            localVarRequestOptions.Operation = "AbusesApi.ApiV1AbusesPost";
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
            var localVarResponse = this.Client.Post<ApiV1AbusesPost200Response>("/api/v1/abuses", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AbusesPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Report an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1AbusesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1AbusesPost200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1AbusesPost200Response> ApiV1AbusesPostAsync(ApiV1AbusesPostRequest apiV1AbusesPostRequest, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1AbusesPost200Response> localVarResponse = await ApiV1AbusesPostWithHttpInfoAsync(apiV1AbusesPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Report an abuse 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1AbusesPostRequest"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1AbusesPost200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1AbusesPost200Response>> ApiV1AbusesPostWithHttpInfoAsync(ApiV1AbusesPostRequest apiV1AbusesPostRequest, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'apiV1AbusesPostRequest' is set
            if (apiV1AbusesPostRequest == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'apiV1AbusesPostRequest' when calling AbusesApi->ApiV1AbusesPost");
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

            localVarRequestOptions.Data = apiV1AbusesPostRequest;

            localVarRequestOptions.Operation = "AbusesApi.ApiV1AbusesPost";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<ApiV1AbusesPost200Response>("/api/v1/abuses", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AbusesPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List abuses 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="predefinedReason">predefined reason the listed reports should contain (optional)</param>
        /// <param name="search">plain search that will match with video titles, reporter names and more (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="searchReporter">only list reports of a specific reporter (optional)</param>
        /// <param name="searchReportee">only list reports of a specific reportee (optional)</param>
        /// <param name="searchVideo">only list reports of a specific video (optional)</param>
        /// <param name="searchVideoChannel">only list reports of a specific video channel (optional)</param>
        /// <param name="videoIs">only list deleted or blocklisted videos (optional)</param>
        /// <param name="filter">only list account, comment or video reports (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetMyAbuses200Response</returns>
        public GetMyAbuses200Response GetAbuses(int? id = default(int?), List<string>? predefinedReason = default(List<string>?), string? search = default(string?), AbuseStateSet? state = default(AbuseStateSet?), string? searchReporter = default(string?), string? searchReportee = default(string?), string? searchVideo = default(string?), string? searchVideoChannel = default(string?), string? videoIs = default(string?), string? filter = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<GetMyAbuses200Response> localVarResponse = GetAbusesWithHttpInfo(id, predefinedReason, search, state, searchReporter, searchReportee, searchVideo, searchVideoChannel, videoIs, filter, start, count, sort);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List abuses 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="predefinedReason">predefined reason the listed reports should contain (optional)</param>
        /// <param name="search">plain search that will match with video titles, reporter names and more (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="searchReporter">only list reports of a specific reporter (optional)</param>
        /// <param name="searchReportee">only list reports of a specific reportee (optional)</param>
        /// <param name="searchVideo">only list reports of a specific video (optional)</param>
        /// <param name="searchVideoChannel">only list reports of a specific video channel (optional)</param>
        /// <param name="videoIs">only list deleted or blocklisted videos (optional)</param>
        /// <param name="filter">only list account, comment or video reports (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetMyAbuses200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<GetMyAbuses200Response> GetAbusesWithHttpInfo(int? id = default(int?), List<string>? predefinedReason = default(List<string>?), string? search = default(string?), AbuseStateSet? state = default(AbuseStateSet?), string? searchReporter = default(string?), string? searchReportee = default(string?), string? searchVideo = default(string?), string? searchVideoChannel = default(string?), string? videoIs = default(string?), string? filter = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0)
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

            if (id != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "id", id));
            }
            if (predefinedReason != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("multi", "predefinedReason", predefinedReason));
            }
            if (search != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "search", search));
            }
            if (state != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "state", state));
            }
            if (searchReporter != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchReporter", searchReporter));
            }
            if (searchReportee != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchReportee", searchReportee));
            }
            if (searchVideo != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchVideo", searchVideo));
            }
            if (searchVideoChannel != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchVideoChannel", searchVideoChannel));
            }
            if (videoIs != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoIs", videoIs));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
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

            localVarRequestOptions.Operation = "AbusesApi.GetAbuses";
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
            var localVarResponse = this.Client.Get<GetMyAbuses200Response>("/api/v1/abuses", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAbuses", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List abuses 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="predefinedReason">predefined reason the listed reports should contain (optional)</param>
        /// <param name="search">plain search that will match with video titles, reporter names and more (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="searchReporter">only list reports of a specific reporter (optional)</param>
        /// <param name="searchReportee">only list reports of a specific reportee (optional)</param>
        /// <param name="searchVideo">only list reports of a specific video (optional)</param>
        /// <param name="searchVideoChannel">only list reports of a specific video channel (optional)</param>
        /// <param name="videoIs">only list deleted or blocklisted videos (optional)</param>
        /// <param name="filter">only list account, comment or video reports (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetMyAbuses200Response</returns>
        public async System.Threading.Tasks.Task<GetMyAbuses200Response> GetAbusesAsync(int? id = default(int?), List<string>? predefinedReason = default(List<string>?), string? search = default(string?), AbuseStateSet? state = default(AbuseStateSet?), string? searchReporter = default(string?), string? searchReportee = default(string?), string? searchVideo = default(string?), string? searchVideoChannel = default(string?), string? videoIs = default(string?), string? filter = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<GetMyAbuses200Response> localVarResponse = await GetAbusesWithHttpInfoAsync(id, predefinedReason, search, state, searchReporter, searchReportee, searchVideo, searchVideoChannel, videoIs, filter, start, count, sort, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List abuses 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="predefinedReason">predefined reason the listed reports should contain (optional)</param>
        /// <param name="search">plain search that will match with video titles, reporter names and more (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="searchReporter">only list reports of a specific reporter (optional)</param>
        /// <param name="searchReportee">only list reports of a specific reportee (optional)</param>
        /// <param name="searchVideo">only list reports of a specific video (optional)</param>
        /// <param name="searchVideoChannel">only list reports of a specific video channel (optional)</param>
        /// <param name="videoIs">only list deleted or blocklisted videos (optional)</param>
        /// <param name="filter">only list account, comment or video reports (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetMyAbuses200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<GetMyAbuses200Response>> GetAbusesWithHttpInfoAsync(int? id = default(int?), List<string>? predefinedReason = default(List<string>?), string? search = default(string?), AbuseStateSet? state = default(AbuseStateSet?), string? searchReporter = default(string?), string? searchReportee = default(string?), string? searchVideo = default(string?), string? searchVideoChannel = default(string?), string? videoIs = default(string?), string? filter = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (id != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "id", id));
            }
            if (predefinedReason != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("multi", "predefinedReason", predefinedReason));
            }
            if (search != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "search", search));
            }
            if (state != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "state", state));
            }
            if (searchReporter != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchReporter", searchReporter));
            }
            if (searchReportee != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchReportee", searchReportee));
            }
            if (searchVideo != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchVideo", searchVideo));
            }
            if (searchVideoChannel != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchVideoChannel", searchVideoChannel));
            }
            if (videoIs != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoIs", videoIs));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
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

            localVarRequestOptions.Operation = "AbusesApi.GetAbuses";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetMyAbuses200Response>("/api/v1/abuses", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAbuses", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List my abuses 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetMyAbuses200Response</returns>
        public GetMyAbuses200Response GetMyAbuses(int? id = default(int?), AbuseStateSet? state = default(AbuseStateSet?), string? sort = default(string?), int? start = default(int?), int? count = default(int?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<GetMyAbuses200Response> localVarResponse = GetMyAbusesWithHttpInfo(id, state, sort, start, count);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List my abuses 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetMyAbuses200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<GetMyAbuses200Response> GetMyAbusesWithHttpInfo(int? id = default(int?), AbuseStateSet? state = default(AbuseStateSet?), string? sort = default(string?), int? start = default(int?), int? count = default(int?), int operationIndex = 0)
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

            if (id != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "id", id));
            }
            if (state != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "state", state));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (count != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "count", count));
            }

            localVarRequestOptions.Operation = "AbusesApi.GetMyAbuses";
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
            var localVarResponse = this.Client.Get<GetMyAbuses200Response>("/api/v1/users/me/abuses", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetMyAbuses", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List my abuses 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetMyAbuses200Response</returns>
        public async System.Threading.Tasks.Task<GetMyAbuses200Response> GetMyAbusesAsync(int? id = default(int?), AbuseStateSet? state = default(AbuseStateSet?), string? sort = default(string?), int? start = default(int?), int? count = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<GetMyAbuses200Response> localVarResponse = await GetMyAbusesWithHttpInfoAsync(id, state, sort, start, count, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List my abuses 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">only list the report with this id (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="sort">Sort abuses by criteria (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetMyAbuses200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<GetMyAbuses200Response>> GetMyAbusesWithHttpInfoAsync(int? id = default(int?), AbuseStateSet? state = default(AbuseStateSet?), string? sort = default(string?), int? start = default(int?), int? count = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (id != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "id", id));
            }
            if (state != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "state", state));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (count != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "count", count));
            }

            localVarRequestOptions.Operation = "AbusesApi.GetMyAbuses";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetMyAbuses200Response>("/api/v1/users/me/abuses", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetMyAbuses", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
