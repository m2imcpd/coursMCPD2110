using coursCSharp.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            IDe de1 = new FauxDe(5);
            IDe de2 = new FauxDe(3);
            bool result = jeu.Jouer(de1, de2);
            Assert.IsTrue(result);
        }
    }
}
