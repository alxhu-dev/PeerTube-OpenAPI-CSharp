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
    /// Abuse
    /// </summary>
    [DataContract(Name = "Abuse")]
    public partial class Abuse : IValidatableObject
    {
        /// <summary>
        /// Defines PredefinedReasons
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PredefinedReasonsEnum
        {
            /// <summary>
            /// Enum ViolentOrAbusive for value: violentOrAbusive
            /// </summary>
            [EnumMember(Value = "violentOrAbusive")]
            ViolentOrAbusive = 1,

            /// <summary>
            /// Enum HatefulOrAbusive for value: hatefulOrAbusive
            /// </summary>
            [EnumMember(Value = "hatefulOrAbusive")]
            HatefulOrAbusive = 2,

            /// <summary>
            /// Enum SpamOrMisleading for value: spamOrMisleading
            /// </summary>
            [EnumMember(Value = "spamOrMisleading")]
            SpamOrMisleading = 3,

            /// <summary>
            /// Enum Privacy for value: privacy
            /// </summary>
            [EnumMember(Value = "privacy")]
            Privacy = 4,

            /// <summary>
            /// Enum Rights for value: rights
            /// </summary>
            [EnumMember(Value = "rights")]
            Rights = 5,

            /// <summary>
            /// Enum ServerRules for value: serverRules
            /// </summary>
            [EnumMember(Value = "serverRules")]
            ServerRules = 6,

            /// <summary>
            /// Enum Thumbnails for value: thumbnails
            /// </summary>
            [EnumMember(Value = "thumbnails")]
            Thumbnails = 7,

            /// <summary>
            /// Enum Captions for value: captions
            /// </summary>
            [EnumMember(Value = "captions")]
            Captions = 8
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Abuse" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="reason">reason.</param>
        /// <param name="predefinedReasons">predefinedReasons.</param>
        /// <param name="reporterAccount">reporterAccount.</param>
        /// <param name="state">state.</param>
        /// <param name="moderationComment">moderationComment.</param>
        /// <param name="video">video.</param>
        /// <param name="createdAt">createdAt.</param>
        public Abuse(int id = default(int), string reason = default(string), List<PredefinedReasonsEnum> predefinedReasons = default(List<PredefinedReasonsEnum>), Account reporterAccount = default(Account), AbuseStateConstant state = default(AbuseStateConstant), string moderationComment = default(string), VideoInfo video = default(VideoInfo), DateTime createdAt = default(DateTime))
        {
            this.Id = id;
            this.Reason = reason;
            this.PredefinedReasons = predefinedReasons;
            this.ReporterAccount = reporterAccount;
            this.State = state;
            this.ModerationComment = moderationComment;
            this.Video = video;
            this.CreatedAt = createdAt;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        /// <example>42</example>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Reason
        /// </summary>
        /// <example>The video is a spam</example>
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or Sets PredefinedReasons
        /// </summary>
        /// <example>[&quot;spamOrMisleading&quot;]</example>
        [DataMember(Name = "predefinedReasons", EmitDefaultValue = false)]
        public List<Abuse.PredefinedReasonsEnum> PredefinedReasons { get; set; }

        /// <summary>
        /// Gets or Sets ReporterAccount
        /// </summary>
        [DataMember(Name = "reporterAccount", EmitDefaultValue = false)]
        public Account ReporterAccount { get; set; }

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public AbuseStateConstant State { get; set; }

        /// <summary>
        /// Gets or Sets ModerationComment
        /// </summary>
        /// <example>Decided to ban the server since it spams us regularly</example>
        [DataMember(Name = "moderationComment", EmitDefaultValue = false)]
        public string ModerationComment { get; set; }

        /// <summary>
        /// Gets or Sets Video
        /// </summary>
        [DataMember(Name = "video", EmitDefaultValue = false)]
        public VideoInfo Video { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Abuse {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  PredefinedReasons: ").Append(PredefinedReasons).Append("\n");
            sb.Append("  ReporterAccount: ").Append(ReporterAccount).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  ModerationComment: ").Append(ModerationComment).Append("\n");
            sb.Append("  Video: ").Append(Video).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
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

            // Reason (string) maxLength
            if (this.Reason != null && this.Reason.Length > 3000)
            {
                yield return new ValidationResult("Invalid value for Reason, length must be less than 3000.", new [] { "Reason" });
            }

            // Reason (string) minLength
            if (this.Reason != null && this.Reason.Length < 2)
            {
                yield return new ValidationResult("Invalid value for Reason, length must be greater than 2.", new [] { "Reason" });
            }

            // ModerationComment (string) maxLength
            if (this.ModerationComment != null && this.ModerationComment.Length > 3000)
            {
                yield return new ValidationResult("Invalid value for ModerationComment, length must be less than 3000.", new [] { "ModerationComment" });
            }

            // ModerationComment (string) minLength
            if (this.ModerationComment != null && this.ModerationComment.Length < 2)
            {
                yield return new ValidationResult("Invalid value for ModerationComment, length must be greater than 2.", new [] { "ModerationComment" });
            }

            yield break;
        }
    }

}
