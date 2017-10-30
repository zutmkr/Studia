import socket, pickle

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.connect(('127.0.0.1', 4000))

while True:
    data = raw_input("Wyslij tekst na serwer: ")
    data = pickle.dumps(data)
    server.send(data)
    data = server.recv(1024)
    data = pickle.loads(data)
    print(data)

server.close()