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
    /// User
    /// </summary>
    [DataContract(Name = "User")]
    public partial class User : IValidatableObject
    {

        /// <summary>
        /// Gets or Sets NsfwPolicy
        /// </summary>
        [DataMember(Name = "nsfwPolicy", EmitDefaultValue = false)]
        public NSFWPolicy? NsfwPolicy { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="account">account.</param>
        /// <param name="autoPlayNextVideo">Automatically start playing the upcoming video after the currently playing video.</param>
        /// <param name="autoPlayNextVideoPlaylist">Automatically start playing the video on the playlist after the currently playing video.</param>
        /// <param name="autoPlayVideo">Automatically start playing the video on the watch page.</param>
        /// <param name="blocked">blocked.</param>
        /// <param name="blockedReason">blockedReason.</param>
        /// <param name="createdAt">createdAt.</param>
        /// <param name="email">The user email.</param>
        /// <param name="emailVerified">Has the user confirmed their email address?.</param>
        /// <param name="pluginAuth">Auth plugin to use to authenticate the user.</param>
        /// <param name="lastLoginDate">lastLoginDate.</param>
        /// <param name="noInstanceConfigWarningModal">noInstanceConfigWarningModal.</param>
        /// <param name="noAccountSetupWarningModal">noAccountSetupWarningModal.</param>
        /// <param name="noWelcomeModal">noWelcomeModal.</param>
        /// <param name="nsfwPolicy">nsfwPolicy.</param>
        /// <param name="role">role.</param>
        /// <param name="theme">Theme enabled by this user.</param>
        /// <param name="username">immutable name of the user, used to find or mention its actor.</param>
        /// <param name="videoChannels">videoChannels.</param>
        /// <param name="videoQuota">The user video quota in bytes.</param>
        /// <param name="videoQuotaDaily">The user daily video quota in bytes.</param>
        /// <param name="p2pEnabled">Enable P2P in the player.</param>
        public User(Account account = default(Account), bool autoPlayNextVideo = default(bool), bool autoPlayNextVideoPlaylist = default(bool), bool autoPlayVideo = default(bool), bool blocked = default(bool), string blockedReason = default(string), string createdAt = default(string), string email = default(string), bool emailVerified = default(bool), string pluginAuth = default(string), DateTime lastLoginDate = default(DateTime), bool noInstanceConfigWarningModal = default(bool), bool noAccountSetupWarningModal = default(bool), bool noWelcomeModal = default(bool), NSFWPolicy? nsfwPolicy = default(NSFWPolicy?), UserRole role = default(UserRole), string theme = default(string), string username = default(string), List<VideoChannel> videoChannels = default(List<VideoChannel>), int videoQuota = default(int), int videoQuotaDaily = default(int), bool p2pEnabled = default(bool))
        {
            this.Account = account;
            this.AutoPlayNextVideo = autoPlayNextVideo;
            this.AutoPlayNextVideoPlaylist = autoPlayNextVideoPlaylist;
            this.AutoPlayVideo = autoPlayVideo;
            this.Blocked = blocked;
            this.BlockedReason = blockedReason;
            this.CreatedAt = createdAt;
            this.Email = email;
            this.EmailVerified = emailVerified;
            this.PluginAuth = pluginAuth;
            this.LastLoginDate = lastLoginDate;
            this.NoInstanceConfigWarningModal = noInstanceConfigWarningModal;
            this.NoAccountSetupWarningModal = noAccountSetupWarningModal;
            this.NoWelcomeModal = noWelcomeModal;
            this.NsfwPolicy = nsfwPolicy;
            this.Role = role;
            this.Theme = theme;
            this.Username = username;
            this.VideoChannels = videoChannels;
            this.VideoQuota = videoQuota;
            this.VideoQuotaDaily = videoQuotaDaily;
            this.P2pEnabled = p2pEnabled;
        }

        /// <summary>
        /// Gets or Sets Account
        /// </summary>
        [DataMember(Name = "account", EmitDefaultValue = false)]
        public Account Account { get; set; }

        /// <summary>
        /// Automatically start playing the upcoming video after the currently playing video
        /// </summary>
        /// <value>Automatically start playing the upcoming video after the currently playing video</value>
        [DataMember(Name = "autoPlayNextVideo", EmitDefaultValue = true)]
        public bool AutoPlayNextVideo { get; set; }

        /// <summary>
        /// Automatically start playing the video on the playlist after the currently playing video
        /// </summary>
        /// <value>Automatically start playing the video on the playlist after the currently playing video</value>
        [DataMember(Name = "autoPlayNextVideoPlaylist", EmitDefaultValue = true)]
        public bool AutoPlayNextVideoPlaylist { get; set; }

        /// <summary>
        /// Automatically start playing the video on the watch page
        /// </summary>
        /// <value>Automatically start playing the video on the watch page</value>
        [DataMember(Name = "autoPlayVideo", EmitDefaultValue = true)]
        public bool AutoPlayVideo { get; set; }

        /// <summary>
        /// Gets or Sets Blocked
        /// </summary>
        [DataMember(Name = "blocked", EmitDefaultValue = true)]
        public bool Blocked { get; set; }

        /// <summary>
        /// Gets or Sets BlockedReason
        /// </summary>
        [DataMember(Name = "blockedReason", EmitDefaultValue = false)]
        public string BlockedReason { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// The user email
        /// </summary>
        /// <value>The user email</value>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        /// <summary>
        /// Has the user confirmed their email address?
        /// </summary>
        /// <value>Has the user confirmed their email address?</value>
        [DataMember(Name = "emailVerified", EmitDefaultValue = true)]
        public bool EmailVerified { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        /// <example>42</example>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; private set; }

        /// <summary>
        /// Returns false as Id should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeId()
        {
            return false;
        }
        /// <summary>
        /// Auth plugin to use to authenticate the user
        /// </summary>
        /// <value>Auth plugin to use to authenticate the user</value>
        [DataMember(Name = "pluginAuth", EmitDefaultValue = false)]
        public string PluginAuth { get; set; }

        /// <summary>
        /// Gets or Sets LastLoginDate
        /// </summary>
        [DataMember(Name = "lastLoginDate", EmitDefaultValue = false)]
        public DateTime LastLoginDate { get; set; }

        /// <summary>
        /// Gets or Sets NoInstanceConfigWarningModal
        /// </summary>
        [DataMember(Name = "noInstanceConfigWarningModal", EmitDefaultValue = true)]
        public bool NoInstanceConfigWarningModal { get; set; }

        /// <summary>
        /// Gets or Sets NoAccountSetupWarningModal
        /// </summary>
        [DataMember(Name = "noAccountSetupWarningModal", EmitDefaultValue = true)]
        public bool NoAccountSetupWarningModal { get; set; }

        /// <summary>
        /// Gets or Sets NoWelcomeModal
        /// </summary>
        [DataMember(Name = "noWelcomeModal", EmitDefaultValue = true)]
        public bool NoWelcomeModal { get; set; }

        /// <summary>
        /// Gets or Sets Role
        /// </summary>
        [DataMember(Name = "role", EmitDefaultValue = false)]
        public UserRole Role { get; set; }

        /// <summary>
        /// Theme enabled by this user
        /// </summary>
        /// <value>Theme enabled by this user</value>
        [DataMember(Name = "theme", EmitDefaultValue = false)]
        public string Theme { get; set; }

        /// <summary>
        /// immutable name of the user, used to find or mention its actor
        /// </summary>
        /// <value>immutable name of the user, used to find or mention its actor</value>
        /// <example>chocobozzz</example>
        [DataMember(Name = "username", EmitDefaultValue = false)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or Sets VideoChannels
        /// </summary>
        [DataMember(Name = "videoChannels", EmitDefaultValue = false)]
        public List<VideoChannel> VideoChannels { get; set; }

        /// <summary>
        /// The user video quota in bytes
        /// </summary>
        /// <value>The user video quota in bytes</value>
        /// <example>-1</example>
        [DataMember(Name = "videoQuota", EmitDefaultValue = false)]
        public int VideoQuota { get; set; }

        /// <summary>
        /// The user daily video quota in bytes
        /// </summary>
        /// <value>The user daily video quota in bytes</value>
        /// <example>-1</example>
        [DataMember(Name = "videoQuotaDaily", EmitDefaultValue = false)]
        public int VideoQuotaDaily { get; set; }

        /// <summary>
        /// Enable P2P in the player
        /// </summary>
        /// <value>Enable P2P in the player</value>
        [DataMember(Name = "p2pEnabled", EmitDefaultValue = true)]
        public bool P2pEnabled { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class User {\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  AutoPlayNextVideo: ").Append(AutoPlayNextVideo).Append("\n");
            sb.Append("  AutoPlayNextVideoPlaylist: ").Append(AutoPlayNextVideoPlaylist).Append("\n");
            sb.Append("  AutoPlayVideo: ").Append(AutoPlayVideo).Append("\n");
            sb.Append("  Blocked: ").Append(Blocked).Append("\n");
            sb.Append("  BlockedReason: ").Append(BlockedReason).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  EmailVerified: ").Append(EmailVerified).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  PluginAuth: ").Append(PluginAuth).Append("\n");
            sb.Append("  LastLoginDate: ").Append(LastLoginDate).Append("\n");
            sb.Append("  NoInstanceConfigWarningModal: ").Append(NoInstanceConfigWarningModal).Append("\n");
            sb.Append("  NoAccountSetupWarningModal: ").Append(NoAccountSetupWarningModal).Append("\n");
            sb.Append("  NoWelcomeModal: ").Append(NoWelcomeModal).Append("\n");
            sb.Append("  NsfwPolicy: ").Append(NsfwPolicy).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("  Theme: ").Append(Theme).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  VideoChannels: ").Append(VideoChannels).Append("\n");
            sb.Append("  VideoQuota: ").Append(VideoQuota).Append("\n");
            sb.Append("  VideoQuotaDaily: ").Append(VideoQuotaDaily).Append("\n");
            sb.Append("  P2pEnabled: ").Append(P2pEnabled).Append("\n");
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
            // Id (int) minimum
            if (this.Id < (int)1)
            {
                yield return new ValidationResult("Invalid value for Id, must be a value greater than or equal to 1.", new [] { "Id" });
            }

            // Username (string) maxLength
            if (this.Username != null && this.Username.Length > 50)
            {
                yield return new ValidationResult("Invalid value for Username, length must be less than 50.", new [] { "Username" });
            }

            // Username (string) minLength
            if (this.Username != null && this.Username.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Username, length must be greater than 1.", new [] { "Username" });
            }

            if (this.Username != null) {
                // Username (string) pattern
                Regex regexUsername = new Regex(@"^[a-z0-9._]+$", RegexOptions.CultureInvariant);
                if (!regexUsername.Match(this.Username).Success)
                {
                    yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Username, must match a pattern of " + regexUsername, new [] { "Username" });
                }
            }

            yield break;
        }
    }

}
