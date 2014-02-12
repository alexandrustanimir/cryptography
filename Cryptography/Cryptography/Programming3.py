from Crypto.Hash import SHA256
fileName =""
fileList = []
hashes =[]
with open(fileName, 'rb') as file:
        while True:
                 chunk = file.read(1024)
                 if chunk:
                         fileList.append(chunk)
                 else:
                         break
fileList.reverse()
temphash = SHA256.new(fileList[0])
print(temphash.hexdigest())
fileList.remove(fileList[0])
for item in fileList:
    item =  item + temphash.digest()
    temphash = SHA256.new(item)
    print(temphash.hexdigest())
