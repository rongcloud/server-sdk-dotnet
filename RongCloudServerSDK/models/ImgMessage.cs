using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace io.rong.models {
    class ImgMessage : Message {
        [JsonProperty]
        private String content, imageUri, extra;

        public String getContent() {
            return content;
        }

        public void setContent(String content) {
            this.content = content;
        }

        public String getImageUri() {
            return this.imageUri;
        }

        public void setImageUri(String uri) {
            this.imageUri = uri;
        }

        public String getExtra() {
            return extra;
        }

        public void setExtra(String extra) {
            this.extra = extra;
        }

        public ImgMessage(String content, String imageUri) {
            this.type = "RC:ImgMsg";
            this.imageUri = imageUri;
            this.content = content;
        }

        public ImgMessage(String content, String imageUri, String extra) : this(content, imageUri) {
            this.extra = extra;
        }

        public override string toString() {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this);
        }
    }
}
