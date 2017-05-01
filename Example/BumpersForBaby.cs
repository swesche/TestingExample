using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.SDK.Web;

namespace Example
{
    public class BumpersForBaby
    {
        private IBrowser browser { get; set; }
        private IEditField searchbox;
        IButton searchbutton;

        public IBrowser LoadBrowser(BrowserType bt)
        {
            browser = BrowserFactory.Launch(bt);
            return browser;
        }

        public void NavigateURL(string url)
        {
            if (browser.Equals(null))
            {
                LoadBrowser(BrowserType.Chrome);
            }
            else
            {
                browser.Navigate(url);
            }

        }

        public void LoadSearchBox(string searchtext)
        {
            searchbox = getSearchBar();
            searchbox.SetValue(searchtext);
        }

        public void ClickSearchButton()
        {
            searchbutton = getSearchButton();
            searchbutton.Click();
        }
        public IEditField getSearchBar()
        {
            return browser.Describe<IEditField>(new EditFieldDescription
            {
                Type = @"search",
                XPath = @"//INPUT[@id=""sb_form_q""]",
                CSSSelector = @"input#sb_form_q",
                Id = @"sb_form_q",
                TagName = @"INPUT",
                OuterHTML = @"<input class=""b_searchbox"" id=""sb_form_q"" name=""q"" title=""Enter your search term"" type=""search"" value="""" maxlength=""1000"" autocapitalize=""off"" autocorrect=""off"" autocomplete=""off"" spellcheck=""false"" role=""combobox"" aria-autocomplete=""both"" aria-haspopup=""true"" aria-expanded=""false"" aria-controls=""sw_as"" aria-owns=""sw_as"">",
                Name = @"q"
            });
        }

        public IButton getSearchButton()
        {
            return browser.Describe<IButton>(new ButtonDescription
            {
                ButtonType = @"submit",
                XPath = @"//INPUT[@id=""sb_form_go""]",
                CSSSelector = @"input#sb_form_go",
                Id = @"sb_form_go",
                TagName = @"INPUT",
                Name = @"Submit Query"
            });
        }

        public ILink getResults()
        {
            return browser.Describe<ILink>(new LinkDescription
            {
                Href = @"http://www.urbandictionary.com/define.php?term=rubber%20baby%20buggy%20bumpers",
                XPath = @"//LI[3]/H2[1]/A[1]",
                CSSSelector = @"ol#b_results > li:nth-child(3) > h2 > a",
                TagName = @"A",
                InnerHTML = @"Urban Dictionary: <strong>rubber baby buggy bumpers</strong>",
                OuterHTML = @"<a href=""http://www.urbandictionary.com/define.php?term=rubber%20baby%20buggy%20bumpers"" h=""ID=SERP,5130.1"">Urban Dictionary: <strong>rubber baby buggy bumpers</strong></a>",
                InnerText = @"Urban Dictionary: rubber baby buggy bumpers",
                OuterText = @"Urban Dictionary: rubber baby buggy bumpers",
                Name = @"Urban Dictionary: rubber baby buggy bumpers"
            });
        }

        public void CloseBrowser()
        {
            browser.Close();
        }
    }
}
