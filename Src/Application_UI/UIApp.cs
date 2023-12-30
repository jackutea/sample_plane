using System.Numerics;
using Raylib_cs;

public static class UIApp {

    #region Panel: Login
    public static void Login_Open(UIContext ctx) {
        ref Panel_Login panel = ref ctx.panel_Login;
        if (panel == null) {
            panel = new Panel_Login();
            panel.Ctor(); // Constructure
        }
        panel.Init();
    }

    public static void Login_Close(UIContext ctx) {
        if (ctx.panel_Login != null) {
            ctx.panel_Login.Close();
        }
    }

    public static bool Login_IsClickStart(UIContext ctx) {
        if (ctx.panel_Login == null || !ctx.panel_Login.isOpen) {
            return false;
        }
        if (ctx.panel_Login.IsClickStart()) {
            return true;
        }
        return false;
    }

    public static void Login_Draw(UIContext ctx) {
        if (ctx.panel_Login != null && ctx.panel_Login.isOpen) {
            ctx.panel_Login.Draw();
        }
    }
    #endregion Panel: Login

}