using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

public static class Program {

    public static void Main() {

        Context ctx = new Context();

        // ==== Init ====
        InfraController.Init(ctx);
        LoginController.Init(ctx);
        GameController.Init(ctx);

        Raylib.InitWindow(640, 900, "Plane");
        Raylib.SetTargetFPS(ctx.fps);

        // ==== Enter ====
        LoginController.Enter(ctx);

        while (!Raylib.WindowShouldClose()) {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            // ==== Tick ====
            float dt = Raylib.GetFrameTime();
            LoginController.Tick(ctx, dt);
            GameController.Tick(ctx, dt);

            // ==== Draw World ====
            LoginController.Draw(ctx);
            GameController.Draw(ctx);

            // ==== Draw UI (根据窗口) ====
            LoginController.DrawUI(ctx);
            GameController.DrawUI(ctx);

            Raylib.EndDrawing();

        }

        Raylib.CloseWindow();

    }

}