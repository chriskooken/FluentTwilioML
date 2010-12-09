using System;
using System.Text;

namespace FluentTwilio
{
    public class DialResult
    {
        private StringBuilder xmlResponse;

        public DialResult(Action<DialResult> action, ref StringBuilder xmlResponse)
        {
            this.xmlResponse = xmlResponse;
            action.Invoke(this);
        }

        public DialResult Number(string number)
        {
            xmlResponse.Append(string.Format("<Number>{0}</Number>", number));
            return this;
        }

        public DialResult Number(string number, string sendDigits, string url)
        {
            xmlResponse.Append(string.Format("<Number"));
            if (!String.IsNullOrEmpty(sendDigits)) xmlResponse.Append(string.Format(" sendDigits=\"{0}\"", sendDigits));
            if (!String.IsNullOrEmpty(url)) xmlResponse.Append(string.Format(" url=\"{0}\"", url));
            xmlResponse.Append(string.Format(">{0}</Number>", number));
            return this;
        }

        public DialResult Conference(string roomnumber)
        {
            xmlResponse.Append(string.Format("<Conference>{0}</Conference>", roomnumber));
            return this; 
        }

        public DialResult Conference(string roomnumber, bool? muted, bool? beep, bool? startConferenceOnEnter,
            bool? endConferenceOnExit)
        {
            xmlResponse.Append(string.Format("<Conference"));
            if (muted.HasValue) xmlResponse.Append(string.Format(" muted=\"{0}\"", muted.ToString().ToLower()));
            if (beep.HasValue) xmlResponse.Append(string.Format(" beep=\"{0}\"", beep.ToString().ToLower()));
            if (startConferenceOnEnter.HasValue) xmlResponse.Append(string.Format(" startConferenceOnEnter=\"{0}\"", startConferenceOnEnter.ToString().ToLower()));
            if (endConferenceOnExit.HasValue) xmlResponse.Append(string.Format(" endConferenceOnExit=\"{0}\"", endConferenceOnExit.ToString().ToLower()));
            xmlResponse.Append(string.Format(">{0}</Conference>", roomnumber));
            return this;
        }

        public DialResult Conference(string roomnumber, bool? muted, bool? beep, bool? startConferenceOnEnter, 
            bool? endConferenceOnExit, string waitUrl, HttpMethod? waitMethod)
        {
            xmlResponse.Append(string.Format("<Conference"));
            if (muted.HasValue) xmlResponse.Append(string.Format(" muted=\"{0}\"", muted.ToString().ToLower()));
            if (beep.HasValue) xmlResponse.Append(string.Format(" beep=\"{0}\"", beep.ToString().ToLower()));
            if (startConferenceOnEnter.HasValue) xmlResponse.Append(string.Format(" startConferenceOnEnter=\"{0}\"", startConferenceOnEnter.ToString().ToLower()));
            if (endConferenceOnExit.HasValue) xmlResponse.Append(string.Format(" endConferenceOnExit=\"{0}\"", endConferenceOnExit.ToString().ToLower()));
            if (!String.IsNullOrEmpty(waitUrl)) xmlResponse.Append(string.Format(" waitUrl=\"{0}\"", waitUrl));
            if (waitMethod.HasValue) xmlResponse.Append(string.Format(" waitMethod=\"{0}\"", waitMethod));
            xmlResponse.Append(string.Format(">{0}</Conference>", roomnumber));
            return this;
        }
    }
}