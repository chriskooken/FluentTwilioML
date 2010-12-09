using FluentTwilio;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void TestFulentConfig()
        {
            var result = new TwilioResult(r =>
            {
                
                r.Say("Hello");
                
                r.Gather(x =>
                    {
                        x.Say("This Is a menu");
                        x.Pause(10);
                        x.Play("url", 10);

                    });

                r.Dial("phoneNumber");
                r.Dial(x =>
                    {
                        x.Number("7703779886");
                        x.Conference("1234");
                        x.Conference("1234", true, false, true, true);
                    });
                r.Redirect("URL");

                r.Record();
                r.Record("URL", HttpMethod.GET);
                r.Record("URL", HttpMethod.POST, 6, "#", 20, false, null, true);
                r.SMS("Hello sms");
                r.SMS("Hello sms", "URL", HttpMethod.POST);
                r.SMS("Hello sms", "URL", HttpMethod.POST, "7703779886","15474754", "callback");
                r.HangUp();
                r.Reject();
                r.Reject(RejectReason.BUSY);
            });

            string s = result.Render();
            ;
        }
    }
}


//.Method(HttpMethod.POST).Action("url").Timeout(5).FinishOnKey('#').NumDigits(5).Render();