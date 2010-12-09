using System.Web.Mvc;

namespace FluentTwilio
{
    public static class TwilioExtentions
    {
        public static TwilioRequestParams TwilioRequestParams(this Controller controller)
        {
            return new TwilioRequestParams(controller.HttpContext.Request.Params);
        }
    }
}