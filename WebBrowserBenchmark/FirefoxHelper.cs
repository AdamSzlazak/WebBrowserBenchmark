using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium = OpenQA.Selenium;

namespace WebBrowserBenchmark
{
    internal class FirefoxHelper
    {

        public static Selenium.Firefox.FirefoxDriver setFirefox(string webEngineDirectory)
        {
            var firefoxEngine = new Selenium.Firefox.FirefoxOptions() { BrowserExecutableLocation = webEngineDirectory };
            Selenium.Firefox.FirefoxDriver firefoxDriver = new Selenium.Firefox.FirefoxDriver(webEngineDirectory);


            return firefoxDriver;
        }
        public static void openPage(Selenium.Firefox.FirefoxDriver firefoxDriver, string pageName)
        {
            switch (pageName)
            {
                case "youtube":
                    firefoxDriver.Navigate().GoToUrl("https://youtu.be/LDU_Txk06tM");
                    System.Threading.Thread.Sleep(200);
                    break;
                case "instagram":
                    firefoxDriver.Navigate().GoToUrl("https://instagram.com");
                    System.Threading.Thread.Sleep(200);
                    break;
                case "reddit":
                    firefoxDriver.Navigate().GoToUrl("https://www.reddit.com");
                    System.Threading.Thread.Sleep(200);
                    break;
                default:
                    break;
            }
        }
        public static void acceptCookie(Selenium.Firefox.FirefoxDriver firefoxDriver)
        {
            string url = firefoxDriver.Url;
            System.Collections.ObjectModel.ReadOnlyCollection<Selenium.IWebElement> button;
            switch (url)
            {
                case string a when a.Contains("youtube"):
                    button = firefoxDriver.FindElements(Selenium.By.XPath("//*[@id='content']/div/div[6]/div[1]/ytd-button-renderer[2]/a"));
                    while (button.Count == 0)
                    {
                        button = firefoxDriver.FindElements(Selenium.By.XPath("//*[@id='content']/div/div[6]/div[1]/ytd-button-renderer[2]/a"));
                    }
                    button[0].Click();

                    break;
                case string a when a.Contains("instagram"):
                    button = firefoxDriver.FindElements(Selenium.By.XPath("/html/body/div[4]/div/div/button[2]"));
                    while (button.Count == 0)
                    {
                        button = firefoxDriver.FindElements(Selenium.By.XPath("/html/body/div[4]/div/div/button[2]"));
                    }
                    button[0].Click();
                    break;
                case string a when a.Contains("reddit"):
                    button = firefoxDriver.FindElements(Selenium.By.XPath("//*[@id='SHORTCUT_FOCUSABLE_DIV']/div[3]/div[1]/section/div/section/section/form[2]/button"));
                    while (button.Count == 0)
                    {
                        button = firefoxDriver.FindElements(Selenium.By.XPath("//*[@id='SHORTCUT_FOCUSABLE_DIV']/div[3]/div[1]/section/div/section/section/form[2]/button"));
                    }
                    button[0].Click();
                    break;
                default:
                    break;
            }
        }
        public static void logInToWebsite(Selenium.Firefox.FirefoxDriver firefoxDriver)
        {
            string url = firefoxDriver.Url;
            System.Collections.ObjectModel.ReadOnlyCollection<Selenium.IWebElement> button;

            switch (url)
            {
                case string a when a.Contains("instagram"):
                    string login = "pythonkrul@gmail.com", password = "Python69";

                    firefoxDriver.FindElement(Selenium.By.XPath("//*[@id='loginForm']/div/div[1]/div/label/input")).SendKeys(login);
                    firefoxDriver.FindElement(Selenium.By.XPath("//*[@id='loginForm']/div/div[2]/div/label/input")).SendKeys(password);

                    button = firefoxDriver.FindElements(Selenium.By.XPath("//*[@id='loginForm']/div/div[3]/button"));
                    while (button.Count == 0)
                    {
                        button = firefoxDriver.FindElements(Selenium.By.XPath("//*[@id='loginForm']/div/div[3]/button"));
                    }
                    System.Threading.Thread.Sleep(2000);
                    button[0].Click();

                    //System.Threading.Thread.Sleep(4000);
                    button = null;
                    System.Threading.Thread.Sleep(3000);
                    button = firefoxDriver.FindElements(Selenium.By.XPath("//button[@class='_a9-- _a9_0']"));

                    while (button.Count == 0)
                    {
                        button = firefoxDriver.FindElements(Selenium.By.XPath("//button[@class='_a9-- _a9_0']"));
                    }
                    button[0].Click();
                    break;

                default:
                    break;
            }
        }
        public static void performAction(Selenium.Firefox.FirefoxDriver firefoxDriver)
        {
            //scroll
            string url = firefoxDriver.Url;
            switch (url)
            {
                case string a when a.Contains("instagram"):
                    var elements = firefoxDriver.FindElements(Selenium.By.XPath("//button[@class = '_aam8']"));
                    while (elements.Count == 0)
                    {
                        elements = firefoxDriver.FindElements(Selenium.By.XPath("//button[@class = '_aam8']"));
                    }
                    elements[0].Click();
                    break;
                case string a when a.Contains("reddit"):
                    int toScroll = 200;
                    for (int i = 0; i < 20; i++)
                    {
                        Selenium.IJavaScriptExecutor js = (Selenium.IJavaScriptExecutor)firefoxDriver;
                        js.ExecuteScript(String.Format("window.scrollTo({0},{1})", 0, toScroll));
                        toScroll += 200;
                        System.Threading.Thread.Sleep(100);
                    }
                    break;
                case string a when a.Contains("youtube"):
                    System.Threading.Thread.Sleep(10 * 1000);
                    var button = firefoxDriver.FindElements(Selenium.By.XPath("//button[@class='ytp-large-play-button ytp-button']"));
                    while (button.Count == 0)
                    {
                        button = firefoxDriver.FindElements(Selenium.By.XPath("//button[@class='ytp-large-play-button ytp-button']"));
                    }
                    Console.WriteLine("DUAP");
                    button[0].Click();
                    break;
                default:
                    break;
            }
        }
    }
}
