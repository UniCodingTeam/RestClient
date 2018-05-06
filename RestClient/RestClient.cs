using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public enum authenticationType
    {
        None,
        Basic,
        NTLM,
        Token,
    }

    public enum authenicationTechnique
    {
        None,
        RollYourOwn,
        NetworkCredential,
        Token
    }

    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public authenicationTechnique authTech { get; set; }
        public authenticationType authType { get; set; }
        public string userName {get; set;}
        public string userPassword { get; set; }
        public string token { get; set; }
        public HttpWebRequest requestData { get; set; }

        public RestClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
        }

        public string makeRequest()
        {

            string strResponseValue = string.Empty;

            HttpWebResponse response = null;
            

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

                if (authTech == authenicationTechnique.Token)
                {
                    String authHeader = token;
                    request.Headers.Add("Authorization", "Bearer " + token);
                }
                else if (authTech == authenicationTechnique.RollYourOwn)
                {
                    


                    using (var wb = new WebClient())
                    {

                        String authHeader = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("Admin:pass"));
                        wb.Headers.Add("Authorization", "Basic " + authHeader);
                        var data = new NameValueCollection();
                        data["username"] = "myUser";
                        data["password"] = "myPassword";

                        var responses = wb.UploadValues(endPoint, "POST", data);
                        string responseInString = Encoding.UTF8.GetString(responses);
                        return responseInString;
                    }

                }
                else if (authTech == authenicationTechnique.NetworkCredential)
                {
                    NetworkCredential netCred = new NetworkCredential(userName, userPassword);
                    request.Credentials = netCred;
                }

                requestData = request;

                request.Method = httpMethod.ToString();
                

                response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code: " + response.StatusCode);
                }
                // Process the reponse stream
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        } // End of StreamReader
                    }
                } // End of using ResponseStream
            } catch (Exception ex)
            {
                strResponseValue = "{\"errorMessage\":[\"}" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

                return strResponseValue;
        }
    }
}
