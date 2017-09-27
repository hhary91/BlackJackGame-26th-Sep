using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using consoleapp;

namespace Unittstproj
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void shuffle()
        {
            Program.cardfn prgcrdfn = new Program.cardfn();
            prgcrdfn.shuffle();
        }
        [TestMethod]
        public void Deal10()
        {
            Program.cardfn prgcrdfn = new Program.cardfn();
            prgcrdfn.deal(10);
        }
        [TestMethod]
        public void Deal2()
        {
            Program.cardfn prgcrdfn = new Program.cardfn();
            prgcrdfn.deal(2);
        }
        [TestMethod]
        public void continuecardpickup()
        {
            Program.cardfn prgcrdfn = new Program.cardfn();
            prgcrdfn.continuecardpickup();
        }
        [TestMethod]
        public void computerdynamicpickupcard()
        {
            Program.cardfn prgcrdfn = new Program.cardfn();
            prgcrdfn.globalvar.dynamiccount = 0;
            prgcrdfn.globalvar.computershand = prgcrdfn.deal(2);
            prgcrdfn.computerdynamicpickupcardfn();
        }
        [TestMethod]
        public void computerdynamicpickupcardfn()
        {
            Program.cardfn prgcrdfn = new Program.cardfn();
            prgcrdfn.globalvar.dynamiccount = 10;
            prgcrdfn.globalvar.computershand = prgcrdfn.deal(2);
            prgcrdfn.computerdynamicpickupcardfn();
        }
        [TestMethod]
        public void shufflefn()
        {
            Program.cardfn prgcrdfn = new Program.cardfn();
            prgcrdfn.deal(2);
            prgcrdfn.shuffle();
        }
    }
}
