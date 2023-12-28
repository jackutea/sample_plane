using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

public class Template {

    Dictionary<int, PlaneTM> planeTemplate;
    Dictionary<int, LevelTM> levelTemplate;

    public Template() {
        planeTemplate = new Dictionary<int, PlaneTM>();
        levelTemplate = new Dictionary<int, LevelTM>();
    }

    public void Init(float baseSize) {

        // 硬编码
        // - Plane
        planeTemplate.Add(1, CreatePlane(1, 50, MoveType.ByLine, 1, Color.RED, ShapeType.Rectangle, new Vector2(2, 2) * baseSize));
        planeTemplate.Add(2, CreatePlane(2, 40, MoveType.ByLine, 10, Color.PINK, ShapeType.Circle, new Vector2(2, 2) * baseSize));
        planeTemplate.Add(3, CreatePlane(3, 30, MoveType.ByLine, 2, Color.BLUE, ShapeType.Circle, new Vector2(2, 2) * baseSize));
        planeTemplate.Add(4, CreatePlane(4, 20, MoveType.ByLine, 5, Color.BLACK, ShapeType.Rectangle, new Vector2(2, 2) * baseSize));
        planeTemplate.Add(5, CreatePlane(5, 0, MoveType.DontMove, 3, Color.YELLOW, ShapeType.Rectangle, new Vector2(2, 2) * baseSize));

        planeTemplate.Add(TypeIDConst.PLAYER_PLANE_TYPEID, CreatePlane(5, 100, MoveType.ByInput, 100, Color.GREEN, ShapeType.Circle, new Vector2(2, 2) * baseSize));

        InitLevel();

        // 1. 从硬盘加载文件
        // 2. 解析类型
        // 3. Add

    }

    // Plane
    public bool TryGetPlane(int typeID, out PlaneTM tm) {
        return planeTemplate.TryGetValue(typeID, out tm);
    }

    PlaneTM CreatePlane(int typeID, float moveSpeed, MoveType moveType, int hp, Color color, ShapeType shapeType, Vector2 size) {
        PlaneTM planeTM = new PlaneTM();
        planeTM.typeID = typeID;
        planeTM.moveSpeed = moveSpeed;
        planeTM.moveType = moveType;
        planeTM.hp = hp;
        planeTM.color = color;
        planeTM.shapeType = shapeType;
        planeTM.size = size;
        return planeTM;
    }

    // Level
    void InitLevel() {

        // 关卡 -> 波次 -> Entity

        // L1
        LevelTM l1 = new LevelTM();
        l1.typeID = 1;
        l1.level = 1;
        l1.spawnMaintainSec = 60f; // 这个时间到了不再生成任何东西

        LevelSpawnTM[] l1_arr = new LevelSpawnTM[2];

        // L1: 第一种敌机
        LevelSpawnTM l1_s1 = new LevelSpawnTM();
        l1_s1.beginTime = 0;
        l1_s1.endTime = 6f;
        l1_s1.interval = 2f;
        l1_s1.count = 1;
        l1_s1.entityType = EntityType.Plane;
        l1_s1.entityTypeID = 1;
        l1_arr[0] = l1_s1;

        // L1: 第二种敌机
        LevelSpawnTM l1_s2 = new LevelSpawnTM();
        l1_s2.beginTime = 4;
        l1_s2.endTime = 60f;
        l1_s2.interval = 2f;
        l1_s2.count = 1;
        l1_s2.entityType = EntityType.Plane;
        l1_s2.entityTypeID = 2;
        l1_arr[1] = l1_s2;

        // TODO: 食物

        // TODO: 子弹

        l1.spawnTMs = l1_arr;

        levelTemplate.Add(1, l1);

    }

    public bool TryGetLevel(int typeID, out LevelTM tm) {
        return levelTemplate.TryGetValue(typeID, out tm);
    }

}