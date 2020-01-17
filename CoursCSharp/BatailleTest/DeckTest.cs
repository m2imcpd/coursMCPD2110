using CorrectionBataille.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BatailleTest
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void CreateTest()
        {
            Deck deck = new Deck();
            deck.Create();
            Assert.AreEqual(52, deck.Cartes.Count);
        }
        [TestMethod]
        public void CreateTest_Nombre_Carte()
        {
            Deck deck = new Deck();
            deck.Create();
            Assert.AreEqual(4, deck.Cartes.FindAll(x=>x.Valeur==14).Count);
        }

        [TestMethod]
        public void DistribuerTest()
        {
            IJoueur j1 = Mock.Of<IJoueur>();
            IJoueur j2 = Mock.Of<IJoueur>();
            j1.Cartes = new List<Carte>();
            j2.Cartes = new List<Carte>();
            Deck deck = new Deck();
            deck.Create();
            deck.Distribuer(j1, j2);
            Assert.AreEqual(26, j1.Cartes.Count);
        }
    }
}
