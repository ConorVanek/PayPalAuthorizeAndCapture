using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Core;
using PayPalHttp;

using System.IO;
using System.Runtime.Serialization.Json;

namespace paypal_capture
{
    public class PayPalClient
    {

        public static PayPalEnvironment environment()
        {
            /**

           Set up PayPal environment with sandbox credentials.
           In production, use LiveEnvironment.

        */
            
            string clientID = "CLIENT_ID_HERE";
            string secret = "SECRET_HERE";
            return new SandboxEnvironment(clientID, secret); // For sandbox environment
            //return new LiveEnvironment(clientID, secret); For live environment

        }
        // Returns PayPalHttpClient instance to invoke PayPal APIs.
        public static HttpClient client()
        {
            return new PayPalHttpClient(environment());
        }
        public static HttpClient client(string refreshToken)
        {
            return new PayPalHttpClient(environment(), refreshToken);
        }

        // Use this method to serialize object to JSON string.
        public static String ObjectToJSONString(Object serializableObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            var writer = JsonReaderWriterFactory.CreateJsonWriter(
                        memoryStream, Encoding.UTF8, true, true, "  ");
            DataContractJsonSerializer ser = new DataContractJsonSerializer(serializableObject.GetType(), new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
            ser.WriteObject(writer, serializableObject);
            memoryStream.Position = 0;
            StreamReader sr = new StreamReader(memoryStream);
            return sr.ReadToEnd();
        }
    }
}
