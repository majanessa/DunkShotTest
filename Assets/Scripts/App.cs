namespace DunkShot
{
    public class App
    {
        private static class InstanceRegister<T> where T : class, new()
        {
            public static readonly T Instance = new T();
        }
    
        public static T GetModel<T>() where T : class, new()
        {
            return InstanceRegister<T>.Instance;
        }
    }
}
