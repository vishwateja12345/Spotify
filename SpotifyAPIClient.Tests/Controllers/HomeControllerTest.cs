﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpotifyAPIClient;
using SpotifyAPIClient.Controllers;

namespace SpotifyAPIClient.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void CheckAlbumDataIsnotOrNot()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.GetAlbums() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CheckArtistDataIsnotOrNot()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.GetArtists() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
