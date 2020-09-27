namespace TichuSensei.Kernel.Consts
{
    /// <summary>
    /// Paginated Lists related constants.
    /// </summary>
    public static class Pagination
    {
        /// <summary>
        /// Pagination list's page index related constants.
        /// </summary>
        public static class PageNumber
        {
            /// <summary>
            /// Default page index if the request does not specify one.
            /// </summary>
            public const int Default = 1;
            /// <summary>
            /// Minimum allowed page index.
            /// </summary>
            public const int Min = 1;
        }

        /// <summary>
        /// Pagination list's page size related constants.
        /// </summary>
        public static class PageSize
        {
            /// <summary>
            /// Default page size if the request does not specify one.
            /// </summary>
            public const int Default = 25;
            /// <summary>
            /// Minimum allowed page size.
            /// </summary>
            public const int Min = 10;
            /// <summary>
            /// Maximum allowed page size.
            /// </summary>
            public const int Max = 200;
        }

    }
}
