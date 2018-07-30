using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace ShoppingMe.Controllers
{
    public class BaseApiController : ApiController
    {
        protected string mediaTypeFormatter = string.Empty;
        public BaseApiController()
        {
            mediaTypeFormatter = Convert.ToString("Json");
        }

        protected IHttpActionResult GetResult<T>(T data, HttpStatusCode httpStatusCode, Dictionary<string, string> headers = null)
        {
            MediaTypeFormatter mediaType = new JsonMediaTypeFormatter();

            if (mediaTypeFormatter.ToLower().Equals("Xml"))
            {
                mediaType = new XmlMediaTypeFormatter();
            }

            switch (httpStatusCode)
            {
                case HttpStatusCode.OK:
                    return GetHttpResponseMessage<T>(data, HttpStatusCode.OK, mediaType, headers);
                case HttpStatusCode.NotFound:
                    return GetHttpResponseMessage<T>(data, HttpStatusCode.NotFound, mediaType, headers);
                case HttpStatusCode.BadRequest:
                    return GetHttpResponseMessage<T>(data, HttpStatusCode.BadRequest, mediaType, headers);
                case HttpStatusCode.InternalServerError:
                    return GetHttpResponseMessage<T>(data, HttpStatusCode.InternalServerError, mediaType, headers);
                case HttpStatusCode.Unauthorized:
                    return GetHttpResponseMessage<T>(data, HttpStatusCode.Unauthorized, mediaType, headers);
                default:
                    return GetHttpResponseMessage<T>(data, HttpStatusCode.OK, mediaType, headers);
            }
        }

        private IHttpActionResult GetHttpResponseMessage<T>(T data, HttpStatusCode httpStatusCode, MediaTypeFormatter mediaTypeFormatter, Dictionary<string, string> headers)
        {
            var response = ResponseMessage(new HttpResponseMessage()
            {
                Content = new ObjectContent<T>(data, mediaTypeFormatter),
                StatusCode = httpStatusCode,
            });

            if (headers != null && headers.Count >= 0)
            {
                foreach (var header in headers)
                {
                    response.Response.Headers.Add(header.Key, header.Value);
                }
            }

            return response;
        }
    }
}
