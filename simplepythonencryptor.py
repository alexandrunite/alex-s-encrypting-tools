import random
import string

chars = list(" " + string.punctuation + string.digits + string.ascii_letters)
key = chars.copy()
random.shuffle(key)

def encrypt(plain_text):
    return ''.join([key[chars.index(letter)] for letter in plain_text])

def decrypt(cipher_text):
    return ''.join([chars[key.index(letter)] for letter in cipher_text])

# ENCRYPT
plain_text = input("Enter a message to encrypt: ")
cipher_text = encrypt(plain_text)

print(f"original message: {plain_text}")
print(f"encrypted message: {cipher_text}")

# DECRYPT
cipher_text = input("Enter a message to decrypt: ")
plain_text = decrypt(cipher_text)

print(f"encrypted message: {cipher_text}")
print(f"original message: {plain_text}")
