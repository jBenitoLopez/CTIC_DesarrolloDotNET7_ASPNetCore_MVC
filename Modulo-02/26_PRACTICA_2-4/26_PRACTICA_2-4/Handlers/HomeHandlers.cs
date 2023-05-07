using Microsoft.Extensions.Caching.Distributed;

namespace _26_PRACTICA_2_4.Handlers
{
    public class HomeHandlers
    {
        public static async Task GetHomePageAsync(HttpContext context, IDistributedCache cache)
        {
            var cachedTotalVisits = await cache.GetStringAsync("TotalVisits") ?? "0";
            var totalVisits = Convert.ToInt32(cachedTotalVisits) + 1;
            var userVisits = context.Session.GetInt32("UserVisits").GetValueOrDefault() + 1;

            var body = $@"
                <h1>Home</h1>
                <p>Hello, {context.User.Identity?.Name}!</p>
                <p>Your visits: {userVisits}. Total visits: {totalVisits}.</p>
                <p><a href='/logout'>Logout</a></p>
            ";

            await cache.SetStringAsync("TotalVisits", totalVisits.ToString());
            context.Session.SetInt32("UserVisits", userVisits);

            await PageUtils.SendPageAsync(context, "Home", body);
        }
    }
}
