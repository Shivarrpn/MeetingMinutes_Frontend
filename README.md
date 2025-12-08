# Meeting Minutes Frontend
Record and track management meetings and their minutes.

* [Meeting Minutes Backend API application](https://github.com/Shivarrpn/MeetingMinutes.git)

---

## 🚀 Description
This is the frontend application which will be used as the app for which the user can view, create, and edit data. This application allows users to keep track of their meetings, minutes, and tasks.

## ✨ Features
* Select the type of meeting being held
* Meeting items from the previous meeting can be retrieved and loaded into the new meeting
* When a meeting is initiated, the status of previous meeting items can be updated and new meeting items can be added
* Lookup tables allow the user to view reports on the progress of meetings, meeting items, and employees assigned to tasks

## 🛠️ Installation & Setup
> Before proceeding, if you have not as yet, please make sure that the API is successfully running on your PC. You may download it from the OneDrive folder in the Executables folder and follow the instructions on the [README for the API](https://github.com/Shivarrpn/MeetingMinutes/blob/master/README.md).



### Prerequisites
The below are required for the installation to run successfully:


#### If you wish to pull the code into an IDE, Visual Studio Community 2026 was the IDE used to develop the frontend
1. Download and install [Visual Studio Community](https://visualstudio.microsoft.com/downloads/)
   1. When running the installer, please select the following workloads:
       * .NET desktop development
       * Data storage and processing
   2. Download and install
2. Once installation is completed, clone the repository:
   1. On the right, click **Clone a repository**
   2. Under **Repository Location**, paste the following: https://github.com/Shivarrpn/MeetingMinutes_Frontend.git
   3. Under **Path**, it should default to `C:\Users\[Your_Username]\source\repos`
   4. Click **Clone**

### Steps
1. In the [OneDrive folder](https://1drv.ms/f/c/46d7247e90cd6e1f/EpabWFn7e1FNuhy8ms3tzgABlIv5hoGlUb8xENORO1k3zA) provided, you'll find the **Executables folder** which contains the **MeetingMinutes.exe** file. Download the file.
2. Make sure that the API is running successfully. You can test it by running this link [test link](http://localhost/test/get). A message will be returned saying: ```API running Successfully! You may proceed to use the Meeting Minutes Application```. If you do not see this, please follow the instructions of the [API README](https://github.com/Shivarrpn/MeetingMinutes/blob/master/README.md) or if you already setup the API, please run the **MeetingMinutes API.jar** file and test again.
3. Run the **MeetingMinutes.exe** and the application will open. If the API is accessible, a message in green font will be displayed on the top-left of the applicable dashboard stating: ```API running Successfully! You may proceed to use the Meeting Minutes Application```

## 💡 Usage
This is the UI application which will be the actual applicable used by the end user to track meetings, assign tasks, and run reports.

## 💾 Database
### Please see below the ERD for only meeting related entities:

<img width="474" height="451" alt="MeetingMinutes ERD" src="https://github.com/user-attachments/assets/c373ffe7-d876-4395-84c9-b3968c863af2" />


### This is the database diagram with all entities:

<img width="1634" height="1320" alt="meeting_minutes_schema" src="https://github.com/user-attachments/assets/d56e0ffe-527d-4eef-a424-c59bb3f72cef" />
