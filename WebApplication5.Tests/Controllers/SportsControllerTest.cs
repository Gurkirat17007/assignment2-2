using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication5.Controllers;
using WebApplication5.Models;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace WebApplication5.Tests.Controllers
{
    [TestClass]
    public class SportsControllerTest
    {
        // global variables needed for multiple tests in this class
        SportsController controller;
        Mock<ISportsMock> mock;
        List<Sport> sports;

        [TestInitialize]
        public void TestInitalize()
        {
            // this method runs automatically before each individual test

            // create a new mock data object to hold a fake list of albums
            mock = new Mock<ISportsMock>();

            // populate mock list
            sports = new List<Sport>
            {
                new Sport { Boys = 200, Soccer = "Real Madrid",  Rugby= "OBJ" },


                               new Sport { Baseball = "Yankee", Soccer = "Man United",  Rugby= "Rock" }



            };
            mock.Setup(m => m.Sports).Returns(sports.AsQueryable());
            controller = new SportsController(mock.Object);
        }

[TestMethod]
        public void IndexLoadsView()
        {
            // arrange - now moved to TestInitialize for code re-use
           // SportsController controller = new SportsController();

            // act
           var result = controller.Index();

            // assert
            Assert.IsNotNull( result);
        }

        [TestMethod]
        public void IndexReturnsSports()
        {
            // act
            var result = (List<Sport>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(sports, result);
        }
        // GET: Details/Sports
        [TestMethod]
        public void DetailsNoId()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(null);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidId()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(101);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DetailsValidIdLoadsView()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(200);

            // assert
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void DetailsValidIdLoadsSport()
        {
            // act
            Sport result = (Sport)((ViewResult)controller.Details(200)).Model;

            // assert
            Assert.AreEqual(sports[0], result);
        }

        //POST:Sports/Create
        [TestMethod]
        public void SportSavedAndRedirected()
        {
            //act
            var result = (RedirectToRouteResult)controller.Create(sports[0]);

            //assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        [TestMethod]
        public void SportsBoysNotNull()
        {

            //act
            controller.ModelState.AddModelError("some error name", "fake error description");
            var result = (ViewResult)this.controller.Create(this.sports[0]);

            //assert
            Assert.IsNotNull(result.ViewBag.Boys);
        }

        [TestMethod]
        public void EditNoId()
        {
            // arrange
            int? id = null;

            // act 
            ViewResult result = (ViewResult)controller.Edit(id);
            // assert 
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void EditInvalidId()
        {
            // act 
            ViewResult result = (ViewResult)controller.Edit(10000);

            // assert 
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void EditValidIdLoadsView()
        {
            // act 
            ViewResult result = (ViewResult)controller.Edit(200);

            // assert 
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditValidIdLoadsSport()
        {
            // act 
            Sport result = (Sport)((ViewResult)controller.Edit(200)).Model;

            // assert 
            Assert.AreEqual(sports[0], result);
        }

        [TestMethod]
        public void EditReturnsBoysViewBag()
        {
            // act 
            ViewResult result = controller.Edit(200) as ViewResult;

            // assert 
            Assert.IsNotNull(result.ViewBag.Boys);
        }

        // POST: Sports/Edit

        [TestMethod]
        public void ModelValidIndexLoaded()
        {
            // act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Edit(sports[0]);

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

     

        // GET: Sports/Delete


        [TestMethod]
        public void DeleteNoId()
        {
            // act
            ViewResult result = (ViewResult)controller.Delete(null);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteInvalidId()
        {
            // act
            ViewResult result = (ViewResult)controller.Delete(309);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteValidIdReturnSport()
        {
            // act
            Sport result = (Sport)((ViewResult)controller.Delete(200)).Model;

            // assert
            Assert.AreEqual(sports[0], result);
        }

        [TestMethod]
        public void DeleteValidIdReturnView()
        {
            // act
            ViewResult result = (ViewResult)controller.Delete(200);

            // assert
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedNoId()
        {
            // act
            ViewResult result = (ViewResult)controller.DeleteConfirmed(1);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }


        [TestMethod]
        public void DeleteConfirmedInvalidId()
        {
            // act
            ViewResult result = (ViewResult)controller.DeleteConfirmed(1000);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteWorks()
        {
            // act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.DeleteConfirmed(200);

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }

}
