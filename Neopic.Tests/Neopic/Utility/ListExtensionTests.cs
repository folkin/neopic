using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neopic.Linq.Tests
{
    [TestClass]
    public class ListExtensionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ListExtensions_RadialSlice_throws_for_null_list()
        {
            List<int> list = null;
            list.RadialSlice(0, 0).ToArray();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListExtensions_RadialSlice_throws_for_index_out_of_range()
        {
            List<int> list = new List<int>();
            var actual = list.RadialSlice(1, 0).ToArray();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListExtensions_RadialSlice_throws_for_radius_out_of_range_1_element()
        {
            List<int> list = new List<int> { 1 };
            var actual = list.RadialSlice(0, 1).ToArray();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListExtensions_RadialSlice_throws_for_radius_out_of_range_2_elements()
        {
            List<int> list = new List<int> { 1, 2 };
            var actual = list.RadialSlice(0, 2).ToArray();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListExtensions_RadialSlice_throws_for_radius_out_of_range_3_elements()
        {
            List<int> list = new List<int> { 1, 2, 3 };
            var actual = list.RadialSlice(0, 2).ToArray();
        }

        [TestMethod]
        public void ListExtensions_RadialSlice_gets_single_element_for_radius_0()
        {
            var actual = new List<int> { 1, 2, 3 }.RadialSlice(1, 0).ToArray();
            CollectionAssert.AreEqual(new[] { 2 }, actual);
        }

        [TestMethod]
        public void ListExtensions_RadialSlice_gets_correct_elsements_simple()
        {
            var actual = new List<int> { 1, 2, 3, 4, 5 }.RadialSlice(2, 1).ToArray();
            CollectionAssert.AreEqual(new[] { 2, 3, 4 }, actual);
        }

        [TestMethod]
        public void ListExtensions_RadialSlice_gets_correct_elements_wrapped_around_end()
        {
            var actual = new List<int> { 1, 2, 3, 4, 5 }.RadialSlice(4, 1).ToArray();
            CollectionAssert.AreEqual(new[] { 4, 5, 1 }, actual);
        }

        [TestMethod]
        public void ListExtensions_RadialSlice_gets_correct_elements_for_entire_list_odd()
        {
            var actual = new List<int> { 1, 2, 3, 4, 5 }.RadialSlice(2, 2).ToArray();
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5}, actual);
        }

        [TestMethod]
        public void ListExtensions_RadialSlice_gets_correct_elements_for_entire_list_even()
        {
            var actual = new List<int> { 1, 2, 3, 4, 5, 6 }.RadialSlice(2, 3).ToArray();
            CollectionAssert.AreEqual(new[] { 6, 1, 2, 3, 4, 5 }, actual);
        }
    }
}
