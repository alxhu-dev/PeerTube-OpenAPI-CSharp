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
    /// Settings pertaining to transcoding jobs
    /// </summary>
    [DataContract(Name = "ServerConfigCustom_transcoding")]
    public partial class ServerConfigCustomTranscoding : IValidatableObject
    {
        /// <summary>
        /// New profiles can be added by plugins ; available in core PeerTube: &#39;default&#39;. 
        /// </summary>
        /// <value>New profiles can be added by plugins ; available in core PeerTube: &#39;default&#39;. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ProfileEnum
        {
            /// <summary>
            /// Enum Default for value: default
            /// </summary>
            [EnumMember(Value = "default")]
            Default = 1
        }


        /// <summary>
        /// New profiles can be added by plugins ; available in core PeerTube: &#39;default&#39;. 
        /// </summary>
        /// <value>New profiles can be added by plugins ; available in core PeerTube: &#39;default&#39;. </value>
        [DataMember(Name = "profile", EmitDefaultValue = false)]
        public ProfileEnum? Profile { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerConfigCustomTranscoding" /> class.
        /// </summary>
        /// <param name="enabled">enabled.</param>
        /// <param name="originalFile">originalFile.</param>
        /// <param name="allowAdditionalExtensions">Allow your users to upload .mkv, .mov, .avi, .wmv, .flv, .f4v, .3g2, .3gp, .mts, m2ts, .mxf, .nut videos.</param>
        /// <param name="allowAudioFiles">If a user uploads an audio file, PeerTube will create a video by merging the preview file and the audio file.</param>
        /// <param name="threads">Amount of threads used by ffmpeg for 1 transcoding job.</param>
        /// <param name="concurrency">Amount of transcoding jobs to execute in parallel.</param>
        /// <param name="profile">New profiles can be added by plugins ; available in core PeerTube: &#39;default&#39;. .</param>
        /// <param name="resolutions">resolutions.</param>
        /// <param name="webVideos">webVideos.</param>
        /// <param name="hls">hls.</param>
        public ServerConfigCustomTranscoding(bool enabled = default(bool), ServerConfigCustomTranscodingOriginalFile originalFile = default(ServerConfigCustomTranscodingOriginalFile), bool allowAdditionalExtensions = default(bool), bool allowAudioFiles = default(bool), int threads = default(int), decimal concurrency = default(decimal), ProfileEnum? profile = default(ProfileEnum?), ServerConfigCustomTranscodingResolutions resolutions = default(ServerConfigCustomTranscodingResolutions), ServerConfigCustomTranscodingWebVideos webVideos = default(ServerConfigCustomTranscodingWebVideos), ServerConfigCustomTranscodingHls hls = default(ServerConfigCustomTranscodingHls))
        {
            this.Enabled = enabled;
            this.OriginalFile = originalFile;
            this.AllowAdditionalExtensions = allowAdditionalExtensions;
            this.AllowAudioFiles = allowAudioFiles;
            this.Threads = threads;
            this.Concurrency = concurrency;
            this.Profile = profile;
            this.Resolutions = resolutions;
            this.WebVideos = webVideos;
            this.Hls = hls;
        }

        /// <summary>
        /// Gets or Sets Enabled
        /// </summary>
        [DataMember(Name = "enabled", EmitDefaultValue = true)]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or Sets OriginalFile
        /// </summary>
        [DataMember(Name = "originalFile", EmitDefaultValue = false)]
        public ServerConfigCustomTranscodingOriginalFile OriginalFile { get; set; }

        /// <summary>
        /// Allow your users to upload .mkv, .mov, .avi, .wmv, .flv, .f4v, .3g2, .3gp, .mts, m2ts, .mxf, .nut videos
        /// </summary>
        /// <value>Allow your users to upload .mkv, .mov, .avi, .wmv, .flv, .f4v, .3g2, .3gp, .mts, m2ts, .mxf, .nut videos</value>
        [DataMember(Name = "allowAdditionalExtensions", EmitDefaultValue = true)]
        public bool AllowAdditionalExtensions { get; set; }

        /// <summary>
        /// If a user uploads an audio file, PeerTube will create a video by merging the preview file and the audio file
        /// </summary>
        /// <value>If a user uploads an audio file, PeerTube will create a video by merging the preview file and the audio file</value>
        [DataMember(Name = "allowAudioFiles", EmitDefaultValue = true)]
        public bool AllowAudioFiles { get; set; }

        /// <summary>
        /// Amount of threads used by ffmpeg for 1 transcoding job
        /// </summary>
        /// <value>Amount of threads used by ffmpeg for 1 transcoding job</value>
        [DataMember(Name = "threads", EmitDefaultValue = false)]
        public int Threads { get; set; }

        /// <summary>
        /// Amount of transcoding jobs to execute in parallel
        /// </summary>
        /// <value>Amount of transcoding jobs to execute in parallel</value>
        [DataMember(Name = "concurrency", EmitDefaultValue = false)]
        public decimal Concurrency { get; set; }

        /// <summary>
        /// Gets or Sets Resolutions
        /// </summary>
        [DataMember(Name = "resolutions", EmitDefaultValue = false)]
        public ServerConfigCustomTranscodingResolutions Resolutions { get; set; }

        /// <summary>
        /// Gets or Sets WebVideos
        /// </summary>
        [DataMember(Name = "web_videos", EmitDefaultValue = false)]
        public ServerConfigCustomTranscodingWebVideos WebVideos { get; set; }

        /// <summary>
        /// Gets or Sets Hls
        /// </summary>
        [DataMember(Name = "hls", EmitDefaultValue = false)]
        public ServerConfigCustomTranscodingHls Hls { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ServerConfigCustomTranscoding {\n");
            sb.Append("  Enabled: ").Append(Enabled).Append("\n");
            sb.Append("  OriginalFile: ").Append(OriginalFile).Append("\n");
            sb.Append("  AllowAdditionalExtensions: ").Append(AllowAdditionalExtensions).Append("\n");
            sb.Append("  AllowAudioFiles: ").Append(AllowAudioFiles).Append("\n");
            sb.Append("  Threads: ").Append(Threads).Append("\n");
            sb.Append("  Concurrency: ").Append(Concurrency).Append("\n");
            sb.Append("  Profile: ").Append(Profile).Append("\n");
            sb.Append("  Resolutions: ").Append(Resolutions).Append("\n");
            sb.Append("  WebVideos: ").Append(WebVideos).Append("\n");
            sb.Append("  Hls: ").Append(Hls).Append("\n");
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
