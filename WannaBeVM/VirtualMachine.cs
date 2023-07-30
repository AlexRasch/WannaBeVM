using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WannaBeVM
{
    public class VirtualMachine
    {

        public int Interpret(byte[] bytecode)
        {
            int ip = 0;         // Instruction pointer
            int stackSize = 0;
            int[] stack = new int[bytecode.Length];
            int returnValue = 0;

            while (ip < bytecode.Length)
            {
                byte instruction = bytecode[ip];

                switch (instruction)
                {
                    // Remove a number from the stack
                    case 0:
                        stackSize--;
                        ip++;
                        break;

                    // Push a number onto the stack
                    case 1:
                        stack[stackSize++] = bytecode[ip + 1];
                        ip += 2;
                        break;

                    // Add the top two numbers on the stack
                    case 2:
                        stack[stackSize - 2] += stack[stackSize - 1];
                        stackSize--;
                        ip++;
                        break;

                    // Subtract the top two numbers on the stack
                    case 3:
                        stack[stackSize - 2] -= stack[stackSize - 1];
                        stackSize--;
                        ip++;
                        break;

                    // Multiply the top two numbers on the stack
                    case 4:
                        if (stackSize >= 2)
                        {
                            stack[stackSize - 2] *= stack[stackSize - 1];
                            //stackSize--;
                        }
                        else
                        {
                            throw new InvalidOperationException("Not enough elements on the stack to perform multiplication.");
                        }
                        ip++;
                        break;


                    // Divide the top two numbers on the stack
                    case 5:
                        if (stackSize >= 2)
                        {
                            if (stack[stackSize - 1] != 0)
                                stack[stackSize - 2] /= stack[stackSize - 1];
                            else
                                throw new DivideByZeroException("Division by zero is not allowed.");
                            //stackSize -= 2; // Remove both divisor and dividend from the stack
                        }
                        else
                        {
                            throw new InvalidOperationException("Not enough elements on the stack to perform division.");
                        }
                        ip++;
                        break;

                    // Return the top number on the stack
                    case 6:
                        returnValue = stack[0];
                        stackSize--;
                        ip++;
                        break;

                    // Return the bottom number on the stack
                    case 7:
                        returnValue = stack[0];
                        ip++;
                        break;

                    // Get the remainder of the top two numbers on the stack
                    case 8:
                        if (stackSize >= 2)
                        {
                            int divisor = stack[stackSize - 1]; // Store the divisor in a temporary variable
                            stack[stackSize - 2] %= divisor; // Get the remainder (last digit)
                            stack[stackSize - 2] *= 10; // Multiply the current result by 10
                        }
                        else
                        {
                            throw new InvalidOperationException("Not enough elements on the stack to perform modulo operation.");
                        }
                        ip++;
                        break;

                    default:
                        throw new InvalidOperationException("Invalid bytecode instruction: " + instruction);
                }
            }

            return returnValue;
        }
    }

}
