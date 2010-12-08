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

                r.Redirect("URL");
            });

            string s = result.Render();
            ;
        }
    }
}


//.Method(HttpMethod.POST).Action("url").Timeout(5).FinishOnKey('#').NumDigits(5).Render();