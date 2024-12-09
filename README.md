# SpanishPoint
Testcase for SpanishPoint


Setup:

The SetUp method initializes the ChromeDriver and maximizes the browser window.

Test Steps:

Navigate to the Matching Engine website.
Locate and expand the Modules menu.
Click the Repertoire Management Module link.
Scroll to the Additional Features section using JavaScript.
Click the Products Supported button.
Verify that the heading for supported products is visible.
Fetch and assert the list of supported products is not empty, then print them to the console.


TearDown:

The TearDown method ensures the browser is closed after the test is completed.
