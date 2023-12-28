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

        // 敌机生成
        // 飞机移动
        System.Console.WriteLine("飞机移动");

    }

    static void EnterGame(Context ctx) {
        GameEntity game = ctx.gameEntity;
        game.isInGame = true;

        // 生成我方飞机
        // 初始化敌机时间
        System.Console.WriteLine("飞机生成");

    }

    public static void Draw(Context ctx) {
        GameEntity game = ctx.gameEntity;
        if (!game.isInGame) {
            return;
        }

        // 绘制飞机
    }

    public static void DrawUI(Context ctx) {
        GameEntity game = ctx.gameEntity;
        if (!game.isInGame) {
            return;
        }
        // 绘制 UI
    }

}