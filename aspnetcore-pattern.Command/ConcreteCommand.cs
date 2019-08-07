namespace aspnetcore_pattern.Command
{
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }
}
