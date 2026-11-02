using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public sealed record CallbackResult(string? Code, string? State, string? Error);

public sealed class OAuthCallbackServer : IAsyncDisposable
{
    private WebApplication? _app;
    private readonly TaskCompletionSource<CallbackResult> _tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);

    public int Port { get; private set; }
    public Task<CallbackResult> Callback => _tcs.Task;
}