import binascii

def HexToBinary(value):
	scale = 16 ## equals to hexadecimal
	num_of_bits = 8
	value = bin(int(value, scale))[2:].zfill(num_of_bits)
	return value

def HexToAscii(data):
	return ''.join(chr(int(data[i:i+2], 16)) for i in range(0, len(data), 2))

def strxor(a, b):     # xor two strings of different lengths
    if len(a) > len(b):
        return "".join([chr(ord(x) ^ ord(y)) for (x, y) in zip(a[:len(b)], b)])
    else:
        return "".join([chr(ord(x) ^ ord(y)) for (x, y) in zip(a, b[:len(a)])])
def binarystrxor(a,b):
	if(len(a) > len(b)):
		return "".join([strxor(x,y) for(x,y) in zip(a[:len(b)],b)])
	else:
		return "".join([strxor(x,y) for(x,y) in zip(a,b[:len(a)])])

def main():
	hex_string ="315c4eeaa8b5f8aaf9174145bf43e1784b8fa00dc71d885a804e5ee9fa40b16349c146fb778cdf2d3aff021dfff5b403b510d0d0455468aeb98622b137dae857553ccd8883a7bc37520e06e515d22c954eba5025b8cc57ee59418ce7dc6bc41556bdb36bbca3e8774301fbcaa3b83b220809560987815f65286764703de0f3d524400a19b159610b11ef3e"
	hex_string2="32510ba9a7b2bba9b8005d43a304b5714cc0bb0c8a34884dd91304b8ad40b62b07df44ba6e9d8a2368e51d04e0e7b207b70b9b8261112bacb6c866a232dfe257527dc29398f5f3251a0d47e503c66e935de81230b59b7afb5f41afa8d661cb"
	#print(binarystrxor(HexToBinary(hex_string),HexToBinary(hex_string)))
	binarystring = binarystrxor(HexToBinary(hex_string),HexToBinary(hex_string2))
	print(binarystring)
	buf = ''
	for i in range(len(binarystring)):
		if i % 8 ==0 and	 i > 0 :
			print(ord(int(buf,2)))
			buf=''
		else:
			buf = buf+ binarystring[i]
			print(i)



#	print (HexToAscii('315c4eeaa8b5f8aaf9174145bf43e1784b8fa00dc71d885a804e5ee9fa40b16349c146fb778cdf2d3aff021dfff5b403b510d0d0455468aeb98622b137dae857553ccd8883a7bc37520e06e515d22c954eba5025b8cc57ee59418ce7dc6bc41556bdb36bbca3e8774301fbcaa3b83b220809560987815f65286764703de0f3d524400a19b159610b11ef3e'))
main()
