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
    public interface IVideoPlaylistsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create a video playlist
        /// </summary>
        /// <remarks>
        /// If the video playlist is set as public, &#x60;videoChannelId&#x60; is mandatory.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="displayName">Video playlist display name</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AddPlaylist200Response</returns>
        AddPlaylist200Response AddPlaylist(string displayName, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0);

        /// <summary>
        /// Create a video playlist
        /// </summary>
        /// <remarks>
        /// If the video playlist is set as public, &#x60;videoChannelId&#x60; is mandatory.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="displayName">Video playlist display name</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AddPlaylist200Response</returns>
        ApiResponse<AddPlaylist200Response> AddPlaylistWithHttpInfo(string displayName, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0);
        /// <summary>
        /// Add a video in a playlist
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="addVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AddVideoPlaylistVideo200Response</returns>
        AddVideoPlaylistVideo200Response AddVideoPlaylistVideo(int playlistId, AddVideoPlaylistVideoRequest? addVideoPlaylistVideoRequest = default(AddVideoPlaylistVideoRequest?), int operationIndex = 0);

        /// <summary>
        /// Add a video in a playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="addVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AddVideoPlaylistVideo200Response</returns>
        ApiResponse<AddVideoPlaylistVideo200Response> AddVideoPlaylistVideoWithHttpInfo(int playlistId, AddVideoPlaylistVideoRequest? addVideoPlaylistVideoRequest = default(AddVideoPlaylistVideoRequest?), int operationIndex = 0);
        /// <summary>
        /// List playlists of an account
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response ApiV1AccountsNameVideoPlaylistsGet(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0);

        /// <summary>
        /// List playlists of an account
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> ApiV1AccountsNameVideoPlaylistsGetWithHttpInfo(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0);
        /// <summary>
        /// Check video exists in my playlists
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoIds">The video ids to check</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1UsersMeVideoPlaylistsVideosExistGet200Response</returns>
        ApiV1UsersMeVideoPlaylistsVideosExistGet200Response ApiV1UsersMeVideoPlaylistsVideosExistGet(List<int> videoIds, int operationIndex = 0);

        /// <summary>
        /// Check video exists in my playlists
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoIds">The video ids to check</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1UsersMeVideoPlaylistsVideosExistGet200Response</returns>
        ApiResponse<ApiV1UsersMeVideoPlaylistsVideosExistGet200Response> ApiV1UsersMeVideoPlaylistsVideosExistGetWithHttpInfo(List<int> videoIds, int operationIndex = 0);
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
        /// Delete a video playlist
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1VideoPlaylistsPlaylistIdDelete(int playlistId, int operationIndex = 0);

        /// <summary>
        /// Delete a video playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1VideoPlaylistsPlaylistIdDeleteWithHttpInfo(int playlistId, int operationIndex = 0);
        /// <summary>
        /// Get a video playlist
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoPlaylist</returns>
        VideoPlaylist ApiV1VideoPlaylistsPlaylistIdGet(int playlistId, int operationIndex = 0);

        /// <summary>
        /// Get a video playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoPlaylist</returns>
        ApiResponse<VideoPlaylist> ApiV1VideoPlaylistsPlaylistIdGetWithHttpInfo(int playlistId, int operationIndex = 0);
        /// <summary>
        /// Update a video playlist
        /// </summary>
        /// <remarks>
        /// If the video playlist is set as public, the playlist must have a assigned channel.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="displayName">Video playlist display name (optional)</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1VideoPlaylistsPlaylistIdPut(int playlistId, string? displayName = default(string?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0);

        /// <summary>
        /// Update a video playlist
        /// </summary>
        /// <remarks>
        /// If the video playlist is set as public, the playlist must have a assigned channel.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="displayName">Video playlist display name (optional)</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1VideoPlaylistsPlaylistIdPutWithHttpInfo(int playlistId, string? displayName = default(string?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0);
        /// <summary>
        /// Delete an element from a playlist
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void DelVideoPlaylistVideo(int playlistId, int playlistElementId, int operationIndex = 0);

        /// <summary>
        /// Delete an element from a playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DelVideoPlaylistVideoWithHttpInfo(int playlistId, int playlistElementId, int operationIndex = 0);
        /// <summary>
        /// List available playlist privacy policies
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetPlaylistPrivacyPolicies(int operationIndex = 0);

        /// <summary>
        /// List available playlist privacy policies
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        ApiResponse<List<string>> GetPlaylistPrivacyPoliciesWithHttpInfo(int operationIndex = 0);
        /// <summary>
        /// List video playlists
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response GetPlaylists(int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0);

        /// <summary>
        /// List video playlists
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> GetPlaylistsWithHttpInfo(int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0);
        /// <summary>
        /// List videos of a playlist
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoListResponse</returns>
        VideoListResponse GetVideoPlaylistVideos(int playlistId, int? start = default(int?), int? count = default(int?), int operationIndex = 0);

        /// <summary>
        /// List videos of a playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoListResponse</returns>
        ApiResponse<VideoListResponse> GetVideoPlaylistVideosWithHttpInfo(int playlistId, int? start = default(int?), int? count = default(int?), int operationIndex = 0);
        /// <summary>
        /// Update a playlist element
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="putVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void PutVideoPlaylistVideo(int playlistId, int playlistElementId, PutVideoPlaylistVideoRequest? putVideoPlaylistVideoRequest = default(PutVideoPlaylistVideoRequest?), int operationIndex = 0);

        /// <summary>
        /// Update a playlist element
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="putVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> PutVideoPlaylistVideoWithHttpInfo(int playlistId, int playlistElementId, PutVideoPlaylistVideoRequest? putVideoPlaylistVideoRequest = default(PutVideoPlaylistVideoRequest?), int operationIndex = 0);
        /// <summary>
        /// Reorder a playlist
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="reorderVideoPlaylistRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ReorderVideoPlaylist(int playlistId, ReorderVideoPlaylistRequest? reorderVideoPlaylistRequest = default(ReorderVideoPlaylistRequest?), int operationIndex = 0);

        /// <summary>
        /// Reorder a playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="reorderVideoPlaylistRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ReorderVideoPlaylistWithHttpInfo(int playlistId, ReorderVideoPlaylistRequest? reorderVideoPlaylistRequest = default(ReorderVideoPlaylistRequest?), int operationIndex = 0);
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
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IVideoPlaylistsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Create a video playlist
        /// </summary>
        /// <remarks>
        /// If the video playlist is set as public, &#x60;videoChannelId&#x60; is mandatory.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="displayName">Video playlist display name</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AddPlaylist200Response</returns>
        System.Threading.Tasks.Task<AddPlaylist200Response> AddPlaylistAsync(string displayName, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a video playlist
        /// </summary>
        /// <remarks>
        /// If the video playlist is set as public, &#x60;videoChannelId&#x60; is mandatory.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="displayName">Video playlist display name</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AddPlaylist200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<AddPlaylist200Response>> AddPlaylistWithHttpInfoAsync(string displayName, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add a video in a playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="addVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AddVideoPlaylistVideo200Response</returns>
        System.Threading.Tasks.Task<AddVideoPlaylistVideo200Response> AddVideoPlaylistVideoAsync(int playlistId, AddVideoPlaylistVideoRequest? addVideoPlaylistVideoRequest = default(AddVideoPlaylistVideoRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add a video in a playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="addVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AddVideoPlaylistVideo200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<AddVideoPlaylistVideo200Response>> AddVideoPlaylistVideoWithHttpInfoAsync(int playlistId, AddVideoPlaylistVideoRequest? addVideoPlaylistVideoRequest = default(AddVideoPlaylistVideoRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List playlists of an account
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        System.Threading.Tasks.Task<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> ApiV1AccountsNameVideoPlaylistsGetAsync(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List playlists of an account
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>> ApiV1AccountsNameVideoPlaylistsGetWithHttpInfoAsync(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Check video exists in my playlists
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoIds">The video ids to check</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1UsersMeVideoPlaylistsVideosExistGet200Response</returns>
        System.Threading.Tasks.Task<ApiV1UsersMeVideoPlaylistsVideosExistGet200Response> ApiV1UsersMeVideoPlaylistsVideosExistGetAsync(List<int> videoIds, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Check video exists in my playlists
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoIds">The video ids to check</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1UsersMeVideoPlaylistsVideosExistGet200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1UsersMeVideoPlaylistsVideosExistGet200Response>> ApiV1UsersMeVideoPlaylistsVideosExistGetWithHttpInfoAsync(List<int> videoIds, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
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
        /// Delete a video playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1VideoPlaylistsPlaylistIdDeleteAsync(int playlistId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete a video playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1VideoPlaylistsPlaylistIdDeleteWithHttpInfoAsync(int playlistId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get a video playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoPlaylist</returns>
        System.Threading.Tasks.Task<VideoPlaylist> ApiV1VideoPlaylistsPlaylistIdGetAsync(int playlistId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get a video playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoPlaylist)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoPlaylist>> ApiV1VideoPlaylistsPlaylistIdGetWithHttpInfoAsync(int playlistId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update a video playlist
        /// </summary>
        /// <remarks>
        /// If the video playlist is set as public, the playlist must have a assigned channel.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="displayName">Video playlist display name (optional)</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1VideoPlaylistsPlaylistIdPutAsync(int playlistId, string? displayName = default(string?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update a video playlist
        /// </summary>
        /// <remarks>
        /// If the video playlist is set as public, the playlist must have a assigned channel.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="displayName">Video playlist display name (optional)</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1VideoPlaylistsPlaylistIdPutWithHttpInfoAsync(int playlistId, string? displayName = default(string?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete an element from a playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DelVideoPlaylistVideoAsync(int playlistId, int playlistElementId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete an element from a playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DelVideoPlaylistVideoWithHttpInfoAsync(int playlistId, int playlistElementId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List available playlist privacy policies
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;string&gt;</returns>
        System.Threading.Tasks.Task<List<string>> GetPlaylistPrivacyPoliciesAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List available playlist privacy policies
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<string>>> GetPlaylistPrivacyPoliciesWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List video playlists
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        System.Threading.Tasks.Task<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> GetPlaylistsAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List video playlists
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>> GetPlaylistsWithHttpInfoAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List videos of a playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoListResponse</returns>
        System.Threading.Tasks.Task<VideoListResponse> GetVideoPlaylistVideosAsync(int playlistId, int? start = default(int?), int? count = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List videos of a playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoListResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoListResponse>> GetVideoPlaylistVideosWithHttpInfoAsync(int playlistId, int? start = default(int?), int? count = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update a playlist element
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="putVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task PutVideoPlaylistVideoAsync(int playlistId, int playlistElementId, PutVideoPlaylistVideoRequest? putVideoPlaylistVideoRequest = default(PutVideoPlaylistVideoRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update a playlist element
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="putVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> PutVideoPlaylistVideoWithHttpInfoAsync(int playlistId, int playlistElementId, PutVideoPlaylistVideoRequest? putVideoPlaylistVideoRequest = default(PutVideoPlaylistVideoRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Reorder a playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="reorderVideoPlaylistRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ReorderVideoPlaylistAsync(int playlistId, ReorderVideoPlaylistRequest? reorderVideoPlaylistRequest = default(ReorderVideoPlaylistRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Reorder a playlist
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="reorderVideoPlaylistRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ReorderVideoPlaylistWithHttpInfoAsync(int playlistId, ReorderVideoPlaylistRequest? reorderVideoPlaylistRequest = default(ReorderVideoPlaylistRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
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
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IVideoPlaylistsApi : IVideoPlaylistsApiSync, IVideoPlaylistsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class VideoPlaylistsApi : IVideoPlaylistsApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoPlaylistsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public VideoPlaylistsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoPlaylistsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public VideoPlaylistsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="VideoPlaylistsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public VideoPlaylistsApi(PeerTubeApiClient.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="VideoPlaylistsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public VideoPlaylistsApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
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
        /// Create a video playlist If the video playlist is set as public, &#x60;videoChannelId&#x60; is mandatory.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="displayName">Video playlist display name</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AddPlaylist200Response</returns>
        public AddPlaylist200Response AddPlaylist(string displayName, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<AddPlaylist200Response> localVarResponse = AddPlaylistWithHttpInfo(displayName, thumbnailfile, privacy, description, videoChannelId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a video playlist If the video playlist is set as public, &#x60;videoChannelId&#x60; is mandatory.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="displayName">Video playlist display name</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AddPlaylist200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<AddPlaylist200Response> AddPlaylistWithHttpInfo(string displayName, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0)
        {
            // verify the required parameter 'displayName' is set
            if (displayName == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'displayName' when calling VideoPlaylistsApi->AddPlaylist");
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

            localVarRequestOptions.FormParameters.Add("displayName", PeerTubeApiClient.Client.ClientUtils.ParameterToString(displayName)); // form parameter
            if (thumbnailfile != null)
            {
                localVarRequestOptions.FileParameters.Add("thumbnailfile", thumbnailfile);
            }
            if (privacy != null)
            {
                localVarRequestOptions.FormParameters.Add("privacy", PeerTubeApiClient.Client.ClientUtils.Serialize(privacy)); // form parameter
            }
            if (description != null)
            {
                localVarRequestOptions.FormParameters.Add("description", PeerTubeApiClient.Client.ClientUtils.ParameterToString(description)); // form parameter
            }
            if (videoChannelId != null)
            {
                localVarRequestOptions.FormParameters.Add("videoChannelId", PeerTubeApiClient.Client.ClientUtils.Serialize(videoChannelId)); // form parameter
            }

            localVarRequestOptions.Operation = "VideoPlaylistsApi.AddPlaylist";
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
            var localVarResponse = this.Client.Post<AddPlaylist200Response>("/api/v1/video-playlists", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("AddPlaylist", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a video playlist If the video playlist is set as public, &#x60;videoChannelId&#x60; is mandatory.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="displayName">Video playlist display name</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AddPlaylist200Response</returns>
        public async System.Threading.Tasks.Task<AddPlaylist200Response> AddPlaylistAsync(string displayName, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<AddPlaylist200Response> localVarResponse = await AddPlaylistWithHttpInfoAsync(displayName, thumbnailfile, privacy, description, videoChannelId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a video playlist If the video playlist is set as public, &#x60;videoChannelId&#x60; is mandatory.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="displayName">Video playlist display name</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AddPlaylist200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<AddPlaylist200Response>> AddPlaylistWithHttpInfoAsync(string displayName, System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'displayName' is set
            if (displayName == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'displayName' when calling VideoPlaylistsApi->AddPlaylist");
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

            localVarRequestOptions.FormParameters.Add("displayName", PeerTubeApiClient.Client.ClientUtils.ParameterToString(displayName)); // form parameter
            if (thumbnailfile != null)
            {
                localVarRequestOptions.FileParameters.Add("thumbnailfile", thumbnailfile);
            }
            if (privacy != null)
            {
                localVarRequestOptions.FormParameters.Add("privacy", PeerTubeApiClient.Client.ClientUtils.Serialize(privacy)); // form parameter
            }
            if (description != null)
            {
                localVarRequestOptions.FormParameters.Add("description", PeerTubeApiClient.Client.ClientUtils.ParameterToString(description)); // form parameter
            }
            if (videoChannelId != null)
            {
                localVarRequestOptions.FormParameters.Add("videoChannelId", PeerTubeApiClient.Client.ClientUtils.Serialize(videoChannelId)); // form parameter
            }

            localVarRequestOptions.Operation = "VideoPlaylistsApi.AddPlaylist";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<AddPlaylist200Response>("/api/v1/video-playlists", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("AddPlaylist", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add a video in a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="addVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>AddVideoPlaylistVideo200Response</returns>
        public AddVideoPlaylistVideo200Response AddVideoPlaylistVideo(int playlistId, AddVideoPlaylistVideoRequest? addVideoPlaylistVideoRequest = default(AddVideoPlaylistVideoRequest?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<AddVideoPlaylistVideo200Response> localVarResponse = AddVideoPlaylistVideoWithHttpInfo(playlistId, addVideoPlaylistVideoRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add a video in a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="addVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of AddVideoPlaylistVideo200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<AddVideoPlaylistVideo200Response> AddVideoPlaylistVideoWithHttpInfo(int playlistId, AddVideoPlaylistVideoRequest? addVideoPlaylistVideoRequest = default(AddVideoPlaylistVideoRequest?), int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter
            localVarRequestOptions.Data = addVideoPlaylistVideoRequest;

            localVarRequestOptions.Operation = "VideoPlaylistsApi.AddVideoPlaylistVideo";
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
            var localVarResponse = this.Client.Post<AddVideoPlaylistVideo200Response>("/api/v1/video-playlists/{playlistId}/videos", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("AddVideoPlaylistVideo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add a video in a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="addVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AddVideoPlaylistVideo200Response</returns>
        public async System.Threading.Tasks.Task<AddVideoPlaylistVideo200Response> AddVideoPlaylistVideoAsync(int playlistId, AddVideoPlaylistVideoRequest? addVideoPlaylistVideoRequest = default(AddVideoPlaylistVideoRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<AddVideoPlaylistVideo200Response> localVarResponse = await AddVideoPlaylistVideoWithHttpInfoAsync(playlistId, addVideoPlaylistVideoRequest, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Add a video in a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="addVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AddVideoPlaylistVideo200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<AddVideoPlaylistVideo200Response>> AddVideoPlaylistVideoWithHttpInfoAsync(int playlistId, AddVideoPlaylistVideoRequest? addVideoPlaylistVideoRequest = default(AddVideoPlaylistVideoRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter
            localVarRequestOptions.Data = addVideoPlaylistVideoRequest;

            localVarRequestOptions.Operation = "VideoPlaylistsApi.AddVideoPlaylistVideo";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<AddVideoPlaylistVideo200Response>("/api/v1/video-playlists/{playlistId}/videos", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("AddVideoPlaylistVideo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List playlists of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        public ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response ApiV1AccountsNameVideoPlaylistsGet(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> localVarResponse = ApiV1AccountsNameVideoPlaylistsGetWithHttpInfo(name, start, count, sort, search, playlistType);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List playlists of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> ApiV1AccountsNameVideoPlaylistsGetWithHttpInfo(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'name' when calling VideoPlaylistsApi->ApiV1AccountsNameVideoPlaylistsGet");
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
            if (search != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "search", search));
            }
            if (playlistType != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "playlistType", playlistType));
            }

            localVarRequestOptions.Operation = "VideoPlaylistsApi.ApiV1AccountsNameVideoPlaylistsGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>("/api/v1/accounts/{name}/video-playlists", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AccountsNameVideoPlaylistsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List playlists of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> ApiV1AccountsNameVideoPlaylistsGetAsync(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> localVarResponse = await ApiV1AccountsNameVideoPlaylistsGetWithHttpInfoAsync(name, start, count, sort, search, playlistType, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List playlists of an account 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="name">The username or handle of the account</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="search">Plain text search, applied to various parts of the model depending on endpoint (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>> ApiV1AccountsNameVideoPlaylistsGetWithHttpInfoAsync(string name, int? start = default(int?), int? count = default(int?), string? sort = default(string?), string? search = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'name' when calling VideoPlaylistsApi->ApiV1AccountsNameVideoPlaylistsGet");
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
            if (search != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "search", search));
            }
            if (playlistType != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "playlistType", playlistType));
            }

            localVarRequestOptions.Operation = "VideoPlaylistsApi.ApiV1AccountsNameVideoPlaylistsGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>("/api/v1/accounts/{name}/video-playlists", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1AccountsNameVideoPlaylistsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Check video exists in my playlists 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoIds">The video ids to check</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1UsersMeVideoPlaylistsVideosExistGet200Response</returns>
        public ApiV1UsersMeVideoPlaylistsVideosExistGet200Response ApiV1UsersMeVideoPlaylistsVideosExistGet(List<int> videoIds, int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeVideoPlaylistsVideosExistGet200Response> localVarResponse = ApiV1UsersMeVideoPlaylistsVideosExistGetWithHttpInfo(videoIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Check video exists in my playlists 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoIds">The video ids to check</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1UsersMeVideoPlaylistsVideosExistGet200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeVideoPlaylistsVideosExistGet200Response> ApiV1UsersMeVideoPlaylistsVideosExistGetWithHttpInfo(List<int> videoIds, int operationIndex = 0)
        {
            // verify the required parameter 'videoIds' is set
            if (videoIds == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'videoIds' when calling VideoPlaylistsApi->ApiV1UsersMeVideoPlaylistsVideosExistGet");
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("multi", "videoIds", videoIds));

            localVarRequestOptions.Operation = "VideoPlaylistsApi.ApiV1UsersMeVideoPlaylistsVideosExistGet";
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
            var localVarResponse = this.Client.Get<ApiV1UsersMeVideoPlaylistsVideosExistGet200Response>("/api/v1/users/me/video-playlists/videos-exist", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeVideoPlaylistsVideosExistGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Check video exists in my playlists 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoIds">The video ids to check</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1UsersMeVideoPlaylistsVideosExistGet200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1UsersMeVideoPlaylistsVideosExistGet200Response> ApiV1UsersMeVideoPlaylistsVideosExistGetAsync(List<int> videoIds, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeVideoPlaylistsVideosExistGet200Response> localVarResponse = await ApiV1UsersMeVideoPlaylistsVideosExistGetWithHttpInfoAsync(videoIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Check video exists in my playlists 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoIds">The video ids to check</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1UsersMeVideoPlaylistsVideosExistGet200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1UsersMeVideoPlaylistsVideosExistGet200Response>> ApiV1UsersMeVideoPlaylistsVideosExistGetWithHttpInfoAsync(List<int> videoIds, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'videoIds' is set
            if (videoIds == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'videoIds' when calling VideoPlaylistsApi->ApiV1UsersMeVideoPlaylistsVideosExistGet");
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("multi", "videoIds", videoIds));

            localVarRequestOptions.Operation = "VideoPlaylistsApi.ApiV1UsersMeVideoPlaylistsVideosExistGet";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApiV1UsersMeVideoPlaylistsVideosExistGet200Response>("/api/v1/users/me/video-playlists/videos-exist", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeVideoPlaylistsVideosExistGet", localVarResponse);
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoPlaylistsApi->ApiV1VideoChannelsChannelHandleVideoPlaylistsGet");
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

            localVarRequestOptions.Operation = "VideoPlaylistsApi.ApiV1VideoChannelsChannelHandleVideoPlaylistsGet";
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'channelHandle' when calling VideoPlaylistsApi->ApiV1VideoChannelsChannelHandleVideoPlaylistsGet");
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

            localVarRequestOptions.Operation = "VideoPlaylistsApi.ApiV1VideoChannelsChannelHandleVideoPlaylistsGet";
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
        /// Delete a video playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1VideoPlaylistsPlaylistIdDelete(int playlistId, int operationIndex = 0)
        {
            ApiV1VideoPlaylistsPlaylistIdDeleteWithHttpInfo(playlistId);
        }

        /// <summary>
        /// Delete a video playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1VideoPlaylistsPlaylistIdDeleteWithHttpInfo(int playlistId, int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter

            localVarRequestOptions.Operation = "VideoPlaylistsApi.ApiV1VideoPlaylistsPlaylistIdDelete";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/video-playlists/{playlistId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoPlaylistsPlaylistIdDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a video playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1VideoPlaylistsPlaylistIdDeleteAsync(int playlistId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1VideoPlaylistsPlaylistIdDeleteWithHttpInfoAsync(playlistId, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a video playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1VideoPlaylistsPlaylistIdDeleteWithHttpInfoAsync(int playlistId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter

            localVarRequestOptions.Operation = "VideoPlaylistsApi.ApiV1VideoPlaylistsPlaylistIdDelete";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/video-playlists/{playlistId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoPlaylistsPlaylistIdDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a video playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoPlaylist</returns>
        public VideoPlaylist ApiV1VideoPlaylistsPlaylistIdGet(int playlistId, int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoPlaylist> localVarResponse = ApiV1VideoPlaylistsPlaylistIdGetWithHttpInfo(playlistId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a video playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoPlaylist</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoPlaylist> ApiV1VideoPlaylistsPlaylistIdGetWithHttpInfo(int playlistId, int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter

            localVarRequestOptions.Operation = "VideoPlaylistsApi.ApiV1VideoPlaylistsPlaylistIdGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<VideoPlaylist>("/api/v1/video-playlists/{playlistId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoPlaylistsPlaylistIdGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a video playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoPlaylist</returns>
        public async System.Threading.Tasks.Task<VideoPlaylist> ApiV1VideoPlaylistsPlaylistIdGetAsync(int playlistId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoPlaylist> localVarResponse = await ApiV1VideoPlaylistsPlaylistIdGetWithHttpInfoAsync(playlistId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a video playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoPlaylist)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoPlaylist>> ApiV1VideoPlaylistsPlaylistIdGetWithHttpInfoAsync(int playlistId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter

            localVarRequestOptions.Operation = "VideoPlaylistsApi.ApiV1VideoPlaylistsPlaylistIdGet";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoPlaylist>("/api/v1/video-playlists/{playlistId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoPlaylistsPlaylistIdGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a video playlist If the video playlist is set as public, the playlist must have a assigned channel.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="displayName">Video playlist display name (optional)</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1VideoPlaylistsPlaylistIdPut(int playlistId, string? displayName = default(string?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0)
        {
            ApiV1VideoPlaylistsPlaylistIdPutWithHttpInfo(playlistId, displayName, thumbnailfile, privacy, description, videoChannelId);
        }

        /// <summary>
        /// Update a video playlist If the video playlist is set as public, the playlist must have a assigned channel.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="displayName">Video playlist display name (optional)</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1VideoPlaylistsPlaylistIdPutWithHttpInfo(int playlistId, string? displayName = default(string?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0)
        {
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter
            if (displayName != null)
            {
                localVarRequestOptions.FormParameters.Add("displayName", PeerTubeApiClient.Client.ClientUtils.ParameterToString(displayName)); // form parameter
            }
            if (thumbnailfile != null)
            {
                localVarRequestOptions.FileParameters.Add("thumbnailfile", thumbnailfile);
            }
            if (privacy != null)
            {
                localVarRequestOptions.FormParameters.Add("privacy", PeerTubeApiClient.Client.ClientUtils.Serialize(privacy)); // form parameter
            }
            if (description != null)
            {
                localVarRequestOptions.FormParameters.Add("description", PeerTubeApiClient.Client.ClientUtils.ParameterToString(description)); // form parameter
            }
            if (videoChannelId != null)
            {
                localVarRequestOptions.FormParameters.Add("videoChannelId", PeerTubeApiClient.Client.ClientUtils.Serialize(videoChannelId)); // form parameter
            }

            localVarRequestOptions.Operation = "VideoPlaylistsApi.ApiV1VideoPlaylistsPlaylistIdPut";
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
            var localVarResponse = this.Client.Put<Object>("/api/v1/video-playlists/{playlistId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoPlaylistsPlaylistIdPut", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a video playlist If the video playlist is set as public, the playlist must have a assigned channel.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="displayName">Video playlist display name (optional)</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1VideoPlaylistsPlaylistIdPutAsync(int playlistId, string? displayName = default(string?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1VideoPlaylistsPlaylistIdPutWithHttpInfoAsync(playlistId, displayName, thumbnailfile, privacy, description, videoChannelId, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a video playlist If the video playlist is set as public, the playlist must have a assigned channel.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="displayName">Video playlist display name (optional)</param>
        /// <param name="thumbnailfile">Video playlist thumbnail file (optional)</param>
        /// <param name="privacy"> (optional)</param>
        /// <param name="description">Video playlist description (optional)</param>
        /// <param name="videoChannelId">Video channel in which the playlist will be published (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1VideoPlaylistsPlaylistIdPutWithHttpInfoAsync(int playlistId, string? displayName = default(string?), System.IO.Stream? thumbnailfile = default(System.IO.Stream?), VideoPlaylistPrivacySet? privacy = default(VideoPlaylistPrivacySet?), string? description = default(string?), int? videoChannelId = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter
            if (displayName != null)
            {
                localVarRequestOptions.FormParameters.Add("displayName", PeerTubeApiClient.Client.ClientUtils.ParameterToString(displayName)); // form parameter
            }
            if (thumbnailfile != null)
            {
                localVarRequestOptions.FileParameters.Add("thumbnailfile", thumbnailfile);
            }
            if (privacy != null)
            {
                localVarRequestOptions.FormParameters.Add("privacy", PeerTubeApiClient.Client.ClientUtils.Serialize(privacy)); // form parameter
            }
            if (description != null)
            {
                localVarRequestOptions.FormParameters.Add("description", PeerTubeApiClient.Client.ClientUtils.ParameterToString(description)); // form parameter
            }
            if (videoChannelId != null)
            {
                localVarRequestOptions.FormParameters.Add("videoChannelId", PeerTubeApiClient.Client.ClientUtils.Serialize(videoChannelId)); // form parameter
            }

            localVarRequestOptions.Operation = "VideoPlaylistsApi.ApiV1VideoPlaylistsPlaylistIdPut";
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
            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/api/v1/video-playlists/{playlistId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1VideoPlaylistsPlaylistIdPut", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete an element from a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void DelVideoPlaylistVideo(int playlistId, int playlistElementId, int operationIndex = 0)
        {
            DelVideoPlaylistVideoWithHttpInfo(playlistId, playlistElementId);
        }

        /// <summary>
        /// Delete an element from a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> DelVideoPlaylistVideoWithHttpInfo(int playlistId, int playlistElementId, int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter
            localVarRequestOptions.PathParameters.Add("playlistElementId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistElementId)); // path parameter

            localVarRequestOptions.Operation = "VideoPlaylistsApi.DelVideoPlaylistVideo";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/video-playlists/{playlistId}/videos/{playlistElementId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DelVideoPlaylistVideo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete an element from a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DelVideoPlaylistVideoAsync(int playlistId, int playlistElementId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await DelVideoPlaylistVideoWithHttpInfoAsync(playlistId, playlistElementId, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete an element from a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> DelVideoPlaylistVideoWithHttpInfoAsync(int playlistId, int playlistElementId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter
            localVarRequestOptions.PathParameters.Add("playlistElementId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistElementId)); // path parameter

            localVarRequestOptions.Operation = "VideoPlaylistsApi.DelVideoPlaylistVideo";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/video-playlists/{playlistId}/videos/{playlistElementId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DelVideoPlaylistVideo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List available playlist privacy policies 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;string&gt;</returns>
        public List<string> GetPlaylistPrivacyPolicies(int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<List<string>> localVarResponse = GetPlaylistPrivacyPoliciesWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// List available playlist privacy policies 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;string&gt;</returns>
        public PeerTubeApiClient.Client.ApiResponse<List<string>> GetPlaylistPrivacyPoliciesWithHttpInfo(int operationIndex = 0)
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


            localVarRequestOptions.Operation = "VideoPlaylistsApi.GetPlaylistPrivacyPolicies";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<string>>("/api/v1/video-playlists/privacies", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetPlaylistPrivacyPolicies", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List available playlist privacy policies 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;string&gt;</returns>
        public async System.Threading.Tasks.Task<List<string>> GetPlaylistPrivacyPoliciesAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<List<string>> localVarResponse = await GetPlaylistPrivacyPoliciesWithHttpInfoAsync(operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List available playlist privacy policies 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;string&gt;)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<List<string>>> GetPlaylistPrivacyPoliciesWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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


            localVarRequestOptions.Operation = "VideoPlaylistsApi.GetPlaylistPrivacyPolicies";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<string>>("/api/v1/video-playlists/privacies", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetPlaylistPrivacyPolicies", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List video playlists 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        public ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response GetPlaylists(int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> localVarResponse = GetPlaylistsWithHttpInfo(start, count, sort, playlistType);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List video playlists 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> GetPlaylistsWithHttpInfo(int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0)
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
            if (playlistType != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "playlistType", playlistType));
            }

            localVarRequestOptions.Operation = "VideoPlaylistsApi.GetPlaylists";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>("/api/v1/video-playlists", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetPlaylists", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List video playlists 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response</returns>
        public async System.Threading.Tasks.Task<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> GetPlaylistsAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response> localVarResponse = await GetPlaylistsWithHttpInfoAsync(start, count, sort, playlistType, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List video playlists 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="playlistType"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>> GetPlaylistsWithHttpInfoAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), VideoPlaylistTypeSet? playlistType = default(VideoPlaylistTypeSet?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            if (playlistType != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "playlistType", playlistType));
            }

            localVarRequestOptions.Operation = "VideoPlaylistsApi.GetPlaylists";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<ApiV1VideoChannelsChannelHandleVideoPlaylistsGet200Response>("/api/v1/video-playlists", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetPlaylists", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List videos of a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoListResponse</returns>
        public VideoListResponse GetVideoPlaylistVideos(int playlistId, int? start = default(int?), int? count = default(int?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoListResponse> localVarResponse = GetVideoPlaylistVideosWithHttpInfo(playlistId, start, count);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List videos of a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoListResponse</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoListResponse> GetVideoPlaylistVideosWithHttpInfo(int playlistId, int? start = default(int?), int? count = default(int?), int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (count != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "count", count));
            }

            localVarRequestOptions.Operation = "VideoPlaylistsApi.GetVideoPlaylistVideos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<VideoListResponse>("/api/v1/video-playlists/{playlistId}/videos", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoPlaylistVideos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List videos of a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoListResponse</returns>
        public async System.Threading.Tasks.Task<VideoListResponse> GetVideoPlaylistVideosAsync(int playlistId, int? start = default(int?), int? count = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoListResponse> localVarResponse = await GetVideoPlaylistVideosWithHttpInfoAsync(playlistId, start, count, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List videos of a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoListResponse)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoListResponse>> GetVideoPlaylistVideosWithHttpInfoAsync(int playlistId, int? start = default(int?), int? count = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter
            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (count != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "count", count));
            }

            localVarRequestOptions.Operation = "VideoPlaylistsApi.GetVideoPlaylistVideos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoListResponse>("/api/v1/video-playlists/{playlistId}/videos", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideoPlaylistVideos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a playlist element 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="putVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void PutVideoPlaylistVideo(int playlistId, int playlistElementId, PutVideoPlaylistVideoRequest? putVideoPlaylistVideoRequest = default(PutVideoPlaylistVideoRequest?), int operationIndex = 0)
        {
            PutVideoPlaylistVideoWithHttpInfo(playlistId, playlistElementId, putVideoPlaylistVideoRequest);
        }

        /// <summary>
        /// Update a playlist element 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="putVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> PutVideoPlaylistVideoWithHttpInfo(int playlistId, int playlistElementId, PutVideoPlaylistVideoRequest? putVideoPlaylistVideoRequest = default(PutVideoPlaylistVideoRequest?), int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter
            localVarRequestOptions.PathParameters.Add("playlistElementId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistElementId)); // path parameter
            localVarRequestOptions.Data = putVideoPlaylistVideoRequest;

            localVarRequestOptions.Operation = "VideoPlaylistsApi.PutVideoPlaylistVideo";
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
            var localVarResponse = this.Client.Put<Object>("/api/v1/video-playlists/{playlistId}/videos/{playlistElementId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PutVideoPlaylistVideo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a playlist element 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="putVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task PutVideoPlaylistVideoAsync(int playlistId, int playlistElementId, PutVideoPlaylistVideoRequest? putVideoPlaylistVideoRequest = default(PutVideoPlaylistVideoRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await PutVideoPlaylistVideoWithHttpInfoAsync(playlistId, playlistElementId, putVideoPlaylistVideoRequest, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a playlist element 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="playlistElementId">Playlist element id</param>
        /// <param name="putVideoPlaylistVideoRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> PutVideoPlaylistVideoWithHttpInfoAsync(int playlistId, int playlistElementId, PutVideoPlaylistVideoRequest? putVideoPlaylistVideoRequest = default(PutVideoPlaylistVideoRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter
            localVarRequestOptions.PathParameters.Add("playlistElementId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistElementId)); // path parameter
            localVarRequestOptions.Data = putVideoPlaylistVideoRequest;

            localVarRequestOptions.Operation = "VideoPlaylistsApi.PutVideoPlaylistVideo";
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
            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/api/v1/video-playlists/{playlistId}/videos/{playlistElementId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PutVideoPlaylistVideo", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Reorder a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="reorderVideoPlaylistRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ReorderVideoPlaylist(int playlistId, ReorderVideoPlaylistRequest? reorderVideoPlaylistRequest = default(ReorderVideoPlaylistRequest?), int operationIndex = 0)
        {
            ReorderVideoPlaylistWithHttpInfo(playlistId, reorderVideoPlaylistRequest);
        }

        /// <summary>
        /// Reorder a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="reorderVideoPlaylistRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ReorderVideoPlaylistWithHttpInfo(int playlistId, ReorderVideoPlaylistRequest? reorderVideoPlaylistRequest = default(ReorderVideoPlaylistRequest?), int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter
            localVarRequestOptions.Data = reorderVideoPlaylistRequest;

            localVarRequestOptions.Operation = "VideoPlaylistsApi.ReorderVideoPlaylist";
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
            var localVarResponse = this.Client.Post<Object>("/api/v1/video-playlists/{playlistId}/videos/reorder", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReorderVideoPlaylist", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Reorder a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="reorderVideoPlaylistRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ReorderVideoPlaylistAsync(int playlistId, ReorderVideoPlaylistRequest? reorderVideoPlaylistRequest = default(ReorderVideoPlaylistRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ReorderVideoPlaylistWithHttpInfoAsync(playlistId, reorderVideoPlaylistRequest, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Reorder a playlist 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="playlistId">Playlist id</param>
        /// <param name="reorderVideoPlaylistRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ReorderVideoPlaylistWithHttpInfoAsync(int playlistId, ReorderVideoPlaylistRequest? reorderVideoPlaylistRequest = default(ReorderVideoPlaylistRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("playlistId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(playlistId)); // path parameter
            localVarRequestOptions.Data = reorderVideoPlaylistRequest;

            localVarRequestOptions.Operation = "VideoPlaylistsApi.ReorderVideoPlaylist";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/video-playlists/{playlistId}/videos/reorder", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReorderVideoPlaylist", localVarResponse);
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'search' when calling VideoPlaylistsApi->SearchPlaylists");
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

            localVarRequestOptions.Operation = "VideoPlaylistsApi.SearchPlaylists";
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
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'search' when calling VideoPlaylistsApi->SearchPlaylists");
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

            localVarRequestOptions.Operation = "VideoPlaylistsApi.SearchPlaylists";
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

    }
}
