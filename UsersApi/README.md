# MicroService RESR User account retrieve

This is a restful api creating a database and used to create and get an account using GET and POST requests.

# Installation

First clone or download this repository.

In the api folder, run the Docker with the command :

 ` docker run -d -p 8080:80 --name myapp usersapi
`

Start the docker with this command  :
` docker start /myapp
`

Access your data at URL http://localhost:8080/api/user

##  User Object

An user is represented as a Json Object :
 { "fname":"Will", "lname":"Smith", "address":"Avenue de l'Europe"}

#  REST calls
## HTTP Get

/api/user
Return all users as a JSON Array.

/api/user/{id}
Return user corresponding to the given id as a JSON Object.

## HTTP Post

/api/user
Creating a new User corresponding to the JSON Object User given in the Request Body.
