using System.Numerics;
using Raylib_cs;

public static class LoginController {

    public static void Init(Context ctx) {

    }

    public static void Enter(Context ctx) {
        // 进入登录状态(注册界面/登录界面/创角界面)
        UIApp.Login_Open(ctx.uiContext);
    }

    public static void Tick(Context ctx, float dt) {
        bool isClick = UIApp.Login_IsClickStart(ctx.uiContext);
        if (isClick) {
            UIApp.Login_Close(ctx.uiContext);

            // 进入游戏状态
            ctx.gameEntity.isEnteringGame = true;
        }
    }

    public static void Draw(Context ctx) {

    }

    public static void DrawUI(Context ctx) {
        // 如果处于登录状态
        UIApp.Login_Draw(ctx.uiContext);
    }

}