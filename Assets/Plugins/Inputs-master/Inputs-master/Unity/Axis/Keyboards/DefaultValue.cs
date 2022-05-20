namespace Plugins.Inputs_master.Inputs_master.Unity.Axis.Keyboards
{
    public class DefaultValue<T> : IValue<T>
    {
        private T _value;
        
        public DefaultValue(T value)
        {
            _value = value;
        }


        public T Evaluate()
        {
            return _value;
        }
    }
}