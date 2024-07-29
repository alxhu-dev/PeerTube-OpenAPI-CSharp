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
    /// VideoPlaylist
    /// </summary>
    [DataContract(Name = "VideoPlaylist")]
    public partial class VideoPlaylist : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoPlaylist" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="uuid">uuid.</param>
        /// <param name="shortUUID">translation of a uuid v4 with a bigger alphabet to have a shorter uuid.</param>
        /// <param name="createdAt">createdAt.</param>
        /// <param name="updatedAt">updatedAt.</param>
        /// <param name="description">description.</param>
        /// <param name="displayName">displayName.</param>
        /// <param name="isLocal">isLocal.</param>
        /// <param name="videoLength">videoLength.</param>
        /// <param name="thumbnailPath">thumbnailPath.</param>
        /// <param name="privacy">privacy.</param>
        /// <param name="type">type.</param>
        /// <param name="ownerAccount">ownerAccount.</param>
        /// <param name="videoChannel">videoChannel.</param>
        public VideoPlaylist(int id = default(int), Guid uuid = default(Guid), string shortUUID = default(string), DateTime createdAt = default(DateTime), DateTime updatedAt = default(DateTime), string description = default(string), string displayName = default(string), bool isLocal = default(bool), int videoLength = default(int), string thumbnailPath = default(string), VideoPlaylistPrivacyConstant privacy = default(VideoPlaylistPrivacyConstant), VideoPlaylistTypeConstant type = default(VideoPlaylistTypeConstant), AccountSummary ownerAccount = default(AccountSummary), VideoChannelSummary videoChannel = default(VideoChannelSummary))
        {
            this.Id = id;
            this.Uuid = uuid;
            this.ShortUUID = shortUUID;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.Description = description;
            this.DisplayName = displayName;
            this.IsLocal = isLocal;
            this.VideoLength = videoLength;
            this.ThumbnailPath = thumbnailPath;
            this.Privacy = privacy;
            this.Type = type;
            this.OwnerAccount = ownerAccount;
            this.VideoChannel = videoChannel;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        /// <example>42</example>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Uuid
        /// </summary>
        /// <example>9c9de5e8-0a1e-484a-b099-e80766180a6d</example>
        [DataMember(Name = "uuid", EmitDefaultValue = false)]
        public Guid Uuid { get; set; }

        /// <summary>
        /// translation of a uuid v4 with a bigger alphabet to have a shorter uuid
        /// </summary>
        /// <value>translation of a uuid v4 with a bigger alphabet to have a shorter uuid</value>
        /// <example>2y84q2MQUMWPbiEcxNXMgC</example>
        [DataMember(Name = "shortUUID", EmitDefaultValue = false)]
        public string ShortUUID { get; set; }

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
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        [DataMember(Name = "displayName", EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets IsLocal
        /// </summary>
        [DataMember(Name = "isLocal", EmitDefaultValue = true)]
        public bool IsLocal { get; set; }

        /// <summary>
        /// Gets or Sets VideoLength
        /// </summary>
        [DataMember(Name = "videoLength", EmitDefaultValue = false)]
        public int VideoLength { get; set; }

        /// <summary>
        /// Gets or Sets ThumbnailPath
        /// </summary>
        [DataMember(Name = "thumbnailPath", EmitDefaultValue = false)]
        public string ThumbnailPath { get; set; }

        /// <summary>
        /// Gets or Sets Privacy
        /// </summary>
        [DataMember(Name = "privacy", EmitDefaultValue = false)]
        public VideoPlaylistPrivacyConstant Privacy { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public VideoPlaylistTypeConstant Type { get; set; }

        /// <summary>
        /// Gets or Sets OwnerAccount
        /// </summary>
        [DataMember(Name = "ownerAccount", EmitDefaultValue = false)]
        public AccountSummary OwnerAccount { get; set; }

        /// <summary>
        /// Gets or Sets VideoChannel
        /// </summary>
        [DataMember(Name = "videoChannel", EmitDefaultValue = false)]
        public VideoChannelSummary VideoChannel { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class VideoPlaylist {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Uuid: ").Append(Uuid).Append("\n");
            sb.Append("  ShortUUID: ").Append(ShortUUID).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  IsLocal: ").Append(IsLocal).Append("\n");
            sb.Append("  VideoLength: ").Append(VideoLength).Append("\n");
            sb.Append("  ThumbnailPath: ").Append(ThumbnailPath).Append("\n");
            sb.Append("  Privacy: ").Append(Privacy).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  OwnerAccount: ").Append(OwnerAccount).Append("\n");
            sb.Append("  VideoChannel: ").Append(VideoChannel).Append("\n");
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

            // Uuid (Guid) maxLength
            if (this.Uuid != null && this.Uuid.Length > 36)
            {
                yield return new ValidationResult("Invalid value for Uuid, length must be less than 36.", new [] { "Uuid" });
            }

            // Uuid (Guid) minLength
            if (this.Uuid != null && this.Uuid.Length < 36)
            {
                yield return new ValidationResult("Invalid value for Uuid, length must be greater than 36.", new [] { "Uuid" });
            }

            if (this.Uuid != null) {
                // Uuid (Guid) pattern
                Regex regexUuid = new Regex(@"^[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$", RegexOptions.CultureInvariant);
                if (!regexUuid.Match(this.Uuid.ToString()).Success)
                {
                    yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Uuid, must match a pattern of " + regexUuid, new [] { "Uuid" });
                }
            }

            // Description (string) maxLength
            if (this.Description != null && this.Description.Length > 1000)
            {
                yield return new ValidationResult("Invalid value for Description, length must be less than 1000.", new [] { "Description" });
            }

            // Description (string) minLength
            if (this.Description != null && this.Description.Length < 3)
            {
                yield return new ValidationResult("Invalid value for Description, length must be greater than 3.", new [] { "Description" });
            }

            // DisplayName (string) maxLength
            if (this.DisplayName != null && this.DisplayName.Length > 120)
            {
                yield return new ValidationResult("Invalid value for DisplayName, length must be less than 120.", new [] { "DisplayName" });
            }

            // DisplayName (string) minLength
            if (this.DisplayName != null && this.DisplayName.Length < 1)
            {
                yield return new ValidationResult("Invalid value for DisplayName, length must be greater than 1.", new [] { "DisplayName" });
            }

            // VideoLength (int) minimum
            if (this.VideoLength < (int)0)
            {
                yield return new ValidationResult("Invalid value for VideoLength, must be a value greater than or equal to 0.", new [] { "VideoLength" });
            }

            yield break;
        }
    }

}
