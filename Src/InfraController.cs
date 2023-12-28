using System.Numerics;
using Raylib_cs;

// Infrastructure 基础设施
// 相机/模板数据/资源/物理引擎/音频
public static class InfraController {

    public static void Init(Context ctx) {

        ctx.windowWidth = 500;
        ctx.windowHeight = 800;
        ctx.baseSize = 20; // 25, 40
        ctx.fps = 60;

        ctx.template.Init(ctx.baseSize);

        CameraEntity cameraEntity = ctx.cameraEntity;
        Camera2D cam = cameraEntity.cam;
        cam.Zoom = 1.0f;
        cam.Rotation = 0;
        cam.Target = Vector2.Zero;
        cam.Offset = Vector2.Zero;
        cameraEntity.cam = cam;

    }

    public static void Tick(Context ctx, float dt) {

        // 相机
        TickCamera(ctx, dt);

    }

    public static void PreTickInput(Context ctx, float dt) {

        InputEntity input = ctx.inputEntity;

        // WSAD
        Vector2 axis = Vector2.Zero;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) {
            axis.Y -= 1;
        } else if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) {
            axis.Y += 1;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) {
            axis.X -= 1;
        } else if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) {
            axis.X += 1;
        }
        input.moveAxis = axis;

    }

    static void TickCamera(Context ctx, float dt) {
        ref Camera2D cam = ref ctx.cameraEntity.cam;
        float mouseWheel = Raylib.GetMouseWheelMove();
        if (mouseWheel != 0) {
            cam.Zoom += mouseWheel * 1 * dt;
        }

        cam.Offset = new Vector2(ctx.windowWidth, ctx.windowHeight) / 2;
    }

}