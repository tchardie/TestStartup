using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UnitTestProject1.Utils
{
    public class HttpContextMock : HttpContextBase
    {
        private HttpSessionStateBase sessionState;
        private HttpRequestBase requestBase;

        public override HttpSessionStateBase Session
        {
            get
            {
                if (sessionState == null)
                {
                    sessionState = new HttpSessionStateMock();
                }

                return sessionState;
            }
        }

        public override HttpRequestBase Request
        {
            get
            {
                if (requestBase == null)
                {
                    requestBase = new HttpRequestMock();
                }

                return requestBase;
            }
        }
    }

    public class HttpSessionStateMock : HttpSessionStateBase
    {
        private Dictionary<string, object> session;

        public HttpSessionStateMock()
        {
            session = new Dictionary<string, object>();
        }

        public override object this[string name]
        {
            get
            {
                if(session == null)
                {
                    session = new Dictionary<string, object>();
                }

                return session[name];
            }
            set
            {
                if(session == null)
                {
                    session = new Dictionary<string, object>();
                }

                session[name] = value;
            }
        }
    }

    public class HttpRequestMock : HttpRequestBase
    {
        public override string UserHostAddress => "UserBaseAddress";
    }
}
