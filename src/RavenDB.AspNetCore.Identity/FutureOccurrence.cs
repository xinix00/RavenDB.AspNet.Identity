using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RavenDB.AspNetCore.Identity
{
    public class FutureOccurrence : Occurrence
    {
        public FutureOccurrence() : base()
        {
        }

        public FutureOccurrence(DateTime willOccurOn) : base(willOccurOn)
        {
        }
    }
}
