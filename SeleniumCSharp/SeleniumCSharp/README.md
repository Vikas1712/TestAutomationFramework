#  ✨ About

🚀 Selenium Framework using C# (CSharp) development from scratch

##  ✨ Requirements.
- Visual Studio IDE 2022
- JetBrain Rider 2022.2.3

##  ✨ Instructions for Windows
-  Clone the repo \
   `https://github.com/Vikas1712/TestAutomationFramework.git`
- Once done, open the solution in Visual Studio IDE or JetBrain Rider \
  `SeleniumCSharp.sln`
- Install Nuget packgae \
  `Right-click on project and click "Manage NuGet Package" and install it`

##  ✨ Package information
### Framework used
- `Selenium WebDriver` is an open-source web automation framework that permits you to execute cross-browser tests.
- `Specflow` is a tool supporting BDD (Behavior Driven Development) practices in .NET framework
- `ExtentReport` allows to generate custom logs, snapshots along with pie chart and dashboard

##  ✨ Structure
- `Base`- Page Initialization with base class
- `Config`- Configuration of config xml file
- `Extension`- WebDriver and WebElement extension method
- `Feature`- Feature reside here
- `Hooks`- Specflow hooks
- `Pages`- Pages of POM (Page Object Model)
- `Steps`- Step definition glue code reside here
- `Result`- Test result
- `ReadMe`- Framework development and instruction document

##  ✨ CodeBase is developed on below  components
-   [🚀 Page Initialization with Base Class]
-   [🚀 Page Navigation]
-   [🚀 Page Generator]
-   [🚀 WebDriver and WebElement Extension Methods]

## 🚀 Page Initialization with Base Class

### Old Code Implementation:
    Many times, we try to pass the WebDriver object over and over again from one class to another class.
    By the means of Constructor or passing it as a parameter in the method where IWebDriver instance is required.

![image](https://user-images.githubusercontent.com/13363157/180227839-15b0eefe-e70b-4fbd-b82f-910d411764d5.png)

### New	Code Implementation
      Created a base abstract class and create a private property
![image](https://user-images.githubusercontent.com/13363157/180231069-97e8d61a-e6fd-47fa-a092-727cdbca867e.png)

## 🚀 Page Navigation

### Old Code function without return type
    We create a function or method without any return type.
![image](https://user-images.githubusercontent.com/13363157/180240799-628e1b95-74f7-452b-8b79-bd32bfd1214f.png)
### New Code for Page Navigation
    Ensure that business logic is embedded in our test code.
    We can establish relationships between each page.
    While an operation is performed on one method it may or may not return a page object.
![image](https://user-images.githubusercontent.com/13363157/180239114-a15383c9-51fd-4ee8-aac1-b02afcdf81e1.png)

## 🚀 Page Generator

### The Thumb Rule of Factory Design Pattern is the avoiding object initialization in the test.
#### Old Code
![image](https://user-images.githubusercontent.com/13363157/180242809-7adb3591-26fc-4d35-8b6e-baaddc260a95.png)
#### New Code
        How did we accomplish this? Generics in C# were used to accomplish this. 
        In the following section, we discuss this topic in more detail
![image](https://user-images.githubusercontent.com/13363157/180243477-caceffc6-cf37-4cb7-befa-704d7c74cf63.png)

## 🚀 Introduction to Generics in C#
    Generics in C# give the user the ability to write classes or functions that can work with any data type easily.
    We might say a generic class or function that is compatible with any other data type. 
    All we need to do is define it with a placeholder.
    To put it simply, we have to write a set of methods or classes that take arguments based on the data type. 
    The constructor will therefore generate code to handle the specified data type when it encounters a compiler.

### Generics Implementation in Code
![tempsnip1](https://user-images.githubusercontent.com/13363157/180247732-a0cbb510-f019-4dfa-9a02-0d694ee1600d.png)


## 🚀 WebDriver and WebElement Extension Methods
    Extension Methods enable you to add methods to an existing type without creating a new derived type.
    An extension method is a static method of a static class.
    Where the “this” modifier is applied to the first parameter.
    The type of the first parameter will be the type that is extended.
![image](https://user-images.githubusercontent.com/13363157/180249818-79f459f1-5883-459d-815a-6b96a8b61f25.png)

## Calling extension method in script
![image](https://user-images.githubusercontent.com/13363157/180250869-ddcbd2a8-f089-4a26-8200-178fe102a88a.png)

## 🚀 Further, proposed improvements
- Executing test in parallel
