﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWEB.Utils
{
    public class Secao
    {
        //#1
        private readonly IHttpContextAccessor _http;

        private const string CARRINHO_ID = "CARRINHO_ID";

        public Secao(IHttpContextAccessor http)
        {
            _http = http;
        }

        public string BuscarCarrinhoId()
        {
            if (_http.HttpContext.Session.GetString(CARRINHO_ID) == null)
            {
                _http.HttpContext.Session.SetString(CARRINHO_ID, Guid.NewGuid().ToString());
            }

            return _http.HttpContext.Session.GetString(CARRINHO_ID);
        }

    }
}


/* #1
    _http será o obj que permitira trabalhar com a Session
 */