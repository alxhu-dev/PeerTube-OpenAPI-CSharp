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
    public interface IVideoChannelsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create a video channel
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AddVideoChannel200Response</returns>
        AddVideoChannel200Response AddVideoChannel(VideoChannelCreate? videoChannelCreate = default(VideoChannelCreate?), int operationIndex = 0);

        /// <summary>
        /// Create a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AddVideoChannel200Response</returns>
        ApiResponse<AddVideoChannel200Response> AddVideoChannelWithHttpInfo(VideoChannelCreate? videoChannelCreate = default(VideoChannelCreate?), int operationIndex = 0);
        /// <summary>
        /// List the synchronizations of video channels of an account
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoChannelSyncList</returns>
        VideoChannelSyncList ApiV1AccountsNameVideoChannelSyncsGet(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0);

        /// <summary>
        /// List the synchronizations of video channels of an account
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoChannelSyncList</returns>
        ApiResponse<VideoChannelSyncList> ApiV1AccountsNameVideoChannelSyncsGetWithHttpInfo(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0);
        /// <summary>
        /// List video channels of an account
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="withStats">include daily view statistics for the last 30 days and total views (only if authentified as the account user) (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoChannelList</returns>
        VideoChannelList ApiV1AccountsNameVideoChannelsGet(string name, bool? withStats = default(bool?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0);

        /// <summary>
        /// List video channels of an account
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="withStats">include daily view statistics for the last 30 days and total views (only if authentified as the account user) (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoChannelList</returns>
        ApiResponse<VideoChannelList> ApiV1AccountsNameVideoChannelsGetWithHttpInfo(string name, bool? withStats = default(bool?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0);
        /// <summary>
        /// Delete channel avatar
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1VideoChannelsChannelHandleAvatarDelete(string channelHandle, int operationIndex = 0);

        /// <summary>
        /// Delete channel avatar
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1VideoChannelsChannelHandleAvatarDeleteWithHttpInfo(string channelHandle, int operationIndex = 0);
        /// <summary>
        /// Update channel avatar
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="avatarfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1UsersMeAvatarPickPost200Response</returns>
        ApiV1UsersMeAvatarPickPost200Response ApiV1VideoChannelsChannelHandleAvatarPickPost(string channelHandle, System.IO.Stream? avatarfile = default(System.IO.Stream?), int operationIndex = 0);

        /// <summary>
        /// Update channel avatar
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="avatarfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1UsersMeAvatarPickPost200Response</returns>
        ApiResponse<ApiV1UsersMeAvatarPickPost200Response> ApiV1VideoChannelsChannelHandleAvatarPickPostWithHttpInfo(string channelHandle, System.IO.Stream? avatarfile = default(System.IO.Stream?), int operationIndex = 0);
        /// <summary>
        /// Delete channel banner
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1VideoChannelsChannelHandleBannerDelete(string channelHandle, int operationIndex = 0);

        /// <summary>
        /// Delete channel banner
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1VideoChannelsChannelHandleBannerDeleteWithHttpInfo(string channelHandle, int operationIndex = 0);
        /// <summary>
        /// Update channel banner
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="bannerfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1VideoChannelsChannelHandleBannerPickPost200Response</returns>
        ApiV1VideoChannelsChannelHandleBannerPickPost200Response ApiV1VideoChannelsChannelHandleBannerPickPost(string channelHandle, System.IO.Stream? bannerfile = default(System.IO.Stream?), int operationIndex = 0);

        /// <summary>
        /// Update channel banner
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="bannerfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1VideoChannelsChannelHandleBannerPickPost200Response</returns>
        ApiResponse<ApiV1VideoChannelsChannelHandleBannerPickPost200Response> ApiV1VideoChannelsChannelHandleBannerPickPostWithHttpInfo(string channelHandle, System.IO.Stream? bannerfile = default(System.IO.Stream?), int operationIndex = 0);
        /// <summary>
        /// Import videos in channel
        /// </summary>
        /// <remarks>
        /// Import a remote channel/playlist videos into a channel
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="importVideosInChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1VideoChannelsChannelHandleImportVideosPost(string channelHandle, ImportVideosInChannelCreate? importVideosInChannelCreate = default(ImportVideosInChannelCreate?), int operationIndex = 0);

        /// <summary>
        /// Import videos in channel
        /// </summary>
        /// <remarks>
        /// Import a remote channel/playlist videos into a channel
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="importVideosInChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1VideoChannelsChannelHandleImportVideosPostWithHttpInfo(string channelHandle, ImportVideosInChannelCreate? importVideosInChannelCreate = default(ImportVideosInChannelCreate?), int operationIndex = 0);
        /// <summary>
        /// List playlists of a channel
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response ApiV1VideoChannelsChannelHandleVideoPlaylistsGet(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0);

        /// <summary>
        /// List playlists of a channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> ApiV1VideoChannelsChannelHandleVideoPlaylistsGetWithHttpInfo(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0);
        /// <summary>
        /// Delete a video channel
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void DelVideoChannel(string channelHandle, int operationIndex = 0);

        /// <summary>
        /// Delete a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DelVideoChannelWithHttpInfo(string channelHandle, int operationIndex = 0);
        /// <summary>
        /// Get a video channel
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoChannel</returns>
        VideoChannel GetVideoChannel(string channelHandle, int operationIndex = 0);

        /// <summary>
        /// Get a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoChannel</returns>
        ApiResponse<VideoChannel> GetVideoChannelWithHttpInfo(string channelHandle, int operationIndex = 0);
        /// <summary>
        /// List followers of a video channel
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort followers by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetAccountFollowers200Response</returns>
        GetAccountFollowers200Response GetVideoChannelFollowers(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), int operationIndex = 0);

        /// <summary>
        /// List followers of a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort followers by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetAccountFollowers200Response</returns>
        ApiResponse<GetAccountFollowers200Response> GetVideoChannelFollowersWithHttpInfo(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), int operationIndex = 0);
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
        /// List video channels
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoChannelList</returns>
        VideoChannelList GetVideoChannels(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0);

        /// <summary>
        /// List video channels
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoChannelList</returns>
        ApiResponse<VideoChannelList> GetVideoChannelsWithHttpInfo(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0);
        /// <summary>
        /// Update a video channel
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="videoChannelUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void PutVideoChannel(string channelHandle, VideoChannelUpdate? videoChannelUpdate = default(VideoChannelUpdate?), int operationIndex = 0);

        /// <summary>
        /// Update a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="videoChannelUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> PutVideoChannelWithHttpInfo(string channelHandle, VideoChannelUpdate? videoChannelUpdate = default(VideoChannelUpdate?), int operationIndex = 0);
        /// <summary>
        /// Search channels
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete channel information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="handles">Find elements with these handles (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoChannelList</returns>
        VideoChannelList SearchChannels(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? handles = default(List<string>?), int operationIndex = 0);

        /// <summary>
        /// Search channels
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete channel information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="handles">Find elements with these handles (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoChannelList</returns>
        ApiResponse<VideoChannelList> SearchChannelsWithHttpInfo(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? handles = default(List<string>?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IVideoChannelsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Create a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AddVideoChannel200Response</returns>
        System.Threading.Tasks.Task<AddVideoChannel200Response> AddVideoChannelAsync(VideoChannelCreate? videoChannelCreate = default(VideoChannelCreate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AddVideoChannel200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<AddVideoChannel200Response>> AddVideoChannelWithHttpInfoAsync(VideoChannelCreate? videoChannelCreate = default(VideoChannelCreate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List the synchronizations of video channels of an account
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoChannelSyncList</returns>
        System.Threading.Tasks.Task<VideoChannelSyncList> ApiV1AccountsNameVideoChannelSyncsGetAsync(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List the synchronizations of video channels of an account
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoChannelSyncList)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoChannelSyncList>> ApiV1AccountsNameVideoChannelSyncsGetWithHttpInfoAsync(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List video channels of an account
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="withStats">include daily view statistics for the last 30 days and total views (only if authentified as the account user) (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoChannelList</returns>
        System.Threading.Tasks.Task<VideoChannelList> ApiV1AccountsNameVideoChannelsGetAsync(string name, bool? withStats = default(bool?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List video channels of an account
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="withStats">include daily view statistics for the last 30 days and total views (only if authentified as the account user) (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoChannelList)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoChannelList>> ApiV1AccountsNameVideoChannelsGetWithHttpInfoAsync(string name, bool? withStats = default(bool?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete channel avatar
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1VideoChannelsChannelHandleAvatarDeleteAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete channel avatar
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1VideoChannelsChannelHandleAvatarDeleteWithHttpInfoAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update channel avatar
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="avatarfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1UsersMeAvatarPickPost200Response</returns>
        System.Threading.Tasks.Task<ApiV1UsersMeAvatarPickPost200Response> ApiV1VideoChannelsChannelHandleAvatarPickPostAsync(string channelHandle, System.IO.Stream? avatarfile = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update channel avatar
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="avatarfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1UsersMeAvatarPickPost200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1UsersMeAvatarPickPost200Response>> ApiV1VideoChannelsChannelHandleAvatarPickPostWithHttpInfoAsync(string channelHandle, System.IO.Stream? avatarfile = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete channel banner
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1VideoChannelsChannelHandleBannerDeleteAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete channel banner
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1VideoChannelsChannelHandleBannerDeleteWithHttpInfoAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update channel banner
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="bannerfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1VideoChannelsChannelHandleBannerPickPost200Response</returns>
        System.Threading.Tasks.Task<ApiV1VideoChannelsChannelHandleBannerPickPost200Response> ApiV1VideoChannelsChannelHandleBannerPickPostAsync(string channelHandle, System.IO.Stream? bannerfile = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update channel banner
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="bannerfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1VideoChannelsChannelHandleBannerPickPost200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1VideoChannelsChannelHandleBannerPickPost200Response>> ApiV1VideoChannelsChannelHandleBannerPickPostWithHttpInfoAsync(string channelHandle, System.IO.Stream? bannerfile = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Import videos in channel
        /// </summary>
        /// <remarks>
        /// Import a remote channel/playlist videos into a channel
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="importVideosInChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1VideoChannelsChannelHandleImportVideosPostAsync(string channelHandle, ImportVideosInChannelCreate? importVideosInChannelCreate = default(ImportVideosInChannelCreate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Import videos in channel
        /// </summary>
        /// <remarks>
        /// Import a remote channel/playlist videos into a channel
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="importVideosInChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1VideoChannelsChannelHandleImportVideosPostWithHttpInfoAsync(string channelHandle, ImportVideosInChannelCreate? importVideosInChannelCreate = default(ImportVideosInChannelCreate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List playlists of a channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        System.Threading.Tasks.Task<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> ApiV1VideoChannelsChannelHandleVideoPlaylistsGetAsync(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List playlists of a channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>> ApiV1VideoChannelsChannelHandleVideoPlaylistsGetWithHttpInfoAsync(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DelVideoChannelAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DelVideoChannelWithHttpInfoAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoChannel</returns>
        System.Threading.Tasks.Task<VideoChannel> GetVideoChannelAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoChannel)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoChannel>> GetVideoChannelWithHttpInfoAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List followers of a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort followers by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetAccountFollowers200Response</returns>
        System.Threading.Tasks.Task<GetAccountFollowers200Response> GetVideoChannelFollowersAsync(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List followers of a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort followers by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetAccountFollowers200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetAccountFollowers200Response>> GetVideoChannelFollowersWithHttpInfoAsync(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
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
        /// List video channels
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoChannelList</returns>
        System.Threading.Tasks.Task<VideoChannelList> GetVideoChannelsAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List video channels
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoChannelList)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoChannelList>> GetVideoChannelsWithHttpInfoAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="videoChannelUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task PutVideoChannelAsync(string channelHandle, VideoChannelUpdate? videoChannelUpdate = default(VideoChannelUpdate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update a video channel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="videoChannelUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> PutVideoChannelWithHttpInfoAsync(string channelHandle, VideoChannelUpdate? videoChannelUpdate = default(VideoChannelUpdate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Search channels
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete channel information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="handles">Find elements with these handles (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoChannelList</returns>
        System.Threading.Tasks.Task<VideoChannelList> SearchChannelsAsync(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? handles = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Search channels
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete channel information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="handles">Find elements with these handles (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoChannelList)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoChannelList>> SearchChannelsWithHttpInfoAsync(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? handles = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IVideoChannelsApi : IVideoChannelsApiSync, IVideoChannelsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class VideoChannelsApi : IVideoChannelsApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoChannelsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public VideoChannelsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoChannelsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public VideoChannelsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="VideoChannelsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public VideoChannelsApi(PeerTubeApiClient.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="VideoChannelsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public VideoChannelsApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
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
        /// Create a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AddVideoChannel200Response</returns>
        public AddVideoChannel200Response AddVideoChannel(VideoChannelCreate? videoChannelCreate = default(VideoChannelCreate?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<AddVideoChannel200Response> localVarResponse = AddVideoChannelWithHttpInfo(videoChannelCreate);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AddVideoChannel200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<AddVideoChannel200Response> AddVideoChannelWithHttpInfo(VideoChannelCreate? videoChannelCreate = default(VideoChannelCreate?), int operationIndex = 0)
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

            localVarRequestOptions.Data = videoChannelCreate;

            localVarRequestOptions.Operation = "VideoChannelsApi.AddVideoChannel";
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
            var localVarResponse = this.Client.Post<AddVideoChannel200Response>("/api/v1/video-channels", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("AddVideoChannel", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AddVideoChannel200Response</returns>
        public async System.Threading.Tasks.Task<AddVideoChannel200Response> AddVideoChannelAsync(VideoChannelCreate? videoChannelCreate = default(VideoChannelCreate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<AddVideoChannel200Response> localVarResponse = await AddVideoChannelWithHttpInfoAsync(videoChannelCreate, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AddVideoChannel200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<AddVideoChannel200Response>> AddVideoChannelWithHttpInfoAsync(VideoChannelCreate? videoChannelCreate = default(VideoChannelCreate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.Data = videoChannelCreate;

            localVarRequestOptions.Operation = "VideoChannelsApi.AddVideoChannel";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<AddVideoChannel200Response>("/api/v1/video-channels", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("AddVideoChannel", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List the synchronizations of video channels of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoChannelSyncList</returns>
        public VideoChannelSyncList ApiV1AccountsNameVideoChannelSyncsGet(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoChannelSyncList> localVarResponse = ApiV1AccountsNameVideoChannelSyncsGetWithHttpInfo(name, start, count, sort);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List the synchronizations of video channels of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoChannelSyncList</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoChannelSyncList> ApiV1AccountsNameVideoChannelSyncsGetWithHttpInfo(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'name' when calling VideoChannelsApi->ApiV1AccountsNameVideoChannelSyncsGet");
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

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1AccountsNameVideoChannelSyncsGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<VideoChannelSyncList>("/api/v1/accounts/{name}/video-channel-syncs", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AccountsNameVideoChannelSyncsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List the synchronizations of video channels of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoChannelSyncList</returns>
        public async System.Threading.Tasks.Task<VideoChannelSyncList> ApiV1AccountsNameVideoChannelSyncsGetAsync(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoChannelSyncList> localVarResponse = await ApiV1AccountsNameVideoChannelSyncsGetWithHttpInfoAsync(name, start, count, sort, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List the synchronizations of video channels of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoChannelSyncList)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoChannelSyncList>> ApiV1AccountsNameVideoChannelSyncsGetWithHttpInfoAsync(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'name' when calling VideoChannelsApi->ApiV1AccountsNameVideoChannelSyncsGet");
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

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1AccountsNameVideoChannelSyncsGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoChannelSyncList>("/api/v1/accounts/{name}/video-channel-syncs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AccountsNameVideoChannelSyncsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List video channels of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="withStats">include daily view statistics for the last 30 days and total views (only if authentified as the account user) (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoChannelList</returns>
        public VideoChannelList ApiV1AccountsNameVideoChannelsGet(string name, bool? withStats = default(bool?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoChannelList> localVarResponse = ApiV1AccountsNameVideoChannelsGetWithHttpInfo(name, withStats, start, count, sort);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List video channels of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="withStats">include daily view statistics for the last 30 days and total views (only if authentified as the account user) (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoChannelList</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoChannelList> ApiV1AccountsNameVideoChannelsGetWithHttpInfo(string name, bool? withStats = default(bool?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'name' when calling VideoChannelsApi->ApiV1AccountsNameVideoChannelsGet");
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
            if (withStats != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "withStats", withStats));
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

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1AccountsNameVideoChannelsGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<VideoChannelList>("/api/v1/accounts/{name}/video-channels", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AccountsNameVideoChannelsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List video channels of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="withStats">include daily view statistics for the last 30 days and total views (only if authentified as the account user) (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoChannelList</returns>
        public async System.Threading.Tasks.Task<VideoChannelList> ApiV1AccountsNameVideoChannelsGetAsync(string name, bool? withStats = default(bool?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoChannelList> localVarResponse = await ApiV1AccountsNameVideoChannelsGetWithHttpInfoAsync(name, withStats, start, count, sort, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List video channels of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="withStats">include daily view statistics for the last 30 days and total views (only if authentified as the account user) (optional)</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoChannelList)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoChannelList>> ApiV1AccountsNameVideoChannelsGetWithHttpInfoAsync(string name, bool? withStats = default(bool?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'name' when calling VideoChannelsApi->ApiV1AccountsNameVideoChannelsGet");
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
            if (withStats != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "withStats", withStats));
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

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1AccountsNameVideoChannelsGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoChannelList>("/api/v1/accounts/{name}/video-channels", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AccountsNameVideoChannelsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete channel avatar 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1VideoChannelsChannelHandleAvatarDelete(string channelHandle, int operationIndex = 0)
        {
            ApiV1VideoChannelsChannelHandleAvatarDeleteWithHttpInfo(channelHandle);
        }

        /// <summary>
        /// Delete channel avatar 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1VideoChannelsChannelHandleAvatarDeleteWithHttpInfo(string channelHandle, int operationIndex = 0)
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->ApiV1VideoChannelsChannelHandleAvatarDelete");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1VideoChannelsChannelHandleAvatarDelete";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/video-channels/{channelHandle}/avatar", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoChannelsChannelHandleAvatarDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete channel avatar 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1VideoChannelsChannelHandleAvatarDeleteAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1VideoChannelsChannelHandleAvatarDeleteWithHttpInfoAsync(channelHandle, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete channel avatar 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1VideoChannelsChannelHandleAvatarDeleteWithHttpInfoAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->ApiV1VideoChannelsChannelHandleAvatarDelete");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1VideoChannelsChannelHandleAvatarDelete";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/video-channels/{channelHandle}/avatar", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoChannelsChannelHandleAvatarDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update channel avatar 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="avatarfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1UsersMeAvatarPickPost200Response</returns>
        public ApiV1UsersMeAvatarPickPost200Response ApiV1VideoChannelsChannelHandleAvatarPickPost(string channelHandle, System.IO.Stream? avatarfile = default(System.IO.Stream?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeAvatarPickPost200Response> localVarResponse = ApiV1VideoChannelsChannelHandleAvatarPickPostWithHttpInfo(channelHandle, avatarfile);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update channel avatar 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="avatarfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1UsersMeAvatarPickPost200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeAvatarPickPost200Response> ApiV1VideoChannelsChannelHandleAvatarPickPostWithHttpInfo(string channelHandle, System.IO.Stream? avatarfile = default(System.IO.Stream?), int operationIndex = 0)
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->ApiV1VideoChannelsChannelHandleAvatarPickPost");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter
            if (avatarfile != null)
            {
                localVarRequestOptions.FileParameters.Add("avatarfile", avatarfile);
            }

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1VideoChannelsChannelHandleAvatarPickPost";
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
            var localVarResponse = this.Client.Post<ApiV1UsersMeAvatarPickPost200Response>("/api/v1/video-channels/{channelHandle}/avatar/pick", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoChannelsChannelHandleAvatarPickPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update channel avatar 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="avatarfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1UsersMeAvatarPickPost200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1UsersMeAvatarPickPost200Response> ApiV1VideoChannelsChannelHandleAvatarPickPostAsync(string channelHandle, System.IO.Stream? avatarfile = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeAvatarPickPost200Response> localVarResponse = await ApiV1VideoChannelsChannelHandleAvatarPickPostWithHttpInfoAsync(channelHandle, avatarfile, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update channel avatar 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="avatarfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1UsersMeAvatarPickPost200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeAvatarPickPost200Response>> ApiV1VideoChannelsChannelHandleAvatarPickPostWithHttpInfoAsync(string channelHandle, System.IO.Stream? avatarfile = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->ApiV1VideoChannelsChannelHandleAvatarPickPost");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter
            if (avatarfile != null)
            {
                localVarRequestOptions.FileParameters.Add("avatarfile", avatarfile);
            }

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1VideoChannelsChannelHandleAvatarPickPost";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<ApiV1UsersMeAvatarPickPost200Response>("/api/v1/video-channels/{channelHandle}/avatar/pick", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoChannelsChannelHandleAvatarPickPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete channel banner 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1VideoChannelsChannelHandleBannerDelete(string channelHandle, int operationIndex = 0)
        {
            ApiV1VideoChannelsChannelHandleBannerDeleteWithHttpInfo(channelHandle);
        }

        /// <summary>
        /// Delete channel banner 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1VideoChannelsChannelHandleBannerDeleteWithHttpInfo(string channelHandle, int operationIndex = 0)
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->ApiV1VideoChannelsChannelHandleBannerDelete");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1VideoChannelsChannelHandleBannerDelete";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/video-channels/{channelHandle}/banner", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoChannelsChannelHandleBannerDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete channel banner 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1VideoChannelsChannelHandleBannerDeleteAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1VideoChannelsChannelHandleBannerDeleteWithHttpInfoAsync(channelHandle, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete channel banner 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1VideoChannelsChannelHandleBannerDeleteWithHttpInfoAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->ApiV1VideoChannelsChannelHandleBannerDelete");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1VideoChannelsChannelHandleBannerDelete";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/video-channels/{channelHandle}/banner", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoChannelsChannelHandleBannerDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update channel banner 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="bannerfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1VideoChannelsChannelHandleBannerPickPost200Response</returns>
        public ApiV1VideoChannelsChannelHandleBannerPickPost200Response ApiV1VideoChannelsChannelHandleBannerPickPost(string channelHandle, System.IO.Stream? bannerfile = default(System.IO.Stream?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleBannerPickPost200Response> localVarResponse = ApiV1VideoChannelsChannelHandleBannerPickPostWithHttpInfo(channelHandle, bannerfile);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update channel banner 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="bannerfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1VideoChannelsChannelHandleBannerPickPost200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleBannerPickPost200Response> ApiV1VideoChannelsChannelHandleBannerPickPostWithHttpInfo(string channelHandle, System.IO.Stream? bannerfile = default(System.IO.Stream?), int operationIndex = 0)
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->ApiV1VideoChannelsChannelHandleBannerPickPost");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter
            if (bannerfile != null)
            {
                localVarRequestOptions.FileParameters.Add("bannerfile", bannerfile);
            }

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1VideoChannelsChannelHandleBannerPickPost";
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
            var localVarResponse = this.Client.Post<ApiV1VideoChannelsChannelHandleBannerPickPost200Response>("/api/v1/video-channels/{channelHandle}/banner/pick", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoChannelsChannelHandleBannerPickPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update channel banner 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="bannerfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1VideoChannelsChannelHandleBannerPickPost200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1VideoChannelsChannelHandleBannerPickPost200Response> ApiV1VideoChannelsChannelHandleBannerPickPostAsync(string channelHandle, System.IO.Stream? bannerfile = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleBannerPickPost200Response> localVarResponse = await ApiV1VideoChannelsChannelHandleBannerPickPostWithHttpInfoAsync(channelHandle, bannerfile, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update channel banner 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="bannerfile">The file to upload. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1VideoChannelsChannelHandleBannerPickPost200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleBannerPickPost200Response>> ApiV1VideoChannelsChannelHandleBannerPickPostWithHttpInfoAsync(string channelHandle, System.IO.Stream? bannerfile = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->ApiV1VideoChannelsChannelHandleBannerPickPost");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter
            if (bannerfile != null)
            {
                localVarRequestOptions.FileParameters.Add("bannerfile", bannerfile);
            }

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1VideoChannelsChannelHandleBannerPickPost";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<ApiV1VideoChannelsChannelHandleBannerPickPost200Response>("/api/v1/video-channels/{channelHandle}/banner/pick", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoChannelsChannelHandleBannerPickPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Import videos in channel Import a remote channel/playlist videos into a channel
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="importVideosInChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1VideoChannelsChannelHandleImportVideosPost(string channelHandle, ImportVideosInChannelCreate? importVideosInChannelCreate = default(ImportVideosInChannelCreate?), int operationIndex = 0)
        {
            ApiV1VideoChannelsChannelHandleImportVideosPostWithHttpInfo(channelHandle, importVideosInChannelCreate);
        }

        /// <summary>
        /// Import videos in channel Import a remote channel/playlist videos into a channel
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="importVideosInChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1VideoChannelsChannelHandleImportVideosPostWithHttpInfo(string channelHandle, ImportVideosInChannelCreate? importVideosInChannelCreate = default(ImportVideosInChannelCreate?), int operationIndex = 0)
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->ApiV1VideoChannelsChannelHandleImportVideosPost");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter
            localVarRequestOptions.Data = importVideosInChannelCreate;

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1VideoChannelsChannelHandleImportVideosPost";
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
            var localVarResponse = this.Client.Post<Object>("/api/v1/video-channels/{channelHandle}/import-videos", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoChannelsChannelHandleImportVideosPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Import videos in channel Import a remote channel/playlist videos into a channel
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="importVideosInChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1VideoChannelsChannelHandleImportVideosPostAsync(string channelHandle, ImportVideosInChannelCreate? importVideosInChannelCreate = default(ImportVideosInChannelCreate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1VideoChannelsChannelHandleImportVideosPostWithHttpInfoAsync(channelHandle, importVideosInChannelCreate, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Import videos in channel Import a remote channel/playlist videos into a channel
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="importVideosInChannelCreate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1VideoChannelsChannelHandleImportVideosPostWithHttpInfoAsync(string channelHandle, ImportVideosInChannelCreate? importVideosInChannelCreate = default(ImportVideosInChannelCreate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->ApiV1VideoChannelsChannelHandleImportVideosPost");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter
            localVarRequestOptions.Data = importVideosInChannelCreate;

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1VideoChannelsChannelHandleImportVideosPost";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/video-channels/{channelHandle}/import-videos", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoChannelsChannelHandleImportVideosPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List playlists of a channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        public ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response ApiV1VideoChannelsChannelHandleVideoPlaylistsGet(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> localVarResponse = ApiV1VideoChannelsChannelHandleVideoPlaylistsGetWithHttpInfo(channelHandle, start, count, sort, playlistType);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List playlists of a channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> ApiV1VideoChannelsChannelHandleVideoPlaylistsGetWithHttpInfo(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0)
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->ApiV1VideoChannelsChannelHandleVideoPlaylistsGet");
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
            if (playlistType != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "playlistType", playlistType));
            }

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1VideoChannelsChannelHandleVideoPlaylistsGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>("/api/v1/video-channels/{channelHandle}/video-playlists", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoChannelsChannelHandleVideoPlaylistsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List playlists of a channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> ApiV1VideoChannelsChannelHandleVideoPlaylistsGetAsync(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> localVarResponse = await ApiV1VideoChannelsChannelHandleVideoPlaylistsGetWithHttpInfoAsync(channelHandle, start, count, sort, playlistType, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List playlists of a channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>> ApiV1VideoChannelsChannelHandleVideoPlaylistsGetWithHttpInfoAsync(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->ApiV1VideoChannelsChannelHandleVideoPlaylistsGet");
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
            if (playlistType != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "playlistType", playlistType));
            }

            localVarRequestOptions.Operation = "VideoChannelsApi.ApiV1VideoChannelsChannelHandleVideoPlaylistsGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>("/api/v1/video-channels/{channelHandle}/video-playlists", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoChannelsChannelHandleVideoPlaylistsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void DelVideoChannel(string channelHandle, int operationIndex = 0)
        {
            DelVideoChannelWithHttpInfo(channelHandle);
        }

        /// <summary>
        /// Delete a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> DelVideoChannelWithHttpInfo(string channelHandle, int operationIndex = 0)
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->DelVideoChannel");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter

            localVarRequestOptions.Operation = "VideoChannelsApi.DelVideoChannel";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/video-channels/{channelHandle}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DelVideoChannel", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DelVideoChannelAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await DelVideoChannelWithHttpInfoAsync(channelHandle, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> DelVideoChannelWithHttpInfoAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->DelVideoChannel");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter

            localVarRequestOptions.Operation = "VideoChannelsApi.DelVideoChannel";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/video-channels/{channelHandle}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DelVideoChannel", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoChannel</returns>
        public VideoChannel GetVideoChannel(string channelHandle, int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoChannel> localVarResponse = GetVideoChannelWithHttpInfo(channelHandle);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoChannel</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoChannel> GetVideoChannelWithHttpInfo(string channelHandle, int operationIndex = 0)
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->GetVideoChannel");
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

            localVarRequestOptions.Operation = "VideoChannelsApi.GetVideoChannel";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<VideoChannel>("/api/v1/video-channels/{channelHandle}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoChannel", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoChannel</returns>
        public async System.Threading.Tasks.Task<VideoChannel> GetVideoChannelAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoChannel> localVarResponse = await GetVideoChannelWithHttpInfoAsync(channelHandle, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoChannel)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoChannel>> GetVideoChannelWithHttpInfoAsync(string channelHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->GetVideoChannel");
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

            localVarRequestOptions.Operation = "VideoChannelsApi.GetVideoChannel";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoChannel>("/api/v1/video-channels/{channelHandle}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoChannel", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List followers of a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort followers by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetAccountFollowers200Response</returns>
        public GetAccountFollowers200Response GetVideoChannelFollowers(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<GetAccountFollowers200Response> localVarResponse = GetVideoChannelFollowersWithHttpInfo(channelHandle, start, count, sort, search);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List followers of a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort followers by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetAccountFollowers200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<GetAccountFollowers200Response> GetVideoChannelFollowersWithHttpInfo(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), int operationIndex = 0)
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->GetVideoChannelFollowers");
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

            localVarRequestOptions.Operation = "VideoChannelsApi.GetVideoChannelFollowers";
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
            var localVarResponse = this.Client.Get<GetAccountFollowers200Response>("/api/v1/video-channels/{channelHandle}/followers", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoChannelFollowers", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List followers of a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort followers by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetAccountFollowers200Response</returns>
        public async System.Threading.Tasks.Task<GetAccountFollowers200Response> GetVideoChannelFollowersAsync(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<GetAccountFollowers200Response> localVarResponse = await GetVideoChannelFollowersWithHttpInfoAsync(channelHandle, start, count, sort, search, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List followers of a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort followers by criteria (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetAccountFollowers200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<GetAccountFollowers200Response>> GetVideoChannelFollowersWithHttpInfoAsync(string channelHandle, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->GetVideoChannelFollowers");
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

            localVarRequestOptions.Operation = "VideoChannelsApi.GetVideoChannelFollowers";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetAccountFollowers200Response>("/api/v1/video-channels/{channelHandle}/followers", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoChannelFollowers", localVarResponse);
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->GetVideoChannelVideos");
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

            localVarRequestOptions.Operation = "VideoChannelsApi.GetVideoChannelVideos";
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->GetVideoChannelVideos");
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

            localVarRequestOptions.Operation = "VideoChannelsApi.GetVideoChannelVideos";
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
        /// List video channels 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoChannelList</returns>
        public VideoChannelList GetVideoChannels(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoChannelList> localVarResponse = GetVideoChannelsWithHttpInfo(start, count, sort);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List video channels 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoChannelList</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoChannelList> GetVideoChannelsWithHttpInfo(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0)
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

            localVarRequestOptions.Operation = "VideoChannelsApi.GetVideoChannels";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<VideoChannelList>("/api/v1/video-channels", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoChannels", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List video channels 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoChannelList</returns>
        public async System.Threading.Tasks.Task<VideoChannelList> GetVideoChannelsAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoChannelList> localVarResponse = await GetVideoChannelsWithHttpInfoAsync(start, count, sort, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List video channels 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoChannelList)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoChannelList>> GetVideoChannelsWithHttpInfoAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.Operation = "VideoChannelsApi.GetVideoChannels";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoChannelList>("/api/v1/video-channels", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoChannels", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="videoChannelUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void PutVideoChannel(string channelHandle, VideoChannelUpdate? videoChannelUpdate = default(VideoChannelUpdate?), int operationIndex = 0)
        {
            PutVideoChannelWithHttpInfo(channelHandle, videoChannelUpdate);
        }

        /// <summary>
        /// Update a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="videoChannelUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> PutVideoChannelWithHttpInfo(string channelHandle, VideoChannelUpdate? videoChannelUpdate = default(VideoChannelUpdate?), int operationIndex = 0)
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->PutVideoChannel");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter
            localVarRequestOptions.Data = videoChannelUpdate;

            localVarRequestOptions.Operation = "VideoChannelsApi.PutVideoChannel";
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
            var localVarResponse = this.Client.Put<Object>("/api/v1/video-channels/{channelHandle}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PutVideoChannel", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="videoChannelUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task PutVideoChannelAsync(string channelHandle, VideoChannelUpdate? videoChannelUpdate = default(VideoChannelUpdate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await PutVideoChannelWithHttpInfoAsync(channelHandle, videoChannelUpdate, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a video channel 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="channelHandle">The video channel handle</param>
        /// <param name="videoChannelUpdate"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> PutVideoChannelWithHttpInfoAsync(string channelHandle, VideoChannelUpdate? videoChannelUpdate = default(VideoChannelUpdate?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'channelHandle' is set
            if (channelHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoChannelsApi->PutVideoChannel");
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

            localVarRequestOptions.PathParameters.Add("channelHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(channelHandle)); // path parameter
            localVarRequestOptions.Data = videoChannelUpdate;

            localVarRequestOptions.Operation = "VideoChannelsApi.PutVideoChannel";
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
            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/api/v1/video-channels/{channelHandle}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PutVideoChannel", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Search channels 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete channel information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="handles">Find elements with these handles (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoChannelList</returns>
        public VideoChannelList SearchChannels(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? handles = default(List<string>?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoChannelList> localVarResponse = SearchChannelsWithHttpInfo(search, start, count, searchTarget, sort, host, handles);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search channels 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete channel information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="handles">Find elements with these handles (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoChannelList</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoChannelList> SearchChannelsWithHttpInfo(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? handles = default(List<string>?), int operationIndex = 0)
        {
            // verify the required parameter 'search' is set
            if (search == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'search' when calling VideoChannelsApi->SearchChannels");
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
            if (host != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "host", host));
            }
            if (handles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("multi", "handles", handles));
            }

            localVarRequestOptions.Operation = "VideoChannelsApi.SearchChannels";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<VideoChannelList>("/api/v1/search/video-channels", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SearchChannels", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Search channels 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete channel information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="handles">Find elements with these handles (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoChannelList</returns>
        public async System.Threading.Tasks.Task<VideoChannelList> SearchChannelsAsync(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? handles = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoChannelList> localVarResponse = await SearchChannelsWithHttpInfoAsync(search, start, count, searchTarget, sort, host, handles, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search channels 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete channel information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="handles">Find elements with these handles (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoChannelList)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoChannelList>> SearchChannelsWithHttpInfoAsync(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? handles = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'search' is set
            if (search == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'search' when calling VideoChannelsApi->SearchChannels");
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
            if (host != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "host", host));
            }
            if (handles != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("multi", "handles", handles));
            }

            localVarRequestOptions.Operation = "VideoChannelsApi.SearchChannels";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoChannelList>("/api/v1/search/video-channels", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SearchChannels", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
