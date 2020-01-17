using coursCSharp.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpTest
{
    [TestClass]
    public class JeuTest
    {

        [TestMethod]
        public void JouerTest()
        {
            Jeu jeu = new Jeu();
            //IDe de1 = new FauxDe(5);
            //IDe de2 = new FauxDe(3);
            IDe de1 = Mock.Of<IDe>();
            IDe de2 = Mock.Of<IDe>();
            Mock.Get(de1).Setup(m => m.Valeur).Returns(5);
            Mock.Get(de2).Setup(m => m.Valeur).Returns(3);
            bool result = jeu.Jouer(de1, de2);
            Assert.IsTrue(result);
        }
    }
}
