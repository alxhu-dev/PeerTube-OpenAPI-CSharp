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
    /// VideoUploadRequestResumable
    /// </summary>
    [DataContract(Name = "VideoUploadRequestResumable")]
    public partial class VideoUploadRequestResumable : IValidatableObject
    {

        /// <summary>
        /// Gets or Sets Privacy
        /// </summary>
        [DataMember(Name = "privacy", EmitDefaultValue = false)]
        public VideoPrivacySet? Privacy { get; set; }

        /// <summary>
        /// Gets or Sets CommentsPolicy
        /// </summary>
        [DataMember(Name = "commentsPolicy", EmitDefaultValue = false)]
        public VideoCommentsPolicySet? CommentsPolicy { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoUploadRequestResumable" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected VideoUploadRequestResumable() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoUploadRequestResumable" /> class.
        /// </summary>
        /// <param name="name">Video name (required).</param>
        /// <param name="channelId">Channel id that will contain this video (required).</param>
        /// <param name="privacy">privacy.</param>
        /// <param name="category">category id of the video (see [/videos/categories](#operation/getCategories)).</param>
        /// <param name="licence">licence id of the video (see [/videos/licences](#operation/getLicences)).</param>
        /// <param name="language">language id of the video (see [/videos/languages](#operation/getLanguages)).</param>
        /// <param name="description">Video description.</param>
        /// <param name="waitTranscoding">Whether or not we wait transcoding before publish the video.</param>
        /// <param name="generateTranscription">**PeerTube &gt;&#x3D; 6.2** If enabled by the admin, automatically generate a subtitle of the video.</param>
        /// <param name="support">A text tell the audience how to support the video creator.</param>
        /// <param name="nsfw">Whether or not this video contains sensitive content.</param>
        /// <param name="tags">Video tags (maximum 5 tags each between 2 and 30 characters).</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead.</param>
        /// <param name="commentsPolicy">commentsPolicy.</param>
        /// <param name="downloadEnabled">Enable or disable downloading for this video.</param>
        /// <param name="originallyPublishedAt">Date when the content was originally published.</param>
        /// <param name="scheduleUpdate">scheduleUpdate.</param>
        /// <param name="thumbnailfile">Video thumbnail file.</param>
        /// <param name="previewfile">Video preview file.</param>
        /// <param name="videoPasswords">videoPasswords.</param>
        /// <param name="filename">Video filename including extension (required).</param>
        public VideoUploadRequestResumable(string name = default(string), int channelId = default(int), VideoPrivacySet? privacy = default(VideoPrivacySet?), int category = default(int), int licence = default(int), string language = default(string), string description = default(string), bool waitTranscoding = default(bool), bool generateTranscription = default(bool), string support = default(string), bool nsfw = default(bool), List<string> tags = default(List<string>), bool commentsEnabled = default(bool), VideoCommentsPolicySet? commentsPolicy = default(VideoCommentsPolicySet?), bool downloadEnabled = default(bool), DateTime originallyPublishedAt = default(DateTime), VideoScheduledUpdate scheduleUpdate = default(VideoScheduledUpdate), System.IO.Stream thumbnailfile = default(System.IO.Stream), System.IO.Stream previewfile = default(System.IO.Stream), List<string> videoPasswords = default(List<string>), string filename = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for VideoUploadRequestResumable and cannot be null");
            }
            this.Name = name;
            this.ChannelId = channelId;
            // to ensure "filename" is required (not null)
            if (filename == null)
            {
                throw new ArgumentNullException("filename is a required property for VideoUploadRequestResumable and cannot be null");
            }
            this.Filename = filename;
            this.Privacy = privacy;
            this.Category = category;
            this.Licence = licence;
            this.Language = language;
            this.Description = description;
            this.WaitTranscoding = waitTranscoding;
            this.GenerateTranscription = generateTranscription;
            this.Support = support;
            this.Nsfw = nsfw;
            this.Tags = tags;
            this.CommentsEnabled = commentsEnabled;
            this.CommentsPolicy = commentsPolicy;
            this.DownloadEnabled = downloadEnabled;
            this.OriginallyPublishedAt = originallyPublishedAt;
            this.ScheduleUpdate = scheduleUpdate;
            this.Thumbnailfile = thumbnailfile;
            this.Previewfile = previewfile;
            this.VideoPasswords = videoPasswords;
        }

        /// <summary>
        /// Video name
        /// </summary>
        /// <value>Video name</value>
        /// <example>What is PeerTube?</example>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Channel id that will contain this video
        /// </summary>
        /// <value>Channel id that will contain this video</value>
        /// <example>3</example>
        [DataMember(Name = "channelId", IsRequired = true, EmitDefaultValue = true)]
        public int ChannelId { get; set; }

        /// <summary>
        /// category id of the video (see [/videos/categories](#operation/getCategories))
        /// </summary>
        /// <value>category id of the video (see [/videos/categories](#operation/getCategories))</value>
        /// <example>15</example>
        [DataMember(Name = "category", EmitDefaultValue = false)]
        public int Category { get; set; }

        /// <summary>
        /// licence id of the video (see [/videos/licences](#operation/getLicences))
        /// </summary>
        /// <value>licence id of the video (see [/videos/licences](#operation/getLicences))</value>
        /// <example>2</example>
        [DataMember(Name = "licence", EmitDefaultValue = false)]
        public int Licence { get; set; }

        /// <summary>
        /// language id of the video (see [/videos/languages](#operation/getLanguages))
        /// </summary>
        /// <value>language id of the video (see [/videos/languages](#operation/getLanguages))</value>
        /// <example>en</example>
        [DataMember(Name = "language", EmitDefaultValue = false)]
        public string Language { get; set; }

        /// <summary>
        /// Video description
        /// </summary>
        /// <value>Video description</value>
        /// <example>**[Want to help to translate this video?](https://weblate.framasoft.org/projects/what-is-peertube-video/)**\r\n\r\n**Take back the control of your videos! [#JoinPeertube](https://joinpeertube.org)**
</example>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Whether or not we wait transcoding before publish the video
        /// </summary>
        /// <value>Whether or not we wait transcoding before publish the video</value>
        [DataMember(Name = "waitTranscoding", EmitDefaultValue = true)]
        public bool WaitTranscoding { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.2** If enabled by the admin, automatically generate a subtitle of the video
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.2** If enabled by the admin, automatically generate a subtitle of the video</value>
        [DataMember(Name = "generateTranscription", EmitDefaultValue = true)]
        public bool GenerateTranscription { get; set; }

        /// <summary>
        /// A text tell the audience how to support the video creator
        /// </summary>
        /// <value>A text tell the audience how to support the video creator</value>
        /// <example>Please support our work on https://soutenir.framasoft.org/en/ &lt;3</example>
        [DataMember(Name = "support", EmitDefaultValue = false)]
        public string Support { get; set; }

        /// <summary>
        /// Whether or not this video contains sensitive content
        /// </summary>
        /// <value>Whether or not this video contains sensitive content</value>
        [DataMember(Name = "nsfw", EmitDefaultValue = true)]
        public bool Nsfw { get; set; }

        /// <summary>
        /// Video tags (maximum 5 tags each between 2 and 30 characters)
        /// </summary>
        /// <value>Video tags (maximum 5 tags each between 2 and 30 characters)</value>
        /// <example>[framasoft, peertube]</example>
        [DataMember(Name = "tags", EmitDefaultValue = false)]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Deprecated in 6.2, use commentsPolicy instead
        /// </summary>
        /// <value>Deprecated in 6.2, use commentsPolicy instead</value>
        [DataMember(Name = "commentsEnabled", EmitDefaultValue = true)]
        [Obsolete]
        public bool CommentsEnabled { get; set; }

        /// <summary>
        /// Enable or disable downloading for this video
        /// </summary>
        /// <value>Enable or disable downloading for this video</value>
        [DataMember(Name = "downloadEnabled", EmitDefaultValue = true)]
        public bool DownloadEnabled { get; set; }

        /// <summary>
        /// Date when the content was originally published
        /// </summary>
        /// <value>Date when the content was originally published</value>
        [DataMember(Name = "originallyPublishedAt", EmitDefaultValue = false)]
        public DateTime OriginallyPublishedAt { get; set; }

        /// <summary>
        /// Gets or Sets ScheduleUpdate
        /// </summary>
        [DataMember(Name = "scheduleUpdate", EmitDefaultValue = false)]
        public VideoScheduledUpdate ScheduleUpdate { get; set; }

        /// <summary>
        /// Video thumbnail file
        /// </summary>
        /// <value>Video thumbnail file</value>
        [DataMember(Name = "thumbnailfile", EmitDefaultValue = false)]
        public System.IO.Stream Thumbnailfile { get; set; }

        /// <summary>
        /// Video preview file
        /// </summary>
        /// <value>Video preview file</value>
        [DataMember(Name = "previewfile", EmitDefaultValue = false)]
        public System.IO.Stream Previewfile { get; set; }

        /// <summary>
        /// Gets or Sets VideoPasswords
        /// </summary>
        [DataMember(Name = "videoPasswords", EmitDefaultValue = false)]
        public List<string> VideoPasswords { get; set; }

        /// <summary>
        /// Video filename including extension
        /// </summary>
        /// <value>Video filename including extension</value>
        /// <example>what_is_peertube.mp4</example>
        [DataMember(Name = "filename", IsRequired = true, EmitDefaultValue = true)]
        public string Filename { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class VideoUploadRequestResumable {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ChannelId: ").Append(ChannelId).Append("\n");
            sb.Append("  Privacy: ").Append(Privacy).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Licence: ").Append(Licence).Append("\n");
            sb.Append("  Language: ").Append(Language).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  WaitTranscoding: ").Append(WaitTranscoding).Append("\n");
            sb.Append("  GenerateTranscription: ").Append(GenerateTranscription).Append("\n");
            sb.Append("  Support: ").Append(Support).Append("\n");
            sb.Append("  Nsfw: ").Append(Nsfw).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  CommentsEnabled: ").Append(CommentsEnabled).Append("\n");
            sb.Append("  CommentsPolicy: ").Append(CommentsPolicy).Append("\n");
            sb.Append("  DownloadEnabled: ").Append(DownloadEnabled).Append("\n");
            sb.Append("  OriginallyPublishedAt: ").Append(OriginallyPublishedAt).Append("\n");
            sb.Append("  ScheduleUpdate: ").Append(ScheduleUpdate).Append("\n");
            sb.Append("  Thumbnailfile: ").Append(Thumbnailfile).Append("\n");
            sb.Append("  Previewfile: ").Append(Previewfile).Append("\n");
            sb.Append("  VideoPasswords: ").Append(VideoPasswords).Append("\n");
            sb.Append("  Filename: ").Append(Filename).Append("\n");
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
            // Name (string) maxLength
            if (this.Name != null && this.Name.Length > 120)
            {
                yield return new ValidationResult("Invalid value for Name, length must be less than 120.", new [] { "Name" });
            }

            // Name (string) minLength
            if (this.Name != null && this.Name.Length < 3)
            {
                yield return new ValidationResult("Invalid value for Name, length must be greater than 3.", new [] { "Name" });
            }

            // ChannelId (int) minimum
            if (this.ChannelId < (int)1)
            {
                yield return new ValidationResult("Invalid value for ChannelId, must be a value greater than or equal to 1.", new [] { "ChannelId" });
            }

            yield break;
        }
    }

}
