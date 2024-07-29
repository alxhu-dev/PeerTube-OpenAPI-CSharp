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
    public interface IVideoApiSync : IApiAccessor
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
        /// Notify user is watching a video
        /// </summary>
        /// <remarks>
        /// Call this endpoint regularly (every 5-10 seconds for example) to notify the server the user is watching the video. After a while, PeerTube will increase video&#39;s viewers counter. If the user is authenticated, PeerTube will also store the current player time.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void AddView(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0);

        /// <summary>
        /// Notify user is watching a video
        /// </summary>
        /// <remarks>
        /// Call this endpoint regularly (every 5-10 seconds for example) to notify the server the user is watching the video. After a while, PeerTube will increase video&#39;s viewers counter. If the user is authenticated, PeerTube will also store the current player time.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> AddViewWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0);
        /// <summary>
        /// Create a studio task
        /// </summary>
        /// <remarks>
        /// Create a task to edit a video  (cut, add intro/outro etc)
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1VideosIdStudioEditPost(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0);

        /// <summary>
        /// Create a studio task
        /// </summary>
        /// <remarks>
        /// Create a task to edit a video  (cut, add intro/outro etc)
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1VideosIdStudioEditPostWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0);
        /// <summary>
        /// Set watching progress of a video
        /// </summary>
        /// <remarks>
        /// This endpoint has been deprecated. Use &#x60;/videos/{id}/views&#x60; instead
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        [Obsolete]
        void ApiV1VideosIdWatchingPut(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0);

        /// <summary>
        /// Set watching progress of a video
        /// </summary>
        /// <remarks>
        /// This endpoint has been deprecated. Use &#x60;/videos/{id}/views&#x60; instead
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        [Obsolete]
        ApiResponse<Object> ApiV1VideosIdWatchingPutWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0);
        /// <summary>
        /// Delete a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void DelVideo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0);

        /// <summary>
        /// Delete a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DelVideoWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0);
        /// <summary>
        /// Delete video source file
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void DeleteVideoSourceFile(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0);

        /// <summary>
        /// Delete video source file
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteVideoSourceFileWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0);
        /// <summary>
        /// List videos of an account
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoListResponse</returns>
        VideoListResponse GetAccountVideos(string name, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0);

        /// <summary>
        /// List videos of an account
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoListResponse</returns>
        ApiResponse<VideoListResponse> GetAccountVideosWithHttpInfo(string name, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0);
        /// <summary>
        /// List available video categories
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetCategories(int operationIndex = 0);

        /// <summary>
        /// List available video categories
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        ApiResponse<List<string>> GetCategoriesWithHttpInfo(int operationIndex = 0);
        /// <summary>
        /// List available video languages
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetLanguages(int operationIndex = 0);

        /// <summary>
        /// List available video languages
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        ApiResponse<List<string>> GetLanguagesWithHttpInfo(int operationIndex = 0);
        /// <summary>
        /// List available video licences
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetLicences(int operationIndex = 0);

        /// <summary>
        /// List available video licences
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        ApiResponse<List<string>> GetLicencesWithHttpInfo(int operationIndex = 0);
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
        /// Get a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoDetails</returns>
        VideoDetails GetVideo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0);

        /// <summary>
        /// Get a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoDetails</returns>
        ApiResponse<VideoDetails> GetVideoWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0);
        /// <summary>
        /// List videos of a video channel
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoListResponse</returns>
        VideoListResponse GetVideoChannelVideos(string channelHandle, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0);

        /// <summary>
        /// List videos of a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoListResponse</returns>
        ApiResponse<VideoListResponse> GetVideoChannelVideosWithHttpInfo(string channelHandle, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0);
        /// <summary>
        /// Get complete video description
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>string</returns>
        string GetVideoDesc(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0);

        /// <summary>
        /// Get complete video description
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> GetVideoDescWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0);
        /// <summary>
        /// List available video privacy policies
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetVideoPrivacyPolicies(int operationIndex = 0);

        /// <summary>
        /// List available video privacy policies
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        ApiResponse<List<string>> GetVideoPrivacyPoliciesWithHttpInfo(int operationIndex = 0);
        /// <summary>
        /// Get video source file metadata
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoSource</returns>
        VideoSource GetVideoSource(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0);

        /// <summary>
        /// Get video source file metadata
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoSource</returns>
        ApiResponse<VideoSource> GetVideoSourceWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0);
        /// <summary>
        /// List videos
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoListResponse</returns>
        VideoListResponse GetVideos(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0);

        /// <summary>
        /// List videos
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoListResponse</returns>
        ApiResponse<VideoListResponse> GetVideosWithHttpInfo(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0);
        /// <summary>
        /// List storyboards of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ListVideoStoryboards200Response</returns>
        ListVideoStoryboards200Response ListVideoStoryboards(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0);

        /// <summary>
        /// List storyboards of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ListVideoStoryboards200Response</returns>
        ApiResponse<ListVideoStoryboards200Response> ListVideoStoryboardsWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0);
        /// <summary>
        /// Update a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="name">Video name (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void PutVideo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), VideoPrivacySet? privacy = default(VideoPrivacySet?), string? description = default(string?), string? waitTranscoding = default(string?), string? support = default(string?), bool? nsfw = default(bool?), string? name = default(string?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0);

        /// <summary>
        /// Update a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="name">Video name (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> PutVideoWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), VideoPrivacySet? privacy = default(VideoPrivacySet?), string? description = default(string?), string? waitTranscoding = default(string?), string? support = default(string?), bool? nsfw = default(bool?), string? name = default(string?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0);
        /// <summary>
        /// Send chunk for the resumable replacement of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the replacement of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ReplaceVideoSourceResumable(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0);

        /// <summary>
        /// Send chunk for the resumable replacement of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the replacement of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ReplaceVideoSourceResumableWithHttpInfo(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0);
        /// <summary>
        /// Cancel the resumable replacement of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the replacement of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ReplaceVideoSourceResumableCancel(string uploadId, decimal contentLength, int operationIndex = 0);

        /// <summary>
        /// Cancel the resumable replacement of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the replacement of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ReplaceVideoSourceResumableCancelWithHttpInfo(string uploadId, decimal contentLength, int operationIndex = 0);
        /// <summary>
        /// Initialize the resumable replacement of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the replacement of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoReplaceSourceRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ReplaceVideoSourceResumableInit(decimal xUploadContentLength, string xUploadContentType, VideoReplaceSourceRequestResumable? videoReplaceSourceRequestResumable = default(VideoReplaceSourceRequestResumable?), int operationIndex = 0);

        /// <summary>
        /// Initialize the resumable replacement of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the replacement of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoReplaceSourceRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ReplaceVideoSourceResumableInitWithHttpInfo(decimal xUploadContentLength, string xUploadContentType, VideoReplaceSourceRequestResumable? videoReplaceSourceRequestResumable = default(VideoReplaceSourceRequestResumable?), int operationIndex = 0);
        /// <summary>
        /// Request video token
        /// </summary>
        /// <remarks>
        /// Request special tokens that expire quickly to use them in some context (like accessing private static files)
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoTokenResponse</returns>
        VideoTokenResponse RequestVideoToken(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0);

        /// <summary>
        /// Request video token
        /// </summary>
        /// <remarks>
        /// Request special tokens that expire quickly to use them in some context (like accessing private static files)
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoTokenResponse</returns>
        ApiResponse<VideoTokenResponse> RequestVideoTokenWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0);
        /// <summary>
        /// Search videos
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete video information and interact with it. </param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort videos by criteria (prefixing with &#x60;-&#x60; means &#x60;DESC&#x60; order):  (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="startDate">Get videos that are published after this date (optional)</param>
        /// <param name="endDate">Get videos that are published before this date (optional)</param>
        /// <param name="originallyPublishedStartDate">Get videos that are originally published after this date (optional)</param>
        /// <param name="originallyPublishedEndDate">Get videos that are originally published before this date (optional)</param>
        /// <param name="durationMin">Get videos that have this minimum duration (optional)</param>
        /// <param name="durationMax">Get videos that have this maximum duration (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoListResponse</returns>
        VideoListResponse SearchVideos(string search, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), List<string>? uuids = default(List<string>?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), string? host = default(string?), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), DateTime? originallyPublishedStartDate = default(DateTime?), DateTime? originallyPublishedEndDate = default(DateTime?), int? durationMin = default(int?), int? durationMax = default(int?), int operationIndex = 0);

        /// <summary>
        /// Search videos
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete video information and interact with it. </param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort videos by criteria (prefixing with &#x60;-&#x60; means &#x60;DESC&#x60; order):  (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="startDate">Get videos that are published after this date (optional)</param>
        /// <param name="endDate">Get videos that are published before this date (optional)</param>
        /// <param name="originallyPublishedStartDate">Get videos that are originally published after this date (optional)</param>
        /// <param name="originallyPublishedEndDate">Get videos that are originally published before this date (optional)</param>
        /// <param name="durationMin">Get videos that have this minimum duration (optional)</param>
        /// <param name="durationMax">Get videos that have this maximum duration (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoListResponse</returns>
        ApiResponse<VideoListResponse> SearchVideosWithHttpInfo(string search, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), List<string>? uuids = default(List<string>?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), string? host = default(string?), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), DateTime? originallyPublishedStartDate = default(DateTime?), DateTime? originallyPublishedEndDate = default(DateTime?), int? durationMin = default(int?), int? durationMax = default(int?), int operationIndex = 0);
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
        /// <summary>
        /// Upload a video
        /// </summary>
        /// <remarks>
        /// Uses a single request to upload a video.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Video name</param>
        /// <param name="channelId">Channel id that will contain this video</param>
        /// <param name="videofile">Video file</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="generateTranscription">**PeerTube &gt;&#x3D; 6.2** If enabled by the admin, automatically generate a subtitle of the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoUploadResponse</returns>
        VideoUploadResponse UploadLegacy(string name, int channelId, System.IO.Stream videofile, VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), bool? waitTranscoding = default(bool?), bool? generateTranscription = default(bool?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0);

        /// <summary>
        /// Upload a video
        /// </summary>
        /// <remarks>
        /// Uses a single request to upload a video.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Video name</param>
        /// <param name="channelId">Channel id that will contain this video</param>
        /// <param name="videofile">Video file</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="generateTranscription">**PeerTube &gt;&#x3D; 6.2** If enabled by the admin, automatically generate a subtitle of the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoUploadResponse</returns>
        ApiResponse<VideoUploadResponse> UploadLegacyWithHttpInfo(string name, int channelId, System.IO.Stream videofile, VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), bool? waitTranscoding = default(bool?), bool? generateTranscription = default(bool?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0);
        /// <summary>
        /// Send chunk for the resumable upload of a video
        /// </summary>
        /// <remarks>
        /// Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the upload of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoUploadResponse</returns>
        VideoUploadResponse UploadResumable(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0);

        /// <summary>
        /// Send chunk for the resumable upload of a video
        /// </summary>
        /// <remarks>
        /// Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the upload of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoUploadResponse</returns>
        ApiResponse<VideoUploadResponse> UploadResumableWithHttpInfo(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0);
        /// <summary>
        /// Cancel the resumable upload of a video, deleting any data uploaded so far
        /// </summary>
        /// <remarks>
        /// Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the upload of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void UploadResumableCancel(string uploadId, decimal contentLength, int operationIndex = 0);

        /// <summary>
        /// Cancel the resumable upload of a video, deleting any data uploaded so far
        /// </summary>
        /// <remarks>
        /// Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the upload of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UploadResumableCancelWithHttpInfo(string uploadId, decimal contentLength, int operationIndex = 0);
        /// <summary>
        /// Initialize the resumable upload of a video
        /// </summary>
        /// <remarks>
        /// Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the upload of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoUploadRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void UploadResumableInit(decimal xUploadContentLength, string xUploadContentType, VideoUploadRequestResumable? videoUploadRequestResumable = default(VideoUploadRequestResumable?), int operationIndex = 0);

        /// <summary>
        /// Initialize the resumable upload of a video
        /// </summary>
        /// <remarks>
        /// Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the upload of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoUploadRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UploadResumableInitWithHttpInfo(decimal xUploadContentLength, string xUploadContentType, VideoUploadRequestResumable? videoUploadRequestResumable = default(VideoUploadRequestResumable?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IVideoApiAsync : IApiAccessor
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
        /// Notify user is watching a video
        /// </summary>
        /// <remarks>
        /// Call this endpoint regularly (every 5-10 seconds for example) to notify the server the user is watching the video. After a while, PeerTube will increase video&#39;s viewers counter. If the user is authenticated, PeerTube will also store the current player time.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task AddViewAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Notify user is watching a video
        /// </summary>
        /// <remarks>
        /// Call this endpoint regularly (every 5-10 seconds for example) to notify the server the user is watching the video. After a while, PeerTube will increase video&#39;s viewers counter. If the user is authenticated, PeerTube will also store the current player time.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> AddViewWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create a studio task
        /// </summary>
        /// <remarks>
        /// Create a task to edit a video  (cut, add intro/outro etc)
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1VideosIdStudioEditPostAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a studio task
        /// </summary>
        /// <remarks>
        /// Create a task to edit a video  (cut, add intro/outro etc)
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1VideosIdStudioEditPostWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Set watching progress of a video
        /// </summary>
        /// <remarks>
        /// This endpoint has been deprecated. Use &#x60;/videos/{id}/views&#x60; instead
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        [Obsolete]
        System.Threading.Tasks.Task ApiV1VideosIdWatchingPutAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Set watching progress of a video
        /// </summary>
        /// <remarks>
        /// This endpoint has been deprecated. Use &#x60;/videos/{id}/views&#x60; instead
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        [Obsolete]
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1VideosIdWatchingPutWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DelVideoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DelVideoWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete video source file
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteVideoSourceFileAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete video source file
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteVideoSourceFileWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List videos of an account
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoListResponse</returns>
        System.Threading.Tasks.Task<VideoListResponse> GetAccountVideosAsync(string name, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List videos of an account
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoListResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoListResponse>> GetAccountVideosWithHttpInfoAsync(string name, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List available video categories
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;string&gt;</returns>
        System.Threading.Tasks.Task<List<string>> GetCategoriesAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List available video categories
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<string>>> GetCategoriesWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List available video languages
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;string&gt;</returns>
        System.Threading.Tasks.Task<List<string>> GetLanguagesAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List available video languages
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<string>>> GetLanguagesWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List available video licences
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;string&gt;</returns>
        System.Threading.Tasks.Task<List<string>> GetLicencesAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List available video licences
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<string>>> GetLicencesWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
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
        /// Get a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoDetails</returns>
        System.Threading.Tasks.Task<VideoDetails> GetVideoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoDetails)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoDetails>> GetVideoWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List videos of a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoListResponse</returns>
        System.Threading.Tasks.Task<VideoListResponse> GetVideoChannelVideosAsync(string channelHandle, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List videos of a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoListResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoListResponse>> GetVideoChannelVideosWithHttpInfoAsync(string channelHandle, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get complete video description
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> GetVideoDescAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get complete video description
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (string)</returns>
        System.Threading.Tasks.Task<ApiResponse<string>> GetVideoDescWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List available video privacy policies
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;string&gt;</returns>
        System.Threading.Tasks.Task<List<string>> GetVideoPrivacyPoliciesAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List available video privacy policies
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<string>>> GetVideoPrivacyPoliciesWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get video source file metadata
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoSource</returns>
        System.Threading.Tasks.Task<VideoSource> GetVideoSourceAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get video source file metadata
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoSource)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoSource>> GetVideoSourceWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List videos
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoListResponse</returns>
        System.Threading.Tasks.Task<VideoListResponse> GetVideosAsync(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List videos
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoListResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoListResponse>> GetVideosWithHttpInfoAsync(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List storyboards of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ListVideoStoryboards200Response</returns>
        System.Threading.Tasks.Task<ListVideoStoryboards200Response> ListVideoStoryboardsAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List storyboards of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ListVideoStoryboards200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ListVideoStoryboards200Response>> ListVideoStoryboardsWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="name">Video name (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task PutVideoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), VideoPrivacySet? privacy = default(VideoPrivacySet?), string? description = default(string?), string? waitTranscoding = default(string?), string? support = default(string?), bool? nsfw = default(bool?), string? name = default(string?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update a video
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="name">Video name (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> PutVideoWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), VideoPrivacySet? privacy = default(VideoPrivacySet?), string? description = default(string?), string? waitTranscoding = default(string?), string? support = default(string?), bool? nsfw = default(bool?), string? name = default(string?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Send chunk for the resumable replacement of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the replacement of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ReplaceVideoSourceResumableAsync(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Send chunk for the resumable replacement of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the replacement of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ReplaceVideoSourceResumableWithHttpInfoAsync(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Cancel the resumable replacement of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the replacement of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ReplaceVideoSourceResumableCancelAsync(string uploadId, decimal contentLength, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Cancel the resumable replacement of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the replacement of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ReplaceVideoSourceResumableCancelWithHttpInfoAsync(string uploadId, decimal contentLength, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Initialize the resumable replacement of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the replacement of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoReplaceSourceRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ReplaceVideoSourceResumableInitAsync(decimal xUploadContentLength, string xUploadContentType, VideoReplaceSourceRequestResumable? videoReplaceSourceRequestResumable = default(VideoReplaceSourceRequestResumable?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Initialize the resumable replacement of a video
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the replacement of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoReplaceSourceRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ReplaceVideoSourceResumableInitWithHttpInfoAsync(decimal xUploadContentLength, string xUploadContentType, VideoReplaceSourceRequestResumable? videoReplaceSourceRequestResumable = default(VideoReplaceSourceRequestResumable?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Request video token
        /// </summary>
        /// <remarks>
        /// Request special tokens that expire quickly to use them in some context (like accessing private static files)
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoTokenResponse</returns>
        System.Threading.Tasks.Task<VideoTokenResponse> RequestVideoTokenAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Request video token
        /// </summary>
        /// <remarks>
        /// Request special tokens that expire quickly to use them in some context (like accessing private static files)
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoTokenResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoTokenResponse>> RequestVideoTokenWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Search videos
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete video information and interact with it. </param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort videos by criteria (prefixing with &#x60;-&#x60; means &#x60;DESC&#x60; order):  (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="startDate">Get videos that are published after this date (optional)</param>
        /// <param name="endDate">Get videos that are published before this date (optional)</param>
        /// <param name="originallyPublishedStartDate">Get videos that are originally published after this date (optional)</param>
        /// <param name="originallyPublishedEndDate">Get videos that are originally published before this date (optional)</param>
        /// <param name="durationMin">Get videos that have this minimum duration (optional)</param>
        /// <param name="durationMax">Get videos that have this maximum duration (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoListResponse</returns>
        System.Threading.Tasks.Task<VideoListResponse> SearchVideosAsync(string search, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), List<string>? uuids = default(List<string>?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), string? host = default(string?), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), DateTime? originallyPublishedStartDate = default(DateTime?), DateTime? originallyPublishedEndDate = default(DateTime?), int? durationMin = default(int?), int? durationMax = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Search videos
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete video information and interact with it. </param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort videos by criteria (prefixing with &#x60;-&#x60; means &#x60;DESC&#x60; order):  (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="startDate">Get videos that are published after this date (optional)</param>
        /// <param name="endDate">Get videos that are published before this date (optional)</param>
        /// <param name="originallyPublishedStartDate">Get videos that are originally published after this date (optional)</param>
        /// <param name="originallyPublishedEndDate">Get videos that are originally published before this date (optional)</param>
        /// <param name="durationMin">Get videos that have this minimum duration (optional)</param>
        /// <param name="durationMax">Get videos that have this maximum duration (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoListResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoListResponse>> SearchVideosWithHttpInfoAsync(string search, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), List<string>? uuids = default(List<string>?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), string? host = default(string?), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), DateTime? originallyPublishedStartDate = default(DateTime?), DateTime? originallyPublishedEndDate = default(DateTime?), int? durationMin = default(int?), int? durationMax = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
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
        /// <summary>
        /// Upload a video
        /// </summary>
        /// <remarks>
        /// Uses a single request to upload a video.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Video name</param>
        /// <param name="channelId">Channel id that will contain this video</param>
        /// <param name="videofile">Video file</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="generateTranscription">**PeerTube &gt;&#x3D; 6.2** If enabled by the admin, automatically generate a subtitle of the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoUploadResponse</returns>
        System.Threading.Tasks.Task<VideoUploadResponse> UploadLegacyAsync(string name, int channelId, System.IO.Stream videofile, VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), bool? waitTranscoding = default(bool?), bool? generateTranscription = default(bool?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Upload a video
        /// </summary>
        /// <remarks>
        /// Uses a single request to upload a video.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Video name</param>
        /// <param name="channelId">Channel id that will contain this video</param>
        /// <param name="videofile">Video file</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="generateTranscription">**PeerTube &gt;&#x3D; 6.2** If enabled by the admin, automatically generate a subtitle of the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoUploadResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoUploadResponse>> UploadLegacyWithHttpInfoAsync(string name, int channelId, System.IO.Stream videofile, VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), bool? waitTranscoding = default(bool?), bool? generateTranscription = default(bool?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Send chunk for the resumable upload of a video
        /// </summary>
        /// <remarks>
        /// Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the upload of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoUploadResponse</returns>
        System.Threading.Tasks.Task<VideoUploadResponse> UploadResumableAsync(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Send chunk for the resumable upload of a video
        /// </summary>
        /// <remarks>
        /// Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the upload of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoUploadResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoUploadResponse>> UploadResumableWithHttpInfoAsync(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Cancel the resumable upload of a video, deleting any data uploaded so far
        /// </summary>
        /// <remarks>
        /// Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the upload of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UploadResumableCancelAsync(string uploadId, decimal contentLength, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Cancel the resumable upload of a video, deleting any data uploaded so far
        /// </summary>
        /// <remarks>
        /// Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the upload of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> UploadResumableCancelWithHttpInfoAsync(string uploadId, decimal contentLength, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Initialize the resumable upload of a video
        /// </summary>
        /// <remarks>
        /// Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the upload of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoUploadRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UploadResumableInitAsync(decimal xUploadContentLength, string xUploadContentType, VideoUploadRequestResumable? videoUploadRequestResumable = default(VideoUploadRequestResumable?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Initialize the resumable upload of a video
        /// </summary>
        /// <remarks>
        /// Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the upload of a video
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoUploadRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> UploadResumableInitWithHttpInfoAsync(decimal xUploadContentLength, string xUploadContentType, VideoUploadRequestResumable? videoUploadRequestResumable = default(VideoUploadRequestResumable?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IVideoApi : IVideoApiSync, IVideoApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class VideoApi : IVideoApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoApi"/> class.
        /// </summary>
        /// <returns></returns>
        public VideoApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoApi"/> class.
        /// </summary>
        /// <returns></returns>
        public VideoApi(string basePath)
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
        /// Initializes a new instance of the <see cref="VideoApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public VideoApi(PeerTubeApiClient.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="VideoApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public VideoApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'name' when calling VideoApi->AddLive");
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

            localVarRequestOptions.Operation = "VideoApi.AddLive";
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'name' when calling VideoApi->AddLive");
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

            localVarRequestOptions.Operation = "VideoApi.AddLive";
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
        /// Notify user is watching a video Call this endpoint regularly (every 5-10 seconds for example) to notify the server the user is watching the video. After a while, PeerTube will increase video&#39;s viewers counter. If the user is authenticated, PeerTube will also store the current player time.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void AddView(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0)
        {
            AddViewWithHttpInfo(id, userViewingVideo);
        }

        /// <summary>
        /// Notify user is watching a video Call this endpoint regularly (every 5-10 seconds for example) to notify the server the user is watching the video. After a while, PeerTube will increase video&#39;s viewers counter. If the user is authenticated, PeerTube will also store the current player time.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> AddViewWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->AddView");
            }

            // verify the required parameter 'userViewingVideo' is set
            if (userViewingVideo == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'userViewingVideo' when calling VideoApi->AddView");
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
            localVarRequestOptions.Data = userViewingVideo;

            localVarRequestOptions.Operation = "VideoApi.AddView";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/api/v1/videos/{id}/views", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("AddView", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Notify user is watching a video Call this endpoint regularly (every 5-10 seconds for example) to notify the server the user is watching the video. After a while, PeerTube will increase video&#39;s viewers counter. If the user is authenticated, PeerTube will also store the current player time.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task AddViewAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await AddViewWithHttpInfoAsync(id, userViewingVideo, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Notify user is watching a video Call this endpoint regularly (every 5-10 seconds for example) to notify the server the user is watching the video. After a while, PeerTube will increase video&#39;s viewers counter. If the user is authenticated, PeerTube will also store the current player time.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> AddViewWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->AddView");
            }

            // verify the required parameter 'userViewingVideo' is set
            if (userViewingVideo == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'userViewingVideo' when calling VideoApi->AddView");
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
            localVarRequestOptions.Data = userViewingVideo;

            localVarRequestOptions.Operation = "VideoApi.AddView";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/videos/{id}/views", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("AddView", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a studio task Create a task to edit a video  (cut, add intro/outro etc)
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1VideosIdStudioEditPost(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0)
        {
            ApiV1VideosIdStudioEditPostWithHttpInfo(id);
        }

        /// <summary>
        /// Create a studio task Create a task to edit a video  (cut, add intro/outro etc)
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1VideosIdStudioEditPostWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->ApiV1VideosIdStudioEditPost");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/x-www-form-urlencoded"
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

            localVarRequestOptions.Operation = "VideoApi.ApiV1VideosIdStudioEditPost";
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
            var localVarResponse = this.Client.Post<Object>("/api/v1/videos/{id}/studio/edit", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdStudioEditPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a studio task Create a task to edit a video  (cut, add intro/outro etc)
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1VideosIdStudioEditPostAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1VideosIdStudioEditPostWithHttpInfoAsync(id, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a studio task Create a task to edit a video  (cut, add intro/outro etc)
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1VideosIdStudioEditPostWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->ApiV1VideosIdStudioEditPost");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/x-www-form-urlencoded"
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

            localVarRequestOptions.Operation = "VideoApi.ApiV1VideosIdStudioEditPost";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/videos/{id}/studio/edit", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdStudioEditPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Set watching progress of a video This endpoint has been deprecated. Use &#x60;/videos/{id}/views&#x60; instead
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        [Obsolete]
        public void ApiV1VideosIdWatchingPut(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0)
        {
            ApiV1VideosIdWatchingPutWithHttpInfo(id, userViewingVideo);
        }

        /// <summary>
        /// Set watching progress of a video This endpoint has been deprecated. Use &#x60;/videos/{id}/views&#x60; instead
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        [Obsolete]
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1VideosIdWatchingPutWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->ApiV1VideosIdWatchingPut");
            }

            // verify the required parameter 'userViewingVideo' is set
            if (userViewingVideo == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'userViewingVideo' when calling VideoApi->ApiV1VideosIdWatchingPut");
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
            localVarRequestOptions.Data = userViewingVideo;

            localVarRequestOptions.Operation = "VideoApi.ApiV1VideosIdWatchingPut";
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
            var localVarResponse = this.Client.Put<Object>("/api/v1/videos/{id}/watching", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdWatchingPut", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Set watching progress of a video This endpoint has been deprecated. Use &#x60;/videos/{id}/views&#x60; instead
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        [Obsolete]
        public async System.Threading.Tasks.Task ApiV1VideosIdWatchingPutAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1VideosIdWatchingPutWithHttpInfoAsync(id, userViewingVideo, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Set watching progress of a video This endpoint has been deprecated. Use &#x60;/videos/{id}/views&#x60; instead
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="userViewingVideo"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        [Obsolete]
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1VideosIdWatchingPutWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, UserViewingVideo userViewingVideo, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->ApiV1VideosIdWatchingPut");
            }

            // verify the required parameter 'userViewingVideo' is set
            if (userViewingVideo == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'userViewingVideo' when calling VideoApi->ApiV1VideosIdWatchingPut");
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
            localVarRequestOptions.Data = userViewingVideo;

            localVarRequestOptions.Operation = "VideoApi.ApiV1VideosIdWatchingPut";
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
            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/api/v1/videos/{id}/watching", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideosIdWatchingPut", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void DelVideo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0)
        {
            DelVideoWithHttpInfo(id);
        }

        /// <summary>
        /// Delete a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> DelVideoWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->DelVideo");
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

            localVarRequestOptions.Operation = "VideoApi.DelVideo";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/videos/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DelVideo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DelVideoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await DelVideoWithHttpInfoAsync(id, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> DelVideoWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->DelVideo");
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

            localVarRequestOptions.Operation = "VideoApi.DelVideo";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/videos/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DelVideo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete video source file 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void DeleteVideoSourceFile(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0)
        {
            DeleteVideoSourceFileWithHttpInfo(id);
        }

        /// <summary>
        /// Delete video source file 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> DeleteVideoSourceFileWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->DeleteVideoSourceFile");
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

            localVarRequestOptions.Operation = "VideoApi.DeleteVideoSourceFile";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/videos/{id}/source/file", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteVideoSourceFile", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete video source file 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteVideoSourceFileAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await DeleteVideoSourceFileWithHttpInfoAsync(id, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete video source file 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> DeleteVideoSourceFileWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->DeleteVideoSourceFile");
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

            localVarRequestOptions.Operation = "VideoApi.DeleteVideoSourceFile";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/videos/{id}/source/file", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteVideoSourceFile", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List videos of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoListResponse</returns>
        public VideoListResponse GetAccountVideos(string name, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoListResponse> localVarResponse = GetAccountVideosWithHttpInfo(name, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List videos of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoListResponse</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoListResponse> GetAccountVideosWithHttpInfo(string name, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'name' when calling VideoApi->GetAccountVideos");
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

            localVarRequestOptions.PathParameters.Add("name", PeerTubeApiClient.Client.ClientUtils.ParameterToString(name)); // path parameter
            if (categoryOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "categoryOneOf", categoryOneOf));
            }
            if (isLive != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLive", isLive));
            }
            if (tagsOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsOneOf", tagsOneOf));
            }
            if (tagsAllOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsAllOf", tagsAllOf));
            }
            if (licenceOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "licenceOneOf", licenceOneOf));
            }
            if (languageOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "languageOneOf", languageOneOf));
            }
            if (autoTagOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "autoTagOneOf", autoTagOneOf));
            }
            if (nsfw != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "nsfw", nsfw));
            }
            if (isLocal != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLocal", isLocal));
            }
            if (include != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "include", include));
            }
            if (privacyOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "privacyOneOf", privacyOneOf));
            }
            if (hasHLSFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasHLSFiles", hasHLSFiles));
            }
            if (hasWebVideoFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasWebVideoFiles", hasWebVideoFiles));
            }
            if (skipCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "skipCount", skipCount));
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
            if (excludeAlreadyWatched != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "excludeAlreadyWatched", excludeAlreadyWatched));
            }

            localVarRequestOptions.Operation = "VideoApi.GetAccountVideos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<VideoListResponse>("/api/v1/accounts/{name}/videos", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAccountVideos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List videos of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoListResponse</returns>
        public async System.Threading.Tasks.Task<VideoListResponse> GetAccountVideosAsync(string name, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoListResponse> localVarResponse = await GetAccountVideosWithHttpInfoAsync(name, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List videos of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoListResponse)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoListResponse>> GetAccountVideosWithHttpInfoAsync(string name, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'name' when calling VideoApi->GetAccountVideos");
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

            localVarRequestOptions.PathParameters.Add("name", PeerTubeApiClient.Client.ClientUtils.ParameterToString(name)); // path parameter
            if (categoryOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "categoryOneOf", categoryOneOf));
            }
            if (isLive != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLive", isLive));
            }
            if (tagsOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsOneOf", tagsOneOf));
            }
            if (tagsAllOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsAllOf", tagsAllOf));
            }
            if (licenceOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "licenceOneOf", licenceOneOf));
            }
            if (languageOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "languageOneOf", languageOneOf));
            }
            if (autoTagOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "autoTagOneOf", autoTagOneOf));
            }
            if (nsfw != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "nsfw", nsfw));
            }
            if (isLocal != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLocal", isLocal));
            }
            if (include != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "include", include));
            }
            if (privacyOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "privacyOneOf", privacyOneOf));
            }
            if (hasHLSFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasHLSFiles", hasHLSFiles));
            }
            if (hasWebVideoFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasWebVideoFiles", hasWebVideoFiles));
            }
            if (skipCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "skipCount", skipCount));
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
            if (excludeAlreadyWatched != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "excludeAlreadyWatched", excludeAlreadyWatched));
            }

            localVarRequestOptions.Operation = "VideoApi.GetAccountVideos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoListResponse>("/api/v1/accounts/{name}/videos", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAccountVideos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List available video categories 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;string&gt;</returns>
        public List<string> GetCategories(int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<List<string>> localVarResponse = GetCategoriesWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// List available video categories 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        public PeerTubeApiClient.Client.ApiResponse<List<string>> GetCategoriesWithHttpInfo(int operationIndex = 0)
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


            localVarRequestOptions.Operation = "VideoApi.GetCategories";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<string>>("/api/v1/videos/categories", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCategories", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List available video categories 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;string&gt;</returns>
        public async System.Threading.Tasks.Task<List<string>> GetCategoriesAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<List<string>> localVarResponse = await GetCategoriesWithHttpInfoAsync(operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List available video categories 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<List<string>>> GetCategoriesWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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


            localVarRequestOptions.Operation = "VideoApi.GetCategories";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<string>>("/api/v1/videos/categories", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCategories", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List available video languages 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;string&gt;</returns>
        public List<string> GetLanguages(int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<List<string>> localVarResponse = GetLanguagesWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// List available video languages 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        public PeerTubeApiClient.Client.ApiResponse<List<string>> GetLanguagesWithHttpInfo(int operationIndex = 0)
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


            localVarRequestOptions.Operation = "VideoApi.GetLanguages";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<string>>("/api/v1/videos/languages", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLanguages", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List available video languages 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;string&gt;</returns>
        public async System.Threading.Tasks.Task<List<string>> GetLanguagesAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<List<string>> localVarResponse = await GetLanguagesWithHttpInfoAsync(operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List available video languages 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<List<string>>> GetLanguagesWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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


            localVarRequestOptions.Operation = "VideoApi.GetLanguages";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<string>>("/api/v1/videos/languages", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLanguages", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List available video licences 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;string&gt;</returns>
        public List<string> GetLicences(int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<List<string>> localVarResponse = GetLicencesWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// List available video licences 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        public PeerTubeApiClient.Client.ApiResponse<List<string>> GetLicencesWithHttpInfo(int operationIndex = 0)
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


            localVarRequestOptions.Operation = "VideoApi.GetLicences";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<string>>("/api/v1/videos/licences", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLicences", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List available video licences 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;string&gt;</returns>
        public async System.Threading.Tasks.Task<List<string>> GetLicencesAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<List<string>> localVarResponse = await GetLicencesWithHttpInfoAsync(operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List available video licences 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<List<string>>> GetLicencesWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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


            localVarRequestOptions.Operation = "VideoApi.GetLicences";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<string>>("/api/v1/videos/licences", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLicences", localVarResponse);
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->GetLiveId");
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

            localVarRequestOptions.Operation = "VideoApi.GetLiveId";
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->GetLiveId");
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

            localVarRequestOptions.Operation = "VideoApi.GetLiveId";
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
        /// Get a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoDetails</returns>
        public VideoDetails GetVideo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoDetails> localVarResponse = GetVideoWithHttpInfo(id, xPeertubeVideoPassword);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoDetails</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoDetails> GetVideoWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->GetVideo");
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

            localVarRequestOptions.Operation = "VideoApi.GetVideo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<VideoDetails>("/api/v1/videos/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoDetails</returns>
        public async System.Threading.Tasks.Task<VideoDetails> GetVideoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoDetails> localVarResponse = await GetVideoWithHttpInfoAsync(id, xPeertubeVideoPassword, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoDetails)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoDetails>> GetVideoWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->GetVideo");
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

            localVarRequestOptions.Operation = "VideoApi.GetVideo";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoDetails>("/api/v1/videos/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List videos of a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoListResponse</returns>
        public VideoListResponse GetVideoChannelVideos(string channelHandle, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoListResponse> localVarResponse = GetVideoChannelVideosWithHttpInfo(channelHandle, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List videos of a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoListResponse</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoListResponse> GetVideoChannelVideosWithHttpInfo(string channelHandle, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0)
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoApi->GetVideoChannelVideos");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter
            if (categoryOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "categoryOneOf", categoryOneOf));
            }
            if (isLive != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLive", isLive));
            }
            if (tagsOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsOneOf", tagsOneOf));
            }
            if (tagsAllOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsAllOf", tagsAllOf));
            }
            if (licenceOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "licenceOneOf", licenceOneOf));
            }
            if (languageOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "languageOneOf", languageOneOf));
            }
            if (autoTagOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "autoTagOneOf", autoTagOneOf));
            }
            if (nsfw != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "nsfw", nsfw));
            }
            if (isLocal != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLocal", isLocal));
            }
            if (include != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "include", include));
            }
            if (privacyOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "privacyOneOf", privacyOneOf));
            }
            if (hasHLSFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasHLSFiles", hasHLSFiles));
            }
            if (hasWebVideoFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasWebVideoFiles", hasWebVideoFiles));
            }
            if (skipCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "skipCount", skipCount));
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
            if (excludeAlreadyWatched != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "excludeAlreadyWatched", excludeAlreadyWatched));
            }

            localVarRequestOptions.Operation = "VideoApi.GetVideoChannelVideos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<VideoListResponse>("/api/v1/video-channels/{channelHandle}/videos", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoChannelVideos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List videos of a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoListResponse</returns>
        public async System.Threading.Tasks.Task<VideoListResponse> GetVideoChannelVideosAsync(string channelHandle, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoListResponse> localVarResponse = await GetVideoChannelVideosWithHttpInfoAsync(channelHandle, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List videos of a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoListResponse)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoListResponse>> GetVideoChannelVideosWithHttpInfoAsync(string channelHandle, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoApi->GetVideoChannelVideos");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter
            if (categoryOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "categoryOneOf", categoryOneOf));
            }
            if (isLive != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLive", isLive));
            }
            if (tagsOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsOneOf", tagsOneOf));
            }
            if (tagsAllOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsAllOf", tagsAllOf));
            }
            if (licenceOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "licenceOneOf", licenceOneOf));
            }
            if (languageOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "languageOneOf", languageOneOf));
            }
            if (autoTagOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "autoTagOneOf", autoTagOneOf));
            }
            if (nsfw != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "nsfw", nsfw));
            }
            if (isLocal != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLocal", isLocal));
            }
            if (include != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "include", include));
            }
            if (privacyOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "privacyOneOf", privacyOneOf));
            }
            if (hasHLSFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasHLSFiles", hasHLSFiles));
            }
            if (hasWebVideoFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasWebVideoFiles", hasWebVideoFiles));
            }
            if (skipCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "skipCount", skipCount));
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
            if (excludeAlreadyWatched != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "excludeAlreadyWatched", excludeAlreadyWatched));
            }

            localVarRequestOptions.Operation = "VideoApi.GetVideoChannelVideos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoListResponse>("/api/v1/video-channels/{channelHandle}/videos", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoChannelVideos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get complete video description 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>string</returns>
        public string GetVideoDesc(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<string> localVarResponse = GetVideoDescWithHttpInfo(id, xPeertubeVideoPassword);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get complete video description 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of string</returns>
        public PeerTubeApiClient.Client.ApiResponse<string> GetVideoDescWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->GetVideoDesc");
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

            localVarRequestOptions.Operation = "VideoApi.GetVideoDesc";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<string>("/api/v1/videos/{id}/description", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoDesc", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get complete video description 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of string</returns>
        public async System.Threading.Tasks.Task<string> GetVideoDescAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<string> localVarResponse = await GetVideoDescWithHttpInfoAsync(id, xPeertubeVideoPassword, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get complete video description 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (string)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<string>> GetVideoDescWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->GetVideoDesc");
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

            localVarRequestOptions.Operation = "VideoApi.GetVideoDesc";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<string>("/api/v1/videos/{id}/description", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoDesc", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List available video privacy policies 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;string&gt;</returns>
        public List<string> GetVideoPrivacyPolicies(int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<List<string>> localVarResponse = GetVideoPrivacyPoliciesWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// List available video privacy policies 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        public PeerTubeApiClient.Client.ApiResponse<List<string>> GetVideoPrivacyPoliciesWithHttpInfo(int operationIndex = 0)
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


            localVarRequestOptions.Operation = "VideoApi.GetVideoPrivacyPolicies";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<string>>("/api/v1/videos/privacies", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoPrivacyPolicies", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List available video privacy policies 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;string&gt;</returns>
        public async System.Threading.Tasks.Task<List<string>> GetVideoPrivacyPoliciesAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<List<string>> localVarResponse = await GetVideoPrivacyPoliciesWithHttpInfoAsync(operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List available video privacy policies 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<List<string>>> GetVideoPrivacyPoliciesWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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


            localVarRequestOptions.Operation = "VideoApi.GetVideoPrivacyPolicies";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<string>>("/api/v1/videos/privacies", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoPrivacyPolicies", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get video source file metadata 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoSource</returns>
        public VideoSource GetVideoSource(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoSource> localVarResponse = GetVideoSourceWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get video source file metadata 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoSource</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoSource> GetVideoSourceWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->GetVideoSource");
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

            localVarRequestOptions.Operation = "VideoApi.GetVideoSource";
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
            var localVarResponse = this.Client.Get<VideoSource>("/api/v1/videos/{id}/source", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoSource", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get video source file metadata 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoSource</returns>
        public async System.Threading.Tasks.Task<VideoSource> GetVideoSourceAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoSource> localVarResponse = await GetVideoSourceWithHttpInfoAsync(id, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get video source file metadata 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoSource)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoSource>> GetVideoSourceWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->GetVideoSource");
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

            localVarRequestOptions.Operation = "VideoApi.GetVideoSource";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoSource>("/api/v1/videos/{id}/source", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoSource", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List videos 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoListResponse</returns>
        public VideoListResponse GetVideos(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoListResponse> localVarResponse = GetVideosWithHttpInfo(categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List videos 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoListResponse</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoListResponse> GetVideosWithHttpInfo(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0)
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

            if (categoryOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "categoryOneOf", categoryOneOf));
            }
            if (isLive != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLive", isLive));
            }
            if (tagsOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsOneOf", tagsOneOf));
            }
            if (tagsAllOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsAllOf", tagsAllOf));
            }
            if (licenceOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "licenceOneOf", licenceOneOf));
            }
            if (languageOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "languageOneOf", languageOneOf));
            }
            if (autoTagOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "autoTagOneOf", autoTagOneOf));
            }
            if (nsfw != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "nsfw", nsfw));
            }
            if (isLocal != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLocal", isLocal));
            }
            if (include != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "include", include));
            }
            if (privacyOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "privacyOneOf", privacyOneOf));
            }
            if (hasHLSFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasHLSFiles", hasHLSFiles));
            }
            if (hasWebVideoFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasWebVideoFiles", hasWebVideoFiles));
            }
            if (skipCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "skipCount", skipCount));
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
            if (excludeAlreadyWatched != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "excludeAlreadyWatched", excludeAlreadyWatched));
            }

            localVarRequestOptions.Operation = "VideoApi.GetVideos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<VideoListResponse>("/api/v1/videos", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List videos 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoListResponse</returns>
        public async System.Threading.Tasks.Task<VideoListResponse> GetVideosAsync(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoListResponse> localVarResponse = await GetVideosWithHttpInfoAsync(categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List videos 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort"> (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoListResponse)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoListResponse>> GetVideosWithHttpInfoAsync(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (categoryOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "categoryOneOf", categoryOneOf));
            }
            if (isLive != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLive", isLive));
            }
            if (tagsOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsOneOf", tagsOneOf));
            }
            if (tagsAllOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsAllOf", tagsAllOf));
            }
            if (licenceOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "licenceOneOf", licenceOneOf));
            }
            if (languageOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "languageOneOf", languageOneOf));
            }
            if (autoTagOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "autoTagOneOf", autoTagOneOf));
            }
            if (nsfw != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "nsfw", nsfw));
            }
            if (isLocal != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLocal", isLocal));
            }
            if (include != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "include", include));
            }
            if (privacyOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "privacyOneOf", privacyOneOf));
            }
            if (hasHLSFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasHLSFiles", hasHLSFiles));
            }
            if (hasWebVideoFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasWebVideoFiles", hasWebVideoFiles));
            }
            if (skipCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "skipCount", skipCount));
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
            if (excludeAlreadyWatched != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "excludeAlreadyWatched", excludeAlreadyWatched));
            }

            localVarRequestOptions.Operation = "VideoApi.GetVideos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoListResponse>("/api/v1/videos", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List storyboards of a video **PeerTube &gt;&#x3D; 6.0**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ListVideoStoryboards200Response</returns>
        public ListVideoStoryboards200Response ListVideoStoryboards(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ListVideoStoryboards200Response> localVarResponse = ListVideoStoryboardsWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List storyboards of a video **PeerTube &gt;&#x3D; 6.0**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ListVideoStoryboards200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ListVideoStoryboards200Response> ListVideoStoryboardsWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->ListVideoStoryboards");
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

            localVarRequestOptions.Operation = "VideoApi.ListVideoStoryboards";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<ListVideoStoryboards200Response>("/api/v1/videos/{id}/storyboards", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListVideoStoryboards", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List storyboards of a video **PeerTube &gt;&#x3D; 6.0**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ListVideoStoryboards200Response</returns>
        public async System.Threading.Tasks.Task<ListVideoStoryboards200Response> ListVideoStoryboardsAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ListVideoStoryboards200Response> localVarResponse = await ListVideoStoryboardsWithHttpInfoAsync(id, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List storyboards of a video **PeerTube &gt;&#x3D; 6.0**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ListVideoStoryboards200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ListVideoStoryboards200Response>> ListVideoStoryboardsWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->ListVideoStoryboards");
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

            localVarRequestOptions.Operation = "VideoApi.ListVideoStoryboards";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ListVideoStoryboards200Response>("/api/v1/videos/{id}/storyboards", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListVideoStoryboards", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="name">Video name (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void PutVideo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), VideoPrivacySet? privacy = default(VideoPrivacySet?), string? description = default(string?), string? waitTranscoding = default(string?), string? support = default(string?), bool? nsfw = default(bool?), string? name = default(string?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0)
        {
            PutVideoWithHttpInfo(id, thumbnailfile, previewfile, category, licence, language, privacy, description, waitTranscoding, support, nsfw, name, tags, commentsEnabled, commentsPolicy, downloadEnabled, originallyPublishedAt, scheduleUpdate, videoPasswords);
        }

        /// <summary>
        /// Update a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="name">Video name (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> PutVideoWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), VideoPrivacySet? privacy = default(VideoPrivacySet?), string? description = default(string?), string? waitTranscoding = default(string?), string? support = default(string?), bool? nsfw = default(bool?), string? name = default(string?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->PutVideo");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "multipart/form-data"
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
            if (thumbnailfile != null)
            {
                localVarRequestOptions.FileParameters.Add("thumbnailfile", thumbnailfile);
            }
            if (previewfile != null)
            {
                localVarRequestOptions.FileParameters.Add("previewfile", previewfile);
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
            if (privacy != null)
            {
                localVarRequestOptions.FormParameters.Add("privacy", PeerTubeApiClient.Client.ClientUtils.Serialize(privacy)); // form parameter
            }
            if (description != null)
            {
                localVarRequestOptions.FormParameters.Add("description", PeerTubeApiClient.Client.ClientUtils.ParameterToString(description)); // form parameter
            }
            if (waitTranscoding != null)
            {
                localVarRequestOptions.FormParameters.Add("waitTranscoding", PeerTubeApiClient.Client.ClientUtils.ParameterToString(waitTranscoding)); // form parameter
            }
            if (support != null)
            {
                localVarRequestOptions.FormParameters.Add("support", PeerTubeApiClient.Client.ClientUtils.ParameterToString(support)); // form parameter
            }
            if (nsfw != null)
            {
                localVarRequestOptions.FormParameters.Add("nsfw", PeerTubeApiClient.Client.ClientUtils.ParameterToString(nsfw)); // form parameter
            }
            if (name != null)
            {
                localVarRequestOptions.FormParameters.Add("name", PeerTubeApiClient.Client.ClientUtils.ParameterToString(name)); // form parameter
            }
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
            if (originallyPublishedAt != null)
            {
                localVarRequestOptions.FormParameters.Add("originallyPublishedAt", PeerTubeApiClient.Client.ClientUtils.ParameterToString(originallyPublishedAt)); // form parameter
            }
            if (scheduleUpdate != null)
            {
                localVarRequestOptions.FormParameters.Add("scheduleUpdate", PeerTubeApiClient.Client.ClientUtils.Serialize(scheduleUpdate)); // form parameter
            }
            if (videoPasswords != null)
            {
                localVarRequestOptions.FormParameters.Add("videoPasswords", PeerTubeApiClient.Client.ClientUtils.Serialize(videoPasswords)); // form parameter
            }

            localVarRequestOptions.Operation = "VideoApi.PutVideo";
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
            var localVarResponse = this.Client.Put<Object>("/api/v1/videos/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PutVideo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="name">Video name (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task PutVideoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), VideoPrivacySet? privacy = default(VideoPrivacySet?), string? description = default(string?), string? waitTranscoding = default(string?), string? support = default(string?), bool? nsfw = default(bool?), string? name = default(string?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await PutVideoWithHttpInfoAsync(id, thumbnailfile, previewfile, category, licence, language, privacy, description, waitTranscoding, support, nsfw, name, tags, commentsEnabled, commentsPolicy, downloadEnabled, originallyPublishedAt, scheduleUpdate, videoPasswords, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a video 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="name">Video name (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> PutVideoWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), VideoPrivacySet? privacy = default(VideoPrivacySet?), string? description = default(string?), string? waitTranscoding = default(string?), string? support = default(string?), bool? nsfw = default(bool?), string? name = default(string?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->PutVideo");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "multipart/form-data"
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
            if (thumbnailfile != null)
            {
                localVarRequestOptions.FileParameters.Add("thumbnailfile", thumbnailfile);
            }
            if (previewfile != null)
            {
                localVarRequestOptions.FileParameters.Add("previewfile", previewfile);
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
            if (privacy != null)
            {
                localVarRequestOptions.FormParameters.Add("privacy", PeerTubeApiClient.Client.ClientUtils.Serialize(privacy)); // form parameter
            }
            if (description != null)
            {
                localVarRequestOptions.FormParameters.Add("description", PeerTubeApiClient.Client.ClientUtils.ParameterToString(description)); // form parameter
            }
            if (waitTranscoding != null)
            {
                localVarRequestOptions.FormParameters.Add("waitTranscoding", PeerTubeApiClient.Client.ClientUtils.ParameterToString(waitTranscoding)); // form parameter
            }
            if (support != null)
            {
                localVarRequestOptions.FormParameters.Add("support", PeerTubeApiClient.Client.ClientUtils.ParameterToString(support)); // form parameter
            }
            if (nsfw != null)
            {
                localVarRequestOptions.FormParameters.Add("nsfw", PeerTubeApiClient.Client.ClientUtils.ParameterToString(nsfw)); // form parameter
            }
            if (name != null)
            {
                localVarRequestOptions.FormParameters.Add("name", PeerTubeApiClient.Client.ClientUtils.ParameterToString(name)); // form parameter
            }
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
            if (originallyPublishedAt != null)
            {
                localVarRequestOptions.FormParameters.Add("originallyPublishedAt", PeerTubeApiClient.Client.ClientUtils.ParameterToString(originallyPublishedAt)); // form parameter
            }
            if (scheduleUpdate != null)
            {
                localVarRequestOptions.FormParameters.Add("scheduleUpdate", PeerTubeApiClient.Client.ClientUtils.Serialize(scheduleUpdate)); // form parameter
            }
            if (videoPasswords != null)
            {
                localVarRequestOptions.FormParameters.Add("videoPasswords", PeerTubeApiClient.Client.ClientUtils.Serialize(videoPasswords)); // form parameter
            }

            localVarRequestOptions.Operation = "VideoApi.PutVideo";
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
            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/api/v1/videos/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PutVideo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Send chunk for the resumable replacement of a video **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the replacement of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ReplaceVideoSourceResumable(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0)
        {
            ReplaceVideoSourceResumableWithHttpInfo(uploadId, contentRange, contentLength, body);
        }

        /// <summary>
        /// Send chunk for the resumable replacement of a video **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the replacement of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ReplaceVideoSourceResumableWithHttpInfo(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0)
        {
            // verify the required parameter 'uploadId' is set
            if (uploadId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'uploadId' when calling VideoApi->ReplaceVideoSourceResumable");
            }

            // verify the required parameter 'contentRange' is set
            if (contentRange == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'contentRange' when calling VideoApi->ReplaceVideoSourceResumable");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/octet-stream"
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "upload_id", uploadId));
            localVarRequestOptions.HeaderParameters.Add("Content-Range", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentRange)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentLength)); // header parameter
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "VideoApi.ReplaceVideoSourceResumable";
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
            var localVarResponse = this.Client.Put<Object>("/api/v1/videos/{id}/source/replace-resumable", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReplaceVideoSourceResumable", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Send chunk for the resumable replacement of a video **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the replacement of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ReplaceVideoSourceResumableAsync(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ReplaceVideoSourceResumableWithHttpInfoAsync(uploadId, contentRange, contentLength, body, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Send chunk for the resumable replacement of a video **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the replacement of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ReplaceVideoSourceResumableWithHttpInfoAsync(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'uploadId' is set
            if (uploadId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'uploadId' when calling VideoApi->ReplaceVideoSourceResumable");
            }

            // verify the required parameter 'contentRange' is set
            if (contentRange == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'contentRange' when calling VideoApi->ReplaceVideoSourceResumable");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/octet-stream"
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "upload_id", uploadId));
            localVarRequestOptions.HeaderParameters.Add("Content-Range", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentRange)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentLength)); // header parameter
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "VideoApi.ReplaceVideoSourceResumable";
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
            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/api/v1/videos/{id}/source/replace-resumable", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReplaceVideoSourceResumable", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel the resumable replacement of a video **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the replacement of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ReplaceVideoSourceResumableCancel(string uploadId, decimal contentLength, int operationIndex = 0)
        {
            ReplaceVideoSourceResumableCancelWithHttpInfo(uploadId, contentLength);
        }

        /// <summary>
        /// Cancel the resumable replacement of a video **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the replacement of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ReplaceVideoSourceResumableCancelWithHttpInfo(string uploadId, decimal contentLength, int operationIndex = 0)
        {
            // verify the required parameter 'uploadId' is set
            if (uploadId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'uploadId' when calling VideoApi->ReplaceVideoSourceResumableCancel");
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "upload_id", uploadId));
            localVarRequestOptions.HeaderParameters.Add("Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentLength)); // header parameter

            localVarRequestOptions.Operation = "VideoApi.ReplaceVideoSourceResumableCancel";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/videos/{id}/source/replace-resumable", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReplaceVideoSourceResumableCancel", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel the resumable replacement of a video **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the replacement of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ReplaceVideoSourceResumableCancelAsync(string uploadId, decimal contentLength, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ReplaceVideoSourceResumableCancelWithHttpInfoAsync(uploadId, contentLength, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancel the resumable replacement of a video **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the replacement of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ReplaceVideoSourceResumableCancelWithHttpInfoAsync(string uploadId, decimal contentLength, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'uploadId' is set
            if (uploadId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'uploadId' when calling VideoApi->ReplaceVideoSourceResumableCancel");
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "upload_id", uploadId));
            localVarRequestOptions.HeaderParameters.Add("Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentLength)); // header parameter

            localVarRequestOptions.Operation = "VideoApi.ReplaceVideoSourceResumableCancel";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/videos/{id}/source/replace-resumable", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReplaceVideoSourceResumableCancel", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Initialize the resumable replacement of a video **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the replacement of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoReplaceSourceRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ReplaceVideoSourceResumableInit(decimal xUploadContentLength, string xUploadContentType, VideoReplaceSourceRequestResumable? videoReplaceSourceRequestResumable = default(VideoReplaceSourceRequestResumable?), int operationIndex = 0)
        {
            ReplaceVideoSourceResumableInitWithHttpInfo(xUploadContentLength, xUploadContentType, videoReplaceSourceRequestResumable);
        }

        /// <summary>
        /// Initialize the resumable replacement of a video **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the replacement of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoReplaceSourceRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ReplaceVideoSourceResumableInitWithHttpInfo(decimal xUploadContentLength, string xUploadContentType, VideoReplaceSourceRequestResumable? videoReplaceSourceRequestResumable = default(VideoReplaceSourceRequestResumable?), int operationIndex = 0)
        {
            // verify the required parameter 'xUploadContentType' is set
            if (xUploadContentType == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'xUploadContentType' when calling VideoApi->ReplaceVideoSourceResumableInit");
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

            localVarRequestOptions.HeaderParameters.Add("X-Upload-Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xUploadContentLength)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("X-Upload-Content-Type", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xUploadContentType)); // header parameter
            localVarRequestOptions.Data = videoReplaceSourceRequestResumable;

            localVarRequestOptions.Operation = "VideoApi.ReplaceVideoSourceResumableInit";
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
            var localVarResponse = this.Client.Post<Object>("/api/v1/videos/{id}/source/replace-resumable", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReplaceVideoSourceResumableInit", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Initialize the resumable replacement of a video **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the replacement of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoReplaceSourceRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ReplaceVideoSourceResumableInitAsync(decimal xUploadContentLength, string xUploadContentType, VideoReplaceSourceRequestResumable? videoReplaceSourceRequestResumable = default(VideoReplaceSourceRequestResumable?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ReplaceVideoSourceResumableInitWithHttpInfoAsync(xUploadContentLength, xUploadContentType, videoReplaceSourceRequestResumable, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Initialize the resumable replacement of a video **PeerTube &gt;&#x3D; 6.0** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the replacement of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoReplaceSourceRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ReplaceVideoSourceResumableInitWithHttpInfoAsync(decimal xUploadContentLength, string xUploadContentType, VideoReplaceSourceRequestResumable? videoReplaceSourceRequestResumable = default(VideoReplaceSourceRequestResumable?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xUploadContentType' is set
            if (xUploadContentType == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'xUploadContentType' when calling VideoApi->ReplaceVideoSourceResumableInit");
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

            localVarRequestOptions.HeaderParameters.Add("X-Upload-Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xUploadContentLength)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("X-Upload-Content-Type", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xUploadContentType)); // header parameter
            localVarRequestOptions.Data = videoReplaceSourceRequestResumable;

            localVarRequestOptions.Operation = "VideoApi.ReplaceVideoSourceResumableInit";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/videos/{id}/source/replace-resumable", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReplaceVideoSourceResumableInit", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Request video token Request special tokens that expire quickly to use them in some context (like accessing private static files)
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoTokenResponse</returns>
        public VideoTokenResponse RequestVideoToken(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoTokenResponse> localVarResponse = RequestVideoTokenWithHttpInfo(id, xPeertubeVideoPassword);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Request video token Request special tokens that expire quickly to use them in some context (like accessing private static files)
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoTokenResponse</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoTokenResponse> RequestVideoTokenWithHttpInfo(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->RequestVideoToken");
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

            localVarRequestOptions.Operation = "VideoApi.RequestVideoToken";
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
            var localVarResponse = this.Client.Post<VideoTokenResponse>("/api/v1/videos/{id}/token", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RequestVideoToken", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Request video token Request special tokens that expire quickly to use them in some context (like accessing private static files)
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoTokenResponse</returns>
        public async System.Threading.Tasks.Task<VideoTokenResponse> RequestVideoTokenAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoTokenResponse> localVarResponse = await RequestVideoTokenWithHttpInfoAsync(id, xPeertubeVideoPassword, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Request video token Request special tokens that expire quickly to use them in some context (like accessing private static files)
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The object id, uuid or short uuid</param>
        /// <param name="xPeertubeVideoPassword">Required on password protected video (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoTokenResponse)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoTokenResponse>> RequestVideoTokenWithHttpInfoAsync(ApiV1VideosOwnershipIdAcceptPostIdParameter id, string? xPeertubeVideoPassword = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->RequestVideoToken");
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

            localVarRequestOptions.Operation = "VideoApi.RequestVideoToken";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<VideoTokenResponse>("/api/v1/videos/{id}/token", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RequestVideoToken", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Search videos 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete video information and interact with it. </param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort videos by criteria (prefixing with &#x60;-&#x60; means &#x60;DESC&#x60; order):  (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="startDate">Get videos that are published after this date (optional)</param>
        /// <param name="endDate">Get videos that are published before this date (optional)</param>
        /// <param name="originallyPublishedStartDate">Get videos that are originally published after this date (optional)</param>
        /// <param name="originallyPublishedEndDate">Get videos that are originally published before this date (optional)</param>
        /// <param name="durationMin">Get videos that have this minimum duration (optional)</param>
        /// <param name="durationMax">Get videos that have this maximum duration (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoListResponse</returns>
        public VideoListResponse SearchVideos(string search, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), List<string>? uuids = default(List<string>?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), string? host = default(string?), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), DateTime? originallyPublishedStartDate = default(DateTime?), DateTime? originallyPublishedEndDate = default(DateTime?), int? durationMin = default(int?), int? durationMax = default(int?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoListResponse> localVarResponse = SearchVideosWithHttpInfo(search, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, uuids, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, searchTarget, sort, excludeAlreadyWatched, host, startDate, endDate, originallyPublishedStartDate, originallyPublishedEndDate, durationMin, durationMax);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search videos 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete video information and interact with it. </param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort videos by criteria (prefixing with &#x60;-&#x60; means &#x60;DESC&#x60; order):  (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="startDate">Get videos that are published after this date (optional)</param>
        /// <param name="endDate">Get videos that are published before this date (optional)</param>
        /// <param name="originallyPublishedStartDate">Get videos that are originally published after this date (optional)</param>
        /// <param name="originallyPublishedEndDate">Get videos that are originally published before this date (optional)</param>
        /// <param name="durationMin">Get videos that have this minimum duration (optional)</param>
        /// <param name="durationMax">Get videos that have this maximum duration (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoListResponse</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoListResponse> SearchVideosWithHttpInfo(string search, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), List<string>? uuids = default(List<string>?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), string? host = default(string?), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), DateTime? originallyPublishedStartDate = default(DateTime?), DateTime? originallyPublishedEndDate = default(DateTime?), int? durationMin = default(int?), int? durationMax = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'search' is set
            if (search == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'search' when calling VideoApi->SearchVideos");
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "search", search));
            if (categoryOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "categoryOneOf", categoryOneOf));
            }
            if (isLive != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLive", isLive));
            }
            if (tagsOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsOneOf", tagsOneOf));
            }
            if (tagsAllOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsAllOf", tagsAllOf));
            }
            if (licenceOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "licenceOneOf", licenceOneOf));
            }
            if (languageOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "languageOneOf", languageOneOf));
            }
            if (autoTagOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "autoTagOneOf", autoTagOneOf));
            }
            if (nsfw != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "nsfw", nsfw));
            }
            if (isLocal != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLocal", isLocal));
            }
            if (include != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "include", include));
            }
            if (privacyOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "privacyOneOf", privacyOneOf));
            }
            if (uuids != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("multi", "uuids", uuids));
            }
            if (hasHLSFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasHLSFiles", hasHLSFiles));
            }
            if (hasWebVideoFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasWebVideoFiles", hasWebVideoFiles));
            }
            if (skipCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "skipCount", skipCount));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (count != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "count", count));
            }
            if (searchTarget != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchTarget", searchTarget));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (excludeAlreadyWatched != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "excludeAlreadyWatched", excludeAlreadyWatched));
            }
            if (host != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "host", host));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "startDate", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "endDate", endDate));
            }
            if (originallyPublishedStartDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "originallyPublishedStartDate", originallyPublishedStartDate));
            }
            if (originallyPublishedEndDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "originallyPublishedEndDate", originallyPublishedEndDate));
            }
            if (durationMin != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "durationMin", durationMin));
            }
            if (durationMax != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "durationMax", durationMax));
            }

            localVarRequestOptions.Operation = "VideoApi.SearchVideos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<VideoListResponse>("/api/v1/search/videos", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SearchVideos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Search videos 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete video information and interact with it. </param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort videos by criteria (prefixing with &#x60;-&#x60; means &#x60;DESC&#x60; order):  (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="startDate">Get videos that are published after this date (optional)</param>
        /// <param name="endDate">Get videos that are published before this date (optional)</param>
        /// <param name="originallyPublishedStartDate">Get videos that are originally published after this date (optional)</param>
        /// <param name="originallyPublishedEndDate">Get videos that are originally published before this date (optional)</param>
        /// <param name="durationMin">Get videos that have this minimum duration (optional)</param>
        /// <param name="durationMax">Get videos that have this maximum duration (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoListResponse</returns>
        public async System.Threading.Tasks.Task<VideoListResponse> SearchVideosAsync(string search, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), List<string>? uuids = default(List<string>?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), string? host = default(string?), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), DateTime? originallyPublishedStartDate = default(DateTime?), DateTime? originallyPublishedEndDate = default(DateTime?), int? durationMin = default(int?), int? durationMax = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoListResponse> localVarResponse = await SearchVideosWithHttpInfoAsync(search, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, uuids, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, searchTarget, sort, excludeAlreadyWatched, host, startDate, endDate, originallyPublishedStartDate, originallyPublishedEndDate, durationMin, durationMax, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search videos 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete video information and interact with it. </param>
        /// <param name="categoryOneOf">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="isLive">whether or not the video is a live (optional)</param>
        /// <param name="tagsOneOf">tag(s) of the video (optional)</param>
        /// <param name="tagsAllOf">tag(s) of the video, where all should be present in the video (optional)</param>
        /// <param name="licenceOneOf">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="languageOneOf">language id of the video (see [/videos/languages](#operation/getLanguages)). Use &#x60;_unknown&#x60; to filter on videos that don&#39;t have a video language (optional)</param>
        /// <param name="autoTagOneOf">**PeerTube &gt;&#x3D; 6.2** **Admins and moderators only** filter on videos that contain one of these automatic tags (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="skipCount">if you don&#39;t need the &#x60;total&#x60; in the response (optional, default to false)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort videos by criteria (prefixing with &#x60;-&#x60; means &#x60;DESC&#x60; order):  (optional)</param>
        /// <param name="excludeAlreadyWatched">Whether or not to exclude videos that are in the user&#39;s video history (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="startDate">Get videos that are published after this date (optional)</param>
        /// <param name="endDate">Get videos that are published before this date (optional)</param>
        /// <param name="originallyPublishedStartDate">Get videos that are originally published after this date (optional)</param>
        /// <param name="originallyPublishedEndDate">Get videos that are originally published before this date (optional)</param>
        /// <param name="durationMin">Get videos that have this minimum duration (optional)</param>
        /// <param name="durationMax">Get videos that have this maximum duration (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoListResponse)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoListResponse>> SearchVideosWithHttpInfoAsync(string search, GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), List<string>? uuids = default(List<string>?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), string? host = default(string?), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), DateTime? originallyPublishedStartDate = default(DateTime?), DateTime? originallyPublishedEndDate = default(DateTime?), int? durationMin = default(int?), int? durationMax = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'search' is set
            if (search == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'search' when calling VideoApi->SearchVideos");
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "search", search));
            if (categoryOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "categoryOneOf", categoryOneOf));
            }
            if (isLive != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLive", isLive));
            }
            if (tagsOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsOneOf", tagsOneOf));
            }
            if (tagsAllOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "tagsAllOf", tagsAllOf));
            }
            if (licenceOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "licenceOneOf", licenceOneOf));
            }
            if (languageOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "languageOneOf", languageOneOf));
            }
            if (autoTagOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "autoTagOneOf", autoTagOneOf));
            }
            if (nsfw != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "nsfw", nsfw));
            }
            if (isLocal != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "isLocal", isLocal));
            }
            if (include != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "include", include));
            }
            if (privacyOneOf != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "privacyOneOf", privacyOneOf));
            }
            if (uuids != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("multi", "uuids", uuids));
            }
            if (hasHLSFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasHLSFiles", hasHLSFiles));
            }
            if (hasWebVideoFiles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "hasWebVideoFiles", hasWebVideoFiles));
            }
            if (skipCount != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "skipCount", skipCount));
            }
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (count != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "count", count));
            }
            if (searchTarget != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "searchTarget", searchTarget));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
            }
            if (excludeAlreadyWatched != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "excludeAlreadyWatched", excludeAlreadyWatched));
            }
            if (host != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "host", host));
            }
            if (startDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "startDate", startDate));
            }
            if (endDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "endDate", endDate));
            }
            if (originallyPublishedStartDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "originallyPublishedStartDate", originallyPublishedStartDate));
            }
            if (originallyPublishedEndDate != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "originallyPublishedEndDate", originallyPublishedEndDate));
            }
            if (durationMin != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "durationMin", durationMin));
            }
            if (durationMax != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "durationMax", durationMax));
            }

            localVarRequestOptions.Operation = "VideoApi.SearchVideos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoListResponse>("/api/v1/search/videos", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SearchVideos", localVarResponse);
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->UpdateLiveId");
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

            localVarRequestOptions.Operation = "VideoApi.UpdateLiveId";
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'id' when calling VideoApi->UpdateLiveId");
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

            localVarRequestOptions.Operation = "VideoApi.UpdateLiveId";
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

        /// <summary>
        /// Upload a video Uses a single request to upload a video.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Video name</param>
        /// <param name="channelId">Channel id that will contain this video</param>
        /// <param name="videofile">Video file</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="generateTranscription">**PeerTube &gt;&#x3D; 6.2** If enabled by the admin, automatically generate a subtitle of the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoUploadResponse</returns>
        public VideoUploadResponse UploadLegacy(string name, int channelId, System.IO.Stream videofile, VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), bool? waitTranscoding = default(bool?), bool? generateTranscription = default(bool?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoUploadResponse> localVarResponse = UploadLegacyWithHttpInfo(name, channelId, videofile, privacy, category, licence, language, description, waitTranscoding, generateTranscription, support, nsfw, tags, commentsEnabled, commentsPolicy, downloadEnabled, originallyPublishedAt, scheduleUpdate, thumbnailfile, previewfile, videoPasswords);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Upload a video Uses a single request to upload a video.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Video name</param>
        /// <param name="channelId">Channel id that will contain this video</param>
        /// <param name="videofile">Video file</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="generateTranscription">**PeerTube &gt;&#x3D; 6.2** If enabled by the admin, automatically generate a subtitle of the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoUploadResponse</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoUploadResponse> UploadLegacyWithHttpInfo(string name, int channelId, System.IO.Stream videofile, VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), bool? waitTranscoding = default(bool?), bool? generateTranscription = default(bool?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'name' when calling VideoApi->UploadLegacy");
            }

            // verify the required parameter 'videofile' is set
            if (videofile == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'videofile' when calling VideoApi->UploadLegacy");
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

            localVarRequestOptions.FormParameters.Add("name", PeerTubeApiClient.Client.ClientUtils.ParameterToString(name)); // form parameter
            localVarRequestOptions.FormParameters.Add("channelId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelId)); // form parameter
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
            if (waitTranscoding != null)
            {
                localVarRequestOptions.FormParameters.Add("waitTranscoding", PeerTubeApiClient.Client.ClientUtils.ParameterToString(waitTranscoding)); // form parameter
            }
            if (generateTranscription != null)
            {
                localVarRequestOptions.FormParameters.Add("generateTranscription", PeerTubeApiClient.Client.ClientUtils.ParameterToString(generateTranscription)); // form parameter
            }
            if (support != null)
            {
                localVarRequestOptions.FormParameters.Add("support", PeerTubeApiClient.Client.ClientUtils.ParameterToString(support)); // form parameter
            }
            if (nsfw != null)
            {
                localVarRequestOptions.FormParameters.Add("nsfw", PeerTubeApiClient.Client.ClientUtils.ParameterToString(nsfw)); // form parameter
            }
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
            if (originallyPublishedAt != null)
            {
                localVarRequestOptions.FormParameters.Add("originallyPublishedAt", PeerTubeApiClient.Client.ClientUtils.ParameterToString(originallyPublishedAt)); // form parameter
            }
            if (scheduleUpdate != null)
            {
                localVarRequestOptions.FormParameters.Add("scheduleUpdate", PeerTubeApiClient.Client.ClientUtils.Serialize(scheduleUpdate)); // form parameter
            }
            if (thumbnailfile != null)
            {
                localVarRequestOptions.FileParameters.Add("thumbnailfile", thumbnailfile);
            }
            if (previewfile != null)
            {
                localVarRequestOptions.FileParameters.Add("previewfile", previewfile);
            }
            if (videoPasswords != null)
            {
                localVarRequestOptions.FormParameters.Add("videoPasswords", PeerTubeApiClient.Client.ClientUtils.Serialize(videoPasswords)); // form parameter
            }
            localVarRequestOptions.FileParameters.Add("videofile", videofile);

            localVarRequestOptions.Operation = "VideoApi.UploadLegacy";
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
            var localVarResponse = this.Client.Post<VideoUploadResponse>("/api/v1/videos/upload", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UploadLegacy", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Upload a video Uses a single request to upload a video.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Video name</param>
        /// <param name="channelId">Channel id that will contain this video</param>
        /// <param name="videofile">Video file</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="generateTranscription">**PeerTube &gt;&#x3D; 6.2** If enabled by the admin, automatically generate a subtitle of the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoUploadResponse</returns>
        public async System.Threading.Tasks.Task<VideoUploadResponse> UploadLegacyAsync(string name, int channelId, System.IO.Stream videofile, VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), bool? waitTranscoding = default(bool?), bool? generateTranscription = default(bool?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoUploadResponse> localVarResponse = await UploadLegacyWithHttpInfoAsync(name, channelId, videofile, privacy, category, licence, language, description, waitTranscoding, generateTranscription, support, nsfw, tags, commentsEnabled, commentsPolicy, downloadEnabled, originallyPublishedAt, scheduleUpdate, thumbnailfile, previewfile, videoPasswords, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Upload a video Uses a single request to upload a video.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">Video name</param>
        /// <param name="channelId">Channel id that will contain this video</param>
        /// <param name="videofile">Video file</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)) (optional)</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)) (optional)</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)) (optional)</param>
        /// <param name="description">Video description (optional)</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video (optional)</param>
        /// <param name="generateTranscription">**PeerTube &gt;&#x3D; 6.2** If enabled by the admin, automatically generate a subtitle of the video (optional)</param>
        /// <param name="support">A text tell the audience how to support the video creator (optional)</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content (optional)</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters) (optional)</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead (optional)</param>
        /// <param name="commentsPolicy"> (optional)</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video (optional)</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published (optional)</param>
        /// <param name="scheduleUpdate"> (optional)</param>
        /// <param name="thumbnailfile">Video thumbnail file (optional)</param>
        /// <param name="previewfile">Video preview file (optional)</param>
        /// <param name="videoPasswords"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoUploadResponse)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoUploadResponse>> UploadLegacyWithHttpInfoAsync(string name, int channelId, System.IO.Stream videofile, VideoPrivacySet? privacy = default(VideoPrivacySet?), int? category = default(int?), int? licence = default(int?), string? language = default(string?), string? description = default(string?), bool? waitTranscoding = default(bool?), bool? generateTranscription = default(bool?), string? support = default(string?), bool? nsfw = default(bool?), List<string>? tags = default(List<string>?), bool? commentsEnabled = default(bool?), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool? downloadEnabled = default(bool?), DateTime? originallyPublishedAt = default(DateTime?), VideoScheduledUpdate? scheduleUpdate = default(VideoScheduledUpdate?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), System.IO.Stream? previewfile = default(System.IO.Stream?), List<string>? videoPasswords = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'name' when calling VideoApi->UploadLegacy");
            }

            // verify the required parameter 'videofile' is set
            if (videofile == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'videofile' when calling VideoApi->UploadLegacy");
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

            localVarRequestOptions.FormParameters.Add("name", PeerTubeApiClient.Client.ClientUtils.ParameterToString(name)); // form parameter
            localVarRequestOptions.FormParameters.Add("channelId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelId)); // form parameter
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
            if (waitTranscoding != null)
            {
                localVarRequestOptions.FormParameters.Add("waitTranscoding", PeerTubeApiClient.Client.ClientUtils.ParameterToString(waitTranscoding)); // form parameter
            }
            if (generateTranscription != null)
            {
                localVarRequestOptions.FormParameters.Add("generateTranscription", PeerTubeApiClient.Client.ClientUtils.ParameterToString(generateTranscription)); // form parameter
            }
            if (support != null)
            {
                localVarRequestOptions.FormParameters.Add("support", PeerTubeApiClient.Client.ClientUtils.ParameterToString(support)); // form parameter
            }
            if (nsfw != null)
            {
                localVarRequestOptions.FormParameters.Add("nsfw", PeerTubeApiClient.Client.ClientUtils.ParameterToString(nsfw)); // form parameter
            }
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
            if (originallyPublishedAt != null)
            {
                localVarRequestOptions.FormParameters.Add("originallyPublishedAt", PeerTubeApiClient.Client.ClientUtils.ParameterToString(originallyPublishedAt)); // form parameter
            }
            if (scheduleUpdate != null)
            {
                localVarRequestOptions.FormParameters.Add("scheduleUpdate", PeerTubeApiClient.Client.ClientUtils.Serialize(scheduleUpdate)); // form parameter
            }
            if (thumbnailfile != null)
            {
                localVarRequestOptions.FileParameters.Add("thumbnailfile", thumbnailfile);
            }
            if (previewfile != null)
            {
                localVarRequestOptions.FileParameters.Add("previewfile", previewfile);
            }
            if (videoPasswords != null)
            {
                localVarRequestOptions.FormParameters.Add("videoPasswords", PeerTubeApiClient.Client.ClientUtils.Serialize(videoPasswords)); // form parameter
            }
            localVarRequestOptions.FileParameters.Add("videofile", videofile);

            localVarRequestOptions.Operation = "VideoApi.UploadLegacy";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<VideoUploadResponse>("/api/v1/videos/upload", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UploadLegacy", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Send chunk for the resumable upload of a video Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the upload of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoUploadResponse</returns>
        public VideoUploadResponse UploadResumable(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoUploadResponse> localVarResponse = UploadResumableWithHttpInfo(uploadId, contentRange, contentLength, body);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Send chunk for the resumable upload of a video Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the upload of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoUploadResponse</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoUploadResponse> UploadResumableWithHttpInfo(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0)
        {
            // verify the required parameter 'uploadId' is set
            if (uploadId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'uploadId' when calling VideoApi->UploadResumable");
            }

            // verify the required parameter 'contentRange' is set
            if (contentRange == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'contentRange' when calling VideoApi->UploadResumable");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/octet-stream"
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "upload_id", uploadId));
            localVarRequestOptions.HeaderParameters.Add("Content-Range", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentRange)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentLength)); // header parameter
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "VideoApi.UploadResumable";
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
            var localVarResponse = this.Client.Put<VideoUploadResponse>("/api/v1/videos/upload-resumable", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UploadResumable", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Send chunk for the resumable upload of a video Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the upload of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoUploadResponse</returns>
        public async System.Threading.Tasks.Task<VideoUploadResponse> UploadResumableAsync(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoUploadResponse> localVarResponse = await UploadResumableWithHttpInfoAsync(uploadId, contentRange, contentLength, body, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Send chunk for the resumable upload of a video Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the upload of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoUploadResponse)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoUploadResponse>> UploadResumableWithHttpInfoAsync(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'uploadId' is set
            if (uploadId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'uploadId' when calling VideoApi->UploadResumable");
            }

            // verify the required parameter 'contentRange' is set
            if (contentRange == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'contentRange' when calling VideoApi->UploadResumable");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/octet-stream"
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "upload_id", uploadId));
            localVarRequestOptions.HeaderParameters.Add("Content-Range", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentRange)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentLength)); // header parameter
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "VideoApi.UploadResumable";
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
            var localVarResponse = await this.AsynchronousClient.PutAsync<VideoUploadResponse>("/api/v1/videos/upload-resumable", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UploadResumable", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel the resumable upload of a video, deleting any data uploaded so far Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the upload of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void UploadResumableCancel(string uploadId, decimal contentLength, int operationIndex = 0)
        {
            UploadResumableCancelWithHttpInfo(uploadId, contentLength);
        }

        /// <summary>
        /// Cancel the resumable upload of a video, deleting any data uploaded so far Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the upload of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> UploadResumableCancelWithHttpInfo(string uploadId, decimal contentLength, int operationIndex = 0)
        {
            // verify the required parameter 'uploadId' is set
            if (uploadId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'uploadId' when calling VideoApi->UploadResumableCancel");
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "upload_id", uploadId));
            localVarRequestOptions.HeaderParameters.Add("Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentLength)); // header parameter

            localVarRequestOptions.Operation = "VideoApi.UploadResumableCancel";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/videos/upload-resumable", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UploadResumableCancel", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel the resumable upload of a video, deleting any data uploaded so far Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the upload of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UploadResumableCancelAsync(string uploadId, decimal contentLength, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UploadResumableCancelWithHttpInfoAsync(uploadId, contentLength, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancel the resumable upload of a video, deleting any data uploaded so far Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the upload of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> UploadResumableCancelWithHttpInfoAsync(string uploadId, decimal contentLength, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'uploadId' is set
            if (uploadId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'uploadId' when calling VideoApi->UploadResumableCancel");
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "upload_id", uploadId));
            localVarRequestOptions.HeaderParameters.Add("Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentLength)); // header parameter

            localVarRequestOptions.Operation = "VideoApi.UploadResumableCancel";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/videos/upload-resumable", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UploadResumableCancel", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Initialize the resumable upload of a video Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the upload of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoUploadRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void UploadResumableInit(decimal xUploadContentLength, string xUploadContentType, VideoUploadRequestResumable? videoUploadRequestResumable = default(VideoUploadRequestResumable?), int operationIndex = 0)
        {
            UploadResumableInitWithHttpInfo(xUploadContentLength, xUploadContentType, videoUploadRequestResumable);
        }

        /// <summary>
        /// Initialize the resumable upload of a video Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the upload of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoUploadRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> UploadResumableInitWithHttpInfo(decimal xUploadContentLength, string xUploadContentType, VideoUploadRequestResumable? videoUploadRequestResumable = default(VideoUploadRequestResumable?), int operationIndex = 0)
        {
            // verify the required parameter 'xUploadContentType' is set
            if (xUploadContentType == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'xUploadContentType' when calling VideoApi->UploadResumableInit");
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

            localVarRequestOptions.HeaderParameters.Add("X-Upload-Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xUploadContentLength)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("X-Upload-Content-Type", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xUploadContentType)); // header parameter
            localVarRequestOptions.Data = videoUploadRequestResumable;

            localVarRequestOptions.Operation = "VideoApi.UploadResumableInit";
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
            var localVarResponse = this.Client.Post<Object>("/api/v1/videos/upload-resumable", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UploadResumableInit", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Initialize the resumable upload of a video Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the upload of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoUploadRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UploadResumableInitAsync(decimal xUploadContentLength, string xUploadContentType, VideoUploadRequestResumable? videoUploadRequestResumable = default(VideoUploadRequestResumable?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UploadResumableInitWithHttpInfoAsync(xUploadContentLength, xUploadContentType, videoUploadRequestResumable, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Initialize the resumable upload of a video Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the upload of a video
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="videoUploadRequestResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> UploadResumableInitWithHttpInfoAsync(decimal xUploadContentLength, string xUploadContentType, VideoUploadRequestResumable? videoUploadRequestResumable = default(VideoUploadRequestResumable?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xUploadContentType' is set
            if (xUploadContentType == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'xUploadContentType' when calling VideoApi->UploadResumableInit");
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

            localVarRequestOptions.HeaderParameters.Add("X-Upload-Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xUploadContentLength)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("X-Upload-Content-Type", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xUploadContentType)); // header parameter
            localVarRequestOptions.Data = videoUploadRequestResumable;

            localVarRequestOptions.Operation = "VideoApi.UploadResumableInit";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/videos/upload-resumable", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UploadResumableInit", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
