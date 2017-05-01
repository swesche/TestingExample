using System;
using TechTalk.SpecFlow;
using Example;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HP.LFT.Report;
using HP.LFT.SDK;
using HP.LFT.SDK.Web;

namespace BumpersForBabyTests
{
    [Binding]
    public class SearchForBumpersSteps
    {
        private BumpersForBaby bumpersforbaby = new BumpersForBaby();

        [Given(@"I have access to a web browser")]
        public void GivenIHaveAccessToAWebBrowser()
        {
            SDK.Init(new SdkConfiguration
            {
                ServerAddress = new Uri("ws://localhost:5095")
            });
            ReportConfiguration r = new ReportConfiguration();
            r.IsOverrideExisting = true;
            r.Title = "My LeanFT Report";

            Reporter.Init(r);

            bumpersforbaby.LoadBrowser(HP.LFT.SDK.Web.BrowserType.Chrome);
        }
        
        [When(@"I navigate to bing\.com")]
        public void WhenINavigateTobing_Com()
        {
            bumpersforbaby.NavigateURL("http://www.bing.com");  
        }
        
        [When(@"I enter ""(.*)"" in the search input box")]
        public void WhenIEnterInTheSearchInputBox(string searchtext)
        {
            bumpersforbaby.LoadSearchBox("rubber baby buggy bumpers");
        }
        
        [When(@"I click the Search button")]
        public void WhenIClickTheSearchButton()
        {
            bumpersforbaby.ClickSearchButton();
        }
        
        [Then(@"I find results showing rubber baby buggy bumpers")]
        public void ThenIFindResultsShowingRubberBabyBuggyBumpers()
        {
            Assert.IsTrue(bumpersforbaby.getResults().Exists(10));
            bumpersforbaby.CloseBrowser();
            SDK.Cleanup();
        }
    }
}
