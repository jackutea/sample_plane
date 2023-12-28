using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

public class Template {

    Dictionary<int, PlaneTM> planeTemplate;

    public Template() {
        planeTemplate = new Dictionary<int, PlaneTM>();
    }

    public void Init() {
        // 硬编码
        planeTemplate.Add(1, Create(1, 50, 1, Color.RED, ShapeType.Rectangle, new Vector2(50, 30)));
        planeTemplate.Add(2, Create(2, 40, 10, Color.PINK, ShapeType.Circle, new Vector2(50, 50)));
        planeTemplate.Add(3, Create(3, 30, 2, Color.BLUE, ShapeType.Circle, new Vector2(30, 30)));
        planeTemplate.Add(4, Create(4, 20, 5, Color.BLACK, ShapeType.Rectangle, new Vector2(30, 50)));
        planeTemplate.Add(5, Create(5, 0, 3, Color.YELLOW, ShapeType.Rectangle, new Vector2(100, 100)));

        // 1. 从硬盘加载文件
        // 2. 解析类型
        // 3. Add
    }

    public bool TryGetPlane(int typeID, out PlaneTM tm) {
        return planeTemplate.TryGetValue(typeID, out tm);
    }

    PlaneTM Create(int typeID, float moveSpeed, int hp, Color color, ShapeType shapeType, Vector2 size) {
        PlaneTM planeTM = new PlaneTM();
        planeTM.typeID = typeID;
        planeTM.moveSpeed = moveSpeed;
        planeTM.hp = hp;
        planeTM.color = color;
        planeTM.shapeType = shapeType;
        planeTM.size = size;
        return planeTM;
    }

}