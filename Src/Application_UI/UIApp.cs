using System.Numerics;
using Raylib_cs;

public static class UIApp {

    #region Panel: Login
    public static void Login_Open(UIContext ctx) {
        ctx.panel_Login = new Panel_Login();
        ctx.panel_Login.Ctor(); // Constructure
    }

    public static void Login_Close(UIContext ctx) {
        ctx.panel_Login = null;
    }

    public static bool Login_IsClickStart(UIContext ctx) {
        if (ctx.panel_Login == null) {
            return false;
        }
        if (ctx.panel_Login.IsClickStart()) {
            return true;
        }
        return false;
    }

    public static void Login_Draw(UIContext ctx) {
        if (ctx.panel_Login != null) {
            ctx.panel_Login.Draw();
        }
    }
    #endregion Panel: Login

}