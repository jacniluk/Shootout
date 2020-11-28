// Player character in game
public class Player : Character
{
    // When bullet hit player
    override public void Hit()
    {
        base.Hit();

        CharactersManager.Instance.SetPlayerDead();
    }
}
