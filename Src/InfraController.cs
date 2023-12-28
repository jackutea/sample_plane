// Infrastructure 基础设施
// 相机/模板数据/资源/物理引擎/音频
public static class InfraController {

    public static void Init(Context ctx) {

        ctx.fps = 60;

        ctx.template.Init();

    }

}