using CorrectionBataille.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BatailleTest
{
    [TestClass]
    public class JeuTest
    {
        [TestMethod]
        public void JouerUnTourTest_1()
        {
            Jeu jeu = new Jeu();
            IJoueur j1 = Mock.Of<IJoueur>();
            IJoueur j2 = Mock.Of<IJoueur>();
            j1.Cartes = new List<Carte>();
            j2.Cartes = new List<Carte>();
            j1.Cartes.Add(new Carte { Valeur = 4 });
            j2.Cartes.Add(new Carte { Valeur = 8 });
            jeu.JouerUnTour(j1, j2);
            Assert.AreEqual(2, j2.Cartes.Count);
        }
        [TestMethod]
        public void JouerUnTourTest_2()
        {
            Jeu jeu = new Jeu();
            IJoueur j1 = Mock.Of<IJoueur>();
            IJoueur j2 = Mock.Of<IJoueur>();
            j1.Cartes = new List<Carte>();
            j2.Cartes = new List<Carte>();
            j1.Cartes.Add(new Carte { Valeur = 3 });
            j2.Cartes.Add(new Carte { Valeur = 3 });
            j1.Cartes.Add(new Carte { Valeur = 5 });
            j2.Cartes.Add(new Carte { Valeur = 3 });
            jeu.JouerUnTour(j1, j2);
            Assert.AreEqual(4, j1.Cartes.Count);
        }

        [TestMethod]
        public void JouerTest()
        {
            Jeu jeu = new Jeu();
            IJoueur j1 = Mock.Of<IJoueur>();
            IJoueur j2 = Mock.Of<IJoueur>();
            j1.Cartes = new List<Carte>();
            j2.Cartes = new List<Carte>();
            j1.Cartes.Add(new Carte { Valeur = 2 });
            j2.Cartes.Add(new Carte { Valeur = 5 });
            j1.Cartes.Add(new Carte { Valeur = 3 });
            j2.Cartes.Add(new Carte { Valeur = 7 });
            string result = jeu.Jouer(j1, j2);
            Assert.AreEqual("j2 win", result);
        }
    }
}
