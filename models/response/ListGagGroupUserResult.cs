using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    class ListGagGroupUserResult : Result
    {
        // 群组被禁言用户列表。
        List<GagGroupUser> members;

        public ListGagGroupUserResult(int code, String msg, List<GagGroupUser> members) : base(code, msg)
        {
            this.members = members;
        }

        public ListGagGroupUserResult(List<GagGroupUser> members)
        {
            this.members = members;
        }

        public ListGagGroupUserResult()
        {
        }



        /**
         * 获取members
         *
         * @return List
         */
        public List<GagGroupUser> getMembers()
        {
            return this.members;
        }

        /**
         * 设置members
         *
         */
        public void setMembers(List<GagGroupUser> members)
        {
            this.members = members;
        }

        override
    public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        }
    }
}
