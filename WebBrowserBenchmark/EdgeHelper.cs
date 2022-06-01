﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium = OpenQA.Selenium;

namespace WebBrowserBenchmark
{
    internal class EdgeHelper
    {
        public static Selenium.Edge.EdgeDriver setEdge(string webEngineDirectory)
        {
            Selenium.Edge.EdgeOptions edgeEngine = new Selenium.Edge.EdgeOptions();

            Selenium.Edge.EdgeDriver edgeDriver = new Selenium.Edge.EdgeDriver(webEngineDirectory);
            return edgeDriver;
        }
        public static void openPage(Selenium.Edge.EdgeDriver edgeDriver, string pageName)
        {
            switch (pageName)
            {
                case "youtube":
                    edgeDriver.Navigate().GoToUrl("https://youtu.be/LDU_Txk06tM");
                    System.Threading.Thread.Sleep(200);
                    break;
                case "instagram":
                    edgeDriver.Navigate().GoToUrl("https://instagram.com");
                    System.Threading.Thread.Sleep(200);
                    break;
                case "reddit":
                    edgeDriver.Navigate().GoToUrl("https://www.reddit.com");
                    System.Threading.Thread.Sleep(200);
                    break;
                default:
                    break;
            }
        }
        public static void acceptCookie(Selenium.Edge.EdgeDriver edgeDriver)
        {
            string url = edgeDriver.Url;
            System.Collections.ObjectModel.ReadOnlyCollection<Selenium.IWebElement> button;
            switch (url)
            {
                case string a when a.Contains("youtube"):
                    button = edgeDriver.FindElements(Selenium.By.XPath("//*[@id='content']/div/div[6]/div[1]/ytd-button-renderer[2]/a"));
                    while (button.Count == 0)
                    {
                        button = edgeDriver.FindElements(Selenium.By.XPath("//*[@id='content']/div/div[6]/div[1]/ytd-button-renderer[2]/a"));
                    }
                    button[0].Click();
                    break;
                case string a when a.Contains("instagram"):
                    button = edgeDriver.FindElements(Selenium.By.XPath("/html/body/div[4]/div/div/button[2]"));
                    if (button.Count == 0)
                    {
                        button = edgeDriver.FindElements(Selenium.By.XPath("/html/body/div[4]/div/div/button[2]"));
                    }
                    button[0].Click();
                    break;
                case string a when a.Contains("reddit"):
                    button = edgeDriver.FindElements(Selenium.By.XPath("//*[@id='SHORTCUT_FOCUSABLE_DIV']/div[3]/div[1]/section/div/section/section/form[2]/button"));
                    while (button.Count == 0)
                    {
                        button = edgeDriver.FindElements(Selenium.By.XPath("//*[@id='SHORTCUT_FOCUSABLE_DIV']/div[3]/div[1]/section/div/section/section/form[2]/button"));
                    }
                    button[0].Click();
                    break;
                default:
                    break;
            }
        }
        public static void Test<T>(T driver)
        {
            Console.WriteLine(driver.GetType());
        }
        public static void logInToWebsite(Selenium.Edge.EdgeDriver edgeDriver)
        {
            string url = edgeDriver.Url;
            System.Collections.ObjectModel.ReadOnlyCollection<Selenium.IWebElement> button;

            switch (url)
            {
                case string a when a.Contains("instagram"):
                    string login = "pythonkrul@gmail.com", password = "Python69";

                    edgeDriver.FindElement(Selenium.By.XPath("//*[@id='loginForm']/div/div[1]/div/label/input")).SendKeys(login);
                    edgeDriver.FindElement(Selenium.By.XPath("//*[@id='loginForm']/div/div[2]/div/label/input")).SendKeys(password);

                    edgeDriver.FindElement(Selenium.By.XPath("//*[@id='loginForm']/div/div[3]/button")).Click();
                    System.Threading.Thread.Sleep(2000);

                    button = edgeDriver.FindElements(Selenium.By.XPath("//*[@id='mount_0_0_Z8']/div/div[1]/div/div[2]/div/div/div[1]/div/div[2]/div/div/div/div/div/div/div/div[3]/button[1]"));


                    if (button.Count == 0)
                    {
                        button = edgeDriver.FindElements(Selenium.By.XPath("//*[@id='mount_0_0_Z8']/div/div[1]/div/div[2]/div/div/div[1]/div/div[2]/div/div/div/div/div/div/div/div[3]/button[1]"));
                    }

                    button[0].Click();
                    break;

                default:
                    break;
            }
        }
        public static void performAction(Selenium.Edge.EdgeDriver edgeDriver)
        {
            //edgeDriver.Se
            Selenium.Interactions.Actions actions = new Selenium.Interactions.Actions(edgeDriver);
            actions.SendKeys(Selenium.Keys.ArrowDown);
        }
    }
}
