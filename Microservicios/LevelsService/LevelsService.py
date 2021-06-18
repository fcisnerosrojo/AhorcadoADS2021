from enum import auto
from os import remove
from flask import Flask, jsonify, abort, request
from flask.helpers import make_response
from WordReader import sendLevel, insertLevel
import requests
import urllib
import json
import re
import time

# Se crea la app
app = Flask(__name__)


# Se define puerto y host
PORT = 3200
HOST = '0.0.0.0'



# ...GET METHOD...
@app.route("/hangman/api/v1.0/level/send/")

def sender():

    # Se invoca el metodo para enviar el level correspondiente al WordService
    res = sendLevel()

    return res



# ...POST METHOD...
@app.route("/hangman/api/v1.0/level/", methods=["POST"])

def createLevel():
    # convierte el JSON en un objeto de tipo "dictionary"
    levels = request.get_json()

    res = insertLevel(levels)

    return res



# Main para correr la app, definiendo puerto y host
if __name__ == "__main__":

        print("Server running in port %s"%(PORT))

        app.debug = True

        app.run(host=HOST, port=PORT)