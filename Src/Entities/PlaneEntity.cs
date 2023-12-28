using System;
using System.Numerics;
using Raylib_cs;

public class PlaneEntity {

    public int entityID;
    public int typeID;
    public AllyStatus ally;
    public MoveType moveType;

    public Vector2 pos;
    public float moveSpeed;

    public int hp;
    public int hpMax;

    // Draw
    public Color color;
    public ShapeType shapeType; // Rectangle, Circle
    public Vector2 size;

    public PlaneEntity() { }

    public void Move(Vector2 dir, float dt) {
        pos += Raymath.Vector2Normalize(dir) * moveSpeed * dt;
    }

    public void Draw() {
        if (shapeType == ShapeType.Rectangle) {
            // size: 宽 高
            Raylib.DrawRectangleV(pos, size, color);
        } else if (shapeType == ShapeType.Circle) {
            // size: 半径
            Raylib.DrawCircleV(pos, size.X / 2, color);
        } else {
            PLog.LogError("不存在该形状" + shapeType.ToString());
        }
    }

}