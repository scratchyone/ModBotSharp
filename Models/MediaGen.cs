using System;
using System.Net;

namespace ModBot.APIs
{
    class MediaGen
    {
        private string URL;
        public MediaGen(string URL)
        {
            this.URL = URL;
        }
        public void AssertOnline()
        {
            try
            {
                if (((HttpWebResponse)WebRequest.Create(URL).GetResponse()).StatusCode != HttpStatusCode.OK)
                    throw new UserError("MediaGen is currently offline, this command cannot be run right now.");
            }
            catch
            {
                throw new UserError("MediaGen is currently offline, this command cannot be run right now.");
            }
        }
        public string GeneratePollURL(int up, int down)
        {
            return $"{URL}poll?up={up}&down={down}";
        }
    }
}
namespace ModBot.APIs.Models
{
}