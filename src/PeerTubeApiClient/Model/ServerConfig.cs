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
    /// ServerConfig
    /// </summary>
    [DataContract(Name = "ServerConfig")]
    public partial class ServerConfig : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerConfig" /> class.
        /// </summary>
        /// <param name="instance">instance.</param>
        /// <param name="search">search.</param>
        /// <param name="plugin">plugin.</param>
        /// <param name="theme">theme.</param>
        /// <param name="email">email.</param>
        /// <param name="contactForm">contactForm.</param>
        /// <param name="serverVersion">serverVersion.</param>
        /// <param name="serverCommit">serverCommit.</param>
        /// <param name="signup">signup.</param>
        /// <param name="transcoding">transcoding.</param>
        /// <param name="import">import.</param>
        /// <param name="export">export.</param>
        /// <param name="autoBlacklist">autoBlacklist.</param>
        /// <param name="avatar">avatar.</param>
        /// <param name="video">video.</param>
        /// <param name="videoCaption">videoCaption.</param>
        /// <param name="user">user.</param>
        /// <param name="trending">trending.</param>
        /// <param name="tracker">tracker.</param>
        /// <param name="followings">followings.</param>
        /// <param name="homepage">homepage.</param>
        /// <param name="openTelemetry">openTelemetry.</param>
        /// <param name="views">views.</param>
        public ServerConfig(ServerConfigInstance instance = default(ServerConfigInstance), ServerConfigSearch search = default(ServerConfigSearch), ServerConfigPlugin plugin = default(ServerConfigPlugin), ServerConfigPlugin theme = default(ServerConfigPlugin), ServerConfigEmail email = default(ServerConfigEmail), ServerConfigEmail contactForm = default(ServerConfigEmail), string serverVersion = default(string), string serverCommit = default(string), ServerConfigSignup signup = default(ServerConfigSignup), ServerConfigTranscoding transcoding = default(ServerConfigTranscoding), ServerConfigImport import = default(ServerConfigImport), ServerConfigExport export = default(ServerConfigExport), ServerConfigAutoBlacklist autoBlacklist = default(ServerConfigAutoBlacklist), ServerConfigAvatar avatar = default(ServerConfigAvatar), ServerConfigVideo video = default(ServerConfigVideo), ServerConfigVideoCaption videoCaption = default(ServerConfigVideoCaption), ServerConfigUser user = default(ServerConfigUser), ServerConfigTrending trending = default(ServerConfigTrending), ServerConfigEmail tracker = default(ServerConfigEmail), ServerConfigFollowings followings = default(ServerConfigFollowings), ServerConfigEmail homepage = default(ServerConfigEmail), ServerConfigOpenTelemetry openTelemetry = default(ServerConfigOpenTelemetry), ServerConfigViews views = default(ServerConfigViews))
        {
            this.Instance = instance;
            this.Search = search;
            this.Plugin = plugin;
            this.Theme = theme;
            this.Email = email;
            this.ContactForm = contactForm;
            this.ServerVersion = serverVersion;
            this.ServerCommit = serverCommit;
            this.Signup = signup;
            this.Transcoding = transcoding;
            this.Import = import;
            this.Export = export;
            this.AutoBlacklist = autoBlacklist;
            this.Avatar = avatar;
            this.Video = video;
            this.VideoCaption = videoCaption;
            this.User = user;
            this.Trending = trending;
            this.Tracker = tracker;
            this.Followings = followings;
            this.Homepage = homepage;
            this.OpenTelemetry = openTelemetry;
            this.Views = views;
        }

        /// <summary>
        /// Gets or Sets Instance
        /// </summary>
        [DataMember(Name = "instance", EmitDefaultValue = false)]
        public ServerConfigInstance Instance { get; set; }

        /// <summary>
        /// Gets or Sets Search
        /// </summary>
        [DataMember(Name = "search", EmitDefaultValue = false)]
        public ServerConfigSearch Search { get; set; }

        /// <summary>
        /// Gets or Sets Plugin
        /// </summary>
        [DataMember(Name = "plugin", EmitDefaultValue = false)]
        public ServerConfigPlugin Plugin { get; set; }

        /// <summary>
        /// Gets or Sets Theme
        /// </summary>
        [DataMember(Name = "theme", EmitDefaultValue = false)]
        public ServerConfigPlugin Theme { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public ServerConfigEmail Email { get; set; }

        /// <summary>
        /// Gets or Sets ContactForm
        /// </summary>
        [DataMember(Name = "contactForm", EmitDefaultValue = false)]
        public ServerConfigEmail ContactForm { get; set; }

        /// <summary>
        /// Gets or Sets ServerVersion
        /// </summary>
        [DataMember(Name = "serverVersion", EmitDefaultValue = false)]
        public string ServerVersion { get; set; }

        /// <summary>
        /// Gets or Sets ServerCommit
        /// </summary>
        [DataMember(Name = "serverCommit", EmitDefaultValue = false)]
        public string ServerCommit { get; set; }

        /// <summary>
        /// Gets or Sets Signup
        /// </summary>
        [DataMember(Name = "signup", EmitDefaultValue = false)]
        public ServerConfigSignup Signup { get; set; }

        /// <summary>
        /// Gets or Sets Transcoding
        /// </summary>
        [DataMember(Name = "transcoding", EmitDefaultValue = false)]
        public ServerConfigTranscoding Transcoding { get; set; }

        /// <summary>
        /// Gets or Sets Import
        /// </summary>
        [DataMember(Name = "import", EmitDefaultValue = false)]
        public ServerConfigImport Import { get; set; }

        /// <summary>
        /// Gets or Sets Export
        /// </summary>
        [DataMember(Name = "export", EmitDefaultValue = false)]
        public ServerConfigExport Export { get; set; }

        /// <summary>
        /// Gets or Sets AutoBlacklist
        /// </summary>
        [DataMember(Name = "autoBlacklist", EmitDefaultValue = false)]
        public ServerConfigAutoBlacklist AutoBlacklist { get; set; }

        /// <summary>
        /// Gets or Sets Avatar
        /// </summary>
        [DataMember(Name = "avatar", EmitDefaultValue = false)]
        public ServerConfigAvatar Avatar { get; set; }

        /// <summary>
        /// Gets or Sets Video
        /// </summary>
        [DataMember(Name = "video", EmitDefaultValue = false)]
        public ServerConfigVideo Video { get; set; }

        /// <summary>
        /// Gets or Sets VideoCaption
        /// </summary>
        [DataMember(Name = "videoCaption", EmitDefaultValue = false)]
        public ServerConfigVideoCaption VideoCaption { get; set; }

        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public ServerConfigUser User { get; set; }

        /// <summary>
        /// Gets or Sets Trending
        /// </summary>
        [DataMember(Name = "trending", EmitDefaultValue = false)]
        public ServerConfigTrending Trending { get; set; }

        /// <summary>
        /// Gets or Sets Tracker
        /// </summary>
        [DataMember(Name = "tracker", EmitDefaultValue = false)]
        public ServerConfigEmail Tracker { get; set; }

        /// <summary>
        /// Gets or Sets Followings
        /// </summary>
        [DataMember(Name = "followings", EmitDefaultValue = false)]
        public ServerConfigFollowings Followings { get; set; }

        /// <summary>
        /// Gets or Sets Homepage
        /// </summary>
        [DataMember(Name = "homepage", EmitDefaultValue = false)]
        public ServerConfigEmail Homepage { get; set; }

        /// <summary>
        /// Gets or Sets OpenTelemetry
        /// </summary>
        [DataMember(Name = "openTelemetry", EmitDefaultValue = false)]
        public ServerConfigOpenTelemetry OpenTelemetry { get; set; }

        /// <summary>
        /// Gets or Sets Views
        /// </summary>
        [DataMember(Name = "views", EmitDefaultValue = false)]
        public ServerConfigViews Views { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ServerConfig {\n");
            sb.Append("  Instance: ").Append(Instance).Append("\n");
            sb.Append("  Search: ").Append(Search).Append("\n");
            sb.Append("  Plugin: ").Append(Plugin).Append("\n");
            sb.Append("  Theme: ").Append(Theme).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  ContactForm: ").Append(ContactForm).Append("\n");
            sb.Append("  ServerVersion: ").Append(ServerVersion).Append("\n");
            sb.Append("  ServerCommit: ").Append(ServerCommit).Append("\n");
            sb.Append("  Signup: ").Append(Signup).Append("\n");
            sb.Append("  Transcoding: ").Append(Transcoding).Append("\n");
            sb.Append("  Import: ").Append(Import).Append("\n");
            sb.Append("  Export: ").Append(Export).Append("\n");
            sb.Append("  AutoBlacklist: ").Append(AutoBlacklist).Append("\n");
            sb.Append("  Avatar: ").Append(Avatar).Append("\n");
            sb.Append("  Video: ").Append(Video).Append("\n");
            sb.Append("  VideoCaption: ").Append(VideoCaption).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
            sb.Append("  Trending: ").Append(Trending).Append("\n");
            sb.Append("  Tracker: ").Append(Tracker).Append("\n");
            sb.Append("  Followings: ").Append(Followings).Append("\n");
            sb.Append("  Homepage: ").Append(Homepage).Append("\n");
            sb.Append("  OpenTelemetry: ").Append(OpenTelemetry).Append("\n");
            sb.Append("  Views: ").Append(Views).Append("\n");
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
