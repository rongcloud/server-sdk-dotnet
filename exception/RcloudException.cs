using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace io.rong.exception
{

    public abstract class RcloudException : Exception
    {
        /**
         *
         */
        private static readonly long serialVersionUID = -700374663662873165L;
        protected Error error = null;
        public RcloudException()
        {
        }

        public RcloudException(String message, Exception e) : base(message, e)
        {
        }

        public RcloudException(Exception e) : base(e.Message)
        {
        }

        public RcloudException(String message) : base(message)
        {
        }

        public Error GetError()
        {
            return error;
        }

        public int GetErrorCode()
        {
            if (error == null)
            {
                return 200;
            }
            return error.Code;
        }

        public int GetHttpCode()
        {
            if (error == null)
            {
                return 200;
            }
            return error.HttpCode;
        }

        public void SetUri(String uri)
        {
            if (error == null)
            {
                return;
            }
            error.Url = uri;
        }
    }
}

