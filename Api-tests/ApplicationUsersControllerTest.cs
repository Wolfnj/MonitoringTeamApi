using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringTeamApi.Models;
using MonitoringTeamApi.Controllers;
using Xunit;

namespace Api_tests
{
    public class ApplicationUsersControllerTest
    {



        ApplicationUsersController controller;
        CoreDbContext context;



        public ApplicationUsersControllerTest()
        {
            context = new CoreDbContext();
            controller = new ApplicationUsersController(context);
        }



        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = controller.GetApplicationUser();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result.Result);

        }






        [Fact]
        public void GetById_UnknownId_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = controller.GetApplicationUser(0);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result.Result);



        }











        [Theory]
        [InlineData(1234, "437b05e9-f1f4-4ca0-943d-c191808de8d0", 1112, null)]
        public void GetById_ExistingId_ReturnsRightItem(int id, string userId, int pageInfoId, Pages pageInfo)
        {


            // Act
            var okResult = controller.GetApplicationUser(id);




            ApplicationUser au = okResult.Result.Value as ApplicationUser;

            // Assert
            Assert.Equal(id, au.Id);
            Assert.Equal(userId, au.UserId);
            Assert.Equal(pageInfoId, au.PageInfoId);
            Assert.Equal(pageInfo, au.PageInfo);
      




        }






        [Fact]
        public void Put_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange





            ApplicationUser newApplicationUser = new ApplicationUser()
            {
                Id = 21,
                UserId = "437b05e9-f1f4-4ca0-943d-c191808de8d0",
                PageInfoId = 1112,
                PageInfo = null,
                User = null,
            };






            var result = controller.PutApplicationUser(1234, newApplicationUser);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }





        [Fact]
        public void Put_UserDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            ApplicationUser newApplicationUser = new ApplicationUser()
            {
                Id = 23,
                UserId = "437b05e9-f1f4-4ca0-943d-c191808de8d0",
                PageInfoId = 1112,
                PageInfo = null,
                User = null,
            };


            var result = controller.PutApplicationUser(23, newApplicationUser);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }









        [Fact]
        public void Post_ValidUser_ReturnsCreatedAtAction()
        {

            ApplicationUser newApplicationUser = new ApplicationUser()
            {
                UserId = "437b05e9-f1f4-4ca0-943d-c191808de8d0",
                PageInfoId = 1112,
                PageInfo = null,
                User = null,
            };

            var result = controller.PostApplicationUser(newApplicationUser);


            Assert.IsType<CreatedAtActionResult>(result.Result.Result);


        }







        [Fact]
        public void Delete_IdNotFoundForDelete_ReturnsNotFound()
        {


            var result = controller.DeleteApplicationUser(12);


            Assert.IsType<NotFoundResult>(result.Result.Result);


        }






        [Fact(Skip = "ID needs to be updated to work")]
        public void Delete_IdFoundForDelete_ReturnsOriginalLog()
        {



            var result = controller.DeleteApplicationUser(1243);



            Assert.IsType<OkObjectResult>(result.Result.Result);


        }









    }
}
