using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace io.rong.models {
    class ContactNtfMessage : Message {
        [JsonProperty]
        private String operation, sourceUserId, targetUserId, message, extra;

        public String getOperation() {
            return operation;
        }

        public void setOperation(String operation) {
            this.operation = operation;
        }

        public String getSourceUserId() {
            return sourceUserId;
        }

        public void setSourceUserId(String sourceUserId) {
            this.sourceUserId = sourceUserId;
        }

        public String TargetUserId() {
            return targetUserId;
        }

        public void setTargetUserId(String targetUserId) {
            this.targetUserId = targetUserId;
        }

        public String getMessage() {
            return message;
        }

        public void setMessage(String message) {
            this.message = message;
        }

        public String getExtra() {
            return extra;
        }

        public void setExtra(String extra) {
            this.extra = extra;
        }

        public ContactNtfMessage(String operation, String sourceUserId, String targetUserId, String message) {
            this.type = "RC:ContactNtf";
            this.operation = operation;
            this.sourceUserId = sourceUserId;
            this.targetUserId = targetUserId;
            this.message = message;
        }

        public ContactNtfMessage(String operation, String sourceUserId, String targetUserId, String message, String extra)
            : this(operation, sourceUserId, targetUserId, message) {
            this.extra = extra;
        }

        public override string toString() {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this);
        }
    }
}
