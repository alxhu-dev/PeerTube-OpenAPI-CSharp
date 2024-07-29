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
    /// ApiV1UsersMeNotificationSettingsPutRequest
    /// </summary>
    [DataContract(Name = "_api_v1_users_me_notification_settings_put_request")]
    public partial class ApiV1UsersMeNotificationSettingsPutRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiV1UsersMeNotificationSettingsPutRequest" /> class.
        /// </summary>
        /// <param name="newVideoFromSubscription">Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL .</param>
        /// <param name="newCommentOnMyVideo">Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL .</param>
        /// <param name="abuseAsModerator">Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL .</param>
        /// <param name="videoAutoBlacklistAsModerator">Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL .</param>
        /// <param name="blacklistOnMyVideo">Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL .</param>
        /// <param name="myVideoPublished">Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL .</param>
        /// <param name="myVideoImportFinished">Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL .</param>
        /// <param name="newFollow">Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL .</param>
        /// <param name="newUserRegistration">Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL .</param>
        /// <param name="commentMention">Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL .</param>
        /// <param name="newInstanceFollower">Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL .</param>
        /// <param name="autoInstanceFollowing">Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL .</param>
        public ApiV1UsersMeNotificationSettingsPutRequest(int newVideoFromSubscription = default(int), int newCommentOnMyVideo = default(int), int abuseAsModerator = default(int), int videoAutoBlacklistAsModerator = default(int), int blacklistOnMyVideo = default(int), int myVideoPublished = default(int), int myVideoImportFinished = default(int), int newFollow = default(int), int newUserRegistration = default(int), int commentMention = default(int), int newInstanceFollower = default(int), int autoInstanceFollowing = default(int))
        {
            this.NewVideoFromSubscription = newVideoFromSubscription;
            this.NewCommentOnMyVideo = newCommentOnMyVideo;
            this.AbuseAsModerator = abuseAsModerator;
            this.VideoAutoBlacklistAsModerator = videoAutoBlacklistAsModerator;
            this.BlacklistOnMyVideo = blacklistOnMyVideo;
            this.MyVideoPublished = myVideoPublished;
            this.MyVideoImportFinished = myVideoImportFinished;
            this.NewFollow = newFollow;
            this.NewUserRegistration = newUserRegistration;
            this.CommentMention = commentMention;
            this.NewInstanceFollower = newInstanceFollower;
            this.AutoInstanceFollowing = autoInstanceFollowing;
        }

        /// <summary>
        /// Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL 
        /// </summary>
        /// <value>Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL </value>
        [DataMember(Name = "newVideoFromSubscription", EmitDefaultValue = false)]
        public int NewVideoFromSubscription { get; set; }

        /// <summary>
        /// Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL 
        /// </summary>
        /// <value>Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL </value>
        [DataMember(Name = "newCommentOnMyVideo", EmitDefaultValue = false)]
        public int NewCommentOnMyVideo { get; set; }

        /// <summary>
        /// Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL 
        /// </summary>
        /// <value>Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL </value>
        [DataMember(Name = "abuseAsModerator", EmitDefaultValue = false)]
        public int AbuseAsModerator { get; set; }

        /// <summary>
        /// Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL 
        /// </summary>
        /// <value>Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL </value>
        [DataMember(Name = "videoAutoBlacklistAsModerator", EmitDefaultValue = false)]
        public int VideoAutoBlacklistAsModerator { get; set; }

        /// <summary>
        /// Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL 
        /// </summary>
        /// <value>Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL </value>
        [DataMember(Name = "blacklistOnMyVideo", EmitDefaultValue = false)]
        public int BlacklistOnMyVideo { get; set; }

        /// <summary>
        /// Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL 
        /// </summary>
        /// <value>Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL </value>
        [DataMember(Name = "myVideoPublished", EmitDefaultValue = false)]
        public int MyVideoPublished { get; set; }

        /// <summary>
        /// Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL 
        /// </summary>
        /// <value>Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL </value>
        [DataMember(Name = "myVideoImportFinished", EmitDefaultValue = false)]
        public int MyVideoImportFinished { get; set; }

        /// <summary>
        /// Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL 
        /// </summary>
        /// <value>Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL </value>
        [DataMember(Name = "newFollow", EmitDefaultValue = false)]
        public int NewFollow { get; set; }

        /// <summary>
        /// Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL 
        /// </summary>
        /// <value>Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL </value>
        [DataMember(Name = "newUserRegistration", EmitDefaultValue = false)]
        public int NewUserRegistration { get; set; }

        /// <summary>
        /// Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL 
        /// </summary>
        /// <value>Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL </value>
        [DataMember(Name = "commentMention", EmitDefaultValue = false)]
        public int CommentMention { get; set; }

        /// <summary>
        /// Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL 
        /// </summary>
        /// <value>Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL </value>
        [DataMember(Name = "newInstanceFollower", EmitDefaultValue = false)]
        public int NewInstanceFollower { get; set; }

        /// <summary>
        /// Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL 
        /// </summary>
        /// <value>Notification type. One of the following values, or a sum of multiple values: - &#x60;0&#x60; NONE - &#x60;1&#x60; WEB - &#x60;2&#x60; EMAIL </value>
        [DataMember(Name = "autoInstanceFollowing", EmitDefaultValue = false)]
        public int AutoInstanceFollowing { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ApiV1UsersMeNotificationSettingsPutRequest {\n");
            sb.Append("  NewVideoFromSubscription: ").Append(NewVideoFromSubscription).Append("\n");
            sb.Append("  NewCommentOnMyVideo: ").Append(NewCommentOnMyVideo).Append("\n");
            sb.Append("  AbuseAsModerator: ").Append(AbuseAsModerator).Append("\n");
            sb.Append("  VideoAutoBlacklistAsModerator: ").Append(VideoAutoBlacklistAsModerator).Append("\n");
            sb.Append("  BlacklistOnMyVideo: ").Append(BlacklistOnMyVideo).Append("\n");
            sb.Append("  MyVideoPublished: ").Append(MyVideoPublished).Append("\n");
            sb.Append("  MyVideoImportFinished: ").Append(MyVideoImportFinished).Append("\n");
            sb.Append("  NewFollow: ").Append(NewFollow).Append("\n");
            sb.Append("  NewUserRegistration: ").Append(NewUserRegistration).Append("\n");
            sb.Append("  CommentMention: ").Append(CommentMention).Append("\n");
            sb.Append("  NewInstanceFollower: ").Append(NewInstanceFollower).Append("\n");
            sb.Append("  AutoInstanceFollowing: ").Append(AutoInstanceFollowing).Append("\n");
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
