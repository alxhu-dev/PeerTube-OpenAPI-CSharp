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
    public interface ISearchApiSync : IApiAccessor
    {
        #region Synchronous Operations
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
        /// <summary>
        /// Search playlists
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete playlist information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response SearchPlaylists(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? uuids = default(List<string>?), int operationIndex = 0);

        /// <summary>
        /// Search playlists
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete playlist information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> SearchPlaylistsWithHttpInfo(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? uuids = default(List<string>?), int operationIndex = 0);
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
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISearchApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
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
        /// <summary>
        /// Search playlists
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete playlist information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        System.Threading.Tasks.Task<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> SearchPlaylistsAsync(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? uuids = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Search playlists
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete playlist information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>> SearchPlaylistsWithHttpInfoAsync(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? uuids = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
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
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISearchApi : ISearchApiSync, ISearchApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class SearchApi : ISearchApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SearchApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SearchApi(string basePath)
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
        /// Initializes a new instance of the <see cref="SearchApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public SearchApi(PeerTubeApiClient.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="SearchApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public SearchApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'search' when calling SearchApi->SearchChannels");
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

            localVarRequestOptions.Operation = "SearchApi.SearchChannels";
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'search' when calling SearchApi->SearchChannels");
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

            localVarRequestOptions.Operation = "SearchApi.SearchChannels";
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

        /// <summary>
        /// Search playlists 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete playlist information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        public ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response SearchPlaylists(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? uuids = default(List<string>?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> localVarResponse = SearchPlaylistsWithHttpInfo(search, start, count, searchTarget, sort, host, uuids);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search playlists 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete playlist information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> SearchPlaylistsWithHttpInfo(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? uuids = default(List<string>?), int operationIndex = 0)
        {
            // verify the required parameter 'search' is set
            if (search == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'search' when calling SearchApi->SearchPlaylists");
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
            if (uuids != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("multi", "uuids", uuids));
            }

            localVarRequestOptions.Operation = "SearchApi.SearchPlaylists";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>("/api/v1/search/video-playlists", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SearchPlaylists", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Search playlists 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete playlist information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> SearchPlaylistsAsync(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? uuids = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> localVarResponse = await SearchPlaylistsWithHttpInfoAsync(search, start, count, searchTarget, sort, host, uuids, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Search playlists 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="search">String to search. If the user can make a remote URI search, and the string is an URI then the PeerTube instance will fetch the remote object and add it to its database. Then, you can use the REST API to fetch the complete playlist information and interact with it. </param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="searchTarget">If the administrator enabled search index support, you can override the default search target.  **Warning**: If you choose to make an index search, PeerTube will get results from a third party service. It means the instance may not yet know the objects you fetched. If you want to load video/channel information:   * If the current user has the ability to make a remote URI search (this information is available in the config endpoint),   then reuse the search API to make a search using the object URI so PeerTube instance fetches the remote object and fill its database.   After that, you can use the classic REST API endpoints to fetch the complete object or interact with it   * If the current user doesn&#39;t have the ability to make a remote URI search, then redirect the user on the origin instance or fetch   the data from the origin instance API  (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="host">Find elements owned by this host (optional)</param>
        /// <param name="uuids">Find elements with specific UUIDs (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>> SearchPlaylistsWithHttpInfoAsync(string search, int? start = default(int?), int? count = default(int?), string? searchTarget = default(string?), string? sort = default(string?), string? host = default(string?), List<string>? uuids = default(List<string>?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'search' is set
            if (search == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'search' when calling SearchApi->SearchPlaylists");
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
            if (uuids != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("multi", "uuids", uuids));
            }

            localVarRequestOptions.Operation = "SearchApi.SearchPlaylists";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>("/api/v1/search/video-playlists", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SearchPlaylists", localVarResponse);
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'search' when calling SearchApi->SearchVideos");
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

            localVarRequestOptions.Operation = "SearchApi.SearchVideos";
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'search' when calling SearchApi->SearchVideos");
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

            localVarRequestOptions.Operation = "SearchApi.SearchVideos";
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

    }
}
