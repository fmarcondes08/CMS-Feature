using FabricioAssignment.CMSService;
using FabricioAssignment.CMSService.Dto;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FabricioAssignment.Tests.CMS
{
    public class CMSAppService_Tests : FabricioAssignmentTestBase
    {
        private readonly ICMSServiceAppService _cmsAppService;

        public CMSAppService_Tests()
        {
            _cmsAppService = Resolve<ICMSServiceAppService>();
        }

        [Fact]
        public async Task Should_GetCMSContent_Test()
        {
            //Arrange
            var id = new Random().Next(10);

            //Act
            await _cmsAppService.InsertOrUpdateCSMContent(new ContentDto
            {
                Id = id,
                PageName = "Page Name",
                PageContent = "Page Content"
            });

            //Assert
            UsingDbContext(context =>
            {
                context.Content.FirstOrDefault(e => e.Id == id).ShouldNotBe(null);
                context.Content.Single(e => e.Id == id);
            });
        }

        [Fact]
        public async Task Should_InsertOrUpdateCSMContent_Test()
        {
            //Arrange
            var pageName = "Page Name";

            //Act
            await _cmsAppService.InsertOrUpdateCSMContent(new ContentDto
            {
                Id = 0,
                PageName = pageName,
                PageContent = "Page Content"
            });

            //Assert
            UsingDbContext(context =>
            {
                context.Content.FirstOrDefault(e => e.PageName == pageName).ShouldNotBe(null);
            });
        }

        [Fact]
        public async Task Should_Update_InsertOrUpdateCSMContent_Test()
        {
            //Arrange
            var pageName = "Page Name";
            var updatePageName = "Update Page Name";

            //Act
            await _cmsAppService.InsertOrUpdateCSMContent(new ContentDto
            {
                Id = 0,
                PageName = pageName,
                PageContent = "Page Content"
            });

            //Act
            await _cmsAppService.InsertOrUpdateCSMContent(new ContentDto
            {
                Id = 0,
                PageName = updatePageName,
                PageContent = "Page Content"
            });

            //Assert
            UsingDbContext(context =>
            {
                context.Content.FirstOrDefault(e => e.PageName == updatePageName).ShouldNotBe(null);
            });
        }

        [Fact]
        public async Task Should_GetAll_Test()
        {
            //Act
            await _cmsAppService.InsertOrUpdateCSMContent(new ContentDto
            {
                Id = 0,
                PageName = "Page Name 1",
                PageContent = "Page Content"
            });

            //Act
            await _cmsAppService.InsertOrUpdateCSMContent(new ContentDto
            {
                Id = 1,
                PageName = "Page Name 2",
                PageContent = "Page Content"
            });

            // Act
            var output = await _cmsAppService.GetAll();

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }
    }
}
