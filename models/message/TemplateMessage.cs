using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.message
{
    public class TemplateMessage
    {
        /**
         * 发送人Id
         * */
        private String senderId;
        /**
         * 消息类型
         * */
        private String objectName;
        /**
         * 发送消息内容，内容中定义模版，标识通过 content 中的标识位内容进行替换，
         * 参考融云消息类型表.示例说明；如果 objectName 为自定义消息类型，该参数可自定义格式。（必传）
         * */
        private Object template;
        /**
         * key 用户Id ,value 模板赋值内容
         *
         * */
        private Dictionary<String, ContentData> content;

        private String[] pushData;

        private int verifyBlacklist;

        private int contentAvailable;

        public string SenderId { get => senderId; set => senderId = value; }
        public string ObjectName { get => objectName; set => objectName = value; }
        public object Template { get => template; set => template = value; }
        public Dictionary<string, ContentData> Content { get => content; set => content = value; }
        public string[] PushData { get => pushData; set => pushData = value; }
        public int VerifyBlacklist { get => verifyBlacklist; set => verifyBlacklist = value; }
        public int ContentAvailable { get => contentAvailable; set => contentAvailable = value; }
    }

    public class ContentData
    {
        /**
         * 消息内容数据，key对应模版的标识 ，value具体内容
         */
        private Dictionary<String, String> data;
        /**
         * push内容
         */
        private String push;

        public string Push { get => push; set => push = value; }
        public Dictionary<string, string> Data { get => data; set => data = value; }
    }
}
