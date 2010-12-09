using System.Collections.Specialized;

namespace FluentTwilio
{
    public class TwilioRequestParams
    {
        private readonly NameValueCollection values;

        public string To { get { return values["To"] as string; } }
        public string From { get { return values["From"] as string; } }
        public string FromCity { get { return values["FromCity"] as string; } }
        public string FromState { get { return values["FromState"] as string; } }
        public string FromZip { get { return values["FromZip"] as string; } }
        public string FromCountry { get { return values["FromCountry"] as string; } }
        public string ToCity { get { return values["ToCity"] as string; } }
        public string ToState { get { return values["ToState"] as string; } }
        public string ToZip { get { return values["ToZip"] as string; } }
        public string ToCountry { get { return values["ToCountry"] as string; } }

        public string CallSid { get { return values["CallSid"] as string; } }
        public string AccountSid { get { return values["AccountSid"] as string; } }
        public CallStatus? CallStatus
        {
            get
            {
                var callStatus = values["CallStatus"] as string;
                switch (callStatus)
                {
                    case "queued": return FluentTwilio.CallStatus.QUEUED;
                    case "ringing": return FluentTwilio.CallStatus.RINGING;
                    case "in-progress": return FluentTwilio.CallStatus.INPROCESS;
                    case "completed": return FluentTwilio.CallStatus.COMPLETED;
                    case "busy": return FluentTwilio.CallStatus.BUSY;
                    case "no-answer": return FluentTwilio.CallStatus.NOANSWER;
                    case "failed": return FluentTwilio.CallStatus.FAILED;
                    case "canceled": return FluentTwilio.CallStatus.CANCELED;
                    default: return null;
                }
            }
        }
        public string ApiVersion { get { return values["ApiVersion"] as string; } }
        public string Direction { get { return values["Direction"] as string; } }
        public string ForwardedFrom { get { return values["ForwardedFrom"] as string; } }

        public TwilioRequestParams(NameValueCollection values)
        {
            this.values = values;
        }
    }
}