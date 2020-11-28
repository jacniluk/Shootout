// Enemy character in game
public class Enemy : Character
{
    // When bullet hit enemy
    override public void Hit()
    {
        base.Hit();

        CharactersManager.Instance.SetEnemyDead();
    }
}
