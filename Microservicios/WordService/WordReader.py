import re
import random


def getMultiplesWords(amount):

    path = ".\WordService\DataBase\levels.txt"

    with open(path) as file:

        allData = file.read()
        allData_array = re.split("\n",allData)

        result = []

        for i in range(amount):
            word = allData_array[random.randint(0,len(allData_array)-1)]

            result.append(
                {
                    'word': word
                }
            )
        
    return result


def loadWord(word):
    
    path = ".\WordService\DataBase\levels.txt"

    my_file = open(path, "a")

    my_file.write("\n" + word)

    my_file.close()

    return word