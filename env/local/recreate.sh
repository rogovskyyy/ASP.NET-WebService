#!/usr/bin/env bash
set -a
source ./env/local/.env
set +a

docker-compose up --remove-orphans --build --force-recreate --detach