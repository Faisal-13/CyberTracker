# 🛡️ CyberTracker

> **Monitoring the Digital Frontier**


## 📖 About The Project

**CyberTracker** is a cybersecurity incident management dashboard built with **ASP.NET Core**. It is designed to help organizations streamline the detection, tracking, and resolution of digital threats.

Beyond just logging incidents, CyberTracker acts as an education hub, providing security awareness tips to help users stay ahead of potential risks like phishing and social engineering.

## ✨ Key Features

* **🚨 Incident Logging:** Create and track security threats (e.g., Phishing, Malware, Brute Force).
* **📊 Severity Management:** Categorize incidents by severity (Critical, High, Medium, Low) with visual indicators.
* **✅ Workflow Tracking:** Manage the lifecycle of an incident from **Open** to **Investigating** to **Resolved**.
* **💡 Awareness Hub:** A dedicated section for "Security Tips" to educate users on best practices.
* **🔐 Admin Dashboard:** Secure management of all data.

## 🛠️ Built With

* **Framework:** [ASP.NET Core](https://dotnet.microsoft.com/) (C#)
* **Database:** Entity Framework Core & SQL Server
* **Frontend:** Razor Pages / MVC, Bootstrap, CSS
* **Tools:** Visual Studio

## 🚀 Getting Started

To get a local copy up and running, follow these steps.

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download) installed.
* SQL Server (LocalDB or full instance).

### Installation

1.  **Clone the repository**
    ```bash
    git clone [https://github.com/yourusername/CyberTracker.git](https://github.com/yourusername/CyberTracker.git)
    ```
2.  **Navigate to the project directory**
    ```bash
    cd CyberTracker
    ```
3.  **Update the Database** (Apply Entity Framework Migrations)
    ```bash
    dotnet ef database update
    ```
4.  **Run the Application**
    ```bash
    dotnet run
    ```

## 💻 Usage

1.  Open your browser and navigate to `https://localhost:5001` (or the port shown in your terminal).
2.  **Log in** using the administrator credentials (seeded in `SeedData.cs`):
    * **Email:** `admin@cybertracker.com`
    * **Password:** *(Check your SeedData file, typically `Admin123!` or `P@ssword1`)*
3.  Navigate to the **Incidents** tab to view the dashboard.


## 🤝 Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

## 📝 License

Distributed under the MIT License. See `LICENSE` for more information.

## 📧 Contact

**Project Link:** [https://github.com/yourusername/CyberTracker](https://github.com/Faisal-13/CyberTracker)
