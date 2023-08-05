# WannaBeVM

![image](https://github.com/AlexRasch/WannaBeVM/assets/46262688/430cced8-a17b-46f2-8143-ff1098fab3b0)
WannaBeVM is a simple virtual machine (VM) written in C#. It interprets a bytecode representation of basic mathematical operations.

## Usage

To use WannaBeVM, you can call it like this:

```csharp
byte[] bytecode = new byte[]
{
    1, 10,      // Push 10 onto the stack
    1, 5,       // Push 5 onto the stack

    2,          // Add the top two numbers (10 + 5 = 15)

    1, 3,       // Push 3 onto the stack

    4,          // Multiply the top two numbers (15 * 3 = 45)

    5,          // Divide the top two numbers (45 / 3 = 15)

    6           // Return the output (15)
};

VirtualMachine vm = new VirtualMachine();
int result = vm.Interpret(bytecode);
Console.WriteLine("Result: " + result); // Output: Result: 15
```
