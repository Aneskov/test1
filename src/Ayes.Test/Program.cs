using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ayes.Test.Domain;
using Newtonsoft.Json.Linq;

namespace Ayes.Test
{
    class Program
    {
        private const int DefaultCardsCount = 3;
        private const string ApiUrl = "https://deckofcardsapi.com";

        static async Task Main(string[] args)
        {
            var cardsCount = EvaluateCardsCount(args);
            var cards = await DrawCards(cardsCount);
            var calc = new Baccarat.ScoreCalculator();

            foreach (var card in cards)
            {
                calc.Append(card.Value);
                Console.WriteLine(card);
            }

            Console.WriteLine($"Your score is {calc.Score}");
        }

        static int EvaluateCardsCount(string[] args)
            => args.Length == 0 ? DefaultCardsCount : int.Parse(args[0]);

        static async Task<IEnumerable<Card>> DrawCards(int count)
        {
            using var cli = new HttpClient {BaseAddress = new Uri(ApiUrl)};
            var deckId = await GetDeckId(cli);
            return await DrawCards(cli, deckId, count);
        }

        static async Task<string> GetDeckId(HttpClient cli)
        {
            var respJson = await cli.GetJson("/api/deck/new/shuffle");
            var deckIdJsonProp = (JProperty)respJson.Single(i => i.Path == "deck_id");
            return deckIdJsonProp.First.ToString();
        }

        static async Task<IEnumerable<Card>> DrawCards(HttpClient cli, string deckId, int count)
        {
            var respJson = await cli.GetJson($"/api/deck/{deckId}/draw/?count={count}");
            var cardsJsonProp = respJson.Single(i => i.Path == "cards");
            return cardsJsonProp.First.Select(i => i.ToObject<Card>());
        }
    }

    static class HttpClientExt
    {
        public static async Task<JToken> GetJson(this HttpClient cli, string url)
        {
            var respStr = await cli.GetStringAsync(url);
            return JToken.Parse(respStr);
        }
    }
}
