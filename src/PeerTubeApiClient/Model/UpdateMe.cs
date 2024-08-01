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
    /// UpdateMe
    /// </summary>
    [DataContract(Name = "UpdateMe")]
    public partial class UpdateMe : IValidatableObject
    {
        /// <summary>
        /// new NSFW display policy
        /// </summary>
        /// <value>new NSFW display policy</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DisplayNSFWEnum
        {
            /// <summary>
            /// Enum True for value: true
            /// </summary>
            [EnumMember(Value = "true")]
            True = 1,

            /// <summary>
            /// Enum False for value: false
            /// </summary>
            [EnumMember(Value = "false")]
            False = 2,

            /// <summary>
            /// Enum Both for value: both
            /// </summary>
            [EnumMember(Value = "both")]
            Both = 3
        }


        /// <summary>
        /// new NSFW display policy
        /// </summary>
        /// <value>new NSFW display policy</value>
        [DataMember(Name = "displayNSFW", EmitDefaultValue = false)]
        public DisplayNSFWEnum? DisplayNSFW { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMe" /> class.
        /// </summary>
        /// <param name="password">password.</param>
        /// <param name="currentPassword">currentPassword.</param>
        /// <param name="email">new email used for login and service communications.</param>
        /// <param name="displayName">new name of the user in its representations.</param>
        /// <param name="displayNSFW">new NSFW display policy.</param>
        /// <param name="p2pEnabled">whether to enable P2P in the player or not.</param>
        /// <param name="autoPlayVideo">new preference regarding playing videos automatically.</param>
        /// <param name="autoPlayNextVideo">new preference regarding playing following videos automatically.</param>
        /// <param name="autoPlayNextVideoPlaylist">new preference regarding playing following playlist videos automatically.</param>
        /// <param name="videosHistoryEnabled">whether to keep track of watched history or not.</param>
        /// <param name="videoLanguages">list of languages to filter videos down to.</param>
        /// <param name="theme">theme.</param>
        /// <param name="noInstanceConfigWarningModal">noInstanceConfigWarningModal.</param>
        /// <param name="noAccountSetupWarningModal">noAccountSetupWarningModal.</param>
        /// <param name="noWelcomeModal">noWelcomeModal.</param>
        public UpdateMe(string password = default(string), string currentPassword = default(string), string email = default(string), string displayName = default(string), DisplayNSFWEnum? displayNSFW = default(DisplayNSFWEnum?), bool p2pEnabled = default(bool), bool autoPlayVideo = default(bool), bool autoPlayNextVideo = default(bool), bool autoPlayNextVideoPlaylist = default(bool), bool videosHistoryEnabled = default(bool), List<string> videoLanguages = default(List<string>), string theme = default(string), bool noInstanceConfigWarningModal = default(bool), bool noAccountSetupWarningModal = default(bool), bool noWelcomeModal = default(bool))
        {
            this.Password = password;
            this.CurrentPassword = currentPassword;
            this.Email = email;
            this.DisplayName = displayName;
            this.DisplayNSFW = displayNSFW;
            this.P2pEnabled = p2pEnabled;
            this.AutoPlayVideo = autoPlayVideo;
            this.AutoPlayNextVideo = autoPlayNextVideo;
            this.AutoPlayNextVideoPlaylist = autoPlayNextVideoPlaylist;
            this.VideosHistoryEnabled = videosHistoryEnabled;
            this.VideoLanguages = videoLanguages;
            this.Theme = theme;
            this.NoInstanceConfigWarningModal = noInstanceConfigWarningModal;
            this.NoAccountSetupWarningModal = noAccountSetupWarningModal;
            this.NoWelcomeModal = noWelcomeModal;
        }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [DataMember(Name = "password", EmitDefaultValue = false)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or Sets CurrentPassword
        /// </summary>
        [DataMember(Name = "currentPassword", EmitDefaultValue = false)]
        public string CurrentPassword { get; set; }

        /// <summary>
        /// new email used for login and service communications
        /// </summary>
        /// <value>new email used for login and service communications</value>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        /// <summary>
        /// new name of the user in its representations
        /// </summary>
        /// <value>new name of the user in its representations</value>
        [DataMember(Name = "displayName", EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// whether to enable P2P in the player or not
        /// </summary>
        /// <value>whether to enable P2P in the player or not</value>
        [DataMember(Name = "p2pEnabled", EmitDefaultValue = true)]
        public bool P2pEnabled { get; set; }

        /// <summary>
        /// new preference regarding playing videos automatically
        /// </summary>
        /// <value>new preference regarding playing videos automatically</value>
        [DataMember(Name = "autoPlayVideo", EmitDefaultValue = true)]
        public bool AutoPlayVideo { get; set; }

        /// <summary>
        /// new preference regarding playing following videos automatically
        /// </summary>
        /// <value>new preference regarding playing following videos automatically</value>
        [DataMember(Name = "autoPlayNextVideo", EmitDefaultValue = true)]
        public bool AutoPlayNextVideo { get; set; }

        /// <summary>
        /// new preference regarding playing following playlist videos automatically
        /// </summary>
        /// <value>new preference regarding playing following playlist videos automatically</value>
        [DataMember(Name = "autoPlayNextVideoPlaylist", EmitDefaultValue = true)]
        public bool AutoPlayNextVideoPlaylist { get; set; }

        /// <summary>
        /// whether to keep track of watched history or not
        /// </summary>
        /// <value>whether to keep track of watched history or not</value>
        [DataMember(Name = "videosHistoryEnabled", EmitDefaultValue = true)]
        public bool VideosHistoryEnabled { get; set; }

        /// <summary>
        /// list of languages to filter videos down to
        /// </summary>
        /// <value>list of languages to filter videos down to</value>
        [DataMember(Name = "videoLanguages", EmitDefaultValue = false)]
        public List<string> VideoLanguages { get; set; }

        /// <summary>
        /// Gets or Sets Theme
        /// </summary>
        [DataMember(Name = "theme", EmitDefaultValue = false)]
        public string Theme { get; set; }

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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UpdateMe {\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  CurrentPassword: ").Append(CurrentPassword).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  DisplayNSFW: ").Append(DisplayNSFW).Append("\n");
            sb.Append("  P2pEnabled: ").Append(P2pEnabled).Append("\n");
            sb.Append("  AutoPlayVideo: ").Append(AutoPlayVideo).Append("\n");
            sb.Append("  AutoPlayNextVideo: ").Append(AutoPlayNextVideo).Append("\n");
            sb.Append("  AutoPlayNextVideoPlaylist: ").Append(AutoPlayNextVideoPlaylist).Append("\n");
            sb.Append("  VideosHistoryEnabled: ").Append(VideosHistoryEnabled).Append("\n");
            sb.Append("  VideoLanguages: ").Append(VideoLanguages).Append("\n");
            sb.Append("  Theme: ").Append(Theme).Append("\n");
            sb.Append("  NoInstanceConfigWarningModal: ").Append(NoInstanceConfigWarningModal).Append("\n");
            sb.Append("  NoAccountSetupWarningModal: ").Append(NoAccountSetupWarningModal).Append("\n");
            sb.Append("  NoWelcomeModal: ").Append(NoWelcomeModal).Append("\n");
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
            // Password (string) maxLength
            if (this.Password != null && this.Password.Length > 255)
            {
                yield return new ValidationResult("Invalid value for Password, length must be less than 255.", new [] { "Password" });
            }

            // Password (string) minLength
            if (this.Password != null && this.Password.Length < 6)
            {
                yield return new ValidationResult("Invalid value for Password, length must be greater than 6.", new [] { "Password" });
            }

            // CurrentPassword (string) maxLength
            if (this.CurrentPassword != null && this.CurrentPassword.Length > 255)
            {
                yield return new ValidationResult("Invalid value for CurrentPassword, length must be less than 255.", new [] { "CurrentPassword" });
            }

            // CurrentPassword (string) minLength
            if (this.CurrentPassword != null && this.CurrentPassword.Length < 6)
            {
                yield return new ValidationResult("Invalid value for CurrentPassword, length must be greater than 6.", new [] { "CurrentPassword" });
            }

            // DisplayName (string) maxLength
            if (this.DisplayName != null && this.DisplayName.Length > 120)
            {
                yield return new ValidationResult("Invalid value for DisplayName, length must be less than 120.", new [] { "DisplayName" });
            }

            // DisplayName (string) minLength
            if (this.DisplayName != null && this.DisplayName.Length < 3)
            {
                yield return new ValidationResult("Invalid value for DisplayName, length must be greater than 3.", new [] { "DisplayName" });
            }

            yield break;
        }
    }

}
