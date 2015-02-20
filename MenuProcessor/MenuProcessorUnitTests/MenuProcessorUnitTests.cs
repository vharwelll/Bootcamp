using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MenuProcessor;

namespace MenuProcessorUnitTests
{
    [TestClass]
    public class MenuProcessorUnitTests
    {
        private static readonly IMenuProcessor m_processor = MenuProcessorFactory.getInstance();

        [TestMethod]
        public void Morning_1_2_3()
        {
            Assert.AreEqual("eggs, toast, coffee", m_processor.ProcessOrder("morning, 1, 2, 3"));
        }

        [TestMethod]
        public void morning_2_1_3()
        {
            Assert.AreEqual("eggs, toast, coffee", m_processor.ProcessOrder("morning, 2, 1, 3"));
        }

        [TestMethod]
        public void morning_1_2_3_4()
        {
            Assert.AreEqual("eggs, toast, coffee, error", m_processor.ProcessOrder("morning, 1, 2, 3, 4"));
        }

        [TestMethod]
        public void morning_1_2_3_3_3()
        {
            Assert.AreEqual("eggs, toast, coffee(x3)", m_processor.ProcessOrder("morning, 1, 2, 3, 3, 3"));
        }

        [TestMethod]
        public void night_1_2_3_4()
        {
            Assert.AreEqual("steak, potato, wine, cake", m_processor.ProcessOrder("night, 1, 2, 3, 4"));
        }

        [TestMethod]
        public void night_1_2_2_4()
        {
            Assert.AreEqual("steak, potato(x2), cake", m_processor.ProcessOrder("night, 1, 2, 2, 4"));
        }

        [TestMethod]
        public void night_1_2_3_5()
        {
            Assert.AreEqual("steak, potato, wine, error", m_processor.ProcessOrder("night, 1, 2, 3, 5"));
        }

        [TestMethod]
        public void night_1_1_2_3_5()
        {
            Assert.AreEqual("steak, error", m_processor.ProcessOrder("night, 1, 1, 2, 3, 5"));
        }

        /* additional unit tests */
        [TestMethod]
        public void No_input()
        {
            Assert.AreEqual("error", m_processor.ProcessOrder(null));
            Assert.AreEqual("error", m_processor.ProcessOrder(String.Empty));
        }

        [TestMethod]
        public void All_Meal_Cases()
        {
            Assert.AreEqual("eggs, toast, coffee", m_processor.ProcessOrder("morning, 1, 2, 3"));
            Assert.AreEqual("eggs, toast, coffee", m_processor.ProcessOrder("MORNING, 1, 2, 3"));
            Assert.AreEqual("steak, potato, wine", m_processor.ProcessOrder("night, 1, 2, 3"));
            Assert.AreEqual("steak, potato, wine", m_processor.ProcessOrder("NIGHT, 1, 2, 3"));
        }

        [TestMethod]
        public void Only_morning_and_night()
        {
            Assert.AreEqual("error", m_processor.ProcessOrder("lunch"));
            Assert.AreEqual("error", m_processor.ProcessOrder("lunch, 1, 2, 3"));
        }

        [TestMethod]
        public void No_items()
        {
            Assert.AreEqual("error", m_processor.ProcessOrder("morning"));
            Assert.AreEqual("error", m_processor.ProcessOrder("night"));
        }

        [TestMethod]
        public void Non_numeric_menu_items()
        {
            Assert.AreEqual("error", m_processor.ProcessOrder("morning, foo"));
            Assert.AreEqual("error", m_processor.ProcessOrder("morning, foo, bar"));
            Assert.AreEqual("error", m_processor.ProcessOrder("night, foo"));
            Assert.AreEqual("error", m_processor.ProcessOrder("night, foo, bar"));
            Assert.AreEqual("error", m_processor.ProcessOrder("morning, , , , "));
            Assert.AreEqual("error", m_processor.ProcessOrder("night, , , , "));
        }

        [TestMethod]
        public void Missing_seperators()
        {
            Assert.AreEqual("error", m_processor.ProcessOrder("morning 1"));
            Assert.AreEqual("error", m_processor.ProcessOrder("morning 1 2 3"));
            Assert.AreEqual("error", m_processor.ProcessOrder("night 1"));
            Assert.AreEqual("error", m_processor.ProcessOrder("night 1 2 3 4"));
        }

        [TestMethod]
        public void Numeric_menu_item_out_of_range()
        {
            Assert.AreEqual("error", m_processor.ProcessOrder("morning, 4"));
            Assert.AreEqual("error", m_processor.ProcessOrder("night, 5"));
        }

        [TestMethod]
        public void Morning_single_item()
        {
            Assert.AreEqual("eggs", m_processor.ProcessOrder("morning, 1"));
            Assert.AreEqual("toast", m_processor.ProcessOrder("morning, 2"));
            Assert.AreEqual("coffee", m_processor.ProcessOrder("morning, 3"));
        }

        [TestMethod]
        public void Night_single_item()
        {
            Assert.AreEqual("steak", m_processor.ProcessOrder("night, 1"));
            Assert.AreEqual("potato", m_processor.ProcessOrder("night, 2"));
            Assert.AreEqual("wine", m_processor.ProcessOrder("night, 3"));
            Assert.AreEqual("cake", m_processor.ProcessOrder("night, 4"));
        }

        [TestMethod]
        public void Morning_single_item_allow_many()
        {
            Assert.AreEqual("coffee(x2)", m_processor.ProcessOrder("morning, 3, 3"));
            Assert.AreEqual("coffee(x10)", m_processor.ProcessOrder("morning, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3"));
        }

        [TestMethod]
        public void Night_single_item_allow_many()
        {
            Assert.AreEqual("potato(x2)", m_processor.ProcessOrder("night, 2, 2"));
            Assert.AreEqual("potato(x10)", m_processor.ProcessOrder("night, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2"));
        }

        [TestMethod]
        public void Morning_single_item_allow_one_specify_two()
        {
            Assert.AreEqual("eggs, error", m_processor.ProcessOrder("morning, 1, 1"));
            Assert.AreEqual("eggs, error", m_processor.ProcessOrder("morning, 1, 1, 1"));
            Assert.AreEqual("toast, error", m_processor.ProcessOrder("morning, 2, 2"));
            Assert.AreEqual("toast, error", m_processor.ProcessOrder("morning, 2, 2, 2"));
        }

        [TestMethod]
        public void Night_single_item_allow_one_specify_two()
        {
            Assert.AreEqual("steak, error", m_processor.ProcessOrder("night, 1, 1"));
            Assert.AreEqual("steak, error", m_processor.ProcessOrder("night, 1, 1, 1"));
            Assert.AreEqual("wine, error", m_processor.ProcessOrder("night, 3, 3"));
            Assert.AreEqual("wine, error", m_processor.ProcessOrder("night, 3, 3, 3"));
            Assert.AreEqual("cake, error", m_processor.ProcessOrder("night, 4, 4"));
            Assert.AreEqual("cake, error", m_processor.ProcessOrder("night, 4, 4, 4"));
        }

        [TestMethod]
        public void Morning_valid_set_equvalence()
        {
            Assert.AreEqual("eggs, toast, coffee", m_processor.ProcessOrder("morning, 1, 2, 3"));
            Assert.AreEqual("eggs, toast, coffee", m_processor.ProcessOrder("morning, 2, 3, 1"));
            Assert.AreEqual("eggs, toast, coffee", m_processor.ProcessOrder("morning, 3, 1, 2"));
            Assert.AreEqual("eggs, toast, coffee", m_processor.ProcessOrder("morning, 3, 2, 1"));
        }

        [TestMethod]
        public void Night_valid_set_equvalence()
        {
            Assert.AreEqual("steak, potato, wine, cake", m_processor.ProcessOrder("night, 1, 2, 3, 4"));
            Assert.AreEqual("steak, potato, wine, cake", m_processor.ProcessOrder("night, 2, 3, 4, 1"));
            Assert.AreEqual("steak, potato, wine, cake", m_processor.ProcessOrder("night, 3, 4, 1, 2"));
            Assert.AreEqual("steak, potato, wine, cake", m_processor.ProcessOrder("night, 4, 1, 2, 3"));
            Assert.AreEqual("steak, potato, wine, cake", m_processor.ProcessOrder("night, 4, 3, 2, 1"));
        }

        [TestMethod]
        public void Morning_single_item_allow_one_specify_two_with_others()
        {
            Assert.AreEqual("eggs, toast, error", m_processor.ProcessOrder("morning, 1, 2, 1"));
            Assert.AreEqual("eggs, toast, error", m_processor.ProcessOrder("morning, 1, 2, 1, 2"));
            Assert.AreEqual("toast, coffee, error", m_processor.ProcessOrder("morning, 2, 3, 2"));
            Assert.AreEqual("toast, coffee, error", m_processor.ProcessOrder("morning, 2, 3, 2, 3"));
            Assert.AreEqual("toast, coffee(x2), error", m_processor.ProcessOrder("morning, 3, 2, 3, 2"));
        }

        [TestMethod]
        public void Night_single_item_allow_one_specify_two_with_others()
        {
            Assert.AreEqual("steak, potato, error", m_processor.ProcessOrder("night, 1, 2, 1"));
            Assert.AreEqual("steak, potato, error", m_processor.ProcessOrder("night, 1, 2, 1, 2"));
            Assert.AreEqual("potato(x2), wine, error", m_processor.ProcessOrder("night, 2, 3, 2, 3"));
            Assert.AreEqual("potato, wine, error", m_processor.ProcessOrder("night, 3, 2, 3, 2"));
            Assert.AreEqual("wine, cake, error", m_processor.ProcessOrder("night, 3, 4, 3, 4"));
            Assert.AreEqual("wine, cake, error", m_processor.ProcessOrder("night, 4, 3, 4, 3"));
        }
    }
}
