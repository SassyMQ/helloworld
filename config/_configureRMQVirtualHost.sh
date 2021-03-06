#!/bin/sh
USER="$1"
PASS="$2"
VHOST="$3"
SERVER="$4"

set -x

curl -s -i -k -u $USER:$PASS -H "content-type:application/json" -XPUT $SERVER/api/vhosts/$VHOST | grep HTTP 
curl -s -i -k -u $USER:$PASS -H "content-type:application/json" -d "{\"configure\":\".*\",\"write\":\".*\",\"read\":\".*\"}" -XPUT $SERVER/api/permissions/$VHOST/$USER | grep HTTP 
curl -s -i -k -u $USER:$PASS -H "content-type:application/json" -d "{\"configure\":\".*\",\"write\":\".*\",\"read\":\".*\"}" -XPUT $SERVER/api/permissions/$VHOST/guest | grep HTTP 


curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"durable\":true}" -XPUT $SERVER/api/queues/$VHOST/programmer.all | grep HTTP
                         
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"durable\":true}" -XPUT $SERVER/api/queues/$VHOST/world.all | grep HTTP
                         
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"durable\":true}" -XPUT $SERVER/api/queues/$VHOST/universe.all | grep HTTP
                         


curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"type\":\"topic\",\"durable\":true,\"internal\":false}" -XPUT $SERVER/api/exchanges/$VHOST/programmermic | grep HTTP
                         
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"type\":\"topic\",\"durable\":true,\"internal\":true}" -XPUT $SERVER/api/exchanges/$VHOST/programmer.general | grep HTTP
                                
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"type\":\"topic\",\"durable\":true,\"internal\":true}" -XPUT $SERVER/api/exchanges/$VHOST/programmer.all | grep HTTP
                                
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"type\":\"topic\",\"durable\":true,\"internal\":false}" -XPUT $SERVER/api/exchanges/$VHOST/worldmic | grep HTTP
                         
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"type\":\"topic\",\"durable\":true,\"internal\":true}" -XPUT $SERVER/api/exchanges/$VHOST/world.general | grep HTTP
                                
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"type\":\"topic\",\"durable\":true,\"internal\":true}" -XPUT $SERVER/api/exchanges/$VHOST/world.all | grep HTTP
                                
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"type\":\"topic\",\"durable\":true,\"internal\":false}" -XPUT $SERVER/api/exchanges/$VHOST/universemic | grep HTTP
                         
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"type\":\"topic\",\"durable\":true,\"internal\":true}" -XPUT $SERVER/api/exchanges/$VHOST/universe.all | grep HTTP
                                
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"routing_key\":\"world.general.programmer.#\",\"arguments\":{}}" -XPOST $SERVER/api/bindings/$VHOST/e/programmermic/e/world.general | grep HTTP
                         
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"routing_key\":\"#\",\"arguments\":{}}" -XPOST $SERVER/api/bindings/$VHOST/e/world.general/e/world.all | grep HTTP
                         
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"routing_key\":\"#\",\"arguments\":{}}" -XPOST $SERVER/api/bindings/$VHOST/e/programmer.all/q/programmer.all | grep HTTP
                         
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"routing_key\":\"programmer.general.world.#\",\"arguments\":{}}" -XPOST $SERVER/api/bindings/$VHOST/e/worldmic/e/programmer.general | grep HTTP
                         
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"routing_key\":\"#\",\"arguments\":{}}" -XPOST $SERVER/api/bindings/$VHOST/e/programmer.general/e/programmer.all | grep HTTP
                         
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"routing_key\":\"#\",\"arguments\":{}}" -XPOST $SERVER/api/bindings/$VHOST/e/world.all/q/world.all | grep HTTP
                         
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"routing_key\":\"#\",\"arguments\":{}}" -XPOST $SERVER/api/bindings/$VHOST/e/programmer.all/e/world.all | grep HTTP
                         
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"routing_key\":\"world.general.universe.#\",\"arguments\":{}}" -XPOST $SERVER/api/bindings/$VHOST/e/universemic/e/world.general | grep HTTP
                         
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"routing_key\":\"#\",\"arguments\":{}}" -XPOST $SERVER/api/bindings/$VHOST/e/universe.all/q/universe.all | grep HTTP
                         
curl -i -k -u $USER:$PASS -H "content-type:application/json" -d"{\"routing_key\":\"#\",\"arguments\":{}}" -XPOST $SERVER/api/bindings/$VHOST/e/world.all/e/universe.all | grep HTTP
                         

                    