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
    /// AddUser
    /// </summary>
    [DataContract(Name = "AddUser")]
    public partial class AddUser : IValidatableObject
    {

        /// <summary>
        /// Gets or Sets AdminFlags
        /// </summary>
        [DataMember(Name = "adminFlags", EmitDefaultValue = false)]
        public UserAdminFlags? AdminFlags { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AddUser" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AddUser() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AddUser" /> class.
        /// </summary>
        /// <param name="username">immutable name of the user, used to find or mention its actor (required).</param>
        /// <param name="password">password (required).</param>
        /// <param name="email">The user email (required).</param>
        /// <param name="videoQuota">The user video quota in bytes.</param>
        /// <param name="videoQuotaDaily">The user daily video quota in bytes.</param>
        /// <param name="channelName">immutable name of the channel, used to interact with its actor.</param>
        /// <param name="role">role (required).</param>
        /// <param name="adminFlags">adminFlags.</param>
        public AddUser(string username = default(string), string password = default(string), string email = default(string), int videoQuota = default(int), int videoQuotaDaily = default(int), string channelName = default(string), UserRole role = default(UserRole), UserAdminFlags? adminFlags = default(UserAdminFlags?))
        {
            // to ensure "username" is required (not null)
            if (username == null)
            {
                throw new ArgumentNullException("username is a required property for AddUser and cannot be null");
            }
            this.Username = username;
            // to ensure "password" is required (not null)
            if (password == null)
            {
                throw new ArgumentNullException("password is a required property for AddUser and cannot be null");
            }
            this.Password = password;
            // to ensure "email" is required (not null)
            if (email == null)
            {
                throw new ArgumentNullException("email is a required property for AddUser and cannot be null");
            }
            this.Email = email;
            // to ensure "role" is required (not null)
            if (role == null)
            {
                throw new ArgumentNullException("role is a required property for AddUser and cannot be null");
            }
            this.Role = role;
            this.VideoQuota = videoQuota;
            this.VideoQuotaDaily = videoQuotaDaily;
            this.ChannelName = channelName;
            this.AdminFlags = adminFlags;
        }

        /// <summary>
        /// immutable name of the user, used to find or mention its actor
        /// </summary>
        /// <value>immutable name of the user, used to find or mention its actor</value>
        /// <example>chocobozzz</example>
        [DataMember(Name = "username", IsRequired = true, EmitDefaultValue = true)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [DataMember(Name = "password", IsRequired = true, EmitDefaultValue = true)]
        public string Password { get; set; }

        /// <summary>
        /// The user email
        /// </summary>
        /// <value>The user email</value>
        [DataMember(Name = "email", IsRequired = true, EmitDefaultValue = true)]
        public string Email { get; set; }

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
        /// immutable name of the channel, used to interact with its actor
        /// </summary>
        /// <value>immutable name of the channel, used to interact with its actor</value>
        /// <example>framasoft_videos</example>
        [DataMember(Name = "channelName", EmitDefaultValue = false)]
        public string ChannelName { get; set; }

        /// <summary>
        /// Gets or Sets Role
        /// </summary>
        [DataMember(Name = "role", IsRequired = true, EmitDefaultValue = true)]
        public UserRole Role { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AddUser {\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  VideoQuota: ").Append(VideoQuota).Append("\n");
            sb.Append("  VideoQuotaDaily: ").Append(VideoQuotaDaily).Append("\n");
            sb.Append("  ChannelName: ").Append(ChannelName).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("  AdminFlags: ").Append(AdminFlags).Append("\n");
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

            // ChannelName (string) maxLength
            if (this.ChannelName != null && this.ChannelName.Length > 50)
            {
                yield return new ValidationResult("Invalid value for ChannelName, length must be less than 50.", new [] { "ChannelName" });
            }

            // ChannelName (string) minLength
            if (this.ChannelName != null && this.ChannelName.Length < 1)
            {
                yield return new ValidationResult("Invalid value for ChannelName, length must be greater than 1.", new [] { "ChannelName" });
            }

            if (this.ChannelName != null) {
                // ChannelName (string) pattern
                Regex regexChannelName = new Regex(@"^[a-zA-Z0-9\\-_.:]+$", RegexOptions.CultureInvariant);
                if (!regexChannelName.Match(this.ChannelName).Success)
                {
                    yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ChannelName, must match a pattern of " + regexChannelName, new [] { "ChannelName" });
                }
            }

            yield break;
        }
    }

}
