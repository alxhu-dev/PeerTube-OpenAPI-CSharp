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
    public interface IUserImportsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Get latest user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetLatestUserImport200Response</returns>
        GetLatestUserImport200Response GetLatestUserImport(int userId, int operationIndex = 0);

        /// <summary>
        /// Get latest user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetLatestUserImport200Response</returns>
        ApiResponse<GetLatestUserImport200Response> GetLatestUserImportWithHttpInfo(int userId, int operationIndex = 0);
        /// <summary>
        /// Send chunk for the resumable user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the import of the archive
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void UserImportResumable(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0);

        /// <summary>
        /// Send chunk for the resumable user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the import of the archive
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UserImportResumableWithHttpInfo(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0);
        /// <summary>
        /// Cancel the resumable user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the resumable user import
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void UserImportResumableCancel(string uploadId, decimal contentLength, int operationIndex = 0);

        /// <summary>
        /// Cancel the resumable user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the resumable user import
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UserImportResumableCancelWithHttpInfo(string uploadId, decimal contentLength, int operationIndex = 0);
        /// <summary>
        /// Initialize the resumable user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the import of the archive
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="userImportResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void UserImportResumableInit(decimal xUploadContentLength, string xUploadContentType, UserImportResumable? userImportResumable = default(UserImportResumable?), int operationIndex = 0);

        /// <summary>
        /// Initialize the resumable user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the import of the archive
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="userImportResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UserImportResumableInitWithHttpInfo(decimal xUploadContentLength, string xUploadContentType, UserImportResumable? userImportResumable = default(UserImportResumable?), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IUserImportsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Get latest user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetLatestUserImport200Response</returns>
        System.Threading.Tasks.Task<GetLatestUserImport200Response> GetLatestUserImportAsync(int userId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get latest user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1**
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetLatestUserImport200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetLatestUserImport200Response>> GetLatestUserImportWithHttpInfoAsync(int userId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Send chunk for the resumable user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the import of the archive
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UserImportResumableAsync(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Send chunk for the resumable user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the import of the archive
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> UserImportResumableWithHttpInfoAsync(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Cancel the resumable user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the resumable user import
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UserImportResumableCancelAsync(string uploadId, decimal contentLength, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Cancel the resumable user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the resumable user import
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> UserImportResumableCancelWithHttpInfoAsync(string uploadId, decimal contentLength, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Initialize the resumable user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the import of the archive
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="userImportResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UserImportResumableInitAsync(decimal xUploadContentLength, string xUploadContentType, UserImportResumable? userImportResumable = default(UserImportResumable?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Initialize the resumable user import
        /// </summary>
        /// <remarks>
        /// **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the import of the archive
        /// </remarks>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="userImportResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> UserImportResumableInitWithHttpInfoAsync(decimal xUploadContentLength, string xUploadContentType, UserImportResumable? userImportResumable = default(UserImportResumable?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IUserImportsApi : IUserImportsApiSync, IUserImportsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class UserImportsApi : IUserImportsApi
    {
        private PeerTubeApiClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserImportsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UserImportsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserImportsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UserImportsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="UserImportsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public UserImportsApi(PeerTubeApiClient.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="UserImportsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public UserImportsApi(PeerTubeApiClient.Client.ISynchronousClient client, PeerTubeApiClient.Client.IAsynchronousClient asyncClient, PeerTubeApiClient.Client.IReadableConfiguration configuration)
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
        /// Get latest user import **PeerTube &gt;&#x3D; 6.1**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GetLatestUserImport200Response</returns>
        public GetLatestUserImport200Response GetLatestUserImport(int userId, int operationIndex = 0)
        {
            PeerTubeApiClient.Client.ApiResponse<GetLatestUserImport200Response> localVarResponse = GetLatestUserImportWithHttpInfo(userId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get latest user import **PeerTube &gt;&#x3D; 6.1**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GetLatestUserImport200Response</returns>
        public PeerTubeApiClient.Client.ApiResponse<GetLatestUserImport200Response> GetLatestUserImportWithHttpInfo(int userId, int operationIndex = 0)
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

            localVarRequestOptions.PathParameters.Add("userId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(userId)); // path parameter

            localVarRequestOptions.Operation = "UserImportsApi.GetLatestUserImport";
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
            var localVarResponse = this.Client.Get<GetLatestUserImport200Response>("/api/v1/users/{userId}/imports/latest", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLatestUserImport", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get latest user import **PeerTube &gt;&#x3D; 6.1**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GetLatestUserImport200Response</returns>
        public async System.Threading.Tasks.Task<GetLatestUserImport200Response> GetLatestUserImportAsync(int userId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            PeerTubeApiClient.Client.ApiResponse<GetLatestUserImport200Response> localVarResponse = await GetLatestUserImportWithHttpInfoAsync(userId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get latest user import **PeerTube &gt;&#x3D; 6.1**
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="userId">User id</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GetLatestUserImport200Response)</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<GetLatestUserImport200Response>> GetLatestUserImportWithHttpInfoAsync(int userId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("userId", PeerTubeApiClient.Client.ClientUtils.ParameterToString(userId)); // path parameter

            localVarRequestOptions.Operation = "UserImportsApi.GetLatestUserImport";
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
            var localVarResponse = await this.AsynchronousClient.GetAsync<GetLatestUserImport200Response>("/api/v1/users/{userId}/imports/latest", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLatestUserImport", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Send chunk for the resumable user import **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the import of the archive
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void UserImportResumable(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0)
        {
            UserImportResumableWithHttpInfo(uploadId, contentRange, contentLength, body);
        }

        /// <summary>
        /// Send chunk for the resumable user import **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the import of the archive
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> UserImportResumableWithHttpInfo(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0)
        {
            // verify the required parameter 'uploadId' is set
            if (uploadId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'uploadId' when calling UserImportsApi->UserImportResumable");
            }

            // verify the required parameter 'contentRange' is set
            if (contentRange == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'contentRange' when calling UserImportsApi->UserImportResumable");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/octet-stream"
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "upload_id", uploadId));
            localVarRequestOptions.HeaderParameters.Add("Content-Range", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentRange)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentLength)); // header parameter
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "UserImportsApi.UserImportResumable";
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
            var localVarResponse = this.Client.Put<Object>("/api/v1/users/{userId}/imports/import-resumable", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserImportResumable", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Send chunk for the resumable user import **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the import of the archive
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UserImportResumableAsync(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UserImportResumableWithHttpInfoAsync(uploadId, contentRange, contentLength, body, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Send chunk for the resumable user import **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to continue, pause or resume the import of the archive
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentRange">Specifies the bytes in the file that the request is uploading.  For example, a value of &#x60;bytes 0-262143/1000000&#x60; shows that the request is sending the first 262144 bytes (256 x 1024) in a 2,469,036 byte file. </param>
        /// <param name="contentLength">Size of the chunk that the request is sending.  Remember that larger chunks are more efficient. PeerTube&#39;s web client uses chunks varying from 1048576 bytes (~1MB) and increases or reduces size depending on connection health. </param>
        /// <param name="body"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> UserImportResumableWithHttpInfoAsync(string uploadId, string contentRange, decimal contentLength, System.IO.Stream? body = default(System.IO.Stream?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'uploadId' is set
            if (uploadId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'uploadId' when calling UserImportsApi->UserImportResumable");
            }

            // verify the required parameter 'contentRange' is set
            if (contentRange == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'contentRange' when calling UserImportsApi->UserImportResumable");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/octet-stream"
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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "upload_id", uploadId));
            localVarRequestOptions.HeaderParameters.Add("Content-Range", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentRange)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentLength)); // header parameter
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "UserImportsApi.UserImportResumable";
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
            var localVarResponse = await this.AsynchronousClient.PutAsync<Object>("/api/v1/users/{userId}/imports/import-resumable", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserImportResumable", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel the resumable user import **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the resumable user import
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void UserImportResumableCancel(string uploadId, decimal contentLength, int operationIndex = 0)
        {
            UserImportResumableCancelWithHttpInfo(uploadId, contentLength);
        }

        /// <summary>
        /// Cancel the resumable user import **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the resumable user import
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> UserImportResumableCancelWithHttpInfo(string uploadId, decimal contentLength, int operationIndex = 0)
        {
            // verify the required parameter 'uploadId' is set
            if (uploadId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'uploadId' when calling UserImportsApi->UserImportResumableCancel");
            }

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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "upload_id", uploadId));
            localVarRequestOptions.HeaderParameters.Add("Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentLength)); // header parameter

            localVarRequestOptions.Operation = "UserImportsApi.UserImportResumableCancel";
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
            var localVarResponse = this.Client.Delete<Object>("/api/v1/users/{userId}/imports/import-resumable", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserImportResumableCancel", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancel the resumable user import **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the resumable user import
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UserImportResumableCancelAsync(string uploadId, decimal contentLength, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UserImportResumableCancelWithHttpInfoAsync(uploadId, contentLength, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancel the resumable user import **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to cancel the resumable user import
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="uploadId">Created session id to proceed with. If you didn&#39;t send chunks in the last hour, it is not valid anymore and you need to initialize a new upload. </param>
        /// <param name="contentLength"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> UserImportResumableCancelWithHttpInfoAsync(string uploadId, decimal contentLength, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'uploadId' is set
            if (uploadId == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'uploadId' when calling UserImportsApi->UserImportResumableCancel");
            }


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

            localVarRequestOptions.QueryParameters.Add(PeerTubeApiClient.Client.ClientUtils.ParameterToMultiMap("", "upload_id", uploadId));
            localVarRequestOptions.HeaderParameters.Add("Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(contentLength)); // header parameter

            localVarRequestOptions.Operation = "UserImportsApi.UserImportResumableCancel";
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
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/api/v1/users/{userId}/imports/import-resumable", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserImportResumableCancel", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Initialize the resumable user import **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the import of the archive
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="userImportResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void UserImportResumableInit(decimal xUploadContentLength, string xUploadContentType, UserImportResumable? userImportResumable = default(UserImportResumable?), int operationIndex = 0)
        {
            UserImportResumableInitWithHttpInfo(xUploadContentLength, xUploadContentType, userImportResumable);
        }

        /// <summary>
        /// Initialize the resumable user import **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the import of the archive
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="userImportResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public PeerTubeApiClient.Client.ApiResponse<Object> UserImportResumableInitWithHttpInfo(decimal xUploadContentLength, string xUploadContentType, UserImportResumable? userImportResumable = default(UserImportResumable?), int operationIndex = 0)
        {
            // verify the required parameter 'xUploadContentType' is set
            if (xUploadContentType == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'xUploadContentType' when calling UserImportsApi->UserImportResumableInit");
            }

            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
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

            localVarRequestOptions.HeaderParameters.Add("X-Upload-Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xUploadContentLength)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("X-Upload-Content-Type", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xUploadContentType)); // header parameter
            localVarRequestOptions.Data = userImportResumable;

            localVarRequestOptions.Operation = "UserImportsApi.UserImportResumableInit";
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
            var localVarResponse = this.Client.Post<Object>("/api/v1/users/{userId}/imports/import-resumable", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserImportResumableInit", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Initialize the resumable user import **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the import of the archive
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="userImportResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UserImportResumableInitAsync(decimal xUploadContentLength, string xUploadContentType, UserImportResumable? userImportResumable = default(UserImportResumable?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UserImportResumableInitWithHttpInfoAsync(xUploadContentLength, xUploadContentType, userImportResumable, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Initialize the resumable user import **PeerTube &gt;&#x3D; 6.1** Uses [a resumable protocol](https://github.com/kukhariev/node-uploadx/blob/master/proto.md) to initialize the import of the archive
        /// </summary>
        /// <exception cref="PeerTubeApiClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xUploadContentLength">Number of bytes that will be uploaded in subsequent requests. Set this value to the size of the file you are uploading.</param>
        /// <param name="xUploadContentType">MIME type of the file that you are uploading. Depending on your instance settings, acceptable values might vary.</param>
        /// <param name="userImportResumable"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<PeerTubeApiClient.Client.ApiResponse<Object>> UserImportResumableInitWithHttpInfoAsync(decimal xUploadContentLength, string xUploadContentType, UserImportResumable? userImportResumable = default(UserImportResumable?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'xUploadContentType' is set
            if (xUploadContentType == null)
            {
                throw new PeerTubeApiClient.Client.ApiException(400, "Missing required parameter 'xUploadContentType' when calling UserImportsApi->UserImportResumableInit");
            }


            PeerTubeApiClient.Client.RequestOptions localVarRequestOptions = new PeerTubeApiClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
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

            localVarRequestOptions.HeaderParameters.Add("X-Upload-Content-Length", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xUploadContentLength)); // header parameter
            localVarRequestOptions.HeaderParameters.Add("X-Upload-Content-Type", PeerTubeApiClient.Client.ClientUtils.ParameterToString(xUploadContentType)); // header parameter
            localVarRequestOptions.Data = userImportResumable;

            localVarRequestOptions.Operation = "UserImportsApi.UserImportResumableInit";
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
            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/api/v1/users/{userId}/imports/import-resumable", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UserImportResumableInit", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
