using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace POCAcademicSystemUI.Providers
{
    public class HttpRequesterProvider : IDisposable
    {
        private readonly string _baseUrl;
        private readonly string _contentType;

        public HttpRequesterProvider(string baseUrl, string contentType)
        {
            _baseUrl = baseUrl;
            _contentType = contentType;
        }

        public void Dispose()
        {
            //TODO: implement dispose
        }

        public HttpResponseMessage Request(string stringUri, HttpMethod method, string content = null)
        {
            HttpResponseMessage response;

            var request = new HttpRequestMessage() {RequestUri = new Uri(_baseUrl + stringUri)};

            if (!string.IsNullOrWhiteSpace(content))
            {
                request.Content = new StringContent(content);
            }

            if (string.IsNullOrWhiteSpace(_contentType))
            {
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            request.Method = method;

            using (var client = new HttpClient() {Timeout = TimeSpan.FromSeconds(300)})
            {
                response = client.SendAsync(request).Result;
            }

            return response;
        }
    }
}