using Microsoft.JSInterop;

namespace CloudWatchLogsEncoderDecoder.Web.Services;

public sealed class ClipboardService
{
    private readonly IJSRuntime _jsRuntime;
    public ClipboardService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    public async ValueTask CopyToClipboard(string text)
    {
        await _jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
    }
    public async ValueTask<string> GetFromClipboard()
    {
        return await _jsRuntime.InvokeAsync<string>("navigator.clipboard.readText");
    }
}
