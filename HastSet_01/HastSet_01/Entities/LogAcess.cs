using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    class LogAcess
    {
        public string Name { get; set; }
        public DateTime Instant { get; set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if(!(obj is LogAcess))
            {
                return false;
            }
            LogAcess other = obj as LogAcess;
            return Name.Equals(other.Name);
        }
    }
}
