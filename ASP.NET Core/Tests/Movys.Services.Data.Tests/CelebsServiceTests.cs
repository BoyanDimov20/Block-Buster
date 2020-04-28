namespace Movys.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Moq;
    using Movys.Data.Common.Repositories;
    using Movys.Data.Models;
    using Movys.Services.Mapping;
    using Movys.Web.ViewModels.Celebs;
    using Xunit;

    public class CelebsServiceTests
    {
        [Fact]
        public void NotNullIfEmpty()
        {
            var mockService = new Mock<ICelebsService>();
            mockService.Setup(r => r.GetAll<SingleCelebViewModel>()).Returns(new List<SingleCelebViewModel>
            {
            }.AsQueryable());

            Assert.NotNull(mockService.Object.GetAll<SingleCelebViewModel>());
            mockService.Verify(x => x.GetAll<SingleCelebViewModel>(), Times.Once);
        }

        [Fact]
        public void GetCountIfSingle()
        {
            var mockService = new Mock<ICelebsService>();
            mockService.Setup(r => r.GetAll<SingleCelebViewModel>()).Returns(new List<SingleCelebViewModel>
            {
                new SingleCelebViewModel(),
            }.AsQueryable());

            Assert.Single(mockService.Object.GetAll<SingleCelebViewModel>());
            mockService.Verify(x => x.GetAll<SingleCelebViewModel>(), Times.Once);
        }

    }
}
