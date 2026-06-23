using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Resources;
using io.rong.models.response;
using io.rong.models.push;

namespace io.rong.util
{
    public class CommonUtil

    {
        public static String VERIFY_JSON_NAME = "/verify.json";
        public static String API_JSON_NAME = "/api.json";
        public static String CHRARCTER = "UTF-8";

        public static bool ValidateParams(Object paramObj, int length)
        {
            try
            {
                if (null == paramObj)
                {
                    return false;
                }
                if (paramObj.GetType() == typeof(String[]))
                {
                    String[] param = (String[])paramObj;
                    int len = param.Length;
                    if (len <= length)
                    {
                        return true;
                    }
                }
                else if (paramObj.GetType() == typeof(String))
                {
                    String param = (String)paramObj;
                    int len = param.Length;
                    if (len <= length)
                    {
                        return true;
                    }
                }
                else if (paramObj.GetType() == typeof(int))
                {
                    int param = (int)paramObj;
                    if (param <= length)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("长度校验错误" + e.Message);
            }
            return false;
        }

        /**
         * 从文件读取 json 对象
         * 
         * @param path  文件路径
         * 
         * @return Jobj
         **/
        private static JObject FromPath(String path)
        {
            var assembly = typeof(CommonUtil).GetTypeInfo().Assembly;
            using (var stream = assembly.GetManifestResourceStream("ServerSDK.jsonsource." + path.Replace("/", ".")))
            {
                using (var reader = new StreamReader(stream))
                {
                    JObject jObject = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                    return jObject;
                }
            }
        }

        private static List<String> GetKeys(JToken jToken)
        {
            Dictionary<string, Object> dictObj = jToken.ToObject<Dictionary<string, Object>>();

            return dictObj.Keys.ToList<String>();
        }

        private static Dictionary<String, Dictionary<String, String>> GetMessages(JToken jToken)
        {
            Dictionary<string, Dictionary<String, String>> dictObj = jToken.ToObject<Dictionary<string, Dictionary<String, String>>>();
            Dictionary<String, Dictionary<String, String>> messageSet = new Dictionary<string, Dictionary<String, String>>();
            foreach (var item in dictObj)
            {
                Dictionary<String, String> msg = new Dictionary<string, string>();
                foreach (var dict in item.Value)
                {
                    msg.Add(dict.Key, dict.Value);
                }
                messageSet.Add(item.Key, msg);
            }

            return messageSet;
        }

        /**
         * 参数校验方法
         *
         * @param model  校验对象
         * @param path   路径
         * @param method 需要校验方法
         *
         * @return String
         **/
        public static String CheckFiled(Object model, String path, String method)
        {
            try
            {
                String code = "200";
                int max = 64;
                //api.json 的路径
                String apiPath = path;
                String type = "";
                if (path.Contains("/"))
                {
                    path = path.Substring(0, path.IndexOf("/"));
                }
                String[] fileds = { };
                String checkObjectKey = "";
                //获取需要校验的参数
                Dictionary<String, String[]> checkInfo = GetCheckInfo(apiPath, method);
                foreach (var item in checkInfo)
                {
                    checkObjectKey = item.Key;
                    fileds = item.Value;
                }

                //获取校验文件
                JObject verify = FromPath(path + VERIFY_JSON_NAME);

                //获取校验key
                List<String> keys = GetKeys(verify.GetValue(checkObjectKey));
                //获取具体校验规则

                JObject entity = (JObject)verify.GetValue(checkObjectKey);
                //Dictionary<String, Object> entity = verify.GetValue(checkObjectKey).ToObject<Dictionary<String, Object>>();
                foreach (String name in fileds)
                {
                    foreach (String key in keys)
                    {
                        if (name.Equals(key))
                        {
                            //将属性的首字符大写，方便构造get，set方法
                            String nameTemp = name.Substring(0, 1).ToUpper() + name.Substring(1);
                            //获取属性的类型
                            //String type = field.getGenericType().ToString();

                            MethodInfo m = model.GetType().GetMethod("Get" + nameTemp);
                            PropertyInfo propertyInfo = model.GetType().GetProperty(nameTemp);
                            //.GetValue(model, null)

                            //获取字段的具体校验规则
                            JObject obj = (JObject)entity.GetValue(name);
                            if (obj.GetValue("require") != null)
                            {
                                Boolean must = (Boolean)((JObject)obj.GetValue("require")).GetValue("must");
                                Object result = null;
                                if (null != m)
                                {
                                    result = m.Invoke(model, new Object[] { });
                                }
                                else
                                {
                                    result = propertyInfo.GetValue(model, null);
                                }

                                if (result != null && result.GetType() == typeof(String))
                                {
                                    String value = (String)result;
                                    if (String.IsNullOrEmpty(value))
                                    {
                                        code = (String)((JObject)obj.GetValue("require")).GetValue("invalid");
                                    }
                                }
                                else
                                {
                                    Object value = result;
                                    if (null == value)
                                    {
                                        code = (String)((JObject)obj.GetValue("require")).GetValue("invalid");
                                    }
                                }
                            }
                            if (obj.GetValue("length") != null)
                            {
                                max = (int)((JObject)obj.GetValue("length")).GetValue("max");
                                Object result = null;
                                if (null != m)
                                {
                                    result = m.Invoke(model, new Object[] { });
                                }
                                else
                                {
                                    result = propertyInfo.GetValue(model, null);
                                }
                                if (null != result && result.GetType() == typeof(String))
                                {
                                    String value = (String)result;
                                    if ("200".Equals(code) && String.IsNullOrEmpty(value))
                                    {
                                        code = (String)((JObject)obj.GetValue("length")).GetValue("invalid");
                                    }
                                    if ("200".Equals(code) && value.Length > max)
                                    {
                                        code = (String)((JObject)obj.GetValue("length")).GetValue("invalid");
                                    }
                                }
                                else if (null != result && result.GetType() == typeof(String[]))
                                {
                                    String[] value = (String[])result;
                                    if ("200".Equals(code) && value.Length > max)
                                    {
                                        code = (String)((JObject)obj.GetValue("length")).GetValue("invalid");
                                    }
                                }

                            }
                            if (obj.GetValue("size") != null)
                            {
                                max = (int)((JObject)obj.GetValue("size")).GetValue("max");
                                type = (String)((JObject)obj.GetValue("typeof")).GetValue("type");
                                if (type.Contains("array"))
                                {
                                    Object[] value = null;
                                    if (null != m)
                                    {
                                        value = (Object[])m.Invoke(model, new Object[] { });
                                    }
                                    else
                                    {
                                        value = (Object[])propertyInfo.GetValue(model, null);
                                    }
                                    if ("200".Equals(code) && null == value)
                                    {
                                        code = (String)((JObject)obj.GetValue("size")).GetValue("invalid");
                                    }
                                    if ("200".Equals(code) && value.Length > max)
                                    {
                                        code = (String)((JObject)obj.GetValue("size")).GetValue("invalid");
                                    }

                                }
                                else if (type.Contains("int"))
                                {
                                    int value = 0;
                                    try
                                    {
                                        if (null != m)
                                        {
                                            value = (int)m.Invoke(model, new Object[] { });
                                        }
                                        else
                                        {
                                            value = (int)propertyInfo.GetValue(model, null);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        code = (String)((JObject)obj.GetValue("typeof")).GetValue("invalid");
                                    }

                                    if ("200".Equals(code) && 0 == value)
                                    {
                                        code = (String)((JObject)obj.GetValue("size")).GetValue("invalid");
                                    }
                                    if ("200".Equals(code) && value > max)
                                    {
                                        code = (String)((JObject)obj.GetValue("size")).GetValue("invalid");
                                    }

                                }
                            }
                            if (!"200".Equals(code))
                            {
                                //根据错误码获取错误信息
                                String message = (String)CommonUtil.GetErrorMessage(apiPath, method, code, name, max.ToString(), "1", type);
                                //对 errorMessage  替换
                                message = message.Replace("errorMessage", "msg");
                                return message;
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            return null;
        }

        /**
         * 获取校验信息
         *
         * @param path   路径 （获取校验文件路径）
         * @param method 校验方法（需要校验的方法）
         *
         * @return Map
         **/
        public static Dictionary<String, String[]> GetCheckInfo(String path, String method)
        {
            JObject api = null;
            try
            {
                api = FromPath(path + API_JSON_NAME);
                List<String> keys = GetKeys(((JObject)api.GetValue(method)).GetValue("params"));
                //ISet<String> keys = api.GetValue(method).GetValue("params").keySet();
                String key = keys[0];
                if (String.IsNullOrEmpty(key))
                {
                    return null;
                }
                List<String> subkeys;

                JToken obj = ((JObject)((JObject)api.GetValue(method)).GetValue("params")).GetValue(key);

                if (null != obj)
                {
                    subkeys = GetKeys(obj);
                }
                else
                {
                    subkeys = keys;
                }
                Dictionary<String, String[]> map = new Dictionary<String, String[]>
                    {
                        { key, subkeys.ToArray() }
                    };
                return map;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }


        /**
         * 获取错误信息
         *
         * @param path   路径 （获取校验文件路径）
         * @param method 校验方法（需要校验的方法）
         * @param errorCode 错误码
         * @param name  具体字段名
         * @param max   字段需要的最大值
         * @param min   字段的最小值
         * @param type  类型
         *
         * @return Map
         **/
        public static Object GetErrorMessage(String path, String method, String errorCode, String name, String max, String min, String type)
        {
            JObject api = null;
            try
            {
                api = FromPath(path + API_JSON_NAME);
                Dictionary<String, Dictionary<String, String>> messages = GetMessages(((JObject)((JObject)api.GetValue(method)).GetValue("response")).GetValue("fail"));
                String[] searchList = { "{{name}}", "{{max}}", "{{name}}", "{{min}}", "{{currentType}}" };
                String[] replaceList = { name, max, name, min, type };
                foreach (var item in messages)
                {
                    if (errorCode.Equals(item.Key))
                    {
                        String text = JsonConvert.SerializeObject(item.Value);
                        //StringUtils.replaceEach(text,serchList,replaceList);
                        for (int i = 0; i < searchList.Length; i++)
                        {
                            text = text.Replace(searchList[i], replaceList[i]);
                        }

                        return text;
                    }
                }
            }
            catch (IOException e)
            {
                throw e;
            }
            return null;
        }

        /**
         * 参数校验
         *
         * @param checkFiled 需要校验的字段
         * @param value  传入参数值
         * @param path   路径 （获取校验文件路径）
         * @param method 需要校验方法
         *
         * @return String
         **/
        public static String CheckParam(String checkFiled, Object value, String path, String method)
        {
            try
            {
                String code = "200";
                bool flag = false;
                int max = 64;
                String type = "";
                String apiPath = path;
                if (path.Contains("/"))
                {
                    path = path.Substring(0, path.IndexOf("/"));
                }
                //String[] fileds = {};
                String checkObject = "";
                //获取需要校验的key
                Dictionary<String, String[]> checkInfo = GetCheckInfo(apiPath, method);
                foreach (var item in checkInfo)
                {
                    //fileds = entry.getValue();
                    checkObject = item.Key;
                }
                JToken verify = FromPath(path + VERIFY_JSON_NAME);
                List<String> keys = GetKeys(((JObject)verify).GetValue(checkObject));
                JObject entity = (JObject)((JObject)verify).GetValue(checkObject);
                foreach (String key in keys)
                {
                    if (checkFiled.Equals(key))
                    {
                        JObject obj = (JObject)entity.GetValue(checkFiled);
                        if (obj.GetValue("require") != null)
                        {
                            Boolean must = (Boolean)((JObject)obj.GetValue("require")).GetValue("must");
                            if (value.GetType() == typeof(String))
                            {
                                if (String.IsNullOrEmpty(value.ToString()))
                                {
                                    code = (String)((JObject)obj.GetValue("require")).GetValue("invalid");
                                }

                            }
                            else
                            {
                                if (null == value)
                                {
                                    code = (String)((JObject)obj.GetValue("require")).GetValue("invalid");
                                }
                            }
                        }
                        if (obj.GetValue("length") != null)
                        {
                            max = (int)((JObject)obj.GetValue("length")).GetValue("max");
                            if (value.GetType() == typeof(String))
                            {
                                if ("200".Equals(code) && String.IsNullOrEmpty(value.ToString()))
                                {
                                    code = (String)((JObject)obj.GetValue("length")).GetValue("invalid");
                                }
                                if ("200".Equals(code) && value.ToString().Length > max)
                                {
                                    code = (String)((JObject)(JObject)obj.GetValue("length")).GetValue("invalid");
                                }
                            }
                            else if (value.GetType() == typeof(String[]))
                            {
                                String[] valueTemp = { };
                                try
                                {
                                    valueTemp = (String[])value;
                                }
                                catch (Exception e)
                                {
                                    code = (String)((JObject)obj.GetValue("typeof")).GetValue("invalid");
                                }
                                if ("200".Equals(code) && valueTemp.Length > max)
                                {
                                    code = (String)((JObject)obj.GetValue("length")).GetValue("invalid");
                                }
                            }

                        }
                        if (obj.GetValue("size") != null)
                        {
                            max = (int)((JObject)obj.GetValue("size")).GetValue("max");
                            type = (String)((JObject)obj.GetValue("typeof")).GetValue("type");
                            if (type.Contains("array"))
                            {
                                String[] valueTemp = null;
                                if ("200".Equals(code) && null == value)
                                {
                                    code = (String)((JObject)obj.GetValue("size")).GetValue("invalid");
                                }
                                try
                                {
                                    valueTemp = (String[])value;
                                }
                                catch (Exception e)
                                {
                                    code = (String)((JObject)obj.GetValue("typeof")).GetValue("invalid");
                                }

                                if ("200".Equals(code) && valueTemp.Length > max)
                                {
                                    code = (String)((JObject)obj.GetValue("size")).GetValue("invalid");
                                }

                            }
                            else if (type.Contains("int"))
                            {
                                int valueTemp = 64;
                                try
                                {
                                    valueTemp = (int)value;
                                }
                                catch (Exception e)
                                {
                                    code = (String)((JObject)obj.GetValue("typeof")).GetValue("invalid");
                                }
                                if ("200".Equals(code) && null == value)
                                {
                                    code = (String)((JObject)obj.GetValue("size")).GetValue("invalid");
                                }
                                if ("200".Equals(code) && valueTemp > max)
                                {
                                    code = (String)((JObject)obj.GetValue("size")).GetValue("invalid");
                                }

                            }
                        }
                        String message = (String)CommonUtil.GetErrorMessage(apiPath, method, code, checkFiled, max.ToString(), "1", type);
                        if (null != message)
                        {
                            message = message.Replace("errorMessage", "msg");
                            return message;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            return null;
        }

        /**
         * 获取response信息
         *
         * @param path   路径 （获取校验文件路径）
         * @param method 校验方法（需要校验的方法）
         * @param response 返回信息
         *
         * @return String
         **/
        public static String GetResponseByCode(String path, String method, String response)
        {
            JObject api = null;
            try
            {
                JObject obj = (JObject)JToken.Parse(response);
                String code = obj.GetValue("code").ToString();
                api = FromPath(path + API_JSON_NAME);
                Dictionary<String, Dictionary<String, String>> messages = GetMessages(((JObject)((JObject)api.GetValue(method)).GetValue("response")).GetValue("fail"));
                String text = response;
                if (code.Equals("200"))
                {
                    if (path.Contains("blacklist") && method.Equals("getList"))
                    {

                        UserList userList = JsonConvert.DeserializeObject<UserList>(response);
                        List<UserModel> users = new List<UserModel>();
                        foreach (String id in userList.getUsers())
                        {
                            UserModel tmpUser = new UserModel
                            {
                                Id = id
                            };
                            users.Add(tmpUser);
                        }
                        UserModel[] members = users.ToArray();

                        BlackListResult blacklist = new BlackListResult(userList.getCode(), null, members);

                        text = blacklist.ToString();

                    }
                    else if (path.Contains("whitelist/user") && method.Equals("getList"))
                    {

                        UserList userList = JsonConvert.DeserializeObject<UserList>(response);
                        //User[] members = {};
                        List<UserModel> users = new List<UserModel>();
                        foreach (String id in userList.getUsers())
                        {
                            users.Add(new UserModel() { Id = id });
                        }
                        UserModel[] members = users.ToArray();
                        WhiteListResult whitelist = new WhiteListResult(userList.getCode(), null, members);

                        text = whitelist.ToString();

                    }
                    else if (path.Contains("chatroom") || path.Contains("group"))
                    {
                        text = response.Replace("users", "members");
                        if (text.Contains("whitlistMsgType"))
                        {
                            text = text.Replace("whitlistMsgType", "objNames");
                        }
                        if (path.Contains("gag") || path.Contains("block"))
                        {
                            text = text.Replace("userId", "id");
                        }
                    }
                    else if (path.Contains("user"))
                    {
                        if (path.Contains("block") || path.Contains("blacklist"))
                        {
                            text = response.Replace("userId", "id");
                        }
                    }
                    else if (path.Contains("sensitiveword"))
                    {
                        text = response.Replace("word", "keyword");
                        if (text.Contains("keywords"))
                        {
                            text = text.Replace("keywords", "words");
                        }
                        text = text.Replace("replaceWord", "replace");

                    }
                    else
                    {
                        text = response;
                    }
                    return text;
                }
                else
                {
                    foreach (var item in messages)
                    {
                        if (code.Equals(item.Key))
                        {
                            text = JsonConvert.SerializeObject(item.Value);
                            //text = StringUtils.replace(text,"msg","errorMessage");
                            text = text.Replace("errorMessage", "msg");

                            return text;
                        }
                    }
                    text = response.Replace("errorMessage", "msg");
                    if (path.Contains("chatroom"))
                    {
                        text = text.Replace("users", "members");
                        //对于 聊天室保活成功返回的code是0 更改统一返回200
                        if (path.Contains("keepalive") && "0".Equals(code))
                        {
                            text = text.Replace("chatroomIds", "chatrooms");
                            text = text.Replace("0", "200");

                        }
                    }
                    return text;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("-------------" + e.Message);
            }
            return response;
        }
        static void Main(string[] args)
        {
            UserModel user = new UserModel("user_id", "user_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_nameuser_name", "url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url_url");
            String msg = CommonUtil.CheckFiled(user, "user", "register");
            Console.WriteLine(msg);
            Console.ReadLine();
        }
    }
}
