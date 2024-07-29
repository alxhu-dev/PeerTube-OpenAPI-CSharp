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
    public interface ILiveVideosApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create a live
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId">Channel id that will contain this live video</param>
        /// <param name="name">Live video/replay name</param>
        /// <param name="saveReplay"> (optional)</param>
        /// <param name="replaySettings"> (optional)</param>
        /// <param name="permanentLive">User can stream multiple times in a permanent live (optional)</param>
        /// <param name="latencyMode"> (optional)</param>
        /// <param name="thumbnailfile">Live video/replay thumbnail file (optional)</param>
        /// <param name="previewfile">Live video/replay preview file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Live video/replay description (optional)</param>
        /// <param name="support">A text tell the audience how to support the creator (optional)</param>
        /// <param name="nsfw">Whether or not this live video/replay contains sensitive content (optional)</param>
        /// <param name="tags">Live video/replay tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for the replay of this live video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoUploadResponse</returns>
        VideoUploadResponse AddLive(int channelId, string name, bool? saveReplay = default(bool?), LiveVideoReplaySettings? replaySettings = default(LiveVideoReplaySettings?), bool? permanentLive = default(bool?), LiveVideoLatencyMode? latencyMode = default(LiveVideoLatencyMode?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), int operationIndex = 0);

        /// <summary>
        /// Create a live
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId">Channel id that will contain this live video</param>
        /// <param name="name">Live video/replay name</param>
        /// <param name="saveReplay"> (optional)</param>
        /// <param name="replaySettings"> (optional)</param>
        /// <param name="permanentLive">User can stream multiple times in a permanent live (optional)</param>
        /// <param name="latencyMode"> (optional)</param>
        /// <param name="thumbnailfile">Live video/replay thumbnail file (optional)</param>
        /// <param name="previewfile">Live video/replay preview file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Live video/replay description (optional)</param>
        /// <param name="support">A text tell the audience how to support the creator (optional)</param>
        /// <param name="nsfw">Whether or not this live video/replay contains sensitive content (optional)</param>
        /// <param name="tags">Live video/replay tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for the replay of this live video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoUploadResponse</returns>
        ApiResponse<VideoUploadResponse> AddLiveWithHttpInfo(int channelId, string name, bool? saveReplay = default(bool?), LiveVideoReplaySettings? replaySettings = default(LiveVideoReplaySettings?), bool? permanentLive = default(bool?), LiveVideoLatencyMode? latencyMode = default(LiveVideoLatencyMode?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), int operationIndex = 0);
        /// <summary>
        /// Get live session of a replay
        /// </summary>
        /// <remarks>
        /// If the video is a replay of a live, you can find the associated live session using this endpoint
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LiveVideoSessionResponse</returns>
        LiveVideoSessionResponse ApiV1VideosIdLiveSessionGet(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0);

        /// <summary>
        /// Get live session of a replay
        /// </summary>
        /// <remarks>
        /// If the video is a replay of a live, you can find the associated live session using this endpoint
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LiveVideoSessionResponse</returns>
        ApiResponse<LiveVideoSessionResponse> ApiV1VideosIdLiveSessionGetWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0);
        /// <summary>
        /// List live sessions
        /// </summary>
        /// <remarks>
        /// List all sessions created in a particular live
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1VideosLiveIdSessionsGet200Response</returns>
        ApiV1VideosLiveIdSessionsGet200Response ApiV1VideosLiveIdSessionsGet(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0);

        /// <summary>
        /// List live sessions
        /// </summary>
        /// <remarks>
        /// List all sessions created in a particular live
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1VideosLiveIdSessionsGet200Response</returns>
        ApiResponse<ApiV1VideosLiveIdSessionsGet200Response> ApiV1VideosLiveIdSessionsGetWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0);
        /// <summary>
        /// Get information about a live
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LiveVideoResponse</returns>
        LiveVideoResponse GetLiveId(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0);

        /// <summary>
        /// Get information about a live
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LiveVideoResponse</returns>
        ApiResponse<LiveVideoResponse> GetLiveIdWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0);
        /// <summary>
        /// Update information about a live
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="liveVideoUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void UpdateLiveId(ApiV1VideosOwnershipIdAcceptPostIdParameter id, LiveVideoUpdate? liveVideoUpdate = default(LiveVideoUpdate?), int operationIndex = 0);

        /// <summary>
        /// Update information about a live
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="liveVideoUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UpdateLiveIdWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, LiveVideoUpdate? liveVideoUpdate = default(LiveVideoUpdate?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ILiveVideosApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Create a live
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId">Channel id that will contain this live video</param>
        /// <param name="name">Live video/replay name</param>
        /// <param name="saveReplay"> (optional)</param>
        /// <param name="replaySettings"> (optional)</param>
        /// <param name="permanentLive">User can stream multiple times in a permanent live (optional)</param>
        /// <param name="latencyMode"> (optional)</param>
        /// <param name="thumbnailfile">Live video/replay thumbnail file (optional)</param>
        /// <param name="previewfile">Live video/replay preview file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Live video/replay description (optional)</param>
        /// <param name="support">A text tell the audience how to support the creator (optional)</param>
        /// <param name="nsfw">Whether or not this live video/replay contains sensitive content (optional)</param>
        /// <param name="tags">Live video/replay tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for the replay of this live video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoUploadResponse</returns>
        System.Threading.Tasks.Task<VideoUploadResponse> AddLiveAsync(int channelId, string name, bool? saveReplay = default(bool?), LiveVideoReplaySettings? replaySettings = default(LiveVideoReplaySettings?), bool? permanentLive = default(bool?), LiveVideoLatencyMode? latencyMode = default(LiveVideoLatencyMode?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a live
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId">Channel id that will contain this live video</param>
        /// <param name="name">Live video/replay name</param>
        /// <param name="saveReplay"> (optional)</param>
        /// <param name="replaySettings"> (optional)</param>
        /// <param name="permanentLive">User can stream multiple times in a permanent live (optional)</param>
        /// <param name="latencyMode"> (optional)</param>
        /// <param name="thumbnailfile">Live video/replay thumbnail file (optional)</param>
        /// <param name="previewfile">Live video/replay preview file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Live video/replay description (optional)</param>
        /// <param name="support">A text tell the audience how to support the creator (optional)</param>
        /// <param name="nsfw">Whether or not this live video/replay contains sensitive content (optional)</param>
        /// <param name="tags">Live video/replay tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for the replay of this live video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoUploadResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoUploadResponse>> AddLiveWithHttpInfoAsync(int channelId, string name, bool? saveReplay = default(bool?), LiveVideoReplaySettings? replaySettings = default(LiveVideoReplaySettings?), bool? permanentLive = default(bool?), LiveVideoLatencyMode? latencyMode = default(LiveVideoLatencyMode?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get live session of a replay
        /// </summary>
        /// <remarks>
        /// If the video is a replay of a live, you can find the associated live session using this endpoint
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LiveVideoSessionResponse</returns>
        System.Threading.Tasks.Task<LiveVideoSessionResponse> ApiV1VideosIdLiveSessionGetAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get live session of a replay
        /// </summary>
        /// <remarks>
        /// If the video is a replay of a live, you can find the associated live session using this endpoint
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LiveVideoSessionResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<LiveVideoSessionResponse>> ApiV1VideosIdLiveSessionGetWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List live sessions
        /// </summary>
        /// <remarks>
        /// List all sessions created in a particular live
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1VideosLiveIdSessionsGet200Response</returns>
        System.Threading.Tasks.Task<ApiV1VideosLiveIdSessionsGet200Response> ApiV1VideosLiveIdSessionsGetAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List live sessions
        /// </summary>
        /// <remarks>
        /// List all sessions created in a particular live
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1VideosLiveIdSessionsGet200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1VideosLiveIdSessionsGet200Response>> ApiV1VideosLiveIdSessionsGetWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get information about a live
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LiveVideoResponse</returns>
        System.Threading.Tasks.Task<LiveVideoResponse> GetLiveIdAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get information about a live
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LiveVideoResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<LiveVideoResponse>> GetLiveIdWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update information about a live
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="liveVideoUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UpdateLiveIdAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, LiveVideoUpdate? liveVideoUpdate = default(LiveVideoUpdate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update information about a live
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="liveVideoUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> UpdateLiveIdWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, LiveVideoUpdate? liveVideoUpdate = default(LiveVideoUpdate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ILiveVideosApi : ILiveVideosApiSync, ILiveVideosApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class LiveVideosApi : ILiveVideosApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="LiveVideosApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LiveVideosApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LiveVideosApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LiveVideosApi(string basePath)
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
        /// Initializes a new instance of the <see cref="LiveVideosApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public LiveVideosApi(PeerTubeApiClient.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="LiveVideosApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public LiveVideosApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
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
        /// Create a live 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId">Channel id that will contain this live video</param>
        /// <param name="name">Live video/replay name</param>
        /// <param name="saveReplay"> (optional)</param>
        /// <param name="replaySettings"> (optional)</param>
        /// <param name="permanentLive">User can stream multiple times in a permanent live (optional)</param>
        /// <param name="latencyMode"> (optional)</param>
        /// <param name="thumbnailfile">Live video/replay thumbnail file (optional)</param>
        /// <param name="previewfile">Live video/replay preview file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Live video/replay description (optional)</param>
        /// <param name="support">A text tell the audience how to support the creator (optional)</param>
        /// <param name="nsfw">Whether or not this live video/replay contains sensitive content (optional)</param>
        /// <param name="tags">Live video/replay tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for the replay of this live video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoUploadResponse</returns>
        public VideoUploadResponse AddLive(int channelId, string name, bool? saveReplay = default(bool?), LiveVideoReplaySettings? replaySettings = default(LiveVideoReplaySettings?), bool? permanentLive = default(bool?), LiveVideoLatencyMode? latencyMode = default(LiveVideoLatencyMode?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoUploadResponse> localVarResponse = AddLiveWithHttpInfo(channelId, name, saveReplay, replaySettings, permanentLive, latencyMode, thumbnailfile, previewfile, privacy, category, licence, language, description, support, nsfw, tags, commentsEnabled, commentsPolicy, downloadEnabled);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a live 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId">Channel id that will contain this live video</param>
        /// <param name="name">Live video/replay name</param>
        /// <param name="saveReplay"> (optional)</param>
        /// <param name="replaySettings"> (optional)</param>
        /// <param name="permanentLive">User can stream multiple times in a permanent live (optional)</param>
        /// <param name="latencyMode"> (optional)</param>
        /// <param name="thumbnailfile">Live video/replay thumbnail file (optional)</param>
        /// <param name="previewfile">Live video/replay preview file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Live video/replay description (optional)</param>
        /// <param name="support">A text tell the audience how to support the creator (optional)</param>
        /// <param name="nsfw">Whether or not this live video/replay contains sensitive content (optional)</param>
        /// <param name="tags">Live video/replay tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for the replay of this live video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoUploadResponse</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoUploadResponse> AddLiveWithHttpInfo(int channelId, string name, bool? saveReplay = default(bool?), LiveVideoReplaySettings? replaySettings = default(LiveVideoReplaySettings?), bool? permanentLive = default(bool?), LiveVideoLatencyMode? latencyMode = default(LiveVideoLatencyMode?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), int operationIndex = 0)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'name' when calling LiveVideosApi->AddLive");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "multipart/form-data"
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

            localVarRequestOptions.FormParameters.Add("channelId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelId)); // form parameter
            if (saveReplay != null)
            {
                localVarRequestOptions.FormParameters.Add("saveReplay", PeerTubeApiClient.Client.ClientUtils.ParameterToString(saveReplay)); // form parameter
            }
            if (replaySettings != null)
            {
                localVarRequestOptions.FormParameters.Add("replaySettings", PeerTubeApiClient.Client.ClientUtils.Serialize(replaySettings)); // form parameter
            }
            if (permanentLive != null)
            {
                localVarRequestOptions.FormParameters.Add("permanentLive", PeerTubeApiClient.Client.ClientUtils.ParameterToString(permanentLive)); // form parameter
            }
            if (latencyMode != null)
            {
                localVarRequestOptions.FormParameters.Add("latencyMode", PeerTubeApiClient.Client.ClientUtils.Serialize(latencyMode)); // form parameter
            }
            if (thumbnailfile != null)
            {
                localVarRequestOptions.FileParameters.Add("thumbnailfile", thumbnailfile);
            }
            if (previewfile != null)
            {
                localVarRequestOptions.FileParameters.Add("previewfile", previewfile);
            }
            if (privacy != null)
            {
                localVarRequestOptions.FormParameters.Add("privacy", PeerTubeApiClient.Client.ClientUtils.Serialize(privacy)); // form parameter
            }
            if (category != null)
            {
                localVarRequestOptions.FormParameters.Add("category", PeerTubeApiClient.Client.ClientUtils.ParameterToString(category)); // form parameter
            }
            if (licence != null)
            {
                localVarRequestOptions.FormParameters.Add("licence", PeerTubeApiClient.Client.ClientUtils.ParameterToString(licence)); // form parameter
            }
            if (language != null)
            {
                localVarRequestOptions.FormParameters.Add("language", PeerTubeApiClient.Client.ClientUtils.ParameterToString(language)); // form parameter
            }
            if (description != null)
            {
                localVarRequestOptions.FormParameters.Add("description", PeerTubeApiClient.Client.ClientUtils.ParameterToString(description)); // form parameter
            }
            if (support != null)
            {
                localVarRequestOptions.FormParameters.Add("support", PeerTubeApiClient.Client.ClientUtils.ParameterToString(support)); // form parameter
            }
            if (nsfw != null)
            {
                localVarRequestOptions.FormParameters.Add("nsfw", PeerTubeApiClient.Client.ClientUtils.ParameterToString(nsfw)); // form parameter
            }
            localVarRequestOptions.FormParameters.Add("name", PeerTubeApiClient.Client.ClientUtils.ParameterToString(name)); // form parameter
            if (tags != null)
            {
                localVarRequestOptions.FormParameters.Add("tags", PeerTubeApiClient.Client.ClientUtils.Serialize(tags)); // form parameter
            }
            if (commentsEnabled != null)
            {
                localVarRequestOptions.FormParameters.Add("commentsEnabled", PeerTubeApiClient.Client.ClientUtils.ParameterToString(commentsEnabled)); // form parameter
            }
            if (commentsPolicy != null)
            {
                localVarRequestOptions.FormParameters.Add("commentsPolicy", PeerTubeApiClient.Client.ClientUtils.Serialize(commentsPolicy)); // form parameter
            }
            if (downloadEnabled != null)
            {
                localVarRequestOptions.FormParameters.Add("downloadEnabled", PeerTubeApiClient.Client.ClientUtils.ParameterToString(downloadEnabled)); // form parameter
            }

            localVarRequestOptions.Operation = "LiveVideosApi.AddLive";
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
            var localVarResponse = this.Client.Post<VideoUploadResponse>("/api/v1/videos/live", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("AddLive", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a live 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId">Channel id that will contain this live video</param>
        /// <param name="name">Live video/replay name</param>
        /// <param name="saveReplay"> (optional)</param>
        /// <param name="replaySettings"> (optional)</param>
        /// <param name="permanentLive">User can stream multiple times in a permanent live (optional)</param>
        /// <param name="latencyMode"> (optional)</param>
        /// <param name="thumbnailfile">Live video/replay thumbnail file (optional)</param>
        /// <param name="previewfile">Live video/replay preview file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Live video/replay description (optional)</param>
        /// <param name="support">A text tell the audience how to support the creator (optional)</param>
        /// <param name="nsfw">Whether or not this live video/replay contains sensitive content (optional)</param>
        /// <param name="tags">Live video/replay tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for the replay of this live video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoUploadResponse</returns>
        public async System.Threading.Tasks.Task<VideoUploadResponse> AddLiveAsync(int channelId, string name, bool? saveReplay = default(bool?), LiveVideoReplaySettings? replaySettings = default(LiveVideoReplaySettings?), bool? permanentLive = default(bool?), LiveVideoLatencyMode? latencyMode = default(LiveVideoLatencyMode?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoUploadResponse> localVarResponse = await AddLiveWithHttpInfoAsync(channelId, name, saveReplay, replaySettings, permanentLive, latencyMode, thumbnailfile, previewfile, privacy, category, licence, language, description, support, nsfw, tags, commentsEnabled, commentsPolicy, downloadEnabled, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a live 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelId">Channel id that will contain this live video</param>
        /// <param name="name">Live video/replay name</param>
        /// <param name="saveReplay"> (optional)</param>
        /// <param name="replaySettings"> (optional)</param>
        /// <param name="permanentLive">User can stream multiple times in a permanent live (optional)</param>
        /// <param name="latencyMode"> (optional)</param>
        /// <param name="thumbnailfile">Live video/replay thumbnail file (optional)</param>
        /// <param name="previewfile">Live video/replay preview file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Live video/replay description (optional)</param>
        /// <param name="support">A text tell the audience how to support the creator (optional)</param>
        /// <param name="nsfw">Whether or not this live video/replay contains sensitive content (optional)</param>
        /// <param name="tags">Live video/replay tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for the replay of this live video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoUploadResponse)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoUploadResponse>> AddLiveWithHttpInfoAsync(int channelId, string name, bool? saveReplay = default(bool?), LiveVideoReplaySettings? replaySettings = default(LiveVideoReplaySettings?), bool? permanentLive = default(bool?), LiveVideoLatencyMode? latencyMode = default(LiveVideoLatencyMode?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'name' when calling LiveVideosApi->AddLive");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "multipart/form-data"
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

            localVarRequestOptions.FormParameters.Add("channelId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelId)); // form parameter
            if (saveReplay != null)
            {
                localVarRequestOptions.FormParameters.Add("saveReplay", PeerTubeApiClient.Client.ClientUtils.ParameterToString(saveReplay)); // form parameter
            }
            if (replaySettings != null)
            {
                localVarRequestOptions.FormParameters.Add("replaySettings", PeerTubeApiClient.Client.ClientUtils.Serialize(replaySettings)); // form parameter
            }
            if (permanentLive != null)
            {
                localVarRequestOptions.FormParameters.Add("permanentLive", PeerTubeApiClient.Client.ClientUtils.ParameterToString(permanentLive)); // form parameter
            }
            if (latencyMode != null)
            {
                localVarRequestOptions.FormParameters.Add("latencyMode", PeerTubeApiClient.Client.ClientUtils.Serialize(latencyMode)); // form parameter
            }
            if (thumbnailfile != null)
            {
                localVarRequestOptions.FileParameters.Add("thumbnailfile", thumbnailfile);
            }
            if (previewfile != null)
            {
                localVarRequestOptions.FileParameters.Add("previewfile", previewfile);
            }
            if (privacy != null)
            {
                localVarRequestOptions.FormParameters.Add("privacy", PeerTubeApiClient.Client.ClientUtils.Serialize(privacy)); // form parameter
            }
            if (category != null)
            {
                localVarRequestOptions.FormParameters.Add("category", PeerTubeApiClient.Client.ClientUtils.ParameterToString(category)); // form parameter
            }
            if (licence != null)
            {
                localVarRequestOptions.FormParameters.Add("licence", PeerTubeApiClient.Client.ClientUtils.ParameterToString(licence)); // form parameter
            }
            if (language != null)
            {
                localVarRequestOptions.FormParameters.Add("language", PeerTubeApiClient.Client.ClientUtils.ParameterToString(language)); // form parameter
            }
            if (description != null)
            {
                localVarRequestOptions.FormParameters.Add("description", PeerTubeApiClient.Client.ClientUtils.ParameterToString(description)); // form parameter
            }
            if (support != null)
            {
                localVarRequestOptions.FormParameters.Add("support", PeerTubeApiClient.Client.ClientUtils.ParameterToString(support)); // form parameter
            }
            if (nsfw != null)
            {
                localVarRequestOptions.FormParameters.Add("nsfw", PeerTubeApiClient.Client.ClientUtils.ParameterToString(nsfw)); // form parameter
            }
            localVarRequestOptions.FormParameters.Add("name", PeerTubeApiClient.Client.ClientUtils.ParameterToString(name)); // form parameter
            if (tags != null)
            {
                localVarRequestOptions.FormParameters.Add("tags", PeerTubeApiClient.Client.ClientUtils.Serialize(tags)); // form parameter
            }
            if (commentsEnabled != null)
            {
                localVarRequestOptions.FormParameters.Add("commentsEnabled", PeerTubeApiClient.Client.ClientUtils.ParameterToString(commentsEnabled)); // form parameter
            }
            if (commentsPolicy != null)
            {
                localVarRequestOptions.FormParameters.Add("commentsPolicy", PeerTubeApiClient.Client.ClientUtils.Serialize(commentsPolicy)); // form parameter
            }
            if (downloadEnabled != null)
            {
                localVarRequestOptions.FormParameters.Add("downloadEnabled", PeerTubeApiClient.Client.ClientUtils.ParameterToString(downloadEnabled)); // form parameter
            }

            localVarRequestOptions.Operation = "LiveVideosApi.AddLive";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<VideoUploadResponse>("/api/v1/videos/live", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("AddLive", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get live session of a replay If the video is a replay of a live, you can find the associated live session using this endpoint
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LiveVideoSessionResponse</returns>
        public LiveVideoSessionResponse ApiV1VideosIdLiveSessionGet(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<LiveVideoSessionResponse> localVarResponse = ApiV1VideosIdLiveSessionGetWithHttpInfo(id, xPeertubeVideoPassword);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get live session of a replay If the video is a replay of a live, you can find the associated live session using this endpoint
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LiveVideoSessionResponse</returns>
        public PeerTubeApiClient.Client.ApiResponse<LiveVideoSessionResponse> ApiV1VideosIdLiveSessionGetWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling LiveVideosApi->ApiV1VideosIdLiveSessionGet");
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
            if (xPeertubeVideoPassword != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-peertube-video-password", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xPeertubeVideoPassword)); // header parameter
            }

            localVarRequestOptions.Operation = "LiveVideosApi.ApiV1VideosIdLiveSessionGet";
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
            var localVarResponse = this.Client.Get<LiveVideoSessionResponse>("/api/v1/videos/{id}/live-session", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdLiveSessionGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get live session of a replay If the video is a replay of a live, you can find the associated live session using this endpoint
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LiveVideoSessionResponse</returns>
        public async System.Threading.Tasks.Task<LiveVideoSessionResponse> ApiV1VideosIdLiveSessionGetAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<LiveVideoSessionResponse> localVarResponse = await ApiV1VideosIdLiveSessionGetWithHttpInfoAsync(id, xPeertubeVideoPassword, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get live session of a replay If the video is a replay of a live, you can find the associated live session using this endpoint
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LiveVideoSessionResponse)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<LiveVideoSessionResponse>> ApiV1VideosIdLiveSessionGetWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling LiveVideosApi->ApiV1VideosIdLiveSessionGet");
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
            if (xPeertubeVideoPassword != null)
            {
                localVarRequestOptions.HeaderParameters.Add("x-peertube-video-password", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xPeertubeVideoPassword)); // header parameter
            }

            localVarRequestOptions.Operation = "LiveVideosApi.ApiV1VideosIdLiveSessionGet";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<LiveVideoSessionResponse>("/api/v1/videos/{id}/live-session", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdLiveSessionGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List live sessions List all sessions created in a particular live
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1VideosLiveIdSessionsGet200Response</returns>
        public ApiV1VideosLiveIdSessionsGet200Response ApiV1VideosLiveIdSessionsGet(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1VideosLiveIdSessionsGet200Response> localVarResponse = ApiV1VideosLiveIdSessionsGetWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List live sessions List all sessions created in a particular live
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1VideosLiveIdSessionsGet200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1VideosLiveIdSessionsGet200Response> ApiV1VideosLiveIdSessionsGetWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling LiveVideosApi->ApiV1VideosLiveIdSessionsGet");
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

            localVarRequestOptions.Operation = "LiveVideosApi.ApiV1VideosLiveIdSessionsGet";
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
            var localVarResponse = this.Client.Get<ApiV1VideosLiveIdSessionsGet200Response>("/api/v1/videos/live/{id}/sessions", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosLiveIdSessionsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List live sessions List all sessions created in a particular live
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1VideosLiveIdSessionsGet200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1VideosLiveIdSessionsGet200Response> ApiV1VideosLiveIdSessionsGetAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1VideosLiveIdSessionsGet200Response> localVarResponse = await ApiV1VideosLiveIdSessionsGetWithHttpInfoAsync(id, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List live sessions List all sessions created in a particular live
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1VideosLiveIdSessionsGet200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1VideosLiveIdSessionsGet200Response>> ApiV1VideosLiveIdSessionsGetWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling LiveVideosApi->ApiV1VideosLiveIdSessionsGet");
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

            localVarRequestOptions.Operation = "LiveVideosApi.ApiV1VideosLiveIdSessionsGet";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApiV1VideosLiveIdSessionsGet200Response>("/api/v1/videos/live/{id}/sessions", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosLiveIdSessionsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get information about a live 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>LiveVideoResponse</returns>
        public LiveVideoResponse GetLiveId(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<LiveVideoResponse> localVarResponse = GetLiveIdWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get information about a live 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of LiveVideoResponse</returns>
        public PeerTubeApiClient.Client.ApiResponse<LiveVideoResponse> GetLiveIdWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling LiveVideosApi->GetLiveId");
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

            localVarRequestOptions.Operation = "LiveVideosApi.GetLiveId";
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
            var localVarResponse = this.Client.Get<LiveVideoResponse>("/api/v1/videos/live/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLiveId", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get information about a live 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of LiveVideoResponse</returns>
        public async System.Threading.Tasks.Task<LiveVideoResponse> GetLiveIdAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<LiveVideoResponse> localVarResponse = await GetLiveIdWithHttpInfoAsync(id, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get information about a live 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (LiveVideoResponse)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<LiveVideoResponse>> GetLiveIdWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling LiveVideosApi->GetLiveId");
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

            localVarRequestOptions.Operation = "LiveVideosApi.GetLiveId";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<LiveVideoResponse>("/api/v1/videos/live/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLiveId", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update information about a live 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="liveVideoUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void UpdateLiveId(ApiV1VideosOwnershipIdAcceptPostIdParameter id, LiveVideoUpdate? liveVideoUpdate = default(LiveVideoUpdate?), int operationIndex = 0)
        {
            UpdateLiveIdWithHttpInfo(id, liveVideoUpdate);
        }

        /// <summary>
        /// Update information about a live 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="liveVideoUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> UpdateLiveIdWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, LiveVideoUpdate? liveVideoUpdate = default(LiveVideoUpdate?), int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling LiveVideosApi->UpdateLiveId");
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

            localVarRequestOptions.PathParameters.Add("id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.Data = liveVideoUpdate;

            localVarRequestOptions.Operation = "LiveVideosApi.UpdateLiveId";
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
            var localVarResponse = this.Client.Put<Object>("/api/v1/videos/live/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateLiveId", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update information about a live 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="liveVideoUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UpdateLiveIdAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, LiveVideoUpdate? liveVideoUpdate = default(LiveVideoUpdate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UpdateLiveIdWithHttpInfoAsync(id, liveVideoUpdate, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update information about a live 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="liveVideoUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> UpdateLiveIdWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, LiveVideoUpdate? liveVideoUpdate = default(LiveVideoUpdate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling LiveVideosApi->UpdateLiveId");
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

            localVarRequestOptions.PathParameters.Add("id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.Data = liveVideoUpdate;

            localVarRequestOptions.Operation = "LiveVideosApi.UpdateLiveId";
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
            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/api/v1/videos/live/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateLiveId", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
