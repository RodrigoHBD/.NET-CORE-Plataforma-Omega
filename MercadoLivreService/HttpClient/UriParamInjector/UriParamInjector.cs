using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HttpClientLibrary
{
    public class UriParamInjector
    {
        public static string InjectParamList(string uri, List<UriParam> list)
        {
            list.ForEach(param => 
            {
                uri = InjectParam(uri, param);
            });

            return uri;
        }

        public static string InjectParam(string uri, UriParam param)
        {
            var uriHasParam = GetHasAnyParam(uri);

            if (uriHasParam)
            {
                return $"{uri}&{param.Name}={param.Data}";
            }
            else
            {
                return $"{uri}?{param.Name}={param.Data}";
            }
        }

        private static bool GetHasAnyParam(string uri)
        {
            return uri.Contains("?");
        }
    }
}
