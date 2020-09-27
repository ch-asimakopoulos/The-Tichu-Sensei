namespace TichuSensei.Kernel.Consts
{
    /// <summary>
    /// Logging related constants.
    /// </summary>
    public static class Logging
    {
        /// <summary>
        /// The number of miliseconds that must pass before a request is considered slow and gets logged.
        /// </summary>
        public const int ElapsedMillisecondLimitForLoggingSlowRequests = 500;
    }
}
