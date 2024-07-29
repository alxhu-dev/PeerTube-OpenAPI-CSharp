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
    public interface IVideoCommentsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// List comments on user&#39;s videos
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isHeldForReview">only display comments that are held for review (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1UsersMeVideosCommentsGet200Response</returns>
        ApiV1UsersMeVideosCommentsGet200Response ApiV1UsersMeVideosCommentsGet(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isHeldForReview = default(bool?), int operationIndex = 0);

        /// <summary>
        /// List comments on user&#39;s videos
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isHeldForReview">only display comments that are held for review (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1UsersMeVideosCommentsGet200Response</returns>
        ApiResponse<ApiV1UsersMeVideosCommentsGet200Response> ApiV1UsersMeVideosCommentsGetWithHttpInfo(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isHeldForReview = default(bool?), int operationIndex = 0);
        /// <summary>
        /// List instance comments
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="onLocalVideo">Display only objects of local or remote videos (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1UsersMeVideosCommentsGet200Response</returns>
        ApiV1UsersMeVideosCommentsGet200Response ApiV1VideosCommentsGet(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isLocal = default(bool?), bool? onLocalVideo = default(bool?), int operationIndex = 0);

        /// <summary>
        /// List instance comments
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="onLocalVideo">Display only objects of local or remote videos (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1UsersMeVideosCommentsGet200Response</returns>
        ApiResponse<ApiV1UsersMeVideosCommentsGet200Response> ApiV1VideosCommentsGetWithHttpInfo(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isLocal = default(bool?), bool? onLocalVideo = default(bool?), int operationIndex = 0);
        /// <summary>
        /// List threads of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort comments by criteria (optional)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommentThreadResponse</returns>
        CommentThreadResponse ApiV1VideosIdCommentThreadsGet(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? xPeertubeVideoPassword = default(string?), int operationIndex = 0);

        /// <summary>
        /// List threads of a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort comments by criteria (optional)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommentThreadResponse</returns>
        ApiResponse<CommentThreadResponse> ApiV1VideosIdCommentThreadsGetWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? xPeertubeVideoPassword = default(string?), int operationIndex = 0);
        /// <summary>
        /// Create a thread
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommentThreadPostResponse</returns>
        CommentThreadPostResponse ApiV1VideosIdCommentThreadsPost(ApiV1VideosOwnershipIdAcceptPostIdParameter id, ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0);

        /// <summary>
        /// Create a thread
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommentThreadPostResponse</returns>
        ApiResponse<CommentThreadPostResponse> ApiV1VideosIdCommentThreadsPostWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0);
        /// <summary>
        /// Get a thread
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="threadId">The thread id (root comment id)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoCommentThreadTree</returns>
        VideoCommentThreadTree ApiV1VideosIdCommentThreadsThreadIdGet(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int threadId, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0);

        /// <summary>
        /// Get a thread
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="threadId">The thread id (root comment id)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoCommentThreadTree</returns>
        ApiResponse<VideoCommentThreadTree> ApiV1VideosIdCommentThreadsThreadIdGetWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int threadId, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0);
        /// <summary>
        /// Approve a comment
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2** Approve a comment that requires a review
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1VideosIdCommentsCommentIdApprovePost(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0);

        /// <summary>
        /// Approve a comment
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2** Approve a comment that requires a review
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1VideosIdCommentsCommentIdApprovePostWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0);
        /// <summary>
        /// Delete a comment or a reply
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1VideosIdCommentsCommentIdDelete(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0);

        /// <summary>
        /// Delete a comment or a reply
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1VideosIdCommentsCommentIdDeleteWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0);
        /// <summary>
        /// Reply to a thread of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommentThreadPostResponse</returns>
        CommentThreadPostResponse ApiV1VideosIdCommentsCommentIdPost(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, string? xPeertubeVideoPassword = default(string?), ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0);

        /// <summary>
        /// Reply to a thread of a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommentThreadPostResponse</returns>
        ApiResponse<CommentThreadPostResponse> ApiV1VideosIdCommentsCommentIdPostWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, string? xPeertubeVideoPassword = default(string?), ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IVideoCommentsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// List comments on user&#39;s videos
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isHeldForReview">only display comments that are held for review (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1UsersMeVideosCommentsGet200Response</returns>
        System.Threading.Tasks.Task<ApiV1UsersMeVideosCommentsGet200Response> ApiV1UsersMeVideosCommentsGetAsync(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isHeldForReview = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List comments on user&#39;s videos
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isHeldForReview">only display comments that are held for review (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1UsersMeVideosCommentsGet200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1UsersMeVideosCommentsGet200Response>> ApiV1UsersMeVideosCommentsGetWithHttpInfoAsync(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isHeldForReview = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List instance comments
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="onLocalVideo">Display only objects of local or remote videos (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1UsersMeVideosCommentsGet200Response</returns>
        System.Threading.Tasks.Task<ApiV1UsersMeVideosCommentsGet200Response> ApiV1VideosCommentsGetAsync(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isLocal = default(bool?), bool? onLocalVideo = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List instance comments
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="onLocalVideo">Display only objects of local or remote videos (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1UsersMeVideosCommentsGet200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1UsersMeVideosCommentsGet200Response>> ApiV1VideosCommentsGetWithHttpInfoAsync(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isLocal = default(bool?), bool? onLocalVideo = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List threads of a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort comments by criteria (optional)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommentThreadResponse</returns>
        System.Threading.Tasks.Task<CommentThreadResponse> ApiV1VideosIdCommentThreadsGetAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List threads of a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort comments by criteria (optional)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommentThreadResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommentThreadResponse>> ApiV1VideosIdCommentThreadsGetWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create a thread
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommentThreadPostResponse</returns>
        System.Threading.Tasks.Task<CommentThreadPostResponse> ApiV1VideosIdCommentThreadsPostAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a thread
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommentThreadPostResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommentThreadPostResponse>> ApiV1VideosIdCommentThreadsPostWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get a thread
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="threadId">The thread id (root comment id)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoCommentThreadTree</returns>
        System.Threading.Tasks.Task<VideoCommentThreadTree> ApiV1VideosIdCommentThreadsThreadIdGetAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int threadId, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get a thread
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="threadId">The thread id (root comment id)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoCommentThreadTree)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoCommentThreadTree>> ApiV1VideosIdCommentThreadsThreadIdGetWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int threadId, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Approve a comment
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2** Approve a comment that requires a review
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1VideosIdCommentsCommentIdApprovePostAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Approve a comment
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.2** Approve a comment that requires a review
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1VideosIdCommentsCommentIdApprovePostWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete a comment or a reply
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1VideosIdCommentsCommentIdDeleteAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete a comment or a reply
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1VideosIdCommentsCommentIdDeleteWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Reply to a thread of a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommentThreadPostResponse</returns>
        System.Threading.Tasks.Task<CommentThreadPostResponse> ApiV1VideosIdCommentsCommentIdPostAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, string? xPeertubeVideoPassword = default(string?), ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Reply to a thread of a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommentThreadPostResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommentThreadPostResponse>> ApiV1VideosIdCommentsCommentIdPostWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, string? xPeertubeVideoPassword = default(string?), ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IVideoCommentsApi : IVideoCommentsApiSync, IVideoCommentsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class VideoCommentsApi : IVideoCommentsApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoCommentsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public VideoCommentsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoCommentsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public VideoCommentsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="VideoCommentsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public VideoCommentsApi(PeerTubeApiClient.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="VideoCommentsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public VideoCommentsApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
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
        /// List comments on user&#39;s videos **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isHeldForReview">only display comments that are held for review (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1UsersMeVideosCommentsGet200Response</returns>
        public ApiV1UsersMeVideosCommentsGet200Response ApiV1UsersMeVideosCommentsGet(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isHeldForReview = default(bool?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeVideosCommentsGet200Response> localVarResponse = ApiV1UsersMeVideosCommentsGetWithHttpInfo(search, searchAccount, searchVideo, videoId, videoChannelId, autoTagOneOf, isHeldForReview);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List comments on user&#39;s videos **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isHeldForReview">only display comments that are held for review (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1UsersMeVideosCommentsGet200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeVideosCommentsGet200Response> ApiV1UsersMeVideosCommentsGetWithHttpInfo(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isHeldForReview = default(bool?), int operationIndex = 0)
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

            if (search != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "search", search));
            }
            if (searchAccount != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchAccount", searchAccount));
            }
            if (searchVideo != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchVideo", searchVideo));
            }
            if (videoId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoId", videoId));
            }
            if (videoChannelId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoChannelId", videoChannelId));
            }
            if (autoTagOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "autoTagOneOf", autoTagOneOf));
            }
            if (isHeldForReview != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isHeldForReview", isHeldForReview));
            }

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1UsersMeVideosCommentsGet";
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
            var localVarResponse = this.Client.Get<ApiV1UsersMeVideosCommentsGet200Response>("/api/v1/users/me/videos/comments", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeVideosCommentsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List comments on user&#39;s videos **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isHeldForReview">only display comments that are held for review (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1UsersMeVideosCommentsGet200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1UsersMeVideosCommentsGet200Response> ApiV1UsersMeVideosCommentsGetAsync(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isHeldForReview = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeVideosCommentsGet200Response> localVarResponse = await ApiV1UsersMeVideosCommentsGetWithHttpInfoAsync(search, searchAccount, searchVideo, videoId, videoChannelId, autoTagOneOf, isHeldForReview, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List comments on user&#39;s videos **PeerTube &gt;&#x3D; 6.2**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isHeldForReview">only display comments that are held for review (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1UsersMeVideosCommentsGet200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeVideosCommentsGet200Response>> ApiV1UsersMeVideosCommentsGetWithHttpInfoAsync(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isHeldForReview = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (search != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "search", search));
            }
            if (searchAccount != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchAccount", searchAccount));
            }
            if (searchVideo != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchVideo", searchVideo));
            }
            if (videoId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoId", videoId));
            }
            if (videoChannelId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoChannelId", videoChannelId));
            }
            if (autoTagOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "autoTagOneOf", autoTagOneOf));
            }
            if (isHeldForReview != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isHeldForReview", isHeldForReview));
            }

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1UsersMeVideosCommentsGet";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApiV1UsersMeVideosCommentsGet200Response>("/api/v1/users/me/videos/comments", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeVideosCommentsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List instance comments 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="onLocalVideo">Display only objects of local or remote videos (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1UsersMeVideosCommentsGet200Response</returns>
        public ApiV1UsersMeVideosCommentsGet200Response ApiV1VideosCommentsGet(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isLocal = default(bool?), bool? onLocalVideo = default(bool?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeVideosCommentsGet200Response> localVarResponse = ApiV1VideosCommentsGetWithHttpInfo(search, searchAccount, searchVideo, videoId, videoChannelId, autoTagOneOf, isLocal, onLocalVideo);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List instance comments 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="onLocalVideo">Display only objects of local or remote videos (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1UsersMeVideosCommentsGet200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeVideosCommentsGet200Response> ApiV1VideosCommentsGetWithHttpInfo(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isLocal = default(bool?), bool? onLocalVideo = default(bool?), int operationIndex = 0)
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

            if (search != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "search", search));
            }
            if (searchAccount != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchAccount", searchAccount));
            }
            if (searchVideo != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchVideo", searchVideo));
            }
            if (videoId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoId", videoId));
            }
            if (videoChannelId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoChannelId", videoChannelId));
            }
            if (autoTagOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "autoTagOneOf", autoTagOneOf));
            }
            if (isLocal != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLocal", isLocal));
            }
            if (onLocalVideo != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "onLocalVideo", onLocalVideo));
            }

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1VideosCommentsGet";
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
            var localVarResponse = this.Client.Get<ApiV1UsersMeVideosCommentsGet200Response>("/api/v1/videos/comments", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosCommentsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List instance comments 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="onLocalVideo">Display only objects of local or remote videos (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1UsersMeVideosCommentsGet200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1UsersMeVideosCommentsGet200Response> ApiV1VideosCommentsGetAsync(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isLocal = default(bool?), bool? onLocalVideo = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeVideosCommentsGet200Response> localVarResponse = await ApiV1VideosCommentsGetWithHttpInfoAsync(search, searchAccount, searchVideo, videoId, videoChannelId, autoTagOneOf, isLocal, onLocalVideo, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List instance comments 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="searchAccount">Filter comments by searching on the account (optional)</param>
        /// <param name="searchVideo">Filter comments by searching on the video (optional)</param>
        /// <param name="videoId">Limit results on this specific video (optional)</param>
        /// <param name="videoChannelId">Limit results on this specific video channel (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** filter on comments that contain one of these automatic tags (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="onLocalVideo">Display only objects of local or remote videos (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1UsersMeVideosCommentsGet200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeVideosCommentsGet200Response>> ApiV1VideosCommentsGetWithHttpInfoAsync(string? search = default(string?), string? searchAccount = default(string?), string? searchVideo = default(string?), int? videoId = default(int?), int? videoChannelId = default(int?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), bool? isLocal = default(bool?), bool? onLocalVideo = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (search != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "search", search));
            }
            if (searchAccount != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchAccount", searchAccount));
            }
            if (searchVideo != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchVideo", searchVideo));
            }
            if (videoId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoId", videoId));
            }
            if (videoChannelId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoChannelId", videoChannelId));
            }
            if (autoTagOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "autoTagOneOf", autoTagOneOf));
            }
            if (isLocal != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLocal", isLocal));
            }
            if (onLocalVideo != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "onLocalVideo", onLocalVideo));
            }

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1VideosCommentsGet";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApiV1UsersMeVideosCommentsGet200Response>("/api/v1/videos/comments", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosCommentsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List threads of a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort comments by criteria (optional)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommentThreadResponse</returns>
        public CommentThreadResponse ApiV1VideosIdCommentThreadsGet(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? xPeertubeVideoPassword = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<CommentThreadResponse> localVarResponse = ApiV1VideosIdCommentThreadsGetWithHttpInfo(id, start, count, sort, xPeertubeVideoPassword);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List threads of a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort comments by criteria (optional)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommentThreadResponse</returns>
        public PeerTubeApiClient.Client.ApiResponse<CommentThreadResponse> ApiV1VideosIdCommentThreadsGetWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? xPeertubeVideoPassword = default(string?), int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoCommentsApi->ApiV1VideosIdCommentThreadsGet");
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

            localVarRequestOptions.PathParameters.Add("id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(id)); // path parameter
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
            if (xPeertubeVideoPassword != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-peertube-video-password", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xPeertubeVideoPassword)); // header parameter
            }

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1VideosIdCommentThreadsGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<CommentThreadResponse>("/api/v1/videos/{id}/comment-threads", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdCommentThreadsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List threads of a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort comments by criteria (optional)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommentThreadResponse</returns>
        public async System.Threading.Tasks.Task<CommentThreadResponse> ApiV1VideosIdCommentThreadsGetAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<CommentThreadResponse> localVarResponse = await ApiV1VideosIdCommentThreadsGetWithHttpInfoAsync(id, start, count, sort, xPeertubeVideoPassword, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List threads of a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort comments by criteria (optional)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommentThreadResponse)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<CommentThreadResponse>> ApiV1VideosIdCommentThreadsGetWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoCommentsApi->ApiV1VideosIdCommentThreadsGet");
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

            localVarRequestOptions.PathParameters.Add("id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(id)); // path parameter
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
            if (xPeertubeVideoPassword != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-peertube-video-password", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xPeertubeVideoPassword)); // header parameter
            }

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1VideosIdCommentThreadsGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<CommentThreadResponse>("/api/v1/videos/{id}/comment-threads", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdCommentThreadsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a thread 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommentThreadPostResponse</returns>
        public CommentThreadPostResponse ApiV1VideosIdCommentThreadsPost(ApiV1VideosOwnershipIdAcceptPostIdParameter id, ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<CommentThreadPostResponse> localVarResponse = ApiV1VideosIdCommentThreadsPostWithHttpInfo(id, apiV1VideosIdCommentThreadsPostRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a thread 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommentThreadPostResponse</returns>
        public PeerTubeApiClient.Client.ApiResponse<CommentThreadPostResponse> ApiV1VideosIdCommentThreadsPostWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoCommentsApi->ApiV1VideosIdCommentThreadsPost");
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

            localVarRequestOptions.PathParameters.Add("id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.Data = apiV1VideosIdCommentThreadsPostRequest;

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1VideosIdCommentThreadsPost";
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
            var localVarResponse = this.Client.Post<CommentThreadPostResponse>("/api/v1/videos/{id}/comment-threads", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdCommentThreadsPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a thread 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommentThreadPostResponse</returns>
        public async System.Threading.Tasks.Task<CommentThreadPostResponse> ApiV1VideosIdCommentThreadsPostAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<CommentThreadPostResponse> localVarResponse = await ApiV1VideosIdCommentThreadsPostWithHttpInfoAsync(id, apiV1VideosIdCommentThreadsPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a thread 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommentThreadPostResponse)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<CommentThreadPostResponse>> ApiV1VideosIdCommentThreadsPostWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoCommentsApi->ApiV1VideosIdCommentThreadsPost");
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

            localVarRequestOptions.PathParameters.Add("id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.Data = apiV1VideosIdCommentThreadsPostRequest;

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1VideosIdCommentThreadsPost";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<CommentThreadPostResponse>("/api/v1/videos/{id}/comment-threads", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdCommentThreadsPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a thread 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="threadId">The thread id (root comment id)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoCommentThreadTree</returns>
        public VideoCommentThreadTree ApiV1VideosIdCommentThreadsThreadIdGet(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int threadId, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoCommentThreadTree> localVarResponse = ApiV1VideosIdCommentThreadsThreadIdGetWithHttpInfo(id, threadId, xPeertubeVideoPassword);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a thread 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="threadId">The thread id (root comment id)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoCommentThreadTree</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoCommentThreadTree> ApiV1VideosIdCommentThreadsThreadIdGetWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int threadId, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoCommentsApi->ApiV1VideosIdCommentThreadsThreadIdGet");
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

            localVarRequestOptions.PathParameters.Add("id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.PathParameters.Add("threadId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(threadId)); // path parameter
            if (xPeertubeVideoPassword != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-peertube-video-password", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xPeertubeVideoPassword)); // header parameter
            }

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1VideosIdCommentThreadsThreadIdGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<VideoCommentThreadTree>("/api/v1/videos/{id}/comment-threads/{threadId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdCommentThreadsThreadIdGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a thread 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="threadId">The thread id (root comment id)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoCommentThreadTree</returns>
        public async System.Threading.Tasks.Task<VideoCommentThreadTree> ApiV1VideosIdCommentThreadsThreadIdGetAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int threadId, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoCommentThreadTree> localVarResponse = await ApiV1VideosIdCommentThreadsThreadIdGetWithHttpInfoAsync(id, threadId, xPeertubeVideoPassword, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a thread 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="threadId">The thread id (root comment id)</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoCommentThreadTree)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoCommentThreadTree>> ApiV1VideosIdCommentThreadsThreadIdGetWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int threadId, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoCommentsApi->ApiV1VideosIdCommentThreadsThreadIdGet");
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

            localVarRequestOptions.PathParameters.Add("id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.PathParameters.Add("threadId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(threadId)); // path parameter
            if (xPeertubeVideoPassword != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-peertube-video-password", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xPeertubeVideoPassword)); // header parameter
            }

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1VideosIdCommentThreadsThreadIdGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoCommentThreadTree>("/api/v1/videos/{id}/comment-threads/{threadId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdCommentThreadsThreadIdGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Approve a comment **PeerTube &gt;&#x3D; 6.2** Approve a comment that requires a review
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1VideosIdCommentsCommentIdApprovePost(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0)
        {
            ApiV1VideosIdCommentsCommentIdApprovePostWithHttpInfo(id, commentId);
        }

        /// <summary>
        /// Approve a comment **PeerTube &gt;&#x3D; 6.2** Approve a comment that requires a review
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1VideosIdCommentsCommentIdApprovePostWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoCommentsApi->ApiV1VideosIdCommentsCommentIdApprovePost");
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

            localVarRequestOptions.PathParameters.Add("id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.PathParameters.Add("commentId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(commentId)); // path parameter

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1VideosIdCommentsCommentIdApprovePost";
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
            var localVarResponse = this.Client.Post<Object>("/api/v1/videos/{id}/comments/{commentId}/approve", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdCommentsCommentIdApprovePost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Approve a comment **PeerTube &gt;&#x3D; 6.2** Approve a comment that requires a review
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1VideosIdCommentsCommentIdApprovePostAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1VideosIdCommentsCommentIdApprovePostWithHttpInfoAsync(id, commentId, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Approve a comment **PeerTube &gt;&#x3D; 6.2** Approve a comment that requires a review
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1VideosIdCommentsCommentIdApprovePostWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoCommentsApi->ApiV1VideosIdCommentsCommentIdApprovePost");
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

            localVarRequestOptions.PathParameters.Add("id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.PathParameters.Add("commentId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(commentId)); // path parameter

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1VideosIdCommentsCommentIdApprovePost";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/videos/{id}/comments/{commentId}/approve", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdCommentsCommentIdApprovePost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a comment or a reply 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1VideosIdCommentsCommentIdDelete(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0)
        {
            ApiV1VideosIdCommentsCommentIdDeleteWithHttpInfo(id, commentId);
        }

        /// <summary>
        /// Delete a comment or a reply 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1VideosIdCommentsCommentIdDeleteWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoCommentsApi->ApiV1VideosIdCommentsCommentIdDelete");
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

            localVarRequestOptions.PathParameters.Add("id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.PathParameters.Add("commentId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(commentId)); // path parameter

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1VideosIdCommentsCommentIdDelete";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/videos/{id}/comments/{commentId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdCommentsCommentIdDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a comment or a reply 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1VideosIdCommentsCommentIdDeleteAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1VideosIdCommentsCommentIdDeleteWithHttpInfoAsync(id, commentId, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a comment or a reply 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1VideosIdCommentsCommentIdDeleteWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoCommentsApi->ApiV1VideosIdCommentsCommentIdDelete");
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

            localVarRequestOptions.PathParameters.Add("id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.PathParameters.Add("commentId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(commentId)); // path parameter

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1VideosIdCommentsCommentIdDelete";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/videos/{id}/comments/{commentId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdCommentsCommentIdDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Reply to a thread of a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CommentThreadPostResponse</returns>
        public CommentThreadPostResponse ApiV1VideosIdCommentsCommentIdPost(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, string? xPeertubeVideoPassword = default(string?), ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<CommentThreadPostResponse> localVarResponse = ApiV1VideosIdCommentsCommentIdPostWithHttpInfo(id, commentId, xPeertubeVideoPassword, apiV1VideosIdCommentThreadsPostRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Reply to a thread of a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CommentThreadPostResponse</returns>
        public PeerTubeApiClient.Client.ApiResponse<CommentThreadPostResponse> ApiV1VideosIdCommentsCommentIdPostWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, string? xPeertubeVideoPassword = default(string?), ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoCommentsApi->ApiV1VideosIdCommentsCommentIdPost");
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

            localVarRequestOptions.PathParameters.Add("id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.PathParameters.Add("commentId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(commentId)); // path parameter
            if (xPeertubeVideoPassword != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-peertube-video-password", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xPeertubeVideoPassword)); // header parameter
            }
            localVarRequestOptions.Data = apiV1VideosIdCommentThreadsPostRequest;

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1VideosIdCommentsCommentIdPost";
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
            var localVarResponse = this.Client.Post<CommentThreadPostResponse>("/api/v1/videos/{id}/comments/{commentId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdCommentsCommentIdPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Reply to a thread of a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CommentThreadPostResponse</returns>
        public async System.Threading.Tasks.Task<CommentThreadPostResponse> ApiV1VideosIdCommentsCommentIdPostAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, string? xPeertubeVideoPassword = default(string?), ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<CommentThreadPostResponse> localVarResponse = await ApiV1VideosIdCommentsCommentIdPostWithHttpInfoAsync(id, commentId, xPeertubeVideoPassword, apiV1VideosIdCommentThreadsPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Reply to a thread of a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="commentId">The comment id</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="apiV1VideosIdCommentThreadsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CommentThreadPostResponse)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<CommentThreadPostResponse>> ApiV1VideosIdCommentsCommentIdPostWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int commentId, string? xPeertubeVideoPassword = default(string?), ApiV1VideosIdCommentThreadsPostRequest? apiV1VideosIdCommentThreadsPostRequest = default(ApiV1VideosIdCommentThreadsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoCommentsApi->ApiV1VideosIdCommentsCommentIdPost");
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

            localVarRequestOptions.PathParameters.Add("id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.PathParameters.Add("commentId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(commentId)); // path parameter
            if (xPeertubeVideoPassword != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-peertube-video-password", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xPeertubeVideoPassword)); // header parameter
            }
            localVarRequestOptions.Data = apiV1VideosIdCommentThreadsPostRequest;

            localVarRequestOptions.Operation = "VideoCommentsApi.ApiV1VideosIdCommentsCommentIdPost";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<CommentThreadPostResponse>("/api/v1/videos/{id}/comments/{commentId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdCommentsCommentIdPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
