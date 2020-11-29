#! /bin/bash
# coap-client -m get -u "bjarne" -k "K2FdNhdmGBGDb1ni" "coaps://192.168.1.51:5684/15001" -> result/getdevices.json

USERNAME = $1
CODE = $2
coap-client -m get -u "$USERNAME" -k "$CODE" "coaps://192.168.1.51:5684/15001"

