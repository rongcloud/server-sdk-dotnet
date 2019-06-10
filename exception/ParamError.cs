using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace io.rong.exception
{
    class ParamError : Error
    {
        public ParamError(int errorCode, String apiURL, String errorMessage) : base(errorCode, errorCode, apiURL, errorMessage)
        {
        }

        public ParamError(int errorCode, int httpCode, String apiURL,
                String errorMessage) : base(errorCode, httpCode, apiURL, errorMessage)
        {

        }

        public ParamError(String apiURL) : base(1002, 400, apiURL, "缺少参数，请检查。")
        {
        }

        public ParamError(String apiURL, String message) : base(1002, 400, apiURL, message)
        {
        }
    }
}
