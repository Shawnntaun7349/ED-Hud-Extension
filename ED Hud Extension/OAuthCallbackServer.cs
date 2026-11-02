using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;

namespace ED_Hud_Extension
{
    public sealed record CallbackResult(string? Code, string? State, string? Error);

    public sealed class OAuthCallbackServer : IAsyncDisposable
    {
        private WebApplication? _app;
        private readonly TaskCompletionSource<CallbackResult> _tcs =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public int Port { get; private set; }
        public Task<CallbackResult> Callback => _tcs.Task;

        public async Task StartAsync(X509Certificate2 cert, IEnumerable<int> ports)
        {
            foreach (var port in ports)
            {
                var builder = WebApplication.CreateSlimBuilder();
                builder.Logging.ClearProviders();
                builder.WebHost.ConfigureKestrel(k =>
                    k.ListenLocalhost(port, lo => lo.UseHttps(cert)));

                var app = builder.Build();
                app.MapGet("/{**path}", async (HttpContext ctx) =>
                {
                    var q = ctx.Request.Query;
                    // Ignore stray requests (favicon, etc.); only react to the real redirect.
                    if (!q.ContainsKey("code") && !q.ContainsKey("error"))
                    {
                        ctx.Response.StatusCode = 404;
                        return;
                    }
                    ctx.Response.ContentType = "text/html";
                    await ctx.Response.WriteAsync("<html><body>Authorization received. You can close this tab.</body></html>");
                    _tcs.TrySetResult(new CallbackResult(q["code"], q["state"], q["error"]));
                });

                try
                {
                    await app.StartAsync();
                    _app = app;
                    Port = port;
                    return;
                }
                catch (IOException) // port already in use
                {
                    await app.DisposeAsync();
                }
            }
            throw new InvalidOperationException("None of the registered ports are available.");
        }

        public async ValueTask DisposeAsync()
        {
            if (_app is not null)
            {
                await _app.StopAsync();
                await _app.DisposeAsync();
            }
        }
    }
}