using RSMuseum.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace RSMuseum.ClassLibrary.Tests
{
    public class TestTests
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        private int Add(int x, int y)
        {
            return x + y;
        }

        [Fact]
        public void MockTest()
        {
            var mock = new Mock<ITestModel>();
            mock.Setup(foo => foo.Id).Returns(3);
            Assert.Equal(mock.Object.Id, 3);
        }
    }
}