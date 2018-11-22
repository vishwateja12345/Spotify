﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotifyAPIClient.Models
{
    public class Album
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public string scope { get; set; }

        public string expires_in { get; set; }

        public string code { get; set; }
    }
}