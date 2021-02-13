using System;
using System.Net;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Collections.Generic;

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
        public async Task<List<string>> GetOwoActions()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            var query = new NameValueCollection();
            var url = $"owoActions";
            var response = await client.GetAsync(url);
            var owoActions = JsonSerializer.Deserialize<List<string>>(await response.Content.ReadAsStringAsync());
            return owoActions;
        }
        public async Task<Models.OwOInfo> GetOwoInfo(string action, string author, string authee)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            var query = new NameValueCollection();
            query.Add("action", action);
            if (author != null)
                query.Add("author", author);
            if (authee != null)
                query.Add("authee", authee);
            var url = $"owoJson{ToQueryString(query)}";
            var response = await client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.NotFound) throw new UserError($"Invalid action. Valid actions are {string.Join(", ", await GetOwoActions())}");
            var owoInfo = JsonSerializer.Deserialize<Models.OwOInfo>(await response.Content.ReadAsStringAsync());
            owoInfo.imageURL = $"{URL}owoProxy.gif?url={HttpUtility.UrlEncode(owoInfo.imageURL)}";
            Console.WriteLine(owoInfo.authorName);
            return owoInfo;
        }
        public async Task<Models.CoinFlip> GetCoinFlip()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            var url = $"coinFlip";
            var response = await client.GetAsync(url);
            var owoInfo = JsonSerializer.Deserialize<Models.CoinFlip>(await response.Content.ReadAsStringAsync());
            owoInfo.imageURL = $"{URL}owoProxy.gif?url={HttpUtility.UrlEncode(owoInfo.imageURL)}";
            return owoInfo;
        }
        private string ToQueryString(NameValueCollection nvc)
        {
            var array = (
                from key in nvc.AllKeys
                from value in nvc.GetValues(key)
                select string.Format(
            "{0}={1}",
            HttpUtility.UrlEncode(key),
            HttpUtility.UrlEncode(value))
                ).ToArray();
            return "?" + string.Join("&", array);
        }
    }
}
namespace ModBot.APIs.Models
{
    class OwOInfo
    {
        public string imageURL { get; set; }
        public string authorName { get; set; }
        public string color { get; set; }
    }
    class CoinFlip
    {
        public string imageURL { get; set; }
        public int length { get; set; }
    }
}