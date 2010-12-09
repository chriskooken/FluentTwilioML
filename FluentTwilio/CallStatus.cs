using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FluentTwilio
{
    public enum CallStatus
    {
        QUEUED, RINGING, INPROCESS, COMPLETED, BUSY, FAILED, NOANSWER, CANCELED
    }
}
