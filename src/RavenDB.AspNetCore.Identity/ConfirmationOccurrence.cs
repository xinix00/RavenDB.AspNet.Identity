using System;

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
