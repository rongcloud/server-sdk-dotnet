using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace io.rong.models.push
{
    public class UserModel

    {
        /**
    * 用户 Id，最大长度 64 字节.是用户在 App 中的唯一标识码，
    * 必须保证在同一个 App 内不重复，重复的用户 Id 将被当作是同一用户。（必传）
    */
        public String id;
        /**
         * 用户名称，最大长度 128 字节。用来在 Push 推送时，显示用户的名称，
         * 刷新用户名称后 5 分钟内生效。（可选，提供即刷新，不提供忽略）
         */
        public String name;
        /**
         * 用户头像 URI，最大长度 1024 字节。
         * 用来在 Push 推送时显示。（可选，提供即刷新，不提供忽略)
         */
        public String portrait;

        public int minute;
        /**
         * 黑名单列表。
         */
        public UserModel[] blacklist;


        public UserModel()
        {
        }

        public UserModel(String id, String name, String portrait)
        {
            this.id = id;
            this.name = name;
            this.portrait = portrait;
        }

        [JsonIgnore]
        public String Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public String GetId()
        {
            return this.id;
        }

        public UserModel SetId(String id)
        {
            this.id = id;
            return this;
        }

        [JsonIgnore]
        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public String GetName()
        {
            return this.name;
        }

        public UserModel SetName(String name)
        {
            this.name = name;
            return this;
        }

        [JsonIgnore]
        public String Portrait
        {
            get { return this.portrait; }
            set { this.portrait = value; }
        }

        public String GetPortrait()
        {
            return this.portrait;
        }

        public UserModel SetPortrait(String portrait)
        {
            this.portrait = portrait;
            return this;
        }

        [JsonIgnore]
        public int Minute
        {
            get { return this.minute; }
            set { this.minute = value; }
        }

        public int GetMinute()
        {
            return this.minute;
        }

        public UserModel SetMinute(int minute)
        {
            this.minute = minute;
            return this;
        }

        [JsonIgnore]
        public UserModel[] Blacklist
        {
            get { return this.blacklist; }
            set { this.blacklist = value; }
        }

        public UserModel[] GetBlacklist()
        {
            return this.blacklist;
        }

        public UserModel SetBlacklist(UserModel[] blacklist)
        {
            this.blacklist = blacklist;
            return this;
        }

        override
        public String ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
