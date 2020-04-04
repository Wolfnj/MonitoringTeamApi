using System;
using Xunit;
using MonitoringTeamApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MonitoringTeamApi.Models;
using System.Collections.Generic;

namespace Api_tests
{
    public class PagesControllerTest
    {







        PagesController controller;
        CoreDbContext context;



        public PagesControllerTest()
        {
            context = new CoreDbContext();
            controller = new PagesController(context);
        }






        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = controller.GetPages();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);



        }



        [Fact]
        public void GetById_UnknownId_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = controller.GetPages(0);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }










        [Theory]
        [InlineData(1112, "03/07/2020:1421", "HomePage", "Bubba")]
        [InlineData(1113, "03/07/2020:1425", "AnotherPage", "Mace Windu")]
        [InlineData(1160, "4/3/2020 5:35:53 PM", "Bicycles", "LogansTest")]
        [InlineData(1161, "4/3/2020 5:46:37 PM", "Bicycles", "LogansTest")]
        public void GetById_ExistingId_ReturnsRightItem(int id, string timeStamp, string page, string user)
        {


            // Act
            var okResult = controller.GetPages(id);


            Pages pg = okResult.Value as Pages;

            // Assert
            Assert.Equal(id, pg.Id);
            Assert.Equal(timeStamp, pg.TimeStamp);
            Assert.Equal(page, pg.PageTitle);
            Assert.Equal(user, pg.UserName);

        }









        

        [Fact]
        public void Put_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange

            Pages newPage = new Pages()
            {
                Id = 21,
                TimeStamp = "Fake",
                PageTitle = "Fake",
                UserName = "Fake"
            };

                       
            var result = controller.PutPages(23,newPage);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }






        [Fact]
        public void Put_PageDoesNotExist_ReturnsNotFound()
        {
            // Arrange

            Pages newPage = new Pages()
            {
                Id = 23,
                TimeStamp = "Fake",
                PageTitle = "Fake",
                UserName = "Fake"
            };


            var result = controller.PutPages(23, newPage);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }



        [Fact]
        public void Post_ValidPost_ReturnsCreatedAtAction()
        {

            Pages newPage = new Pages()
            {

                TimeStamp = "4/3/2020 6:35:53 PM",
                PageTitle = "NathanPage",
                UserName = "Nathan"
            };

            var result = controller.PostPages(newPage);


            Assert.IsType<CreatedAtActionResult>(result.Result.Result);


        }




        [Fact]
        public void Delete_IdNotFoundForDelete_ReturnsNotFound()
        {


            var result = controller.DeletePages(12);


            Assert.IsType<NotFoundResult>(result.Result.Result);


        }



        
        [Fact(Skip = "ID needs to be updated to work")]
        public void Delete_IdFoundForDelete_ReturnsOriginalPage()
        {

            

            var result = controller.DeletePages(1173);

      

            Assert.IsType<OkObjectResult>(result.Result.Result);


        }
















        /*
                private List<Pages> GetTestPages()
                {
                    var testPages = new List<Pages>();
                    testPages.Add(new Pages {  Id = 1 ,TimeStamp = "03/07/2020:1421", PageTitle = "MyPage", UserName = "Bob" });
                    testPages.Add(new Pages {  Id = 2, TimeStamp = "03/07/2020:1421", PageTitle = "MyPage", UserName = "Bob" });
                    testPages.Add(new Pages {  Id = 3, TimeStamp = "03/07/2020:1421", PageTitle = "MyPage", UserName = "Bob" });
                    testPages.Add(new Pages {  Id = 4, TimeStamp = "03/07/2020:1421", PageTitle = "MyPage", UserName = "Bob" });

                    return testPages;
                }
        */






    }
}
