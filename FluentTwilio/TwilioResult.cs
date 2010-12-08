using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentTwilio
{
    public class TwilioResult : GenricTwilio<TwilioResult>
    {
        
        public TwilioResult(Action<TwilioResult> param)
        {
            xmlResponse = new StringBuilder("<Response>");
            param.Invoke(this);
            xmlResponse.Append("</Response>");
        }

        public TwilioResult Gather(Action<GatherResult> action)
        {
            xmlResponse.Append("<Gather>");
            var gatherResult = new GatherResult(action, ref xmlResponse);
            xmlResponse.Append("</Gather>");
            return this;
        }

        public TwilioResult Gather(string url, Action<TwilioResult> action)
        {
            xmlResponse.Append(string.Format("<Gather action=\"{0}\">", url));
            action.Invoke(this);
            xmlResponse.Append("</Gather>");
            return this;
        }

        public TwilioResult Gather(string actionUrl, HttpMethod? method, int? timeOut, int? numDigits, char? finishOnKey, Action<TwilioResult> action)
        {
            xmlResponse.Append("<Gather");

            if (!String.IsNullOrEmpty(actionUrl))
                xmlResponse.Append(string.Format(" action=\"{0}\"", actionUrl));

            if (method.HasValue)
                xmlResponse.Append(string.Format(" method=\"{0}\"", method));

            if (timeOut.HasValue)
                xmlResponse.Append(string.Format(" timeout=\"{0}\"", timeOut));

            if (numDigits.HasValue)
                xmlResponse.Append(string.Format(" numDigits=\"{0}\"", numDigits));

            if (finishOnKey.HasValue)
                xmlResponse.Append(string.Format(" finishOnKey=\"{0}\"", finishOnKey));

            xmlResponse.Append(">");


            action.Invoke(this);
            xmlResponse.Append("</Gather>");
            return this;
        }

        public TwilioResult Gather(string actionUrl, HttpMethod? method, Action<TwilioResult> action)
        {
            xmlResponse.Append("<Gather");

            if (!String.IsNullOrEmpty(actionUrl))
                xmlResponse.Append(string.Format(" action=\"{0}\"", actionUrl));

            if (method.HasValue)
                xmlResponse.Append(string.Format(" method=\"{0}\"", method));

            xmlResponse.Append(">");

            action.Invoke(this);
            xmlResponse.Append("</Gather>");
            return this;
        }

        public TwilioResult Redirect(string url)
        {
            xmlResponse.Append(string.Format("<Redirect>{0}</Redirect>", url));
            return this;
        }

        public string Render()
        {
            return xmlResponse.ToString();
        }

        public TwilioResult Dial(string phonenumber)
        {
            xmlResponse.Append(string.Format("<Dial>{0}</Dial>", phonenumber));
            return this;
        }
    }
}
