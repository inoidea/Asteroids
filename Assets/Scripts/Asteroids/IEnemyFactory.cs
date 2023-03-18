namespace Asteroids
{
    public interface IEnemyFactory
    {
        Enemy Create(float hp);
    }
}
