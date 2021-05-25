public class PlayerState : State
{
    protected PlayerCharacter _playerCharacter;
    public PlayerState(PlayerCharacter playerCharacter)
    {
        _playerCharacter = playerCharacter;
        playerCharacter.stateRef = this.ToString();
    }
    public virtual void Collisions(UnityEngine.Collision collision)
    {
        return;
    }
}
