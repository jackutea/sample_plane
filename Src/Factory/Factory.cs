using System.Numerics;

public static class Factory {

    public static PlaneEntity CreatePlane(Template template, IDService idService, int typeID, Vector2 pos, AllyStatus ally) {

        bool has = template.TryGetPlane(typeID, out PlaneTM tm);
        if (!has) {
            PLog.LogError($"Factory.CreatePlane: typeID {typeID} not found");
            return null;
        }

        PlaneEntity plane = new PlaneEntity();
        plane.entityID = idService.planeIDRecord++;
        plane.typeID = tm.typeID;
        plane.ally = ally;

        plane.pos = pos;
        plane.moveSpeed = tm.moveSpeed;
        plane.moveType = tm.moveType;

        plane.hp = tm.hp;
        plane.hpMax = tm.hp;

        plane.color = tm.color;
        plane.shapeType = tm.shapeType;
        plane.size = tm.size;

        return plane;

    }

    public static LevelEntity CreateWave(Template template, IDService idService, int typeID) {

        bool has = template.TryGetLevel(typeID, out LevelTM tm);
        if (!has) {
            PLog.LogError($"不存在Wave:{typeID}");
            return null;
        }

        LevelEntity wave = new LevelEntity();
        wave.entityID = idService.waveIDRecord++;
        wave.typeID = typeID;
        wave.level = tm.level;
        wave.spawnMaintainSec = tm.spawnMaintainSec;

        wave.spawnModels = new LevelSpawnModel[tm.spawnTMs.Length];
        for (int i = 0; i < tm.spawnTMs.Length; i += 1) {
            LevelSpawnTM spawnTM = tm.spawnTMs[i];
            LevelSpawnModel spawnModel = new LevelSpawnModel();
            spawnModel.beginTime = spawnTM.beginTime;
            spawnModel.endTime = spawnTM.endTime;
            spawnModel.interval = spawnTM.interval;
            spawnModel.timer = spawnTM.interval;
            spawnModel.count = spawnTM.count;
            spawnModel.entityType = spawnTM.entityType;
            spawnModel.entityTypeID = spawnTM.entityTypeID;

            wave.spawnModels[i] = spawnModel;
        }

        wave.time = 0;

        return wave;
    }

}