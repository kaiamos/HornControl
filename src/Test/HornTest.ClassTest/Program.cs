namespace HornTest.ClassTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (MyClass caryClass = new MyClass())
            //{
            //    caryClass.DoSomething();
            //}

            MyClass myClass = new MyClass();
            try
            {
                myClass.DoSomething();
            }
            finally
            {
                IDisposable disposable = myClass as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            Console.ReadLine();

        }
    }
}
