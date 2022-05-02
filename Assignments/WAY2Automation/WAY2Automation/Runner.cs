using System;
using WAY2Automation.Alerts;
using WAY2Automation.Dynamic_Events;
using WAY2Automation.FramesAndWindows;
using WAY2Automation.Interaction;
using WAY2Automation.Widgets;

namespace WAY2Automation
{
    internal class Runner
    {
        static void Main(string[] args)
        {
            //registration();
            //interactions(true, 0);
            //widgets(true, 6);
            //FAWS();
            //dropdown();
            alerts();
        }

        private static void alerts()
        {
            new Alarts().start();
        }

        private static void dropdown()
        {
            new Dropdown().start();
        }

        static void registration()
        {
            new Registration().start();
        }

        static void interactions(bool chainTest, int switchTo)
        {
            switch (switchTo)
            {
                case 0:
                    {
                        new Draggable().start(chainTest);
                        break;
                    }
                case 1:
                    {
                        new Droppable().start(chainTest);
                        break;
                    }
                case 2:
                    {
                        new Resizable().start(chainTest);
                        break;
                    }
                case 3:
                    {
                        new Selectable().start(chainTest);
                        break;
                    }
                case 4:
                    {
                        new Sortable().start(chainTest);
                        break;
                    }
            }

        }

        static void widgets(bool chain, int switchTo)
        {
            switch (switchTo)
            {
                case 0:
                    {
                        new Accordion().start(chain);
                        break;
                    }
                case 1:
                    {
                        new AutoComplete().start(chain);
                        break;
                    }
                case 2:
                    {
                        new DatePicker().start(chain);
                        break;
                    }
                case 3:
                    {
                        new Menu().start(chain);
                        break;
                    }
                case 4:
                    {
                        new Slider().start(chain);
                        break;
                    }
                case 5:
                    {
                        new Tabs().start(chain);
                        break;
                    }
                case 6:
                    {
                        new Tooltips().start();
                        break;
                    }
            }
        }

        static void FAWS()
        {
            new FAWS().start();
        }
    }
}
