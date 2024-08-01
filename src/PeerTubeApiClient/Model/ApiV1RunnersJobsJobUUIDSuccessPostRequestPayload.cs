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
using System.Reflection;

namespace PeerTubeApiClient.Model
{
    /// <summary>
    /// ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload
    /// </summary>
    [JsonConverter(typeof(ApiV1RunnersJobsJobUUIDSuccessPostRequestPayloadJsonConverter))]
    [DataContract(Name = "_api_v1_runners_jobs__jobUUID__success_post_request_payload")]
    public partial class ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload : AbstractOpenAPISchema, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload" /> class
        /// with the <see cref="VODWebVideoTranscoding" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of VODWebVideoTranscoding.</param>
        public ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload(VODWebVideoTranscoding actualInstance)
        {
            IsNullable = false;
            SchemaType= "anyOf";
            ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload" /> class
        /// with the <see cref="VODHLSTranscoding" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of VODHLSTranscoding.</param>
        public ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload(VODHLSTranscoding actualInstance)
        {
            IsNullable = false;
            SchemaType= "anyOf";
            ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload" /> class
        /// with the <see cref="VODAudioMergeTranscoding" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of VODAudioMergeTranscoding.</param>
        public ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload(VODAudioMergeTranscoding actualInstance)
        {
            IsNullable = false;
            SchemaType= "anyOf";
            ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload" /> class
        /// with the <see cref="Object" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of Object.</param>
        public ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload(Object actualInstance)
        {
            IsNullable = false;
            SchemaType= "anyOf";
            ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }


        private Object _actualInstance;

        /// <summary>
        /// Gets or Sets ActualInstance
        /// </summary>
        public override Object ActualInstance
        {
            get
            {
                return _actualInstance;
            }
            set
            {
                if (value.GetType() == typeof(Object))
                {
                    _actualInstance = value;
                }
                else if (value.GetType() == typeof(VODAudioMergeTranscoding))
                {
                    _actualInstance = value;
                }
                else if (value.GetType() == typeof(VODHLSTranscoding))
                {
                    _actualInstance = value;
                }
                else if (value.GetType() == typeof(VODWebVideoTranscoding))
                {
                    _actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: Object, VODAudioMergeTranscoding, VODHLSTranscoding, VODWebVideoTranscoding");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `VODWebVideoTranscoding`. If the actual instance is not `VODWebVideoTranscoding`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of VODWebVideoTranscoding</returns>
        public VODWebVideoTranscoding GetVODWebVideoTranscoding()
        {
            return (VODWebVideoTranscoding)ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `VODHLSTranscoding`. If the actual instance is not `VODHLSTranscoding`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of VODHLSTranscoding</returns>
        public VODHLSTranscoding GetVODHLSTranscoding()
        {
            return (VODHLSTranscoding)ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `VODAudioMergeTranscoding`. If the actual instance is not `VODAudioMergeTranscoding`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of VODAudioMergeTranscoding</returns>
        public VODAudioMergeTranscoding GetVODAudioMergeTranscoding()
        {
            return (VODAudioMergeTranscoding)ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `Object`. If the actual instance is not `Object`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of Object</returns>
        public Object GetObject()
        {
            return (Object)ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload {\n");
            sb.Append("  ActualInstance: ").Append(ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(ActualInstance, ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload</returns>
        public static ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload FromJson(string jsonString)
        {
            ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload newApiV1RunnersJobsJobUUIDSuccessPostRequestPayload = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newApiV1RunnersJobsJobUUIDSuccessPostRequestPayload;
            }

            try
            {
                newApiV1RunnersJobsJobUUIDSuccessPostRequestPayload = new ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload(JsonConvert.DeserializeObject<Object>(jsonString, ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newApiV1RunnersJobsJobUUIDSuccessPostRequestPayload;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into Object: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newApiV1RunnersJobsJobUUIDSuccessPostRequestPayload = new ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload(JsonConvert.DeserializeObject<VODAudioMergeTranscoding>(jsonString, ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newApiV1RunnersJobsJobUUIDSuccessPostRequestPayload;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into VODAudioMergeTranscoding: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newApiV1RunnersJobsJobUUIDSuccessPostRequestPayload = new ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload(JsonConvert.DeserializeObject<VODHLSTranscoding>(jsonString, ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newApiV1RunnersJobsJobUUIDSuccessPostRequestPayload;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into VODHLSTranscoding: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newApiV1RunnersJobsJobUUIDSuccessPostRequestPayload = new ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload(JsonConvert.DeserializeObject<VODWebVideoTranscoding>(jsonString, ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newApiV1RunnersJobsJobUUIDSuccessPostRequestPayload;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into VODWebVideoTranscoding: {1}", jsonString, exception.ToString()));
            }

            // no match found, throw an exception
            throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

    /// <summary>
    /// Custom JSON converter for ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload
    /// </summary>
    public class ApiV1RunnersJobsJobUUIDSuccessPostRequestPayloadJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload).GetMethod("ToJson").Invoke(value, null)));
        }

        /// <summary>
        /// To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">Object type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">JSON Serializer</param>
        /// <returns>The object converted from the JSON string</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch(reader.TokenType) 
            {
                case JsonToken.StartObject:
                    return ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload.FromJson(JObject.Load(reader).ToString(Formatting.None));
                case JsonToken.StartArray:
                    return ApiV1RunnersJobsJobUUIDSuccessPostRequestPayload.FromJson(JArray.Load(reader).ToString(Formatting.None));
                default:
                    return null;
            }
        }

        /// <summary>
        /// Check if the object can be converted
        /// </summary>
        /// <param name="objectType">Object type</param>
        /// <returns>True if the object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

}
