public class Context {

    public int scale;
    public int fps;

    public GameEntity gameEntity;

    // ==== Template ====
    public Template template;

    // ==== Assets ====

    // ==== Service ====
    public IDService idService;

    // ==== Context ====
    public UIContext uiContext;
    public LoginContext loginContext;
    // public GameContext gameContext;

    public Context() {

        gameEntity = new GameEntity();

        template = new Template();
        idService = new IDService();

        uiContext = new UIContext();
        loginContext = new LoginContext();

    }

    public float Scale() {
        return scale;
    }

}