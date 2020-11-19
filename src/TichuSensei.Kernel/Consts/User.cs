namespace TichuSensei.Kernel.Consts
{
    /// <summary>
    /// User related constants.
    /// </summary>
    public static class User
    {
        /// User role related constants.
        /// </summary>
        public static class Role
        {
            /// <summary>
            /// A user that has full administrative authorization.
            /// </summary>
            public const string SuperAdmin = "SuperAdmin";

            /// <summary>
            /// A user that has elevated administrative authorization.
            /// </summary>
            public const string Admin = "Admin";

            /// <summary>
            /// A user that has moderator privileges.
            /// </summary>
            public const string Moderator = "Moderator";

            /// <summary>
            /// A user that has no elevated authorization.
            /// </summary>
            public const string User = "User";

        }
    }
}
