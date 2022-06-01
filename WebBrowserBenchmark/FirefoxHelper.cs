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
            Selenium.Firefox.FirefoxOptions FirefoxEngine = new Selenium.Firefox.FirefoxOptions();

            Selenium.Firefox.FirefoxDriver FirefoxDriver = new Selenium.Firefox.FirefoxDriver(webEngineDirectory);
            return FirefoxDriver;
        }
        public static void openPage(Selenium.Firefox.FirefoxDriver FirefoxDriver, string pageName)
        {
            switch (pageName)
            {
                case "youtube":
                    FirefoxDriver.Navigate().GoToUrl("https://youtu.be/LDU_Txk06tM");
                    System.Threading.Thread.Sleep(200);
                    break;
                case "instagram":
                    FirefoxDriver.Navigate().GoToUrl("https://instagram.com");
                    System.Threading.Thread.Sleep(200);
                    break;
                case "reddit":
                    FirefoxDriver.Navigate().GoToUrl("https://www.reddit.com");
                    System.Threading.Thread.Sleep(200);
                    break;
                default:
                    break;
            }
        }
        public static void acceptCookie(Selenium.Firefox.FirefoxDriver FirefoxDriver)
        {
            string url = FirefoxDriver.Url;
            System.Collections.ObjectModel.ReadOnlyCollection<Selenium.IWebElement> button;
            switch (url)
            {
                case string a when a.Contains("youtube"):
                    button = FirefoxDriver.FindElements(Selenium.By.XPath("//*[@id='content']/div/div[6]/div[1]/ytd-button-renderer[2]/a"));
                    while (button.Count == 0)
                    {
                        button = FirefoxDriver.FindElements(Selenium.By.XPath("//*[@id='content']/div/div[6]/div[1]/ytd-button-renderer[2]/a"));
                    }
                    button[0].Click();
                    break;
                case string a when a.Contains("instagram"):
                    button = FirefoxDriver.FindElements(Selenium.By.XPath("/html/body/div[4]/div/div/button[2]"));
                    if (button.Count == 0)
                    {
                        button = FirefoxDriver.FindElements(Selenium.By.XPath("/html/body/div[4]/div/div/button[2]"));
                    }
                    button[0].Click();
                    break;
                case string a when a.Contains("reddit"):
                    button = FirefoxDriver.FindElements(Selenium.By.XPath("//*[@id='SHORTCUT_FOCUSABLE_DIV']/div[3]/div[1]/section/div/section/section/form[2]/button"));
                    while (button.Count == 0)
                    {
                        button = FirefoxDriver.FindElements(Selenium.By.XPath("//*[@id='SHORTCUT_FOCUSABLE_DIV']/div[3]/div[1]/section/div/section/section/form[2]/button"));
                    }
                    button[0].Click();
                    break;
                default:
                    break;
            }
        }
        public static void logInToWebsite(Selenium.Firefox.FirefoxDriver FirefoxDriver)
        {
            string url = FirefoxDriver.Url;
            System.Collections.ObjectModel.ReadOnlyCollection<Selenium.IWebElement> button;

            switch (url)
            {
                case string a when a.Contains("instagram"):
                    string login = "pythonkrul@gmail.com", password = "Python69";

                    FirefoxDriver.FindElement(Selenium.By.XPath("//*[@id='loginForm']/div/div[1]/div/label/input")).SendKeys(login);
                    FirefoxDriver.FindElement(Selenium.By.XPath("//*[@id='loginForm']/div/div[2]/div/label/input")).SendKeys(password);

                    button = FirefoxDriver.FindElements(Selenium.By.XPath("//*[@id='loginForm']/div/div[3]/button"));
                    if (button.Count == 0)
                    {
                        button = FirefoxDriver.FindElements(Selenium.By.XPath("//*[@id='loginForm']/div/div[3]/button"));
                    }
                    System.Threading.Thread.Sleep(1000);
                    button[0].Click();

                    System.Threading.Thread.Sleep(3000);
                    button = FirefoxDriver.FindElements(Selenium.By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div[1]/div/div[2]/div/div/div/div/div/div/div/div[3]/button[2]"));

                    if (button.Count == 0)
                    {
                        button = FirefoxDriver.FindElements(Selenium.By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div/div/div[1]/div/div[2]/div/div/div/div/div/div/div/div[3]/button[2]"));
                    }
                    button[0].Click();
                    break;
                default:
                    break;
            }
        }
        public static void performAction(Selenium.Firefox.FirefoxDriver FirefoxDriver)
        {
            //scroll
            string url = FirefoxDriver.Url;
            switch (url)
            {
                case string a when a.Contains("instagram"):
                    var elements = FirefoxDriver.FindElements(Selenium.By.XPath("//button[@class = '_aam8']"));
                    if (elements.Count == 0)
                    {
                        elements = FirefoxDriver.FindElements(Selenium.By.XPath("//button[@class = '_aam8']"));
                    }
                    elements[0].Click();
                    break;
                case string a when a.Contains("reddit"):
                    for (int i = 0; i < 20; i++)
                    {
                        Selenium.IJavaScriptExecutor js = (Selenium.IJavaScriptExecutor)FirefoxDriver;
                        js.ExecuteScript(String.Format("window.scrollTo({0},{1})", 0, 600));
                        System.Threading.Thread.Sleep(4000);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
