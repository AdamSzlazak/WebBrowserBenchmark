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
            var firefoxDriver = new Selenium.Firefox.FirefoxDriver(webEngineDirectory);
            return firefoxDriver;
        }
    }

}
