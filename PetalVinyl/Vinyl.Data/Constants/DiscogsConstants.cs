using System;
using System.Collections.Generic;
using System.Text;

namespace Vinyl.Data.Constants
{
    public static class DiscogsConstants
    {
        public const string URL = "https://api.discogs.com";
        public const string PATH_TO_COLLECTION = "/users/ausamerika/collection/folders/0/releases";
        public const string PAGE_QUERY_PARAM_NAME = "page";
        public const string PER_PAGE_QUERY_PARAM_NAME = "page";

        public const string ERROR_MESSAGE_DISCOGS_CALL_FAILED = "Failed to call the Discogs API";
    }
}
