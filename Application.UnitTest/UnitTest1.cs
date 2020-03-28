using System;
using Xunit;
using Api.Controllers;
using Application.Persistence;
using Application.Persistence.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Application.UnitTest
{
    public class UnitTest1
    {
        /*
        private  Deneme _deneme;
        public UnitTest1()
        {
            _deneme=new Deneme();
        }*/
        private UserController _userController;
        BlogDbContext _blogDbContext;
        public UnitTest1()
        {
           
            _userController=new UserController(_blogDbContext);
        }


        [Fact]
        public   void Test1()
        {
            /*
           var result=_userController.MetotDeneme(5);
           Assert.Equal(40,result);
           */
            /*
             var testGuid = new Guid("2347674e-2f93-49bd-ec27-08d7c8cd6404");
             var result = _userController.Get(testGuid);
             Assert.IsType<OkObjectResult>(result.Result);
             */
            // Arrange
            var testGuid = new Guid("2347674e-2f93-49bd-ec27-08d7c8cd6404");

            // Act
            var okResult = _userController.Get(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);


        }
    }
}
