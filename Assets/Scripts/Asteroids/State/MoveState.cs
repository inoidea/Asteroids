namespace Asteroids.State
{
    public sealed class MoveState : State
    {
        public override void Handle(Context context)
        {
            context.State = new DntMoveState();
        }
    }
}
