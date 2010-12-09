using System.Text;

namespace FluentTwilio
{
    public class GenricTwilio<T> where T : class
    {
        public StringBuilder xmlResponse;
        public T Say(string message)
        {
            xmlResponse.Append(string.Format("<Say>{0}</Say>", message));
            return this as T;
        }

        public T Say(string message, Voice? voice, int? loop)
        {
            xmlResponse.Append(string.Format("<Say"));
            if (voice.HasValue) xmlResponse.Append(string.Format(" voice=\"{0}\"", voice.ToString().ToLower()));
            if (loop.HasValue) xmlResponse.Append(string.Format(" loop=\"{0}\"", loop));
            xmlResponse.Append(string.Format(">{0}</Say>", message));
            return this as T;
        }

        public T Pause(int pauseFor)
        {
            xmlResponse.Append(string.Format("<Pause length=\"{0}\"/>", pauseFor));
            return this as T;
        }

        public T Play(string url)
        {
            xmlResponse.Append(string.Format("<Play>{0}</Play>", url));
            return this as T;
        }

        public T Play(string url, int loop)
        {
            xmlResponse.Append(string.Format("<Play loop=\"{0}\">{1}</Play>", loop, url));
            return this as T;
        }

    }
}