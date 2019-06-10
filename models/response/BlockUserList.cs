using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.response
{
    class BlockUserList
    {
        /**
         * 返回码，200 为正常。
         *
         */
        private int code;
        /**
         * 黑名单用户列表
         */
        private String[] users;


        public BlockUserList(int code, String[] users)
        {
            this.code = code;
            this.users = users;
        }

        public String[] getUsers()
        {
            return this.users;
        }

        public void setUsers(String[] users)
        {
            this.users = users;
        }

        public int getCode()
        {
            return this.code;
        }

        public void setCode(int code)
        {
            this.code = code;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
