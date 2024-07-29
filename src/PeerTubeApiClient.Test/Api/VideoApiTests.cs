/*
 * PeerTube
 *
 * The PeerTube API is built on HTTP(S) and is RESTful. You can use your favorite HTTP/REST library for your programming language to use PeerTube. The spec API is fully compatible with [openapi-generator](https://github.com/OpenAPITools/openapi-generator/wiki/API-client-generator-HOWTO) which generates a client SDK in the language of your choice - we generate some client SDKs automatically:  - [Python](https://framagit.org/framasoft/peertube/clients/python) - [Go](https://framagit.org/framasoft/peertube/clients/go) - [Kotlin](https://framagit.org/framasoft/peertube/clients/kotlin)  See the [REST API quick start](https://docs.joinpeertube.org/api/rest-getting-started) for a few examples of using the PeerTube API.  # Authentication  When you sign up for an account on a PeerTube instance, you are given the possibility to generate sessions on it, and authenticate there using an access token. Only __one access token can currently be used at a time__.  ## Roles  Accounts are given permissions based on their role. There are three roles on PeerTube: Administrator, Moderator, and User. See the [roles guide](https://docs.joinpeertube.org/admin/managing-users#roles) for a detail of their permissions.  # Errors  The API uses standard HTTP status codes to indicate the success or failure of the API call, completed by a [RFC7807-compliant](https://tools.ietf.org/html/rfc7807) response body.  ``` HTTP 1.1 404 Not Found Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Video not found\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"status\": 404,   \"title\": \"Not Found\",   \"type\": \"about:blank\" } ```  We provide error `type` (following RFC7807) and `code` (internal PeerTube code) values for [a growing number of cases](https://github.com/Chocobozzz/PeerTube/blob/develop/packages/models/src/server/server-error-code.enum.ts), but it is still optional. Types are used to disambiguate errors that bear the same status code and are non-obvious:  ``` HTTP 1.1 403 Forbidden Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Cannot get this video regarding follow constraints\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"status\": 403,   \"title\": \"Forbidden\",   \"type\": \"https://docs.joinpeertube.org/api-rest-reference.html#section/Errors/does_not_respect_follow_constraints\" } ```  Here a 403 error could otherwise mean that the video is private or blocklisted.  ### Validation errors  Each parameter is evaluated on its own against a set of rules before the route validator proceeds with potential testing involving parameter combinations. Errors coming from validation errors appear earlier and benefit from a more detailed error description:  ``` HTTP 1.1 400 Bad Request Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Incorrect request parameters: id\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"instance\": \"/api/v1/videos/9c9de5e8-0a1e-484a-b099-e80766180\",   \"invalid-params\": {     \"id\": {       \"location\": \"params\",       \"msg\": \"Invalid value\",       \"param\": \"id\",       \"value\": \"9c9de5e8-0a1e-484a-b099-e80766180\"     }   },   \"status\": 400,   \"title\": \"Bad Request\",   \"type\": \"about:blank\" } ```  Where `id` is the name of the field concerned by the error, within the route definition. `invalid-params.<field>.location` can be either 'params', 'body', 'header', 'query' or 'cookies', and `invalid-params.<field>.value` reports the value that didn't pass validation whose `invalid-params.<field>.msg` is about.  ### Deprecated error fields  Some fields could be included with previous versions. They are still included but their use is deprecated: - `error`: superseded by `detail`  # Rate limits  We are rate-limiting all endpoints of PeerTube's API. Custom values can be set by administrators:  | Endpoint (prefix: `/api/v1`) | Calls         | Time frame   | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- --|- -- -- -- -- -- -- -| | `/_*`                         | 50            | 10 seconds   | | `POST /users/token`          | 15            | 5 minutes    | | `POST /users/register`       | 2<sup>*</sup> | 5 minutes    | | `POST /users/ask-send-verify-email` | 3      | 5 minutes    |  Depending on the endpoint, <sup>*</sup>failed requests are not taken into account. A service limit is announced by a `429 Too Many Requests` status code.  You can get details about the current state of your rate limit by reading the following headers:  | Header                  | Description                                                | |- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | `X-RateLimit-Limit`     | Number of max requests allowed in the current time period  | | `X-RateLimit-Remaining` | Number of remaining requests in the current time period    | | `X-RateLimit-Reset`     | Timestamp of end of current time period as UNIX timestamp  | | `Retry-After`           | Seconds to delay after the first `429` is received         |  # CORS  This API features [Cross-Origin Resource Sharing (CORS)](https://fetch.spec.whatwg.org/), allowing cross-domain communication from the browser for some routes:  | Endpoint                    | |- -- -- -- -- -- -- -- -- -- -- -- -- - --| | `/api/_*`                    | | `/download/_*`               | | `/lazy-static/_*`            | | `/.well-known/webfinger`    |  In addition, all routes serving ActivityPub are CORS-enabled for all origins. 
 *
 * The version of the OpenAPI document: 6.2.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using PeerTubeApiClient.Client;
using PeerTubeApiClient.Api;
// uncomment below to import models
//using PeerTubeApiClient.Model;

namespace PeerTubeApiClient.Test.Api
{
    /// <summary>
    ///  Class for testing VideoApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class VideoApiTests : IDisposable
    {
        private VideoApi instance;

        public VideoApiTests()
        {
            instance = new VideoApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of VideoApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' VideoApi
            //Assert.IsType<VideoApi>(instance);
        }

        /// <summary>
        /// Test AddLive
        /// </summary>
        [Fact]
        public void AddLiveTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int channelId = null;
            //string name = null;
            //bool? saveReplay = null;
            //LiveVideoReplaySettings? replaySettings = null;
            //bool? permanentLive = null;
            //LiveVideoLatencyMode? latencyMode = null;
            //System.IO.Stream? thumbnailfile = null;
            //System.IO.Stream? previewfile = null;
            //VideoPrivacySet? privacy = null;
            //int? category = null;
            //int? licence = null;
            //string? language = null;
            //string? description = null;
            //string? support = null;
            //bool? nsfw = null;
            //List<string>? tags = null;
            //bool? commentsEnabled = null;
            //VideoCommentsPolicySet? commentsPolicy = null;
            //bool? downloadEnabled = null;
            //var response = instance.AddLive(channelId, name, saveReplay, replaySettings, permanentLive, latencyMode, thumbnailfile, previewfile, privacy, category, licence, language, description, support, nsfw, tags, commentsEnabled, commentsPolicy, downloadEnabled);
            //Assert.IsType<VideoUploadResponse>(response);
        }

        /// <summary>
        /// Test AddView
        /// </summary>
        [Fact]
        public void AddViewTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ApiV1VideosOwnershipIdAcceptPostIdParameter id = null;
            //UserViewingVideo userViewingVideo = null;
            //instance.AddView(id, userViewingVideo);
        }

        /// <summary>
        /// Test ApiV1VideosIdStudioEditPost
        /// </summary>
        [Fact]
        public void ApiV1VideosIdStudioEditPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ApiV1VideosOwnershipIdAcceptPostIdParameter id = null;
            //instance.ApiV1VideosIdStudioEditPost(id);
        }

        /// <summary>
        /// Test ApiV1VideosIdWatchingPut
        /// </summary>
        [Fact]
        public void ApiV1VideosIdWatchingPutTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ApiV1VideosOwnershipIdAcceptPostIdParameter id = null;
            //UserViewingVideo userViewingVideo = null;
            //instance.ApiV1VideosIdWatchingPut(id, userViewingVideo);
        }

        /// <summary>
        /// Test DelVideo
        /// </summary>
        [Fact]
        public void DelVideoTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ApiV1VideosOwnershipIdAcceptPostIdParameter id = null;
            //instance.DelVideo(id);
        }

        /// <summary>
        /// Test DeleteVideoSourceFile
        /// </summary>
        [Fact]
        public void DeleteVideoSourceFileTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ApiV1VideosOwnershipIdAcceptPostIdParameter id = null;
            //instance.DeleteVideoSourceFile(id);
        }

        /// <summary>
        /// Test GetAccountVideos
        /// </summary>
        [Fact]
        public void GetAccountVideosTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string name = null;
            //GetAccountVideosCategoryOneOfParameter? categoryOneOf = null;
            //bool? isLive = null;
            //GetAccountVideosTagsOneOfParameter? tagsOneOf = null;
            //GetAccountVideosTagsAllOfParameter? tagsAllOf = null;
            //GetAccountVideosLicenceOneOfParameter? licenceOneOf = null;
            //GetAccountVideosLanguageOneOfParameter? languageOneOf = null;
            //GetAccountVideosTagsAllOfParameter? autoTagOneOf = null;
            //string? nsfw = null;
            //bool? isLocal = null;
            //int? include = null;
            //VideoPrivacySet? privacyOneOf = null;
            //bool? hasHLSFiles = null;
            //bool? hasWebVideoFiles = null;
            //string? skipCount = null;
            //int? start = null;
            //int? count = null;
            //string? sort = null;
            //bool? excludeAlreadyWatched = null;
            //var response = instance.GetAccountVideos(name, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
            //Assert.IsType<VideoListResponse>(response);
        }

        /// <summary>
        /// Test GetCategories
        /// </summary>
        [Fact]
        public void GetCategoriesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.GetCategories();
            //Assert.IsType<List<string>>(response);
        }

        /// <summary>
        /// Test GetLanguages
        /// </summary>
        [Fact]
        public void GetLanguagesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.GetLanguages();
            //Assert.IsType<List<string>>(response);
        }

        /// <summary>
        /// Test GetLicences
        /// </summary>
        [Fact]
        public void GetLicencesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.GetLicences();
            //Assert.IsType<List<string>>(response);
        }

        /// <summary>
        /// Test GetLiveId
        /// </summary>
        [Fact]
        public void GetLiveIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ApiV1VideosOwnershipIdAcceptPostIdParameter id = null;
            //var response = instance.GetLiveId(id);
            //Assert.IsType<LiveVideoResponse>(response);
        }

        /// <summary>
        /// Test GetVideo
        /// </summary>
        [Fact]
        public void GetVideoTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ApiV1VideosOwnershipIdAcceptPostIdParameter id = null;
            //string? xPeertubeVideoPassword = null;
            //var response = instance.GetVideo(id, xPeertubeVideoPassword);
            //Assert.IsType<VideoDetails>(response);
        }

        /// <summary>
        /// Test GetVideoChannelVideos
        /// </summary>
        [Fact]
        public void GetVideoChannelVideosTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string channelHandle = null;
            //GetAccountVideosCategoryOneOfParameter? categoryOneOf = null;
            //bool? isLive = null;
            //GetAccountVideosTagsOneOfParameter? tagsOneOf = null;
            //GetAccountVideosTagsAllOfParameter? tagsAllOf = null;
            //GetAccountVideosLicenceOneOfParameter? licenceOneOf = null;
            //GetAccountVideosLanguageOneOfParameter? languageOneOf = null;
            //GetAccountVideosTagsAllOfParameter? autoTagOneOf = null;
            //string? nsfw = null;
            //bool? isLocal = null;
            //int? include = null;
            //VideoPrivacySet? privacyOneOf = null;
            //bool? hasHLSFiles = null;
            //bool? hasWebVideoFiles = null;
            //string? skipCount = null;
            //int? start = null;
            //int? count = null;
            //string? sort = null;
            //bool? excludeAlreadyWatched = null;
            //var response = instance.GetVideoChannelVideos(channelHandle, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
            //Assert.IsType<VideoListResponse>(response);
        }

        /// <summary>
        /// Test GetVideoDesc
        /// </summary>
        [Fact]
        public void GetVideoDescTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ApiV1VideosOwnershipIdAcceptPostIdParameter id = null;
            //string? xPeertubeVideoPassword = null;
            //var response = instance.GetVideoDesc(id, xPeertubeVideoPassword);
            //Assert.IsType<string>(response);
        }

        /// <summary>
        /// Test GetVideoPrivacyPolicies
        /// </summary>
        [Fact]
        public void GetVideoPrivacyPoliciesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.GetVideoPrivacyPolicies();
            //Assert.IsType<List<string>>(response);
        }

        /// <summary>
        /// Test GetVideoSource
        /// </summary>
        [Fact]
        public void GetVideoSourceTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ApiV1VideosOwnershipIdAcceptPostIdParameter id = null;
            //var response = instance.GetVideoSource(id);
            //Assert.IsType<VideoSource>(response);
        }

        /// <summary>
        /// Test GetVideos
        /// </summary>
        [Fact]
        public void GetVideosTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //GetAccountVideosCategoryOneOfParameter? categoryOneOf = null;
            //bool? isLive = null;
            //GetAccountVideosTagsOneOfParameter? tagsOneOf = null;
            //GetAccountVideosTagsAllOfParameter? tagsAllOf = null;
            //GetAccountVideosLicenceOneOfParameter? licenceOneOf = null;
            //GetAccountVideosLanguageOneOfParameter? languageOneOf = null;
            //GetAccountVideosTagsAllOfParameter? autoTagOneOf = null;
            //string? nsfw = null;
            //bool? isLocal = null;
            //int? include = null;
            //VideoPrivacySet? privacyOneOf = null;
            //bool? hasHLSFiles = null;
            //bool? hasWebVideoFiles = null;
            //string? skipCount = null;
            //int? start = null;
            //int? count = null;
            //string? sort = null;
            //bool? excludeAlreadyWatched = null;
            //var response = instance.GetVideos(categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, sort, excludeAlreadyWatched);
            //Assert.IsType<VideoListResponse>(response);
        }

        /// <summary>
        /// Test ListVideoStoryboards
        /// </summary>
        [Fact]
        public void ListVideoStoryboardsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ApiV1VideosOwnershipIdAcceptPostIdParameter id = null;
            //var response = instance.ListVideoStoryboards(id);
            //Assert.IsType<ListVideoStoryboards200Response>(response);
        }

        /// <summary>
        /// Test PutVideo
        /// </summary>
        [Fact]
        public void PutVideoTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ApiV1VideosOwnershipIdAcceptPostIdParameter id = null;
            //System.IO.Stream? thumbnailfile = null;
            //System.IO.Stream? previewfile = null;
            //int? category = null;
            //int? licence = null;
            //string? language = null;
            //VideoPrivacySet? privacy = null;
            //string? description = null;
            //string? waitTranscoding = null;
            //string? support = null;
            //bool? nsfw = null;
            //string? name = null;
            //List<string>? tags = null;
            //bool? commentsEnabled = null;
            //VideoCommentsPolicySet? commentsPolicy = null;
            //bool? downloadEnabled = null;
            //DateTime? originallyPublishedAt = null;
            //VideoScheduledUpdate? scheduleUpdate = null;
            //List<string>? videoPasswords = null;
            //instance.PutVideo(id, thumbnailfile, previewfile, category, licence, language, privacy, description, waitTranscoding, support, nsfw, name, tags, commentsEnabled, commentsPolicy, downloadEnabled, originallyPublishedAt, scheduleUpdate, videoPasswords);
        }

        /// <summary>
        /// Test ReplaceVideoSourceResumable
        /// </summary>
        [Fact]
        public void ReplaceVideoSourceResumableTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string uploadId = null;
            //string contentRange = null;
            //decimal contentLength = null;
            //System.IO.Stream? body = null;
            //instance.ReplaceVideoSourceResumable(uploadId, contentRange, contentLength, body);
        }

        /// <summary>
        /// Test ReplaceVideoSourceResumableCancel
        /// </summary>
        [Fact]
        public void ReplaceVideoSourceResumableCancelTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string uploadId = null;
            //decimal contentLength = null;
            //instance.ReplaceVideoSourceResumableCancel(uploadId, contentLength);
        }

        /// <summary>
        /// Test ReplaceVideoSourceResumableInit
        /// </summary>
        [Fact]
        public void ReplaceVideoSourceResumableInitTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //decimal xUploadContentLength = null;
            //string xUploadContentType = null;
            //VideoReplaceSourceRequestResumable? videoReplaceSourceRequestResumable = null;
            //instance.ReplaceVideoSourceResumableInit(xUploadContentLength, xUploadContentType, videoReplaceSourceRequestResumable);
        }

        /// <summary>
        /// Test RequestVideoToken
        /// </summary>
        [Fact]
        public void RequestVideoTokenTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ApiV1VideosOwnershipIdAcceptPostIdParameter id = null;
            //string? xPeertubeVideoPassword = null;
            //var response = instance.RequestVideoToken(id, xPeertubeVideoPassword);
            //Assert.IsType<VideoTokenResponse>(response);
        }

        /// <summary>
        /// Test SearchVideos
        /// </summary>
        [Fact]
        public void SearchVideosTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string search = null;
            //GetAccountVideosCategoryOneOfParameter? categoryOneOf = null;
            //bool? isLive = null;
            //GetAccountVideosTagsOneOfParameter? tagsOneOf = null;
            //GetAccountVideosTagsAllOfParameter? tagsAllOf = null;
            //GetAccountVideosLicenceOneOfParameter? licenceOneOf = null;
            //GetAccountVideosLanguageOneOfParameter? languageOneOf = null;
            //GetAccountVideosTagsAllOfParameter? autoTagOneOf = null;
            //string? nsfw = null;
            //bool? isLocal = null;
            //int? include = null;
            //VideoPrivacySet? privacyOneOf = null;
            //List<string>? uuids = null;
            //bool? hasHLSFiles = null;
            //bool? hasWebVideoFiles = null;
            //string? skipCount = null;
            //int? start = null;
            //int? count = null;
            //string? searchTarget = null;
            //string? sort = null;
            //bool? excludeAlreadyWatched = null;
            //string? host = null;
            //DateTime? startDate = null;
            //DateTime? endDate = null;
            //DateTime? originallyPublishedStartDate = null;
            //DateTime? originallyPublishedEndDate = null;
            //int? durationMin = null;
            //int? durationMax = null;
            //var response = instance.SearchVideos(search, categoryOneOf, isLive, tagsOneOf, tagsAllOf, licenceOneOf, languageOneOf, autoTagOneOf, nsfw, isLocal, include, privacyOneOf, uuids, hasHLSFiles, hasWebVideoFiles, skipCount, start, count, searchTarget, sort, excludeAlreadyWatched, host, startDate, endDate, originallyPublishedStartDate, originallyPublishedEndDate, durationMin, durationMax);
            //Assert.IsType<VideoListResponse>(response);
        }

        /// <summary>
        /// Test UpdateLiveId
        /// </summary>
        [Fact]
        public void UpdateLiveIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //ApiV1VideosOwnershipIdAcceptPostIdParameter id = null;
            //LiveVideoUpdate? liveVideoUpdate = null;
            //instance.UpdateLiveId(id, liveVideoUpdate);
        }

        /// <summary>
        /// Test UploadLegacy
        /// </summary>
        [Fact]
        public void UploadLegacyTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string name = null;
            //int channelId = null;
            //System.IO.Stream videofile = null;
            //VideoPrivacySet? privacy = null;
            //int? category = null;
            //int? licence = null;
            //string? language = null;
            //string? description = null;
            //bool? waitTranscoding = null;
            //bool? generateTranscription = null;
            //string? support = null;
            //bool? nsfw = null;
            //List<string>? tags = null;
            //bool? commentsEnabled = null;
            //VideoCommentsPolicySet? commentsPolicy = null;
            //bool? downloadEnabled = null;
            //DateTime? originallyPublishedAt = null;
            //VideoScheduledUpdate? scheduleUpdate = null;
            //System.IO.Stream? thumbnailfile = null;
            //System.IO.Stream? previewfile = null;
            //List<string>? videoPasswords = null;
            //var response = instance.UploadLegacy(name, channelId, videofile, privacy, category, licence, language, description, waitTranscoding, generateTranscription, support, nsfw, tags, commentsEnabled, commentsPolicy, downloadEnabled, originallyPublishedAt, scheduleUpdate, thumbnailfile, previewfile, videoPasswords);
            //Assert.IsType<VideoUploadResponse>(response);
        }

        /// <summary>
        /// Test UploadResumable
        /// </summary>
        [Fact]
        public void UploadResumableTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string uploadId = null;
            //string contentRange = null;
            //decimal contentLength = null;
            //System.IO.Stream? body = null;
            //var response = instance.UploadResumable(uploadId, contentRange, contentLength, body);
            //Assert.IsType<VideoUploadResponse>(response);
        }

        /// <summary>
        /// Test UploadResumableCancel
        /// </summary>
        [Fact]
        public void UploadResumableCancelTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string uploadId = null;
            //decimal contentLength = null;
            //instance.UploadResumableCancel(uploadId, contentLength);
        }

        /// <summary>
        /// Test UploadResumableInit
        /// </summary>
        [Fact]
        public void UploadResumableInitTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //decimal xUploadContentLength = null;
            //string xUploadContentType = null;
            //VideoUploadRequestResumable? videoUploadRequestResumable = null;
            //instance.UploadResumableInit(xUploadContentLength, xUploadContentType, videoUploadRequestResumable);
        }
    }
}
