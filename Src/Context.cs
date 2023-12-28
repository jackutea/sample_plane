public class Context {

    public int windowWidth;
    public int windowHeight;
    public int baseSize;
    public int fps;

    public GameEntity gameEntity;

    // ==== Input ====
    public InputEntity inputEntity;

    // ==== Camera ====
    public CameraEntity cameraEntity;

    // ==== Template ====
    public Template template;

    // ==== Assets ====

    // ==== Service ====
    public IDService idService;

    // ==== Context ====
    public UIContext uiContext;
    public LoginContext loginContext;
    public GameContext gameContext;

    public Context() {

        // Game
        gameEntity = new GameEntity();

        inputEntity = new InputEntity();

        // Camera
        cameraEntity = new CameraEntity();

        // Template
        template = new Template();
        
        // Services
        idService = new IDService();

        uiContext = new UIContext();
        loginContext = new LoginContext();
        gameContext = new GameContext();

    }

}