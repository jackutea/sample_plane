using System.Numerics;

public static class Factory {

    public static PlaneEntity CreatePlane(Template template, IDService idService, int typeID, Vector2 pos, AllyStatus ally) {

        bool has = template.TryGetPlane(typeID, out PlaneTM tm);
        if (!has) {
            System.Console.Error.WriteLine($"Factory.CreatePlane: typeID {typeID} not found");
            return null;
        }

        PlaneEntity plane = new PlaneEntity();
        plane.entityID = idService.planeIDRecord++;
        plane.typeID = tm.typeID;

        plane.pos = pos;
        plane.moveSpeed = tm.moveSpeed;

        plane.hp = tm.hp;
        plane.hpMax = tm.hp;

        plane.color = tm.color;
        plane.shapeType = tm.shapeType;
        plane.size = tm.size;

        return plane;

    }

}