using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

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

        public TwilioResult Gather(string url, Action<GatherResult> action)
        {
            xmlResponse.Append(string.Format("<Gather action=\"{0}\">", url));
            var gatherResult = new GatherResult(action, ref xmlResponse);
            xmlResponse.Append("</Gather>");
            return this;
        }

        public TwilioResult Gather(string actionUrl, HttpMethod? method, int? timeOut, int? numDigits, char? finishOnKey, Action<GatherResult> action)
        {
            xmlResponse.Append("<Gather");
            if (!String.IsNullOrEmpty(actionUrl))xmlResponse.Append(string.Format(" action=\"{0}\"", actionUrl));
            if (method.HasValue)xmlResponse.Append(string.Format(" method=\"{0}\"", method));
            if (timeOut.HasValue)xmlResponse.Append(string.Format(" timeout=\"{0}\"", timeOut));
            if (numDigits.HasValue)xmlResponse.Append(string.Format(" numDigits=\"{0}\"", numDigits));
            if (finishOnKey.HasValue)xmlResponse.Append(string.Format(" finishOnKey=\"{0}\"", finishOnKey));
            xmlResponse.Append(">");
            
            var gatherResult = new GatherResult(action, ref xmlResponse);
            xmlResponse.Append("</Gather>");
            return this;
        }

        public TwilioResult Gather(string actionUrl, HttpMethod? method, Action<TwilioResult> action)
        {
            xmlResponse.Append("<Gather");
            if (!String.IsNullOrEmpty(actionUrl))xmlResponse.Append(string.Format(" action=\"{0}\"", actionUrl));
            if (method.HasValue)xmlResponse.Append(string.Format(" method=\"{0}\"", method));
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

        public TwilioResult Redirect(string url, HttpMethod? method)
        {
            xmlResponse.Append(string.Format("<Redirect"));
            if (method.HasValue) xmlResponse.Append(string.Format(" method=\"{0}\"", method));
            xmlResponse.Append(string.Format(">{0}</Redirect>", url));
            return this;
        }

        public string Render()
        {
            return xmlResponse.ToString();
        }
        
        public TwilioResult Record()
        {
            xmlResponse.Append(string.Format("<Record/>"));
            return this;
        }

        public TwilioResult Record(string actionUrl, HttpMethod? method)
        {
            xmlResponse.Append("<Record");
            if (!String.IsNullOrEmpty(actionUrl))xmlResponse.Append(string.Format(" action=\"{0}\"", actionUrl));
            if (method.HasValue)xmlResponse.Append(string.Format(" method=\"{0}\"", method));
            xmlResponse.Append("/>");
            return this;
        }

        public TwilioResult Record(string actionUrl, HttpMethod? method, int? maxLength, string finishOnKey, int? timeOut, 
            bool? transcribe, string transcribeCallbackUrl, bool? playBeep)
        {
            xmlResponse.Append("<Record");

            if (!String.IsNullOrEmpty(actionUrl)) xmlResponse.Append(string.Format(" action=\"{0}\"", actionUrl));
            if (method.HasValue) xmlResponse.Append(string.Format(" method=\"{0}\"", method));
            if (maxLength.HasValue) xmlResponse.Append(string.Format(" maxLength=\"{0}\"", maxLength));
            if (!String.IsNullOrEmpty(finishOnKey)) xmlResponse.Append(string.Format(" finishOnKey=\"{0}\"", finishOnKey));
            if (timeOut.HasValue) xmlResponse.Append(string.Format(" timeout=\"{0}\"", timeOut));
            if (transcribe.HasValue) xmlResponse.Append(string.Format(" transcribe=\"{0}\"", transcribe.ToString().ToLower()));
            if (!String.IsNullOrEmpty(transcribeCallbackUrl)) xmlResponse.Append(string.Format(" transcribeCallback=\"{0}\"", transcribeCallbackUrl));
            if (playBeep.HasValue) xmlResponse.Append(string.Format(" playBeep=\"{0}\"", transcribe.ToString().ToLower()));

            xmlResponse.Append("/>");
            return this;
        }

        public TwilioResult SMS(string messageText)
        {
            xmlResponse.Append(string.Format("<Sms>{0}</Sms>", messageText));
            return this;
        }

        public TwilioResult SMS(string messageText, string actionUrl, HttpMethod? method)
        {
            xmlResponse.Append(string.Format("<Sms"));
            if (!String.IsNullOrEmpty(actionUrl)) xmlResponse.Append(string.Format(" action=\"{0}\"", actionUrl));
            if (method.HasValue) xmlResponse.Append(string.Format(" method=\"{0}\"", method));
            xmlResponse.Append(string.Format(">{0}</Sms>",messageText));

            return this;
        }

        public TwilioResult SMS(string messageText, string actionUrl, HttpMethod? method, string to, string from, string statusCallbackUrl)
        {
            xmlResponse.Append(string.Format("<Sms"));
            if (!String.IsNullOrEmpty(actionUrl)) xmlResponse.Append(string.Format(" action=\"{0}\"", actionUrl));
            if (method.HasValue) xmlResponse.Append(string.Format(" method=\"{0}\"", method));
            if (!String.IsNullOrEmpty(to)) xmlResponse.Append(string.Format(" to=\"{0}\"", to));
            if (!String.IsNullOrEmpty(from)) xmlResponse.Append(string.Format(" from=\"{0}\"", from));
            if (!String.IsNullOrEmpty(statusCallbackUrl)) xmlResponse.Append(string.Format(" statusCallback=\"{0}\"", statusCallbackUrl));

            xmlResponse.Append(string.Format(">{0}</Sms>", messageText));

            return this;
        }

        public TwilioResult Dial(string phonenumber)
        {
            xmlResponse.Append(string.Format("<Dial>{0}</Dial>", phonenumber));
            return this;
        }

        public TwilioResult Dial(string phonenumber, string actionUrl, HttpMethod? method)
        {
            xmlResponse.Append(string.Format("<Dial"));
            if (!String.IsNullOrEmpty(actionUrl)) xmlResponse.Append(string.Format(" action=\"{0}\"", actionUrl));
            if (method.HasValue) xmlResponse.Append(string.Format(" method=\"{0}\"", method));
            xmlResponse.Append(string.Format(">{0}</Dial>", phonenumber));
            return this;
        }

        public TwilioResult Dial(string phonenumber, string actionUrl, HttpMethod? method, int? timeout, bool? hangupOnStar, 
            int? timeLimit, string callerId)
        {
            xmlResponse.Append(string.Format("<Dial"));
            if (!String.IsNullOrEmpty(actionUrl)) xmlResponse.Append(string.Format(" action=\"{0}\"", actionUrl));
            if (method.HasValue) xmlResponse.Append(string.Format(" method=\"{0}\"", method));
            if (timeout.HasValue) xmlResponse.Append(string.Format(" timeout=\"{0}\"", timeout));
            if (hangupOnStar.HasValue) xmlResponse.Append(string.Format(" hangupOnStar=\"{0}\"", hangupOnStar.ToString().ToLower()));
            if (timeLimit.HasValue) xmlResponse.Append(string.Format(" timeLimit=\"{0}\"", timeLimit));
            if (!String.IsNullOrEmpty(callerId)) xmlResponse.Append(string.Format(" callerId=\"{0}\"", callerId));
            xmlResponse.Append(string.Format(">{0}</Dial>", phonenumber));
            return this;
        }

        public TwilioResult Dial(Action<DialResult> action)
        {
            xmlResponse.Append(string.Format("<Dial>"));
            var gatherResult = new DialResult(action, ref xmlResponse);
            xmlResponse.Append("</Dial>");
            return this;
        }
        
        public TwilioResult Dial(string actionUrl, HttpMethod? method, Action<DialResult> action)
        {
            xmlResponse.Append(string.Format("<Dial"));
            if (!String.IsNullOrEmpty(actionUrl)) xmlResponse.Append(string.Format(" action=\"{0}\"", actionUrl));
            if (method.HasValue) xmlResponse.Append(string.Format(" method=\"{0}\"", method));
            var gatherResult = new DialResult(action, ref xmlResponse);
            xmlResponse.Append("></Dial>");
            return this;
        }

        public TwilioResult Dial(string actionUrl, HttpMethod? method, int? timeout, bool? hangupOnStar, 
            int? timeLimit, string callerId, Action<DialResult> action)
        {
            xmlResponse.Append(string.Format("<Dial"));
            if (!String.IsNullOrEmpty(actionUrl)) xmlResponse.Append(string.Format(" action=\"{0}\"", actionUrl));
            if (method.HasValue) xmlResponse.Append(string.Format(" method=\"{0}\"", method));
            if (timeout.HasValue) xmlResponse.Append(string.Format(" timeout=\"{0}\"", timeout));
            if (hangupOnStar.HasValue) xmlResponse.Append(string.Format(" hangupOnStar=\"{0}\"", hangupOnStar.ToString().ToLower()));
            if (timeLimit.HasValue) xmlResponse.Append(string.Format(" timeLimit=\"{0}\"", timeLimit));
            if (!String.IsNullOrEmpty(callerId)) xmlResponse.Append(string.Format(" callerId=\"{0}\"", callerId));
            var gatherResult = new DialResult(action, ref xmlResponse);
            xmlResponse.Append("></Dial>");
            return this;
        }

        public TwilioResult HangUp()
        {
            xmlResponse.Append(string.Format("<Hangup/>"));
            return this;
        }

        public TwilioResult Reject()
        {
            xmlResponse.Append(string.Format("<Reject/>"));
            return this;
        }

        public TwilioResult Reject(RejectReason? reason)
        {
            xmlResponse.Append(string.Format("<Reject"));
            if (reason.HasValue) xmlResponse.Append(string.Format(" reason=\"{0}\"", reason.ToString().ToLower()));
            xmlResponse.Append(string.Format("/>"));
            return this;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "text/xml";
            context.HttpContext.Response.Write(xmlResponse.ToString());
        }
    }
}
