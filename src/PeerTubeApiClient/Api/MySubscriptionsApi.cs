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
    public interface IMySubscriptionsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get if subscriptions exist for my user
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uris">list of uris to check if each is part of the user subscriptions</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Object</returns>
        Object ApiV1UsersMeSubscriptionsExistGet(List<string> uris, int operationIndex = 0);

        /// <summary>
        /// Get if subscriptions exist for my user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uris">list of uris to check if each is part of the user subscriptions</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> ApiV1UsersMeSubscriptionsExistGetWithHttpInfo(List<string> uris, int operationIndex = 0);
        /// <summary>
        /// Get my user subscriptions
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoChannelList</returns>
        VideoChannelList ApiV1UsersMeSubscriptionsGet(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0);

        /// <summary>
        /// Get my user subscriptions
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
        ApiResponse<VideoChannelList> ApiV1UsersMeSubscriptionsGetWithHttpInfo(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0);
        /// <summary>
        /// Add subscription to my user
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1UsersMeSubscriptionsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1UsersMeSubscriptionsPost(ApiV1UsersMeSubscriptionsPostRequest? apiV1UsersMeSubscriptionsPostRequest = default(ApiV1UsersMeSubscriptionsPostRequest?), int operationIndex = 0);

        /// <summary>
        /// Add subscription to my user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1UsersMeSubscriptionsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1UsersMeSubscriptionsPostWithHttpInfo(ApiV1UsersMeSubscriptionsPostRequest? apiV1UsersMeSubscriptionsPostRequest = default(ApiV1UsersMeSubscriptionsPostRequest?), int operationIndex = 0);
        /// <summary>
        /// Delete subscription of my user
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void ApiV1UsersMeSubscriptionsSubscriptionHandleDelete(string subscriptionHandle, int operationIndex = 0);

        /// <summary>
        /// Delete subscription of my user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ApiV1UsersMeSubscriptionsSubscriptionHandleDeleteWithHttpInfo(string subscriptionHandle, int operationIndex = 0);
        /// <summary>
        /// Get subscription of my user
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoChannel</returns>
        VideoChannel ApiV1UsersMeSubscriptionsSubscriptionHandleGet(string subscriptionHandle, int operationIndex = 0);

        /// <summary>
        /// Get subscription of my user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoChannel</returns>
        ApiResponse<VideoChannel> ApiV1UsersMeSubscriptionsSubscriptionHandleGetWithHttpInfo(string subscriptionHandle, int operationIndex = 0);
        /// <summary>
        /// List videos of subscriptions of my user
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
        VideoListResponse ApiV1UsersMeSubscriptionsVideosGet(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0);

        /// <summary>
        /// List videos of subscriptions of my user
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
        ApiResponse<VideoListResponse> ApiV1UsersMeSubscriptionsVideosGetWithHttpInfo(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IMySubscriptionsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get if subscriptions exist for my user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uris">list of uris to check if each is part of the user subscriptions</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Object</returns>
        System.Threading.Tasks.Task<Object> ApiV1UsersMeSubscriptionsExistGetAsync(List<string> uris, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get if subscriptions exist for my user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uris">list of uris to check if each is part of the user subscriptions</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1UsersMeSubscriptionsExistGetWithHttpInfoAsync(List<string> uris, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get my user subscriptions
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
        System.Threading.Tasks.Task<VideoChannelList> ApiV1UsersMeSubscriptionsGetAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get my user subscriptions
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
        System.Threading.Tasks.Task<ApiResponse<VideoChannelList>> ApiV1UsersMeSubscriptionsGetWithHttpInfoAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Add subscription to my user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1UsersMeSubscriptionsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1UsersMeSubscriptionsPostAsync(ApiV1UsersMeSubscriptionsPostRequest? apiV1UsersMeSubscriptionsPostRequest = default(ApiV1UsersMeSubscriptionsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Add subscription to my user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1UsersMeSubscriptionsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1UsersMeSubscriptionsPostWithHttpInfoAsync(ApiV1UsersMeSubscriptionsPostRequest? apiV1UsersMeSubscriptionsPostRequest = default(ApiV1UsersMeSubscriptionsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete subscription of my user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ApiV1UsersMeSubscriptionsSubscriptionHandleDeleteAsync(string subscriptionHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete subscription of my user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ApiV1UsersMeSubscriptionsSubscriptionHandleDeleteWithHttpInfoAsync(string subscriptionHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get subscription of my user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoChannel</returns>
        System.Threading.Tasks.Task<VideoChannel> ApiV1UsersMeSubscriptionsSubscriptionHandleGetAsync(string subscriptionHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get subscription of my user
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoChannel)</returns>
        System.Threading.Tasks.Task<ApiResponse<VideoChannel>> ApiV1UsersMeSubscriptionsSubscriptionHandleGetWithHttpInfoAsync(string subscriptionHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List videos of subscriptions of my user
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
        System.Threading.Tasks.Task<VideoListResponse> ApiV1UsersMeSubscriptionsVideosGetAsync(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List videos of subscriptions of my user
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
        System.Threading.Tasks.Task<ApiResponse<VideoListResponse>> ApiV1UsersMeSubscriptionsVideosGetWithHttpInfoAsync(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IMySubscriptionsApi : IMySubscriptionsApiSync, IMySubscriptionsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class MySubscriptionsApi : IMySubscriptionsApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MySubscriptionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MySubscriptionsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MySubscriptionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MySubscriptionsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="MySubscriptionsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public MySubscriptionsApi(PeerTubeApiClient.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="MySubscriptionsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public MySubscriptionsApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
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
        /// Get if subscriptions exist for my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uris">list of uris to check if each is part of the user subscriptions</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Object</returns>
        public Object ApiV1UsersMeSubscriptionsExistGet(List<string> uris, int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<Object> localVarResponse = ApiV1UsersMeSubscriptionsExistGetWithHttpInfo(uris);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get if subscriptions exist for my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uris">list of uris to check if each is part of the user subscriptions</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1UsersMeSubscriptionsExistGetWithHttpInfo(List<string> uris, int operationIndex = 0)
        {
            // verify the required parameter 'uris' is set
            if (uris == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'uris' when calling MySubscriptionsApi->ApiV1UsersMeSubscriptionsExistGet");
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("multi", "uris", uris));

            localVarRequestOptions.Operation = "MySubscriptionsApi.ApiV1UsersMeSubscriptionsExistGet";
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
            var localVarResponse = this.Client.Get<Object>("/api/v1/users/me/subscriptions/exist", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeSubscriptionsExistGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get if subscriptions exist for my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uris">list of uris to check if each is part of the user subscriptions</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Object</returns>
        public async System.Threading.Tasks.Task<Object> ApiV1UsersMeSubscriptionsExistGetAsync(List<string> uris, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<Object> localVarResponse = await ApiV1UsersMeSubscriptionsExistGetWithHttpInfoAsync(uris, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get if subscriptions exist for my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uris">list of uris to check if each is part of the user subscriptions</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Object)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1UsersMeSubscriptionsExistGetWithHttpInfoAsync(List<string> uris, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'uris' is set
            if (uris == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'uris' when calling MySubscriptionsApi->ApiV1UsersMeSubscriptionsExistGet");
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("multi", "uris", uris));

            localVarRequestOptions.Operation = "MySubscriptionsApi.ApiV1UsersMeSubscriptionsExistGet";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<Object>("/api/v1/users/me/subscriptions/exist", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeSubscriptionsExistGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get my user subscriptions 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoChannelList</returns>
        public VideoChannelList ApiV1UsersMeSubscriptionsGet(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoChannelList> localVarResponse = ApiV1UsersMeSubscriptionsGetWithHttpInfo(start, count, sort);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get my user subscriptions 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoChannelList</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoChannelList> ApiV1UsersMeSubscriptionsGetWithHttpInfo(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0)
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

            localVarRequestOptions.Operation = "MySubscriptionsApi.ApiV1UsersMeSubscriptionsGet";
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
            var localVarResponse = this.Client.Get<VideoChannelList>("/api/v1/users/me/subscriptions", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeSubscriptionsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get my user subscriptions 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoChannelList</returns>
        public async System.Threading.Tasks.Task<VideoChannelList> ApiV1UsersMeSubscriptionsGetAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoChannelList> localVarResponse = await ApiV1UsersMeSubscriptionsGetWithHttpInfoAsync(start, count, sort, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get my user subscriptions 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="start">Offset used to paginate results (optional)</param>
        /// <param name="count">Number of items to return (optional, default to 15)</param>
        /// <param name="sort">Sort column (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoChannelList)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoChannelList>> ApiV1UsersMeSubscriptionsGetWithHttpInfoAsync(int? start = default(int?), int? count = default(int?), string? sort = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.Operation = "MySubscriptionsApi.ApiV1UsersMeSubscriptionsGet";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoChannelList>("/api/v1/users/me/subscriptions", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeSubscriptionsGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add subscription to my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1UsersMeSubscriptionsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1UsersMeSubscriptionsPost(ApiV1UsersMeSubscriptionsPostRequest? apiV1UsersMeSubscriptionsPostRequest = default(ApiV1UsersMeSubscriptionsPostRequest?), int operationIndex = 0)
        {
            ApiV1UsersMeSubscriptionsPostWithHttpInfo(apiV1UsersMeSubscriptionsPostRequest);
        }

        /// <summary>
        /// Add subscription to my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1UsersMeSubscriptionsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1UsersMeSubscriptionsPostWithHttpInfo(ApiV1UsersMeSubscriptionsPostRequest? apiV1UsersMeSubscriptionsPostRequest = default(ApiV1UsersMeSubscriptionsPostRequest?), int operationIndex = 0)
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

            localVarRequestOptions.Data = apiV1UsersMeSubscriptionsPostRequest;

            localVarRequestOptions.Operation = "MySubscriptionsApi.ApiV1UsersMeSubscriptionsPost";
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
            var localVarResponse = this.Client.Post<Object>("/api/v1/users/me/subscriptions", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeSubscriptionsPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Add subscription to my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1UsersMeSubscriptionsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1UsersMeSubscriptionsPostAsync(ApiV1UsersMeSubscriptionsPostRequest? apiV1UsersMeSubscriptionsPostRequest = default(ApiV1UsersMeSubscriptionsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1UsersMeSubscriptionsPostWithHttpInfoAsync(apiV1UsersMeSubscriptionsPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Add subscription to my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apiV1UsersMeSubscriptionsPostRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1UsersMeSubscriptionsPostWithHttpInfoAsync(ApiV1UsersMeSubscriptionsPostRequest? apiV1UsersMeSubscriptionsPostRequest = default(ApiV1UsersMeSubscriptionsPostRequest?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.Data = apiV1UsersMeSubscriptionsPostRequest;

            localVarRequestOptions.Operation = "MySubscriptionsApi.ApiV1UsersMeSubscriptionsPost";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/users/me/subscriptions", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeSubscriptionsPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete subscription of my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void ApiV1UsersMeSubscriptionsSubscriptionHandleDelete(string subscriptionHandle, int operationIndex = 0)
        {
            ApiV1UsersMeSubscriptionsSubscriptionHandleDeleteWithHttpInfo(subscriptionHandle);
        }

        /// <summary>
        /// Delete subscription of my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> ApiV1UsersMeSubscriptionsSubscriptionHandleDeleteWithHttpInfo(string subscriptionHandle, int operationIndex = 0)
        {
            // verify the required parameter 'subscriptionHandle' is set
            if (subscriptionHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'subscriptionHandle' when calling MySubscriptionsApi->ApiV1UsersMeSubscriptionsSubscriptionHandleDelete");
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

            localVarRequestOptions.PathParameters.Add("subscriptionHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(subscriptionHandle)); // path parameter

            localVarRequestOptions.Operation = "MySubscriptionsApi.ApiV1UsersMeSubscriptionsSubscriptionHandleDelete";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/users/me/subscriptions/{subscriptionHandle}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeSubscriptionsSubscriptionHandleDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete subscription of my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ApiV1UsersMeSubscriptionsSubscriptionHandleDeleteAsync(string subscriptionHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ApiV1UsersMeSubscriptionsSubscriptionHandleDeleteWithHttpInfoAsync(subscriptionHandle, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete subscription of my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> ApiV1UsersMeSubscriptionsSubscriptionHandleDeleteWithHttpInfoAsync(string subscriptionHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'subscriptionHandle' is set
            if (subscriptionHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'subscriptionHandle' when calling MySubscriptionsApi->ApiV1UsersMeSubscriptionsSubscriptionHandleDelete");
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

            localVarRequestOptions.PathParameters.Add("subscriptionHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(subscriptionHandle)); // path parameter

            localVarRequestOptions.Operation = "MySubscriptionsApi.ApiV1UsersMeSubscriptionsSubscriptionHandleDelete";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/users/me/subscriptions/{subscriptionHandle}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeSubscriptionsSubscriptionHandleDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get subscription of my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>VideoChannel</returns>
        public VideoChannel ApiV1UsersMeSubscriptionsSubscriptionHandleGet(string subscriptionHandle, int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoChannel> localVarResponse = ApiV1UsersMeSubscriptionsSubscriptionHandleGetWithHttpInfo(subscriptionHandle);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get subscription of my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of VideoChannel</returns>
        public PeerTubeApiClient.Client.ApiResponse<VideoChannel> ApiV1UsersMeSubscriptionsSubscriptionHandleGetWithHttpInfo(string subscriptionHandle, int operationIndex = 0)
        {
            // verify the required parameter 'subscriptionHandle' is set
            if (subscriptionHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'subscriptionHandle' when calling MySubscriptionsApi->ApiV1UsersMeSubscriptionsSubscriptionHandleGet");
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

            localVarRequestOptions.PathParameters.Add("subscriptionHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(subscriptionHandle)); // path parameter

            localVarRequestOptions.Operation = "MySubscriptionsApi.ApiV1UsersMeSubscriptionsSubscriptionHandleGet";
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
            var localVarResponse = this.Client.Get<VideoChannel>("/api/v1/users/me/subscriptions/{subscriptionHandle}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeSubscriptionsSubscriptionHandleGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get subscription of my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VideoChannel</returns>
        public async System.Threading.Tasks.Task<VideoChannel> ApiV1UsersMeSubscriptionsSubscriptionHandleGetAsync(string subscriptionHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoChannel> localVarResponse = await ApiV1UsersMeSubscriptionsSubscriptionHandleGetWithHttpInfoAsync(subscriptionHandle, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get subscription of my user 
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="subscriptionHandle">The subscription handle</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VideoChannel)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoChannel>> ApiV1UsersMeSubscriptionsSubscriptionHandleGetWithHttpInfoAsync(string subscriptionHandle, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'subscriptionHandle' is set
            if (subscriptionHandle == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'subscriptionHandle' when calling MySubscriptionsApi->ApiV1UsersMeSubscriptionsSubscriptionHandleGet");
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

            localVarRequestOptions.PathParameters.Add("subscriptionHandle", PeerTubeApiClient.Client.ClientUtils.ParameterToString(subscriptionHandle)); // path parameter

            localVarRequestOptions.Operation = "MySubscriptionsApi.ApiV1UsersMeSubscriptionsSubscriptionHandleGet";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoChannel>("/api/v1/users/me/subscriptions/{subscriptionHandle}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeSubscriptionsSubscriptionHandleGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List videos of subscriptions of my user 
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
        public VideoListResponse ApiV1UsersMeSubscriptionsVideosGet(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<VideoListResponse> localVarResponse = ApiV1UsersMeSubscriptionsVideosGetWithHttpInfo(categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List videos of subscriptions of my user 
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
        public PeerTubeApiClient.Client.ApiResponse<VideoListResponse> ApiV1UsersMeSubscriptionsVideosGetWithHttpInfo(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0)
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

            localVarRequestOptions.Operation = "MySubscriptionsApi.ApiV1UsersMeSubscriptionsVideosGet";
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
            var localVarResponse = this.Client.Get<VideoListResponse>("/api/v1/users/me/subscriptions/videos", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeSubscriptionsVideosGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List videos of subscriptions of my user 
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
        public async System.Threading.Tasks.Task<VideoListResponse> ApiV1UsersMeSubscriptionsVideosGetAsync(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<VideoListResponse> localVarResponse = await ApiV1UsersMeSubscriptionsVideosGetWithHttpInfoAsync(categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List videos of subscriptions of my user 
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
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<VideoListResponse>> ApiV1UsersMeSubscriptionsVideosGetWithHttpInfoAsync(GetAccountVideosCategoryOneOfParameter? categoryOneOf = default(GetAccountVideosCategoryOneOfParameter?), bool? isLive = default(bool?), GetAccountVideosTagsOneOfParameter? tagsOneOf = default(GetAccountVideosTagsOneOfParameter?), GetAccountVideosTagsAllOfParameter? tagsAllOf = default(GetAccountVideosTagsAllOfParameter?), GetAccountVideosLicenceOneOfParameter? licenceOneOf = default(GetAccountVideosLicenceOneOfParameter?), GetAccountVideosLanguageOneOfParameter? languageOneOf = default(GetAccountVideosLanguageOneOfParameter?), GetAccountVideosTagsAllOfParameter? autoTagOneOf = default(GetAccountVideosTagsAllOfParameter?), string? nsfw = default(string?), bool? isLocal = default(bool?), int? include = default(int?), VideoPrivacySet? privacyOneOf = default(VideoPrivacySet?), bool? hasHLSFiles = default(bool?), bool? hasWebVideoFiles = default(bool?), string? skipCount = default(string?), int? start = default(int?), int? count = default(int?), string? sort = default(string?), bool? excludeAlreadyWatched = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.Operation = "MySubscriptionsApi.ApiV1UsersMeSubscriptionsVideosGet";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<VideoListResponse>("/api/v1/users/me/subscriptions/videos", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ApiV1UsersMeSubscriptionsVideosGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
