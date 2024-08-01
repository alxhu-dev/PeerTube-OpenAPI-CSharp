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
    ///  Class for testing ServerStats
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class ServerStatsTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for ServerStats
        //private ServerStats instance;

        public ServerStatsTests()
        {
            // TODO uncomment below to create an instance of ServerStats
            //instance = new ServerStats();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of ServerStats
        /// </summary>
        [Fact]
        public void ServerStatsInstanceTest()
        {
            // TODO uncomment below to test "IsType" ServerStats
            //Assert.IsType<ServerStats>(instance);
        }

        /// <summary>
        /// Test the property 'TotalUsers'
        /// </summary>
        [Fact]
        public void TotalUsersTest()
        {
            // TODO unit test for the property 'TotalUsers'
        }

        /// <summary>
        /// Test the property 'TotalDailyActiveUsers'
        /// </summary>
        [Fact]
        public void TotalDailyActiveUsersTest()
        {
            // TODO unit test for the property 'TotalDailyActiveUsers'
        }

        /// <summary>
        /// Test the property 'TotalWeeklyActiveUsers'
        /// </summary>
        [Fact]
        public void TotalWeeklyActiveUsersTest()
        {
            // TODO unit test for the property 'TotalWeeklyActiveUsers'
        }

        /// <summary>
        /// Test the property 'TotalMonthlyActiveUsers'
        /// </summary>
        [Fact]
        public void TotalMonthlyActiveUsersTest()
        {
            // TODO unit test for the property 'TotalMonthlyActiveUsers'
        }

        /// <summary>
        /// Test the property 'TotalModerators'
        /// </summary>
        [Fact]
        public void TotalModeratorsTest()
        {
            // TODO unit test for the property 'TotalModerators'
        }

        /// <summary>
        /// Test the property 'TotalAdmins'
        /// </summary>
        [Fact]
        public void TotalAdminsTest()
        {
            // TODO unit test for the property 'TotalAdmins'
        }

        /// <summary>
        /// Test the property 'TotalLocalVideos'
        /// </summary>
        [Fact]
        public void TotalLocalVideosTest()
        {
            // TODO unit test for the property 'TotalLocalVideos'
        }

        /// <summary>
        /// Test the property 'TotalLocalVideoViews'
        /// </summary>
        [Fact]
        public void TotalLocalVideoViewsTest()
        {
            // TODO unit test for the property 'TotalLocalVideoViews'
        }

        /// <summary>
        /// Test the property 'TotalLocalVideoComments'
        /// </summary>
        [Fact]
        public void TotalLocalVideoCommentsTest()
        {
            // TODO unit test for the property 'TotalLocalVideoComments'
        }

        /// <summary>
        /// Test the property 'TotalLocalVideoFilesSize'
        /// </summary>
        [Fact]
        public void TotalLocalVideoFilesSizeTest()
        {
            // TODO unit test for the property 'TotalLocalVideoFilesSize'
        }

        /// <summary>
        /// Test the property 'TotalVideos'
        /// </summary>
        [Fact]
        public void TotalVideosTest()
        {
            // TODO unit test for the property 'TotalVideos'
        }

        /// <summary>
        /// Test the property 'TotalVideoComments'
        /// </summary>
        [Fact]
        public void TotalVideoCommentsTest()
        {
            // TODO unit test for the property 'TotalVideoComments'
        }

        /// <summary>
        /// Test the property 'TotalLocalVideoChannels'
        /// </summary>
        [Fact]
        public void TotalLocalVideoChannelsTest()
        {
            // TODO unit test for the property 'TotalLocalVideoChannels'
        }

        /// <summary>
        /// Test the property 'TotalLocalDailyActiveVideoChannels'
        /// </summary>
        [Fact]
        public void TotalLocalDailyActiveVideoChannelsTest()
        {
            // TODO unit test for the property 'TotalLocalDailyActiveVideoChannels'
        }

        /// <summary>
        /// Test the property 'TotalLocalWeeklyActiveVideoChannels'
        /// </summary>
        [Fact]
        public void TotalLocalWeeklyActiveVideoChannelsTest()
        {
            // TODO unit test for the property 'TotalLocalWeeklyActiveVideoChannels'
        }

        /// <summary>
        /// Test the property 'TotalLocalMonthlyActiveVideoChannels'
        /// </summary>
        [Fact]
        public void TotalLocalMonthlyActiveVideoChannelsTest()
        {
            // TODO unit test for the property 'TotalLocalMonthlyActiveVideoChannels'
        }

        /// <summary>
        /// Test the property 'TotalLocalPlaylists'
        /// </summary>
        [Fact]
        public void TotalLocalPlaylistsTest()
        {
            // TODO unit test for the property 'TotalLocalPlaylists'
        }

        /// <summary>
        /// Test the property 'TotalInstanceFollowers'
        /// </summary>
        [Fact]
        public void TotalInstanceFollowersTest()
        {
            // TODO unit test for the property 'TotalInstanceFollowers'
        }

        /// <summary>
        /// Test the property 'TotalInstanceFollowing'
        /// </summary>
        [Fact]
        public void TotalInstanceFollowingTest()
        {
            // TODO unit test for the property 'TotalInstanceFollowing'
        }

        /// <summary>
        /// Test the property 'VideosRedundancy'
        /// </summary>
        [Fact]
        public void VideosRedundancyTest()
        {
            // TODO unit test for the property 'VideosRedundancy'
        }

        /// <summary>
        /// Test the property 'TotalActivityPubMessagesProcessed'
        /// </summary>
        [Fact]
        public void TotalActivityPubMessagesProcessedTest()
        {
            // TODO unit test for the property 'TotalActivityPubMessagesProcessed'
        }

        /// <summary>
        /// Test the property 'TotalActivityPubMessagesSuccesses'
        /// </summary>
        [Fact]
        public void TotalActivityPubMessagesSuccessesTest()
        {
            // TODO unit test for the property 'TotalActivityPubMessagesSuccesses'
        }

        /// <summary>
        /// Test the property 'TotalActivityPubMessagesErrors'
        /// </summary>
        [Fact]
        public void TotalActivityPubMessagesErrorsTest()
        {
            // TODO unit test for the property 'TotalActivityPubMessagesErrors'
        }

        /// <summary>
        /// Test the property 'ActivityPubMessagesProcessedPerSecond'
        /// </summary>
        [Fact]
        public void ActivityPubMessagesProcessedPerSecondTest()
        {
            // TODO unit test for the property 'ActivityPubMessagesProcessedPerSecond'
        }

        /// <summary>
        /// Test the property 'TotalActivityPubMessagesWaiting'
        /// </summary>
        [Fact]
        public void TotalActivityPubMessagesWaitingTest()
        {
            // TODO unit test for the property 'TotalActivityPubMessagesWaiting'
        }

        /// <summary>
        /// Test the property 'AverageRegistrationRequestResponseTimeMs'
        /// </summary>
        [Fact]
        public void AverageRegistrationRequestResponseTimeMsTest()
        {
            // TODO unit test for the property 'AverageRegistrationRequestResponseTimeMs'
        }

        /// <summary>
        /// Test the property 'TotalRegistrationRequestsProcessed'
        /// </summary>
        [Fact]
        public void TotalRegistrationRequestsProcessedTest()
        {
            // TODO unit test for the property 'TotalRegistrationRequestsProcessed'
        }

        /// <summary>
        /// Test the property 'TotalRegistrationRequests'
        /// </summary>
        [Fact]
        public void TotalRegistrationRequestsTest()
        {
            // TODO unit test for the property 'TotalRegistrationRequests'
        }

        /// <summary>
        /// Test the property 'AverageAbuseResponseTimeMs'
        /// </summary>
        [Fact]
        public void AverageAbuseResponseTimeMsTest()
        {
            // TODO unit test for the property 'AverageAbuseResponseTimeMs'
        }

        /// <summary>
        /// Test the property 'TotalAbusesProcessed'
        /// </summary>
        [Fact]
        public void TotalAbusesProcessedTest()
        {
            // TODO unit test for the property 'TotalAbusesProcessed'
        }

        /// <summary>
        /// Test the property 'TotalAbuses'
        /// </summary>
        [Fact]
        public void TotalAbusesTest()
        {
            // TODO unit test for the property 'TotalAbuses'
        }
    }
}
