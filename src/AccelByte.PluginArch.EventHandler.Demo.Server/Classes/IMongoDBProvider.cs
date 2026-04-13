// Copyright (c) 2026 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System;
using MongoDB.Driver;

namespace AccelByte.PluginArch.EventHandler.Demo.Server
{
    public interface IMongoDBProvider
    {
        IMongoClient GetClient();

        IMongoDatabase GetDatabase();
    }
}
