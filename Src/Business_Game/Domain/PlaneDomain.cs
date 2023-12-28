using System.Numerics;
using Raylib_cs;

public static class PlaneDomain {

    public static PlaneEntity SpawnPlane(Context ctx, int typeID, Vector2 pos, AllyStatus ally) {

        // 生成: Factory
        var plane = Factory.CreatePlane(ctx.template, ctx.idService, typeID, pos, ally);

        // 存储: Repository
        ctx.gameContext.planeRepo.Add(plane);

        return plane;

    }

    public static void Move(Context ctx, PlaneEntity plane, float dt) {
        if (plane.ally == AllyStatus.Player) {
            // 根据输入
            Vector2 moveAxis = ctx.inputEntity.moveAxis;
            plane.Move(moveAxis, dt);
        } else if (plane.ally == AllyStatus.Enemy) {
            // 初始方向 / 跟踪
            MoveByType(ctx, plane, dt);
        }
    }

    static void MoveByType(Context ctx, PlaneEntity plane, float dt) {
        if (plane.moveType == MoveType.ByLine) {
            MoveByType_Line(ctx, plane, dt);
        }
    }

    static void MoveByType_Line(Context ctx, PlaneEntity plane, float dt) {

    }

}