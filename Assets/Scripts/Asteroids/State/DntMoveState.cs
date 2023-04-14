namespace Asteroids.State
{
    public sealed class DntMoveState : State
    {
        public override void Handle(Context context)
        {
            context.State = new MoveState();
        }
    }
}
