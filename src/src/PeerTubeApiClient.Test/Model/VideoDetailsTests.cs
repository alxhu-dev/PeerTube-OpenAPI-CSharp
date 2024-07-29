/*
 * PeerTube
 *
 * The PeerTube API is built on HTTP(S) and is RESTful. You can use your favorite HTTP/REST library for your programming language to use PeerTube. The spec API is fully compatible with [openapi-generator](https://github.com/OpenAPITools/openapi-generator/wiki/API-client-generator-HOWTO) which generates a client SDK in the language of your choice - we generate some client SDKs automatically:  - [Python](https://framagit.org/framasoft/peertube/clients/python) - [Go](https://framagit.org/framasoft/peertube/clients/go) - [Kotlin](https://framagit.org/framasoft/peertube/clients/kotlin)  See the [REST API quick start](https://docs.joinpeertube.org/api/rest-getting-started) for a few examples of using the PeerTube API.  # Authentication  When you sign up for an account on a PeerTube instance, you are given the possibility to generate sessions on it, and authenticate there using an access token. Only __one access token can currently be used at a time__.  ## Roles  Accounts are given permissions based on their role. There are three roles on PeerTube: Administrator, Moderator, and User. See the [roles guide](https://docs.joinpeertube.org/admin/managing-users#roles) for a detail of their permissions.  # Errors  The API uses standard HTTP status codes to indicate the success or failure of the API call, completed by a [RFC7807-compliant](https://tools.ietf.org/html/rfc7807) response body.  ``` HTTP 1.1 404 Not Found Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Video not found\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"status\": 404,   \"title\": \"Not Found\",   \"type\": \"about:blank\" } ```  We provide error `type` (following RFC7807) and `code` (internal PeerTube code) values for [a growing number of cases](https://github.com/Chocobozzz/PeerTube/blob/develop/packages/models/src/server/server-error-code.enum.ts), but it is still optional. Types are used to disambiguate errors that bear the same status code and are non-obvious:  ``` HTTP 1.1 403 Forbidden Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Cannot get this video regarding follow constraints\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"status\": 403,   \"title\": \"Forbidden\",   \"type\": \"https://docs.joinpeertube.org/api-rest-reference.html#section/Errors/does_not_respect_follow_constraints\" } ```  Here a 403 error could otherwise mean that the video is private or blocklisted.  ### Validation errors  Each parameter is evaluated on its own against a set of rules before the route validator proceeds with potential testing involving parameter combinations. Errors coming from validation errors appear earlier and benefit from a more detailed error description:  ``` HTTP 1.1 400 Bad Request Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Incorrect request parameters: id\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"instance\": \"/api/v1/videos/9c9de5e8-0a1e-484a-b099-e80766180\",   \"invalid-params\": {     \"id\": {       \"location\": \"params\",       \"msg\": \"Invalid value\",       \"param\": \"id\",       \"value\": \"9c9de5e8-0a1e-484a-b099-e80766180\"     }   },   \"status\": 400,   \"title\": \"Bad Request\",   \"type\": \"about:blank\" } ```  Where `id` is the name of the field concerned by the error, within the route definition. `invalid-params.<field>.location` can be either 'params', 'body', 'header', 'query' or 'cookies', and `invalid-params.<field>.value` reports the value that didn't pass validation whose `invalid-params.<field>.msg` is about.  ### Deprecated error fields  Some fields could be included with previous versions. They are still included but their use is deprecated: - `error`: superseded by `detail`  # Rate limits  We are rate-limiting all endpoints of PeerTube's API. Custom values can be set by administrators:  | Endpoint (prefix: `/api/v1`) | Calls         | Time frame   | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- --|- -- -- -- -- -- -- -| | `/_*`                         | 50            | 10 seconds   | | `POST /users/token`          | 15            | 5 minutes    | | `POST /users/register`       | 2<sup>*</sup> | 5 minutes    | | `POST /users/ask-send-verify-email` | 3      | 5 minutes    |  Depending on the endpoint, <sup>*</sup>failed requests are not taken into account. A service limit is announced by a `429 Too Many Requests` status code.  You can get details about the current state of your rate limit by reading the following headers:  | Header                  | Description                                                | |- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | `X-RateLimit-Limit`     | Number of max requests allowed in the current time period  | | `X-RateLimit-Remaining` | Number of remaining requests in the current time period    | | `X-RateLimit-Reset`     | Timestamp of end of current time period as UNIX timestamp  | | `Retry-After`           | Seconds to delay after the first `429` is received         |  # CORS  This API features [Cross-Origin Resource Sharing (CORS)](https://fetch.spec.whatwg.org/), allowing cross-domain communication from the browser for some routes:  | Endpoint                    | |- -- -- -- -- -- -- -- -- -- -- -- -- - --| | `/api/_*`                    | | `/download/_*`               | | `/lazy-static/_*`            | | `/.well-known/webfinger`    |  In addition, all routes serving ActivityPub are CORS-enabled for all origins. 
 *
 * The version of the OpenAPI document: 6.2.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using Xunit;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using PeerTubeApiClient.Model;
using PeerTubeApiClient.Client;
using System.Reflection;
using Newtonsoft.Json;

namespace PeerTubeApiClient.Test.Model
{
    /// <summary>
    ///  Class for testing VideoDetails
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class VideoDetailsTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for VideoDetails
        //private VideoDetails instance;

        public VideoDetailsTests()
        {
            // TODO uncomment below to create an instance of VideoDetails
            //instance = new VideoDetails();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of VideoDetails
        /// </summary>
        [Fact]
        public void VideoDetailsInstanceTest()
        {
            // TODO uncomment below to test "IsType" VideoDetails
            //Assert.IsType<VideoDetails>(instance);
        }

        /// <summary>
        /// Test the property 'Id'
        /// </summary>
        [Fact]
        public void IdTest()
        {
            // TODO unit test for the property 'Id'
        }

        /// <summary>
        /// Test the property 'Uuid'
        /// </summary>
        [Fact]
        public void UuidTest()
        {
            // TODO unit test for the property 'Uuid'
        }

        /// <summary>
        /// Test the property 'ShortUUID'
        /// </summary>
        [Fact]
        public void ShortUUIDTest()
        {
            // TODO unit test for the property 'ShortUUID'
        }

        /// <summary>
        /// Test the property 'IsLive'
        /// </summary>
        [Fact]
        public void IsLiveTest()
        {
            // TODO unit test for the property 'IsLive'
        }

        /// <summary>
        /// Test the property 'CreatedAt'
        /// </summary>
        [Fact]
        public void CreatedAtTest()
        {
            // TODO unit test for the property 'CreatedAt'
        }

        /// <summary>
        /// Test the property 'PublishedAt'
        /// </summary>
        [Fact]
        public void PublishedAtTest()
        {
            // TODO unit test for the property 'PublishedAt'
        }

        /// <summary>
        /// Test the property 'UpdatedAt'
        /// </summary>
        [Fact]
        public void UpdatedAtTest()
        {
            // TODO unit test for the property 'UpdatedAt'
        }

        /// <summary>
        /// Test the property 'OriginallyPublishedAt'
        /// </summary>
        [Fact]
        public void OriginallyPublishedAtTest()
        {
            // TODO unit test for the property 'OriginallyPublishedAt'
        }

        /// <summary>
        /// Test the property 'Category'
        /// </summary>
        [Fact]
        public void CategoryTest()
        {
            // TODO unit test for the property 'Category'
        }

        /// <summary>
        /// Test the property 'Licence'
        /// </summary>
        [Fact]
        public void LicenceTest()
        {
            // TODO unit test for the property 'Licence'
        }

        /// <summary>
        /// Test the property 'Language'
        /// </summary>
        [Fact]
        public void LanguageTest()
        {
            // TODO unit test for the property 'Language'
        }

        /// <summary>
        /// Test the property 'Privacy'
        /// </summary>
        [Fact]
        public void PrivacyTest()
        {
            // TODO unit test for the property 'Privacy'
        }

        /// <summary>
        /// Test the property 'TruncatedDescription'
        /// </summary>
        [Fact]
        public void TruncatedDescriptionTest()
        {
            // TODO unit test for the property 'TruncatedDescription'
        }

        /// <summary>
        /// Test the property 'Duration'
        /// </summary>
        [Fact]
        public void DurationTest()
        {
            // TODO unit test for the property 'Duration'
        }

        /// <summary>
        /// Test the property 'AspectRatio'
        /// </summary>
        [Fact]
        public void AspectRatioTest()
        {
            // TODO unit test for the property 'AspectRatio'
        }

        /// <summary>
        /// Test the property 'IsLocal'
        /// </summary>
        [Fact]
        public void IsLocalTest()
        {
            // TODO unit test for the property 'IsLocal'
        }

        /// <summary>
        /// Test the property 'Name'
        /// </summary>
        [Fact]
        public void NameTest()
        {
            // TODO unit test for the property 'Name'
        }

        /// <summary>
        /// Test the property 'ThumbnailPath'
        /// </summary>
        [Fact]
        public void ThumbnailPathTest()
        {
            // TODO unit test for the property 'ThumbnailPath'
        }

        /// <summary>
        /// Test the property 'PreviewPath'
        /// </summary>
        [Fact]
        public void PreviewPathTest()
        {
            // TODO unit test for the property 'PreviewPath'
        }

        /// <summary>
        /// Test the property 'EmbedPath'
        /// </summary>
        [Fact]
        public void EmbedPathTest()
        {
            // TODO unit test for the property 'EmbedPath'
        }

        /// <summary>
        /// Test the property 'Views'
        /// </summary>
        [Fact]
        public void ViewsTest()
        {
            // TODO unit test for the property 'Views'
        }

        /// <summary>
        /// Test the property 'Likes'
        /// </summary>
        [Fact]
        public void LikesTest()
        {
            // TODO unit test for the property 'Likes'
        }

        /// <summary>
        /// Test the property 'Dislikes'
        /// </summary>
        [Fact]
        public void DislikesTest()
        {
            // TODO unit test for the property 'Dislikes'
        }

        /// <summary>
        /// Test the property 'Nsfw'
        /// </summary>
        [Fact]
        public void NsfwTest()
        {
            // TODO unit test for the property 'Nsfw'
        }

        /// <summary>
        /// Test the property 'WaitTranscoding'
        /// </summary>
        [Fact]
        public void WaitTranscodingTest()
        {
            // TODO unit test for the property 'WaitTranscoding'
        }

        /// <summary>
        /// Test the property 'State'
        /// </summary>
        [Fact]
        public void StateTest()
        {
            // TODO unit test for the property 'State'
        }

        /// <summary>
        /// Test the property 'ScheduledUpdate'
        /// </summary>
        [Fact]
        public void ScheduledUpdateTest()
        {
            // TODO unit test for the property 'ScheduledUpdate'
        }

        /// <summary>
        /// Test the property 'Blacklisted'
        /// </summary>
        [Fact]
        public void BlacklistedTest()
        {
            // TODO unit test for the property 'Blacklisted'
        }

        /// <summary>
        /// Test the property 'BlacklistedReason'
        /// </summary>
        [Fact]
        public void BlacklistedReasonTest()
        {
            // TODO unit test for the property 'BlacklistedReason'
        }

        /// <summary>
        /// Test the property 'Account'
        /// </summary>
        [Fact]
        public void AccountTest()
        {
            // TODO unit test for the property 'Account'
        }

        /// <summary>
        /// Test the property 'Channel'
        /// </summary>
        [Fact]
        public void ChannelTest()
        {
            // TODO unit test for the property 'Channel'
        }

        /// <summary>
        /// Test the property 'UserHistory'
        /// </summary>
        [Fact]
        public void UserHistoryTest()
        {
            // TODO unit test for the property 'UserHistory'
        }

        /// <summary>
        /// Test the property 'Viewers'
        /// </summary>
        [Fact]
        public void ViewersTest()
        {
            // TODO unit test for the property 'Viewers'
        }

        /// <summary>
        /// Test the property 'Description'
        /// </summary>
        [Fact]
        public void DescriptionTest()
        {
            // TODO unit test for the property 'Description'
        }

        /// <summary>
        /// Test the property 'Support'
        /// </summary>
        [Fact]
        public void SupportTest()
        {
            // TODO unit test for the property 'Support'
        }

        /// <summary>
        /// Test the property 'Tags'
        /// </summary>
        [Fact]
        public void TagsTest()
        {
            // TODO unit test for the property 'Tags'
        }

        /// <summary>
        /// Test the property 'CommentsEnabled'
        /// </summary>
        [Fact]
        public void CommentsEnabledTest()
        {
            // TODO unit test for the property 'CommentsEnabled'
        }

        /// <summary>
        /// Test the property 'CommentsPolicy'
        /// </summary>
        [Fact]
        public void CommentsPolicyTest()
        {
            // TODO unit test for the property 'CommentsPolicy'
        }

        /// <summary>
        /// Test the property 'DownloadEnabled'
        /// </summary>
        [Fact]
        public void DownloadEnabledTest()
        {
            // TODO unit test for the property 'DownloadEnabled'
        }

        /// <summary>
        /// Test the property 'InputFileUpdatedAt'
        /// </summary>
        [Fact]
        public void InputFileUpdatedAtTest()
        {
            // TODO unit test for the property 'InputFileUpdatedAt'
        }

        /// <summary>
        /// Test the property 'TrackerUrls'
        /// </summary>
        [Fact]
        public void TrackerUrlsTest()
        {
            // TODO unit test for the property 'TrackerUrls'
        }

        /// <summary>
        /// Test the property 'Files'
        /// </summary>
        [Fact]
        public void FilesTest()
        {
            // TODO unit test for the property 'Files'
        }

        /// <summary>
        /// Test the property 'StreamingPlaylists'
        /// </summary>
        [Fact]
        public void StreamingPlaylistsTest()
        {
            // TODO unit test for the property 'StreamingPlaylists'
        }
    }
}
