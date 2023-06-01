using System.Collections.Generic;
using System;
using NUnit.Framework;
using System.Web.Mvc;
using MvcMusicStore.Models;
using MvcMusicStore.ViewModels;
using System.Linq;

namespace MvcMusicStore.Controllers
{

    [TestFixture]
    public class UnitTestForAddToCart
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();


        [Test]
        public void AddToCart_ItemDoesNotExist_ShouldCreateCartItem()
        {
            
            var cart = new ShoppingCart(); // Create an instance of the Cart class
            var album = new Album { AlbumId = 1 }; // Create a sample album

            // Act
            cart.AddToCart(album);

            // Assert
            var cartItem = storeDB.Carts.SingleOrDefault(
                c => c.CartId == cart.ShoppingCartId && c.AlbumId == album.AlbumId);

            Assert.NotNull(cartItem); // Assert that a cart item was created
            Assert.AreEqual(1, cartItem.Count); // Assert that the cart item count is set to 1
        }

        [Test]
        public void AddToCart_ItemExists_ShouldIncrementCount()
        {
            var cart = new ShoppingCart(); // Create an instance of the Cart class
            var album = new Album { AlbumId = 1 }; // Create a sample album

            // Add an existing cart item to the storeDB
            var existingCartItem = new Cart
            {
                AlbumId = album.AlbumId,
                CartId = cart.ShoppingCartId,
                Count = 1
            };
            storeDB.Carts.Add(existingCartItem);

            // Act
            cart.AddToCart(album);

            // Assert
            var cartItem = storeDB.Carts.SingleOrDefault(
                c => c.CartId == cart.ShoppingCartId && c.AlbumId == album.AlbumId);

            Assert.NotNull(cartItem); // Assert that the cart item exists
            Assert.AreEqual(2, cartItem.Count); // Assert that the cart item count is incremented to 2
        }


    }
    }

