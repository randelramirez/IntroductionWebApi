﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HelloWebApiDemo
{
    public class SecondController : ApiController
    {
        public string Get()
        {
            return "This is the second controller";
        }

    }
}