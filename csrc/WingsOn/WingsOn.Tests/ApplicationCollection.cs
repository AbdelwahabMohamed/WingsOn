﻿using Microsoft.AspNetCore.Mvc.Testing;
using WingsOn.Api;
using Xunit;

namespace WingsOn.Tests
{
    [CollectionDefinition("Application collection")]
    public class ApplicationCollection : ICollectionFixture<WebApplicationFactory<Startup>>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}