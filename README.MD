# Selenium WebDriver vs Playwright practical examples

Practical examples comparing Selenium WebDriver and Playwright for .NET using the [UI Test Automation Playground](http://uitestingplayground.com/).

This repository contains side-by-side test implementations that demonstrate how the two frameworks behave in real-world scenarios and provide reusable Page Object patterns you can learn from or adapt.

Scenarios covered
----------------------------
- Element visibility differences
- Interacting with overlapped inputs
- Frames (nested frames) handling
- Select controls (single and multi-select)
- Shadow DOM access
- Alerts / confirm / prompt dialogs
- File upload (iframe-hosted widget)

License
-------
Provided for learning and experimentation.

## Introduction

You’ll find plenty of resources online comparing Selenium WebDriver and Playwright. Most of them offer only high-level overviews or dry facts presented in tables. What I’m interested in is how these two test automation frameworks behave in specific, real-world scenarios — and that’s exactly what this article aims to explore.

Special thanks to the [UI Test Automation Playground](http://uitestingplayground.com/) for providing engaging, hands-on cases to practice and refine automation skills.

## Page navigation and element finding capabilities

Before diving into specific cases of interacting with elements on a page, I’d like to say a few words about how each test automation framework influences project structure, specifically, the declaration of Page Object classes.

The main interface in Selenium is `IWebDriver`. In almost all automation projects I’ve seen, the Page Object class accepts an `IWebDriver` instance as a constructor parameter. I’m not a big fan of this approach, because a Page Object may represent not the entire page, but only a specific section located under another parent element. In such cases, it would make more sense to pass an `ISearchContext` instance to the page object constructor since both `IWebDriver` and `IWebElement` implement `ISearchContext`.

```
public abstract class PageObject
{
	protected readonly ISearchContext Context;
	protected PageObject(ISearchContext search) => Context = search;
}
```
		
This apporach works well until you not need to solve a bit more complex tasks than just searching for an element. Navigation, actions, waitings, JS script execution, dealing with frames all require `IWebDriver`. All that remains is to define bunch of helpers. Honestly, I have never loved such separation.

On the other hand, it makes sense to encapsulate the navigation to a page within the Page Object class itself.

I patially resolve this dilemma by providing two protected constructors in the base [PageObject class](https://github.com/Andrii-Cherepakha/WebUiPlayground/blob/main/SeleniumTests/PageObjects/PageObject.cs): one accepts `IWebDriver`, the other `ISearchContext`. Then, in each derived class, I decide whether that Page Object represents a full page or just a block by exposing only one of these constructors as public.

However, with such approach, I could never shake the feeling that the result was more of a weird mishmash than an elegant solution.

For Playwright, this dilemma just doesn’t exist: the `IPage` interface exposes the GetBy* methods, GotoAsync, EvaluateAsyns, and others at the same level.

## Element visibility

There are several ways to make an element invisible to the user: remove it from the DOM, set its width and height to 0, cover it with another element, move it off-screen, or apply various CSS styles such as opacity: 0, visibility: hidden, or display: none.

It turns out that Selenium and Playwright determine element visibility differently in these cases.

hidden approach   | Selenium `.Displayed`     | Playwright `.IsVisibleAsync()`
|------------- |-------------|-------------
Removed           | NoSuchElementException  | False                        
Zero Width        | False                   | False           
Overlapped        | True                    | True                   
Opacity 0         | False                   | True                   
Visibility Hidden | False                   | False                
Not Displayed     | False                   | False                 
OffScreen         | False                   | True                

An overlapped element is considered visible in both frameworks. When an element is removed from the DOM, Selenium throws `NoSuchElementException`, whereas Playwright behaves in a more user-friendly way: if the element isn’t present, it’s simply treated as not visible. Selenium “doesn’t see” elements with zero opacity or those positioned off-screen, while Playwright considers them visible even though such elements are effectively invisible to the user.

## Input Text Into The Overlapped Element

Another interesting case is entering text into an overlapped element. [The page](http://uitestingplayground.com/overlapped) contains three `<input type="text">` elements: one is fully visible, the second is partially overlapped, and the third is completely overlapped. In all three cases, Selenium and Playwright behave the same way, but I’d say, equally strangely.

With the fully visible input element, there are no surprises, everything works as expected. For the partially overlapped input, you first need to make the element visible. Only calling the JavaScript `scrollIntoView` function helps here. Despite Playwright’s advertised built-in ability to scroll elements during `FillAsync()`, it doesn’t help in this scenario. That said, Playwright does have an advantage: the `EvaluateAsync()` method is available directly on the element itself. In contrast, with Selenium you need to declare an additional helper function that requires two parameters — `IWebDriver` and `IWebElement` — which doesn’t fit quite as smoothly into the project structure.

As for the completely overlapped element, even though it remains invisible, there’s no need to call scrollIntoView. Text can be entered into such an element using the usual built-in methods, just as in the first case.

## Select

In Playwright, you do not need any wrappers like `SelectElement` in Selenium to interact with a select element.

## Frame

The difference in frame-handling approaches is clearly illustrated by [a page](http://uitestingplayground.com/frames) that contains a frame (outer) with another frame (inner) nested inside it.

Selenium treats frames as separate pages — or more precisely, as separate contents — and forces the developer to explicitly switch between these contexts, while also remembering to return to the main (parent) content.

```
driver.SwitchTo().Frame("frame-outer");
driver.SwitchTo().Frame("frame-inner");
FrameTest();
driver.SwitchTo().DefaultContent();
```

Playwright, on the other hand, treats a frame more like a child element. Consequently, when there are multiple nested frames, you get a kind of inheritance-like structure.

```
IFrameLocator outerFrameLocator = Page.FrameLocator("#frame-outer");
IFrameLocator innerFrameLocator = outerFrameLocator.FrameLocator("#frame-inner");
```

In my opinion, Playwright’s approach is more convenient, as it helps avoid confusion of switching between contexts.	

## Shadow DOM

Selenium treats the Shadow DOM and its contents similarly to frames. You must first locate the host element and then call `GetShadowRoot()` on it. If a page contains multiple nested Shadow DOM elements, your code will sooner or later become spaghetti-like. In contrast, Playwright can recognize elements inside the Shadow DOM regardless of their nesting level. You can use regular locators for Shadow DOM elements just as you would for any other element on the page.

## Alert Confirm Prompt dialogs

In Selenium, handling such dialogs is straightforward. You call `SwitchTo().Alert()`, which returns an `IAlert` object on which you perform the required actions (e.g., `Accept()`, `Dismiss()`, `SendKeys()`).

In Playwright, you need to define a dialog handler and attach it before the action that triggers the alert. A tricky part arises when you need to handle several dialogs that appear one after another. In that case, you either introduce a counter inside the handler or implement a custom wait method (e.g., using `WaitForEventAsync<Dialog>`) to wait for each dialog explicitly.

