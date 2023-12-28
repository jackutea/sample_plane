using System.Numerics;
using Raylib_cs;

public class PlaneEntity {
    
    public int entityID;
    public int typeID;

    public Vector2 pos;
    public float moveSpeed;

    public int hp;
    public int hpMax;

    // Draw
    public Color color;
    public ShapeType shapeType; // Rectangle, Circle
    public Vector2 size;

}