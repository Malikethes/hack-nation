# Swift&Found - Lost & Found Management System

**HackNation 2025 Submission**

A modern web platform connecting people with their lost items. Built with Nuxt 4 + Vuetify 3 frontend and .NET 8 Web API backend.

## Key Features
-  Photo upload with AI-powered search (coming soon)
-  Interactive Google Maps integration
-  Admin dashboard with real-time statistics
-  Advanced filtering and search
-  Draft/Published/Archived item states
-  Cloudinary image hosting

## Tech Stack
**Frontend:** Nuxt 4.2, TypeScript, Vuetify 3, Google Maps API  
**Backend:** .NET 8, SQL Server, Entity Framework Core, Cloudinary

## Frontend Setup

Make sure to install dependencies:

```bash
npm install
```

## Development Server

Start the development server on `http://localhost:3000`:

```bash

npm run dev

```

## Production

Build the application for production:

```bash

npm run build
```

Locally preview production build:

```bash
npm run preview
```

Check out the [deployment documentation](https://nuxt.com/docs/getting-started/deployment) for more information.

## Backend Setup
```bash
cd webApi/webApi
dotnet restore
dotnet ef database update
dotnet run
```
