import binascii
from Crypto.Cipher import AES
s=binascii.unhexlify("140b41b22a29beb4061bda66b6747e14")
print(s)
obj = AES.new(
#obj = AES.new('140b41b22a29beb4061bda66b6747e14', AES.MODE_CBC, 'This is an IV456')
#message = "4ca00ff4c898d61e1edbf1800618fb2828a226d160dad07883d04e008a7897ee2e4b7465d5290d0c0e6c6822236e1daafb94ffe0c5da05d9476be028ad7c1d81"
#ciphertext = obj.encrypt(message)
#print(ciphertext)