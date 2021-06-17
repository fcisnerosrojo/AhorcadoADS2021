from flask import jsonify
from flask.helpers import make_response
import requests
import re



def sendLevel():
    path = '.\LevelsService\DataBase\levels.txt'

    # Se obtiene la primer palabra de la BD
    with open(path) as file:
        allData = file.read()

        allData_array = re.split("\n",allData)

        word = allData_array[0]

        result = {
            "word": word
            }

    req = requests.post('http://127.0.0.1:5000/hangman/api/v1.0/word/', result)

    # Se borra la primera palabra de la BD
    removeFirstLevel()

    if req != None:
        res = make_response(jsonify({"message":"level enviado"}),201)
    else:
        res = make_response(jsonify({"error":"nivel no enviado"}))
        
    return res



def removeFirstLevel():
    path = '.\LevelsService\DataBase\levels.txt'

    file = open(path, "r")

    lines = file.readlines()
    file.close()

    del lines[0]

    new_file = open(path, "w+")

    for line in lines:
        new_file.write(line)
    
    new_file.close()