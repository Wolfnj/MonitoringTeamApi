using System;
using Xunit;
using MonitoringTeamApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MonitoringTeamApi.Models;
using System.Collections.Generic;

namespace Api_tests
{
    public class LogsControllerTest
    {

        LogsController controller;
        CoreDbContext context;



        public LogsControllerTest()
        {
            context = new CoreDbContext();
            controller = new LogsController(context);
        }



        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = controller.GetLogs();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result.Result);



        }





        [Fact]
        public void GetById_UnknownId_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = controller.GetLogs(0);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result.Result);
        }




        [Theory]
        [InlineData(2221, "03/07/2020:1421", "Dude1@gmail.com", "03/07/2020:1421", "03/07/2020:1435","1","5min","HomePage",1112,null)]
        [InlineData(2223, "03/07/2020:1427", "LABeast@gmail.com", "03/04/2020:1421", "03/07/2020:1435", "6", "12min", "YetAnotherPage", 1114, null)]
        public void GetById_ExistingId_ReturnsRightItem(int id, string timeStamp, string user, string timeLogedIn, 
            string timeLogedOut, string numberOfPageViews, string sessionDuration, string pageTitle, int pageInfoId,
            string pageInfo)
        {


            // Act
            var okResult = controller.GetLogs(id);


            

            Logs lg = okResult.Result.Value as Logs;

            // Assert
            Assert.Equal(id, lg.Id);
            Assert.Equal(timeStamp, lg.TimeStamp);
            Assert.Equal(user, lg.UserName);
            Assert.Equal(timeLogedIn, lg.TimeLoggedIn);
            Assert.Equal(timeLogedOut, lg.TimeLoggedOut);
            Assert.Equal(numberOfPageViews, lg.NumberOfPageViews);
            Assert.Equal(sessionDuration, lg.SessionDuration);
            Assert.Equal(pageTitle, lg.PageTitle);
            Assert.Equal(pageInfoId, lg.PageInfoId);
          


        }







        [Fact]
        public void Put_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange

            Logs newLog = new Logs()
            {
                Id = 21,
                TimeStamp = "Fake",
                UserName = "Fake",
                TimeLoggedIn = "Fake",
                TimeLoggedOut = "Fake",
                NumberOfPageViews = "Fake",
                SessionDuration = "Fake",
                PageTitle = "Fake",
                PageInfoId = 3,
                PageInfo = null
            };


            var result = controller.PutLogs(23, newLog);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }










        [Fact]
        public void Put_LogDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            Logs newLog = new Logs()
            {
                Id = 23,
                TimeStamp = "Fake",
                UserName = "Fake",
                TimeLoggedIn = "Fake",
                TimeLoggedOut = "Fake",
                NumberOfPageViews = "Fake",
                SessionDuration = "Fake",
                PageTitle = "Fake",
                PageInfoId = 3,
                PageInfo = null
            };


            var result = controller.PutLogs(23, newLog);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }





        [Fact]
        public void Post_ValidLog_ReturnsCreatedAtAction()
        {

            Logs newLog = new Logs()
            {

                TimeStamp = "04/03/2020:1421",
                UserName = "SupDude123@yahoo.com",
                TimeLoggedIn = "04/03/2020:1421",
                TimeLoggedOut = "04/03/2020:1435",
                NumberOfPageViews = "5",
                SessionDuration = "8min",
                PageTitle = "YetAnotherPage",
                PageInfoId = 1114,
                PageInfo = null
            };

            var result = controller.PostLogs(newLog);


            Assert.IsType<CreatedAtActionResult>(result.Result.Result);


        }






        [Fact]
        public void Delete_IdNotFoundForDelete_ReturnsNotFound()
        {


            var result = controller.DeleteLogs(12);


            Assert.IsType<NotFoundResult>(result.Result.Result);


        }










        [Fact(Skip = "ID needs to be updated to work")]
        public void Delete_IdFoundForDelete_ReturnsOriginalLog()
        {



            var result = controller.DeleteLogs(2242);



            Assert.IsType<OkObjectResult>(result.Result.Result);


        }















































    }
}
