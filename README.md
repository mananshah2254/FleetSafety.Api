# Fleet Safety  
### .NET 8 • SQL Server • Docker • AWS EC2 • HTML/Bootstrap UI

This is a lightweight Fleet Safety Management application built to demonstrate full-stack engineering skills including backend API development, SQL modeling, Docker containerization, cloud deployment, and simple front-end UI integration.

---

## ☁️ 1. Deploying to AWS EC2

### 1.1 EC2 Setup

- **OS:** Ubuntu 22.04 LTS  
- **Instance Type:** `t3.small`, `c7i-flex.large`, etc.  
- **Security Group – Inbound Rules:**
  - `22` (SSH) from **your IP**
  - `80` (HTTP) from **0.0.0.0/0** (for demo access)
  - *(Optional)* `8080` if you expose that port directly

---

### 1.2 Install Docker & Docker Compose

**SSH into EC2:**

    ssh -i /path/to/your-key.pem ubuntu@<EC2_PUBLIC_IP>

**Install Docker & Docker Compose:**

    sudo apt update
    sudo apt install -y docker.io docker-compose
    sudo usermod -aG docker ubuntu

Log out and back in so the `docker` group takes effect:

    exit
    ssh -i /path/to/your-key.pem ubuntu@<EC2_PUBLIC_IP>

---

### 1.3 Clone the Project


    git clone https://github.com/mananshah2254/FleetSafety.Api.git

---

### 1.4 Run on EC2

On the **EC2 instance**:

    cd ~/FleetSafety.Api
    docker-compose build
    docker-compose up -d
    docker ps

If you want the app directly on port **80**, update `docker-compose.yml` for the API service:

    ports:
      - "80:8080"

---

### 1.5 Access the App

Open in your browser:

    http://<EC2_PUBLIC_IP>/



# 📌 2. Features

### ✅ Drivers Module
- Add, view, list, update, remove drivers  
- Stores license details, active status, hire date  

### ✅ Vehicles Module
- Add, view, list vehicles  
- Stores make/model/year/truck numbers  

### ✅ Inspection Records
- Link inspections to drivers & vehicles  
- Track violations, notes, pass/fail results  
- All CRUD operations supported  

### ✅ Full REST API (ASP.NET Core)
- Built with .NET 8 Web API  
- EF Core for data access  
- JSON cycle-safe serialization  

### ✅ Simple Front-end UI
- Built with HTML + Bootstrap  
- Uses JavaScript `fetch()` to call API  
- Runs directly from `wwwroot/index.html`

### ✅ Dockerized
- API container  
- SQL Server container  
- Fully orchestrated with Docker Compose  

### ✅ AWS Deployment
- Runs on EC2 Ubuntu instance  
- Publicly accessible via instance IP  
- Infrastructure defined through Docker  

---

# 🛠 3. Tech Stack

| Layer      | Technology                         |
|-----------|-------------------------------------|
| API       | ASP.NET Core 8 Web API             |
| Database  | SQL Server 2022 (Dockerized)       |
| ORM       | Entity Framework Core              |
| Frontend  | HTML + Bootstrap + Vanilla JS      |
| Contain.  | Docker & Docker Compose            |
| Cloud     | AWS EC2 (Ubuntu)                   |
| JSON      | System.Text.Json (IgnoreCycles)    |


