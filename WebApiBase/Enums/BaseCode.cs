using System.ComponentModel;

namespace WebApiBase.Enums
{
    public static class BaseCode
    {
        public enum AuthFilter
        {
            /// <summary>
            ///     Request model convert failed.
            /// </summary>
            [Description("Request model convert failed.")]
            AuthError001,

            /// <summary>
            ///     Required parameters of request model are missing.
            /// </summary>
            [Description("Required parameters of request model are missing.")]
            AuthError002,

            /// <summary>
            ///     The API key is invalid.
            /// </summary>
            [Description("The API key is invalid.")]
            AuthError003,

            /// <summary>
            ///     Data signature is invalid.
            /// </summary>
            [Description("Data signature is invalid.")]
            AuthError004
        }

        public enum Common
        {
            /// <summary>
            ///     Necessary parameters are missing.
            /// </summary>
            [Description("Necessary parameters are missing.")]
            CommonError001,

            /// <summary>
            ///     The format of parameters are incorrect.
            /// </summary>
            [Description("The format of parameters are incorrect.")]
            CommonError002
        }
    }
}