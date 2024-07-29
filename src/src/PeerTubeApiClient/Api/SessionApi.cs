/*
 * PeerTube
 *
 * The PeerTube API is built on HTTP(S) and is RESTful. You can use your favorite HTTP/REST library for your programming language to use PeerTube. The spec API is fully compatible with [openapi-generator](https://github.com/OpenAPITools/openapi-generator/wiki/API-client-generator-HOWTO) which generates a client SDK in the language of your choice - we generate some client SDKs automatically:  - [Python](https://framagit.org/framasoft/peertube/clients/python) - [Go](https://framagit.org/framasoft/peertube/clients/go) - [Kotlin](https://framagit.org/framasoft/peertube/clients/kotlin)  See the [REST API quick start](https://docs.joinpeertube.org/api/rest-getting-started) for a few examples of using the PeerTube API.  # Authentication  When you sign up for an account on a PeerTube instance, you are given the possibility to generate sessions on it, and authenticate there using an access token. Only __one access token can currently be used at a time__.  ## Roles  Accounts are given permissions based on their role. There are three roles on PeerTube: Administrator, Moderator, and User. See the [roles guide](https://docs.joinpeertube.org/admin/managing-users#roles) for a detail of their permissions.  # Errors  The API uses standard HTTP status codes to indicate the success or failure of the API call, completed by a [RFC7807-compliant](https://tools.ietf.org/html/rfc7807) response body.  ``` HTTP 1.1 404 Not Found Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Video not found\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"status\": 404,   \"title\": \"Not Found\",   \"type\": \"about:blank\" } ```  We provide error `type` (following RFC7807) and `code` (internal PeerTube code) values for [a growing number of cases](https://github.com/Chocobozzz/PeerTube/blob/develop/packages/models/src/server/server-error-code.enum.ts), but it is still optional. Types are used to disambiguate errors that bear the same status code and are non-obvious:  ``` HTTP 1.1 403 Forbidden Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Cannot get this video regarding follow constraints\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"status\": 403,   \"title\": \"Forbidden\",   \"type\": \"https://docs.joinpeertube.org/api-rest-reference.html#section/Errors/does_not_respect_follow_constraints\" } ```  Here a 403 error could otherwise mean that the video is private or blocklisted.  ### Validation errors  Each parameter is evaluated on its own against a set of rules before the route validator proceeds with potential testing involving parameter combinations. Errors coming from validation errors appear earlier and benefit from a more detailed error description:  ``` HTTP 1.1 400 Bad Request Content-Type: application/problem+json; charset=utf-8  {   \"detail\": \"Incorrect request parameters: id\",   \"docs\": \"https://docs.joinpeertube.org/api-rest-reference.html#operation/getVideo\",   \"instance\": \"/api/v1/videos/9c9de5e8-0a1e-484a-b099-e80766180\",   \"invalid-params\": {     \"id\": {       \"location\": \"params\",       \"msg\": \"Invalid value\",       \"param\": \"id\",       \"value\": \"9c9de5e8-0a1e-484a-b099-e80766180\"     }   },   \"status\": 400,   \"title\": \"Bad Request\",   \"type\": \"about:blank\" } ```  Where `id` is the name of the field concerned by the error, within the route definition. `invalid-params.<field>.location` can be either 'params', 'body', 'header', 'query' or 'cookies', and `invalid-params.<field>.value` reports the value that didn't pass validation whose `invalid-params.<field>.msg` is about.  ### Deprecated error fields  Some fields could be included with previous versions. They are still included but their use is deprecated: - `error`: superseded by `detail`  # Rate limits  We are rate-limiting all endpoints of PeerTube's API. Custom values can be set by administrators:  | Endpoint (prefix: `/api/v1`) | Calls         | Time frame   | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- --|- -- -- -- -- -- -- -| | `/_*`                         | 50            | 10 seconds   | | `POST /users/token`          | 15            | 5 minutes    | | `POST /users/register`       | 2<sup>*</sup> | 5 minutes    | | `POST /users/ask-send-verify-email` | 3      | 5 minutes    |  Depending on the endpoint, <sup>*</sup>failed requests are not taken into account. A service limit is announced by a `429 Too Many Requests` status code.  You can get details about the current state of your rate limit by reading the following headers:  | Header                  | Description                                                | |- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | `X-RateLimit-Limit`     | Number of max requests allowed in the current time period  | | `X-RateLimit-Remaining` | Number of remaining requests in the current time period    | | `X-RateLimit-Reset`     | Timestamp of end of current time period as UNIX timestamp  | | `Retry-After`           | Seconds to delay after the first `429` is received         |  # CORS  This API features [Cross-Origin Resource Sharing (CORS)](https://fetch.spec.whatwg.org/), allowing cross-domain communication from the browser for some routes:  | Endpoint                    | |- -- -- -- -- -- -- -- -- -- -- -- -- - --| | `/api/_*`                    | | `/download/_*`               | | `/lazy-static/_*`            | | `/.well-known/webfinger`    |  In addition, all routes serving ActivityPub are CORS-enabled for all origins. 
 *
 * The version of the OpenAPI document: 6.2.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using PeerTubeApiClient.Client;
using PeerTubeApiClient.Client.Auth;
using PeerTubeApiClient.Model;

namespace PeerTubeApiClient.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISessionApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Login prerequisite
        /// </summary>
        /// <remarks>
        /// You need to retrieve a client id and secret before [logging in](#operation/getOAuthToken).
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>OAuthClient</returns>
        OAuthClient GetOAuthClient(int operationIndex = 0);

        /// <summary>
        /// Login prerequisite
        /// </summary>
        /// <remarks>
        /// You need to retrieve a client id and secret before [logging in](#operation/getOAuthToken).
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of OAuthClient</returns>
        ApiResponse<OAuthClient> GetOAuthClientWithHttpInfo(int operationIndex = 0);
        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>
        /// With your [client id and secret](#operation/getOAuthClient), you can retrieve an access and refresh tokens.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"> (optional)</param>
        /// <param name="clientSecret"> (optional)</param>
        /// <param name="grantType"> (optional, default to password)</param>
        /// <param name="username">immutable name of the user, used to find or mention its actor (optional)</param>
        /// <param name="password"> (optional)</param>
        /// <param name="refreshToken"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetOAuthToken200Response</returns>
        GetOAuthToken200Response GetOAuthToken(string? clientId = default(string?), string? clientSecret = default(string?), string? grantType = default(string?), string? username = default(string?), string? password = default(string?), string? refreshToken = default(string?), int operationIndex = 0);

        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>
        /// With your [client id and secret](#operation/getOAuthClient), you can retrieve an access and refresh tokens.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"> (optional)</param>
        /// <param name="clientSecret"> (optional)</param>
        /// <param name="grantType"> (optional, default to password)</param>
        /// <param name="username">immutable name of the user, used to find or mention its actor (optional)</param>
        /// <param name="password"> (optional)</param>
        /// <param name="refreshToken"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetOAuthToken200Response</returns>
        ApiResponse<GetOAuthToken200Response> GetOAuthTokenWithHttpInfo(string? clientId = default(string?), string? clientSecret = default(string?), string? grantType = default(string?), string? username = default(string?), string? password = default(string?), string? refreshToken = default(string?), int operationIndex = 0);
        /// <summary>
        /// Logout
        /// </summary>
        /// <remarks>
        /// Revokes your access token and its associated refresh token, destroying your current session.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void RevokeOAuthToken(int operationIndex = 0);

        /// <summary>
        /// Logout
        /// </summary>
        /// <remarks>
        /// Revokes your access token and its associated refresh token, destroying your current session.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> RevokeOAuthTokenWithHttpInfo(int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISessionApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Login prerequisite
        /// </summary>
        /// <remarks>
        /// You need to retrieve a client id and secret before [logging in](#operation/getOAuthToken).
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OAuthClient</returns>
        System.Threading.Tasks.Task<OAuthClient> GetOAuthClientAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Login prerequisite
        /// </summary>
        /// <remarks>
        /// You need to retrieve a client id and secret before [logging in](#operation/getOAuthToken).
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OAuthClient)</returns>
        System.Threading.Tasks.Task<ApiResponse<OAuthClient>> GetOAuthClientWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>
        /// With your [client id and secret](#operation/getOAuthClient), you can retrieve an access and refresh tokens.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"> (optional)</param>
        /// <param name="clientSecret"> (optional)</param>
        /// <param name="grantType"> (optional, default to password)</param>
        /// <param name="username">immutable name of the user, used to find or mention its actor (optional)</param>
        /// <param name="password"> (optional)</param>
        /// <param name="refreshToken"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetOAuthToken200Response</returns>
        System.Threading.Tasks.Task<GetOAuthToken200Response> GetOAuthTokenAsync(string? clientId = default(string?), string? clientSecret = default(string?), string? grantType = default(string?), string? username = default(string?), string? password = default(string?), string? refreshToken = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>
        /// With your [client id and secret](#operation/getOAuthClient), you can retrieve an access and refresh tokens.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"> (optional)</param>
        /// <param name="clientSecret"> (optional)</param>
        /// <param name="grantType"> (optional, default to password)</param>
        /// <param name="username">immutable name of the user, used to find or mention its actor (optional)</param>
        /// <param name="password"> (optional)</param>
        /// <param name="refreshToken"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetOAuthToken200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetOAuthToken200Response>> GetOAuthTokenWithHttpInfoAsync(string? clientId = default(string?), string? clientSecret = default(string?), string? grantType = default(string?), string? username = default(string?), string? password = default(string?), string? refreshToken = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Logout
        /// </summary>
        /// <remarks>
        /// Revokes your access token and its associated refresh token, destroying your current session.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task RevokeOAuthTokenAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Logout
        /// </summary>
        /// <remarks>
        /// Revokes your access token and its associated refresh token, destroying your current session.
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> RevokeOAuthTokenWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISessionApi : ISessionApiSync, ISessionApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class SessionApi : ISessionApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SessionApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SessionApi(string basePath)
        {
            this.Configuration = PeerTubeApiClient.Client.Configuration.MergeConfigurations(
                PeerTubeApiClient.Client.GlobalConfiguration.Instance,
                new PeerTubeApiClient.Client.Configuration { BasePath = basePath }
            );
            this.Client = new PeerTubeApiClient.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new PeerTubeApiClient.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = PeerTubeApiClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public SessionApi(PeerTubeApiClient.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = PeerTubeApiClient.Client.Configuration.MergeConfigurations(
                PeerTubeApiClient.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new PeerTubeApiClient.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new PeerTubeApiClient.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = PeerTubeApiClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public SessionApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = PeerTubeApiClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public PeerTubeApiClient.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public PeerTubeApiClient.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public PeerTubeApiClient.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public PeerTubeApiClient.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Login prerequisite You need to retrieve a client id and secret before [logging in](#operation/getOAuthToken).
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>OAuthClient</returns>
        public OAuthClient GetOAuthClient(int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<OAuthClient> localVarResponse = GetOAuthClientWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// Login prerequisite You need to retrieve a client id and secret before [logging in](#operation/getOAuthToken).
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of OAuthClient</returns>
        public PeerTubeApiClient.Client.ApiResponse<OAuthClient> GetOAuthClientWithHttpInfo(int operationIndex = 0)
        {
            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }


            localVarRequestOptions.Operation = "SessionApi.GetOAuthClient";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<OAuthClient>("/api/v1/oauth-clients/local", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetOAuthClient", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Login prerequisite You need to retrieve a client id and secret before [logging in](#operation/getOAuthToken).
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of OAuthClient</returns>
        public async System.Threading.Tasks.Task<OAuthClient> GetOAuthClientAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<OAuthClient> localVarResponse = await GetOAuthClientWithHttpInfoAsync(operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Login prerequisite You need to retrieve a client id and secret before [logging in](#operation/getOAuthToken).
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (OAuthClient)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<OAuthClient>> GetOAuthClientWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }


            localVarRequestOptions.Operation = "SessionApi.GetOAuthClient";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<OAuthClient>("/api/v1/oauth-clients/local", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetOAuthClient", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Login With your [client id and secret](#operation/getOAuthClient), you can retrieve an access and refresh tokens.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"> (optional)</param>
        /// <param name="clientSecret"> (optional)</param>
        /// <param name="grantType"> (optional, default to password)</param>
        /// <param name="username">immutable name of the user, used to find or mention its actor (optional)</param>
        /// <param name="password"> (optional)</param>
        /// <param name="refreshToken"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetOAuthToken200Response</returns>
        public GetOAuthToken200Response GetOAuthToken(string? clientId = default(string?), string? clientSecret = default(string?), string? grantType = default(string?), string? username = default(string?), string? password = default(string?), string? refreshToken = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<GetOAuthToken200Response> localVarResponse = GetOAuthTokenWithHttpInfo(clientId, clientSecret, grantType, username, password, refreshToken);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Login With your [client id and secret](#operation/getOAuthClient), you can retrieve an access and refresh tokens.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"> (optional)</param>
        /// <param name="clientSecret"> (optional)</param>
        /// <param name="grantType"> (optional, default to password)</param>
        /// <param name="username">immutable name of the user, used to find or mention its actor (optional)</param>
        /// <param name="password"> (optional)</param>
        /// <param name="refreshToken"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetOAuthToken200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<GetOAuthToken200Response> GetOAuthTokenWithHttpInfo(string? clientId = default(string?), string? clientSecret = default(string?), string? grantType = default(string?), string? username = default(string?), string? password = default(string?), string? refreshToken = default(string?), int operationIndex = 0)
        {
            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/x-www-form-urlencoded"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (clientId != null)
            {
                localVarRequestOptions.FormParameters.Add("client_id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(clientId)); // form parameter
            }
            if (clientSecret != null)
            {
                localVarRequestOptions.FormParameters.Add("client_secret", PeerTubeApiClient.Client.ClientUtils.ParameterToString(clientSecret)); // form parameter
            }
            if (grantType != null)
            {
                localVarRequestOptions.FormParameters.Add("grant_type", PeerTubeApiClient.Client.ClientUtils.ParameterToString(grantType)); // form parameter
            }
            if (username != null)
            {
                localVarRequestOptions.FormParameters.Add("username", PeerTubeApiClient.Client.ClientUtils.ParameterToString(username)); // form parameter
            }
            if (password != null)
            {
                localVarRequestOptions.FormParameters.Add("password", PeerTubeApiClient.Client.ClientUtils.ParameterToString(password)); // form parameter
            }
            if (refreshToken != null)
            {
                localVarRequestOptions.FormParameters.Add("refresh_token", PeerTubeApiClient.Client.ClientUtils.ParameterToString(refreshToken)); // form parameter
            }

            localVarRequestOptions.Operation = "SessionApi.GetOAuthToken";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<GetOAuthToken200Response>("/api/v1/users/token", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetOAuthToken", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Login With your [client id and secret](#operation/getOAuthClient), you can retrieve an access and refresh tokens.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"> (optional)</param>
        /// <param name="clientSecret"> (optional)</param>
        /// <param name="grantType"> (optional, default to password)</param>
        /// <param name="username">immutable name of the user, used to find or mention its actor (optional)</param>
        /// <param name="password"> (optional)</param>
        /// <param name="refreshToken"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetOAuthToken200Response</returns>
        public async System.Threading.Tasks.Task<GetOAuthToken200Response> GetOAuthTokenAsync(string? clientId = default(string?), string? clientSecret = default(string?), string? grantType = default(string?), string? username = default(string?), string? password = default(string?), string? refreshToken = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<GetOAuthToken200Response> localVarResponse = await GetOAuthTokenWithHttpInfoAsync(clientId, clientSecret, grantType, username, password, refreshToken, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Login With your [client id and secret](#operation/getOAuthClient), you can retrieve an access and refresh tokens.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="clientId"> (optional)</param>
        /// <param name="clientSecret"> (optional)</param>
        /// <param name="grantType"> (optional, default to password)</param>
        /// <param name="username">immutable name of the user, used to find or mention its actor (optional)</param>
        /// <param name="password"> (optional)</param>
        /// <param name="refreshToken"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetOAuthToken200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<GetOAuthToken200Response>> GetOAuthTokenWithHttpInfoAsync(string? clientId = default(string?), string? clientSecret = default(string?), string? grantType = default(string?), string? username = default(string?), string? password = default(string?), string? refreshToken = default(string?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/x-www-form-urlencoded"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (clientId != null)
            {
                localVarRequestOptions.FormParameters.Add("client_id", PeerTubeApiClient.Client.ClientUtils.ParameterToString(clientId)); // form parameter
            }
            if (clientSecret != null)
            {
                localVarRequestOptions.FormParameters.Add("client_secret", PeerTubeApiClient.Client.ClientUtils.ParameterToString(clientSecret)); // form parameter
            }
            if (grantType != null)
            {
                localVarRequestOptions.FormParameters.Add("grant_type", PeerTubeApiClient.Client.ClientUtils.ParameterToString(grantType)); // form parameter
            }
            if (username != null)
            {
                localVarRequestOptions.FormParameters.Add("username", PeerTubeApiClient.Client.ClientUtils.ParameterToString(username)); // form parameter
            }
            if (password != null)
            {
                localVarRequestOptions.FormParameters.Add("password", PeerTubeApiClient.Client.ClientUtils.ParameterToString(password)); // form parameter
            }
            if (refreshToken != null)
            {
                localVarRequestOptions.FormParameters.Add("refresh_token", PeerTubeApiClient.Client.ClientUtils.ParameterToString(refreshToken)); // form parameter
            }

            localVarRequestOptions.Operation = "SessionApi.GetOAuthToken";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<GetOAuthToken200Response>("/api/v1/users/token", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetOAuthToken", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Logout Revokes your access token and its associated refresh token, destroying your current session.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void RevokeOAuthToken(int operationIndex = 0)
        {
            RevokeOAuthTokenWithHttpInfo();
        }

        /// <summary>
        /// Logout Revokes your access token and its associated refresh token, destroying your current session.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> RevokeOAuthTokenWithHttpInfo(int operationIndex = 0)
        {
            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }


            localVarRequestOptions.Operation = "SessionApi.RevokeOAuthToken";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/api/v1/users/revoke-token", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RevokeOAuthToken", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Logout Revokes your access token and its associated refresh token, destroying your current session.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task RevokeOAuthTokenAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await RevokeOAuthTokenWithHttpInfoAsync(operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Logout Revokes your access token and its associated refresh token, destroying your current session.
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> RevokeOAuthTokenWithHttpInfoAsync(int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = PeerTubeApiClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = PeerTubeApiClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }


            localVarRequestOptions.Operation = "SessionApi.RevokeOAuthToken";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (OAuth2) required
            // oauth required
            if (!localVarRequestOptions.HeaderParameters.ContainsKey("Authorization"))
            {
                if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
                {
                    localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
                }
                else if (!string.IsNullOrEmpty(this.Configuration.OAuthTokenUrl) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientId) &&
                         !string.IsNullOrEmpty(this.Configuration.OAuthClientSecret) &&
                         this.Configuration.OAuthFlow != null)
                {
                    localVarRequestOptions.OAuth = true;
                }
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/users/revoke-token", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RevokeOAuthToken", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
