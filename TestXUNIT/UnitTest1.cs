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
        string AllowButton = "coi-banner__accept";
        string AboutButton = "li.level1:nth-child(4) > a:nth-child(1)";
        string ManagementAndGovernanceButton = ".sub-menu > ul:nth-child(1) > li:nth-child(6) > a:nth-child(1)";
        string CheckingText = "Demant employs a two-tier management structure, consisting of the Board of Directors and the Executive Board. " +
            "The Board of Directors supervises the performance of the company, its management and organisation on behalf of the shareholders. It also contributes to determining the company strategy. " +
            "The Executive Board, in turn, is responsible for the company's daily operations.";
        string TestWait = ".like-h1-xl-light";
        string TextOnPage = "div.rich-text:nth-child(2) > div:nth-child(1) > p:nth-child(2)";
        string SearchButton = "search";
        string SearchEngine = ".search-field > input:nth-child(1)";
        string input = "Annual Report 2018";
        string Test2Wait = ".search-result > ul:nth-child(1) > li:nth-child(1) > h3:nth-child(1) > a:nth-child(1)";
        string SearchResult = "search-result";
        
       
        [Fact]
        public void Test1()

        {
            var wait = new WebDriverWait(fdriver, TimeSpan.FromSeconds(10));
            fdriver.Url = (url);
            By allowbutton = By.ClassName(AllowButton);

            fdriver.FindElement(allowbutton).Click();
        
            By aboutbutton = By.CssSelector(AboutButton);
            fdriver.FindElement(aboutbutton).Click();

            By managementandgovernancebutton = By.CssSelector(ManagementAndGovernanceButton);
            fdriver.FindElement(managementandgovernancebutton).Click();

            wait.Until(fdriver => fdriver.FindElement(By.CssSelector(TestWait)).Displayed);

            TextOnPage = fdriver.FindElement(By.CssSelector(TextOnPage)).Text;

            Assert.Equal(TextOnPage, CheckingText);

            fdriver.Dispose();  
            
        }
        [Fact]

        public void test2()
        {
           
            
            var wait = new WebDriverWait(fdriver, TimeSpan.FromSeconds(10));

            fdriver.Url = (url);

            By allowbutton = By.ClassName(AllowButton);
            fdriver.FindElement(allowbutton).Click();

            By searchbutton = By.ClassName(SearchButton);
            fdriver.FindElement(searchbutton).Click();

            By searchengine = By.CssSelector(SearchEngine);
            fdriver.FindElement(searchengine).SendKeys(input);     
            fdriver.FindElement(searchengine).SendKeys(Keys.Enter);
            Thread.Sleep(5000);
            wait.Until(fdriver => fdriver.FindElement(By.CssSelector(Test2Wait)).Displayed);

            List <IWebElement> ElementList = new List<IWebElement>();
            var elementsList = fdriver.FindElements(By.ClassName(SearchResult));

            var result = elementsList.Any(_ => _.Text.Contains(input));

            Assert.True(result);

            fdriver.Dispose();


        }

    }
   
}
