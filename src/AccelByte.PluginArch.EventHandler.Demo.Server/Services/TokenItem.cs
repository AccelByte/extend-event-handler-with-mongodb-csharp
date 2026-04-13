// Copyright (c) 2026 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AccelByte.IAM.Oauth;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AccelByte.PluginArch.EventHandler.Demo.Server.Services
{
    public class TokenItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("id")]
        public string? Id { get; set; } = "";

        [BsonElement("clientId")]
        [JsonPropertyName("clientId")]
        public string ClientId { get; set; } = "";

        [BsonElement("namespace")]
        [JsonPropertyName("namespace")]
        public string Namespace { get; set; } = "";

        public static TokenItem FromRequestData(OauthTokenGenerated request)
        {
            return new TokenItem()
            {
                ClientId = request.ClientId,
                Namespace = request.Namespace,
            };
        }
    }
}
