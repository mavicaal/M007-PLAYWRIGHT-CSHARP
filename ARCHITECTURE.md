# Architecture & Flow Diagrams

## 1. Project Architecture

```
┌─────────────────────────────────────────────────────────────────┐
│                    Test Automation Framework                    │
│                  (Playwright + C# + POM Pattern)                │
└─────────────────────────────────────────────────────────────────┘

                              │
        ┌───────────────────┬─┴──────────────────┬──────────────────┐
        │                   │                    │                  │
    ┌───▼────┐      ┌──────▼────┐      ┌───────▼──┐      ┌────────▼──┐
    │  Tests │      │   Pages   │      │ Drivers  │      │  Config   │
    │ (NUnit)│      │   (POM)   │      │          │      │           │
    └───┬────┘      └──────┬────┘      └───────┬──┘      └────────┬──┘
        │                  │                   │                  │
        │         ┌────────┴──────────┐        │                  │
        │         │                   │        │                  │
    ┌───▼─────────▼─────┬──────────────▼────┬──▼──────────────────▼──┐
    │   Base Classes    │   Utilities       │   Helpers & Support    │
    ├───────────────────┼───────────────────┼────────────────────────┤
    │ • BaseTest        │ • LoggerSetup     │ • WaitHelpers          │
    │ • BasePage        │ • Screenshot      │ • TestDataProvider     │
    │                   │                   │                        │
    └───────────────────┴───────────────────┴────────────────────────┘
                              │
        ┌───────────────────┬─┴──────────────────┐
        │                   │                    │
    ┌───▼────────┐  ┌──────▼────┐      ┌───────▼──┐
    │  Logging   │  │ Config    │      │ Reports  │
    │ (Serilog)  │  │ (.json)   │      │          │
    └────────────┘  └───────────┘      └──────────┘
```

## 2. Test Execution Flow

```
┌─────────────────────────────────────────────────────┐
│          Test Execution Lifecycle                   │
└─────────────────────────────────────────────────────┘

    ┌─────────────────────────┐
    │  NUnit Test Framework   │
    └───────────┬─────────────┘
                │
    ┌───────────▼─────────────┐
    │   [SetUp] BaseTest      │
    │  - Create Logger        │
    │  - Initialize Browser   │
    │  - Create Context       │
    │  - Create Page          │
    └───────────┬─────────────┘
                │
    ┌───────────▼──────────────────┐
    │  [Test Method]               │
    │  - Arrange                   │
    │    └─ Prepare test data      │
    │    └─ Create page objects    │
    │  - Act                       │
    │    └─ Call page methods      │
    │  - Assert                    │
    │    └─ Verify results         │
    └───────────┬──────────────────┘
                │
    ┌───────────▼─────────────────────┐
    │  [TearDown] BaseTest            │
    │  - Capture screenshot (if fail) │
    │  - Close browser context        │
    │  - Close browser                │
    │  - Flush logs                   │
    └─────────────────────────────────┘
```

## 3. Page Object Model Pattern

```
                    ┌──────────────────┐
                    │   Web Page       │
                    │  (HTML/DOM)      │
                    └────────┬─────────┘
                             │
                    ┌────────▼────────┐
                    │  Selectors      │
                    │  CSS/XPath      │
                    └────────┬────────┘
                             │
    ┌────────────────────────▼────────────────────────┐
    │         Page Object Interface                   │
    │  (ILoginPage, IHomePage, etc.)                  │
    │  - Defines contract for page                    │
    │  - Lists public methods                         │
    └────────────────┬─────────────────────────────────┘
                     │
    ┌────────────────▼─────────────────────────────────┐
    │      Page Object Implementation                 │
    │  (LoginPage, HomePage, etc.)                    │
    │  - Extends BasePage                             │
    │  - Private selector constants                   │
    │  - Public interaction methods                   │
    └────────────────┬─────────────────────────────────┘
                     │
    ┌────────────────▼─────────────────────────────────┐
    │           BasePage                              │
    │  - Common interaction methods                   │
    │  - Built-in logging                             │
    │  - IPage dependency                             │
    └────────────────┬─────────────────────────────────┘
                     │
    ┌────────────────▼─────────────────────────────────┐
    │      Playwright IPage                           │
    │  - Browser automation engine                    │
    │  - DOM interaction                              │
    └──────────────────────────────────────────────────┘
```

## 4. Configuration Flow

```
┌─────────────────────────────────────────┐
│       appsettings.json                  │
│  ┌─────────────────────────────────────┐│
│  │ Playwright                          ││
│  │  - BrowserType: Chromium            ││
│  │  - Headless: true                   ││
│  │  - Timeout: 30000                   ││
│  │                                     ││
│  │ Application                         ││
│  │  - BaseUrl: https://example.com    ││
│  │  - Environment: Staging             ││
│  └─────────────────────────────────────┘│
└────────────────┬────────────────────────┘
                 │
    ┌────────────▼────────────┐
    │ ConfigurationManager    │
    │ - Load settings         │
    │ - Parse JSON            │
    │ - Map to classes        │
    └────────────┬────────────┘
                 │
        ┌────────┴────────┐
        │                 │
    ┌───▼──────┐   ┌─────▼──┐
    │Playwright│   │ App    │
    │Settings  │   │Settings│
    └───┬──────┘   └─────┬──┘
        │                 │
    ┌───▼─────────────────▼──┐
    │   BrowserManager       │
    │   (Initialization)     │
    └────────────────────────┘
```

## 5. Data Flow

```
┌──────────────────────────────────┐
│   TestDataProvider               │
│  ┌──────────────────────────────┐│
│  │ Users                        ││
│  │  - ValidUser                 ││
│  │  - AdminUser                 ││
│  │  - InvalidUser               ││
│  │                              ││
│  │ Products                     ││
│  │  - ValidProduct              ││
│  │  - OutOfStockProduct         ││
│  │                              ││
│  │ Addresses                    ││
│  │  - ValidAddress              ││
│  │  - InvalidAddress            ││
│  └──────────────────────────────┘│
└────────────────┬─────────────────┘
                 │
    ┌────────────▼────────────┐
    │   Test Method           │
    │  ┌────────────────────┐ │
    │  │ var user =         │ │
    │  │  TestDataProvider  │ │
    │  │  .Users            │ │
    │  │  .ValidUser        │ │
    │  └────────────────────┘ │
    └────────────┬────────────┘
                 │
    ┌────────────▼────────────┐
    │   Page Object Method    │
    │  ┌────────────────────┐ │
    │  │ await page         │ │
    │  │  .LoginAsync(      │ │
    │  │   user.Username,   │ │
    │  │   user.Password    │ │
    │  │  )                 │ │
    │  └────────────────────┘ │
    └────────────────────────┘
```

## 6. Logging & Reporting Flow

```
┌─────────────────────────────────────┐
│   Test Execution                    │
│  (Page interactions)                │
└────────────────┬────────────────────┘
                 │
    ┌────────────▼──────────────┐
    │   BasePage Methods        │
    │  (with logging)           │
    │  - ClickAsync()           │
    │  - FillAsync()            │
    │  - GetTextAsync()         │
    └────────────┬──────────────┘
                 │
    ┌────────────▼──────────────┐
    │   Serilog                 │
    │   (Structured Logging)    │
    └────┬───────────────────┬──┘
         │                   │
    ┌────▼─────┐      ┌─────▼──────┐
    │ Console  │      │ File Sink  │
    │ Output   │      │ (Daily)    │
    └──────────┘      └─────┬──────┘
                            │
                ┌───────────▼──────────┐
                │ Reports/Logs/        │
                │ log_YYYY-MM-DD.txt   │
                └──────────────────────┘

    ┌────────────────────────────────┐
    │  Test Failure                  │
    └────────────────┬───────────────┘
                     │
    ┌────────────────▼────────────────┐
    │  ScreenshotHelper               │
    │  .CaptureScreenshotAsync()      │
    └────────────────┬────────────────┘
                     │
                ┌────▼────────────────┐
                │ Reports/Screenshots/│
                │ TestName_timestamp  │
                └─────────────────────┘
```

## 7. Class Inheritance Hierarchy

```
┌─────────────────────────────────────────────────────┐
│              IPage (Playwright)                     │
└────────────────────┬────────────────────────────────┘
                     │
    ┌────────────────▼────────────────┐
    │         BasePage                │
    │  - Common interaction methods   │
    │  - Logging integration          │
    │  - Protected helper methods     │
    └────────────────┬────────────────┘
                     │
        ┌────────────┼────────────┐
        │            │            │
    ┌───▼────┐  ┌──▼──────┐  ┌──▼──────┐
    │LoginPage  │HomePage│  │...Page   │
    │(: ILogin) │(: IHome)│  │         │
    └──────────┘ └────────┘  └─────────┘


┌─────────────────────────────────────────────────────┐
│              object (C#)                            │
└────────────────────┬────────────────────────────────┘
                     │
    ┌────────────────▼────────────────┐
    │         BaseTest                │
    │  - SetUp / TearDown             │
    │  - Browser initialization       │
    │  - Logger setup                 │
    └────────────────┬────────────────┘
                     │
        ┌────────────┼────────────┐
        │            │            │
    ┌───▼─────┐  ┌─▼──────┐  ┌─▼──────┐
    │LoginTest  │HomeTest│  │...Test   │
    │          │        │  │         │
    └──────────┘ └────────┘  └─────────┘
```

## 8. Dependency Injection Pattern

```
┌───────────────────────────────────┐
│  ConfigurationManager             │
│  - Loads appsettings.json         │
│  - Creates settings objects       │
└────────────────┬──────────────────┘
                 │
    ┌────────────▼────────────┐
    │  BrowserManager         │
    │  - Uses config to       │
    │    initialize browser   │
    └────────────┬────────────┘
                 │
    ┌────────────▼────────────┐
    │  Page Objects           │
    │  - Constructor(IPage)   │
    │  - Use injected page    │
    └────────────┬────────────┘
                 │
    ┌────────────▼────────────┐
    │  Tests                  │
    │  - Create browser       │
    │  - Create pages         │
    │  - Run tests            │
    └────────────────────────┘
```
