using OpenQA.Selenium;
using SeleniumBase;

namespace AutomationPractice.TestCategories
{
    internal class WomenDresses : SelActions
    {
        public WomenDresses()
        {
            open("http://automationpractice.com/index.php?id_category=3&controller=category");

            testLeftBlockExpandButtons();
            testAllCheckBoxes();
        }

        private void testAllCheckBoxes()
        {
            strokeCheckboxes("layered_category_4");
            strokeCheckboxes("layered_category_8");

            strokeCheckboxes("layered_id_attribute_group_1");
            strokeCheckboxes("layered_id_attribute_group_2");
            strokeCheckboxes("layered_id_attribute_group_3");

            strokeCheckboxes("layered_id_attribute_group_7");
            strokeCheckboxes("layered_id_attribute_group_8");
            strokeCheckboxes("layered_id_attribute_group_11");
            strokeCheckboxes("layered_id_attribute_group_13");
            strokeCheckboxes("layered_id_attribute_group_14");
            strokeCheckboxes("layered_id_attribute_group_15");
            strokeCheckboxes("layered_id_attribute_group_16");
            strokeCheckboxes("layered_id_attribute_group_24");

            strokeCheckboxes("layered_id_feature_5");
            strokeCheckboxes("layered_id_feature_1");

            strokeCheckboxes("layered_id_feature_11");
            strokeCheckboxes("layered_id_feature_13");

            strokeCheckboxes("layered_id_feature_19");
            strokeCheckboxes("layered_id_feature_17");

            strokeCheckboxes("layered_quantity_1");

            strokeCheckboxes("layered_manufacturer_1");

            strokeCheckboxes("layered_condition_new");
        }

        private void strokeCheckboxes(string element)
        {
            scrollForElementVisibility(FindID(element));
            clickByJS(FindID(element));
            wait_5();
            while (elementExists(By.XPath("//*[@class='product_list grid row']//img[contains(@src,'load')]")))
            {
                //wait?
            }
            wait_5();
            switchToActive();
            clickByJS(FindID(element));
        }

        private void testLeftBlockExpandButtons()
        {
            var elems = FindAllBy(By.XPath("//*[@id='categories_block_left']//span"));

            elems[0].Click();
            wait1s();
            elems[1].Click();
            wait1s();
            elems[0].Click();
            wait1s();
            elems[1].Click();
            wait1s();
        }
    }
}
