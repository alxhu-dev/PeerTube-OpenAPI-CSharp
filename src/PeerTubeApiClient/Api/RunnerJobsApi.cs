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
    public interface IRunnerJobsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// List jobs
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort runner jobs by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="stateOneOf"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1RunnersJobsGet200Response</returns>
        ApiV1RunnersJobsGet200Response ApiV1RunnersJobsGet(int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), List<RunnerJobState>? stateOneOf = default(List<RunnerJobState>?), int operationIndex = 0);

        /// <summary>
        /// List jobs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort runner jobs by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="stateOneOf"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1RunnersJobsGet200Response</returns>
        ApiResponse<ApiV1RunnersJobsGet200Response> ApiV1RunnersJobsGetWithHttpInfo(int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), List<RunnerJobState>? stateOneOf = default(List<RunnerJobState>?), int operationIndex = 0);
        /// <summary>
        /// Abort job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDAbortPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1RunnersJobsJobUUIDAbortPost(Guid jobUUID, ApiV1RunnersJobsJobUUIDAbortPostRequest? apiV1RunnersJobsJobUUIDAbortPostRequest = default(ApiV1RunnersJobsJobUUIDAbortPostRequest?), int operationIndex = 0);

        /// <summary>
        /// Abort job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDAbortPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1RunnersJobsJobUUIDAbortPostWithHttpInfo(Guid jobUUID, ApiV1RunnersJobsJobUUIDAbortPostRequest? apiV1RunnersJobsJobUUIDAbortPostRequest = default(ApiV1RunnersJobsJobUUIDAbortPostRequest?), int operationIndex = 0);
        /// <summary>
        /// Accept job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1RunnersJobsJobUUIDAcceptPost200Response</returns>
        ApiV1RunnersJobsJobUUIDAcceptPost200Response ApiV1RunnersJobsJobUUIDAcceptPost(Guid jobUUID, ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0);

        /// <summary>
        /// Accept job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1RunnersJobsJobUUIDAcceptPost200Response</returns>
        ApiResponse<ApiV1RunnersJobsJobUUIDAcceptPost200Response> ApiV1RunnersJobsJobUUIDAcceptPostWithHttpInfo(Guid jobUUID, ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0);
        /// <summary>
        /// Cancel a job
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1RunnersJobsJobUUIDCancelGet(Guid jobUUID, int operationIndex = 0);

        /// <summary>
        /// Cancel a job
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1RunnersJobsJobUUIDCancelGetWithHttpInfo(Guid jobUUID, int operationIndex = 0);
        /// <summary>
        /// Delete a job
        /// </summary>
        /// <remarks>
        /// The endpoint will first cancel the job if needed, and then remove it from the database. Children jobs will also be removed
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1RunnersJobsJobUUIDDelete(Guid jobUUID, int operationIndex = 0);

        /// <summary>
        /// Delete a job
        /// </summary>
        /// <remarks>
        /// The endpoint will first cancel the job if needed, and then remove it from the database. Children jobs will also be removed
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1RunnersJobsJobUUIDDeleteWithHttpInfo(Guid jobUUID, int operationIndex = 0);
        /// <summary>
        /// Post job error
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDErrorPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1RunnersJobsJobUUIDErrorPost(Guid jobUUID, ApiV1RunnersJobsJobUUIDErrorPostRequest? apiV1RunnersJobsJobUUIDErrorPostRequest = default(ApiV1RunnersJobsJobUUIDErrorPostRequest?), int operationIndex = 0);

        /// <summary>
        /// Post job error
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDErrorPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1RunnersJobsJobUUIDErrorPostWithHttpInfo(Guid jobUUID, ApiV1RunnersJobsJobUUIDErrorPostRequest? apiV1RunnersJobsJobUUIDErrorPostRequest = default(ApiV1RunnersJobsJobUUIDErrorPostRequest?), int operationIndex = 0);
        /// <summary>
        /// Post job success
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDSuccessPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1RunnersJobsJobUUIDSuccessPost(Guid jobUUID, ApiV1RunnersJobsJobUUIDSuccessPostRequest? apiV1RunnersJobsJobUUIDSuccessPostRequest = default(ApiV1RunnersJobsJobUUIDSuccessPostRequest?), int operationIndex = 0);

        /// <summary>
        /// Post job success
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDSuccessPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1RunnersJobsJobUUIDSuccessPostWithHttpInfo(Guid jobUUID, ApiV1RunnersJobsJobUUIDSuccessPostRequest? apiV1RunnersJobsJobUUIDSuccessPostRequest = default(ApiV1RunnersJobsJobUUIDSuccessPostRequest?), int operationIndex = 0);
        /// <summary>
        /// Update job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDUpdatePostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1RunnersJobsJobUUIDUpdatePost(Guid jobUUID, ApiV1RunnersJobsJobUUIDUpdatePostRequest? apiV1RunnersJobsJobUUIDUpdatePostRequest = default(ApiV1RunnersJobsJobUUIDUpdatePostRequest?), int operationIndex = 0);

        /// <summary>
        /// Update job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDUpdatePostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1RunnersJobsJobUUIDUpdatePostWithHttpInfo(Guid jobUUID, ApiV1RunnersJobsJobUUIDUpdatePostRequest? apiV1RunnersJobsJobUUIDUpdatePostRequest = default(ApiV1RunnersJobsJobUUIDUpdatePostRequest?), int operationIndex = 0);
        /// <summary>
        /// Request a new job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1RunnersJobsRequestPost200Response</returns>
        ApiV1RunnersJobsRequestPost200Response ApiV1RunnersJobsRequestPost(ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0);

        /// <summary>
        /// Request a new job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1RunnersJobsRequestPost200Response</returns>
        ApiResponse<ApiV1RunnersJobsRequestPost200Response> ApiV1RunnersJobsRequestPostWithHttpInfo(ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IRunnerJobsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// List jobs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort runner jobs by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="stateOneOf"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1RunnersJobsGet200Response</returns>
        System.Threading.Tasks.Task<ApiV1RunnersJobsGet200Response> ApiV1RunnersJobsGetAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), List<RunnerJobState>? stateOneOf = default(List<RunnerJobState>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List jobs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort runner jobs by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="stateOneOf"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1RunnersJobsGet200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1RunnersJobsGet200Response>> ApiV1RunnersJobsGetWithHttpInfoAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), List<RunnerJobState>? stateOneOf = default(List<RunnerJobState>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Abort job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDAbortPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1RunnersJobsJobUUIDAbortPostAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDAbortPostRequest? apiV1RunnersJobsJobUUIDAbortPostRequest = default(ApiV1RunnersJobsJobUUIDAbortPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Abort job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDAbortPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1RunnersJobsJobUUIDAbortPostWithHttpInfoAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDAbortPostRequest? apiV1RunnersJobsJobUUIDAbortPostRequest = default(ApiV1RunnersJobsJobUUIDAbortPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Accept job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1RunnersJobsJobUUIDAcceptPost200Response</returns>
        System.Threading.Tasks.Task<ApiV1RunnersJobsJobUUIDAcceptPost200Response> ApiV1RunnersJobsJobUUIDAcceptPostAsync(Guid jobUUID, ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Accept job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1RunnersJobsJobUUIDAcceptPost200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1RunnersJobsJobUUIDAcceptPost200Response>> ApiV1RunnersJobsJobUUIDAcceptPostWithHttpInfoAsync(Guid jobUUID, ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Cancel a job
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1RunnersJobsJobUUIDCancelGetAsync(Guid jobUUID, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Cancel a job
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1RunnersJobsJobUUIDCancelGetWithHttpInfoAsync(Guid jobUUID, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete a job
        /// </summary>
        /// <remarks>
        /// The endpoint will first cancel the job if needed, and then remove it from the database. Children jobs will also be removed
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1RunnersJobsJobUUIDDeleteAsync(Guid jobUUID, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete a job
        /// </summary>
        /// <remarks>
        /// The endpoint will first cancel the job if needed, and then remove it from the database. Children jobs will also be removed
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1RunnersJobsJobUUIDDeleteWithHttpInfoAsync(Guid jobUUID, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Post job error
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDErrorPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1RunnersJobsJobUUIDErrorPostAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDErrorPostRequest? apiV1RunnersJobsJobUUIDErrorPostRequest = default(ApiV1RunnersJobsJobUUIDErrorPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Post job error
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDErrorPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1RunnersJobsJobUUIDErrorPostWithHttpInfoAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDErrorPostRequest? apiV1RunnersJobsJobUUIDErrorPostRequest = default(ApiV1RunnersJobsJobUUIDErrorPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Post job success
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDSuccessPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1RunnersJobsJobUUIDSuccessPostAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDSuccessPostRequest? apiV1RunnersJobsJobUUIDSuccessPostRequest = default(ApiV1RunnersJobsJobUUIDSuccessPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Post job success
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDSuccessPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1RunnersJobsJobUUIDSuccessPostWithHttpInfoAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDSuccessPostRequest? apiV1RunnersJobsJobUUIDSuccessPostRequest = default(ApiV1RunnersJobsJobUUIDSuccessPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDUpdatePostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1RunnersJobsJobUUIDUpdatePostAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDUpdatePostRequest? apiV1RunnersJobsJobUUIDUpdatePostRequest = default(ApiV1RunnersJobsJobUUIDUpdatePostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDUpdatePostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1RunnersJobsJobUUIDUpdatePostWithHttpInfoAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDUpdatePostRequest? apiV1RunnersJobsJobUUIDUpdatePostRequest = default(ApiV1RunnersJobsJobUUIDUpdatePostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Request a new job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1RunnersJobsRequestPost200Response</returns>
        System.Threading.Tasks.Task<ApiV1RunnersJobsRequestPost200Response> ApiV1RunnersJobsRequestPostAsync(ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Request a new job
        /// </summary>
        /// <remarks>
        /// API used by PeerTube runners
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1RunnersJobsRequestPost200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1RunnersJobsRequestPost200Response>> ApiV1RunnersJobsRequestPostWithHttpInfoAsync(ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IRunnerJobsApi : IRunnerJobsApiSync, IRunnerJobsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class RunnerJobsApi : IRunnerJobsApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RunnerJobsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RunnerJobsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RunnerJobsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RunnerJobsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="RunnerJobsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public RunnerJobsApi(PeerTubeApiClient.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="RunnerJobsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public RunnerJobsApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
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
        /// List jobs 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort runner jobs by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="stateOneOf"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1RunnersJobsGet200Response</returns>
        public ApiV1RunnersJobsGet200Response ApiV1RunnersJobsGet(int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), List<RunnerJobState>? stateOneOf = default(List<RunnerJobState>?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1RunnersJobsGet200Response> localVarResponse = ApiV1RunnersJobsGetWithHttpInfo(start, count, sort, search, stateOneOf);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List jobs 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort runner jobs by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="stateOneOf"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1RunnersJobsGet200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1RunnersJobsGet200Response> ApiV1RunnersJobsGetWithHttpInfo(int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), List<RunnerJobState>? stateOneOf = default(List<RunnerJobState>?), int operationIndex = 0)
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
            if (search != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "search", search));
            }
            if (stateOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("multi", "stateOneOf", stateOneOf));
            }

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsGet";
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
            var localVarResponse = this.Client.Get<ApiV1RunnersJobsGet200Response>("/api/v1/runners/jobs", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List jobs 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort runner jobs by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="stateOneOf"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1RunnersJobsGet200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1RunnersJobsGet200Response> ApiV1RunnersJobsGetAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), List<RunnerJobState>? stateOneOf = default(List<RunnerJobState>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1RunnersJobsGet200Response> localVarResponse = await ApiV1RunnersJobsGetWithHttpInfoAsync(start, count, sort, search, stateOneOf, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List jobs 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort runner jobs by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="stateOneOf"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1RunnersJobsGet200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1RunnersJobsGet200Response>> ApiV1RunnersJobsGetWithHttpInfoAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), List<RunnerJobState>? stateOneOf = default(List<RunnerJobState>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            if (search != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "search", search));
            }
            if (stateOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("multi", "stateOneOf", stateOneOf));
            }

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsGet";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApiV1RunnersJobsGet200Response>("/api/v1/runners/jobs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Abort job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDAbortPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1RunnersJobsJobUUIDAbortPost(Guid jobUUID, ApiV1RunnersJobsJobUUIDAbortPostRequest? apiV1RunnersJobsJobUUIDAbortPostRequest = default(ApiV1RunnersJobsJobUUIDAbortPostRequest?), int operationIndex = 0)
        {
            ApiV1RunnersJobsJobUUIDAbortPostWithHttpInfo(jobUUID, apiV1RunnersJobsJobUUIDAbortPostRequest);
        }

        /// <summary>
        /// Abort job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDAbortPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1RunnersJobsJobUUIDAbortPostWithHttpInfo(Guid jobUUID, ApiV1RunnersJobsJobUUIDAbortPostRequest? apiV1RunnersJobsJobUUIDAbortPostRequest = default(ApiV1RunnersJobsJobUUIDAbortPostRequest?), int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("jobUUID", PeerTubeApiClient.Client.ClientUtils.ParameterToString(jobUUID)); // path parameter
            localVarRequestOptions.Data = apiV1RunnersJobsJobUUIDAbortPostRequest;

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsJobUUIDAbortPost";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/api/v1/runners/jobs/{jobUUID}/abort", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsJobUUIDAbortPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Abort job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDAbortPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1RunnersJobsJobUUIDAbortPostAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDAbortPostRequest? apiV1RunnersJobsJobUUIDAbortPostRequest = default(ApiV1RunnersJobsJobUUIDAbortPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1RunnersJobsJobUUIDAbortPostWithHttpInfoAsync(jobUUID, apiV1RunnersJobsJobUUIDAbortPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Abort job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDAbortPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1RunnersJobsJobUUIDAbortPostWithHttpInfoAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDAbortPostRequest? apiV1RunnersJobsJobUUIDAbortPostRequest = default(ApiV1RunnersJobsJobUUIDAbortPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("jobUUID", PeerTubeApiClient.Client.ClientUtils.ParameterToString(jobUUID)); // path parameter
            localVarRequestOptions.Data = apiV1RunnersJobsJobUUIDAbortPostRequest;

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsJobUUIDAbortPost";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/runners/jobs/{jobUUID}/abort", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsJobUUIDAbortPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Accept job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1RunnersJobsJobUUIDAcceptPost200Response</returns>
        public ApiV1RunnersJobsJobUUIDAcceptPost200Response ApiV1RunnersJobsJobUUIDAcceptPost(Guid jobUUID, ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1RunnersJobsJobUUIDAcceptPost200Response> localVarResponse = ApiV1RunnersJobsJobUUIDAcceptPostWithHttpInfo(jobUUID, apiV1RunnersUnregisterPostRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Accept job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1RunnersJobsJobUUIDAcceptPost200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1RunnersJobsJobUUIDAcceptPost200Response> ApiV1RunnersJobsJobUUIDAcceptPostWithHttpInfo(Guid jobUUID, ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("jobUUID", PeerTubeApiClient.Client.ClientUtils.ParameterToString(jobUUID)); // path parameter
            localVarRequestOptions.Data = apiV1RunnersUnregisterPostRequest;

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsJobUUIDAcceptPost";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<ApiV1RunnersJobsJobUUIDAcceptPost200Response>("/api/v1/runners/jobs/{jobUUID}/accept", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsJobUUIDAcceptPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Accept job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1RunnersJobsJobUUIDAcceptPost200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1RunnersJobsJobUUIDAcceptPost200Response> ApiV1RunnersJobsJobUUIDAcceptPostAsync(Guid jobUUID, ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1RunnersJobsJobUUIDAcceptPost200Response> localVarResponse = await ApiV1RunnersJobsJobUUIDAcceptPostWithHttpInfoAsync(jobUUID, apiV1RunnersUnregisterPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Accept job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1RunnersJobsJobUUIDAcceptPost200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1RunnersJobsJobUUIDAcceptPost200Response>> ApiV1RunnersJobsJobUUIDAcceptPostWithHttpInfoAsync(Guid jobUUID, ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("jobUUID", PeerTubeApiClient.Client.ClientUtils.ParameterToString(jobUUID)); // path parameter
            localVarRequestOptions.Data = apiV1RunnersUnregisterPostRequest;

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsJobUUIDAcceptPost";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<ApiV1RunnersJobsJobUUIDAcceptPost200Response>("/api/v1/runners/jobs/{jobUUID}/accept", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsJobUUIDAcceptPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel a job 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1RunnersJobsJobUUIDCancelGet(Guid jobUUID, int operationIndex = 0)
        {
            ApiV1RunnersJobsJobUUIDCancelGetWithHttpInfo(jobUUID);
        }

        /// <summary>
        /// Cancel a job 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1RunnersJobsJobUUIDCancelGetWithHttpInfo(Guid jobUUID, int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("jobUUID", PeerTubeApiClient.Client.ClientUtils.ParameterToString(jobUUID)); // path parameter

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsJobUUIDCancelGet";
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
            var localVarResponse = this.Client.Get<Object>("/api/v1/runners/jobs/{jobUUID}/cancel", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsJobUUIDCancelGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel a job 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1RunnersJobsJobUUIDCancelGetAsync(Guid jobUUID, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1RunnersJobsJobUUIDCancelGetWithHttpInfoAsync(jobUUID, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancel a job 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1RunnersJobsJobUUIDCancelGetWithHttpInfoAsync(Guid jobUUID, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("jobUUID", PeerTubeApiClient.Client.ClientUtils.ParameterToString(jobUUID)); // path parameter

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsJobUUIDCancelGet";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/api/v1/runners/jobs/{jobUUID}/cancel", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsJobUUIDCancelGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a job The endpoint will first cancel the job if needed, and then remove it from the database. Children jobs will also be removed
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1RunnersJobsJobUUIDDelete(Guid jobUUID, int operationIndex = 0)
        {
            ApiV1RunnersJobsJobUUIDDeleteWithHttpInfo(jobUUID);
        }

        /// <summary>
        /// Delete a job The endpoint will first cancel the job if needed, and then remove it from the database. Children jobs will also be removed
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1RunnersJobsJobUUIDDeleteWithHttpInfo(Guid jobUUID, int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("jobUUID", PeerTubeApiClient.Client.ClientUtils.ParameterToString(jobUUID)); // path parameter

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsJobUUIDDelete";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/runners/jobs/{jobUUID}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsJobUUIDDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a job The endpoint will first cancel the job if needed, and then remove it from the database. Children jobs will also be removed
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1RunnersJobsJobUUIDDeleteAsync(Guid jobUUID, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1RunnersJobsJobUUIDDeleteWithHttpInfoAsync(jobUUID, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a job The endpoint will first cancel the job if needed, and then remove it from the database. Children jobs will also be removed
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1RunnersJobsJobUUIDDeleteWithHttpInfoAsync(Guid jobUUID, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("jobUUID", PeerTubeApiClient.Client.ClientUtils.ParameterToString(jobUUID)); // path parameter

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsJobUUIDDelete";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/runners/jobs/{jobUUID}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsJobUUIDDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Post job error API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDErrorPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1RunnersJobsJobUUIDErrorPost(Guid jobUUID, ApiV1RunnersJobsJobUUIDErrorPostRequest? apiV1RunnersJobsJobUUIDErrorPostRequest = default(ApiV1RunnersJobsJobUUIDErrorPostRequest?), int operationIndex = 0)
        {
            ApiV1RunnersJobsJobUUIDErrorPostWithHttpInfo(jobUUID, apiV1RunnersJobsJobUUIDErrorPostRequest);
        }

        /// <summary>
        /// Post job error API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDErrorPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1RunnersJobsJobUUIDErrorPostWithHttpInfo(Guid jobUUID, ApiV1RunnersJobsJobUUIDErrorPostRequest? apiV1RunnersJobsJobUUIDErrorPostRequest = default(ApiV1RunnersJobsJobUUIDErrorPostRequest?), int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("jobUUID", PeerTubeApiClient.Client.ClientUtils.ParameterToString(jobUUID)); // path parameter
            localVarRequestOptions.Data = apiV1RunnersJobsJobUUIDErrorPostRequest;

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsJobUUIDErrorPost";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/api/v1/runners/jobs/{jobUUID}/error", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsJobUUIDErrorPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Post job error API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDErrorPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1RunnersJobsJobUUIDErrorPostAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDErrorPostRequest? apiV1RunnersJobsJobUUIDErrorPostRequest = default(ApiV1RunnersJobsJobUUIDErrorPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1RunnersJobsJobUUIDErrorPostWithHttpInfoAsync(jobUUID, apiV1RunnersJobsJobUUIDErrorPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Post job error API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDErrorPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1RunnersJobsJobUUIDErrorPostWithHttpInfoAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDErrorPostRequest? apiV1RunnersJobsJobUUIDErrorPostRequest = default(ApiV1RunnersJobsJobUUIDErrorPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("jobUUID", PeerTubeApiClient.Client.ClientUtils.ParameterToString(jobUUID)); // path parameter
            localVarRequestOptions.Data = apiV1RunnersJobsJobUUIDErrorPostRequest;

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsJobUUIDErrorPost";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/runners/jobs/{jobUUID}/error", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsJobUUIDErrorPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Post job success API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDSuccessPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1RunnersJobsJobUUIDSuccessPost(Guid jobUUID, ApiV1RunnersJobsJobUUIDSuccessPostRequest? apiV1RunnersJobsJobUUIDSuccessPostRequest = default(ApiV1RunnersJobsJobUUIDSuccessPostRequest?), int operationIndex = 0)
        {
            ApiV1RunnersJobsJobUUIDSuccessPostWithHttpInfo(jobUUID, apiV1RunnersJobsJobUUIDSuccessPostRequest);
        }

        /// <summary>
        /// Post job success API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDSuccessPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1RunnersJobsJobUUIDSuccessPostWithHttpInfo(Guid jobUUID, ApiV1RunnersJobsJobUUIDSuccessPostRequest? apiV1RunnersJobsJobUUIDSuccessPostRequest = default(ApiV1RunnersJobsJobUUIDSuccessPostRequest?), int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("jobUUID", PeerTubeApiClient.Client.ClientUtils.ParameterToString(jobUUID)); // path parameter
            localVarRequestOptions.Data = apiV1RunnersJobsJobUUIDSuccessPostRequest;

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsJobUUIDSuccessPost";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/api/v1/runners/jobs/{jobUUID}/success", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsJobUUIDSuccessPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Post job success API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDSuccessPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1RunnersJobsJobUUIDSuccessPostAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDSuccessPostRequest? apiV1RunnersJobsJobUUIDSuccessPostRequest = default(ApiV1RunnersJobsJobUUIDSuccessPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1RunnersJobsJobUUIDSuccessPostWithHttpInfoAsync(jobUUID, apiV1RunnersJobsJobUUIDSuccessPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Post job success API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDSuccessPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1RunnersJobsJobUUIDSuccessPostWithHttpInfoAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDSuccessPostRequest? apiV1RunnersJobsJobUUIDSuccessPostRequest = default(ApiV1RunnersJobsJobUUIDSuccessPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("jobUUID", PeerTubeApiClient.Client.ClientUtils.ParameterToString(jobUUID)); // path parameter
            localVarRequestOptions.Data = apiV1RunnersJobsJobUUIDSuccessPostRequest;

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsJobUUIDSuccessPost";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/runners/jobs/{jobUUID}/success", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsJobUUIDSuccessPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDUpdatePostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1RunnersJobsJobUUIDUpdatePost(Guid jobUUID, ApiV1RunnersJobsJobUUIDUpdatePostRequest? apiV1RunnersJobsJobUUIDUpdatePostRequest = default(ApiV1RunnersJobsJobUUIDUpdatePostRequest?), int operationIndex = 0)
        {
            ApiV1RunnersJobsJobUUIDUpdatePostWithHttpInfo(jobUUID, apiV1RunnersJobsJobUUIDUpdatePostRequest);
        }

        /// <summary>
        /// Update job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDUpdatePostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1RunnersJobsJobUUIDUpdatePostWithHttpInfo(Guid jobUUID, ApiV1RunnersJobsJobUUIDUpdatePostRequest? apiV1RunnersJobsJobUUIDUpdatePostRequest = default(ApiV1RunnersJobsJobUUIDUpdatePostRequest?), int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("jobUUID", PeerTubeApiClient.Client.ClientUtils.ParameterToString(jobUUID)); // path parameter
            localVarRequestOptions.Data = apiV1RunnersJobsJobUUIDUpdatePostRequest;

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsJobUUIDUpdatePost";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/api/v1/runners/jobs/{jobUUID}/update", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsJobUUIDUpdatePost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDUpdatePostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1RunnersJobsJobUUIDUpdatePostAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDUpdatePostRequest? apiV1RunnersJobsJobUUIDUpdatePostRequest = default(ApiV1RunnersJobsJobUUIDUpdatePostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1RunnersJobsJobUUIDUpdatePostWithHttpInfoAsync(jobUUID, apiV1RunnersJobsJobUUIDUpdatePostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jobUUID"></param>
        /// <param name="apiV1RunnersJobsJobUUIDUpdatePostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1RunnersJobsJobUUIDUpdatePostWithHttpInfoAsync(Guid jobUUID, ApiV1RunnersJobsJobUUIDUpdatePostRequest? apiV1RunnersJobsJobUUIDUpdatePostRequest = default(ApiV1RunnersJobsJobUUIDUpdatePostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("jobUUID", PeerTubeApiClient.Client.ClientUtils.ParameterToString(jobUUID)); // path parameter
            localVarRequestOptions.Data = apiV1RunnersJobsJobUUIDUpdatePostRequest;

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsJobUUIDUpdatePost";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/runners/jobs/{jobUUID}/update", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsJobUUIDUpdatePost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Request a new job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1RunnersJobsRequestPost200Response</returns>
        public ApiV1RunnersJobsRequestPost200Response ApiV1RunnersJobsRequestPost(ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1RunnersJobsRequestPost200Response> localVarResponse = ApiV1RunnersJobsRequestPostWithHttpInfo(apiV1RunnersUnregisterPostRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Request a new job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1RunnersJobsRequestPost200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1RunnersJobsRequestPost200Response> ApiV1RunnersJobsRequestPostWithHttpInfo(ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0)
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

            localVarRequestOptions.Data = apiV1RunnersUnregisterPostRequest;

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsRequestPost";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<ApiV1RunnersJobsRequestPost200Response>("/api/v1/runners/jobs/request", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsRequestPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Request a new job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1RunnersJobsRequestPost200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1RunnersJobsRequestPost200Response> ApiV1RunnersJobsRequestPostAsync(ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1RunnersJobsRequestPost200Response> localVarResponse = await ApiV1RunnersJobsRequestPostWithHttpInfoAsync(apiV1RunnersUnregisterPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Request a new job API used by PeerTube runners
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1RunnersUnregisterPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1RunnersJobsRequestPost200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1RunnersJobsRequestPost200Response>> ApiV1RunnersJobsRequestPostWithHttpInfoAsync(ApiV1RunnersUnregisterPostRequest? apiV1RunnersUnregisterPostRequest = default(ApiV1RunnersUnregisterPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.Data = apiV1RunnersUnregisterPostRequest;

            localVarRequestOptions.Operation = "RunnerJobsApi.ApiV1RunnersJobsRequestPost";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<ApiV1RunnersJobsRequestPost200Response>("/api/v1/runners/jobs/request", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1RunnersJobsRequestPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
