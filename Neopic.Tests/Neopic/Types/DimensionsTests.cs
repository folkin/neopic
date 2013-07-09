using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neopic.Types.Tests
{
    [TestClass]
    public class DimensionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Dimensions_requires_non_null_argument()
        {
            new Dimensions((int[])null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Dimensions_requires_non_empty_argument()
        {
            new Dimensions(new int[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Dimensions_requires_non_negative_argument()
        {
            new Dimensions(new int[] { -1 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Dimensions_requires_non_zero_argument()
        {
            new Dimensions(new int[] { 0 });
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Dimensions_indexer_throws_out_of_range()
        {
            var d = new Dimensions(new int[] { 2 });
            var dne = d[1];
        }

        [TestMethod]
        public void Dimensions_indexer_returns_expected_values()
        {
            var d = new Dimensions(new int[] { 1, 2 });
            Assert.AreEqual(1, d[0]);
            Assert.AreEqual(2, d[1]);
        }

        [TestMethod]
        public void Dimensions_length_returns_expected_value()
        {
            var d = new Dimensions(new int[] { 1, 2 });
            Assert.AreEqual(2, d.Length);
        }
    }
}
