using Space_Shooter;

public static class Globals
{
    public static readonly int COLLIDER_WIDTH = 90;
    public static readonly int COLLIDER_HEIGHT = 45;
    public static readonly int LEFT_OFFSET = 1;
    public static readonly int TOP_OFFSET = 1;
    public static readonly int PLAYER_LAYER = 1;
    public static readonly int ENEMIES_LAYER = 2;
    public static GameState GAMESTATE;
    public static int CURRENT_SCORE = 0;
    public static readonly int MIN_ENEMY_SPAWN_TIME = 1000;
    public static readonly int STARTING_ENEMY_SPAWN_TIME = 5000;
    public static readonly int DECREASE_ENEMY_SPAWN_TIME = 250;
}