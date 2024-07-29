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
    /// Notification
    /// </summary>
    [DataContract(Name = "Notification")]
    public partial class Notification : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Notification" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="type">Notification type, following the &#x60;UserNotificationType&#x60; enum: - &#x60;1&#x60; NEW_VIDEO_FROM_SUBSCRIPTION - &#x60;2&#x60; NEW_COMMENT_ON_MY_VIDEO - &#x60;3&#x60; NEW_ABUSE_FOR_MODERATORS - &#x60;4&#x60; BLACKLIST_ON_MY_VIDEO - &#x60;5&#x60; UNBLACKLIST_ON_MY_VIDEO - &#x60;6&#x60; MY_VIDEO_PUBLISHED - &#x60;7&#x60; MY_VIDEO_IMPORT_SUCCESS - &#x60;8&#x60; MY_VIDEO_IMPORT_ERROR - &#x60;9&#x60; NEW_USER_REGISTRATION - &#x60;10&#x60; NEW_FOLLOW - &#x60;11&#x60; COMMENT_MENTION - &#x60;12&#x60; VIDEO_AUTO_BLACKLIST_FOR_MODERATORS - &#x60;13&#x60; NEW_INSTANCE_FOLLOWER - &#x60;14&#x60; AUTO_INSTANCE_FOLLOWING - &#x60;15&#x60; ABUSE_STATE_CHANGE - &#x60;16&#x60; ABUSE_NEW_MESSAGE - &#x60;17&#x60; NEW_PLUGIN_VERSION - &#x60;18&#x60; NEW_PEERTUBE_VERSION - &#x60;19&#x60; MY_VIDEO_STUDIO_EDITION_FINISHED - &#x60;20&#x60; NEW_USER_REGISTRATION_REQUEST - &#x60;21&#x60; NEW_LIVE_FROM_SUBSCRIPTION .</param>
        /// <param name="read">read.</param>
        /// <param name="video">video.</param>
        /// <param name="videoImport">videoImport.</param>
        /// <param name="comment">comment.</param>
        /// <param name="videoAbuse">videoAbuse.</param>
        /// <param name="videoBlacklist">videoBlacklist.</param>
        /// <param name="account">account.</param>
        /// <param name="actorFollow">actorFollow.</param>
        /// <param name="createdAt">createdAt.</param>
        /// <param name="updatedAt">updatedAt.</param>
        public Notification(int id = default(int), int type = default(int), bool read = default(bool), NotificationVideo video = default(NotificationVideo), NotificationVideoImport videoImport = default(NotificationVideoImport), NotificationComment comment = default(NotificationComment), NotificationVideoAbuse videoAbuse = default(NotificationVideoAbuse), NotificationVideoAbuse videoBlacklist = default(NotificationVideoAbuse), ActorInfo account = default(ActorInfo), NotificationActorFollow actorFollow = default(NotificationActorFollow), DateTime createdAt = default(DateTime), DateTime updatedAt = default(DateTime))
        {
            this.Id = id;
            this.Type = type;
            this.Read = read;
            this.Video = video;
            this.VideoImport = videoImport;
            this.Comment = comment;
            this.VideoAbuse = videoAbuse;
            this.VideoBlacklist = videoBlacklist;
            this.Account = account;
            this.ActorFollow = actorFollow;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        /// <example>42</example>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Notification type, following the &#x60;UserNotificationType&#x60; enum: - &#x60;1&#x60; NEW_VIDEO_FROM_SUBSCRIPTION - &#x60;2&#x60; NEW_COMMENT_ON_MY_VIDEO - &#x60;3&#x60; NEW_ABUSE_FOR_MODERATORS - &#x60;4&#x60; BLACKLIST_ON_MY_VIDEO - &#x60;5&#x60; UNBLACKLIST_ON_MY_VIDEO - &#x60;6&#x60; MY_VIDEO_PUBLISHED - &#x60;7&#x60; MY_VIDEO_IMPORT_SUCCESS - &#x60;8&#x60; MY_VIDEO_IMPORT_ERROR - &#x60;9&#x60; NEW_USER_REGISTRATION - &#x60;10&#x60; NEW_FOLLOW - &#x60;11&#x60; COMMENT_MENTION - &#x60;12&#x60; VIDEO_AUTO_BLACKLIST_FOR_MODERATORS - &#x60;13&#x60; NEW_INSTANCE_FOLLOWER - &#x60;14&#x60; AUTO_INSTANCE_FOLLOWING - &#x60;15&#x60; ABUSE_STATE_CHANGE - &#x60;16&#x60; ABUSE_NEW_MESSAGE - &#x60;17&#x60; NEW_PLUGIN_VERSION - &#x60;18&#x60; NEW_PEERTUBE_VERSION - &#x60;19&#x60; MY_VIDEO_STUDIO_EDITION_FINISHED - &#x60;20&#x60; NEW_USER_REGISTRATION_REQUEST - &#x60;21&#x60; NEW_LIVE_FROM_SUBSCRIPTION 
        /// </summary>
        /// <value>Notification type, following the &#x60;UserNotificationType&#x60; enum: - &#x60;1&#x60; NEW_VIDEO_FROM_SUBSCRIPTION - &#x60;2&#x60; NEW_COMMENT_ON_MY_VIDEO - &#x60;3&#x60; NEW_ABUSE_FOR_MODERATORS - &#x60;4&#x60; BLACKLIST_ON_MY_VIDEO - &#x60;5&#x60; UNBLACKLIST_ON_MY_VIDEO - &#x60;6&#x60; MY_VIDEO_PUBLISHED - &#x60;7&#x60; MY_VIDEO_IMPORT_SUCCESS - &#x60;8&#x60; MY_VIDEO_IMPORT_ERROR - &#x60;9&#x60; NEW_USER_REGISTRATION - &#x60;10&#x60; NEW_FOLLOW - &#x60;11&#x60; COMMENT_MENTION - &#x60;12&#x60; VIDEO_AUTO_BLACKLIST_FOR_MODERATORS - &#x60;13&#x60; NEW_INSTANCE_FOLLOWER - &#x60;14&#x60; AUTO_INSTANCE_FOLLOWING - &#x60;15&#x60; ABUSE_STATE_CHANGE - &#x60;16&#x60; ABUSE_NEW_MESSAGE - &#x60;17&#x60; NEW_PLUGIN_VERSION - &#x60;18&#x60; NEW_PEERTUBE_VERSION - &#x60;19&#x60; MY_VIDEO_STUDIO_EDITION_FINISHED - &#x60;20&#x60; NEW_USER_REGISTRATION_REQUEST - &#x60;21&#x60; NEW_LIVE_FROM_SUBSCRIPTION </value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public int Type { get; set; }

        /// <summary>
        /// Gets or Sets Read
        /// </summary>
        [DataMember(Name = "read", EmitDefaultValue = true)]
        public bool Read { get; set; }

        /// <summary>
        /// Gets or Sets Video
        /// </summary>
        [DataMember(Name = "video", EmitDefaultValue = true)]
        public NotificationVideo Video { get; set; }

        /// <summary>
        /// Gets or Sets VideoImport
        /// </summary>
        [DataMember(Name = "videoImport", EmitDefaultValue = true)]
        public NotificationVideoImport VideoImport { get; set; }

        /// <summary>
        /// Gets or Sets Comment
        /// </summary>
        [DataMember(Name = "comment", EmitDefaultValue = true)]
        public NotificationComment Comment { get; set; }

        /// <summary>
        /// Gets or Sets VideoAbuse
        /// </summary>
        [DataMember(Name = "videoAbuse", EmitDefaultValue = true)]
        public NotificationVideoAbuse VideoAbuse { get; set; }

        /// <summary>
        /// Gets or Sets VideoBlacklist
        /// </summary>
        [DataMember(Name = "videoBlacklist", EmitDefaultValue = true)]
        public NotificationVideoAbuse VideoBlacklist { get; set; }

        /// <summary>
        /// Gets or Sets Account
        /// </summary>
        [DataMember(Name = "account", EmitDefaultValue = true)]
        public ActorInfo Account { get; set; }

        /// <summary>
        /// Gets or Sets ActorFollow
        /// </summary>
        [DataMember(Name = "actorFollow", EmitDefaultValue = true)]
        public NotificationActorFollow ActorFollow { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [DataMember(Name = "updatedAt", EmitDefaultValue = false)]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Notification {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Read: ").Append(Read).Append("\n");
            sb.Append("  Video: ").Append(Video).Append("\n");
            sb.Append("  VideoImport: ").Append(VideoImport).Append("\n");
            sb.Append("  Comment: ").Append(Comment).Append("\n");
            sb.Append("  VideoAbuse: ").Append(VideoAbuse).Append("\n");
            sb.Append("  VideoBlacklist: ").Append(VideoBlacklist).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  ActorFollow: ").Append(ActorFollow).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
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

            yield break;
        }
    }

}
