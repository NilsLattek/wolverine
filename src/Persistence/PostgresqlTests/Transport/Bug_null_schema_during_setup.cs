using IntegrationTests;
using JasperFx.Core;
using Microsoft.Extensions.Hosting;
using Npgsql;
using Shouldly;
using Weasel.Postgresql;
using Wolverine;
using Wolverine.Postgresql;
using Wolverine.RDBMS;

// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Logging.Abstractions;
// using Oakton.Resources;
// using Wolverine;
// using Wolverine.Postgresql;
// using Wolverine.RDBMS.Transport;
// using Wolverine.Runtime;

namespace PostgresqlTests.Transport;

public class Bug_null_schema_during_setup : IAsyncLifetime
{
    private IHost _host;

    public async Task InitializeAsync()
    {
        _host = await Host.CreateDefaultBuilder()
            .UseWolverine(opts =>
            {
                opts.UsePostgresqlPersistenceAndTransport(Servers.PostgresConnectionString)
                    .AutoProvision()
                    .AutoPurgeOnStartup();
            }).StartAsync();
    }

    [Fact]
    public async Task can_set_up_with_default_schema_name()
    {
        using var conn = new NpgsqlConnection(Servers.PostgresConnectionString);
        await conn.OpenAsync();

        var tables = await conn.ExistingTablesAsync(schemas: ["public"]);
        await conn.CloseAsync();

        tables.ShouldContain(x => x.Name == DatabaseConstants.NodeTableName);
    }

    public async Task DisposeAsync()
    {
        await _host.StopAsync();
        _host.Dispose();
    }
}
