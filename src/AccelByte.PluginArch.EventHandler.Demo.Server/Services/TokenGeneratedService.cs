// Copyright (c) 2026 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Threading.Tasks;

using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

using AccelByte.IAM.Oauth;
using Microsoft.Extensions.Logging;

namespace AccelByte.PluginArch.EventHandler.Demo.Server.Services
{
    public class TokenGeneratedService : OauthTokenOauthTokenGeneratedService.OauthTokenOauthTokenGeneratedServiceBase
    {
        private readonly ILogger<TokenGeneratedService> _Logger;

        private readonly IMongoDBProvider _DBProvider;

        public TokenGeneratedService(
            ILogger<TokenGeneratedService> logger,
            IMongoDBProvider dbProvider)
        {
            _Logger = logger;
            _DBProvider = dbProvider;
        }

        public override async Task<Empty> OnMessage(OauthTokenGenerated request, ServerCallContext context)
        {
            _Logger.LogInformation("Received OauthTokenGenerated event: {@Request}", request);

            var tokenItem = TokenItem.FromRequestData(request);

            var db = _DBProvider.GetDatabase();
            var collection = db.GetCollection<TokenItem>("generated_tokens");

            await collection.InsertOneAsync(tokenItem);

            return await Task.FromResult(new Empty());
        }
    }
}
