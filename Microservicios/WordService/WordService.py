from flask import Flask, jsonify, abort
from WordReader import getMultiplesWords

app = Flask(__name__)

@app.route('/hangman/api/v1.0/word/<int:amountOfWords>', methods=['GET'])
def getRandomWord(amountOfWords):
    word = getMultiplesWords(amountOfWords)
    return jsonify(word)


@app.errorhandler(404)
def not_found(error):
    return jsonify({'error': 'Error'}), 404


if __name__ == '__main__':
    app.run(port=5000, debug=True)
