using Microsoft.Extensions.Options;

namespace WebApi.Options;

public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
{
    private const string CONFIGURATION_SECTION_NAME = "DatabaseOptions";
    private readonly IConfiguration _configuration;

    public DatabaseOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(DatabaseOptions options)
    {
        var connectionStrings = _configuration.GetConnectionString("Database");
        options.ConnectionStrings = connectionStrings;
        _configuration.GetSection(CONFIGURATION_SECTION_NAME).Bind(options);
    }
}
