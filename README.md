# upnodo
Track every day with up, normal or down.

## Purpose
The purpose of this repository is to test architectural and technological ideas. 

## MongoDB

Setup environment (users)
1. `use DATABASE_NAME` 
2. `db.createCollection("users")`
3. Set fields to be unique 
   - `db.users.createIndex({ "email": 1 }, { unique: true })`
   - `db.users.createIndex({ "alias": 1 }, { unique: true })`