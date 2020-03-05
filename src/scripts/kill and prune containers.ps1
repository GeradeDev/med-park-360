docker stop $(docker ps -aq)

docker container prune -f

Read-Host