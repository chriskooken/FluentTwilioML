using System;
using System.Text;
using System.Web.Mvc;

namespace FluentTwilio
{
    public class GatherResult : GenricTwilio<GatherResult>
    {
        public GatherResult(Action<GatherResult> action, ref StringBuilder xmlResponse)
        {
            this.xmlResponse = xmlResponse;
            action.Invoke(this);
        }

        public override void ExecuteResult(ControllerContext context)
        {
            //noop
        }

    }
}