
# Soccer Coach Planner (11v11, 4x20, 4-4-2 numbered roles)

This repository is a starter project for your **Soccer Coach Planner**:

- Pick a squad (max 16) from a static player database.
- Select the **starting 11** for **Quarter 1**.
- Generate a substitution plan for Q2–Q4 that balances minutes across the season.
- **GK (#1) hard rule**: GK can only be replaced by another GK; if no other GK exists, GK stays on.
- Confirm substitutions **individually**; if any planned substitution is rejected, the app prompts to generate a **new plan** for remaining quarters.
- Track goals + assists; adding a goal auto-increments your score.

## Repo layout

- `android-app/` → Android app (Kotlin + Jetpack Compose)
- `backend/` → ASP.NET Core minimal API (Azure App Service friendly)
- `database/` → Azure SQL schema + seed scripts
- `.github/workflows/` → GitHub Actions cloud builds (no local admin rights needed)

---

## 1) Build Android APK in GitHub (no local admin rights)

This repo includes a GitHub Actions workflow that builds a **debug APK** and publishes it as an **artifact**.

### Steps

1. Upload this repository to GitHub.
2. Go to **Actions** tab → run **Android CI - Build APK**.
3. Open the workflow run → download the **artifact** `app-debug-apk`.

> Notes
> - Play Store requires AAB + signing; this starter ships debug APK build for easiest distribution.
> - The workflow uses `android-actions/setup-android` and `gradle/actions/setup-gradle`.

---

## 2) Backend API

The Android app should not connect directly to Azure SQL. Use the backend API as a secure middle tier.

Run locally (if you have a dev box) from `backend/SoccerCoach.Api`:

```bash
# set connection string in appsettings.json or environment
DOTNET_ENVIRONMENT=Development dotnet run
```

Swagger UI is enabled at `/swagger`.

---

## 3) Database

Run `database/schema.sql` on Azure SQL Database.
Then run `database/seed_positions_442.sql`.

---

## 4) What is implemented vs placeholder

Implemented:
- Android starter navigation & placeholder screens
- Backend: health, players list, create match, add goal (auto increments score)
- Database: schema + 4-4-2 numbered role seed

Placeholder:
- Substitution planner algorithm
- Individual substitution confirmation flow endpoints

