using Android.App;
using Android.Runtime;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Color = Android.Graphics.Color;

namespace Scanner;

[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
        {
            h.PlatformView.BackgroundTintList =
                Android.Content.Res.ColorStateList.ValueOf(Color.Transparent);
        });
        
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(EntryHandler), (handler, view) =>
        {
#if ANDROID

            handler.PlatformView.UpdateReturnType(view);

#endif
        });
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}