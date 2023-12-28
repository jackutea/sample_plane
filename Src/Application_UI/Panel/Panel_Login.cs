using System.Numerics;
using Raylib_cs;

public class Panel_Login {

    public GUIButton btn_start;

    public Panel_Login() {}

    public void Ctor() {
        btn_start = new GUIButton();
        btn_start.pos = new Vector2(0, 0);
        btn_start.size = new Vector2(160, 30);
        btn_start.color = Color.BLACK;
    }

    public bool IsClickStart() {
        return btn_start.IsClick(Raylib.GetMousePosition(), Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON));
    }

    public void Draw() {
        btn_start.Draw();
    }

}