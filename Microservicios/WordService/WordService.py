from flask import Flask, jsonify, abort, request
from flask.helpers import make_response
from WordReader import getMultiplesWords, loadWord

app = Flask(__name__)



# ...GET METHOD...
@app.route('/hangman/api/v1.0/word/<int:amountOfWords>', methods=['GET'])
def getRandomWord(amountOfWords):
    word = getMultiplesWords(amountOfWords)
    return jsonify(word)


@app.errorhandler(404)
def not_found(error):
    return jsonify({'error': 'Error'}), 404



# ...POST METHOD...
@app.route("/hangman/api/v1.0/word/", methods=["POST"])

def insertWord():
    
    word = request.form.get("word")

    ans = loadWord(word)

    if ans != None:
        res = make_response(jsonify({"message":"level añadido"}),201)
    else:
        res = make_response(jsonify({"error":"nivel no añadido"}))

    return res



if __name__ == '__main__':
    app.run(port=5000, debug=True)
