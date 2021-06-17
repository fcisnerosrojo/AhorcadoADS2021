from enum import auto
from os import remove
from flask import Flask, jsonify, abort, request
from flask.helpers import make_response
from WordReader import sendLevel
import requests
import urllib
import json
import re
import time
import schedule

# Se crea la app
app = Flask(__name__)


# Se define puerto y host
PORT = 3200
HOST = '0.0.0.0'



# ...GET METHOD...
@app.route("/")

# Metodo de prueba que indicaria la pagina principal
def home():
    return "<h1 style='color:blue'> This is home!!</h1>"



# ...POST METHOD...
@app.route("/level/", methods=["POST"])

def createLevel():
    # convierte el JSON en un objeto de tipo "dictionary"
    levels = request.get_json()

    path = '.\LevelsService\DataBase\levels.txt'

    my_file = open(path, "a")

    for word in levels:
        pal = levels[word]
        my_file.write(pal + "\n")

    my_file.close()

    # se envia el nivel al microservicio "WordService"
    res = sendLevel()

    res = make_response(jsonify({"message":"level añadido"}),201)

    return res



# Main para correr la app, definiendo puerto y host
if __name__ == "__main__":

        print("Server running in port %s"%(PORT))

        app.debug = True

        app.run(host=HOST, port=PORT)