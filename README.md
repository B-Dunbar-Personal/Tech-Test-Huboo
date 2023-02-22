# AutomatedTest Background information

This was a tech test created for my application at Huboo

Test 1
- Navigate to https://the-internet.herokuapp.com/ 
- Click Challenging DOM 
- Confirm that the blue, red, and green button ids change after the red button is clicked 
 
Test 2
- Navigate to https://the-internet.herokuapp.com/ 
- Click Dynamic Loading 
- Click Example 2: Element rendered after the fact 
- Click Start 
- Confirm 'Hello World!' is rendered after the loading bar disappears 

## Project Information
- Project dependency is Configuration > Common > Tests
- Configuration values for Launch options are tokenised so they can be replaced by a build/release pipeline for deployment
- We have a [Base Test](Common/BaseTestSetup.cs) that you can inherit to use with tests added to the project, BaseTest will also Initalise Configuration
- Pages are all internal [Example](Common/Sites/herokuapp/Pages/DynaimcLoading.cs) and Inherit [Base Playwright Page](Common/Sites/BasePlaywrightPage.cs). Use actions to chain multiple elements together and turn that into a method example EnterLogingDetailsAndSubmit()
- We use [Global usings](Common/GlobalUsings.cs) to keep the common usings out of classes