using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace TestyJednostkowe {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            Ellipse circle = new Ellipse();

            circle.Width = 2;
            circle.Height = 2;
            Assert.AreEqual(circle.Width, 2);
            Assert.AreEqual(circle.Height, 2);
        }
        [TestMethod]
        public void TestMethod2() {
            Canvas canvas = new Canvas();
            Logika.Controller.spawnCircles(5, canvas);
            Process currentProcess2 = Process.GetCurrentProcess();
            int threadCount2 = currentProcess2.Threads.Count;
            Debug.WriteLine(threadCount2);
            Assert.IsTrue(threadCount2 < 50);
        }

        [TestMethod]
        public void TestMethod3() {
            Dane.CircleList list = new Dane.CircleList();
            Dane.Circle circle1 = new Dane.Circle(5, 5, 5, 5, 10, 1);
            list.AddCircle(circle1);
            Assert.AreEqual(list.CountCircles(), 1);
            Assert.AreEqual(list.GetCircle(0), circle1);
            list.Clear();
            Assert.AreEqual(list.CountCircles(), 0);
        }

        [TestMethod]
        public void TestMethod4() {
            Dane.Circle circle1 = new Dane.Circle(5, 5, 5, 5, 10, 1);
            Assert.AreEqual(circle1.X, 5);
            Assert.AreEqual(circle1.Y, 5);  
            Assert.AreEqual(circle1.Size, 5);
            Assert.AreEqual(circle1.Radius, 5);
            Assert.AreEqual(circle1.Speed, 10);
            Assert.AreEqual(circle1.Mass, 1);
        }
    }
}
