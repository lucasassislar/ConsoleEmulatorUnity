using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleEmulatorUnity {
    public class EmulatorTextWriter : TextWriter {
        public override void Write(char value) {
        }

        public override void Write(string value) {
            ConsoleU.WriteLine(value);
        }

        public override Encoding Encoding {
            get {
                return Encoding.ASCII;
            }
        }
    }
}
