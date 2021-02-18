using System;
using System.IO;
using System.Net;
using System.Collections.Generic;

namespace Lab._1
{
    class Program
    {
        private static void RunServer(HttpListener server)
        {
            //var file = new FileStream("../logs.txt", FileMode.OpenOrCreate);
            var file = new StreamWriter("../../../log.txt", true);
            var strToWriteInFile = "Listening...\n";
            file.WriteLine(strToWriteInFile);
            //            Console.WriteLine(strToWriteInFile);

            while (server.IsListening)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = server.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                // Construct a response.
                string responseString = "";//"<html><body>here should be ERROR</body></html>";
                switch (request.RawUrl)
                {
                    case "/image":
                        responseString = new StreamReader("../../../src/index_image.html").ReadToEnd();
                        break;
                    case "/exit":
                        strToWriteInFile = "" + DateTime.Now.ToString() + "\t" + request.RemoteEndPoint.Address.ToString() + "\t" + request.Url + "\t" + response.StatusCode;
                        file.WriteLine(strToWriteInFile);
                        //                       Console.WriteLine(strToWriteInFile);
                        file.Close();
                        return;
                    case "/favicon.ico":
                        continue;
                    case "/":
                        responseString = new StreamReader("../../../src/index.html").ReadToEnd();
                        break;
                }
                if (responseString == "")
                {
                    response.StatusCode = 404;
                    response.StatusDescription = "ERROR";
                }

                strToWriteInFile = "" + DateTime.Now.ToString() + "\t" + request.RemoteEndPoint.Address.ToString() + "\t" + request.Url + "\t" + response.StatusCode;
                file.WriteLine(strToWriteInFile);
                //                Console.WriteLine(strToWriteInFile);

                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
            }

            file.Write(strToWriteInFile);
            Console.WriteLine(strToWriteInFile);
            file.Close();
        }

        static void Main()
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Something went wrong.");
                return;
            }

            // Create a listener.
            HttpListener listener = new HttpListener();
            // Add the prefixes. 

            foreach (string s in new List<string>() { "http://localhost:8080/" })
            {
                listener.Prefixes.Add(s);
            }

            listener.Start();
            RunServer(listener);


            // You must close the output stream.
            //output.Close();
            listener.Stop();
        }
    }
}
