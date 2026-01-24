Bowling Buddy:

Track your bowling stats on your way to mastery

# Bowling App - Backend Tasks

## Phase 1: MVP (No Auth)

### Setup
- [X] Create solution with 4 projects (Domain, Application, Infrastructure, API)
- [X] Set up database with Docker
- [X] Add Scalar for testing

### Data Models
- [ ] Create Player, Group, Game, Score entities
- [ ] Define repository interfaces
- [ ] Set up database context and migrations

### Business Logic
- [ ] Build player management (create, list, get one)
- [ ] Build group management (create, list, add players)
- [ ] Build game tracking (create game with scores, get games)
- [ ] Build stats calculation (average, high/low, games played)

### API Endpoints
- [ ] Players endpoints
- [ ] Groups endpoints
- [ ] Games endpoints
- [ ] Stats endpoints

### Test It
- [ ] Create a group with 3 players
- [ ] Record a few games
- [ ] Check stats look correct

---

## Phase 2: Add Clerk Auth

### Setup
- [ ] Install and configure Clerk

### Data Models
- [ ] Add User entity
- [ ] Link Groups to Users (owner)
- [ ] Keep Players optionally linked to Users (for guests)

### Business Logic
- [ ] User registration/sync
- [ ] Player claiming (link guest to account)
- [ ] Stats across all user's groups
- [ ] Authorization checks (who can do what)

### API Updates
- [ ] Protect endpoints that need auth
- [ ] Add user profile endpoint
- [ ] Add player claiming endpoint
- [ ] Add current user extraction from token

### Test It
- [ ] Sign up and create group as logged-in user
- [ ] Add guest player
- [ ] Guest player signs up and claims their history
- [ ] Verify users can't access other users' groups