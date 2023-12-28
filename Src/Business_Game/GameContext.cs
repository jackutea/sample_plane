public class GameContext {

    public LevelRepo levelRepo;
    public PlaneRepo planeRepo;

    public GameContext() {
        levelRepo = new LevelRepo();
        planeRepo = new PlaneRepo();
    }

}