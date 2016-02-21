using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using CallData.Controllers;
using CallData.Models;
using CallData.Models.Abstract;
using Xunit;
using Moq;

namespace UnitTests
{
    public class Tests
    {
        [Fact]
        public void Get_Returns_Bill_With_Passed_Id()
        {
            // Arrange
            var mockRepository = new Mock<IBillRepository>();
            mockRepository.Setup(x => x.GetById(1)).Returns(new Bill { Id = 1, Name = "Cool Bill"});

            var controller = new BillsController(mockRepository.Object);

            // Act
            var action = controller.Get(1);
            var contentResult = action as OkNegotiatedContentResult<Bill>;
             
            // Assert
            Assert.NotNull(contentResult);
            Assert.NotNull(contentResult.Content);
            Assert.Equal(1, contentResult.Content.Id);
        }

        [Fact]
        public void GetAll_Returns_AllBills()
        {
            // Arrange
            var mockRepository = new Mock<IBillRepository>();
            mockRepository.Setup(x => x.GetAll()).Returns(new []{
                new Bill { Id = 1, Name = "Cool Bill" },
                new Bill { Id = 2, Name = "Cool Bill #2" },
                new Bill { Id = 3, Name = "Cool Bill #3" }
            });

            var controller = new BillsController(mockRepository.Object);

            // Act
            var action = controller.GetAll();

            // Assert
            Assert.Equal(3, action.Count());
        }

    }
}