﻿using FieldStaffService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace FieldStaffService
{
    class CustomMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage>
          SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            new LoginController().checklogin();

            return base.SendAsync(request, cancellationToken);
        }
    }
}