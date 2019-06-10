using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace io.rong.models.push
{
    /**
     * 设备中的推送内容。（非必传）
     */
    public class PlatformNotification
    {

        /**
         * 默认推送消息内容，如填写了 iOS 或 Android 下的 alert 时，则推送内容以对应平台系统的 alert 为准。（必传）
         */
        [JsonProperty(PropertyName = "alert")]
        private String alert;

        /**
         * 通知栏显示的推送标题，仅针对 iOS 平台，支持 iOS 8.2 及以上版本，参数在 ios 节点下设置，详细可参考“设置 iOS
         * 推送标题请求示例”。（非必传）
         */
        [JsonProperty(PropertyName = "title")]
        private String title;

        /**
         * 针对 iOS 平台，对 SDK 处于后台暂停状态时为静默推送，是 iOS7 之后推出的一种推送方式。
         * 允许应用在收到通知后在后台运行一段代码，且能够马上执行，查看详细。1 表示为开启，0 表示为关闭，默认为 0（非必传）
         */
        [JsonProperty(PropertyName = "contentAvailable")]
        private int contentAvailable;

        /**
         * iOS 或 Android 不同平台下的附加信息，如果开发者自己需要，可以自己在 App 端进行解析。（非必传）
         */
        [JsonProperty(PropertyName = "extras")]
        private Dictionary<String, String> extras;

        /**
         * 应用角标，仅针对 iOS 平台；不填时，表示不改变角标数；为 0 或负数时，表示 App
         * 角标上的数字清零；否则传相应数字表示把角标数改为指定的数字，最大不超过 9999，参数在 ios 节点下设置，详细可参考“设置 iOS 角标数 HTTP
         * 请求示例”。（非必传）
         */
        [JsonProperty(PropertyName = "badge")]
        private int badge;

        /**
         * iOS 富文本推送的类型开发者自已定义，自已在 App 端进行解析判断，与 richMediaUri 一起使用。（非必传）
         */
        [JsonProperty(PropertyName = "category")]
        private String category;

        /**
         * iOS 富文本推送内容的 URL，与 category 一起使用。（非必传）
         */
        [JsonProperty(PropertyName = "richMediaUri")]
        private String richMediaUri;

        public String GetAlert()
        {
            return alert;
        }

        public void SetAlert(String alert)
        {
            this.alert = alert;
        }

        public String GetTitle()
        {
            return title;
        }

        public void SetTitle(String title)
        {
            this.title = title;
        }

        public int GetContentAvailable()
        {
            return contentAvailable;
        }

        public void SetContentAvailable(int contentAvailable)
        {
            this.contentAvailable = contentAvailable;
        }

        public Dictionary<String, String> GetExtras()
        {
            return extras;
        }

        public void SetExtras(Dictionary<String, String> extras)
        {
            this.extras = extras;
        }

        public int GetBadge()
        {
            return badge;
        }

        public void SetBadge(int badge)
        {
            this.badge = badge;
        }

        public String GetCategory()
        {
            return category;
        }

        public void SetCategory(String category)
        {
            this.category = category;
        }

        public String GetRichMediaUri()
        {
            return richMediaUri;
        }

        public void SetRichMediaUri(String richMediaUri)
        {
            this.richMediaUri = richMediaUri;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
