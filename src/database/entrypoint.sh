#!/bin/bash

#Get password from docker secret
password="$(<"${SA_PASSWORD_FILE}")"
echo "password: $password"
export SA_PASSWORD="$password"

# Start SQL Server
/opt/mssql/bin/sqlservr &

# Start the script to create the DB and user
/usr/config/configure-db.sh

# Call extra command

eval $1