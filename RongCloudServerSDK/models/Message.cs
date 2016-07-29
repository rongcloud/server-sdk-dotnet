using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace io.rong.models {
    public abstract class Message {
        protected String type;
        [JsonProperty]
        protected UserInfo userInfo;
        public String getType() {
            return type;
        }

        public UserInfo getUser() {
            return this.userInfo;
        }

        public void setUser(UserInfo userInfo) {
            this.userInfo = userInfo;
        }

        public abstract String toString();
    }
}
