using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.group
{
    /**
     * 群组数据模型
     *
     * */
     class GroupModel
    {
        /**
         * 群组id
         **/
        private String id;
        /**
         * 群组成员
         **/
        private GroupMember[] members;
        /**
         * 群组名
         **/
        private String name;

        /**
         * 禁言时间
         * */
        private int minute;

        public GroupModel()
        {
        }
        /**
         * 构造方法
         *
         * @param id 群组id
         * @param members 群组成员
         * @param name 群名
         */
        public GroupModel(String id, GroupMember[] members, String name, int minute)
        {
            this.id = id;
            this.members = members;
            this.name = name;
            this.minute = minute;
        }

        public int Minute { get => minute; set => minute = value; }
        public string Id { get => id; set => id = value; }
        public GroupMember[] Members { get => members; set => members = value; }
        public string Name { get => name; set => name = value; }

    }
}
