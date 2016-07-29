using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace io.rong.models {
    public class FormatType : Message {
        private int _value;

        public int value {
            get {
                return this._value;
            }
        }

        private String _name;
        
        public String name {
            get {
                return this._name;
            }
        }

        private FormatType(String name, int value) {
            this._value = value;
            this._name = name;
        }

        public static readonly FormatType json = new FormatType("json", 0);
        public static readonly FormatType xml = new FormatType("xml", 1);

        public override string toString() {
            return this.name;
        }
    }
}
