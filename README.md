Overview

RadarLibrary is a library that enables communication with a radar system through HTTP requests. It provides functionality to fetch radar status and radar target data using an HTTP client.

This library handles deserialization of JSON responses from the radar system, ensuring errors are handled gracefully. It is built using C# and leverages the Newtonsoft.Json library for JSON parsing.


Features

Fetch Radar Status:

Check if the radar is online or offline.
Handles exceptions and errors during the status check.

Retrieve Radar Target Data:

Fetch a list of radar targets with information such as ID, distance, angle, speed, and strength.
Handles JSON deserialization errors and HTTP request failures.


Requirements
.NET Framework: .NET 6 or higher


Dependencies:
Newtonsoft.Json (Install via NuGet: Install-Package Newtonsoft.Json)


Installation
Clone or download the RadarLibrary repository.
Add the RadarLibrary project to your solution.
Ensure that the Newtonsoft.Json package is installed.
