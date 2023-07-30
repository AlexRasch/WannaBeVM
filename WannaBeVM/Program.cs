using System;


namespace WannaBeVM
{
    public class WannaBeVM
    {
        public class Program
        {
            public static void Main()
            {
                byte[] bytecode = new byte[]
                {
                    1, 10,      // Push 10 onto the stack
                    1, 5,       // Push 5 onto the stack

                    2,          // Add the top two numbers (10 + 5 = 15)

                    1, 3,       // Push 3 onto the stack

                    4,          // Multiply the top two numbers (45)

                    5,          // Dividethe top two numbers (45 / 3 = 15)

                    6           // Update output (15)
                };

                VirtualMachine vm = new VirtualMachine();
                int returnValue = vm.Interpret(bytecode);

                Console.WriteLine($"Result: {returnValue}");
                Console.ReadLine();
            }
        }

    }
}



