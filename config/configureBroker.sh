#!/bin/sh
schema () {
  echo -e "\t The environment variables \$rmq_admin_username and \$rmq_admin_password are required"
  echo -e "\t Expected invocation format: configureBroker.sh <vhost> <server>"
  exit
}

if [ -z "$rmq_admin_username" ]
  then
    echo "Error: Environment variable $rmq_admin_username must be set"
    schema
fi
if [ -z "$rmq_admin_password" ]
  then
    echo "Error: Environment variable $rmq_admin_password must be set"
    schema
fi
if [ -z "$1" ]
  then
    echo "Error: Must pass script vhost name"
    schema
fi
if [ -z "$2" ]
  then
    echo "Warning: server name is empty"
    schema
fi
                    bash -x _configureRMQVirtualHost.sh $rmq_admin_username $rmq_admin_password $1 $2
