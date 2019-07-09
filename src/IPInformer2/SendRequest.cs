using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace IPInformer2
{
    class SendRequest
    {
        public delegate void OnConnecting(object sender);                
        public event OnConnecting Connecting;        
        
        private HttpWebRequest request = null;
        private WebProxy proxy = null;        
        
        public string URL { get; set; }

        public NetConnectionType ConnectionType { get; set; }
        public string ProxyAddress { get; set; }
        public int ProxyPort { get; set; }
        public string ProxyUser { get; set; }
        public string ProxyPassword { get; set; }        
        public int ConnectionTimeout { get; set; }

        public string ErrorMessage { get; private set; }

        public bool RequestError { get; private set; }
        public bool NetworkError { get; private set; }
        public bool ProtocolError { get; private set; }

        public SendRequest(string url)
        {
            URL = url;            
        }

        public bool CreateRequest()
        {
            //устанавливаем минимальные параметры для запроса
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(URL);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                RequestError = true;
                return false;
            }

            switch (ConnectionType)
            {
                case NetConnectionType.NoProxy:
                    {
                        proxy = null;
                        HttpWebRequest.DefaultWebProxy = null;
                        request.Proxy = proxy;
                    }; break;

                case NetConnectionType.SystemProxy:
                    {
                        HttpWebRequest.DefaultWebProxy = HttpWebRequest.GetSystemWebProxy();
                        proxy = null;
                    }; break;
                case NetConnectionType.ManualProxy:
                    {
                        proxy = new WebProxy(ProxyAddress, ProxyPort);
                        if (!string.IsNullOrEmpty(ProxyUser)) //есть имя пользователя, надобно авторизоваться
                        {
                            CredentialCache cred = new CredentialCache();
                            cred.Add(ProxyAddress, ProxyPort, "Basic",
                                new NetworkCredential(ProxyUser, ProxyPassword));

                            proxy.Credentials = cred;
                        }

                        request.Proxy = proxy;
                    }; break;
            }


            if (ConnectionTimeout > 0) request.Timeout = ConnectionTimeout;            

            return true;
        }
        
        public string Send()
        {
            RequestError = false;
            NetworkError = false;
            ProtocolError = false;

            if (Connecting != null) Connecting(this);
         
            //получаем ответ
            HttpWebResponse resp = null;
            string Answer = "";
            try
            {
                resp = (HttpWebResponse)request.GetResponse();
                //не вывалились в ошибку, значит все OK

                Stream temp = resp.GetResponseStream(); 
                StreamReader sr = new StreamReader(temp);                
                Answer = sr.ReadToEnd();
                temp.Close();
                sr.Close();                
                
            }
            catch (WebException ex)
            {
                ErrorMessage = ex.Message;

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    //ошибка протокола (404, например)
                    //интернет может и есть

                    ProtocolError = true;
                    return null;
                }
                else //какая-то другая ошибка
                {
                    NetworkError = true;
                    return null;
                }
            }

            return Answer;
        }                
    }
}
