# Development:
- Install dotnet SDK 9
- Install docker 28.4.0
- PostgreSQL for local development of GreenhouseFactoryService
- PgAdmin if you would like to see what's inside the database
- Install K6 for performance testing

# Test code
- Run a single project by clicking 'start' or similar
- Test all projects together docker compose up --build -d

# Performance testing
- Go to /Src/PerformanceTest
- Run k6 run loadtest.js
- Modify loadtest.js based on number of users/machines and timeframe

# Git
- Before you commit any code checkout a feature branch and make a pull request to main
- Make sure to run docker compose up --build -d and check that all services are running

# Documentation
- Documentation can be found in "Documentation" folder.
- To generate sequence diagram using PlantUML
	- Download PlantUML
	- Open for example "SequenceDiagram.puml"
	- Do your edits
	- Generate image using "plantml SequenceDiagram.puml"

# Run projects
- Open shell (powershell etc.)
- Go to "software_architecture_project\Src"
- docker compose up --build -d

| Purpose | Command | Notes |
|---------|---------|-------|
| Build all images | `docker compose build` | Builds images for all services without starting containers |
| Start containers (foreground) | `docker compose up` | Starts all services, terminal is blocked |
| Start containers (background) | `docker compose up -d` | Starts all services in the background, terminal is free |
| Build and start in background | `docker compose up --build -d` | Builds images first, then starts containers in the background |
| Stop all containers | `docker compose down` | Stops containers and removes networks, images are kept |
| Stop a single container | `docker stop <container_name>` | Stops only the specified service |
| View logs from all services | `docker compose logs -f` | Follows logs live |
| View logs from a single service | `docker compose logs -f <service_name>` | Follows logs live for the specified service |
| List running containers | `docker ps` | Shows all active containers |
| List all containers | `docker ps -a` | Shows all containers, including stopped ones |
