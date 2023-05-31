using System.Collections.Generic;
using System;
using NUnit.Framework;
using System.Web.Mvc;
using MvcMusicStore.Models;
using MvcMusicStore.ViewModels;
using System.Linq;

namespace MvcMusicStore.Controllers
{
    public class UnitTestForAddToCart
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        [Test]
        public void IsProductAvailable()
        {
            int id = 5; //assume the id is 5
            var addedAlbum = storeDB.Albums
                .Single(album => album.AlbumId == id);

            ShoppingCart sCart = new ShoppingCart();
            sCart.AddToCart(addedAlbum);
            int c = sCart.GetCount();
            // Assert
            Assert.IsNotNull(addedAlbum);

            //........... we can add her all possible cases 

        }
    }
}
