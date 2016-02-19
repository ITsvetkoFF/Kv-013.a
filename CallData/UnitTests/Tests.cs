using Xunit;
using Moq;

namespace UnitTests
{
    public class Tests
    {
        [Fact]
        public void CAN_SHOW_All_BILLS_BY_BILL_NAME()
        {

            Assert.Equal(4, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}