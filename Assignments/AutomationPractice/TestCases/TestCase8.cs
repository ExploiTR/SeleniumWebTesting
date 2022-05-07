using SeleniumBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.TestCases
{
    /*
     * 8# Test Case - Verify that Total Price is reflecting correctly if user changes quantity on 'Shopping Cart Summary' Page.
     * Steps to Automate:
     * 1. Open link http://automationpractice.com/index.php
     * 2. Login to the website.
     * 3. Move your cursor over Women's link.
     * 4. Click on sub menu 'T-shirts'.
     * 5. Mouse hover on the second product displayed.
     * 6. 'More' button will be displayed, click on 'More' button.
     * 7. Make sure quantity is set to 1.
     * 8. Select size 'M'
     * 9. Select color of your choice.
     * 10. Click 'Add to Cart' button.
     * 11. Click 'Proceed to checkout' button.
     * 12. Change the quantity to 2.
     * 13. Verify that Total price is changing and reflecting correct price.
     */
    class TestCase8 : SelActions
    {
        public TestCase8()
        {
            open("http://automationpractice.com/index.php");


        }
    }
}
