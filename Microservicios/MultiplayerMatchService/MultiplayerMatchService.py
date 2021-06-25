from sqlite3.dbapi2 import connect
from flask import Flask, jsonify, abort, request
from flask.helpers import make_response
from flask_sqlalchemy import SQLAlchemy


# Se crea la app
app = Flask(__name__)


# Se define puerto y host
PORT = 5002
HOST = '0.0.0.0'





# ...Metodo POST...
@app.route('/hangman/api/v1.0/multiplayer/findmatch', methods=["POST"])

def findMatch():
    nickname = request.form.get("name")

    





# Main para correr la app, definiendo puerto y host
if __name__ == "__main__":

        print("Server running in port %s"%(PORT))

        app.debug = True

        app.run(host=HOST, port=PORT)