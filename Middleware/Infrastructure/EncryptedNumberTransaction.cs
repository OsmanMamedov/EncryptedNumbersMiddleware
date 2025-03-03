﻿using Microsoft.AspNetCore.Http;
using Middleware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware.Infrastructure
{
    public class EncryptedNumberTransaction
    {
        //Önceki middleware'den gelen context'i alıyoruz.
        private RequestDelegate _request;
        public EncryptedNumberTransaction(RequestDelegate request)
        {
            _request = request;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //Query string üzerinden gelen şifreli sayımız
            var item = httpContext.Request.Query["number"].ToString();
            //Şifrelenmiş sayımızı çözüp numberDecrypt adında itemımıza aktarıyoruz.
            EncryptionManager encryptionManager = new EncryptionManager();
            httpContext.Items["numberDecrypt"] = encryptionManager.Decrypt(item);
            //Sonraki middleware'e gönder
            await _request.Invoke(httpContext);
        }
    }
}
