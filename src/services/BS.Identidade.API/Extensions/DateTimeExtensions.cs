namespace BS.Identidade.API.Extensions
{
    public static class DateTimeExtensions
    {

        public static long ToUnixEpochDate(this DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
    }
}
