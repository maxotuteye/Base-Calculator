# Base-Calculator
WPF App that converts values from any base, to their representation in any other base.

## Tools
The project was built with Microsoft Visual Studio using C#.

## Build
To build, simply clone the repo into Visual Studio, allow it to download dependencies, and then build.

## Algorithm
1. A value is first converted from its base to base 10 (intermediary base), unless it is already in base 10.
2. This converted value is then converted to the new base (unless the new base is base 10).
3. Conversions are performed using repeated modulos on the values, with adjusted exponents.

## Screenshots
![image](https://user-images.githubusercontent.com/37118417/173659370-90158726-57cc-41d0-a06d-0f799bb02be0.png)
![image](https://user-images.githubusercontent.com/37118417/173659381-bffb92db-7921-47fd-b489-5890cb7e9cba.png)
