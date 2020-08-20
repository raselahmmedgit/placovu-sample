using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace RnD.SeleniumApps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Selenium Apps");
            try
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.google.com/");
                IWebElement searchTextBox = driver.FindElement(By.Name("q"));
                searchTextBox.SendKeys("ontrack health");
                IWebElement searchButton = driver.FindElement(By.Name("btnK"));
                //click on the search button  
                searchButton.Click();
                //driver.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
