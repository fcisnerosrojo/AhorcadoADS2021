from datetime import datetime
from flask import Flask, jsonify, request
import time
import schedule
import requests

# Se crea la app
app = Flask(__name__)



# Se define puerto y host
PORT = 3201
HOST = '0.0.0.0'



def notifyLevelsService():
        print("Fecha de chequeo:")
        print(datetime.date(datetime.now()))

        print("Hora de chequeo:")
        print(datetime.time(datetime.now()))
        

        #Se realiza la peticion al LevelsService para que envie el nivel a WordService
        req = requests.get('http://127.0.0.1:3200/hangman/api/v1.0/level/send/')

        print(req)



# Programacion de en que fecha se debe enviar el nivel
schedule.every().friday.at('16:35').do(notifyLevelsService)

# Ciclo que controla si la fecha es la indicada para enviar el level correspondiente
while 1:
        schedule.run_pending()
        time.sleep(5)



# Main para correr la app, definiendo puerto y host
if __name__ == "__main__":

        print("Server running in port %s"%(PORT))

        app.debug = True

        app.run(host=HOST, port=PORT)
