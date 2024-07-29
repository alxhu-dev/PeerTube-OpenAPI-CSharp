/*
 * PeerTube
 *
 * The PeerTube API is built on HTTP(S) and is RESTful. You can use your favorite HTTP/REST library for your programming language to use PeerTube. The spec API is fully compatible with [openapi-generator](https://github.com/OpenAPITools/openapi-generator/wiki/API-client-generator-HOWTO) which generates a client SDK in the language of your choice - we generate some client SDKs automatically:  - [Python](https://framagit.org/framasoft/peertube/clients/python) - [Go](https://framagit.org/framasoft/peertube/clients/go) - [Kotlin](https://framagit.org/framasoft/peertube/clients/kotlin)  See the [REST API quick start](https://docs.joinpeertube.org/api/rest-getting-started) for a few examples of using the PeerTube API.  # Authentication  When you sign up for an account on a PeerTube instance, you are given the possibility to generate sessions on it, and authenticate there using an access token. Only __one access token can currently be used at a time__.  ## Roles  Accounts are given permissions based on their role. There are three roles on PeerTube: Administrator, Moderator, and User. See the [roles guide](https://docs.joinpeertube.org/admin/managing-users#roles) for a detail of their permissions.  # Errors  The API uses standard HTTP status codes to indicate the success or failure of the API call, completed by a [RFC7807-compliant](https://tools.ietf.org/html/rfc7807) response body.  ``` HTTP 1.1 404 Not Found Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Video not found\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"status\": 404,   \"title\": \"Not Found\",   \"type\": \"about:blank\" } ```  We provide error `type` (following RFC7807) and `code` (internal PeerTube code) values for [a growing number of cases](https://github.com/Chocobozzz/PeerTube/blob/develop/packages/models/src/server/server-error-code.enum.ts), but it is still optional. Types are used to disambiguate errors that bear the same status code and are non-obvious:  ``` HTTP 1.1 403 Forbidden Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Cannot get this video regarding follow constraints\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"status\": 403,   \"title\": \"Forbidden\",   \"type\": \"https://docs.joinpeertube.org/api-rest-reference.html#section/Errors/does_not_respect_follow_constraints\" } ```  Here a 403 error could otherwise mean that the video is private or blocklisted.  ### Validation errors  Each parameter is evaluated on its own against a set of rules before the route validator proceeds with potential testing involving parameter combinations. Errors coming from validation errors appear earlier and benefit from a more detailed error description:  ``` HTTP 1.1 400 Bad Request Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Incorrect request parameters: id\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"instance\": \"/api/v1/videos/9c9de5e8-0a1e-484a-b099-e80766180\",   \"invalid-params\": {     \"id\": {       \"location\": \"params\",       \"msg\": \"Invalid value\",       \"param\": \"id\",       \"value\": \"9c9de5e8-0a1e-484a-b099-e80766180\"     }   },   \"status\": 400,   \"title\": \"Bad Request\",   \"type\": \"about:blank\" } ```  Where `id` is the name of the field concerned by the error, within the route definition. `invalid-params.<field>.location` can be either 'params', 'body', 'header', 'query' or 'cookies', and `invalid-params.<field>.value` reports the value that didn't pass validation whose `invalid-params.<field>.msg` is about.  ### Deprecated error fields  Some fields could be included with previous versions. They are still included but their use is deprecated: - `error`: superseded by `detail`  # Rate limits  We are rate-limiting all endpoints of PeerTube's API. Custom values can be set by administrators:  | Endpoint (prefix: `/api/v1`) | Calls         | Time frame   | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- --|- -- -- -- -- -- -- -| | `/_*`                         | 50            | 10 seconds   | | `POST /users/token`          | 15            | 5 minutes    | | `POST /users/register`       | 2<sup>*</sup> | 5 minutes    | | `POST /users/ask-send-verify-email` | 3      | 5 minutes    |  Depending on the endpoint, <sup>*</sup>failed requests are not taken into account. A service limit is announced by a `429 Too Many Requests` status code.  You can get details about the current state of your rate limit by reading the following headers:  | Header                  | Description                                                | |- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | `X-RateLimit-Limit`     | Number of max requests allowed in the current time period  | | `X-RateLimit-Remaining` | Number of remaining requests in the current time period    | | `X-RateLimit-Reset`     | Timestamp of end of current time period as UNIX timestamp  | | `Retry-After`           | Seconds to delay after the first `429` is received         |  # CORS  This API features [Cross-Origin Resource Sharing (CORS)](https://fetch.spec.whatwg.org/), allowing cross-domain communication from the browser for some routes:  | Endpoint                    | |- -- -- -- -- -- -- -- -- -- -- -- -- - --| | `/api/_*`                    | | `/download/_*`               | | `/lazy-static/_*`            | | `/.well-known/webfinger`    |  In addition, all routes serving ActivityPub are CORS-enabled for all origins. 
 *
 * The version of the OpenAPI document: 6.2.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = PeerTubeApiClient.Client.OpenAPIDateConverter;

namespace PeerTubeApiClient.Model
{
    /// <summary>
    /// ServerStats
    /// </summary>
    [DataContract(Name = "ServerStats")]
    public partial class ServerStats : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerStats" /> class.
        /// </summary>
        /// <param name="totalUsers">totalUsers.</param>
        /// <param name="totalDailyActiveUsers">totalDailyActiveUsers.</param>
        /// <param name="totalWeeklyActiveUsers">totalWeeklyActiveUsers.</param>
        /// <param name="totalMonthlyActiveUsers">totalMonthlyActiveUsers.</param>
        /// <param name="totalModerators">**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled total moderators stats.</param>
        /// <param name="totalAdmins">**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled total admins stats.</param>
        /// <param name="totalLocalVideos">totalLocalVideos.</param>
        /// <param name="totalLocalVideoViews">Total video views made on the instance.</param>
        /// <param name="totalLocalVideoComments">Total comments made by local users.</param>
        /// <param name="totalLocalVideoFilesSize">totalLocalVideoFilesSize.</param>
        /// <param name="totalVideos">totalVideos.</param>
        /// <param name="totalVideoComments">totalVideoComments.</param>
        /// <param name="totalLocalVideoChannels">totalLocalVideoChannels.</param>
        /// <param name="totalLocalDailyActiveVideoChannels">totalLocalDailyActiveVideoChannels.</param>
        /// <param name="totalLocalWeeklyActiveVideoChannels">totalLocalWeeklyActiveVideoChannels.</param>
        /// <param name="totalLocalMonthlyActiveVideoChannels">totalLocalMonthlyActiveVideoChannels.</param>
        /// <param name="totalLocalPlaylists">totalLocalPlaylists.</param>
        /// <param name="totalInstanceFollowers">totalInstanceFollowers.</param>
        /// <param name="totalInstanceFollowing">totalInstanceFollowing.</param>
        /// <param name="videosRedundancy">videosRedundancy.</param>
        /// <param name="totalActivityPubMessagesProcessed">totalActivityPubMessagesProcessed.</param>
        /// <param name="totalActivityPubMessagesSuccesses">totalActivityPubMessagesSuccesses.</param>
        /// <param name="totalActivityPubMessagesErrors">totalActivityPubMessagesErrors.</param>
        /// <param name="activityPubMessagesProcessedPerSecond">activityPubMessagesProcessedPerSecond.</param>
        /// <param name="totalActivityPubMessagesWaiting">totalActivityPubMessagesWaiting.</param>
        /// <param name="averageRegistrationRequestResponseTimeMs">**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled registration requests stats.</param>
        /// <param name="totalRegistrationRequestsProcessed">**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled registration requests stats.</param>
        /// <param name="totalRegistrationRequests">**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled registration requests stats.</param>
        /// <param name="averageAbuseResponseTimeMs">**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled abuses stats.</param>
        /// <param name="totalAbusesProcessed">**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled abuses stats.</param>
        /// <param name="totalAbuses">**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled abuses stats.</param>
        public ServerStats(decimal totalUsers = default(decimal), decimal totalDailyActiveUsers = default(decimal), decimal totalWeeklyActiveUsers = default(decimal), decimal totalMonthlyActiveUsers = default(decimal), decimal totalModerators = default(decimal), decimal totalAdmins = default(decimal), decimal totalLocalVideos = default(decimal), decimal totalLocalVideoViews = default(decimal), decimal totalLocalVideoComments = default(decimal), decimal totalLocalVideoFilesSize = default(decimal), decimal totalVideos = default(decimal), decimal totalVideoComments = default(decimal), decimal totalLocalVideoChannels = default(decimal), decimal totalLocalDailyActiveVideoChannels = default(decimal), decimal totalLocalWeeklyActiveVideoChannels = default(decimal), decimal totalLocalMonthlyActiveVideoChannels = default(decimal), decimal totalLocalPlaylists = default(decimal), decimal totalInstanceFollowers = default(decimal), decimal totalInstanceFollowing = default(decimal), List<ServerStatsVideosRedundancyInner> videosRedundancy = default(List<ServerStatsVideosRedundancyInner>), decimal totalActivityPubMessagesProcessed = default(decimal), decimal totalActivityPubMessagesSuccesses = default(decimal), decimal totalActivityPubMessagesErrors = default(decimal), decimal activityPubMessagesProcessedPerSecond = default(decimal), decimal totalActivityPubMessagesWaiting = default(decimal), decimal averageRegistrationRequestResponseTimeMs = default(decimal), decimal totalRegistrationRequestsProcessed = default(decimal), decimal totalRegistrationRequests = default(decimal), decimal averageAbuseResponseTimeMs = default(decimal), decimal totalAbusesProcessed = default(decimal), decimal totalAbuses = default(decimal))
        {
            this.TotalUsers = totalUsers;
            this.TotalDailyActiveUsers = totalDailyActiveUsers;
            this.TotalWeeklyActiveUsers = totalWeeklyActiveUsers;
            this.TotalMonthlyActiveUsers = totalMonthlyActiveUsers;
            this.TotalModerators = totalModerators;
            this.TotalAdmins = totalAdmins;
            this.TotalLocalVideos = totalLocalVideos;
            this.TotalLocalVideoViews = totalLocalVideoViews;
            this.TotalLocalVideoComments = totalLocalVideoComments;
            this.TotalLocalVideoFilesSize = totalLocalVideoFilesSize;
            this.TotalVideos = totalVideos;
            this.TotalVideoComments = totalVideoComments;
            this.TotalLocalVideoChannels = totalLocalVideoChannels;
            this.TotalLocalDailyActiveVideoChannels = totalLocalDailyActiveVideoChannels;
            this.TotalLocalWeeklyActiveVideoChannels = totalLocalWeeklyActiveVideoChannels;
            this.TotalLocalMonthlyActiveVideoChannels = totalLocalMonthlyActiveVideoChannels;
            this.TotalLocalPlaylists = totalLocalPlaylists;
            this.TotalInstanceFollowers = totalInstanceFollowers;
            this.TotalInstanceFollowing = totalInstanceFollowing;
            this.VideosRedundancy = videosRedundancy;
            this.TotalActivityPubMessagesProcessed = totalActivityPubMessagesProcessed;
            this.TotalActivityPubMessagesSuccesses = totalActivityPubMessagesSuccesses;
            this.TotalActivityPubMessagesErrors = totalActivityPubMessagesErrors;
            this.ActivityPubMessagesProcessedPerSecond = activityPubMessagesProcessedPerSecond;
            this.TotalActivityPubMessagesWaiting = totalActivityPubMessagesWaiting;
            this.AverageRegistrationRequestResponseTimeMs = averageRegistrationRequestResponseTimeMs;
            this.TotalRegistrationRequestsProcessed = totalRegistrationRequestsProcessed;
            this.TotalRegistrationRequests = totalRegistrationRequests;
            this.AverageAbuseResponseTimeMs = averageAbuseResponseTimeMs;
            this.TotalAbusesProcessed = totalAbusesProcessed;
            this.TotalAbuses = totalAbuses;
        }

        /// <summary>
        /// Gets or Sets TotalUsers
        /// </summary>
        [DataMember(Name = "totalUsers", EmitDefaultValue = false)]
        public decimal TotalUsers { get; set; }

        /// <summary>
        /// Gets or Sets TotalDailyActiveUsers
        /// </summary>
        [DataMember(Name = "totalDailyActiveUsers", EmitDefaultValue = false)]
        public decimal TotalDailyActiveUsers { get; set; }

        /// <summary>
        /// Gets or Sets TotalWeeklyActiveUsers
        /// </summary>
        [DataMember(Name = "totalWeeklyActiveUsers", EmitDefaultValue = false)]
        public decimal TotalWeeklyActiveUsers { get; set; }

        /// <summary>
        /// Gets or Sets TotalMonthlyActiveUsers
        /// </summary>
        [DataMember(Name = "totalMonthlyActiveUsers", EmitDefaultValue = false)]
        public decimal TotalMonthlyActiveUsers { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled total moderators stats
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled total moderators stats</value>
        [DataMember(Name = "totalModerators", EmitDefaultValue = false)]
        public decimal TotalModerators { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled total admins stats
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled total admins stats</value>
        [DataMember(Name = "totalAdmins", EmitDefaultValue = false)]
        public decimal TotalAdmins { get; set; }

        /// <summary>
        /// Gets or Sets TotalLocalVideos
        /// </summary>
        [DataMember(Name = "totalLocalVideos", EmitDefaultValue = false)]
        public decimal TotalLocalVideos { get; set; }

        /// <summary>
        /// Total video views made on the instance
        /// </summary>
        /// <value>Total video views made on the instance</value>
        [DataMember(Name = "totalLocalVideoViews", EmitDefaultValue = false)]
        public decimal TotalLocalVideoViews { get; set; }

        /// <summary>
        /// Total comments made by local users
        /// </summary>
        /// <value>Total comments made by local users</value>
        [DataMember(Name = "totalLocalVideoComments", EmitDefaultValue = false)]
        public decimal TotalLocalVideoComments { get; set; }

        /// <summary>
        /// Gets or Sets TotalLocalVideoFilesSize
        /// </summary>
        [DataMember(Name = "totalLocalVideoFilesSize", EmitDefaultValue = false)]
        public decimal TotalLocalVideoFilesSize { get; set; }

        /// <summary>
        /// Gets or Sets TotalVideos
        /// </summary>
        [DataMember(Name = "totalVideos", EmitDefaultValue = false)]
        public decimal TotalVideos { get; set; }

        /// <summary>
        /// Gets or Sets TotalVideoComments
        /// </summary>
        [DataMember(Name = "totalVideoComments", EmitDefaultValue = false)]
        public decimal TotalVideoComments { get; set; }

        /// <summary>
        /// Gets or Sets TotalLocalVideoChannels
        /// </summary>
        [DataMember(Name = "totalLocalVideoChannels", EmitDefaultValue = false)]
        public decimal TotalLocalVideoChannels { get; set; }

        /// <summary>
        /// Gets or Sets TotalLocalDailyActiveVideoChannels
        /// </summary>
        [DataMember(Name = "totalLocalDailyActiveVideoChannels", EmitDefaultValue = false)]
        public decimal TotalLocalDailyActiveVideoChannels { get; set; }

        /// <summary>
        /// Gets or Sets TotalLocalWeeklyActiveVideoChannels
        /// </summary>
        [DataMember(Name = "totalLocalWeeklyActiveVideoChannels", EmitDefaultValue = false)]
        public decimal TotalLocalWeeklyActiveVideoChannels { get; set; }

        /// <summary>
        /// Gets or Sets TotalLocalMonthlyActiveVideoChannels
        /// </summary>
        [DataMember(Name = "totalLocalMonthlyActiveVideoChannels", EmitDefaultValue = false)]
        public decimal TotalLocalMonthlyActiveVideoChannels { get; set; }

        /// <summary>
        /// Gets or Sets TotalLocalPlaylists
        /// </summary>
        [DataMember(Name = "totalLocalPlaylists", EmitDefaultValue = false)]
        public decimal TotalLocalPlaylists { get; set; }

        /// <summary>
        /// Gets or Sets TotalInstanceFollowers
        /// </summary>
        [DataMember(Name = "totalInstanceFollowers", EmitDefaultValue = false)]
        public decimal TotalInstanceFollowers { get; set; }

        /// <summary>
        /// Gets or Sets TotalInstanceFollowing
        /// </summary>
        [DataMember(Name = "totalInstanceFollowing", EmitDefaultValue = false)]
        public decimal TotalInstanceFollowing { get; set; }

        /// <summary>
        /// Gets or Sets VideosRedundancy
        /// </summary>
        [DataMember(Name = "videosRedundancy", EmitDefaultValue = false)]
        public List<ServerStatsVideosRedundancyInner> VideosRedundancy { get; set; }

        /// <summary>
        /// Gets or Sets TotalActivityPubMessagesProcessed
        /// </summary>
        [DataMember(Name = "totalActivityPubMessagesProcessed", EmitDefaultValue = false)]
        public decimal TotalActivityPubMessagesProcessed { get; set; }

        /// <summary>
        /// Gets or Sets TotalActivityPubMessagesSuccesses
        /// </summary>
        [DataMember(Name = "totalActivityPubMessagesSuccesses", EmitDefaultValue = false)]
        public decimal TotalActivityPubMessagesSuccesses { get; set; }

        /// <summary>
        /// Gets or Sets TotalActivityPubMessagesErrors
        /// </summary>
        [DataMember(Name = "totalActivityPubMessagesErrors", EmitDefaultValue = false)]
        public decimal TotalActivityPubMessagesErrors { get; set; }

        /// <summary>
        /// Gets or Sets ActivityPubMessagesProcessedPerSecond
        /// </summary>
        [DataMember(Name = "activityPubMessagesProcessedPerSecond", EmitDefaultValue = false)]
        public decimal ActivityPubMessagesProcessedPerSecond { get; set; }

        /// <summary>
        /// Gets or Sets TotalActivityPubMessagesWaiting
        /// </summary>
        [DataMember(Name = "totalActivityPubMessagesWaiting", EmitDefaultValue = false)]
        public decimal TotalActivityPubMessagesWaiting { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled registration requests stats
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled registration requests stats</value>
        [DataMember(Name = "averageRegistrationRequestResponseTimeMs", EmitDefaultValue = false)]
        public decimal AverageRegistrationRequestResponseTimeMs { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled registration requests stats
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled registration requests stats</value>
        [DataMember(Name = "totalRegistrationRequestsProcessed", EmitDefaultValue = false)]
        public decimal TotalRegistrationRequestsProcessed { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled registration requests stats
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled registration requests stats</value>
        [DataMember(Name = "totalRegistrationRequests", EmitDefaultValue = false)]
        public decimal TotalRegistrationRequests { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled abuses stats
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled abuses stats</value>
        [DataMember(Name = "averageAbuseResponseTimeMs", EmitDefaultValue = false)]
        public decimal AverageAbuseResponseTimeMs { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled abuses stats
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled abuses stats</value>
        [DataMember(Name = "totalAbusesProcessed", EmitDefaultValue = false)]
        public decimal TotalAbusesProcessed { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled abuses stats
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.1** Value is null if the admin disabled abuses stats</value>
        [DataMember(Name = "totalAbuses", EmitDefaultValue = false)]
        public decimal TotalAbuses { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ServerStats {\n");
            sb.Append("  TotalUsers: ").Append(TotalUsers).Append("\n");
            sb.Append("  TotalDailyActiveUsers: ").Append(TotalDailyActiveUsers).Append("\n");
            sb.Append("  TotalWeeklyActiveUsers: ").Append(TotalWeeklyActiveUsers).Append("\n");
            sb.Append("  TotalMonthlyActiveUsers: ").Append(TotalMonthlyActiveUsers).Append("\n");
            sb.Append("  TotalModerators: ").Append(TotalModerators).Append("\n");
            sb.Append("  TotalAdmins: ").Append(TotalAdmins).Append("\n");
            sb.Append("  TotalLocalVideos: ").Append(TotalLocalVideos).Append("\n");
            sb.Append("  TotalLocalVideoViews: ").Append(TotalLocalVideoViews).Append("\n");
            sb.Append("  TotalLocalVideoComments: ").Append(TotalLocalVideoComments).Append("\n");
            sb.Append("  TotalLocalVideoFilesSize: ").Append(TotalLocalVideoFilesSize).Append("\n");
            sb.Append("  TotalVideos: ").Append(TotalVideos).Append("\n");
            sb.Append("  TotalVideoComments: ").Append(TotalVideoComments).Append("\n");
            sb.Append("  TotalLocalVideoChannels: ").Append(TotalLocalVideoChannels).Append("\n");
            sb.Append("  TotalLocalDailyActiveVideoChannels: ").Append(TotalLocalDailyActiveVideoChannels).Append("\n");
            sb.Append("  TotalLocalWeeklyActiveVideoChannels: ").Append(TotalLocalWeeklyActiveVideoChannels).Append("\n");
            sb.Append("  TotalLocalMonthlyActiveVideoChannels: ").Append(TotalLocalMonthlyActiveVideoChannels).Append("\n");
            sb.Append("  TotalLocalPlaylists: ").Append(TotalLocalPlaylists).Append("\n");
            sb.Append("  TotalInstanceFollowers: ").Append(TotalInstanceFollowers).Append("\n");
            sb.Append("  TotalInstanceFollowing: ").Append(TotalInstanceFollowing).Append("\n");
            sb.Append("  VideosRedundancy: ").Append(VideosRedundancy).Append("\n");
            sb.Append("  TotalActivityPubMessagesProcessed: ").Append(TotalActivityPubMessagesProcessed).Append("\n");
            sb.Append("  TotalActivityPubMessagesSuccesses: ").Append(TotalActivityPubMessagesSuccesses).Append("\n");
            sb.Append("  TotalActivityPubMessagesErrors: ").Append(TotalActivityPubMessagesErrors).Append("\n");
            sb.Append("  ActivityPubMessagesProcessedPerSecond: ").Append(ActivityPubMessagesProcessedPerSecond).Append("\n");
            sb.Append("  TotalActivityPubMessagesWaiting: ").Append(TotalActivityPubMessagesWaiting).Append("\n");
            sb.Append("  AverageRegistrationRequestResponseTimeMs: ").Append(AverageRegistrationRequestResponseTimeMs).Append("\n");
            sb.Append("  TotalRegistrationRequestsProcessed: ").Append(TotalRegistrationRequestsProcessed).Append("\n");
            sb.Append("  TotalRegistrationRequests: ").Append(TotalRegistrationRequests).Append("\n");
            sb.Append("  AverageAbuseResponseTimeMs: ").Append(AverageAbuseResponseTimeMs).Append("\n");
            sb.Append("  TotalAbusesProcessed: ").Append(TotalAbusesProcessed).Append("\n");
            sb.Append("  TotalAbuses: ").Append(TotalAbuses).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
