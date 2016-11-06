using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RavenDB.AspNetCore.Identity
{
    public class ConfirmationOccurrence : Occurrence
    {
        public ConfirmationOccurrence() : base()
        {
        }

        public ConfirmationOccurrence(DateTime confirmedOn) : base(confirmedOn)
        {
        }
    }
}
