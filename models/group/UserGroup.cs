using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.models.group
{
    public class UserGroup

    {

        private String id;
        private GroupModel[] groups;

        public string Id { get => id; set => id = value; }
        public GroupModel[] Groups { get => groups; set => groups = value; }

        public UserGroup()
        {
        }

        public UserGroup(String id, GroupModel[] groups)
        {
            this.id = id;
            this.groups = groups;
        }

        public String getId()
        {
            return this.id;
        }

        public UserGroup setId(String id)
        {
            this.id = id;
            return this;
        }

        public GroupModel[] getGroups()
        {
            return this.groups;
        }

        public UserGroup setGroups(GroupModel[] groups)
        {
            this.groups = groups;
            return this;
        }
    }
}
