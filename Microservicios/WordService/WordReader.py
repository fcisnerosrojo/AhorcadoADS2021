import re
import random

# def getWord():
#     path = '.\WordService\DataBase\words.txt'
#     with open(path) as file:
#         allData = file.read()
#         allData_array = re.split("\n",allData)
#         word = allData_array[random.randint(0,len(allData_array))]
#         result = [
#             {
#                 'word': word
#             }
#         ]
#     return result

def getMultiplesWords(amount):
    path = '.\WordService\DataBase\words.txt'
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