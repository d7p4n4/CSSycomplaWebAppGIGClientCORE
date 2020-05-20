using CSGIGRESTResponseRequestClassesCORE;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace CSSycomplaWebAppGIGClientCORE
{
    class Program
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();

            GetListOfUsersResponse response =
                new SycomplaWebAppClient().GetListOfUsers(new GetListOfUsersRequest());

            GetUserFromByTokenResponse getUserFromByTokenResponse =
                new SycomplaWebAppClient().GetUserFromByToken(new GetUserFromByTokenReqest()
                {
                    fbToken = "dTf4YoJGx6nCudv_LqcJlV:APA91bGwGX5JBtQbYZ6FMkrpJH6veUdmyC_StzNhAuSvUhAKx9DTp5EVlfDlUdl77kv0HTfcxh-L82-1jhiFIgf15HS4ofnZVQr_nvKXjGT3FkRlFxckwBtqqpqSKFPa-D6abZnbpwc7"
                });

            IsTokenExistResponse isTokenExistResponse =
                new SycomplaWebAppClient().IsTokenExist(new IsTokenExistRequest()
                {
                    fbToken = "dTf4YoJGx6nCudv_LqcJlV:APA91bGwGX5JBtQbYZ6FMkrpJH6veUdmyC_StzNhAuSvUhAKx9DTp5EVlfDlUdl77kv0HTfcxh-L82-1jhiFIgf15HS4ofnZVQr_nvKXjGT3FkRlFxckwBtqqpqSKFPa-D6abZnbpwc7"
                });

            IsUnknownOrInvalidTokenResponse isUnknownOrInvalidTokenResponse =
                new SycomplaWebAppClient().IsUnkmnownOrInvalidToken(new IsUnknownOrInvalidTokenRequest()
                {
                    fbToken = "dTf4YoJGx6nCudv_LqcJlV:APA91bGwGX5JBtQbYZ6FMkrpJH6veUdmyC_StzNhAuSvUhAKx9DTp5EVlfDlUdl77kv0HTfcxh-L82-1jhiFIgf15HS4ofnZVQr_nvKXjGT3FkRlFxckwBtqqpqSKFPa-D6abZnbpwc7"
                });
        }
    }
}
