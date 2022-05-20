namespace Plugins.Inputs_master.Inputs_master.Unity.Axis.Decorators
{
    public abstract class AxisDecorator : IAxis
    {
        protected readonly IAxis ChildAxis;

        public AxisDecorator(IAxis childAxis)
        {
            ChildAxis = childAxis;
        }

        public abstract float Input();
    }
}