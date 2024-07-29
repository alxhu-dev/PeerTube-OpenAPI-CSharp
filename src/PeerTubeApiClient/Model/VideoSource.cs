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
    /// VideoSource
    /// </summary>
    [DataContract(Name = "VideoSource")]
    public partial class VideoSource : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoSource" /> class.
        /// </summary>
        /// <param name="filename">Deprecated in 6.1, use inputFilename instead.</param>
        /// <param name="inputFilename">Uploaded/imported filename.</param>
        /// <param name="fileDownloadUrl">**PeerTube &gt;&#x3D; 6.1** If enabled by the admin, the video source file is kept on the server and can be downloaded by the owner.</param>
        /// <param name="resolution">resolution.</param>
        /// <param name="size">**PeerTube &gt;&#x3D; 6.1** Video file size in bytes.</param>
        /// <param name="fps">**PeerTube &gt;&#x3D; 6.1** Frames per second of the video file.</param>
        /// <param name="width">**PeerTube &gt;&#x3D; 6.1** Video stream width.</param>
        /// <param name="height">**PeerTube &gt;&#x3D; 6.1** Video stream height.</param>
        /// <param name="createdAt">createdAt.</param>
        public VideoSource(string filename = default(string), string inputFilename = default(string), string fileDownloadUrl = default(string), VideoResolutionConstant resolution = default(VideoResolutionConstant), int size = default(int), decimal fps = default(decimal), decimal width = default(decimal), decimal height = default(decimal), DateTime createdAt = default(DateTime))
        {
            this.Filename = filename;
            this.InputFilename = inputFilename;
            this.FileDownloadUrl = fileDownloadUrl;
            this.Resolution = resolution;
            this.Size = size;
            this.Fps = fps;
            this.Width = width;
            this.Height = height;
            this.CreatedAt = createdAt;
        }

        /// <summary>
        /// Deprecated in 6.1, use inputFilename instead
        /// </summary>
        /// <value>Deprecated in 6.1, use inputFilename instead</value>
        [DataMember(Name = "filename", EmitDefaultValue = false)]
        [Obsolete]
        public string Filename { get; set; }

        /// <summary>
        /// Uploaded/imported filename
        /// </summary>
        /// <value>Uploaded/imported filename</value>
        [DataMember(Name = "inputFilename", EmitDefaultValue = false)]
        public string InputFilename { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.1** If enabled by the admin, the video source file is kept on the server and can be downloaded by the owner
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.1** If enabled by the admin, the video source file is kept on the server and can be downloaded by the owner</value>
        [DataMember(Name = "fileDownloadUrl", EmitDefaultValue = false)]
        public string FileDownloadUrl { get; set; }

        /// <summary>
        /// Gets or Sets Resolution
        /// </summary>
        [DataMember(Name = "resolution", EmitDefaultValue = false)]
        public VideoResolutionConstant Resolution { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.1** Video file size in bytes
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.1** Video file size in bytes</value>
        [DataMember(Name = "size", EmitDefaultValue = false)]
        public int Size { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.1** Frames per second of the video file
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.1** Frames per second of the video file</value>
        [DataMember(Name = "fps", EmitDefaultValue = false)]
        public decimal Fps { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.1** Video stream width
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.1** Video stream width</value>
        [DataMember(Name = "width", EmitDefaultValue = false)]
        public decimal Width { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.1** Video stream height
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.1** Video stream height</value>
        [DataMember(Name = "height", EmitDefaultValue = false)]
        public decimal Height { get; set; }

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
            sb.Append("class VideoSource {\n");
            sb.Append("  Filename: ").Append(Filename).Append("\n");
            sb.Append("  InputFilename: ").Append(InputFilename).Append("\n");
            sb.Append("  FileDownloadUrl: ").Append(FileDownloadUrl).Append("\n");
            sb.Append("  Resolution: ").Append(Resolution).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
            sb.Append("  Fps: ").Append(Fps).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
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
            yield break;
        }
    }

}
