using System;
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

        Raylib.InitWindow(ctx.windowWidth, ctx.windowHeight, "Plane");
        Raylib.SetTargetFPS(ctx.fps);

        // ==== Enter ====
        LoginController.Enter(ctx);

        while (!Raylib.WindowShouldClose()) {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);
            
            float dt = Raylib.GetFrameTime();

            ref Camera2D cam = ref ctx.cameraEntity.cam;

            // ==== Input ====
            InfraController.PreTickInput(ctx, dt);

            // ==== Tick ====
            InfraController.Tick(ctx, dt);
            LoginController.Tick(ctx, dt);
            GameController.Tick(ctx, dt);

            // ==== Draw World ====
            Raylib.BeginMode2D(cam);
            LoginController.Draw(ctx);
            GameController.Draw(ctx);
            Raylib.EndMode2D();

            // ==== Draw UI (根据窗口) ====
            LoginController.DrawUI(ctx);
            GameController.DrawUI(ctx);

            Raylib.EndDrawing();

        }

        Raylib.CloseWindow();

    }

}