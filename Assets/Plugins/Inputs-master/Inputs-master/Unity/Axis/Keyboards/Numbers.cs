namespace Plugins.Inputs_master.Inputs_master.Unity.Axis.Keyboards
{
    public class Numbers<T>
    {
        private IValue<T> _positive;
        private IValue<T> _negative;
        private IValue<T> _null;

        public Numbers(IValue<T> positive, IValue<T> negative, IValue<T> @null)
        {
            _positive = positive;
            _negative = negative;
            _null = @null;
        }


        public T Positive() => _positive.Evaluate();
        public T Negative() => _negative.Evaluate();
        public T Null() => _null.Evaluate();
    }
}