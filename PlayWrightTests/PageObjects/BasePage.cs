using Microsoft.Playwright;

namespace PlayWrightTests.PageObjects
{
    public abstract class BasePage
    {
        protected readonly IPage Page;
        public BasePage(IPage page)
        {
            Page = page;
        }

        public void OnDialog(EventHandler<IDialog> handler) => Page.Dialog += handler;

        // Wait for the next dialog and return it. Caller should await the returned task.
        public Task<IDialog> WaitForDialogAsync()
        {
            var tcs = new TaskCompletionSource<IDialog>();
            EventHandler<IDialog>? handler = null;
            handler = (_, dialog) =>
            {
                Page.Dialog -= handler;
                tcs.TrySetResult(dialog);
            };
            Page.Dialog += handler;
            return tcs.Task;
        }
    }
}
