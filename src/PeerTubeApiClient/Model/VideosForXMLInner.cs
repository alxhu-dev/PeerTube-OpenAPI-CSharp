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
    /// VideosForXMLInner
    /// </summary>
    [DataContract(Name = "VideosForXML_inner")]
    public partial class VideosForXMLInner : IValidatableObject
    {
        /// <summary>
        /// see [media:rating](https://www.rssboard.org/media-rss#media-rating) (MRSS)
        /// </summary>
        /// <value>see [media:rating](https://www.rssboard.org/media-rss#media-rating) (MRSS)</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MediaratingEnum
        {
            /// <summary>
            /// Enum Nonadult for value: nonadult
            /// </summary>
            [EnumMember(Value = "nonadult")]
            Nonadult = 1,

            /// <summary>
            /// Enum Adult for value: adult
            /// </summary>
            [EnumMember(Value = "adult")]
            Adult = 2
        }


        /// <summary>
        /// see [media:rating](https://www.rssboard.org/media-rss#media-rating) (MRSS)
        /// </summary>
        /// <value>see [media:rating](https://www.rssboard.org/media-rss#media-rating) (MRSS)</value>
        [DataMember(Name = "media:rating", EmitDefaultValue = false)]
        public MediaratingEnum? Mediarating { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="VideosForXMLInner" /> class.
        /// </summary>
        /// <param name="link">video watch page URL.</param>
        /// <param name="guid">video canonical URL.</param>
        /// <param name="pubDate">video publication date.</param>
        /// <param name="description">video description.</param>
        /// <param name="contentencoded">video description.</param>
        /// <param name="dccreator">publisher user name.</param>
        /// <param name="mediacategory">video category (MRSS).</param>
        /// <param name="mediacommunity">mediacommunity.</param>
        /// <param name="mediaembed">mediaembed.</param>
        /// <param name="mediaplayer">mediaplayer.</param>
        /// <param name="mediathumbnail">mediathumbnail.</param>
        /// <param name="mediatitle">see [media:title](https://www.rssboard.org/media-rss#media-title) (MRSS). We only use &#x60;plain&#x60; titles..</param>
        /// <param name="mediadescription">mediadescription.</param>
        /// <param name="mediarating">see [media:rating](https://www.rssboard.org/media-rss#media-rating) (MRSS).</param>
        /// <param name="enclosure">enclosure.</param>
        /// <param name="mediagroup">list of streamable files for the video. see [media:peerLink](https://www.rssboard.org/media-rss#media-peerlink) and [media:content](https://www.rssboard.org/media-rss#media-content) or  (MRSS).</param>
        public VideosForXMLInner(string link = default(string), string guid = default(string), DateTime pubDate = default(DateTime), string description = default(string), string contentencoded = default(string), string dccreator = default(string), int mediacategory = default(int), VideosForXMLInnerMediaCommunity mediacommunity = default(VideosForXMLInnerMediaCommunity), VideosForXMLInnerMediaEmbed mediaembed = default(VideosForXMLInnerMediaEmbed), VideosForXMLInnerMediaPlayer mediaplayer = default(VideosForXMLInnerMediaPlayer), VideosForXMLInnerMediaThumbnail mediathumbnail = default(VideosForXMLInnerMediaThumbnail), string mediatitle = default(string), string mediadescription = default(string), MediaratingEnum? mediarating = default(MediaratingEnum?), VideosForXMLInnerEnclosure enclosure = default(VideosForXMLInnerEnclosure), List<VideosForXMLInnerMediaGroupInner> mediagroup = default(List<VideosForXMLInnerMediaGroupInner>))
        {
            this.Link = link;
            this.Guid = guid;
            this.PubDate = pubDate;
            this.Description = description;
            this.Contentencoded = contentencoded;
            this.Dccreator = dccreator;
            this.Mediacategory = mediacategory;
            this.Mediacommunity = mediacommunity;
            this.Mediaembed = mediaembed;
            this.Mediaplayer = mediaplayer;
            this.Mediathumbnail = mediathumbnail;
            this.Mediatitle = mediatitle;
            this.Mediadescription = mediadescription;
            this.Mediarating = mediarating;
            this.Enclosure = enclosure;
            this.Mediagroup = mediagroup;
        }

        /// <summary>
        /// video watch page URL
        /// </summary>
        /// <value>video watch page URL</value>
        [DataMember(Name = "link", EmitDefaultValue = false)]
        public string Link { get; set; }

        /// <summary>
        /// video canonical URL
        /// </summary>
        /// <value>video canonical URL</value>
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string Guid { get; set; }

        /// <summary>
        /// video publication date
        /// </summary>
        /// <value>video publication date</value>
        [DataMember(Name = "pubDate", EmitDefaultValue = false)]
        public DateTime PubDate { get; set; }

        /// <summary>
        /// video description
        /// </summary>
        /// <value>video description</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// video description
        /// </summary>
        /// <value>video description</value>
        [DataMember(Name = "content:encoded", EmitDefaultValue = false)]
        public string Contentencoded { get; set; }

        /// <summary>
        /// publisher user name
        /// </summary>
        /// <value>publisher user name</value>
        [DataMember(Name = "dc:creator", EmitDefaultValue = false)]
        public string Dccreator { get; set; }

        /// <summary>
        /// video category (MRSS)
        /// </summary>
        /// <value>video category (MRSS)</value>
        [DataMember(Name = "media:category", EmitDefaultValue = false)]
        public int Mediacategory { get; set; }

        /// <summary>
        /// Gets or Sets Mediacommunity
        /// </summary>
        [DataMember(Name = "media:community", EmitDefaultValue = false)]
        public VideosForXMLInnerMediaCommunity Mediacommunity { get; set; }

        /// <summary>
        /// Gets or Sets Mediaembed
        /// </summary>
        [DataMember(Name = "media:embed", EmitDefaultValue = false)]
        public VideosForXMLInnerMediaEmbed Mediaembed { get; set; }

        /// <summary>
        /// Gets or Sets Mediaplayer
        /// </summary>
        [DataMember(Name = "media:player", EmitDefaultValue = false)]
        public VideosForXMLInnerMediaPlayer Mediaplayer { get; set; }

        /// <summary>
        /// Gets or Sets Mediathumbnail
        /// </summary>
        [DataMember(Name = "media:thumbnail", EmitDefaultValue = false)]
        public VideosForXMLInnerMediaThumbnail Mediathumbnail { get; set; }

        /// <summary>
        /// see [media:title](https://www.rssboard.org/media-rss#media-title) (MRSS). We only use &#x60;plain&#x60; titles.
        /// </summary>
        /// <value>see [media:title](https://www.rssboard.org/media-rss#media-title) (MRSS). We only use &#x60;plain&#x60; titles.</value>
        [DataMember(Name = "media:title", EmitDefaultValue = false)]
        public string Mediatitle { get; set; }

        /// <summary>
        /// Gets or Sets Mediadescription
        /// </summary>
        [DataMember(Name = "media:description", EmitDefaultValue = false)]
        public string Mediadescription { get; set; }

        /// <summary>
        /// Gets or Sets Enclosure
        /// </summary>
        [DataMember(Name = "enclosure", EmitDefaultValue = false)]
        public VideosForXMLInnerEnclosure Enclosure { get; set; }

        /// <summary>
        /// list of streamable files for the video. see [media:peerLink](https://www.rssboard.org/media-rss#media-peerlink) and [media:content](https://www.rssboard.org/media-rss#media-content) or  (MRSS)
        /// </summary>
        /// <value>list of streamable files for the video. see [media:peerLink](https://www.rssboard.org/media-rss#media-peerlink) and [media:content](https://www.rssboard.org/media-rss#media-content) or  (MRSS)</value>
        [DataMember(Name = "media:group", EmitDefaultValue = false)]
        public List<VideosForXMLInnerMediaGroupInner> Mediagroup { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class VideosForXMLInner {\n");
            sb.Append("  Link: ").Append(Link).Append("\n");
            sb.Append("  Guid: ").Append(Guid).Append("\n");
            sb.Append("  PubDate: ").Append(PubDate).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Contentencoded: ").Append(Contentencoded).Append("\n");
            sb.Append("  Dccreator: ").Append(Dccreator).Append("\n");
            sb.Append("  Mediacategory: ").Append(Mediacategory).Append("\n");
            sb.Append("  Mediacommunity: ").Append(Mediacommunity).Append("\n");
            sb.Append("  Mediaembed: ").Append(Mediaembed).Append("\n");
            sb.Append("  Mediaplayer: ").Append(Mediaplayer).Append("\n");
            sb.Append("  Mediathumbnail: ").Append(Mediathumbnail).Append("\n");
            sb.Append("  Mediatitle: ").Append(Mediatitle).Append("\n");
            sb.Append("  Mediadescription: ").Append(Mediadescription).Append("\n");
            sb.Append("  Mediarating: ").Append(Mediarating).Append("\n");
            sb.Append("  Enclosure: ").Append(Enclosure).Append("\n");
            sb.Append("  Mediagroup: ").Append(Mediagroup).Append("\n");
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
