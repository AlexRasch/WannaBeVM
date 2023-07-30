using WannaBeVM;

namespace VirtualMachineTests
{
    public class CalculatorTest
    {
        [Fact]
        public void Sum_of_2_and_2_Should_be_4()
        {
            // Arrange
            byte[] bytecode = new byte[]
            {
                // Push 2 onto the stack
                1, 2,
                // Push 2 onto the stack
                1, 2,
                // Add the top two numbers
                2,
                // Return top number from stack
                6,
            };

            // Act
            VirtualMachine vm = new VirtualMachine();

            // Assert
            Assert.Equal(4, vm.Interpret(bytecode));
        }

        [Fact]
        public void Sum_of_4_substract_2_Should_be_2()
        {
            // Arrange
            byte[] bytecode = new byte[]
            {
                // Push 4 onto the stack
                1, 4,
                // Push 2 onto the stack
                1, 2,
                // Substract the top two numbers
                3,
                // Return top number from stack
                6,
            };

            // Act
            VirtualMachine vm = new VirtualMachine();

            // Assert
            Assert.Equal(2, vm.Interpret(bytecode));
        }

        [Fact]
        public void Sum_of_4_multiply_2_Should_be_8()
        {
            // Arrange
            byte[] bytecode = new byte[]
            {
                // Push 4 onto the stack
                1, 4,
                // Push 2 onto the stack
                1, 2,
                // Multiply the top two numbers
                4,
                // Return top number from stack
                6,
            };

            // Act
            VirtualMachine vm = new VirtualMachine();

            // Assert
            Assert.Equal(8, vm.Interpret(bytecode));
        }
    }
}