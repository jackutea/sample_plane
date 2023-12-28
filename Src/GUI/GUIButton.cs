using System.Numerics;
using Raylib_cs;

public class GUIButton {

    public Vector2 pos;
    public Vector2 size;
    public Color color;

    public GUIButton() {}

    public void Draw() {
        Raylib.DrawRectangleV(pos, size, color);
    }

    public bool IsClick(Vector2 mousePos, bool isDown) {
        if (Raylib.CheckCollisionPointRec(mousePos, new Rectangle(this.pos.X, this.pos.Y, size.X, size.Y))) {
            if (isDown) {
                return true;
            }
        }
        return false;
    }

}