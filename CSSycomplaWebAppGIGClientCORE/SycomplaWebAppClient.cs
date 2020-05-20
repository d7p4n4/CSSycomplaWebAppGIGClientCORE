﻿using CSGIGRESTResponseRequestClassesCORE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSycomplaWebAppGIGClientCORE
{
    public class SycomplaWebAppClient
    {
        private Ac4yRestServiceClient Ac4yRestServiceClient = new Ac4yRestServiceClient("https://service.sycompla.hu/gigserver");

        public GetListOfUsersResponse GetListOfUsers(GetListOfUsersRequest request)
        
        {
            string json = Ac4yRestServiceClient.POST("/getlistofusers/", "{}");

            return JsonConvert.DeserializeObject<GetListOfUsersResponse>(json);

        }

        public GetUserFromByTokenResponse GetUserFromByToken(GetUserFromByTokenReqest request)
        {
            string json = Ac4yRestServiceClient.POST("/getuserfrombytoken/", "{\n\t\"fbToken\": \"" + request.fbToken + "\"\t\n}");

            return JsonConvert.DeserializeObject<GetUserFromByTokenResponse>(json);

        }
    }
}
