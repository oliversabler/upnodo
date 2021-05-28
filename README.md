# upnodo
Track every day with up, normal or down.

## Todo
- [x] Create docker network with upnodo API and MongoDB connection
- [x] Create docker-compose file
- [ ] Fix Models and Repositories, not working properly anymore
- [ ] Fix https binding
- [ ] Make sure some fields are unique in MongoDb
- [ ] Add analyzers and .editorconfig
- [ ] Nullable enable?
- [ ] Unit Tests
- [ ] NSwag?

## Purpose
The purpose of this repository is to test architectural and technological ideas. 

## Get started
### Prerequisites
* [Docker](https://www.docker.com/products/docker-desktop)

### Run
To get the API and MongoDb running, all you need to do is run `docker-compose up -d`. When you are done you can stop it by running `docker-compose down`.

### Run (manually)
If you for some reason want to create and run the API and MongoDb manually in a docker network, do the following steps:
1. Create network `docker network upnodo`
2. Download and run MongoDb `docker run -d --rm --net=upnodo --name upnodo-db mongo`
3. Build docker image `docker build -t upnodo .`
4. Create and run docker container `docker run -d --rm --network=upnodo -p 5000:80 --name upnodo-api upnodo`, 
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
