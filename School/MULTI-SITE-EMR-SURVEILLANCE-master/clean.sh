#!/bin/bash

# Kill & Delete all containers
docker kill $(docker ps -q)
docker rm $(docker ps -a -q)

# Delete all images
docker rmi $(docker images -q)