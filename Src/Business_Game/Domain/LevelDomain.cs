using System.Numerics;
using Raylib_cs;

public static class LevelDomain {

    // 生成一个生成器
    public static void SpawnLevel(Context ctx, int typeID) {

        // 生成
        LevelEntity wave = Factory.CreateWave(ctx.template, ctx.idService, typeID);

        // 存储
        ctx.gameContext.levelRepo.Add(wave);

    }

    public static void TrySpawnEntity(Context ctx, LevelEntity level, float dt) {

        ref float time = ref level.time;
        time += dt;
        if (time >= level.spawnMaintainSec) {
            // 不再生成怪物
            return;
        }

        LevelSpawnModel[] spawnModels = level.spawnModels;
        for (int i = 0; i < spawnModels.Length; i += 1) {

            LevelSpawnModel model = spawnModels[i];
            if (time < model.beginTime || time > model.endTime) {
                continue;
            }

            model.timer -= dt;
            if (model.timer <= 0) {
                model.timer = model.interval;
                // 生成 Entity
                SpawnEntity(ctx, level, model);
            }
        }

    }

    static void SpawnEntity(Context ctx, LevelEntity level, LevelSpawnModel model) {
        if (model.entityType == EntityType.Plane) {
            PlaneDomain.SpawnPlane(ctx, model.entityTypeID, new Vector2(0, -20) * ctx.baseSize, AllyStatus.Enemy);
        } else if (model.entityType == EntityType.Bullet) {
            PLog.LogWarning("TODO BULLET");
        } else if (model.entityType == EntityType.Food) {
            PLog.LogWarning("TODO FOOD");
        } else {
            PLog.LogError($"No {model.entityType}");
        }
    }

}