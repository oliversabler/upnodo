# upnodo
Track every day with up, normal or down.

## Purpose
The purpose of this repository is to test architectural and technological ideas. 

## Get started
**Prerequisites:**
* TBD

**Steps**
1. Clone repository
2. Build docker image `docker build -t upnodo .`
3. Create and run docker container `docker run -d --rm -p 5000:80 --name upnodo-api upnodo`, 
   * `-d` Run container in the bakground 
   * `--rm` Remove the container on exit (`docker stop <container id>`)
   * `-p 5000:80` Map port 5000 on local machine to port 80 in container
   * `--name upnodo-api` Name the container
   * `upnodo` Name of the image

## MongoDB

Setup environment (moods)
1. `use DATABASE_NAME` 
2. `db.createCollection("moods")`
3. Set fields to be unique 
   - `db.moods.createIndex({ "moodRecordId": 1 }, { unique: true })`

Setup environment (users)
1. `use DATABASE_NAME` 
2. `db.createCollection("users")`
3. Set fields to be unique 
   - `db.users.createIndex({ "email": 1 }, { unique: true })`
   - `db.users.createIndex({ "alias": 1 }, { unique: true })`
   - `db.users.createIndex({ "userId": 1 }, { unique: true })`