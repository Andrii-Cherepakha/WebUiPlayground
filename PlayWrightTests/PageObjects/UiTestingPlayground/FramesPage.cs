using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects.UiTestingPlayground
{
    public class FramesPage : BasePage
    {
        public FramesPage(IPage page) : base(page) { }

        private IFrameLocator OuterFrameLocator => Page.FrameLocator("#frame-outer");
        private IFrameLocator InnerFrameLocator => OuterFrameLocator.FrameLocator("#frame-inner");

        public FrameWithButtons OuterFrame => new FrameWithButtons(OuterFrameLocator);
        public FrameWithButtons InnerFrame => new FrameWithButtons(InnerFrameLocator);


        public class FrameWithButtons
        {
            private readonly IFrameLocator frame;
            public FrameWithButtons(IFrameLocator frame)
            {
                this.frame = frame;
            }

            public ILocator EditBtn => frame.Locator("button[data-action='edit']");
            public ILocator SubmitBtn => frame.GetByText("Submit");
            public ILocator ClickMeBtn => frame.Locator("button[name='my-button']");
            public ILocator PrimaryBtn => frame.Locator("button.btn-class");
            public ILocator Result => frame.Locator("#result");
        }
    }
}
