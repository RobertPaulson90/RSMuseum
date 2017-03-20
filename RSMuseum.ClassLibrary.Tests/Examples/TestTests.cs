using RSMuseum.ClassLibrary.Models;
using SimpleInjector;
using Xunit;
using Moq;

namespace RSMuseum.ClassLibrary.Tests
{
    public class TestTests
    {

        public TestTests()
        {
            new DI(true);
        }

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        //[Fact]
        //public void FailingTest()
        //{
        //    Assert.Equal(5, Add(2, 2));
        //}

        private int Add(int x, int y)
        {
            return x + y;
        }

        [Fact]
        public void MockTest()
        {
            var mock = new Mock<ITestModel>();
            //mock.Object.Age = DI.Container.GetInstance<ITestModel>;

            mock.Object.PrintAge();

            Assert.Equal(mock.Object.PrintAge(), 15);
        }
    }
}