# 🎮 Stunt Kings - Game Design Document

## 📋 Overview

**Stunt Kings** ist ein 3D Parkour Jump & Run Spiel für iOS, das kostenlos spielbar ist mit optionalen Premium-Features.

---

## 🎯 Core Gameplay

### Grundmechaniken
- **Springen & Landen** - Präzise Parkour-Bewegungen
- **Hindernisse** - Verschiedene Obstacles zum überwinden
- **Kollision & Fallen** - Spieler fällt aus dem Spiel bei Fehler
- **Laufen zur Ziellinie** - Wer zuerst die Ziellinie erreicht, gewinnt

### Match-Format
- **32 Spieler pro Match** (online oder Bots offline)
- **Timed Match** - 5 Minuten pro Runde
- **Survival Style** - Letzte verbliebene Spieler gewinnen

---

## 👥 Charaktere (20+)

### Seltenheitsstufen
1. **Gewöhnlich (Common)** - Grau | Kostenlos
2. **Selten (Rare)** - Blau | 0,99€
3. **Superselten (SuperRare)** - Orange | 1,99€
4. **Episch (Epic)** - Lila | 2,99€
5. **Legendär (Legendary)** - Gold | 4,99€
6. **Geheim (Secret)** - Rot/Pink | 7,99€

### Charaktere pro Rarity
- Common: 3 Charaktere
- Rare: 3 Charaktere
- SuperRare: 3 Charaktere
- Epic: 3 Charaktere
- Legendary: 3 Charaktere
- Secret: 2 Charaktere (versteckt)

**Total: 17 Charaktere + 3 Starter-Charaktere = 20 Charaktere**

---

## 😄 Emote-System (8 Abilities)

### 4 Equipable Slots
Spieler können **4 verschiedene Emotes** gleichzeitig ausrüsten.

### Cooldown: 10 Sekunden pro Emote

### Die 8 Emotes:

| # | Name | Icon | Effekt | Duration | Cooldown |
|---|------|------|--------|----------|----------|
| 1 | 💨 Speed Boost | 🏃 | +50% Geschwindigkeit | 3s | 10s |
| 2 | 🛡️ Shield | 🛡️ | Immun vor 1 Hindernis | 3s | 10s |
| 3 | 👻 Ghost Mode | 👻 | Unsichtbar/Unverwundbar | 3s | 10s |
| 4 | 🚀 Jump Boost | 🚀 | Doppelte Jump-Höhe | 3s | 10s |
| 5 | 🌪️ Slow Motion | ⏱️ | Zeit um 50% verlangsamt | 3s | 10s |
| 6 | ❄️ Freeze Enemies | 🥶 | Gegner verlangsamt (20m Range) | 3s | 10s |
| 7 | 💪 Super Strength | 💪 | Hindernisse durchbrechen | 3s | 10s |
| 8 | 🎯 Precision | 🎯 | Bessere Landing-Kontrolle | 3s | 10s |

---

## 🏆 Battle Pass System

### Kostenlos vs. Premium
- **Kostenlose BP**: 50 kostenlose Tiers mit Rewards
- **Premium BP**: 50 zusätzliche Premium Tiers (4,99€)

### Reward-Typen
- 💰 In-Game Geld
- 💎 Premium Currency
- 👥 Charaktere freischalten
- 😄 Emotes freischalten
- 🎨 Skins
- ⚡ XP Booster

### XP Progression
- XP verdienen pro Match (je nach Platzierung)
- 1. Platz: 500 XP
- 2. Platz: 400 XP
- 3. Platz: 300 XP
- Andere: 100 XP

---

## 💳 Shop-System

### Währungen
1. **Gold (Kostenlos)**
   - Verdient durch Spiele
   - Kauft Common/Rare/SuperRare Items
   
2. **Diamanten (Premium)**
   - Mit echtem Geld kaufbar
   - Kauft Epic/Legendary/Secret Items

### Preise (Beispiel)
- Common Charakter: Kostenlos
- Rare Charakter: 0,99€
- SuperRare Charakter: 1,99€
- Epic Charakter: 2,99€
- Legendary Charakter: 4,99€
- Secret Charakter: 7,99€
- Premium Battle Pass: 4,99€
- Emotes: 0,99€ - 2,99€

---

## 🌐 Multiplayer

### Online-Modus
- **Live gegen echte Spieler** (32 Spieler)
- Powered by **Photon PUN 2**
- Echtzeit-Leaderboard
- Cross-Device Play (iOS)

### Offline-Modus
- **Gegen KI/Bots** (anpassbar: 4-32 Bots)
- Trainings-Level
- Local nur (kein Internet nötig)
- Vollständige Features verfügbar

---

## 🎨 UI/UX

### Main Menu
- Play Online / Play Offline
- Shop
- Battle Pass
- Charaktere
- Einstellungen

### Game UI
- Leben-Anzeige (Spieler aktuell im Match)
- Timer (verbleibende Zeit)
- Leaderboard (Echtzeit)
- Ability Slots (mit Cooldown-Anzeige)

---

## 💰 Monetisierung

### Free-to-Play Model
- ✅ Kostenlos downloaden
- ✅ Komplettes Spiel spielbar ohne zu zahlen
- ✅ Premium beschleunigt Progression
- ✅ Keine Pay-to-Win Mechaniken

### Revenue Streams
1. **Battle Pass Premium** (4,99€ pro Season)
2. **Premium Charaktere** (0,99€ - 7,99€)
3. **Premium Emotes** (0,99€ - 2,99€)
4. **Cosmetics/Skins** (optional zukünftig)
5. **Optional: Non-intrusive Ads** (für extra Rewards)

---

## 🎮 iOS Optimierungen

- 🎯 Optimiert für iPhone 12+
- 📱 Responsive UI für alle Screen-Größen
- ⚡ 60 FPS Target
- 🔋 Battery-optimized
- 🌐 Online mit WiFi/4G/5G
- 💾 Kleine App Size (~150-200MB)

---

## 📊 Progress Tracking

- Spieler-Profil mit Stats
- Gewonnene Matches
- Gesamt XP
- Charaktere & Emotes im Besitz
- Battle Pass Progress
- Leaderboard Rankings

---

**Version:** 1.0 Design  
**Last Updated:** 2026-07-05  
**Status:** In Development 🚀
