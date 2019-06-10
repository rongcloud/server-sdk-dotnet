using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace io.rong.util
{
    public class HostType

    {
        private String type;
        
        public HostType(String type)
        {
            this.type = type;
        }

        public String Type
        {
            get { return this.type; }
        }
    }
}
