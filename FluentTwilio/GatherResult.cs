using System;
using System.Text;

namespace FluentTwilio
{
    public class GatherResult : GenricTwilio<GatherResult>
    {
        public GatherResult(Action<GatherResult> action, ref StringBuilder xmlResponse)
        {
            this.xmlResponse = xmlResponse;
            action.Invoke(this);
        }



    }
}