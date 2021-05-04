FROM mcr.microsoft.com/mssql/server:2019-latest

# Create a config directory
RUN mkdir -p /usr/config
WORKDIR /usr/config

# Bundle config source
COPY . /usr/config

# Grant permissions for to our scripts to be executable
#RUN sudo chmod +x /usr/config/entrypoint.sh
#RUN sudo chmod +x /usr/config/configure-db.sh

ENTRYPOINT ["/usr/config/entrypoint.sh"]

# Tail the setup logs to trap the process
CMD ["tail -f /dev/null"]

HEALTHCHECK --interval=15s CMD /opt/mssql-tools/bin/sqlcmd -U sa -P $MSSQL_SA_PASSWORD -Q "select 1" && grep -q "MSSQL CONFIG COMPLETE" ./config.log