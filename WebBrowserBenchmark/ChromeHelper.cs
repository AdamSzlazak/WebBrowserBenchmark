using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium = OpenQA.Selenium;

namespace WebBrowserBenchmark
{
    internal class ChromeHelper
    {
        public static Selenium.Chrome.ChromeDriver setChrome(string webEngineDirectory)
        {
            Selenium.Chrome.ChromeDriver chromeDriver = new Selenium.Chrome.ChromeDriver(webEngineDirectory);
            return chromeDriver;
        }
        public static void openPage(Selenium.Chrome.ChromeDriver chromeDriver, string pageName)
        {
            switch (pageName)
            {
                case "youtube":
                    chromeDriver.Navigate().GoToUrl("https://youtu.be/LDU_Txk06tM");
                    System.Threading.Thread.Sleep(200);
                    break;
                case "instagram":
                    chromeDriver.Navigate().GoToUrl("https://instagram.com");
                    System.Threading.Thread.Sleep(200);
                    break;
                case "reddit":
                    chromeDriver.Navigate().GoToUrl("https://www.reddit.com");
                    System.Threading.Thread.Sleep(200);
                    break;
                default:
                    break;
            }
        }
        public static void acceptCookie(Selenium.Chrome.ChromeDriver chromeDriver)
        {
            string url = chromeDriver.Url;
            System.Collections.ObjectModel.ReadOnlyCollection<Selenium.IWebElement> button;
            switch (url)
            {
                case string a when a.Contains("youtube"):
                    button = chromeDriver.FindElements(Selenium.By.XPath("//*[@id='content']/div/div[6]/div[1]/ytd-button-renderer[2]/a"));
                    while (button.Count == 0)
                    {
                        button = chromeDriver.FindElements(Selenium.By.XPath("//*[@id='content']/div/div[6]/div[1]/ytd-button-renderer[2]/a"));
                    }
                    button[0].Click();

                    break;
                case string a when a.Contains("instagram"):
                    button = chromeDriver.FindElements(Selenium.By.XPath("/html/body/div[4]/div/div/button[2]"));
                    while (button.Count == 0)
                    {
                        button = chromeDriver.FindElements(Selenium.By.XPath("/html/body/div[4]/div/div/button[2]"));
                    }
                    button[0].Click();
                    break;
                case string a when a.Contains("reddit"):
                    button = chromeDriver.FindElements(Selenium.By.XPath("//*[@id='SHORTCUT_FOCUSABLE_DIV']/div[3]/div[1]/section/div/section/section/form[2]/button"));
                    while (button.Count == 0)
                    {
                        button = chromeDriver.FindElements(Selenium.By.XPath("//*[@id='SHORTCUT_FOCUSABLE_DIV']/div[3]/div[1]/section/div/section/section/form[2]/button"));
                    }
                    button[0].Click();
                    break;
                default:
                    break;
            }
        }
        public static void logInToWebsite(Selenium.Chrome.ChromeDriver chromeDriver)
        {
            string url = chromeDriver.Url;
            System.Collections.ObjectModel.ReadOnlyCollection<Selenium.IWebElement> button;
            switch (url)
            {
                case string a when a.Contains("instagram"):
                    string login = "pythonkrul@gmail.com", password = "Python69";

                    chromeDriver.FindElement(Selenium.By.XPath("//*[@id='loginForm']/div/div[1]/div/label/input")).SendKeys(login);
                    chromeDriver.FindElement(Selenium.By.XPath("//*[@id='loginForm']/div/div[2]/div/label/input")).SendKeys(password);

                    button = chromeDriver.FindElements(Selenium.By.XPath("//*[@id='loginForm']/div/div[3]/button"));
                    while (button.Count == 0)
                    {
                        button = chromeDriver.FindElements(Selenium.By.XPath("//*[@id='loginForm']/div/div[3]/button"));
                    }
                    System.Threading.Thread.Sleep(2000);
                    button[0].Click();

                    //System.Threading.Thread.Sleep(4000);
                    button = null;
                    System.Threading.Thread.Sleep(3000);
                    button = chromeDriver.FindElements(Selenium.By.XPath("//button[@class='_a9-- _a9_0']"));

                    while (button.Count == 0)
                    {
                        button = chromeDriver.FindElements(Selenium.By.XPath("//button[@class='_a9-- _a9_0']"));
                    }
                    button[0].Click();
                    break;
                default:
                    break;
            }
        }
        public static void performAction(Selenium.Chrome.ChromeDriver chromeDriver)
        {
            string url = chromeDriver.Url;
            switch (url)
            {
                case string a when a.Contains("instagram"):
                    var elements = chromeDriver.FindElements(Selenium.By.XPath("//button[@class = '_aam8']"));
                    while (elements.Count == 0)
                    {
                        elements = chromeDriver.FindElements(Selenium.By.XPath("//button[@class = '_aam8']"));
                    }
                    elements[0].Click();
                    break;
                case string a when a.Contains("reddit"):
                    int toScroll = 200;
                    for (int i = 0; i < 100; i++)
                    {
                        Selenium.IJavaScriptExecutor js = (Selenium.IJavaScriptExecutor)chromeDriver;
                        js.ExecuteScript(String.Format("window.scrollTo({0},{1})", 0, toScroll));
                        toScroll += 200;
                        System.Threading.Thread.Sleep(100);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}