# PiOs-UVA
A Launcher as "OperatingSystem" for the Raspberry Pi 2 with Windows 10 IoT Core

# Universal Windows App

This repo contains a App Launcher for the Universal Windows Platform (UWP) in the Windows Software Development Kit (SDK) for Windows 10. These code was created with the Universal Windows templates available in Visual Studio, and are designed to run on desktop, mobile, and future devices that support the Universal Windows Platform.  

## Universal Windows Platform development

The project require Visual Studio 2015 and the Windows Software Development Kit (SDK) for Windows 10 to build, test, and deploy your Universal Windows apps. 

   [Get a free copy of Visual Studio 2015 Community Edition with support for building Universal Windows apps](http://go.microsoft.com/fwlink/?LinkID=280676)

Additionally, to stay on top of the latest updates to Windows and the development tools, become a Windows Insider by joining the Windows Insider Program.

   [Become a Windows Insider](https://insider.windows.com/)

## Using the Launcher

The easiest way to use the app without using Git is to download the zip file containing the current version (using the link below or by clicking the "Download ZIP" button on the repo page). You can then unzip the entire archive and use the app in Visual Studio 2015.

   [Download the App ZIP](../../archive/master.zip)

   **Notes:** 
   * Before you unzip the archive, right-click it, select Properties, and then select Unblock.
   * Be sure to unzip the entire archive, and not just individual files.   
   * In Visual Studio 2015, the platform target defaults to ARM, so be sure to change that to x64 or x86 if you want to test on a non-ARM device. 
   
The app uses Linked files in Visual Studio to reduce duplication of common files, including app template files and image assets.  
These common files are stored in the other folders at the root of the repository and referred to in the project files using links.  

**Reminder:** If you unzip individual files, they will not build due to references to other portions of the ZIP file that were not unzipped. You must unzip the entire archive if you intend to build the app.

For more info about the programming models, platforms, languages, and APIs demonstrated in these app, please refer to the guidance, tutorials, and reference topics provided in the Windows 10 documentation available in the [Windows Developer Center](https://dev.windows.com). 
(These samples are provided as-is in order to indicate or demonstrate the functionality of the programming models and feature APIs for Windows.)

## Contributions

The app is direct from the HiGHTECHNiX-Teams and we welcome your input on issues and suggestions for new features.  
At this time we are not accepting new features from the public, but check back here as we evolve our contribution model.

## See also

For additional Windows samples, see [Windows on GitHub](http://microsoft.github.io/windows/). 
