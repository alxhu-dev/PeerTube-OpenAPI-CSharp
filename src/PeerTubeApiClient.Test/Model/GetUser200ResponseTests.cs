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
    ///  Class for testing GetUser200Response
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class GetUser200ResponseTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for GetUser200Response
        //private GetUser200Response instance;

        public GetUser200ResponseTests()
        {
            // TODO uncomment below to create an instance of GetUser200Response
            //instance = new GetUser200Response();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of GetUser200Response
        /// </summary>
        [Fact]
        public void GetUser200ResponseInstanceTest()
        {
            // TODO uncomment below to test "IsType" GetUser200Response
            //Assert.IsType<GetUser200Response>(instance);
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
        /// Test the property 'AutoPlayNextVideo'
        /// </summary>
        [Fact]
        public void AutoPlayNextVideoTest()
        {
            // TODO unit test for the property 'AutoPlayNextVideo'
        }

        /// <summary>
        /// Test the property 'AutoPlayNextVideoPlaylist'
        /// </summary>
        [Fact]
        public void AutoPlayNextVideoPlaylistTest()
        {
            // TODO unit test for the property 'AutoPlayNextVideoPlaylist'
        }

        /// <summary>
        /// Test the property 'AutoPlayVideo'
        /// </summary>
        [Fact]
        public void AutoPlayVideoTest()
        {
            // TODO unit test for the property 'AutoPlayVideo'
        }

        /// <summary>
        /// Test the property 'Blocked'
        /// </summary>
        [Fact]
        public void BlockedTest()
        {
            // TODO unit test for the property 'Blocked'
        }

        /// <summary>
        /// Test the property 'BlockedReason'
        /// </summary>
        [Fact]
        public void BlockedReasonTest()
        {
            // TODO unit test for the property 'BlockedReason'
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
        /// Test the property 'Email'
        /// </summary>
        [Fact]
        public void EmailTest()
        {
            // TODO unit test for the property 'Email'
        }

        /// <summary>
        /// Test the property 'EmailVerified'
        /// </summary>
        [Fact]
        public void EmailVerifiedTest()
        {
            // TODO unit test for the property 'EmailVerified'
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
        /// Test the property 'PluginAuth'
        /// </summary>
        [Fact]
        public void PluginAuthTest()
        {
            // TODO unit test for the property 'PluginAuth'
        }

        /// <summary>
        /// Test the property 'LastLoginDate'
        /// </summary>
        [Fact]
        public void LastLoginDateTest()
        {
            // TODO unit test for the property 'LastLoginDate'
        }

        /// <summary>
        /// Test the property 'NoInstanceConfigWarningModal'
        /// </summary>
        [Fact]
        public void NoInstanceConfigWarningModalTest()
        {
            // TODO unit test for the property 'NoInstanceConfigWarningModal'
        }

        /// <summary>
        /// Test the property 'NoAccountSetupWarningModal'
        /// </summary>
        [Fact]
        public void NoAccountSetupWarningModalTest()
        {
            // TODO unit test for the property 'NoAccountSetupWarningModal'
        }

        /// <summary>
        /// Test the property 'NoWelcomeModal'
        /// </summary>
        [Fact]
        public void NoWelcomeModalTest()
        {
            // TODO unit test for the property 'NoWelcomeModal'
        }

        /// <summary>
        /// Test the property 'NsfwPolicy'
        /// </summary>
        [Fact]
        public void NsfwPolicyTest()
        {
            // TODO unit test for the property 'NsfwPolicy'
        }

        /// <summary>
        /// Test the property 'Role'
        /// </summary>
        [Fact]
        public void RoleTest()
        {
            // TODO unit test for the property 'Role'
        }

        /// <summary>
        /// Test the property 'Theme'
        /// </summary>
        [Fact]
        public void ThemeTest()
        {
            // TODO unit test for the property 'Theme'
        }

        /// <summary>
        /// Test the property 'Username'
        /// </summary>
        [Fact]
        public void UsernameTest()
        {
            // TODO unit test for the property 'Username'
        }

        /// <summary>
        /// Test the property 'VideoChannels'
        /// </summary>
        [Fact]
        public void VideoChannelsTest()
        {
            // TODO unit test for the property 'VideoChannels'
        }

        /// <summary>
        /// Test the property 'VideoQuota'
        /// </summary>
        [Fact]
        public void VideoQuotaTest()
        {
            // TODO unit test for the property 'VideoQuota'
        }

        /// <summary>
        /// Test the property 'VideoQuotaDaily'
        /// </summary>
        [Fact]
        public void VideoQuotaDailyTest()
        {
            // TODO unit test for the property 'VideoQuotaDaily'
        }

        /// <summary>
        /// Test the property 'P2pEnabled'
        /// </summary>
        [Fact]
        public void P2pEnabledTest()
        {
            // TODO unit test for the property 'P2pEnabled'
        }

        /// <summary>
        /// Test the property 'VideosCount'
        /// </summary>
        [Fact]
        public void VideosCountTest()
        {
            // TODO unit test for the property 'VideosCount'
        }

        /// <summary>
        /// Test the property 'AbusesCount'
        /// </summary>
        [Fact]
        public void AbusesCountTest()
        {
            // TODO unit test for the property 'AbusesCount'
        }

        /// <summary>
        /// Test the property 'AbusesAcceptedCount'
        /// </summary>
        [Fact]
        public void AbusesAcceptedCountTest()
        {
            // TODO unit test for the property 'AbusesAcceptedCount'
        }

        /// <summary>
        /// Test the property 'AbusesCreatedCount'
        /// </summary>
        [Fact]
        public void AbusesCreatedCountTest()
        {
            // TODO unit test for the property 'AbusesCreatedCount'
        }

        /// <summary>
        /// Test the property 'VideoCommentsCount'
        /// </summary>
        [Fact]
        public void VideoCommentsCountTest()
        {
            // TODO unit test for the property 'VideoCommentsCount'
        }
    }
}
