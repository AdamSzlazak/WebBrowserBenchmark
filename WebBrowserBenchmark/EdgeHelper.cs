using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium = OpenQA.Selenium;

namespace WebBrowserBenchmark
{
    internal class EdgeHelper
    {
        public static void acceptCookie(Selenium.Edge.EdgeDriver driver)
        {
            string url = driver.Url;
            
            switch (url)
            {
                case string a when a.Contains("youtube"):
                    driver.FindElement(Selenium.By.XPath("//*[@id='content']/div/div[6]/div[1]/ytd-button-renderer[2]/a")).Click();
                    break;
                default:
                    break;
            }
        }
        public static Selenium.Edge.EdgeDriver setEdge(string webEngineDirectory)
        {
            Selenium.Edge.EdgeOptions edgeEngine = new Selenium.Edge.EdgeOptions();

            Selenium.Edge.EdgeDriver edgeDriver = new Selenium.Edge.EdgeDriver(webEngineDirectory);
            return edgeDriver;
        }
        public static void openPage(Selenium.Edge.EdgeDriver driver, string pageName)
        {
            switch (pageName)
            {
                case "youtube":
                    driver.Navigate().GoToUrl("Https://youtube.com");
                    break;
                default:
                    break;
            }
        }
    }
}
