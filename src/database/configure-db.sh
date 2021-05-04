#!/bin/bash

# wait for MSSQL server to start
export STATUS=1
i=0
sapwd="$(<"${SA_PASSWORD_FILE}")"
cadb=$CIVILAPP_DATABASE
cau=$(<$CIVILAPP_USER)
cap=$(<$CIVILAPP_PASSWORD)
script="CREATE DATABASE ${cadb};
GO
USE ${cadb};
GO
CREATE LOGIN ${cau} WITH PASSWORD = '${cap}';
GO
SELECT @@VERSION
GO
CREATE USER ${cau} FOR LOGIN ${cau};
GO
ALTER ROLE db_owner ADD MEMBER [${cau}];
GO"

echo "monkey"
echo $script
echo "monkey too $sapwd"

while [[ $STATUS -ne 0 ]] && [[ $i -lt 60 ]]; do
	i=$i+1
	echo "$i : $sapwd"
	/opt/mssql-tools/bin/sqlcmd -t 1 -U sa -P "$sapwd" -Q "select 1" >> /dev/null
	STATUS=$?
done

if [ $STATUS -ne 0 ]; then 
	echo "Error: MSSQL SERVER took more than thirty seconds to start up."
	exit 1
fi

echo "======= MSSQL SERVER STARTED ========" | tee -a ./config.log
# Run the setup script to create the DB and the schema in the DB


/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$sapwd" -d master -Q script

echo "======= MSSQL CONFIG COMPLETE =======" | tee -a ./config.log