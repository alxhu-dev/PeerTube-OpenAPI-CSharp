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
    ///  Class for testing ServerConfigAboutInstance
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class ServerConfigAboutInstanceTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for ServerConfigAboutInstance
        //private ServerConfigAboutInstance instance;

        public ServerConfigAboutInstanceTests()
        {
            // TODO uncomment below to create an instance of ServerConfigAboutInstance
            //instance = new ServerConfigAboutInstance();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of ServerConfigAboutInstance
        /// </summary>
        [Fact]
        public void ServerConfigAboutInstanceInstanceTest()
        {
            // TODO uncomment below to test "IsType" ServerConfigAboutInstance
            //Assert.IsType<ServerConfigAboutInstance>(instance);
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
        /// Test the property 'ShortDescription'
        /// </summary>
        [Fact]
        public void ShortDescriptionTest()
        {
            // TODO unit test for the property 'ShortDescription'
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
        /// Test the property 'Terms'
        /// </summary>
        [Fact]
        public void TermsTest()
        {
            // TODO unit test for the property 'Terms'
        }

        /// <summary>
        /// Test the property 'CodeOfConduct'
        /// </summary>
        [Fact]
        public void CodeOfConductTest()
        {
            // TODO unit test for the property 'CodeOfConduct'
        }

        /// <summary>
        /// Test the property 'HardwareInformation'
        /// </summary>
        [Fact]
        public void HardwareInformationTest()
        {
            // TODO unit test for the property 'HardwareInformation'
        }

        /// <summary>
        /// Test the property 'CreationReason'
        /// </summary>
        [Fact]
        public void CreationReasonTest()
        {
            // TODO unit test for the property 'CreationReason'
        }

        /// <summary>
        /// Test the property 'ModerationInformation'
        /// </summary>
        [Fact]
        public void ModerationInformationTest()
        {
            // TODO unit test for the property 'ModerationInformation'
        }

        /// <summary>
        /// Test the property 'Administrator'
        /// </summary>
        [Fact]
        public void AdministratorTest()
        {
            // TODO unit test for the property 'Administrator'
        }

        /// <summary>
        /// Test the property 'MaintenanceLifetime'
        /// </summary>
        [Fact]
        public void MaintenanceLifetimeTest()
        {
            // TODO unit test for the property 'MaintenanceLifetime'
        }

        /// <summary>
        /// Test the property 'BusinessModel'
        /// </summary>
        [Fact]
        public void BusinessModelTest()
        {
            // TODO unit test for the property 'BusinessModel'
        }

        /// <summary>
        /// Test the property 'Languages'
        /// </summary>
        [Fact]
        public void LanguagesTest()
        {
            // TODO unit test for the property 'Languages'
        }

        /// <summary>
        /// Test the property 'Categories'
        /// </summary>
        [Fact]
        public void CategoriesTest()
        {
            // TODO unit test for the property 'Categories'
        }

        /// <summary>
        /// Test the property 'Avatars'
        /// </summary>
        [Fact]
        public void AvatarsTest()
        {
            // TODO unit test for the property 'Avatars'
        }

        /// <summary>
        /// Test the property 'Banners'
        /// </summary>
        [Fact]
        public void BannersTest()
        {
            // TODO unit test for the property 'Banners'
        }
    }
}
