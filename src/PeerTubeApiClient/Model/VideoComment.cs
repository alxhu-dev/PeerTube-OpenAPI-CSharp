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
    /// VideoComment
    /// </summary>
    [DataContract(Name = "VideoComment")]
    public partial class VideoComment : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoComment" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="url">url.</param>
        /// <param name="text">Text of the comment.</param>
        /// <param name="threadId">threadId.</param>
        /// <param name="inReplyToCommentId">inReplyToCommentId.</param>
        /// <param name="videoId">videoId.</param>
        /// <param name="createdAt">createdAt.</param>
        /// <param name="updatedAt">updatedAt.</param>
        /// <param name="deletedAt">deletedAt.</param>
        /// <param name="isDeleted">isDeleted (default to false).</param>
        /// <param name="heldForReview">heldForReview.</param>
        /// <param name="totalRepliesFromVideoAuthor">totalRepliesFromVideoAuthor.</param>
        /// <param name="totalReplies">totalReplies.</param>
        /// <param name="account">account.</param>
        public VideoComment(int id = default(int), string url = default(string), string text = default(string), int threadId = default(int), int inReplyToCommentId = default(int), int videoId = default(int), DateTime createdAt = default(DateTime), DateTime updatedAt = default(DateTime), DateTime? deletedAt = default(DateTime?), bool isDeleted = false, bool heldForReview = default(bool), int totalRepliesFromVideoAuthor = default(int), int totalReplies = default(int), Account account = default(Account))
        {
            this.Id = id;
            this.Url = url;
            this.Text = text;
            this.ThreadId = threadId;
            this.InReplyToCommentId = inReplyToCommentId;
            this.VideoId = videoId;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.DeletedAt = deletedAt;
            this.IsDeleted = isDeleted;
            this.HeldForReview = heldForReview;
            this.TotalRepliesFromVideoAuthor = totalRepliesFromVideoAuthor;
            this.TotalReplies = totalReplies;
            this.Account = account;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        /// <example>42</example>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// Text of the comment
        /// </summary>
        /// <value>Text of the comment</value>
        /// <example>This video is wonderful!</example>
        [DataMember(Name = "text", EmitDefaultValue = false)]
        public string Text { get; set; }

        /// <summary>
        /// Gets or Sets ThreadId
        /// </summary>
        /// <example>42</example>
        [DataMember(Name = "threadId", EmitDefaultValue = false)]
        public int ThreadId { get; set; }

        /// <summary>
        /// Gets or Sets InReplyToCommentId
        /// </summary>
        /// <example>42</example>
        [DataMember(Name = "inReplyToCommentId", EmitDefaultValue = true)]
        public int InReplyToCommentId { get; set; }

        /// <summary>
        /// Gets or Sets VideoId
        /// </summary>
        /// <example>42</example>
        [DataMember(Name = "videoId", EmitDefaultValue = false)]
        public int VideoId { get; set; }

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
        /// Gets or Sets DeletedAt
        /// </summary>
        [DataMember(Name = "deletedAt", EmitDefaultValue = true)]
        public DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Gets or Sets IsDeleted
        /// </summary>
        [DataMember(Name = "isDeleted", EmitDefaultValue = true)]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or Sets HeldForReview
        /// </summary>
        [DataMember(Name = "heldForReview", EmitDefaultValue = true)]
        public bool HeldForReview { get; set; }

        /// <summary>
        /// Gets or Sets TotalRepliesFromVideoAuthor
        /// </summary>
        [DataMember(Name = "totalRepliesFromVideoAuthor", EmitDefaultValue = false)]
        public int TotalRepliesFromVideoAuthor { get; set; }

        /// <summary>
        /// Gets or Sets TotalReplies
        /// </summary>
        [DataMember(Name = "totalReplies", EmitDefaultValue = false)]
        public int TotalReplies { get; set; }

        /// <summary>
        /// Gets or Sets Account
        /// </summary>
        [DataMember(Name = "account", EmitDefaultValue = false)]
        public Account Account { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class VideoComment {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("  ThreadId: ").Append(ThreadId).Append("\n");
            sb.Append("  InReplyToCommentId: ").Append(InReplyToCommentId).Append("\n");
            sb.Append("  VideoId: ").Append(VideoId).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  DeletedAt: ").Append(DeletedAt).Append("\n");
            sb.Append("  IsDeleted: ").Append(IsDeleted).Append("\n");
            sb.Append("  HeldForReview: ").Append(HeldForReview).Append("\n");
            sb.Append("  TotalRepliesFromVideoAuthor: ").Append(TotalRepliesFromVideoAuthor).Append("\n");
            sb.Append("  TotalReplies: ").Append(TotalReplies).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
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

            // Text (string) minLength
            if (this.Text != null && this.Text.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Text, length must be greater than 1.", new [] { "Text" });
            }

            // ThreadId (int) minimum
            if (this.ThreadId < (int)1)
            {
                yield return new ValidationResult("Invalid value for ThreadId, must be a value greater than or equal to 1.", new [] { "ThreadId" });
            }

            // InReplyToCommentId (int) minimum
            if (this.InReplyToCommentId < (int)1)
            {
                yield return new ValidationResult("Invalid value for InReplyToCommentId, must be a value greater than or equal to 1.", new [] { "InReplyToCommentId" });
            }

            // VideoId (int) minimum
            if (this.VideoId < (int)1)
            {
                yield return new ValidationResult("Invalid value for VideoId, must be a value greater than or equal to 1.", new [] { "VideoId" });
            }

            // TotalRepliesFromVideoAuthor (int) minimum
            if (this.TotalRepliesFromVideoAuthor < (int)0)
            {
                yield return new ValidationResult("Invalid value for TotalRepliesFromVideoAuthor, must be a value greater than or equal to 0.", new [] { "TotalRepliesFromVideoAuthor" });
            }

            // TotalReplies (int) minimum
            if (this.TotalReplies < (int)0)
            {
                yield return new ValidationResult("Invalid value for TotalReplies, must be a value greater than or equal to 0.", new [] { "TotalReplies" });
            }

            yield break;
        }
    }

}
