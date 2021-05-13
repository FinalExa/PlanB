public abstract class State
{
    protected PlayerCharacter _playerCharacter;
    public State(PlayerCharacter playerCharacter)
    {
        _playerCharacter = playerCharacter;
    }
    public virtual void Start()
    {
        return;
    }
}
