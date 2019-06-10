using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace io.rong.exception
{

    public class ParamException : RcloudException

    {

        private static readonly long serialVersionUID = -5021603276540528761L;

        public ParamException()
        {
            this.error = new ParamError("/");
        }

        public ParamException(String message, Exception e) : base(new ParamError("/", message).ToString(), e)
        {
            this.error = new ParamError("/", message);
        }

        public ParamException(Exception e) : base(e.Message)
        {
            this.error = new ParamError("/");
        }

        public ParamException(String message) : base(message)
        {
            this.error = new ParamError("/", message);
        }

        public ParamException(int errorCode, String apiUrl, String message) : base(new ParamError(errorCode, apiUrl, message).ToString())
        {
            this.error = new ParamError(errorCode, apiUrl, message);

        }
    }
}

