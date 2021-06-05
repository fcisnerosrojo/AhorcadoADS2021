from flask import Flask, jsonify, abort
import requests
import urllib

app = Flask(__name__)

ip_address= 'http://127.0.0.1:5000'

@app.route('/hangman/api/v1.0/match/<int:amountWords>', methods=['GET'])
def getMatch(amountWords = 0):
    response = urllib.request.urlopen('http://127.0.0.1:5000/hangman/api/v1.0/word/'+ str(amountWords)).read().decode('utf-8')
    return response


if __name__ == '__main__':
    app.run(port=5001, debug=True)