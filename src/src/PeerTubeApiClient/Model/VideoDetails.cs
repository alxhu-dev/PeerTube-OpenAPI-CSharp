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
    /// VideoDetails
    /// </summary>
    [DataContract(Name = "VideoDetails")]
    public partial class VideoDetails : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoDetails" /> class.
        /// </summary>
        /// <param name="id">object id for the video.</param>
        /// <param name="uuid">universal identifier for the video, that can be used across instances.</param>
        /// <param name="shortUUID">translation of a uuid v4 with a bigger alphabet to have a shorter uuid.</param>
        /// <param name="isLive">isLive.</param>
        /// <param name="createdAt">time at which the video object was first drafted.</param>
        /// <param name="publishedAt">time at which the video was marked as ready for playback (with restrictions depending on &#x60;privacy&#x60;). Usually set after a &#x60;state&#x60; evolution..</param>
        /// <param name="updatedAt">last time the video&#39;s metadata was modified.</param>
        /// <param name="originallyPublishedAt">used to represent a date of first publication, prior to the practical publication date of &#x60;publishedAt&#x60;.</param>
        /// <param name="category">category in which the video is classified.</param>
        /// <param name="licence">licence under which the video is distributed.</param>
        /// <param name="language">main language used in the video.</param>
        /// <param name="privacy">privacy policy used to distribute the video.</param>
        /// <param name="truncatedDescription">truncated description of the video, written in Markdown. .</param>
        /// <param name="duration">duration of the video in seconds.</param>
        /// <param name="aspectRatio">**PeerTube &gt;&#x3D; 6.1** Aspect ratio of the video stream.</param>
        /// <param name="isLocal">isLocal.</param>
        /// <param name="name">title of the video.</param>
        /// <param name="thumbnailPath">thumbnailPath.</param>
        /// <param name="previewPath">previewPath.</param>
        /// <param name="embedPath">embedPath.</param>
        /// <param name="views">views.</param>
        /// <param name="likes">likes.</param>
        /// <param name="dislikes">dislikes.</param>
        /// <param name="nsfw">nsfw.</param>
        /// <param name="waitTranscoding">waitTranscoding.</param>
        /// <param name="state">represents the internal state of the video processing within the PeerTube instance.</param>
        /// <param name="scheduledUpdate">scheduledUpdate.</param>
        /// <param name="blacklisted">blacklisted.</param>
        /// <param name="blacklistedReason">blacklistedReason.</param>
        /// <param name="account">account.</param>
        /// <param name="channel">channel.</param>
        /// <param name="userHistory">userHistory.</param>
        /// <param name="viewers">If the video is a live, you have the amount of current viewers.</param>
        /// <param name="description">full description of the video, written in Markdown. .</param>
        /// <param name="support">A text tell the audience how to support the video creator.</param>
        /// <param name="tags">tags.</param>
        /// <param name="commentsEnabled">Deprecated in 6.2, use commentsPolicy instead.</param>
        /// <param name="commentsPolicy">commentsPolicy.</param>
        /// <param name="downloadEnabled">downloadEnabled.</param>
        /// <param name="inputFileUpdatedAt">Latest input file update. Null if the file has never been replaced since the original upload.</param>
        /// <param name="trackerUrls">trackerUrls.</param>
        /// <param name="files">Web compatible video files. If Web Video is disabled on the server:  - field will be empty - video files will be found in &#x60;streamingPlaylists[].files&#x60; field .</param>
        /// <param name="streamingPlaylists">HLS playlists/manifest files. If HLS is disabled on the server:  - field will be empty - video files will be found in &#x60;files&#x60; field .</param>
        public VideoDetails(int id = default(int), Guid uuid = default(Guid), string shortUUID = default(string), bool isLive = default(bool), DateTime createdAt = default(DateTime), DateTime publishedAt = default(DateTime), DateTime updatedAt = default(DateTime), DateTime? originallyPublishedAt = default(DateTime?), VideoConstantNumberCategory category = default(VideoConstantNumberCategory), VideoConstantNumberLicence licence = default(VideoConstantNumberLicence), VideoConstantStringLanguage language = default(VideoConstantStringLanguage), VideoPrivacyConstant privacy = default(VideoPrivacyConstant), string truncatedDescription = default(string), int duration = default(int), float? aspectRatio = default(float?), bool isLocal = default(bool), string name = default(string), string thumbnailPath = default(string), string previewPath = default(string), string embedPath = default(string), int views = default(int), int likes = default(int), int dislikes = default(int), bool nsfw = default(bool), bool? waitTranscoding = default(bool?), VideoStateConstant state = default(VideoStateConstant), VideoScheduledUpdate scheduledUpdate = default(VideoScheduledUpdate), bool? blacklisted = default(bool?), string blacklistedReason = default(string), Account account = default(Account), VideoChannel channel = default(VideoChannel), VideoUserHistory userHistory = default(VideoUserHistory), int viewers = default(int), string description = default(string), string support = default(string), List<string> tags = default(List<string>), bool commentsEnabled = default(bool), VideoCommentsPolicyConstant commentsPolicy = default(VideoCommentsPolicyConstant), bool downloadEnabled = default(bool), DateTime? inputFileUpdatedAt = default(DateTime?), List<string> trackerUrls = default(List<string>), List<VideoFile> files = default(List<VideoFile>), List<VideoStreamingPlaylists> streamingPlaylists = default(List<VideoStreamingPlaylists>))
        {
            this.Id = id;
            this.Uuid = uuid;
            this.ShortUUID = shortUUID;
            this.IsLive = isLive;
            this.CreatedAt = createdAt;
            this.PublishedAt = publishedAt;
            this.UpdatedAt = updatedAt;
            this.OriginallyPublishedAt = originallyPublishedAt;
            this.Category = category;
            this.Licence = licence;
            this.Language = language;
            this.Privacy = privacy;
            this.TruncatedDescription = truncatedDescription;
            this.Duration = duration;
            this.AspectRatio = aspectRatio;
            this.IsLocal = isLocal;
            this.Name = name;
            this.ThumbnailPath = thumbnailPath;
            this.PreviewPath = previewPath;
            this.EmbedPath = embedPath;
            this.Views = views;
            this.Likes = likes;
            this.Dislikes = dislikes;
            this.Nsfw = nsfw;
            this.WaitTranscoding = waitTranscoding;
            this.State = state;
            this.ScheduledUpdate = scheduledUpdate;
            this.Blacklisted = blacklisted;
            this.BlacklistedReason = blacklistedReason;
            this.Account = account;
            this.Channel = channel;
            this.UserHistory = userHistory;
            this.Viewers = viewers;
            this.Description = description;
            this.Support = support;
            this.Tags = tags;
            this.CommentsEnabled = commentsEnabled;
            this.CommentsPolicy = commentsPolicy;
            this.DownloadEnabled = downloadEnabled;
            this.InputFileUpdatedAt = inputFileUpdatedAt;
            this.TrackerUrls = trackerUrls;
            this.Files = files;
            this.StreamingPlaylists = streamingPlaylists;
        }

        /// <summary>
        /// object id for the video
        /// </summary>
        /// <value>object id for the video</value>
        /// <example>42</example>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// universal identifier for the video, that can be used across instances
        /// </summary>
        /// <value>universal identifier for the video, that can be used across instances</value>
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
        /// Gets or Sets IsLive
        /// </summary>
        [DataMember(Name = "isLive", EmitDefaultValue = true)]
        public bool IsLive { get; set; }

        /// <summary>
        /// time at which the video object was first drafted
        /// </summary>
        /// <value>time at which the video object was first drafted</value>
        /// <example>2017-10-01T10:52:46.396Z</example>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// time at which the video was marked as ready for playback (with restrictions depending on &#x60;privacy&#x60;). Usually set after a &#x60;state&#x60; evolution.
        /// </summary>
        /// <value>time at which the video was marked as ready for playback (with restrictions depending on &#x60;privacy&#x60;). Usually set after a &#x60;state&#x60; evolution.</value>
        /// <example>2018-10-01T10:52:46.396Z</example>
        [DataMember(Name = "publishedAt", EmitDefaultValue = false)]
        public DateTime PublishedAt { get; set; }

        /// <summary>
        /// last time the video&#39;s metadata was modified
        /// </summary>
        /// <value>last time the video&#39;s metadata was modified</value>
        /// <example>2021-05-04T08:01:01.502Z</example>
        [DataMember(Name = "updatedAt", EmitDefaultValue = false)]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// used to represent a date of first publication, prior to the practical publication date of &#x60;publishedAt&#x60;
        /// </summary>
        /// <value>used to represent a date of first publication, prior to the practical publication date of &#x60;publishedAt&#x60;</value>
        /// <example>2010-10-01T10:52:46.396Z</example>
        [DataMember(Name = "originallyPublishedAt", EmitDefaultValue = true)]
        public DateTime? OriginallyPublishedAt { get; set; }

        /// <summary>
        /// category in which the video is classified
        /// </summary>
        /// <value>category in which the video is classified</value>
        [DataMember(Name = "category", EmitDefaultValue = false)]
        public VideoConstantNumberCategory Category { get; set; }

        /// <summary>
        /// licence under which the video is distributed
        /// </summary>
        /// <value>licence under which the video is distributed</value>
        [DataMember(Name = "licence", EmitDefaultValue = false)]
        public VideoConstantNumberLicence Licence { get; set; }

        /// <summary>
        /// main language used in the video
        /// </summary>
        /// <value>main language used in the video</value>
        [DataMember(Name = "language", EmitDefaultValue = false)]
        public VideoConstantStringLanguage Language { get; set; }

        /// <summary>
        /// privacy policy used to distribute the video
        /// </summary>
        /// <value>privacy policy used to distribute the video</value>
        [DataMember(Name = "privacy", EmitDefaultValue = false)]
        public VideoPrivacyConstant Privacy { get; set; }

        /// <summary>
        /// truncated description of the video, written in Markdown. 
        /// </summary>
        /// <value>truncated description of the video, written in Markdown. </value>
        /// <example>**[Want to help to translate this video?](https://weblate.framasoft.org/projects/what-is-peertube-video/)**\r\n\r\n
**Take back the control of your videos! [#JoinPeertube](https://joinpeertube.org)**\r\n*A decentralized video hosting network, based on fr...
</example>
        [DataMember(Name = "truncatedDescription", EmitDefaultValue = true)]
        public string TruncatedDescription { get; set; }

        /// <summary>
        /// duration of the video in seconds
        /// </summary>
        /// <value>duration of the video in seconds</value>
        /// <example>1419</example>
        [DataMember(Name = "duration", EmitDefaultValue = false)]
        public int Duration { get; set; }

        /// <summary>
        /// **PeerTube &gt;&#x3D; 6.1** Aspect ratio of the video stream
        /// </summary>
        /// <value>**PeerTube &gt;&#x3D; 6.1** Aspect ratio of the video stream</value>
        /// <example>1.778</example>
        [DataMember(Name = "aspectRatio", EmitDefaultValue = true)]
        public float? AspectRatio { get; set; }

        /// <summary>
        /// Gets or Sets IsLocal
        /// </summary>
        [DataMember(Name = "isLocal", EmitDefaultValue = true)]
        public bool IsLocal { get; set; }

        /// <summary>
        /// title of the video
        /// </summary>
        /// <value>title of the video</value>
        /// <example>What is PeerTube?</example>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets ThumbnailPath
        /// </summary>
        /// <example>/lazy-static/thumbnails/a65bc12f-9383-462e-81ae-8207e8b434ee.jpg</example>
        [DataMember(Name = "thumbnailPath", EmitDefaultValue = false)]
        public string ThumbnailPath { get; set; }

        /// <summary>
        /// Gets or Sets PreviewPath
        /// </summary>
        /// <example>/lazy-static/previews/a65bc12f-9383-462e-81ae-8207e8b434ee.jpg</example>
        [DataMember(Name = "previewPath", EmitDefaultValue = false)]
        public string PreviewPath { get; set; }

        /// <summary>
        /// Gets or Sets EmbedPath
        /// </summary>
        /// <example>/videos/embed/a65bc12f-9383-462e-81ae-8207e8b434ee</example>
        [DataMember(Name = "embedPath", EmitDefaultValue = false)]
        public string EmbedPath { get; set; }

        /// <summary>
        /// Gets or Sets Views
        /// </summary>
        /// <example>1337</example>
        [DataMember(Name = "views", EmitDefaultValue = false)]
        public int Views { get; set; }

        /// <summary>
        /// Gets or Sets Likes
        /// </summary>
        /// <example>42</example>
        [DataMember(Name = "likes", EmitDefaultValue = false)]
        public int Likes { get; set; }

        /// <summary>
        /// Gets or Sets Dislikes
        /// </summary>
        /// <example>7</example>
        [DataMember(Name = "dislikes", EmitDefaultValue = false)]
        public int Dislikes { get; set; }

        /// <summary>
        /// Gets or Sets Nsfw
        /// </summary>
        [DataMember(Name = "nsfw", EmitDefaultValue = true)]
        public bool Nsfw { get; set; }

        /// <summary>
        /// Gets or Sets WaitTranscoding
        /// </summary>
        [DataMember(Name = "waitTranscoding", EmitDefaultValue = true)]
        public bool? WaitTranscoding { get; set; }

        /// <summary>
        /// represents the internal state of the video processing within the PeerTube instance
        /// </summary>
        /// <value>represents the internal state of the video processing within the PeerTube instance</value>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        public VideoStateConstant State { get; set; }

        /// <summary>
        /// Gets or Sets ScheduledUpdate
        /// </summary>
        [DataMember(Name = "scheduledUpdate", EmitDefaultValue = true)]
        public VideoScheduledUpdate ScheduledUpdate { get; set; }

        /// <summary>
        /// Gets or Sets Blacklisted
        /// </summary>
        [DataMember(Name = "blacklisted", EmitDefaultValue = true)]
        public bool? Blacklisted { get; set; }

        /// <summary>
        /// Gets or Sets BlacklistedReason
        /// </summary>
        [DataMember(Name = "blacklistedReason", EmitDefaultValue = true)]
        public string BlacklistedReason { get; set; }

        /// <summary>
        /// Gets or Sets Account
        /// </summary>
        [DataMember(Name = "account", EmitDefaultValue = false)]
        public Account Account { get; set; }

        /// <summary>
        /// Gets or Sets Channel
        /// </summary>
        [DataMember(Name = "channel", EmitDefaultValue = false)]
        public VideoChannel Channel { get; set; }

        /// <summary>
        /// Gets or Sets UserHistory
        /// </summary>
        [DataMember(Name = "userHistory", EmitDefaultValue = true)]
        public VideoUserHistory UserHistory { get; set; }

        /// <summary>
        /// If the video is a live, you have the amount of current viewers
        /// </summary>
        /// <value>If the video is a live, you have the amount of current viewers</value>
        [DataMember(Name = "viewers", EmitDefaultValue = false)]
        public int Viewers { get; set; }

        /// <summary>
        /// full description of the video, written in Markdown. 
        /// </summary>
        /// <value>full description of the video, written in Markdown. </value>
        /// <example>	&quot;**[Want to help to translate this video?](https://weblate.framasoft.org/projects/what-is-peertube-video/)**\r\n\r\n
 **Take back the control of your videos! [#JoinPeertube](https://joinpeertube.org)**\r\n*A decentralized video hosting network,
 based on free/libre software!*\r\n\r\n**Animation Produced by:** [LILA](https://libreart.info) - [ZeMarmot Team](https://film.zemarmot.net)\r\n
 *Directed by* Aryeom\r\n*Assistant* Jehan\r\n**Licence**: [CC-By-SA 4.0](https://creativecommons.org/licenses/by-sa/4.0/)\r\n\r\n
 **Sponsored by** [Framasoft](https://framasoft.org)\r\n\r\n**Music**: [Red Step Forward](http://play.dogmazic.net/song.php?song_id&#x3D;52491) - CC-By Ken Bushima\r\n\r\n
 **Movie Clip**: [Caminades 3: Llamigos](http://www.caminandes.com/) CC-By Blender Institute\r\n\r\n**Video sources**: https://gitlab.gnome.org/Jehan/what-is-peertube/&quot;
</example>
        [DataMember(Name = "description", EmitDefaultValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// A text tell the audience how to support the video creator
        /// </summary>
        /// <value>A text tell the audience how to support the video creator</value>
        /// <example>Please support our work on https://soutenir.framasoft.org/en/ &lt;3</example>
        [DataMember(Name = "support", EmitDefaultValue = true)]
        public string Support { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        /// <example>[&quot;flowers&quot;,&quot;gardening&quot;]</example>
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
        /// Gets or Sets CommentsPolicy
        /// </summary>
        [DataMember(Name = "commentsPolicy", EmitDefaultValue = false)]
        public VideoCommentsPolicyConstant CommentsPolicy { get; set; }

        /// <summary>
        /// Gets or Sets DownloadEnabled
        /// </summary>
        [DataMember(Name = "downloadEnabled", EmitDefaultValue = true)]
        public bool DownloadEnabled { get; set; }

        /// <summary>
        /// Latest input file update. Null if the file has never been replaced since the original upload
        /// </summary>
        /// <value>Latest input file update. Null if the file has never been replaced since the original upload</value>
        [DataMember(Name = "inputFileUpdatedAt", EmitDefaultValue = true)]
        public DateTime? InputFileUpdatedAt { get; set; }

        /// <summary>
        /// Gets or Sets TrackerUrls
        /// </summary>
        /// <example>[&quot;https://peertube2.cpy.re/tracker/announce&quot;,&quot;wss://peertube2.cpy.re/tracker/socket&quot;]</example>
        [DataMember(Name = "trackerUrls", EmitDefaultValue = false)]
        public List<string> TrackerUrls { get; set; }

        /// <summary>
        /// Web compatible video files. If Web Video is disabled on the server:  - field will be empty - video files will be found in &#x60;streamingPlaylists[].files&#x60; field 
        /// </summary>
        /// <value>Web compatible video files. If Web Video is disabled on the server:  - field will be empty - video files will be found in &#x60;streamingPlaylists[].files&#x60; field </value>
        [DataMember(Name = "files", EmitDefaultValue = false)]
        public List<VideoFile> Files { get; set; }

        /// <summary>
        /// HLS playlists/manifest files. If HLS is disabled on the server:  - field will be empty - video files will be found in &#x60;files&#x60; field 
        /// </summary>
        /// <value>HLS playlists/manifest files. If HLS is disabled on the server:  - field will be empty - video files will be found in &#x60;files&#x60; field </value>
        [DataMember(Name = "streamingPlaylists", EmitDefaultValue = false)]
        public List<VideoStreamingPlaylists> StreamingPlaylists { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class VideoDetails {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Uuid: ").Append(Uuid).Append("\n");
            sb.Append("  ShortUUID: ").Append(ShortUUID).Append("\n");
            sb.Append("  IsLive: ").Append(IsLive).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  PublishedAt: ").Append(PublishedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  OriginallyPublishedAt: ").Append(OriginallyPublishedAt).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Licence: ").Append(Licence).Append("\n");
            sb.Append("  Language: ").Append(Language).Append("\n");
            sb.Append("  Privacy: ").Append(Privacy).Append("\n");
            sb.Append("  TruncatedDescription: ").Append(TruncatedDescription).Append("\n");
            sb.Append("  Duration: ").Append(Duration).Append("\n");
            sb.Append("  AspectRatio: ").Append(AspectRatio).Append("\n");
            sb.Append("  IsLocal: ").Append(IsLocal).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ThumbnailPath: ").Append(ThumbnailPath).Append("\n");
            sb.Append("  PreviewPath: ").Append(PreviewPath).Append("\n");
            sb.Append("  EmbedPath: ").Append(EmbedPath).Append("\n");
            sb.Append("  Views: ").Append(Views).Append("\n");
            sb.Append("  Likes: ").Append(Likes).Append("\n");
            sb.Append("  Dislikes: ").Append(Dislikes).Append("\n");
            sb.Append("  Nsfw: ").Append(Nsfw).Append("\n");
            sb.Append("  WaitTranscoding: ").Append(WaitTranscoding).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  ScheduledUpdate: ").Append(ScheduledUpdate).Append("\n");
            sb.Append("  Blacklisted: ").Append(Blacklisted).Append("\n");
            sb.Append("  BlacklistedReason: ").Append(BlacklistedReason).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  Channel: ").Append(Channel).Append("\n");
            sb.Append("  UserHistory: ").Append(UserHistory).Append("\n");
            sb.Append("  Viewers: ").Append(Viewers).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Support: ").Append(Support).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  CommentsEnabled: ").Append(CommentsEnabled).Append("\n");
            sb.Append("  CommentsPolicy: ").Append(CommentsPolicy).Append("\n");
            sb.Append("  DownloadEnabled: ").Append(DownloadEnabled).Append("\n");
            sb.Append("  InputFileUpdatedAt: ").Append(InputFileUpdatedAt).Append("\n");
            sb.Append("  TrackerUrls: ").Append(TrackerUrls).Append("\n");
            sb.Append("  Files: ").Append(Files).Append("\n");
            sb.Append("  StreamingPlaylists: ").Append(StreamingPlaylists).Append("\n");
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

            // TruncatedDescription (string) maxLength
            if (this.TruncatedDescription != null && this.TruncatedDescription.Length > 250)
            {
                yield return new ValidationResult("Invalid value for TruncatedDescription, length must be less than 250.", new [] { "TruncatedDescription" });
            }

            // TruncatedDescription (string) minLength
            if (this.TruncatedDescription != null && this.TruncatedDescription.Length < 3)
            {
                yield return new ValidationResult("Invalid value for TruncatedDescription, length must be greater than 3.", new [] { "TruncatedDescription" });
            }

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

            // Support (string) maxLength
            if (this.Support != null && this.Support.Length > 1000)
            {
                yield return new ValidationResult("Invalid value for Support, length must be less than 1000.", new [] { "Support" });
            }

            // Support (string) minLength
            if (this.Support != null && this.Support.Length < 3)
            {
                yield return new ValidationResult("Invalid value for Support, length must be greater than 3.", new [] { "Support" });
            }

            yield break;
        }
    }

}
