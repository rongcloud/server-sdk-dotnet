using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace io.rong.models {
    public class UserInfo {
        [JsonProperty]
        private String id, name, icon;

        public String getId() {
            return this.id;
        }

        public void setId(String id) {
            this.id = id;
        }

        public String getName() {
            return this.name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public String getIcon() {
            return this.icon;
        }

        public void setIcon(String icon) {
            this.icon = icon;
        }

        public UserInfo(String id, String name, String portraitUri = null) {
            this.id = id;
            this.name = name;
            this.icon = portraitUri;
        }

        public String toString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
