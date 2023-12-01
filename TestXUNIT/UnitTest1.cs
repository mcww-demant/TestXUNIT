using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium.DevTools.V117.DOM;
using OpenQA.Selenium.DevTools.V117.Debugger;

namespace TestXUNIT

{
    public class UnitTest1
    {
        
        readonly FirefoxDriver fdriver = new FirefoxDriver(@"C:\Users\mcww\source\repos\TestXUNIT\TestXUNIT\drivers");

        string url = "https://www.demant.com";
        string AllowButton = "html/body/div/div/div/div[1]/div[2]/div[1]/button[3]";
        string AboutButton = "html/body/form/div[3]/div[1]/div/div/div[1]/div[3]/ul/li[4]/a";
        string ManagementAndGovernanceButton = "html/body/form/div[3]/div[1]/div/div/div[2]/ul/li[6]/a";
        string CheckingText = "Demant employs a two-tier management structure, consisting of the Board of Directors and the Executive Board. " +
            "The Board of Directors supervises the performance of the company, its management and organisation on behalf of the shareholders. It also contributes to determining the company strategy. " +
            "The Executive Board, in turn, is responsible for the company's daily operations.";
        string TestWait = "/html/body/form/div[3]/div[2]/div/div/div[2]/div/h1/span/span";
        string TextOnPage = "/html/body/form/div[3]/div[2]/div/div/div[2]/div/p[1]";
        string SearchButton = "/html/body/form/div[3]/div[1]/div/div/div/div[2]/a";
        string SearchEngine = "/html/body/form/div[3]/div[1]/div/div/div/div[2]/div/div/input";
        string input = "Remuneration report for 2021";
        string Test2Wait = "/html/body/form/div[3]/div[2]/div/div/div/div/div[2]/ul/li[1]/h3/a";
        string SearchResult = "//*[contains(@class, 'search-result')]/ul/li";
        
       
        [Fact]
        public void Test1()

        {
            var wait = new WebDriverWait(fdriver, TimeSpan.FromSeconds(10));
            fdriver.Url = (url);
            By allowbutton = By.XPath(AllowButton);

            fdriver.FindElement(allowbutton).Click();
        
            By aboutbutton = By.XPath(AboutButton);
            fdriver.FindElement(aboutbutton).Click();

            By managementandgovernancebutton = By.XPath(ManagementAndGovernanceButton);
            fdriver.FindElement(managementandgovernancebutton).Click();

            wait.Until(fdriver => fdriver.FindElement(By.XPath(TestWait)).Displayed);

            TextOnPage = fdriver.FindElement(By.XPath(TextOnPage)).Text;

            Assert.Equal(TextOnPage, CheckingText);

            fdriver.Dispose();  
            
        }
        [Fact]

        public void test2()
        {
           
            
            var wait = new WebDriverWait(fdriver, TimeSpan.FromSeconds(10));

            fdriver.Url = (url);

            By allowbutton = By.XPath(AllowButton);
            fdriver.FindElement(allowbutton).Click();

            By searchbutton = By.XPath(SearchButton);
            fdriver.FindElement(searchbutton).Click();

            By searchengine = By.XPath(SearchEngine);
            fdriver.FindElement(searchengine).SendKeys(input);     
            fdriver.FindElement(searchengine).SendKeys(Keys.Enter);
            Thread.Sleep(5000);
            wait.Until(fdriver => fdriver.FindElement(By.XPath(Test2Wait)).Displayed);

            List <IWebElement> ElementList = new List<IWebElement>();
            var elementsList = fdriver.FindElements(By.XPath(SearchResult));

            var result = elementsList.Any(_ => _.Text.Contains(input));

            Assert.True(result);

            fdriver.Dispose();


        }

    }
   
}
