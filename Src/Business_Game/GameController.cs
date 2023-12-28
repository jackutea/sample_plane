using System.Numerics;
using Raylib_cs;

public static class GameController {

    public static void Init(Context ctx) {

    }

    public static void Tick(Context ctx, float dt) {
        GameEntity game = ctx.gameEntity;

        // 保证只执行一次
        if (game.isEnteringGame) {
            game.isEnteringGame = false;
            EnterGame(ctx);
        }

        // 每帧执行
        if (!game.isInGame || game.isPause) {
            return;
        }

        // 关卡波次
        int levelLen = ctx.gameContext.levelRepo.TakeAll(out LevelEntity[] levels);
        for (int i = 0; i < levelLen; i += 1) {
            LevelEntity level = levels[i];
            LevelDomain.TrySpawnEntity(ctx, level, dt);
        }

        // 飞机移动
        int planeLen = ctx.gameContext.planeRepo.TakeAll(out PlaneEntity[] planes);
        for (int i = 0; i < planeLen; i += 1) {
            PlaneEntity plane = planes[i];
            PlaneDomain.Move(ctx, plane, dt);
            // PlaneDomain.Shoot(); -> BulletDomain->SpawnBullet
        }

        // 子弹移动/击中
        // int bulletLen 

    }

    static void EnterGame(Context ctx) {

        GameEntity game = ctx.gameEntity;
        game.isInGame = true;

        // 生成关卡
        LevelDomain.SpawnLevel(ctx, 1);

        // 生成我方飞机
        PlaneEntity owner = PlaneDomain.SpawnPlane(ctx, TypeIDConst.PLAYER_PLANE_TYPEID, new Vector2(), AllyStatus.Player);
        owner.moveType = MoveType.ByInput;

    }

    public static void Draw(Context ctx) {
        GameEntity game = ctx.gameEntity;
        if (!game.isInGame) {
            return;
        }

        // 绘制飞机
        int planeLen = ctx.gameContext.planeRepo.TakeAll(out PlaneEntity[] all);
        for (int i = 0; i < planeLen; i += 1) {
            PlaneEntity plane = all[i];
            plane.Draw();
        }
    }

    public static void DrawUI(Context ctx) {
        GameEntity game = ctx.gameEntity;
        if (!game.isInGame) {
            return;
        }
        // 绘制 UI
    }

}