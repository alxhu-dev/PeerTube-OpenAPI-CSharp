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
    public interface IVideoFeedsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Comments on videos feeds
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="videoId">limit listing comments to a specific video (optional)</param>
        /// <param name="accountId">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="accountName">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;VideoCommentsForXMLInner&gt;</returns>
        List<VideoCommentsForXMLInner> GetSyndicatedComments(string format, string? videoId = default(string?), string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), int operationIndex = 0);

        /// <summary>
        /// Comments on videos feeds
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="videoId">limit listing comments to a specific video (optional)</param>
        /// <param name="accountId">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="accountName">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;VideoCommentsForXMLInner&gt;</returns>
        ApiResponse<List<VideoCommentsForXMLInner>> GetSyndicatedCommentsWithHttpInfo(string format, string? videoId = default(string?), string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), int operationIndex = 0);
        /// <summary>
        /// Videos of subscriptions feeds
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account</param>
        /// <param name="token">private token allowing access</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;VideosForXMLInner&gt;</returns>
        List<VideosForXMLInner> GetSyndicatedSubscriptionVideos(string format, string accountId, string token, string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0);

        /// <summary>
        /// Videos of subscriptions feeds
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account</param>
        /// <param name="token">private token allowing access</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;VideosForXMLInner&gt;</returns>
        ApiResponse<List<VideosForXMLInner>> GetSyndicatedSubscriptionVideosWithHttpInfo(string format, string accountId, string token, string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0);
        /// <summary>
        /// Common videos feeds
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account (optional)</param>
        /// <param name="accountName">limit listing to a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing to a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing to a specific video channel (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;VideosForXMLInner&gt;</returns>
        List<VideosForXMLInner> GetSyndicatedVideos(string format, string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0);

        /// <summary>
        /// Common videos feeds
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account (optional)</param>
        /// <param name="accountName">limit listing to a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing to a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing to a specific video channel (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;VideosForXMLInner&gt;</returns>
        ApiResponse<List<VideosForXMLInner>> GetSyndicatedVideosWithHttpInfo(string format, string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0);
        /// <summary>
        /// Videos podcast feed
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelId">Limit listing to a specific video channel</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void GetVideosPodcastFeed(string videoChannelId, int operationIndex = 0);

        /// <summary>
        /// Videos podcast feed
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelId">Limit listing to a specific video channel</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> GetVideosPodcastFeedWithHttpInfo(string videoChannelId, int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IVideoFeedsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Comments on videos feeds
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="videoId">limit listing comments to a specific video (optional)</param>
        /// <param name="accountId">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="accountName">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;VideoCommentsForXMLInner&gt;</returns>
        System.Threading.Tasks.Task<List<VideoCommentsForXMLInner>> GetSyndicatedCommentsAsync(string format, string? videoId = default(string?), string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Comments on videos feeds
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="videoId">limit listing comments to a specific video (optional)</param>
        /// <param name="accountId">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="accountName">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;VideoCommentsForXMLInner&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<VideoCommentsForXMLInner>>> GetSyndicatedCommentsWithHttpInfoAsync(string format, string? videoId = default(string?), string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Videos of subscriptions feeds
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account</param>
        /// <param name="token">private token allowing access</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;VideosForXMLInner&gt;</returns>
        System.Threading.Tasks.Task<List<VideosForXMLInner>> GetSyndicatedSubscriptionVideosAsync(string format, string accountId, string token, string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Videos of subscriptions feeds
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account</param>
        /// <param name="token">private token allowing access</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;VideosForXMLInner&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<VideosForXMLInner>>> GetSyndicatedSubscriptionVideosWithHttpInfoAsync(string format, string accountId, string token, string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Common videos feeds
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account (optional)</param>
        /// <param name="accountName">limit listing to a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing to a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing to a specific video channel (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;VideosForXMLInner&gt;</returns>
        System.Threading.Tasks.Task<List<VideosForXMLInner>> GetSyndicatedVideosAsync(string format, string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Common videos feeds
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account (optional)</param>
        /// <param name="accountName">limit listing to a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing to a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing to a specific video channel (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;VideosForXMLInner&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<VideosForXMLInner>>> GetSyndicatedVideosWithHttpInfoAsync(string format, string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Videos podcast feed
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelId">Limit listing to a specific video channel</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task GetVideosPodcastFeedAsync(string videoChannelId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Videos podcast feed
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelId">Limit listing to a specific video channel</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> GetVideosPodcastFeedWithHttpInfoAsync(string videoChannelId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IVideoFeedsApi : IVideoFeedsApiSync, IVideoFeedsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class VideoFeedsApi : IVideoFeedsApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoFeedsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public VideoFeedsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoFeedsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public VideoFeedsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="VideoFeedsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public VideoFeedsApi(PeerTubeApiClient.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="VideoFeedsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public VideoFeedsApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
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
        /// Comments on videos feeds 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="videoId">limit listing comments to a specific video (optional)</param>
        /// <param name="accountId">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="accountName">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;VideoCommentsForXMLInner&gt;</returns>
        public List<VideoCommentsForXMLInner> GetSyndicatedComments(string format, string? videoId = default(string?), string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<List<VideoCommentsForXMLInner>> localVarResponse = GetSyndicatedCommentsWithHttpInfo(format, videoId, accountId, accountName, videoChannelId, videoChannelName);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Comments on videos feeds 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="videoId">limit listing comments to a specific video (optional)</param>
        /// <param name="accountId">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="accountName">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;VideoCommentsForXMLInner&gt;</returns>
        public PeerTubeApiClient.Client.ApiResponse<List<VideoCommentsForXMLInner>> GetSyndicatedCommentsWithHttpInfo(string format, string? videoId = default(string?), string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), int operationIndex = 0)
        {
            // verify the required parameter 'format' is set
            if (format == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'format' when calling VideoFeedsApi->GetSyndicatedComments");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/xml",
                "application/rss+xml",
                "text/xml",
                "application/atom+xml",
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

            localVarRequestOptions.PathParameters.Add("format", PeerTubeApiClient.Client.ClientUtils.ParameterToString(format)); // path parameter
            if (videoId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoId", videoId));
            }
            if (accountId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            }
            if (accountName != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "accountName", accountName));
            }
            if (videoChannelId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoChannelId", videoChannelId));
            }
            if (videoChannelName != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoChannelName", videoChannelName));
            }

            localVarRequestOptions.Operation = "VideoFeedsApi.GetSyndicatedComments";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<VideoCommentsForXMLInner>>("/feeds/video-comments.{format}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSyndicatedComments", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Comments on videos feeds 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="videoId">limit listing comments to a specific video (optional)</param>
        /// <param name="accountId">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="accountName">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;VideoCommentsForXMLInner&gt;</returns>
        public async System.Threading.Tasks.Task<List<VideoCommentsForXMLInner>> GetSyndicatedCommentsAsync(string format, string? videoId = default(string?), string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<List<VideoCommentsForXMLInner>> localVarResponse = await GetSyndicatedCommentsWithHttpInfoAsync(format, videoId, accountId, accountName, videoChannelId, videoChannelName, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Comments on videos feeds 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="videoId">limit listing comments to a specific video (optional)</param>
        /// <param name="accountId">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="accountName">limit listing comments to videos of a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing comments to videos of a specific video channel (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;VideoCommentsForXMLInner&gt;)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<List<VideoCommentsForXMLInner>>> GetSyndicatedCommentsWithHttpInfoAsync(string format, string? videoId = default(string?), string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'format' is set
            if (format == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'format' when calling VideoFeedsApi->GetSyndicatedComments");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/xml",
                "application/rss+xml",
                "text/xml",
                "application/atom+xml",
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

            localVarRequestOptions.PathParameters.Add("format", PeerTubeApiClient.Client.ClientUtils.ParameterToString(format)); // path parameter
            if (videoId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoId", videoId));
            }
            if (accountId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            }
            if (accountName != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "accountName", accountName));
            }
            if (videoChannelId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoChannelId", videoChannelId));
            }
            if (videoChannelName != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoChannelName", videoChannelName));
            }

            localVarRequestOptions.Operation = "VideoFeedsApi.GetSyndicatedComments";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<VideoCommentsForXMLInner>>("/feeds/video-comments.{format}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSyndicatedComments", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Videos of subscriptions feeds 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account</param>
        /// <param name="token">private token allowing access</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;VideosForXMLInner&gt;</returns>
        public List<VideosForXMLInner> GetSyndicatedSubscriptionVideos(string format, string accountId, string token, string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<List<VideosForXMLInner>> localVarResponse = GetSyndicatedSubscriptionVideosWithHttpInfo(format, accountId, token, sort, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Videos of subscriptions feeds 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account</param>
        /// <param name="token">private token allowing access</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;VideosForXMLInner&gt;</returns>
        public PeerTubeApiClient.Client.ApiResponse<List<VideosForXMLInner>> GetSyndicatedSubscriptionVideosWithHttpInfo(string format, string accountId, string token, string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0)
        {
            // verify the required parameter 'format' is set
            if (format == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'format' when calling VideoFeedsApi->GetSyndicatedSubscriptionVideos");
            }

            // verify the required parameter 'accountId' is set
            if (accountId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'accountId' when calling VideoFeedsApi->GetSyndicatedSubscriptionVideos");
            }

            // verify the required parameter 'token' is set
            if (token == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'token' when calling VideoFeedsApi->GetSyndicatedSubscriptionVideos");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/xml",
                "application/rss+xml",
                "text/xml",
                "application/atom+xml",
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

            localVarRequestOptions.PathParameters.Add("format", PeerTubeApiClient.Client.ClientUtils.ParameterToString(format)); // path parameter
            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "token", token));
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
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

            localVarRequestOptions.Operation = "VideoFeedsApi.GetSyndicatedSubscriptionVideos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<VideosForXMLInner>>("/feeds/subscriptions.{format}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSyndicatedSubscriptionVideos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Videos of subscriptions feeds 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account</param>
        /// <param name="token">private token allowing access</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;VideosForXMLInner&gt;</returns>
        public async System.Threading.Tasks.Task<List<VideosForXMLInner>> GetSyndicatedSubscriptionVideosAsync(string format, string accountId, string token, string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<List<VideosForXMLInner>> localVarResponse = await GetSyndicatedSubscriptionVideosWithHttpInfoAsync(format, accountId, token, sort, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Videos of subscriptions feeds 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account</param>
        /// <param name="token">private token allowing access</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;VideosForXMLInner&gt;)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<List<VideosForXMLInner>>> GetSyndicatedSubscriptionVideosWithHttpInfoAsync(string format, string accountId, string token, string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'format' is set
            if (format == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'format' when calling VideoFeedsApi->GetSyndicatedSubscriptionVideos");
            }

            // verify the required parameter 'accountId' is set
            if (accountId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'accountId' when calling VideoFeedsApi->GetSyndicatedSubscriptionVideos");
            }

            // verify the required parameter 'token' is set
            if (token == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'token' when calling VideoFeedsApi->GetSyndicatedSubscriptionVideos");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/xml",
                "application/rss+xml",
                "text/xml",
                "application/atom+xml",
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

            localVarRequestOptions.PathParameters.Add("format", PeerTubeApiClient.Client.ClientUtils.ParameterToString(format)); // path parameter
            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "token", token));
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
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

            localVarRequestOptions.Operation = "VideoFeedsApi.GetSyndicatedSubscriptionVideos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<VideosForXMLInner>>("/feeds/subscriptions.{format}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSyndicatedSubscriptionVideos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Common videos feeds 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account (optional)</param>
        /// <param name="accountName">limit listing to a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing to a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing to a specific video channel (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;VideosForXMLInner&gt;</returns>
        public List<VideosForXMLInner> GetSyndicatedVideos(string format, string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<List<VideosForXMLInner>> localVarResponse = GetSyndicatedVideosWithHttpInfo(format, accountId, accountName, videoChannelId, videoChannelName, sort, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Common videos feeds 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account (optional)</param>
        /// <param name="accountName">limit listing to a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing to a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing to a specific video channel (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;VideosForXMLInner&gt;</returns>
        public PeerTubeApiClient.Client.ApiResponse<List<VideosForXMLInner>> GetSyndicatedVideosWithHttpInfo(string format, string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0)
        {
            // verify the required parameter 'format' is set
            if (format == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'format' when calling VideoFeedsApi->GetSyndicatedVideos");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/xml",
                "application/rss+xml",
                "text/xml",
                "application/atom+xml",
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

            localVarRequestOptions.PathParameters.Add("format", PeerTubeApiClient.Client.ClientUtils.ParameterToString(format)); // path parameter
            if (accountId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            }
            if (accountName != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "accountName", accountName));
            }
            if (videoChannelId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoChannelId", videoChannelId));
            }
            if (videoChannelName != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoChannelName", videoChannelName));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
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

            localVarRequestOptions.Operation = "VideoFeedsApi.GetSyndicatedVideos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<VideosForXMLInner>>("/feeds/videos.{format}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSyndicatedVideos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Common videos feeds 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account (optional)</param>
        /// <param name="accountName">limit listing to a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing to a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing to a specific video channel (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;VideosForXMLInner&gt;</returns>
        public async System.Threading.Tasks.Task<List<VideosForXMLInner>> GetSyndicatedVideosAsync(string format, string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<List<VideosForXMLInner>> localVarResponse = await GetSyndicatedVideosWithHttpInfoAsync(format, accountId, accountName, videoChannelId, videoChannelName, sort, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Common videos feeds 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="format">format expected (we focus on making &#x60;rss&#x60; the most featureful ; it serves [Media RSS](https://www.rssboard.org/media-rss))</param>
        /// <param name="accountId">limit listing to a specific account (optional)</param>
        /// <param name="accountName">limit listing to a specific account (optional)</param>
        /// <param name="videoChannelId">limit listing to a specific video channel (optional)</param>
        /// <param name="videoChannelName">limit listing to a specific video channel (optional)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="nsfw">whether to include nsfw videos, if any (optional)</param>
        /// <param name="isLocal">**PeerTube &gt;&#x3D; 4.0** Display only local or remote objects (optional)</param>
        /// <param name="include">**PeerTube &gt;&#x3D; 4.0** Include additional videos in results (can be combined using bitwise or operator) - &#x60;0&#x60; NONE - &#x60;1&#x60; NOT_PUBLISHED_STATE - &#x60;2&#x60; BLACKLISTED - &#x60;4&#x60; BLOCKED_OWNER - &#x60;8&#x60; FILES - &#x60;16&#x60; CAPTIONS - &#x60;32&#x60; VIDEO SOURCE  (optional)</param>
        /// <param name="privacyOneOf">**PeerTube &gt;&#x3D; 4.0** Display only videos in this specific privacy/privacies (optional)</param>
        /// <param name="hasHLSFiles">**PeerTube &gt;&#x3D; 4.0** Display only videos that have HLS files (optional)</param>
        /// <param name="hasWebVideoFiles">**PeerTube &gt;&#x3D; 6.0** Display only videos that have Web Video files (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;VideosForXMLInner&gt;)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<List<VideosForXMLInner>>> GetSyndicatedVideosWithHttpInfoAsync(string format, string? accountId = default(string?), string? accountName = default(string?), string? videoChannelId = default(string?), string? videoChannelName = default(string?), string? sort = default(string?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'format' is set
            if (format == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'format' when calling VideoFeedsApi->GetSyndicatedVideos");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/xml",
                "application/rss+xml",
                "text/xml",
                "application/atom+xml",
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

            localVarRequestOptions.PathParameters.Add("format", PeerTubeApiClient.Client.ClientUtils.ParameterToString(format)); // path parameter
            if (accountId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            }
            if (accountName != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "accountName", accountName));
            }
            if (videoChannelId != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoChannelId", videoChannelId));
            }
            if (videoChannelName != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoChannelName", videoChannelName));
            }
            if (sort != null)
            {
                localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "sort", sort));
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

            localVarRequestOptions.Operation = "VideoFeedsApi.GetSyndicatedVideos";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<VideosForXMLInner>>("/feeds/videos.{format}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSyndicatedVideos", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Videos podcast feed 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelId">Limit listing to a specific video channel</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void GetVideosPodcastFeed(string videoChannelId, int operationIndex = 0)
        {
            GetVideosPodcastFeedWithHttpInfo(videoChannelId);
        }

        /// <summary>
        /// Videos podcast feed 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelId">Limit listing to a specific video channel</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> GetVideosPodcastFeedWithHttpInfo(string videoChannelId, int operationIndex = 0)
        {
            // verify the required parameter 'videoChannelId' is set
            if (videoChannelId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'videoChannelId' when calling VideoFeedsApi->GetVideosPodcastFeed");
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoChannelId", videoChannelId));

            localVarRequestOptions.Operation = "VideoFeedsApi.GetVideosPodcastFeed";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<Object>("/feeds/podcast/videos.xml", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideosPodcastFeed", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Videos podcast feed 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelId">Limit listing to a specific video channel</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task GetVideosPodcastFeedAsync(string videoChannelId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await GetVideosPodcastFeedWithHttpInfoAsync(videoChannelId, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Videos podcast feed 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="videoChannelId">Limit listing to a specific video channel</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> GetVideosPodcastFeedWithHttpInfoAsync(string videoChannelId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'videoChannelId' is set
            if (videoChannelId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'videoChannelId' when calling VideoFeedsApi->GetVideosPodcastFeed");
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "videoChannelId", videoChannelId));

            localVarRequestOptions.Operation = "VideoFeedsApi.GetVideosPodcastFeed";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/feeds/podcast/videos.xml", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetVideosPodcastFeed", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
